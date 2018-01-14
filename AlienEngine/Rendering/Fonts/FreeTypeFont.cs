using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AlienEngine.UI;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Shaders;
using AlienEngine.Core.Resources;
using AlienEngine.Imaging;
using AlienEngine.Shaders;
using SharpFont;

namespace AlienEngine.Core.Rendering.Fonts
{
    public class FreeTypeFont : IFont, IDisposable
    {
        private Library _fontLibrary;

        private Face _fontFace;

        private const uint DPI = 96;

        private Dictionary<char, Character> _characters;

        public Dictionary<char, Character> Characters => _characters;

        private ShaderProgram _shaderProgram = new FontShaderProgram();

        private uint _vao;

        private uint _vbo;

        private Matrix4f _projectionMatrix;

        private FontRendererConfiguration _config;

        public Matrix4f ProjectionMatrix
        {
            get { return _projectionMatrix; }
            set { _projectionMatrix = value; }
        }

        public FontRendererConfiguration Configuration => _config;

        /// <summary>
        /// Creates a new instace of FreeTypeFont
        /// </summary>
        /// <param name="fontPath">The path to the font file</param>
        /// <param name="size">Size of the font</param>
        /// <param name="style">Style of the font</param>
        /// <exception cref="ArgumentException"></exception>
        public FreeTypeFont(string fontPath, FontRendererConfiguration configuration)
        {
            // Check that the font exists
            if (!File.Exists(fontPath))
                throw new ArgumentException("The specified font path does not exist", nameof(fontPath));

            // Initialize
            _characters = new Dictionary<char, Character>();
            _fontLibrary = new Library();

            StyleFlags fontStyle = StyleFlags.None;
            switch (configuration.FontStyle)
            {
                case FontStyle.Bold:
                    fontStyle = StyleFlags.Bold;
                    break;
                case FontStyle.Italic:
                    fontStyle = StyleFlags.Italic;
                    break;
                case FontStyle.Regular:
                    fontStyle = StyleFlags.None;
                    break;
                default:
                    Debug.WriteLine("Invalid style flag chosen for FreeTypeFont: " + configuration.FontStyle);
                    break;
            }

            // Get total number of faces in a font file
            var tempFace = _fontLibrary.NewFace(fontPath, -1);
            int numberOfFaces = tempFace.FaceCount;

            // Dispose of the temporary face
            tempFace.Dispose();
            tempFace = null;

            // Loop through to find the style we want
            for (int i = 0; i < numberOfFaces; i++)
            {
                tempFace = _fontLibrary.NewFace(fontPath, i);

                // If we've found the style, exit loop
                if (tempFace.StyleFlags == fontStyle)
                    break;

                // Dispose temp face and keep searching
                tempFace.Dispose();
                tempFace = null;
            }

            // Use default font face if correct style not found
            if (tempFace == null)
            {
                Debug.WriteLine("Could not find correct face style in font: " + fontStyle);
                tempFace = _fontLibrary.NewFace(fontPath, 0);
            }

            // Set the face for this instance
            _fontFace = tempFace;

            // Set the size
            _fontFace.SetCharSize(0, configuration.FontSize, 0, DPI);

            // Save the configuration
            _config = configuration;

            // Load characters
            BuildCharMap();

            // Build buffer objects
            BuildBufferObjects();

            // Register this element as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        private void BuildCharMap()
        {
            for (uint i = 0; i < 256; i++)
            {
                try
                {
                    // Load character glyph
                    _fontFace.LoadChar(i, LoadFlags.Render, LoadTarget.Normal);

                    // Now store the character for later use
                    _characters[(char)i] = new Character
                    {
                        Texture = new Texture(_fontFace.Glyph),
                        Size = new Sizef(_fontFace.Glyph.Bitmap.Width, _fontFace.Glyph.Bitmap.Rows),
                        Bearing = new Vector2f(_fontFace.Glyph.BitmapLeft, _fontFace.Glyph.BitmapTop),
                        Advance = (uint)_fontFace.Glyph.Advance.X.Value
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to load the character \"" + (char)i + "\"");
                }
            }
        }

        private void BuildBufferObjects()
        {
            _vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            GL.BindVertexArray(_vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);

            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * 6 * 4, new float[0], BufferUsageHint.DynamicDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void RenderLine(string lineText, Sizef textSize, Point2f textPosition, int lineNumber = 0)
        {
            lineText = lineText.Trim();

            float textWidth = CalculateWidth(lineText);
            float xAdvance = 0.0f;
            float yAdvance = 0.0f;

            if (_config.TextWrapMode == TextWrapMode.None)
            {
                switch (_config.TextAlignement)
                {
                    case TextAlignement.Center:
                        xAdvance += (_config.Container.Width - textWidth) / 2;
                        break;
                    case TextAlignement.Right:
                        xAdvance += (_config.Container.Width - textWidth);
                        break;
                }
            }
            else
            {
                switch (_config.TextAlignement)
                {
                    case TextAlignement.Center:
                        xAdvance += (textSize.Width - textWidth) / 2;
                        break;
                    case TextAlignement.Right:
                        xAdvance += (textSize.Width - textWidth);
                        break;
                }
            }

            yAdvance = lineNumber * (_config.FontSize + _config.LineSpacing) * _config.Scale.Y;

            foreach (char c in lineText)
            {
                Character ch = Characters[c];

                var xpos = textPosition.X + xAdvance + ch.Bearing.X * _config.Scale.X;
                var ypos = textPosition.Y - yAdvance - (ch.Size.Y - ch.Bearing.Y) * _config.Scale.Y;

                var w = ch.Size.X * _config.Scale.X;
                var h = ch.Size.Y * _config.Scale.Y;

                DrawCharacter(xpos, ypos, h, w, ch);

                xAdvance += (ch.Advance >> 6) * _config.Scale.X + _config.CharacterSpacing;
            }
        }

        // TODO: Add a RenderLine() method in FreeTypeFont to render text line by line and use TextAlignment
        public void RenderText(string text)
        {
            // Change the renderer behaviour
            RendererManager.BackupState(RendererBackupMode.Blending);
            RendererManager.Blending();

            _shaderProgram.Bind();
            _shaderProgram.SetUniform("textColor", _config.Color);
            _shaderProgram.SetUniform("projection", ProjectionMatrix);

            GL.ActiveTexture(GL.DIFFUSE_TEXTURE_UNIT_INDEX);

            GL.BindVertexArray(_vao);

            var textSize = CalculateSize(text);
            var lineHeight = _config.FontSize * _config.Scale.Y;
            var position = _config.Position;

            switch (_config.TextOrigin)
            {
                case Origin.BottomLeft:
                    position.Y += textSize.Height - lineHeight;
                    break;

                case Origin.Bottom:
                    position.X -= textSize.Width / 2;
                    position.Y += textSize.Height - lineHeight;
                    break;

                case Origin.BottomRight:
                    position.X -= textSize.Width;
                    position.Y += textSize.Height - lineHeight;
                    break;

                case Origin.MiddleLeft:
                    position.Y += (textSize.Height / 2) - lineHeight;
                    break;

                case Origin.Center:
                    position.X -= textSize.Width / 2;
                    position.Y += (textSize.Height / 2) - lineHeight;
                    break;

                case Origin.MiddleRight:
                    position.X -= textSize.Width;
                    position.Y += (textSize.Height / 2) - lineHeight;
                    break;

                case Origin.TopLeft:
                    position.Y -= lineHeight;
                    break;

                case Origin.Top:
                    position.X -= textSize.Width / 2;
                    position.Y -= lineHeight;
                    break;

                case Origin.TopRight:
                    position.X -= textSize.Width;
                    position.Y -= lineHeight;
                    break;
            }

            switch (_config.TextOrigin)
            {
                case Origin.TopLeft:
                case Origin.Top:
                case Origin.TopRight:
                    position.Y -= (_config.Container.Height - textSize.Height) / 2f;
                    break;

                case Origin.BottomLeft:
                case Origin.Bottom:
                case Origin.BottomRight:
                    position.Y += (_config.Container.Height - textSize.Height) / 2f;
                    break;
            }

            float currentWidth = 0.0f;
            int currentLine = 0;

            if (_config.TextWrapMode == TextWrapMode.None)
            {
                RenderLine(text, textSize, position, currentLine);
            }
            else if (_config.TextWrapMode == TextWrapMode.BreakWord)
            {
                string line = string.Empty;

                foreach (char c in text)
                {
                    Character ch = Characters[c];
                    float charWidth = (ch.Advance >> 6) * _config.Scale.X + _config.CharacterSpacing;

                    currentWidth += charWidth;

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        RenderLine(line, textSize, position, currentLine);

                        currentLine++;
                        currentWidth = charWidth;

                        line = string.Empty;
                    }

                    line += c;
                }

                if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                {
                    RenderLine(line, textSize, position, currentLine);

                    line = string.Empty;
                }
            }
            else if (_config.TextWrapMode == TextWrapMode.Normal)
            {
                var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var line = string.Empty;

                foreach (string word in words)
                {
                    var _word = word + " ";
                    float _wordWidth = CalculateWidth(_word) + _config.CharacterSpacing * _word.Length;

                    currentWidth += _wordWidth;

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        RenderLine(line, textSize, position, currentLine);

                        currentLine++;
                        currentWidth = _wordWidth;

                        line = string.Empty;
                    }

                    line += _word;
                }

                if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                {
                    RenderLine(line, textSize, position, currentLine);

                    line = string.Empty;
                }
            }

            GL.BindVertexArray(0);

            GL.BindTexture(TextureTarget.Texture2D, 0);

            RendererManager.RestoreState(RendererBackupMode.Blending);
        }

