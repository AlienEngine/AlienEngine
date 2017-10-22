using System;
using System.Collections.Generic;
using System.IO;

using AlienEngine.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Graphics.Shaders;
using AlienEngine.Core.Graphics.QuickFont;
using AlienEngine.Core.Graphics.QuickFont.Configuration;
using System.Drawing;

namespace AlienEngine.UI
{
    public class Font : IFont, IDisposable
    {
        #region Enums
        public enum Alignement
        {
            Left = QFontAlignment.Left,
            Center = QFontAlignment.Centre,
            Right = QFontAlignment.Right,
            Justify = QFontAlignment.Justify
        }

        public enum FontStyle
        {
            Bold = System.Drawing.FontStyle.Bold,
            Italic = System.Drawing.FontStyle.Italic,
            Regular = System.Drawing.FontStyle.Regular,
            Strikeout = System.Drawing.FontStyle.Strikeout,
            Underline = System.Drawing.FontStyle.Underline
        }

        public enum ShadowType
        {
            Blurred = Core.Graphics.QuickFont.Configuration.ShadowType.Blurred,
            Expanded = Core.Graphics.QuickFont.Configuration.ShadowType.Expanded
        }

        public enum TextGenerationRenderHint
        {
            AntiAlias = Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint.AntiAlias,
            AntiAliasGridFit = Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint.AntiAliasGridFit,
            ClearTypeGridFit = Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint.ClearTypeGridFit,
            SizeDependent = Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint.SizeDependent,
            SystemDefault = Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint.SystemDefault
        }

        public enum FontMonospacing
        {
            Natural = Core.Graphics.QuickFont.QFontMonospacing.Natural,
            No = Core.Graphics.QuickFont.QFontMonospacing.No,
            Yes = Core.Graphics.QuickFont.QFontMonospacing.Yes
        }
        #endregion

        private QFontDrawing _drawer;
        private QFontBuilderConfiguration _config;
        private QFont _text;
        private Alignement _alignement;
        private QFontRenderOptions _textOptions;
        private string _fontFile = string.Empty;
        private System.Drawing.Font _font;
        private float _fontSize;
        private FontStyle _fontStyle;
        private string _string = string.Empty;
        private Point2i _position;

        /// <summary>
        /// The font texture associated with this bitmap font.
        /// </summary>
        public Texture FontTexture { get; private set; }

        private bool _isCustomFont
        {
            get { return !string.IsNullOrEmpty(_fontFile); }
        }

        internal QFont Text
        {
            get { return _text; }
        }

        #region Public Properties (Configuration)
        public int ShadowBlurRadius
        {
            get { return _config.ShadowConfig.blurRadius; }
            set
            {
                _config.ShadowConfig.blurRadius = value;
                _buildText();
            }
        }

        public int ShadowBlurPasses
        {
            get { return _config.ShadowConfig.blurPasses; }
            set
            {
                _config.ShadowConfig.blurPasses = value;
                _buildText();
            }
        }

        public ShadowType FontShadowType
        {
            get { return (ShadowType)_config.ShadowConfig.Type; }
            set
            {
                _config.ShadowConfig.Type = (Core.Graphics.QuickFont.Configuration.ShadowType)value;
                _buildText();
            }
        }

        public string CharSet
        {
            get { return _config.charSet; }
            set
            {
                _config.charSet = value;
                _buildText();
            }
        }

        public int SuperSampleLevels
        {
            get { return _config.SuperSampleLevels; }
            set
            {
                _config.SuperSampleLevels = MathHelper.Clamp(value, 2, 4);
                _buildText();
            }
        }

        public TextGenerationRenderHint TextGenerationRenderType
        {
            get { return (TextGenerationRenderHint)_config.TextGenerationRenderHint; }
            set
            {
                _config.TextGenerationRenderHint = (Core.Graphics.QuickFont.Configuration.TextGenerationRenderHint)value;
            }
        }
        #endregion

        #region Public Properties (Render Options)
        public float CharacterSpacing
        {
            get { return _textOptions.CharacterSpacing; }
            set
            {
                _textOptions.CharacterSpacing = value;
            }
        }

        public Color4 Color
        {
            get { return _textOptions.Colour; }
            set
            {
                _textOptions.Colour = (Color)value;
            }
        }

        public bool DropShadowActive
        {
            get { return _textOptions.DropShadowActive; }
            set
            {
                _textOptions.DropShadowActive = value;
            }
        }

        public Color4 DropShadowColor
        {
            get { return _textOptions.DropShadowColour; }
            set
            {
                _textOptions.DropShadowColour = (Color)value;
                _textOptions.DropShadowOpacity = value.A;
            }
        }

        public Vector2f DropShadowOffset
        {
            get { return _textOptions.DropShadowOffset; }
            set
            {
                _textOptions.DropShadowOffset = value;
            }
        }

        public float DropShadowOpacity
        {
            set { _textOptions.DropShadowOpacity = value; }
        }

