using System;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering.Fonts;

namespace AlienEngine.UI
{
    public static class Draw
    {
        public static Rectangle CurrentScreenRect
        {
            get { return ControlRect; }
        }

        internal static Gui CurrentGui;
        internal static Rectangle ControlRect;
        internal static Rectangle ScissorRect;

        public static void PrepareCustomDrawing()
        {
            GL.Scissor(ScissorRect.X, CurrentGui.Outer.Height - ScissorRect.Bottom, ScissorRect.Width,
                ScissorRect.Height);
        }

        public static void Fill(ref Color4 color)
        {
            if (color.A == 0.0f)
                return;

            GL.ClearColor(color);
            GL.Scissor(ScissorRect.X, CurrentGui.Outer.Height - ScissorRect.Bottom, ScissorRect.Width,
                ScissorRect.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void FillRect(Rectangle rect, ref Color4 color)
        {
            FillRect(ref rect, ref color);
        }

        public static void FillRect(ref Rectangle rect, ref Color4 color)
        {
            if (color.A == 0.0f)
                return;

            int w = Math.Min(rect.Width, ScissorRect.Width - rect.X);
            int h = Math.Min(rect.Height, ScissorRect.Height - rect.Y);
            if (w > 0 && h > 0)
            {
                GL.ClearColor(color);
                GL.Scissor(ScissorRect.X + rect.X, CurrentGui.Outer.Height - (ScissorRect.Y + rect.Y + h), w, h);
                GL.Clear(ClearBufferMask.ColorBufferBit);
            }
        }

        public static void Text(FontText processedText, Rectangle rect, ref Color4 color)
        {
            Text(processedText, ref rect, ref color);
        }

        public static void Text(FontText processedText, ref Rectangle rect, ref Color4 color)
        {
            if (color.A == 0.0f)
                return;

            int w = Math.Min(rect.Width, ScissorRect.Width - rect.X);
            int h = Math.Min(rect.Height, ScissorRect.Height - rect.Y);
            if (w > 0 && h > 0)
            {
                GL.Scissor(ScissorRect.X + rect.X, CurrentGui.Outer.Height - (ScissorRect.Y + rect.Y + h), w, h);
                GL.PushMatrix();
                switch (processedText.alignment)
                {
                    case FontAlignment.Left:
                    case FontAlignment.Justify:
                        GL.Translate(ControlRect.X + rect.X, ControlRect.Y + rect.Y, 0.0f);
                        break;
                    case FontAlignment.Centre:
                        GL.Translate(ControlRect.X + rect.X + rect.Width / 2, ControlRect.Y + rect.Y, 0.0f);
                        break;
                    case FontAlignment.Right:
                        GL.Translate(ControlRect.X + rect.X + rect.Width, ControlRect.Y + rect.Y, 0.0f);
                        break;
                }
                GL.Color4(color);
                for (int i = 0; i < processedText.VertexBuffers.Length; i++)
                    processedText.VertexBuffers[i].Draw();
                GL.PopMatrix();
            }
        }
    }
}