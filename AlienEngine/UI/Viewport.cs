using System;
using System.Drawing;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.UI
{
	public class Viewport : Control
	{
        public float AspectRatio { get { return (float)Inner.Width / (float)Inner.Height; } }
		public event RenderEventHandler RenderViewport;

		public Viewport(Gui gui) : base(gui)
		{
            Render += OnRender;

			outer = new Rectangle(0, 0, 256, 256);
			sizeMin = new Sizei(1, 1);
			sizeMax = new Sizei(int.MaxValue, int.MaxValue);
		}

        protected override void UpdateLayout()
		{
			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
            outer.Height = Math.Min(Math.Max(outer.Height, sizeMin.Height), sizeMax.Height);
			Inner = new Rectangle(0, 0, outer.Width, outer.Height);
		}

        private void OnRender(object sender, double timeDelta)
        {
            if (RenderViewport == null)
                return;

            // save
            int[] mainViewport = new int[4];
	        mainViewport = GL.GetIntegers(GetPName.Viewport, 4);
            // TODO: get rid of these:
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            
            // render
            var vp = ToViewport(Inner);
            GL.Scissor(Draw.ScissorRect.X, Gui.Outer.Height - Draw.ScissorRect.Bottom, Draw.ScissorRect.Width, Draw.ScissorRect.Height);
            GL.Viewport(vp.X, mainViewport[3] - vp.Y - vp.Height, vp.Width, vp.Height);
            RenderViewport(this, timeDelta);

            // restore
            GL.Viewport(mainViewport[0], mainViewport[1], mainViewport[2], mainViewport[3]);
            // TODO: get rid of these:
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }
	}
}

