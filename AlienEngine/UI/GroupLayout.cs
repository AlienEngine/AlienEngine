using System;
using System.Drawing;
using System.Linq;

namespace AlienEngine.UI
{
	public class GroupLayout : Control
	{
        public Skin.GroupLayoutSkin Skin { get { return skin; } set { skin = value; Invalidate(); } }

		private Skin.GroupLayoutSkin skin;

		public GroupLayout(Gui gui) : base(gui)
		{
			Render += OnRender;

			skin = Gui.Skin.GroupLayout;

			outer = new Rectangle(0, 0, 100, 100);
			sizeMin = new Sizei(0, 0);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

        protected override void UpdateLayout()
		{
			if (AutoSize)
			{
				if (Controls.Count() > 0)
				{
                    outer.Width = Controls.Max(c => c.Outer.Right) - Controls.Min(c => c.Outer.Left) + skin.Border.Horizontal;
                    outer.Height = Controls.Max(c => c.Outer.Bottom) - Controls.Min(c => c.Outer.Top) + skin.Border.Vertical;
				}
				else
				{
                    outer.Width = skin.Border.Horizontal;
                    outer.Height = skin.Border.Vertical;
				}
			}

			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
			outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);
            Inner = new Rectangle(skin.Border.Left, skin.Border.Top, outer.Width - skin.Border.Horizontal, outer.Height - skin.Border.Vertical);
		}

        private void OnRender(object sender, double timeDelta)
        {
            Draw.Fill(ref skin.BorderColor);
            Draw.FillRect(Inner, ref skin.BackgroundColor);
        }
	}
}

