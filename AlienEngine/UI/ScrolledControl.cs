using System;
using System.Drawing;
using System.Linq;

namespace AlienEngine.UI
{
	internal class ScrolledControl : Control
    {
        public Sizei TotalSize;

        public ScrolledControl(Gui gui) : base(gui)
		{
            AutoSize = true;
            HandleMouseEvents = false;
        }

        protected override void UpdateLayout()
        {
            outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
            outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);
            Inner = new Rectangle(0, 0, outer.Width, outer.Height);

            TotalSize = new Sizei(0, 0);
			if (Controls.Any())
            {
                TotalSize.Width = Controls.Max(c => c.Outer.Right);
                TotalSize.Height = Controls.Max(c => c.Outer.Bottom);
            }

			if (Parent != null && !Parent.AutoSize) // avoid repeated calls if autosize is true
                Parent.Invalidate();
        }
    }
}