        public float JustifyCapContract
        {
            get { return _textOptions.JustifyCapContract; }
            set
            {
                _textOptions.JustifyCapContract = value;
            }
        }

        public float JustifyCapExpand
        {
            get { return _textOptions.JustifyCapExpand; }
            set
            {
                _textOptions.JustifyCapExpand = value;
            }
        }

        public float JustifyCharacterWeightForContract
        {
            get { return _textOptions.JustifyCharacterWeightForContract; }
            set
            {
                _textOptions.JustifyCharacterWeightForContract = value;
            }
        }

        public float JustifyCharacterWeightForExpand
        {
            get { return _textOptions.JustifyCharacterWeightForExpand; }
            set
            {
                _textOptions.JustifyCharacterWeightForExpand = value;
            }
        }

        public float JustifyContractionPenalty
        {
            get { return _textOptions.JustifyContractionPenalty; }
            set
            {
                _textOptions.JustifyContractionPenalty = value;
            }
        }

        public float LineSpacing
        {
            get { return _textOptions.LineSpacing; }
            set
            {
                _textOptions.LineSpacing = value;
            }
        }

        public bool LockToPixel
        {
            get { return _textOptions.LockToPixel; }
            set
            {
                _textOptions.LockToPixel = value;
            }
        }

        public float LockToPixelRatio
        {
            get { return _textOptions.LockToPixelRatio; }
            set
            {
                _textOptions.LockToPixelRatio = value;
            }
        }

        public FontMonospacing Monospacing
        {
            get { return (FontMonospacing)_textOptions.Monospacing; }
            set
            {
                _textOptions.Monospacing = (Core.Graphics.QuickFont.QFontMonospacing)value;
            }
        }

        public bool UseDefaultBlendFunction
        {
            get { return _textOptions.UseDefaultBlendFunction; }
            set
            {
                _textOptions.UseDefaultBlendFunction = value;
            }
        }

        public float WordSpacing
        {
            get { return _textOptions.WordSpacing; }
            set
            {
                _textOptions.WordSpacing = value;
            }
        }

        public bool WordWrap
        {
            get { return _textOptions.WordWrap; }
            set
            {
                _textOptions.WordWrap = value;
            }
        }
        #endregion

        #region Public Properties
        public Alignement TextAlignement
        {
            get { return _alignement; }
            set
            {
                _alignement = value;
                _updateDrawer();
            }
        }

