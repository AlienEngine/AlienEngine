using AlienEngine.Core.Game;
using AlienEngine.Graphics.GLFW;
using System;

namespace AlienEngine
{
    public class Cursor : IDisposable
    {
        #region Fields
        private GLFW.Cursor _cursor;
        private GLFW.Image _image;
        private int xhot = 0;
        private int yhot = 0;
        #endregion

        #region Properties
        /// <summary>
        /// The height of this cursor.
        /// </summary>
        public int Height
        {
            get { return _image.Height; }
            set { _image.Height = value; }
        }

        /// <summary>
        /// The width of this cursor.
        /// </summary>
        public int Width
        {
            get { return _image.Width; }
            set { _image.Width = value; }
        }

        /// <summary>
        /// The array of pixels of this cursor.
        /// </summary>
        public byte[] Pixels
        {
            get { return _image.Pixels; }
            set { _image.Pixels = value; }
        }

        /// <summary>
        /// The desired x-coordinate, in pixels, of the cursor hotspot. 
        /// </summary>
        public int HotX
        {
            get { return xhot; }
            set { xhot = value; }
        }

        /// <summary>
        /// The desired y-coordinate, in pixels, of the cursor hotspot. 
        /// </summary>
        public int HotY
        {
            get { return yhot; }
            set { yhot = value; }
        }
        #endregion

        #region Enums
        /// <summary>
        /// Standard cursor shapes.
        /// </summary>
        /// <seealso cref="SetCursor"/>
        public enum CursorType
        {
            /// <summary>
            /// The regular arrow cursor.
            /// </summary>
            Arrow = 0x00036001,

            /// <summary>
            /// The text input I-beam cursor shape.
            /// </summary>
            Beam = 0x00036002,

            /// <summary>
            /// The crosshair shape.
            /// </summary>
            Crosshair = 0x00036003,

            /// <summary>
            /// The hand shape.
            /// </summary>
            Hand = 0x00036004,

            /// <summary>
            /// The horizontal resize arrow shape.
            /// </summary>
            ResizeX = 0x00036005,

            /// <summary>
            /// The vertical resize arrow shape.
            /// </summary>
            ResizeY = 0x00036006
        }
        #endregion

        #region Constructor
        public Cursor()
        {
            _image = new GLFW.Image();
            _cursor = GLFW.CreateStandardCursor(CursorType.Arrow);
            HotX = 0;
            HotY = 0;
        }

        public Cursor(int hotX, int hotY) : this()
        {
            HotX = hotX;
            HotY = hotY;
        }

        public Cursor(string image, int hotX, int hotY) : this()
        {
            HotX = hotX;
            HotY = hotY;
            LoadImage(image);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Load an image and use it as a cursor.
        /// </summary>
        /// <param name="image">The path to the image.</param>
        public void LoadImage(string image)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                System.Drawing.Bitmap img = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(image);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                _image.Height = img.Height;
                _image.Width = img.Width;
                _image.Pixels = ms.ToArray();

                _cursor = GLFW.CreateCursor(_image, HotX, HotY);
            }
        }

        /// <summary>
        /// Use this cursor.
        /// </summary>
        public void Set()
        {
            GLFW.Cursor cur = GLFW.CreateCursor(_image, HotX, HotY);
            GLFW.SetCursor(Game.Window, cur);
        }

        /// <summary>
        /// Unuse this cursor and restore the default one.
        /// </summary>
        public void Unset()
        {
            GLFW.SetCursor(Game.Window, GLFW.Cursor.None);
        }

        /// <summary>
        /// Destroy the current cursor.
        /// </summary>
        public void Destroy()
        {
            GLFW.DestroyCursor(_cursor);
        }
        #endregion

        #region Static Members
        /// <summary>
        /// Set the cursor by the standard <see cref="CursorType"/>.
        /// </summary>
        /// <param name="type">The cursor type.</param>
        public static void SetCursor(CursorType type)
        {
            GLFW.Cursor cur = GLFW.CreateStandardCursor(type);
            GLFW.SetCursor(Game.Window, cur);
        }

        /// <summary>
        /// Set the cursor by a <see cref="Cursor"/> instance.
        /// </summary>
        /// <param name="cursor">The cursor to use.</param>
        public static void SetCursor(Cursor cursor)
        {
            cursor.Set();
        }

        /// <summary>
        /// Create a <see cref="Cursor"/> from an image file.
        /// </summary>
        /// <param name="image">The path to the image file.</param>
        public static Cursor CreateCursor(string image)
        {
            Cursor cur = new Cursor();
            cur.LoadImage(image);

            return cur;
        }

        /// <summary>
        /// Destroy the <paramref name="cursor"/>.
        /// </summary>
        /// <param name="cursor">The cursor to destroy.</param>
        public static void DestroyCursor(Cursor cursor)
        {
            cursor.Destroy();
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Destroy();
                _image.Pixels = null;

                disposedValue = true;
            }
        }

        ~Cursor()
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
