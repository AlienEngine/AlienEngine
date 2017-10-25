using System;
using System.Collections.Generic;
using System.Linq;
using AlienEngine.Core.Graphics;

namespace AlienEngine.UI
{
	public abstract class Control
	{
		public virtual string Name { get; set; }
		public Gui Gui { get; internal set; }
		public Control Parent { get; internal set; }
		public IEnumerable<Control> Controls { get { return controls; } }

        public Rectangle Outer { get { return outer; } set { if (outer != value) { outer = value; Invalidate(); } } }
        public Rectangle Inner { get { return inner; } protected set { if (inner != value) { lastInner = inner; inner = value; DoResize(); /*Invalidate();*/ } } }
		public Sizei SizeMin { get { return sizeMin; } set { sizeMin = value; Invalidate(); } }
        public Sizei SizeMax { get { return sizeMax; } set { sizeMax = value; Invalidate(); } }
		public bool HasFocus { get; private set; }
		public bool IsDragged { get { return isDragged || controls.Any(c => c.IsDragged); } }
        public AnchorStyles Anchor { get { return anchor; } set { anchor = value; Invalidate(); } }
        public bool AutoSize { get { return autoSize; } set { autoSize = value; Invalidate(); } }
		public virtual ContextMenu ContextMenu { get { return contextMenu; } set { contextMenu = value; } }
        public bool HandleMouseEvents { get { return handleMouseEvents; } set { handleMouseEvents = value; } }

        // derived from above properties:
        public Point2i Location { get { return outer.Location; } set { Outer = new Rectangle(value, outer.Size); } }
        public Sizei Size { get { return outer.Size; } set { Outer = new Rectangle(outer.Location, value); } }
        public int X { get { return outer.X; } }
        public int Y { get { return outer.Y; } }
        public int Width { get { return outer.Width; } }
        public int Height { get { return outer.Height; } }
        public Point2i InnerOffset { get { return inner.Location; } }
        public Sizei InnerSize { get { return inner.Size; } }
        public int InnerWidth { get { return inner.Width; } }
        public int InnerHeight { get { return inner.Height; } }

        public delegate void RenderEventHandler(object sender, double timeDelta);
		public delegate bool KeyEventHandler(object sender, KeyboardKeyEventArgs e);
		public delegate bool KeyPressEventHandler(object sender, TextInputEventArgs e);

		public event RenderEventHandler Render;
		public event EventHandler<MouseMoveEventArgs> MouseMove;
		public event EventHandler<MouseButtonEventArgs> MouseDown;
		public event EventHandler<MouseButtonEventArgs> MouseUp;
		public event EventHandler<MouseWheelEventArgs> MouseWheel;
		public event EventHandler MouseEnter;
		public event EventHandler MouseLeave;
		public event KeyEventHandler KeyDown;
		public event KeyEventHandler KeyUp;
		public event KeyPressEventHandler KeyPress;
		public event EventHandler Focus;
		public event EventHandler FocusLost;
		public event EventHandler Resize;

		protected Rectangle outer;
		protected Sizei sizeMin, sizeMax;
		protected bool isDragged = false;
		protected AnchorStyles anchor = AnchorStyles.Left | AnchorStyles.Top;

		private Rectangle inner;
		private Rectangle lastInner;
		private bool autoSize = false;
		private readonly List<Control> controls = new List<Control>();
		private static int idCounter = 0;
        private bool visited = false;
		private ContextMenu contextMenu;
        private bool handleMouseEvents = true;

		private Control hoverChild;
		private Control focusedChild;

