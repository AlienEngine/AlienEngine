using System;
using System.Drawing;

namespace AlienEngine.UI
{
	public class Slider : Control
	{
		public SliderOrientation Direction { get { return direction; } set { direction = value; Invalidate(); } }
        public float Value { get { return value; } set { this.value = value; Invalidate(); if (ValueChanged != null) ValueChanged(this, EventArgs.Empty); } }
        public bool Enabled { get { return enabled; } set { enabled = value; Invalidate(); } }
        public Skin.SliderSkin SkinEnabled { get { return skinEnabled; } set { skinEnabled = value; Invalidate(); } }
        public Skin.SliderSkin SkinPressed { get { return skinPressed; } set { skinPressed = value; Invalidate(); } }
        public Skin.SliderSkin SkinHover { get { return skinHover; } set { skinHover = value; Invalidate(); } }
        public Skin.SliderSkin SkinDisabled { get { return skinDisabled; } set { skinDisabled = value; Invalidate(); } }
        public float MouseWheelStep = 0.001f;

        public event EventHandler ValueChanged;

        private Skin.SliderSkin skinEnabled, skinPressed, skinHover, skinDisabled;
        private Skin.SliderSkin skin;
		private SliderOrientation direction = SliderOrientation.Vertical;
        private float value = 0.0f;
		private bool enabled = true;
		private bool down = false;
		private bool over = false;

		public Slider(Gui gui) : base(gui)
		{
			Render += OnRender;
            MouseMove += OnMouseMove;
			MouseDown += OnMouseDown;
			MouseUp += OnMouseUp;
			MouseEnter += OnMouseEnter;
			MouseLeave += OnMouseLeave;
            MouseWheel += OnMouseWheel;

			skinEnabled = Gui.Skin.SliderEnabled;
            skinPressed = Gui.Skin.SliderPressed;
            skinHover = Gui.Skin.SliderHover;
            skinDisabled = Gui.Skin.SliderDisabled;

			outer = new Rectangle(0, 0, 8, 8);
			sizeMin = new Sizei(8, 8);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

        protected override void UpdateLayout()
		{
			skin = Enabled ? (down ? skinPressed : (over ? skinHover : skinEnabled)) : skinDisabled;

			if (AutoSize)
			{
				outer.Width = sizeMin.Width;
				outer.Height = sizeMin.Height;
				if (Parent != null)
				{
					if (direction == SliderOrientation.Horizontal)
						outer.Width = Parent.Inner.Width;
					else
						outer.Height = Parent.Inner.Height;
				}
			}

			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
			outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);

            if (!enabled)
                value = 0.0f;
            value = Math.Min(Math.Max(value, 0.0f), 1.0f);
			if (direction == SliderOrientation.Horizontal)
				Inner = new Rectangle((int)((outer.Width - 8) * value), 0, 8, 8);
            else
				Inner = new Rectangle(0, (int)((outer.Height - 8) * value), 8, 8);
		}

        private void OnRender(object sender, double timeDelta)
		{
			Draw.Fill(ref skin.BackgroundColor);
            Draw.FillRect(Inner, ref skin.KnobColor);
		}

		private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            if (isDragged && enabled)
            {
				if (direction == SliderOrientation.Horizontal)
					Value = (float)(e.X - 4) / (float)(outer.Width - 8);
                else
					Value = (float)(e.Y - 4) / (float)(outer.Height - 8);
            }
        }

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.Button == MouseButton.Left && enabled)
			{
				isDragged = true;
				down = true;
				if (direction == SliderOrientation.Horizontal)
					Value = (float)(e.X - 4) / (float)(outer.Width - 8);
                else
					Value = (float)(e.Y - 4) / (float)(outer.Height - 8);
			}
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
            if (e.Button == MouseButton.Left && enabled)
			{
				if (down)
				{
					down = false;
					isDragged = false;
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

		private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Enabled)
                Value += (float)(-e.Delta * MouseWheelStep).Y;
        }
	}
}
