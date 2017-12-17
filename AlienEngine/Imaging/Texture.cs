using AlienEngine.Core.Imaging.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using System;
using AlienEngine.Core.Game;
using SharpFont;

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

        [CLSCompliant(false)]
        public uint TextureID { get; private set; }

        public TextureTarget TextureTarget { get; private set; }

        public Image Image => _image;

        #endregion

        public Texture()
        {
            _image = null;
            TextureID = 0;
            TextureTarget = TextureTarget.Texture2D;

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        public Texture(string filename, TextureTarget target = TextureTarget.Texture2D)
        {
            _image = null;
            TextureID = 0;
            TextureTarget = target;

            if (!string.IsNullOrEmpty(filename))
                LoadImage(filename);

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        public Texture(Image image, TextureTarget target = TextureTarget.Texture2D)
        {
            _image = image;
            TextureID = 0;
            TextureTarget = target;

            LoadImage(image);

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        internal Texture(GlyphSlot fontGlyph)
        {
            // No image is referenced in this case...
            _image = null;

            // These parameters are always the same
            TextureTarget = TextureTarget.Texture2D;
            
            // Generate a texture
            TextureID = GL.GenTexture();

            // Set pixel alignment
            GL.PixelStorei(PixelStoreParameter.UnpackAlignment, 1);

            // Bind the texture into the memory
            GL.BindTexture(TextureTarget, TextureID);
            
            // Set texture data
            GL.TexImage2D(TextureTarget, 0, PixelInternalFormat.Red, fontGlyph.Bitmap.Width, fontGlyph.Bitmap.Rows, 0, PixelFormat.Red, PixelType.UnsignedByte, fontGlyph.Bitmap.Buffer);
            
            // Set texture options
            GL.TexParameteri(TextureTarget, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            GL.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

            // Make sure the texture will not be modified from the outside
            GL.BindTexture(TextureTarget, 0);
        }
        
        public bool LoadImage(Image image)
        {
            // Release the previously loaded texture
            Clear();

            bool ret = false;

            try
            {
                // Set the image
                _image = image;

                // TODO: Apply image filters here
                _applyFilters();

                // Generate OpenGL texture
                TextureID = GL.GenTexture();

                if (_image.Origin == OriginLocation.UpperLeft) _image.Flip();

                // Set pixel alignment
                GL.PixelStorei(PixelStoreParameter.UnpackAlignment, 1);
                
                // Bind the texture to memory in OpenGL
                GL.BindTexture(TextureTarget, TextureID);

                // Set texture data
                GL.TexImage2D(TextureTarget, 0, PixelInternalFormat.Rgba8, _image.Width, _image.Height, 0,
                    PixelFormat.Bgra, PixelType.UnsignedByte, _image.Pixels);

                // Set texture filters
                GL.TexParameteri(TextureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
                GL.TexParameteri(TextureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

                // Make sure the texture will not be modified from the outside
                GL.BindTexture(TextureTarget, 0);

                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Texture load error: " + e.Message);
            }

            return ret;
        }

        public bool LoadImage(string filename)
        {
            return LoadImage(Image.FromFile(filename));
        }

        private void _applyFilters()
        {
        }

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