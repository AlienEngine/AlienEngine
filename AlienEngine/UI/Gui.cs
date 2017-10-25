using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlienEngine.Core;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.UI
{
	public class Gui : Control
	{
        public readonly GameWindow ParentWindow;
		public Skin Skin = new Skin();
		public double RenderDuration { get { return renderDuration; } }
		public bool LayoutSuspended { get { return suspendCounter > 0; } }

        public Cursor Cursor
        {
            get { return cursor; }
            set
            {
                cursor = value;
                if(ParentWindow != null)
                    ParentWindow.Cursor = cursor;
            }
        }

		internal static List<IDisposable> toDispose = new List<IDisposable>();
		internal static int usedTextures = 0;
		internal static int usedVertexArrays = 0;
		private static int lastUsedTextures = 0;
		private static int lastUsedVertexArrays = 0;

		private ContextMenu currentContextMenu;
        private Stopwatch stopwatch;
		private double renderDuration;
		private int suspendCounter = 0;
		private Cursor cursor;

        public Gui(GameWindow parent) : base(null)
        {
            Gui = this;
            base.Parent = this;
            ParentWindow = parent;
            Outer = parent.Rectangle;
            Anchor = AnchorStyles.All;

	        Input.AddMouseMoveEvent((s, e) => DoMouseMove(e));
	        Input.AddMouseButtonDownEvent(OnMouseDown);
	        Input.AddMouseButtonUpEvent(OnMouseUp);
	        Input.AddMouseWheelEvent((s, e) => DoMouseWheel(e));
	        parent.MouseEnter += (s, e) => DoMouseEnter();
            parent.MouseLeave += (s, e) => DoMouseLeave();
	        Input.AddKeyEvent((s, e) => DoKeyDown(e));
            Input.AddKeyEvent((s, e) => DoKeyUp(e));
            Input.AddTextInputEvent((s, e) => DoKeyPress(e));
            parent.Resize += (s, e) => Outer = parent.Rectangle;
        }

		public void SuspendLayout()
		{
			suspendCounter++;
		}

		public void ResumeLayout()
		{
			suspendCounter--;
			if (suspendCounter < 0)
				suspendCounter = 0;
		}

		public new void Render()
        {
            if (stopwatch == null)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }
            stopwatch.Stop();
			double delta = stopwatch.Elapsed.TotalMilliseconds * 0.001;
            stopwatch.Restart();

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);

            int[] vp = new int[4];
            vp = GL.GetIntegers(GetPName.Viewport, 4);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho(0, vp[2], vp[3], 0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.ScissorTest);

            var prevGui = Draw.CurrentGui;
            Draw.CurrentGui = this;
            Draw.ControlRect = outer;
            Draw.ScissorRect = outer;

            DoRender(new Point2i(), delta);

            Draw.CurrentGui = prevGui;

            GL.Disable(EnableCap.ScissorTest);
            GL.Disable(EnableCap.Blend);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();

			lock(toDispose)
			{
				foreach(var d in toDispose)
					d.Dispose();
				toDispose.Clear();
			}
			if(usedVertexArrays != lastUsedVertexArrays)
			{
				lastUsedVertexArrays = usedVertexArrays;
				if(usedVertexArrays > 2048)
					Console.WriteLine("Warning: Used vertex arrays by GLGUI: {0}", usedVertexArrays);
				GC.Collect();
			}
			if(usedTextures != lastUsedTextures)
			{
				lastUsedTextures = usedTextures;
				if(usedTextures > 32)
					Console.WriteLine("Warning: Used textures by GLGUI: {0}", usedTextures);
				GC.Collect();
			}

			renderDuration = stopwatch.Elapsed.TotalMilliseconds;
        }

		internal void OpenContextMenu(ContextMenu contextMenu, Point2i position)
		{
			if (currentContextMenu != null)
				Remove(currentContextMenu);

			currentContextMenu = contextMenu;

			if (currentContextMenu != null)
			{
				Add(currentContextMenu);
				currentContextMenu.Location = position;
			}
		}

		internal void CloseContextMenu()
		{
			OpenContextMenu(null, Point2i.Empty);
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (currentContextMenu != null)
			{
				if (currentContextMenu.Outer.Contains(new Point2i((int) e.Location.X, (int) e.Location.Y)))
				{
					currentContextMenu.DoMouseDown(new MouseButtonEventArgs(e.X - currentContextMenu.Outer.X, e.Y - currentContextMenu.Outer.Y, e.Button, e.IsPressed));
					return;
				}
				
				CloseContextMenu();
			}
			    
			DoMouseDown(e);
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (currentContextMenu != null && currentContextMenu.Outer.Contains(new Point2i((int) e.Location.X, (int) e.Location.Y)))
			{
				currentContextMenu.DoMouseUp(new MouseButtonEventArgs(e.X - currentContextMenu.Outer.X, e.Y - currentContextMenu.Outer.Y, e.Button, e.IsPressed));
				return;
			}

			DoMouseUp(e);
		}
	}
}