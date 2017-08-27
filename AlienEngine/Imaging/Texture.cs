using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using System;
using System.Drawing;

namespace AlienEngine.Imaging
{
    /// <summary>
    /// An AlienEngine texture, used by <see cref="Material"/>
    /// and rendered in the <see cref="Scene"/>.
    /// </summary>
    public class Texture : IDisposable
    {
        #region Fields

        private Image _image;

        #endregion

        #region Propreties

        public string Filename { get; private set; }

        [CLSCompliant(false)]
        public uint TextureID { get; private set; }

        public TextureTarget TextureTarget { get; private set; }

        public bool FlipY { get; private set; }

        #endregion

        public Texture(string filename = null, TextureTarget target = TextureTarget.Texture2D, bool flipY = true)
        {
            _image = null;
            TextureID = 0;
            TextureTarget = target;
            Filename = filename;
            FlipY = flipY;

            if (!string.IsNullOrEmpty(filename))
                LoadImage(filename);

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        public bool LoadImage(string filename)
        {
            // Release the previously loaded texture
            Clear();

            // Change the file name of this texture
            Filename = filename;

            bool ret = false;

            try
            {
                // Import the image
                _image = Image.FromFile(filename);

                // TODO: Apply image filters here
                _applyFilters();

                // Generate OpenGL texture
                TextureID = GL.GenTexture();

                if (FlipY) _image.Flip();

                // Set pixel alignment
                GL.PixelStorei(PixelStoreParameter.UnpackAlignment, 1);
                // Bind the texture to memory in OpenGL
                GL.BindTexture(TextureTarget, TextureID);

                // Set texture data
                GL.TexImage2D(TextureTarget, 0, PixelInternalFormat.Rgba8, _image.Width, _image.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, _image.Pixels);

                // Set texture filters
                GL.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
                GL.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

                // Make sure the texture will not be modified from the outside
                GL.BindTexture(TextureTarget, 0);

                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ret;
        }

        private void _applyFilters()
        { }

        [CLSCompliant(false)]
        public void Bind(uint textureUnit)
        {
            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget, TextureID);
        }

        public void Clear()
        {
            if (_image != null)
            {
                _image.Dispose();
                _image = null;
            }

            if (TextureID != 0)
            {
                GL.DeleteTexture(TextureID);
                TextureID = 0;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Clear();
                disposedValue = true;
            }
        }

        ~Texture()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
