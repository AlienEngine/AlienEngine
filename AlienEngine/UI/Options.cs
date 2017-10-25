using System;
using System.Linq;

namespace AlienEngine.UI
{
	public class Options : FlowLayout
	{
        public CheckBox Selection { get { return selection; } set { if (Controls.Contains(value)) Select(value, EventArgs.Empty); } }

        public event EventHandler Changed;

        private CheckBox selection;

		public Options(Gui gui) : base(gui)
		{
			outer = new Rectangle(0, 0, 0, 0);
		}

		public override T Add<T>(T control)
		{
            if (!(control is CheckBox))
                throw new InvalidOperationException("only GLCheckBoxes are allowed on GLOptions instances");
			base.Add(control);
            (control as CheckBox).Changed += Select;
			return control;
		}

		public override void Remove(Control control)
		{
			base.Remove(control);
            (control as CheckBox).Changed -= Select;
		}

        private void Select(object sender, EventArgs e)
        {
            if(selection != null)
                selection.Checked = false;

            CheckBox senderCheckBox = (CheckBox)sender;
            selection = senderCheckBox;
            senderCheckBox.Checked = true;

            if(Changed != null)
                Changed(sender, e);
        }
	}
}

