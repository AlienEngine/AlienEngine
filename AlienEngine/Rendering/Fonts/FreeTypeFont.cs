using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Physics.Entities.Prefabs;
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

        private readonly float Size;

        private const uint DPI = 96;

        private Dictionary<char, Character> _characters;

        public Dictionary<char, Character> Characters => _characters;

        private ShaderProgram _shaderProgram = new FontShaderProgram();

        private uint _vao;

        private uint _vbo;

        private Matrix4f _projectionMatrix;

        public Matrix4f ProjectionMatrix
        {
            get { return _projectionMatrix; }
            set { _projectionMatrix = value; }
        }

        /// <summary>
        /// Creates a new instace of FreeTypeFont
        /// </summary>
        /// <param name="fontPath">The path to the font file</param>
        /// <param name="size">Size of the font</param>
        /// <param name="style">Style of the font</param>
        /// <exception cref="ArgumentException"></exception>
        public FreeTypeFont(string fontPath, float size, FontStyle style)
        {
            // Check that the font exists
            if (!File.Exists(fontPath))
                throw new ArgumentException("The specified font path does not exist", nameof(fontPath));

            // Initialize
            _characters = new Dictionary<char, Character>();
            _fontLibrary = new Library();

            StyleFlags fontStyle = StyleFlags.None;
            switch (style)
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
                    Debug.WriteLine("Invalid style flag chosen for FreeTypeFont: " + style);
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
            Size = size;
            _fontFace.SetCharSize(0, Size, 0, DPI);

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
                    _characters[(char) i] = new Character
                    {
                        Texture = new Texture(_fontFace.Glyph),
                        Size = new Sizef(_fontFace.Glyph.Bitmap.Width, _fontFace.Glyph.Bitmap.Rows),
                        Bearing = new Vector2f(_fontFace.Glyph.BitmapLeft, _fontFace.Glyph.BitmapTop),
                        Advance = (uint) _fontFace.Glyph.Advance.X.Value
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to load the character \"" + (char) i + "\"");
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

        public void RenderText(string text, FontRendererConfiguration config)
        {
            var textWidth = CalculateWidth(text, config.Scale);

            // Change the renderer behaviour
            Renderer.BackupState(RendererBackupMode.Blending);
            Renderer.Blending();

            _shaderProgram.Bind();
            _shaderProgram.SetUniform("textColor", config.Color);
            _shaderProgram.SetUniform("projection", ProjectionMatrix);

            GL.ActiveTexture(GL.COLOR_TEXTURE_UNIT_INDEX);

            GL.BindVertexArray(_vao);

            switch (config.TextAlignement)
            {
                case TextAlignement.Center:
                    config.Position.X += config.Container.Width / 2;
                    break;
                case TextAlignement.Right:
                    config.Position.X += config.Container.Width;
                    break;
            }
                        
            switch (config.TextOrigin)
            {
                case TextOrigin.Bottom:
                        config.Position.X -= textWidth / 2;
                    break;

                case TextOrigin.BottomRight:
                    config.Position.X -= textWidth;
                    break;

                case TextOrigin.MiddleLeft:
                    config.Position.Y -= Size / 2;
                    break;

                case TextOrigin.Middle:
                    config.Position.X -= textWidth / 2;
                    config.Position.Y -= Size / 2;
                    break;

                case TextOrigin.MiddleRight:
                    config.Position.Y -= Size / 2;
                    break;

                case TextOrigin.TopLeft:
                    config.Position.Y -= Size;
                    break;

                case TextOrigin.Top:
                    config.Position.X -= textWidth / 2;
                    config.Position.Y -= Size;
                    break;

                case TextOrigin.TopRight:
                    config.Position.X -= textWidth;
                    config.Position.Y -= Size;
                    break;
            }

            float currentWidth = 0.0f;
            int currentLine = 0;
            float xAdvance = 0.0f;
            float yAdvance = 0.0f;

            if (config.TextWrapMode == TextWrapMode.None)
            {
                foreach (char c in text)
                {
                    Character ch = Characters[c];

                    var xpos = config.Position.X + xAdvance + ch.Bearing.X * config.Scale.X;
                    var ypos = config.Position.Y - yAdvance - (ch.Size.Y - ch.Bearing.Y) * config.Scale.Y;

                    var w = ch.Size.X * config.Scale.X;
                    var h = ch.Size.Y * config.Scale.Y;

                    DrawLetter(xpos, ypos, h, w, ch);

                    xAdvance += (ch.Advance >> 6) * config.Scale.X + config.CharacterSpacing;;
                }
            }
            else if (config.TextWrapMode == TextWrapMode.BreakWord)
            {
                foreach (char c in text)
                {
                    Character ch = Characters[c];

                    currentWidth += (ch.Advance >> 6) * config.Scale.X + config.CharacterSpacing;

                    if (config.Container.Width > 0 && currentWidth + config.Scale.X > config.Container.Width)
                    {
                        xAdvance = 0;
                        currentLine++;
                        currentWidth = (ch.Advance >> 6) * config.Scale.X + config.CharacterSpacing;
                    }

                    yAdvance = currentLine * Size * config.LineSpacing * config.Scale.Y;

                    var xpos = config.Position.X + xAdvance + ch.Bearing.X * config.Scale.X;
                    var ypos = config.Position.Y - yAdvance - (ch.Size.Y - ch.Bearing.Y) * config.Scale.Y;

                    var w = ch.Size.X * config.Scale.X;
                    var h = ch.Size.Y * config.Scale.Y;

                    DrawLetter(xpos, ypos, h, w, ch);

                    xAdvance = currentWidth;
                }
            }
            else if (config.TextWrapMode == TextWrapMode.Normal)
            {
                var words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    var _word = word + " ";

                    currentWidth += CalculateWidth(_word, config.Scale) + config.CharacterSpacing * _word.Length;
                    
                    if (config.Container.Width > 0 && currentWidth + config.Scale.X > config.Container.Width)
                    {
                        xAdvance = 0;
                        currentLine++;
                        currentWidth = CalculateWidth(_word, config.Scale) + config.CharacterSpacing * _word.Length;
                    }

                    yAdvance = currentLine * Size * config.LineSpacing * config.Scale.Y;
                    
                    foreach (char c in _word)
                    {
                        Character ch = Characters[c];

                        var xpos = config.Position.X + xAdvance + ch.Bearing.X * config.Scale.X;
                        var ypos = config.Position.Y - yAdvance - (ch.Size.Y - ch.Bearing.Y) * config.Scale.Y;

                        var w = ch.Size.X * config.Scale.X;
                        var h = ch.Size.Y * config.Scale.Y;

                        DrawLetter(xpos, ypos, h, w, ch);

                        xAdvance += (ch.Advance >> 6) * config.Scale.X + config.CharacterSpacing;;
                    }
                }
            }

            GL.BindVertexArray(0);

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        private void DrawLetter(float xpos, float ypos, float h, float w, Character ch)
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

            ch.Texture.Bind(GL.COLOR_TEXTURE_UNIT_INDEX);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);

            GL.BufferSubData(BufferTarget.ArrayBuffer, 0, sizeof(float) * 6 * 4, vertices);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DrawArrays(BeginMode.Triangles, 0, 6);
        }

        public float CalculateWidth(string text)
        {
            return CalculateWidth(text, Vector2f.One);
        }

        public float CalculateWidth(string text, Vector2f scale)
        {
            float width = 0;

            foreach (char c in text)
                width += (Characters[c].Advance >> 6) * scale.X;

            return width;
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