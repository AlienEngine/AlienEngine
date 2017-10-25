using System;
using System.Drawing.Imaging;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.UI;

namespace AlienEngine.Core.Rendering.Fonts
{
    class FontTexture : IDisposable
    {
		public readonly uint TextureID;
		public readonly int Width;
		public readonly int Height;

        public FontTexture(BitmapData dataSource)
        {
			Width = dataSource.Width;
			Height = dataSource.Height;

            GL.Enable(EnableCap.Texture2D);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTexture(out TextureID);
            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureWrapMode.Clamp);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureWrapMode.Clamp);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureMinFilter.Linear);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureMagFilter.Linear);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0,
				AlienEngine.Core.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, dataSource.Scan0);

            GL.Disable(EnableCap.Texture2D);

			Gui.usedTextures++;
        }

        public void Dispose()
        {
            GL.DeleteTexture(TextureID);
			Gui.usedTextures--;
        }

		~FontTexture()
		{
			lock(Gui.toDispose)
			{
				Gui.toDispose.Add(this);
			}
		}
    }
}
