using System;

using AlienEngine.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Graphics.Shaders;

namespace AlienEngine.UI
{
    public class Text : UIElement
    {
        #region Built-In Font Sizes
        public enum DefaultFontSize
        {
            _12pt = 0,
            _14pt = 1,
            _16pt = 2,
            _24pt = 3,
            _32pt = 4,
            _48pt = 5
        }

        public static BMFont FontFromSize(DefaultFontSize font)
        {
            switch (font)
            {
                case DefaultFontSize._12pt: return BMFont.LoadFont("fonts/font12.fnt");
                case DefaultFontSize._14pt: return BMFont.LoadFont("fonts/font14.fnt");
                case DefaultFontSize._16pt: return BMFont.LoadFont("fonts/font16.fnt");
                case DefaultFontSize._24pt: return BMFont.LoadFont("fonts/font24.fnt");
                case DefaultFontSize._32pt: return BMFont.LoadFont("fonts/font32.fnt");
                case DefaultFontSize._48pt: return BMFont.LoadFont("fonts/font48.fnt");
                default: //Logger.Instance.WriteLine("Unknown font " + font + " requested.");
                    return BMFont.LoadFont("fonts/font12.fnt");
            }
        }
        #endregion

        #region Private Fields
        private string text;
        private IFont font;
        private Color3 _color;
        private Font.Alignement justification;
        #endregion

        internal IFont Font
        {
            get { return font; }
        }


        #region Public Properties
        public Color3 Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Font.Alignement Justification
        {
            get { return justification; }
            set
            {
                if (justification != value)
                {
                    justification = value;
                    if (font is BMFont)
                        ((BMFont)font).CreateString(VAO, text, _color, justification, _scale);
                    else if (font is Font)
                    {
                        ((Font)font).TextAlignement = justification;
                        ((Font)font).CreateString(VAO, text, _color, justification, _scale);
                    }
                }
            }
        }

        private VAO<Vector3f, Vector2f> VAO;

        private bool _fit = true;
        private float _scale = 1;

        public Sizei Padding { get; set; }

        public Sizei TextSize { get; private set; }

        public float FontSize
        {
            get { return _scale; }
            set
            {
                _scale = value;
                if (font is BMFont)
                    ((BMFont)font).CreateString(VAO, text, _color, justification, _scale);
                else if (font is Font)
                {
                    ((Font)font).FontSize = _scale;
                    ((Font)font).CreateString(VAO, text, _color, justification, _scale);
                }
            }
        }

        public bool FitSizeToText
        {
            get { return _fit; }
            set { _fit = value; }
        }

        public string String
        {
            get { return text; }
            set
            {
                // do not cause the text to update if it is the same
                if (text == value || value == null) return;

                if (text != null && text.Length == value.Length)
                {
                    if (font is BMFont)
                        ((BMFont)font).CreateString(VAO, value, Color, Justification, FontSize);
                    else if (font is Font)
                    {
                        ((Font)font).String = value;
                        ((Font)font).CreateString(VAO, value, _color, Justification, FontSize);
                    }
                }
                else
                {
                    if (font is BMFont)
                    {
                        if (this.VAO != null) this.VAO.Dispose();
                        this.VAO = ((BMFont)font).CreateString(Program, value, Color, Justification, FontSize);
                        this.VAO.DisposeChildren = true;
                    }
                    else if (font is Font)
                    {
                        ((Font)font).String = value;
                        if (this.VAO != null) this.VAO.Dispose();
                        this.VAO = ((Font)font).CreateString(Program, value, Color, Justification, FontSize);
                        this.VAO.DisposeChildren = true;
                    }
                }

                text = value;
                if (font is BMFont)
                    this.TextSize = new Sizei(((BMFont)font).GetWidth(text), ((BMFont)font).Height);
                else if (font is Font)
                    this.TextSize = new Sizei((int)((Font)font).GetWidth(), (int)((Font)font).GetHeight());

                if (FitSizeToText)
                {
                    Size = TextSize;
                }
            }
        }
        #endregion

