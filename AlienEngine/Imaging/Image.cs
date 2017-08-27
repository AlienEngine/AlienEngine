using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Resources;
using System;
using System.Drawing;
using DevILImage = AlienEngine.Core.Graphics.DevIL.Image;

namespace AlienEngine.Imaging
{
    /// <summary>
    /// Load, manage, transform and convert image files.
    /// </summary>
    public class Image : IDisposable
    {
        #region Private fields

        private int _x;
        private int _y;
        private int _z;
        private int _d;
        private DataFormat _f;
        private DataType _t;
        private DevILImage _i;

        #endregion

        /// <summary>
        /// The width of the image.
        /// </summary>
        public int Width
        {
            get { return _i.Width; }
        }

        /// <summary>
        /// The height of the image.
        /// </summary>
        public int Height
        {
            get { return _i.Height; }
        }

        /// <summary>
        /// The array of pixels of the image.
        /// </summary>
        public byte[] Pixels
        {
            get
            {
                // Bind the current DevIL image
                _i.Bind();

                // Get image pixels
                var _p = IL.CopyPixels(_x, _y, _z, Width, Height, _d, _f, _t);

                // Make sure this image will not be modified from outside
                _i.Unbind();

                return _p;
            }
        }

        /// <summary>
        /// Load and create a new image.
        /// </summary>
        /// <param name="file">The image file.</param>
        /// <param name="offsetX">The X offset from which pixels will be read.</param>
        /// <param name="offsetY">The Y offset from which pixels will be read.</param>
        /// <param name="offsetZ">The Z offset from which pixels will be read.</param>
        /// <param name="width">The width of the loaded.</param>
        /// <param name="height">The height of the loaded.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="format">The format in which pixels will be read.</param>
        /// <param name="type">The type of data in which pixels will be read.</param>
        public Image(string file, int offsetX = 0, int offsetY = 0, int offsetZ = 0, int width = 0, int height = 0, int depth = 1, DataFormat format = DataFormat.BGRA, DataType type = DataType.UnsignedByte)
        {
            ImageImporter importer = new ImageImporter();
            _i = importer.LoadImage(file);

            // Dispose the importer
            importer.Dispose();

            // Populate fields
            _x = offsetX;
            _y = offsetY;
            _z = offsetZ;
            _d = depth;
            _f = format;
            _t = type;

            // Register this resource as a disposable resource
            ResourcesManager.AddDisposableResource(this);
        }

        #region Public members

        /// <summary>
        /// Flips this image.
        /// </summary>
        /// <returns>true when success, false otherwise</returns>
        public bool Flip()
        {
            return TransformEngine.FlipImage(_i);
        }

        /// <summary>
        /// Mirrors this image.
        /// </summary>
        /// <returns>true when success, false otherwise</returns>
        public bool Mirror()
        {
            return TransformEngine.Mirror(_i);
        }

        /// <summary>
        /// Crops this image.
        /// </summary>
        /// <returns>true when success, false otherwise</returns>
        public bool Crop(int x, int y, int z, int width, int height, int depth)
        {
            return TransformEngine.Crop(_i, x, y, z, width, height, depth);
        }

        /// <summary>
        /// Converts this <see cref="Image"/> to a <see cref="System.Drawing.Bitmap"/>.
        /// </summary>
        public Bitmap ToBitmap()
        {
            return _i.ToBitmap();
        }

        #endregion

        #region Static members

        /// <summary>
        /// Loads an image from a file.
        /// </summary>
        /// <param name="file">The file path of the image to load.</param>
        /// <returns>A new <see cref="Image"/> instance.</returns>
        public static Image FromFile(string file)
        {
            return new Image(file);
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _i.Dispose();
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