		protected Control(Gui gui)
		{
			Gui = gui;
			Name = GetType().Name + (idCounter++);

			outer = new Rectangle(0, 0, 0, 0);
			inner = new Rectangle(0, 0, 0, 0);
			sizeMin = new Sizei(0, 0);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

        public void Invalidate()
        {
			if (visited || Gui == null || Gui.LayoutSuspended)
                return;
            visited = true;

            UpdateLayout();

            if (Parent != null && Parent.autoSize)
                Parent.Invalidate();

            visited = false;
        }

		protected virtual void UpdateLayout()
		{
			if (autoSize)
			{
				if (controls.Count > 0)
				{
					outer.Width = Controls.Max(c => c.Outer.Right);
					outer.Height = Controls.Max(c => c.Outer.Bottom);
				}
				else
				{
					outer.Width = 0;
					outer.Height = 0;
				}
			}
			outer.Width = MathHelper.Clamp(outer.Width, sizeMin.Width, sizeMax.Width);
			outer.Height = MathHelper.Clamp(outer.Height, sizeMin.Height, sizeMax.Height);
			Inner = new Rectangle(0, 0, outer.Width, outer.Height);
		}

		public virtual T Add<T>(T control) where T : Control
		{
			if (control.Parent != null)
			{
				string message = string.Format("{0} {1} is already a child of {2} {3}.",
					control.GetType().Name, control.Name,
					control.Parent.GetType().Name, control.Parent.Name);
				throw new ArgumentException(message);
			}
			if (control is Form || control is ContextMenu)
                controls.Insert(0, control);
            else
			    controls.Add(control);
			control.Gui = Gui;
			control.Parent = this;
            control.Invalidate();
			return control;
		}

		public virtual void Remove(Control control)
		{
			if (control.Parent == null)
				return;

			if (control.Parent != this)
			{
				string message = string.Format("{0} {1} is a child of {2} {3}.",
					control.GetType().Name, control.Name,
					control.Parent.GetType().Name, control.Parent.Name);
				throw new ArgumentException(message);
			}

			controls.Remove(control);
			control.Gui = null;
			control.Parent = null;
		}

		public virtual void Clear()
		{
			Gui.SuspendLayout();
			foreach(Control control in controls.ToArray())
				Remove(control);
			Gui.ResumeLayout();
		}

		protected Point2i ToControl(Point2i p)
		{
			p.X -= outer.X;
			p.Y -= outer.Y;
			Control c = Parent;
			while (c != c.Parent)
			{
				p.X -= c.inner.X + c.outer.X;
				p.Y -= c.inner.Y + c.outer.Y;
				c = c.Parent;
			}
			return p;
		}

		protected Point2i ToViewport(Point2i p)
		{
			p.X += outer.X;
			p.Y += outer.Y;
			Control c = Parent;
			while (c != c.Parent)
			{
				p.X += c.inner.X + c.outer.X;
				p.Y += c.inner.Y + c.outer.Y;
				c = c.Parent;
			}
			return p;
		}

		protected Rectangle ToViewport(Rectangle r)
		{
			r.X += outer.X;
			r.Y += outer.Y;
			Control c = Parent;
			while (c != c.Parent)
			{
				r.X += c.inner.X + c.outer.X;
				r.Y += c.inner.Y + c.outer.Y;
				c = c.Parent;
			}
			return r;
		}

		internal void DoRender(Point2i absolutePosition, double timeDelta)
		{
            absolutePosition.X += outer.X;
            absolutePosition.Y += outer.Y;

			if (Render != null)
			{
                Draw.ControlRect = new Rectangle(absolutePosition, outer.Size);
                Draw.ScissorRect.Intersect(Draw.ControlRect);
                if (Draw.ScissorRect.Width != 0 && Draw.ScissorRect.Height != 0)
                    Render(this, timeDelta);
			}

            if (controls.Count > 0)
            {
                absolutePosition.X += inner.X;
                absolutePosition.Y += inner.Y;
                Draw.ControlRect = new Rectangle(absolutePosition, inner.Size);
                Draw.ScissorRect.Intersect(Draw.ControlRect);

                if (Draw.ScissorRect.Width != 0 && Draw.ScissorRect.Height != 0)
                {
                    Rectangle scissorRect = Draw.ScissorRect;
                    for (int i = controls.Count - 1; i >= 0; i--)
                    {
                        controls[i].DoRender(absolutePosition, timeDelta);
                        Draw.ScissorRect = scissorRect;
                    }
                }
            }
		}

		internal bool DoMouseMove(MouseMoveEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				Point2d im = new Point2d(e.X - inner.X, e.Y - inner.Y);

				if (hoverChild != null && hoverChild.IsDragged)
				{
					hoverChild.DoMouseMove(new MouseMoveEventArgs(im.X - hoverChild.Outer.X, im.Y - hoverChild.Outer.Y, e.XDelta, e.YDelta));
					return true;
				}

				if(inner.Contains(new Point2i((int)e.X, (int)e.Y)))
				{
					foreach (Control control in controls)
					{
						if (control.Outer.Contains(new Point2i((int)im.X, (int)im.Y)))
						{
							if (control.DoMouseMove(new MouseMoveEventArgs(im.X - control.Outer.X, im.Y - control.Outer.Y, e.XDelta, e.YDelta)))
							{
								if (hoverChild != control)
								{
									if (hoverChild != null)
										hoverChild.DoMouseLeave();
									hoverChild = control;
									hoverChild.DoMouseEnter();
								}
								return true;
							}
						}
					}
				}

				if (hoverChild != null)
				{
					hoverChild.DoMouseLeave();
					hoverChild = null;
				}
			}

			if (MouseMove != null)
			{
				MouseMove(this, e);
				return true;
			}

			if (MouseEnter != null || MouseLeave != null) // force correct MouseEnter/Leave handling
				return true;

			return handleMouseEvents;
		}