        public Point2i Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _updateDrawer();
            }
        }

        public string String
        {
            get { return _string; }
            set
            {
                _string = value;
                _updateDrawer();
            }
        }

        public float FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                _buildText();
            }
        }

        public Sizei TextSize
        {
            get { return new Sizei(GetWidth(), GetHeight()); }
        }

        public int Height
        {
            get { return GetHeight(); }
        }
        #endregion

        #region Constructors
        public Font(string fontPath, float size, FontStyle style = FontStyle.Regular, bool addDropShadow = false)
        {
            _fontFile = fontPath;
            _fontSize = size;
            _fontStyle = style;
            _font = null;

            _drawer = new QFontDrawing();

            _config = new QFontBuilderConfiguration(addDropShadow);
            _textOptions = new QFontRenderOptions();

            _buildText();

            FontTexture = new Texture("Assets/test.png");
        }

        public Font() : this(string.Empty, 12, FontStyle.Regular, false)
        {
            _font = System.Drawing.SystemFonts.DefaultFont;

            _drawer = new QFontDrawing();

            _config = new QFontBuilderConfiguration();
            _textOptions = new QFontRenderOptions();

            _buildText();
        }
        #endregion

        public void Draw()
        {
            _drawer.ProjectionMatrix = UserInterface.UIProjectionMatrix;
            _updateDrawer();
            _drawer.Draw();
        }

        public int GetWidth()
        {
            return (int)_text.Measure(String).Width;
        }

        public int GetHeight()
        {
            return (int)_text.Measure(String).Height;
        }

        public int GetWidth(string text)
        {
            return (int)_text.Measure(text).Width;
        }

        public int GetWidth(char character)
        {
            return (int)_text.Measure(character.ToString()).Width;
        }

        private void _buildText()
        {
            if (_text != null)
            {
                _text.Dispose();
                _text = null;
            }

            _text = _isCustomFont ? new QFont(_fontFile, _fontSize, _config, (System.Drawing.FontStyle)_fontStyle, UserInterface.UIProjectionMatrix) : new QFont(_font, _config);
            _updateDrawer();

            _font = QFont.GetFont(_fontFile, FontSize, (System.Drawing.FontStyle)_fontStyle, SuperSampleLevels);
        }

        private void _updateDrawer()
        {
            UseDefaultBlendFunction = true;
            _drawer.DrawingPimitiveses.Clear();
            _drawer.Print(_text, String, new Vector3f(Position.X, Position.Y, 0), (QFontAlignment)TextAlignement, _textOptions);
            _drawer.RefreshBuffers();
        }

        private static int maxStringLength = 200;
        private static Vector3f[] vertices = new Vector3f[maxStringLength * 4];
        private static Vector2f[] uvs = new Vector2f[maxStringLength * 4];
        private static int[] indices = new int[maxStringLength * 6];

        private void CreateStringInternal(string text, Color3 color, Font.Alignement justification, float scale)
        {
            int xpos = 0;

            // calculate the initial x position depending on the justification
            if (justification == Font.Alignement.Right) xpos = -GetWidth(text);
            else if (justification == Font.Alignement.Center) xpos = -GetWidth(text) / 2;

            Vector3f scalingFactor = Vector3f.One * 3;

            for (int i = 0; i < text.Length; i++)
            {
                // grab the character, replacing with ' ' if the character isn't loaded
                QFontGlyph ch = _text.FontData.CharSetMapping[_text.FontData.CharSetMapping.ContainsKey(text[i]) ? text[i] : '_'];

                float offset = this.Height - ch.yOffset;

                // check for kerning
                /*if (i > 0 && kerning.ContainsKey(text[i - 1]) && kerning[text[i - 1]].ContainsKey(text[i]))
                    xpos += kerning[text[i - 1]][text[i]];*/
                xpos += 1;

                vertices[i * 4 + 0] = scalingFactor * new Vector3f(xpos, offset, 0);
                vertices[i * 4 + 1] = scalingFactor * new Vector3f(xpos, offset - Height, 0);
                vertices[i * 4 + 2] = scalingFactor * new Vector3f(xpos + GetWidth(ch.character), offset, 0);
                vertices[i * 4 + 3] = scalingFactor * new Vector3f(xpos + GetWidth(ch.character), offset - Height, 0);
                xpos += (int)ch.rect.Width;
                if (text[i] == '_') xpos += 3;

                uvs[i * 4 + 0] = new Vector2f(ch.rect.X, ch.rect.Y);
                uvs[i * 4 + 1] = new Vector2f(ch.rect.X, ch.rect.Height);
                uvs[i * 4 + 2] = new Vector2f(ch.rect.Width, ch.rect.Y);
                uvs[i * 4 + 3] = new Vector2f(ch.rect.Width, ch.rect.Height);

                indices[i * 6 + 0] = i * 4 + 2;
                indices[i * 6 + 1] = i * 4 + 0;
                indices[i * 6 + 2] = i * 4 + 1;
                indices[i * 6 + 3] = i * 4 + 3;
                indices[i * 6 + 4] = i * 4 + 2;
                indices[i * 6 + 5] = i * 4 + 1;
            }
        }

        /// <summary>
        /// Creates a string over top of an old string VAO of the same length.
        /// Does not overwrite the indices, since those should be consistent
        /// across VAOs of the same length when describing text.
        /// </summary>
        /// <param name="vao">The current vao object.</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        public void CreateString(VAO<Vector3f, Vector2f> vao, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f)
        {
            if (vao == null || vao.ID == 0) return;
            if (vao.VertexCount != text.Length * 6) throw new InvalidOperationException("Text length did not match the length of the current vertex array object.");

            CreateStringInternal(text, color, justification, scale);

            // simply update the underlying VBOs (indices shouldn't be modified)
            GL.BufferSubData(vao.vbos[0].ID, BufferTarget.ArrayBuffer, vertices, text.Length * 4);
            GL.BufferSubData(vao.vbos[1].ID, BufferTarget.ArrayBuffer, uvs, text.Length * 4);
        }

        /// <summary>
        /// Creates a new VAO object with a specified string.
        /// </summary>
        /// <param name="program">The shader program to use with this text (FontShader or Font3DShader).</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        /// <returns>The VAO which contains vertex, UV and index information.</returns>
        public VAO<Vector3f, Vector2f> CreateString(ShaderProgram program, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f)
        {
            if (text.Length > maxStringLength)
            {
                maxStringLength = (int)Math.Min(int.MaxValue, (text.Length * 1.5));

                vertices = new Vector3f[maxStringLength * 4];
                uvs = new Vector2f[maxStringLength * 4];
                indices = new int[maxStringLength * 6];
            }

            CreateStringInternal(text, color, justification, scale);

            // Create the vertex buffer objects and then create the array object
            return new VAO<Vector3f, Vector2f>(program,
                new VBO<Vector3f>(vertices, text.Length * 4),
                new VBO<Vector2f>(uvs, text.Length * 4),
                new string[] { "in_position", "in_uv" },
                new VBO<int>(indices, text.Length * 6, BufferTarget.ElementArrayBuffer));
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_text != null) _text.Dispose();
                    if (_font != null) _font.Dispose();
                    if (_drawer != null) _drawer.Dispose();
                    if (FontTexture != null) FontTexture.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
