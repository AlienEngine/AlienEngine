using System;
using System.Drawing;
using AlienEngine.Core.Graphics;

namespace AlienEngine.UI
{
	public class SplitLayout : Control
	{
		public SplitterOrientation Orientation { get { return orientation; } set { orientation = value; Invalidate(); } }
		public float SplitterPosition { get { return splitterPosition; } set { splitterPosition = value; Invalidate(); } }
		public Skin.SplitLayoutSkin Skin { get { return skin; } set { skin = value; Invalidate(); } }
		public Control First { get { return first; } }
		public Control Second { get { return second; } }

		private SplitterOrientation orientation = SplitterOrientation.Vertical;
		private Skin.SplitLayoutSkin skin;
		private Control first, second;
		private float splitterPosition = 0.5f;

		public SplitLayout(Gui gui) : base(gui)
		{
			MouseDown += OnMouseDown;
			MouseUp += OnMouseUp;
			MouseMove += OnMouseMove;
			Render += OnRender;

			skin = Gui.Skin.SplitLayout;

			outer = new Rectangle(0, 0, 100, 100);
			sizeMin = new Sizei(0, 0);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

        protected override void UpdateLayout()
		{
			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
			outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);
			Inner = new Rectangle(0, 0, outer.Width, outer.Height);

			splitterPosition = Math.Min(Math.Max(splitterPosition, 0.0f), 1.0f);
			if (orientation == SplitterOrientation.Vertical)
			{
				int splitter = (int)((Inner.Width - skin.SplitterSize) * splitterPosition);
				if (first != null)
					first.Outer = new Rectangle(0, 0, splitter, Inner.Height);
				if (second != null)
					second.Outer = new Rectangle(splitter + skin.SplitterSize, 0, Inner.Width - splitter - skin.SplitterSize, Inner.Height);
                splitterRect = new Rectangle(splitter, 0, skin.SplitterSize, Inner.Height);
			}
			else
			{
				int splitter = (int)((Inner.Height - skin.SplitterSize) * splitterPosition);
				if (first != null)
					first.Outer = new Rectangle(0, 0, Inner.Width, splitter);
				if (second != null)
					second.Outer = new Rectangle(0, splitter + skin.SplitterSize, Inner.Width, Inner.Height - splitter - skin.SplitterSize);
                splitterRect = new Rectangle(0, splitter, Inner.Width, skin.SplitterSize);
			}
		}

        private Rectangle splitterRect;
        private void OnRender(object sender, double timeDelta)
		{
            Draw.FillRect(ref splitterRect, ref skin.BackgroundColor);
		}

		public override T Add<T>(T control)
		{
			if (first != null && second != null)
			{
				string message = string.Format("{0} {1} already has two children.",
					control.GetType().Name, control.Name);
				throw new InvalidOperationException(message);
			}
			base.Add(control);
			if (first == null)
				first = control;
			else
				second = control;
			Invalidate();
			return control;
		}

		public override void Remove(Control control)
		{
			if (first == control)
				first = null;
			if (second == control)
				second = null;
			base.Remove(control);
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.Button == MouseButton.Left)
			{
				isDragged = true;
			}
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (e.Button == MouseButton.Left)
			{
				if (isDragged)
				{
					isDragged = false;
					Gui.Cursor = Cursor.Default;
				}
			}
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (isDragged)
			{
				if (orientation == SplitterOrientation.Vertical)
					splitterPosition = (float)(e.X - skin.SplitterSize / 2) / (float)Inner.Width;
				else
					splitterPosition = (float)(e.Y - skin.SplitterSize / 2) / (float)Inner.Height;
				Invalidate();
			}
			Gui.Cursor = orientation == SplitterOrientation.Horizontal ? Cursor.ResizeY : Cursor.ResizeX;
		}
	}
}