		internal bool DoMouseDown(MouseButtonEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				Point2d im = new Point2d(e.X - inner.X, e.Y - inner.Y);

				if (!HasFocus)
				{
					HasFocus = true;
					if (Focus != null)
						Focus(this, EventArgs.Empty);
				}

				if (inner.Contains(new Point2i((int)e.X, (int)e.Y)))
				{
					int i = 0;
					foreach(Control control in controls)
					{
						if (control.Outer.Contains(new Point2i((int)im.X, (int)im.Y)))
						{
							bool handled = control.DoMouseDown(new MouseButtonEventArgs(im.X - control.Outer.X, im.Y - control.Outer.Y, e.Button, e.IsPressed));
							if (control is Form)
							{
								Control tmp = controls[i]; // move to front
								controls.RemoveAt(i);
								controls.Insert(0, tmp);
							}
								if (handled)
								{
									if (control != focusedChild)
									{
										if (focusedChild != null)
											focusedChild.DoFocusLost();
										focusedChild = control;
									}
									return true;
								}
						}
						i++;
					}
				}
			}

            bool handledHere = false;

			if (MouseDown != null)
			{
				MouseDown(this, e);
                handledHere = true;
			}

            if (contextMenu != null && e.Button == MouseButton.Right)
            {
	            Gui.OpenContextMenu(contextMenu, ToViewport(new Point2i((int)e.X, (int)e.Y)));
                handledHere = true;
            }

            return handledHere || handleMouseEvents;
		}

		internal bool DoMouseUp(MouseButtonEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				Point2d im = new Point2d(e.X - inner.X, e.Y - inner.Y);

				if (hoverChild != null && hoverChild.IsDragged)
				{
					hoverChild.DoMouseUp(new MouseButtonEventArgs(im.X - hoverChild.Outer.X, im.Y - hoverChild.Outer.Y, e.Button, e.IsPressed));
					return true;
				}

				if (inner.Contains(new Point2i((int)e.X, (int)e.Y)))
				{
					foreach(Control control in controls)
					{
						if (control.Outer.Contains(new Point2i((int)im.X, (int)im.Y)))
						{
							if(control.DoMouseUp(new MouseButtonEventArgs(im.X - control.Outer.X, im.Y - control.Outer.Y, e.Button, e.IsPressed)))
								return true;
						}
					}
				}
			}

			if (MouseUp != null)
			{
				MouseUp(this, e);
				return true;
			}