        #region Constructors
        public Text(ShaderProgram program, IFont font, string text, Font.Alignement justification = UI.Font.Alignement.Left, float fontSize = 1)
            : this(program, font, text, Color3.White, justification, fontSize)
        {
        }

        public Text(IFont font, string text, Font.Alignement justification = UI.Font.Alignement.Left, float fontSize = 1)
            : this(Shaders.FontShader, font, text, Color3.White, justification, fontSize)
        {
        }

        public Text(DefaultFontSize font, string text, Font.Alignement justification = UI.Font.Alignement.Left, float fontSize = 1)
            : this(Shaders.FontShader, FontFromSize(font), text, Color3.White, justification, fontSize)
        {
        }

        public Text(DefaultFontSize font, string text, Color3 color, Font.Alignement justification = UI.Font.Alignement.Left, float fontSize = 1)
            : this(Shaders.FontShader, FontFromSize(font), text, color, justification, fontSize)
        {
        }

        public Text(ShaderProgram program, IFont font, string text, Color3 color, Font.Alignement justification = UI.Font.Alignement.Left, float fontSize = 1)
        {
            this.font = font;
            this.Program = program;
            this.Justification = justification;
            this.Color = color;
            this.String = text;
            this.Position = new Point2i(0, 0);
            this.FontSize = fontSize;

            if (FitSizeToText)
            {
                Size = TextSize;
            }
        }
        #endregion

        #region Public Methods
        public void DrawWithCharacterCount(int count)
        {
            if (font is BMFont)
            {
                int vertexCount = Math.Min(count * 6, VAO.VertexCount);

                GL.ActiveTexture(0);
                GL.BindTexture(((BMFont)font).FontTexture);

                GL.Enable(EnableCap.Blend);
                Program.Bind();
                Program.SetUniform("position", new Vector2f(CorrectedPosition.X + Padding.X, CorrectedPosition.Y + Padding.Y));
                Program.SetUniform("color", Color);
                VAO.BindAttributes(Program);
                GL.DrawElements(BeginMode.Triangles, vertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
                GL.Disable(EnableCap.Blend);
            }
        }
        #endregion

        #region UIElement Overrides (Draw, Pick, Dispose)
        public override void Draw()
        {
            base.Draw();

            if (font is BMFont)
            {
                ((BMFont)font).FontTexture.Bind(GL.COLOR_TEXTURE_UNIT_INDEX);

                int yoffset = 0;
                if (this.Size.Y > TextSize.Y)
                    yoffset = (Size.Y - TextSize.Y) / 2;

                GL.Enable(EnableCap.Blend);
                Program.Bind();
                if (this.Justification == UI.Font.Alignement.Center) Program.SetUniform("position", new Vector2f(CorrectedPosition.X + Padding.X + Size.X / 2, CorrectedPosition.Y + Padding.Y + yoffset));
                else Program.SetUniform("position", new Vector2f(CorrectedPosition.X + Padding.X, CorrectedPosition.Y + Padding.Y + yoffset));
                Program.SetUniform("color", Color);
                VAO.Draw();
                GL.Disable(EnableCap.Blend);
            }
            else if (font is Font)
            {
                ((Font)font).FontTexture.Bind(GL.COLOR_TEXTURE_UNIT_INDEX);

                int yoffset = 0;
                if (this.Size.Y > TextSize.Y)
                    yoffset = (Size.Y - TextSize.Y) / 2;

                GL.Enable(EnableCap.Blend);
                Program.Bind();
                if (this.Justification == UI.Font.Alignement.Center) Program.SetUniform("position", new Vector2f(CorrectedPosition.X + Padding.X + Size.X / 2, CorrectedPosition.Y + Padding.Y + yoffset));
                else Program.SetUniform("position", new Vector2f(CorrectedPosition.X + Padding.X, CorrectedPosition.Y + Padding.Y + yoffset));
                Program.SetUniform("color", Color);
                VAO.Draw();
                GL.Disable(EnableCap.Blend);
                //((Font)font).Draw();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (VAO != null)
            {
                VAO.Dispose();
                VAO = null;
            }

            base.Dispose(true);
        }
        #endregion
    }
}
