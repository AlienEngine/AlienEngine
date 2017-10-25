using System;
using System.Drawing;
using System.Linq;

namespace AlienEngine.UI
{
	public class FlowLayout : Control
	{
        public FlowDirection FlowDirection { get { return flowDirection; } set { flowDirection = value; Invalidate(); } }
        public Skin.FlowLayoutSkin Skin { get { return skin; } set { skin = value; Invalidate(); } }

		private FlowDirection flowDirection = FlowDirection.LeftToRight;
		private Skin.FlowLayoutSkin skin;
		private Rectangle background;

		public FlowLayout(Gui gui) : base(gui)
		{
			Render += OnRender;

			skin = Gui.Skin.FlowLayout;

			outer = new Rectangle(0, 0, 100, 100);
			sizeMin = new Sizei(0, 0);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

		private void Invalidate(object sender, EventArgs e)
		{
            Invalidate();
		}

		private void UpdatePositions()
		{
			int current = 0;
			switch(FlowDirection)
			{
				case FlowDirection.LeftToRight:
					foreach(Control control in Controls)
					{
						Rectangle o = control.Outer;
						control.Outer = new Rectangle(current, 0, o.Width, o.Height);
						current += o.Width + skin.Space;
					}
					break;
				case FlowDirection.RightToLeft:
					current = Inner.Width;
					foreach(Control control in Controls)
					{
						Rectangle o = control.Outer;
						current -= o.Width;
						control.Outer = new Rectangle(current, 0, o.Width, o.Height);
						current -= skin.Space;
					}
					break;
				case FlowDirection.TopDown:
					foreach(Control control in Controls)
					{
						Rectangle o = control.Outer;
						control.Outer = new Rectangle(0, current, o.Width, o.Height);
						current += o.Height + skin.Space;
					}
					break;
				case FlowDirection.BottomUp:
					current = Inner.Height;
					foreach(Control control in Controls)
					{
						Rectangle o = control.Outer;
						current -= o.Height;
						control.Outer = new Rectangle(0, current, o.Width, o.Height);
						current -= skin.Space;
					}
					break;
			}
		}

        protected override void UpdateLayout()
		{
			UpdatePositions();

			if (AutoSize)
			{
				if (Controls.Count() > 0)
				{
					outer.Width = Controls.Max(c => c.Outer.Right) - Controls.Min(c => c.Outer.Left) + skin.Padding.Horizontal + skin.Border.Horizontal;
					outer.Height = Controls.Max(c => c.Outer.Bottom) - Controls.Min(c => c.Outer.Top) + skin.Padding.Vertical + skin.Border.Vertical;
				}
				else
				{
					outer.Width = skin.Padding.Horizontal + skin.Border.Horizontal;
					outer.Height = skin.Padding.Vertical + skin.Border.Vertical;
				}
			}

			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
			outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);
			background = new Rectangle(
				skin.Border.Left, skin.Border.Top,
				outer.Width - skin.Border.Horizontal, outer.Height - skin.Border.Vertical);
			Inner = new Rectangle(
				background.Left + skin.Padding.Left, background.Top + skin.Padding.Top,
				background.Width - skin.Padding.Horizontal, background.Height - skin.Padding.Vertical);

            if(flowDirection == FlowDirection.BottomUp || flowDirection == FlowDirection.RightToLeft)
			    UpdatePositions();
		}

        private void OnRender(object sender, double timeDelta)
		{
			Draw.Fill(ref skin.BorderColor);
			Draw.FillRect(ref background, ref skin.BackgroundColor);
		}

		public override T Add<T>(T control)
		{
			base.Add(control);
            control.Resize += Invalidate;
            Invalidate();
			return control;
		}

		public override void Remove(Control control)
		{
			base.Remove(control);
            control.Resize -= Invalidate;
            Invalidate();
		}
	}
}
