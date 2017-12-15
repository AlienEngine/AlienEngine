using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Resources;
using System;
using AlienEngine.Core.Physics.BroadPhaseEntries;
using AlienEngine.Imaging;
using Image = AlienEngine.Core.Graphics.DevIL.Image;

namespace AlienEngine.Core.Graphics
{
    /// <summary>
    /// Manage cursors used in a <see cref="GameWindow"/> 
    /// </summary>
    public class Cursor : IDisposable
    {
        #region Fields

        private GLFW.GLFW.Cursor _cursor;
        private GLFW.GLFW.Image _image;
        private int xhot = 0;
        private int yhot = 0;

        public static readonly Cursor Default;
        public static readonly Cursor Beam;
        public static readonly Cursor Hand;
        public static readonly Cursor ResizeY;
        public static readonly Cursor ResizeTop;
        public static readonly Cursor ResizeBottom;
        public static readonly Cursor ResizeX;
        public static readonly Cursor ResizeLeft;
        public static readonly Cursor ResizeRight;
        public static readonly Cursor Crosshair;

        #endregion

        #region Properties

        /// <summary>
        /// Internal cursor's pointer.
        /// </summary>
        internal GLFW.GLFW.Cursor Handle => _cursor;

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

        #region Initializer

        static Cursor()
        {
            Default = new Cursor(CursorType.Arrow);
            Beam = new Cursor(CursorType.Beam);
            ResizeX = new Cursor(CursorType.ResizeX);
            ResizeY = new Cursor(CursorType.ResizeY);
            Crosshair = new Cursor(CursorType.Crosshair);
            ResizeBottom = ResizeY;
            ResizeTop = ResizeY;
            ResizeLeft = ResizeX;
            ResizeRight = ResizeX;
        }

        #endregion

        #region Constructor

        private Cursor(GLFW.GLFW.Cursor cursor)
        {
            _image = new GLFW.GLFW.Image();
            _cursor = cursor;
            HotX = 0;
            HotY = 0;
        }

        public Cursor() : this(GLFW.GLFW.CreateStandardCursor(CursorType.Arrow))
        {
        }

        public Cursor(CursorType type) : this(GLFW.GLFW.CreateStandardCursor(type))
        {
        }

        public Cursor(int hotX, int hotY) : this()
        {
            HotX = hotX;
            HotY = hotY;
        }

        public Cursor(string image, int hotX, int hotY) : this(hotX, hotY)
        {
            FromImage(image);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load an image and use it as a cursor.
        /// </summary>
        /// <param name="image">The path to the image.</param>
        public void FromImage(string image)
        {
            ImageImporter importer = new ImageImporter();
            Image img = importer.LoadImage(image);

            importer.Dispose();

            img.Bind();
            _image.Width = img.Width;
            _image.Height = img.Height;
            _image.Pixels = IL.CopyPixels(0, 0, 0, img.Width, img.Height, 1, DataFormat.BGRA, DataType.UnsignedByte);
            img.Unbind();

            img.Dispose();

            _cursor = GLFW.GLFW.CreateCursor(_image, HotX, HotY);
        }

        /// <summary>
        /// Use this cursor.
        /// </summary>
        public void Use()
        {
            Game.Game.Instance.Window.SetCursor(this);
        }

        /// <summary>
        /// Unuse this cursor and restore the default one.
        /// </summary>
        public void Unuse()
        {
            Game.Game.Instance.Window.SetCursor(None);
        }

        /// <summary>
        /// Destroy the current cursor.
        /// </summary>
        public void Destroy()
        {
            GLFW.GLFW.DestroyCursor(_cursor);
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Gets an empty cursor.
        /// </summary>
        public static Cursor None
        {
            get { return new Cursor(GLFW.GLFW.Cursor.None); }
        }

        /// <summary>
        /// Sets the cursor by the standard <see cref="CursorType"/>.
        /// </summary>
        /// <param name="type">The cursor type.</param>
        public static void SetCursor(CursorType type)
        {
            Game.Game.Instance.Window.SetCursor(new Cursor(type));
        }

        /// <summary>
        /// Sets the cursor by a <see cref="Cursor"/> instance.
        /// </summary>
        /// <param name="cursor">The cursor to use.</param>
        public static void SetCursor(Cursor cursor)
        {
            cursor.Use();
        }

        /// <summary>
        /// Creates a <see cref="Cursor"/> from an image file.
        /// </summary>
        /// <param name="image">The path to the image file.</param>
        public static Cursor CreateCursor(string image)
        {
            Cursor cur = new Cursor();
            cur.FromImage(image);

            return cur;
        }

        /// <summary>
        /// Destroys the <paramref name="cursor"/>.
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