			return handleMouseEvents;
		}

		internal bool DoMouseWheel(MouseWheelEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				Point2d im = new Point2d(e.X - inner.X, e.Y - inner.Y);

				if (inner.Contains(new Point2i((int)e.X, (int)e.Y)))
				{
					foreach(Control control in controls)
					{
						if (control.Outer.Contains(new Point2i((int)im.X, (int)im.Y)))
						{
							if (control.DoMouseWheel(new MouseWheelEventArgs(im.X - control.Outer.X, im.Y - control.Outer.Y, e.Value, e.Delta)))
								return true;
						}
					}
				}
			}

			if (MouseWheel != null)
			{
				MouseWheel(this, e);
				return true;
			}

			return handleMouseEvents;
		}

		internal void DoMouseEnter()
		{
			if (Parent == null)
				return;

			Gui.Cursor = Cursor.Default;

			if (MouseEnter != null)
				MouseEnter(this, EventArgs.Empty);
		}

		internal void DoMouseLeave()
		{
			if (Parent == null)
				return;

			if (hoverChild != null)
			{
				hoverChild.DoMouseLeave();
				hoverChild = null;
			}

			if (MouseLeave != null)
				MouseLeave(this, EventArgs.Empty);
		}

		internal bool DoKeyUp(KeyboardKeyEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				foreach(Control control in controls)
				{
					if (control.HasFocus)
					{
						if (control.DoKeyUp(e))
							return true;
					}
				}
			}

			if (KeyUp != null)
				return KeyUp(this, e);

			return false;
		}

		internal bool DoKeyDown(KeyboardKeyEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				foreach(Control control in controls)
				{
					if (control.HasFocus)
					{
						if (control.DoKeyDown(e))
							return true;
					}
				}
			}

			if (KeyDown != null)
				return KeyDown(this, e);

			return false;
		}

		internal bool DoKeyPress(TextInputEventArgs e)
		{
			if (Parent == null)
				return false;

			if (!isDragged)
			{
				foreach(Control control in controls)
				{
					if (control.HasFocus)
					{
						if (control.DoKeyPress(e))
							return true;
					}
				}
			}

			if (KeyPress != null)
				return KeyPress(this, e);

			return false;
		}

		internal void DoFocusLost()
		{
			if (Parent == null)
				return;

			if (HasFocus)
			{
				HasFocus = false;
				if (FocusLost != null)
					FocusLost(this, EventArgs.Empty);
			}
			foreach (Control control in controls)
				if (control.HasFocus)
					control.DoFocusLost();
		}

		private int subPixelDx = 0, subPixelDy = 0;
		internal void DoResize()
		{
			if (Parent == null)
				return;

			if (Resize != null)
				Resize(this, EventArgs.Empty);

			int dx = inner.Width - lastInner.Width;
			int dy = inner.Height - lastInner.Height;

			foreach (Control control in controls)
			{
				var a = control.Anchor;
				var o = control.Outer;
				int l = o.Left, r = o.Right, t = o.Top, b = o.Bottom;

				if ((a & (AnchorStyles.Left | AnchorStyles.Right)) == 0)
				{
					dx += control.subPixelDx; control.subPixelDx = Math.Sign(dx) * (dx & 1);
					l += dx / 2;
					r += dx / 2;
				}
				else
				{
					if ((a & AnchorStyles.Left) == 0)
						l += dx;
					if ((a & AnchorStyles.Right) != 0)
						r += dx;
				}

				if ((a & (AnchorStyles.Top | AnchorStyles.Bottom)) == 0)
				{
					dy += control.subPixelDy; control.subPixelDy = Math.Sign(dy) * (dy & 1);
					t += dy / 2;
					b += dy / 2;
				}
				else
				{
					if ((a & AnchorStyles.Top) == 0)
						t += dy;
					if ((a & AnchorStyles.Bottom) != 0)
						b += dy;
				}

				control.Outer = new Rectangle(l, t, r - l, b - t);
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
