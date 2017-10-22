using System;

using AlienEngine;
using AlienEngine.Graphics;

namespace AlienEngine.UI
{
    public class Button : UIElement
    {
        #region Properties
        public bool Enabled { get; set; }

        public Color4 EnabledColor { get; set; }
        #endregion

        #region Text Support
        private Text text = null;
        private IFont font = null;
        private string textString = null;
        private float fontSize = 1;

        public IFont Font
        {
            get { return font; }
            set
            {
                if (text != null) text.Dispose();
                font = value;
                if (textString != null && textString.Length != 0)
                {
                    text = new Text(Shaders.FontShader, font, textString, UI.Font.Alignement.Center, fontSize);
                    text.FitSizeToText = false;
                }
            }
        }

        public string Text
        {
            get { return textString; }
            set
            {
                textString = value;
                if (text == null)
                {
                    if (font != null)
                    {
                        text = new Text(Shaders.FontShader, font, textString, UI.Font.Alignement.Center, fontSize);
                        text.FitSizeToText = false;
                        text.Size = this.Size;
                    }
                }
                else text.String = textString;
            }
        }

        public float FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                if (text == null)
                {
                    if (font != null)
                    {
                        text = new Text(Shaders.FontShader, font, textString, UI.Font.Alignement.Center, fontSize);
                        text.FitSizeToText = false;
                        text.Size = this.Size;
                    }
                }
                else text.FontSize = fontSize;
            }
        }
        #endregion

        #region Constructors
        public Button(Texture texture)
        {
            this.BackgroundColor = Color4.Transparent;
            this.EnabledColor = Color4.Transparent;
            this.BackgroundTexture = texture;

            this.RelativeTo = Corner.TopLeft;
            this.Size = new Sizei(texture.Size.Width, texture.Size.Height);
        }

        public Button(int width, int height)
        {
            this.BackgroundColor = new Color4(0.3f, 0.3f, 0.3f, 1f);
            this.EnabledColor = new Color4(0.3f, 0.9f, 0.3f, 1f);

            this.RelativeTo = Corner.TopLeft;
            this.Size = new Sizei(width, height);
        }
        #endregion

        #region UIElement Overrides (OnResize, Dispose, Draw)
        public override void OnResize()
        {
            if (text != null) text.Size = this.Size;

            base.OnResize();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (text != null) text.Dispose();
        }

        public override void Draw()
        {
            base.DrawQuadColored(Enabled ? EnabledColor : BackgroundColor);
            if (BackgroundTexture != null) base.DrawQuadTextured();

            if (text != null)
            {
                text.CorrectedPosition = this.CorrectedPosition;
                text.Draw();
            }
        }
        #endregion
    }
}