        private void DrawCharacter(float xpos, float ypos, float h, float w, Character ch)
        {
            var vertices = new float[6, 4]
            {
                {xpos, ypos + h, 0.0f, 0.0f},
                {xpos, ypos, 0.0f, 1.0f},
                {xpos + w, ypos, 1.0f, 1.0f},
                {xpos, ypos + h, 0.0f, 0.0f},
                {xpos + w, ypos, 1.0f, 1.0f},
                {xpos + w, ypos + h, 1.0f, 0.0f}
            };

            ch.Texture.Bind(GL.DIFFUSE_TEXTURE_UNIT_INDEX);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);

            GL.BufferSubData(BufferTarget.ArrayBuffer, 0, sizeof(float) * 6 * 4, vertices);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DrawArrays(BeginMode.Triangles, 0, 6);
        }

        public float CalculateWidth(string text)
        {
            return CalculateWidth(text, _config.Scale);
        }

        public float CalculateWidth(string text, Vector2f scale)
        {
            float width = 0;

            foreach (char c in text)
                width += (Characters[c].Advance >> 6) * scale.X;

            return width;
        }

        public Sizef CalculateSize(string text)
        {
            Sizef bRect;

            float currentWidth = 0.0f;
            int currentLine = 0;

            float width = 0.0f;
            float height = 0.0f;

            if (_config.TextWrapMode == TextWrapMode.None)
            {
                width = CalculateWidth(text);
                height = _config.FontSize * _config.Scale.Y;
            }
            else if (_config.TextWrapMode == TextWrapMode.BreakWord)
            {
                foreach (char c in text)
                {
                    Character ch = Characters[c];

                    float charWidth = (ch.Advance >> 6) * _config.Scale.X + _config.CharacterSpacing;

                    currentWidth += charWidth;

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        currentLine++;
                    }

                    height = _config.Scale.Y * ((_config.FontSize + _config.LineSpacing) * (currentLine + 1) - _config.LineSpacing);

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        width = MathHelper.Max(width, currentWidth - charWidth);
                        currentWidth = charWidth;
                    }
                    else
                        width = MathHelper.Max(width, currentWidth);
                }
            }
            else if (_config.TextWrapMode == TextWrapMode.Normal)
            {
                var words = text.Split(new char[] { ' ' });

                foreach (string word in words)
                {
                    var _word = word + " ";
                    float _wordWidth = CalculateWidth(_word) + _config.CharacterSpacing * _word.Length;

                    currentWidth += _wordWidth;

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        currentLine++;
                    }

                    height = _config.Scale.Y * ((_config.FontSize + _config.LineSpacing) * (currentLine + 1) - _config.LineSpacing);

                    if (_config.Container.Width > 0 && currentWidth + _config.Scale.X > _config.Container.Width)
                    {
                        width = MathHelper.Max(width, currentWidth - _wordWidth - CalculateWidth(" ") - _config.CharacterSpacing);
                        currentWidth = _wordWidth;
                    }
                    else
                        width = MathHelper.Max(width, currentWidth);
                }
            }

            bRect = new Sizef(width, height);

            return bRect;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return _fontFace.FamilyName ?? "";
        }

        private void ReleaseUnmanagedResources()
        {
            if (_vao != 0)
            {
                GL.DeleteVertexArray(_vao);
                _vao = 0;
            }

            if (_vbo != 0)
            {
                GL.DeleteBuffer(_vbo);
                _vbo = 0;
            }
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();

            if (disposing)
            {
                _fontFace.Dispose();
                _fontFace = null;

                _fontLibrary.Dispose();
                _fontLibrary = null;

                _shaderProgram.Dispose();
                _shaderProgram = null;

                _characters.Clear();
                _characters = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FreeTypeFont()
        {
            Dispose(false);
        }
    }
}