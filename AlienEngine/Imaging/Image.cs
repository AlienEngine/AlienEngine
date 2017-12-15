using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Resources;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using DevILImage = AlienEngine.Core.Graphics.DevIL.Image;

namespace AlienEngine.Imaging
{
    /// <summary>
    /// Load, manage, transform and convert image files.
    /// </summary>
    public class Image : IDisposable
    {
        #region Private fields

        /// <summary>
        /// The X offset of the <see cref="Image"/>.
        /// </summary>
        private int _x;

        /// <summary>
        /// The Y offset of the <see cref="Image"/>.
        /// </summary>
        private int _y;

        /// <summary>
        /// The Z offset of the <see cref="Image"/>.
        /// </summary>
        private int _z;

        /// <summary>
        /// The depth of the <see cref="Image"/>.
        /// </summary>
        private int _d;

        /// <summary>
        /// The format of the <see cref="Image"/>.
        /// </summary>
        private DataFormat _f;

        /// <summary>
        /// The type of the <see cref="Image"/>.
        /// </summary>
        private DataType _t;

        /// <summary>
        /// The inner <see cref="DevILImage"/> handler.
        /// </summary>
        private DevILImage _i;

        #endregion

        /// <summary>
        /// The inner DEVIL image wrapper.
        /// </summary>
        internal DevILImage DevilImage => _i;
        
        /// <summary>
        /// The width of the <see cref="Image"/>.
        /// </summary>
        public int Width => _i.Width;

        /// <summary>
        /// The height of the <see cref="Image"/>.
        /// </summary>
        public int Height => _i.Height;

        /// <summary>
        /// The array of pixels of the <see cref="Image"/>.
        /// </summary>
        public byte[] Pixels
        {
            get
            {
                // Bind the current DevIL image
                _i.Bind();

                // Get image pixels
                var pixels = IL.CopyPixels(_x, _y, _z, Width, Height, _d, _f, _t);

                // Make sure this image will not be modified from outside
                _i.Unbind();

                return pixels;
            }
        }

        /// <summary>
        /// The origin of the <see cref="Image"/>.
        /// </summary>
        public OriginLocation Origin => _i.Origin;

        /// <summary>
        /// Load and create a new image.
        /// </summary>
        /// <param name="file">The image file.</param>
        /// <param name="offsetX">The X offset from which pixels will be read.</param>
        /// <param name="offsetY">The Y offset from which pixels will be read.</param>
        /// <param name="offsetZ">The Z offset from which pixels will be read.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="format">The format in which pixels will be read.</param>
        /// <param name="type">The type of data in which pixels will be read.</param>
        public Image(string file, int offsetX = 0, int offsetY = 0, int offsetZ = 0, int depth = 1,
            DataFormat format = DataFormat.BGRA, DataType type = DataType.UnsignedByte)
        {
            var importer = new ImageImporter();
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
        /// Crops this <see cref="Image"/>.
        /// </summary>
        /// <returns>true when success, false otherwise</returns>
        public bool Crop(int x, int y, int z, int width, int height, int depth)
        {
            return TransformEngine.Crop(_i, x, y, z, width, height, depth);
        }

        /// <summary>
        /// Enlarge the canvas of this <see cref="Image"/>.
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="depth">The new depth</param>
        /// <returns>true when success, false otherwise</returns>
        public bool EnlargeCanvas(int width, int height, int depth)
        {
            return TransformEngine.EnlargeCanvas(_i, width, height, depth);
        }

        /// <summary>
        /// Enlarge the <see cref="Image"/> itself.
        /// </summary>
        /// <param name="xDim">The X dimension.</param>
        /// <param name="yDim">The Y dimension.</param>
        /// <param name="zDim">The Z dimension.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool EnlargeImage(int xDim, int yDim, int zDim)
        {
            return TransformEngine.EnlargeImage(_i, xDim, yDim, zDim);
        }

        /// <summary>
        /// Scale this <see cref="Image"/>. 
        /// </summary>
        /// <param name="width">The scale width.</param>
        /// <param name="height">The scale height.</param>
        /// <param name="depth">The scale depth.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool Scale(int width, int height, int depth)
        {
            return TransformEngine.Scale(_i, width, height, depth);
        }

        /// <summary>
        /// Scale the alpha channel of this <see cref="Image"/>. 
        /// </summary>
        /// <param name="scale">The amount of scale.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool ScaleAlpha(float scale)
        {
            return TransformEngine.ScaleAlpha(_i, scale);
        }

        /// <summary>
        /// Scale the rgb channel of this <see cref="Image"/>.
        /// </summary>
        /// <param name="red">The amount of scale for the red channel.</param>
        /// <param name="green">The amount of scale for the green channel.</param>
        /// <param name="blue">The amount of scale for the blue channel.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool ScaleColors(float red, float green, float blue)
        {
            return TransformEngine.ScaleColors(_i, red, green, blue);
        }

        /// <summary>
        /// Scale the rgb channel of this <see cref="Image"/>.
        /// </summary>
        /// <param name="rgb">The amount of scale.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool ScaleColors(float rgb)
        {
            return ScaleColors(rgb, rgb, rgb);
        }

        /// <summary>
        /// Replace colors in this <see cref="Image"/>. 
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="tolerance"></param>
        /// <returns>true when success, false otherwise</returns>
        public bool ReplaceColors(byte red, byte green, byte blue, float tolerance)
        {
            return TransformEngine.ReplaceColor(_i, red, green, blue, tolerance);
        }

        /// <summary>
        /// Swap colors of this <see cref="Image"/>.
        /// </summary>
        /// <returns>true when success, false otherwise</returns>
        public bool SwapColors()
        {
            return TransformEngine.SwapColors(_i);
        }

        /// <summary>
        /// Flips this <see cref="Image"/>.
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
        /// Rotates this <see cref="Image"/>.
        /// </summary>
        /// <param name="angle">The rotation angle.</param>
        /// <returns>true when success, false otherwise</returns>
        public bool Rotate(float angle)
        {
            return TransformEngine.Rotate(_i, angle);
        }

        /// <summary>
        /// Performs a 3D rotation to this <see cref="Image"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="angle"></param>
        /// <returns>true when success, false otherwise</returns>
        public bool Rotate3D(float x, float y, float z, float angle)
        {
            return TransformEngine.Rotate3D(_i, x, y, z, angle);
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

        /// <summary>
        /// Disposes this instance of <see cref="Image"/>.
        /// </summary>
        /// <param name="disposing">Define if we are disposing unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_i != null)
                {
                    _i.Dispose();
                }

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