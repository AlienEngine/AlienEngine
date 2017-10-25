using System;
using System.Drawing;
using System.Linq;

namespace AlienEngine.UI
{
	public class ContextMenu : FlowLayout
	{
		public ContextMenu(Gui gui) : base(gui)
		{
			FlowDirection = FlowDirection.TopDown;
			AutoSize = true;

			Skin = Gui.Skin.ContextMenu;
		}

        protected override void UpdateLayout()
        {
            if (Controls.Count() > 0)
            {
                int maxWidth = 0;
                foreach (var entry in Controls)
                {
                    entry.AutoSize = true;
                    maxWidth = Math.Max(maxWidth, entry.Width);
                }
                foreach (var entry in Controls)
                {
                    entry.AutoSize = false;
                    entry.Size = new Sizei(maxWidth, entry.Height);
                }
            }

            base.UpdateLayout();
        }
	}
}
