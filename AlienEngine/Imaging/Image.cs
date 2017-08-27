using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Resources;
using System;
using DevILImage = AlienEngine.Core.Graphics.DevIL.Image;

namespace AlienEngine.Imaging
{
    /// <summary>
    /// Loads image files.
    /// </summary>
    public class Image : IDisposable
    {
        private int _w;
        private int _h;
        private byte[] _p;

        /// <summary>
        /// The width of the image.
        /// </summary>
        public int Width
        {
            get { return _w; }
        }

        /// <summary>
        /// The height of the image.
        /// </summary>
        public int Height
        {
            get { return _h; }
        }

        /// <summary>
        /// The array of pixels of the image.
        /// </summary>
        public byte[] Pixels
        {
            get { return _p; }
        }

        public Image(string file, int offsetX = 0, int offsetY = 0, int offsetZ = 0, int width = 0, int height = 0, int depth = 1, DataFormat format = DataFormat.BGRA, DataType type = DataType.UnsignedByte)
        {
            ImageImporter importer = new ImageImporter();
            DevILImage image = importer.LoadImage(file);

            // Dispose the importer
            importer.Dispose();

            _w = width == 0 ? image.Width : width;
            _h = height == 0 ? image.Height : height;
            _p = IL.CopyPixels(offsetX, offsetY, offsetZ, _w, _h, depth, format, type);

            // Dispose the DevIL image
            image.Dispose();

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _p = null;

                disposedValue = true;
            }
        }

        ~Image()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
