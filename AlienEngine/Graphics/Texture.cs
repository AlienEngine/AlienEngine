using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using System;

namespace AlienEngine.Graphics
{
    public class Texture : IDisposable
    {
        #region Fields

        private uint _image;

        #endregion

        #region Propreties

        public string Filename { get; private set; }

        [CLSCompliant(false)]
        public uint TextureID { get; private set; }

        public TextureTarget TextureTarget { get; private set; }

        #endregion

        public Texture(TextureTarget target = TextureTarget.Texture2D, string filename = null)
        {
            _image = 0;
            TextureID = 0;
            TextureTarget = target;
            Filename = filename;

            if (!string.IsNullOrEmpty(filename))
                LoadImage(filename);

            ResourcesManager.AddDisposableResource(this);
        }

        public bool LoadImage(string filename)
        {
            // Release the previously loaded texture
            Clear();

            // Create the Image
            _image = IL.GenImage();
            IL.BindImage(_image);

            Filename = filename;

            bool ret = false;

            try
            {
                ret = IL.LoadImage(filename);

                // TODO: Apply image filters here
                _applyFilters();

                TextureID = ILUT.GLBindTexImage();

                _initTexture();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Make sure the Image will not be modified from the outside
            IL.BindImage(0);

            return ret;
        }

        private void _applyFilters()
        { }

        private void _initTexture()
        {
            GL.PixelStorei(PixelStoreParameter.UnpackAlignment, 1); // Set pixel alignment
            GL.BindTexture(TextureTarget, TextureID);     // Bind the texture to memory in OpenGL

            GL.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            GL.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

            GL.BindTexture(TextureTarget, 0);
        }

        [CLSCompliant(false)]
        public void Bind(uint textureUnit)
        {
            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget, TextureID);
        }

        public void Clear()
        {
            if (_image != 0)
            {
                IL.DeleteImage(_image);
                _image = 0;
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
