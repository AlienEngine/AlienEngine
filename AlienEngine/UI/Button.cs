using System;
using System.Drawing;
using AlienEngine.Core.Rendering.Fonts;

namespace AlienEngine.UI
{
    public class Button : Control
    {
        public string Text
        {
            get { return text; }
            set
            {
                if (value != text)
                {
                    text = value;
                    Invalidate();
                }
            }
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                Invalidate();
            }
        }

        public Skin.ButtonSkin SkinEnabled
        {
            get { return skinEnabled; }
            set
            {
                skinEnabled = value;
                Invalidate();
            }
        }

        public Skin.ButtonSkin SkinPressed
        {
            get { return skinPressed; }
            set
            {
                skinPressed = value;
                Invalidate();
            }
        }

        public Skin.ButtonSkin SkinHover
        {
            get { return skinHover; }
            set
            {
                skinHover = value;
                Invalidate();
            }
        }

        public Skin.ButtonSkin SkinDisabled
        {
            get { return skinDisabled; }
            set
            {
                skinDisabled = value;
                Invalidate();
            }
        }

        public event EventHandler Click;

        private string text = "";
        private FontText textProcessed = new FontText();
        private Sizef textSize;
        private Skin.ButtonSkin skinEnabled, skinPressed, skinHover, skinDisabled;
        private Skin.ButtonSkin skin;
        private bool enabled = true;
        private bool down = false;
        private bool over = false;

        public Button(Gui gui) : base(gui)
        {
            Render += OnRender;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;

            skinEnabled = Gui.Skin.ButtonEnabled;
            skinPressed = Gui.Skin.ButtonPressed;
            skinHover = Gui.Skin.ButtonHover;
            skinDisabled = Gui.Skin.ButtonDisabled;

            outer = new Rectangle(0, 0, 75, 0);
            sizeMin = new Sizei(8, 8);
            sizeMax = new Sizei(int.MaxValue, int.MaxValue);
        }

        protected override void UpdateLayout()
        {
            skin = Enabled ? (down ? skinPressed : (over ? skinHover : skinEnabled)) : skinDisabled;

            outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);

            int innerWidth = outer.Width - skin.Border.Horizontal;
            textSize = skin.Font.ProcessText(textProcessed, text, skin.TextAlign);
            int minHeight = Math.Max(sizeMin.Height, (int) textSize.Height + skin.Border.Vertical);

            if (AutoSize)
            {
                innerWidth = (int) textSize.Width;
                outer.Width = innerWidth + skin.Border.Horizontal;
                outer.Height = minHeight;
                outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
            }

            outer.Height = Math.Min(Math.Max(outer.Height, minHeight), sizeMax.Height);

            Inner = new Rectangle(
                skin.Border.Left, skin.Border.Top,
                innerWidth, outer.Height - skin.Border.Vertical);
        }

        private void OnRender(object sender, double timeDelta)
        {
            Draw.Fill(ref skin.BorderColor);
            Draw.FillRect(Inner, ref skin.BackgroundColor);
            Draw.Text(textProcessed, Inner, ref skin.Color);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (enabled && e.Button == MouseButton.Left)
            {
                isDragged = true;
                down = true;
                Invalidate();
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (enabled && e.Button == MouseButton.Left)
            {
                if (down)
                {
                    down = false;
                    isDragged = false;
                    if (Click != null && new Rectangled(0, 0, outer.Width, outer.Height).Contains(e.Location))
                        Click(this, e);
                    Invalidate();
                }
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            over = true;
            Invalidate();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            over = false;
            Invalidate();
        }
    }
}