using AlienEngine.Core.Game;
using System;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core.Rendering;
using Window = AlienEngine.Core.Graphics.GLFW.GLFW.Window;

namespace AlienEngine.Core
{
    /// <summary>
    /// Create and manage a window in which the game
    /// will be runned.
    /// </summary>
    /// <remarks>
    /// This is a GLFW wrapper.
    /// </remarks>
    public class GameWindow
    {
        #region Fields

        /// <summary>
        /// The internal window's pointer.
        /// </summary>
        internal readonly Window Handle;

        /// <summary>
        /// Stores the current title of the <see cref="GameWindow"/>.
        /// </summary>
        private string _title;

        /// <summary>
        /// Stores the current size of the <see cref="GameWindow"/>.
        /// </summary>
        private Sizei _size;

        /// <summary>
        /// Stores the current framebuffer size of the <see cref="GameWindow"/>.
        /// </summary>
        private Sizei _framebufferSize;

        /// <summary>
        /// The <see cref="Cursor"/> of this <see cref="GameWindow"/>.
        /// </summary>
        private Cursor _cursor;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="GameWindow"/> by
        /// giving the <see cref="Handle"/>.
        /// </summary>
        /// <param name="handle">The GLFW window.</param>
        private GameWindow(Window handle) : this()
        {
            Handle = handle;
        }

        /// <summary>
        /// Initialize the GLFW window library.
        /// </summary>
        private GameWindow()
        {
            // --------------------
            // GLFW
            // --------------------
            // Initialize GLFW at the
            // top of the execution.
            if (!GLFW.Initialize())
                Environment.Exit(-1);
            // --------------------

            // Set default window hints
            GLFW.DefaultWindowHints();

            GLFW.WindowHint(GLFW.Hint.ContextVersionMajor, 3);
            GLFW.WindowHint(GLFW.Hint.ContextVersionMinor, 3);
            GLFW.WindowHint(GLFW.Hint.OpenglProfile, GLFW.OpenGLProfile.Core);
#if APPLE
            // Activate forward compatibility on MacOS/iOS
            GLFW.WindowHint(GLFW.Hint.OpenglForwardCompat, true);
#endif
            GLFW.WindowHint(GLFW.Hint.Resizable, GameSettings.GameWindowResizable);
            GLFW.WindowHint(GLFW.Hint.AutoIconify, true);
            GLFW.WindowHint(GLFW.Hint.Doublebuffer, true);
            GLFW.WindowHint(GLFW.Hint.Visible, false);

            if (GameSettings.MultisampleEnabled)
                GLFW.WindowHint(GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.WindowHint(GLFW.Hint.Samples, 0);
        }

        /// <summary>
        /// Create a new game window with game settings.
        /// </summary>
        /// <param name="title">The title of the <see cref="GameWindow"/>.</param>
        public GameWindow(string title) : this(title, GameWindow.None)
        {
            _title = title;
        }

        /// <summary>
        /// Create a new game window with game settings.
        /// </summary>
        /// <param name="title">The title of the <see cref="GameWindow"/>.</param>
        /// <param name="share">The window to share context resources with.</param>
        public GameWindow(string title, GameWindow share) : this()
        {
            if (GameSettings.GameWindowFullscreenMode)
            {
                var mode = GLFW.GetVideoMode(Monitor.PrimaryMonitor.Handle);

                GLFW.WindowHint(GLFW.Hint.RedBits, mode.RedBits);
                GLFW.WindowHint(GLFW.Hint.GreenBits, mode.GreenBits);
                GLFW.WindowHint(GLFW.Hint.BlueBits, mode.BlueBits);
                GLFW.WindowHint(GLFW.Hint.RefreshRate, mode.RefreshRate);
            }

            Handle = GLFW.CreateWindow(GameSettings.GameWindowSize.Width,
                GameSettings.GameWindowSize.Height,
                title, (GameSettings.GameWindowFullscreenMode) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle,
                (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.Shutdown();
                Environment.Exit(-1);
            }

            _initWindow();
        }

        public GameWindow(Sizei size, string title) : this(size, title, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title) : this(new Sizei(width, height), title, GameWindow.None)
        {
        }

        public GameWindow(Sizei size, string title, GameWindow share) : this()
        {
            _title = title;
            _size = size;

            if (GameSettings.GameWindowFullscreenMode)
            {
                var mode = GLFW.GetVideoMode(Monitor.PrimaryMonitor.Handle);

                GLFW.WindowHint(GLFW.Hint.RedBits, mode.RedBits);
                GLFW.WindowHint(GLFW.Hint.GreenBits, mode.GreenBits);
                GLFW.WindowHint(GLFW.Hint.BlueBits, mode.BlueBits);
                GLFW.WindowHint(GLFW.Hint.RefreshRate, mode.RefreshRate);
            }

            Handle = GLFW.CreateWindow(size.Width, size.Height, title,
                (GameSettings.GameWindowFullscreenMode) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle,
                (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.Shutdown();
                Environment.Exit(-1);
            }

            _initWindow();
        }

        public GameWindow(int width, int height, string title, GameWindow share) : this(new Sizei(width, height), title,
            share)
        {
        }

        /// <summary>
        /// Create a new game window
        /// </summary>
        /// <param name="size">The size of the window.</param>
        /// <param name="title">The title of the window.</param>
        /// <param name="fullscreen">Define if the window is in fullscreen mode on the primary <see cref="Monitor"/>.</param>
        public GameWindow(Sizei size, string title, bool fullscreen) : this(size, title, fullscreen, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, bool fullscreen) : this(new Sizei(width, height), title,
            fullscreen, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, bool fullscreen, GameWindow share) : this(
            new Sizei(width, height), title, fullscreen, share)
        {
        }

        public GameWindow(Sizei size, string title, bool fullscreen, GameWindow share) : this()
        {
            _title = title;
            _size = size;

            if (fullscreen)
            {
                var mode = GLFW.GetVideoMode(Monitor.PrimaryMonitor.Handle);

                GLFW.WindowHint(GLFW.Hint.RedBits, mode.RedBits);
                GLFW.WindowHint(GLFW.Hint.GreenBits, mode.GreenBits);
                GLFW.WindowHint(GLFW.Hint.BlueBits, mode.BlueBits);
                GLFW.WindowHint(GLFW.Hint.RefreshRate, mode.RefreshRate);
            }

            Handle = GLFW.CreateWindow(size.Width, size.Height, title,
                (fullscreen) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle,
                (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.Shutdown();
                Environment.Exit(-1);
            }

            _initWindow();
        }

        public GameWindow(Sizei size, string title, Monitor monitor) : this(size, title, monitor, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, Monitor monitor) : this(new Sizei(width, height), title,
            monitor, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, Monitor monitor, GameWindow share) : this(
            new Sizei(width, height), title, monitor, share)
        {
        }

        public GameWindow(Sizei size, string title, Monitor monitor, GameWindow share) : this()
        {
            _title = title;
            _size = size;

            if (GameSettings.GameWindowFullscreenMode)
            {
                var mode = GLFW.GetVideoMode(monitor.Handle);

                GLFW.WindowHint(GLFW.Hint.RedBits, mode.RedBits);
                GLFW.WindowHint(GLFW.Hint.GreenBits, mode.GreenBits);
                GLFW.WindowHint(GLFW.Hint.BlueBits, mode.BlueBits);
                GLFW.WindowHint(GLFW.Hint.RefreshRate, mode.RefreshRate);
            }

            Handle = GLFW.CreateWindow(size.Width, size.Height, title,
                (GameSettings.GameWindowFullscreenMode) ? monitor.Handle : Monitor.None.Handle,
                (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.Shutdown();
                Environment.Exit(-1);
            }

            _initWindow();
        }

        public GameWindow(Sizei size, string title, bool fullscreen, Monitor monitor) : this(size, title, fullscreen,
            monitor, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, bool fullscreen, Monitor monitor) : this(
            new Sizei(width, height), title, fullscreen, monitor, GameWindow.None)
        {
        }

        public GameWindow(int width, int height, string title, bool fullscreen, Monitor monitor, GameWindow share) :
            this(new Sizei(width, height), title, fullscreen, monitor, share)
        {
        }

        public GameWindow(Sizei size, string title, bool fullscreen, Monitor monitor, GameWindow share) : this()
        {
            _title = title;
            _size = size;

            if (fullscreen)
            {
                var mode = GLFW.GetVideoMode(monitor.Handle);

                GLFW.WindowHint(GLFW.Hint.RedBits, mode.RedBits);
                GLFW.WindowHint(GLFW.Hint.GreenBits, mode.GreenBits);
                GLFW.WindowHint(GLFW.Hint.BlueBits, mode.BlueBits);
                GLFW.WindowHint(GLFW.Hint.RefreshRate, mode.RefreshRate);
            }

            Handle = GLFW.CreateWindow(size.Width, size.Height, title,
                (fullscreen) ? monitor.Handle : Monitor.None.Handle,
                (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.Shutdown();
                Environment.Exit(-1);
            }

            _initWindow();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate used to create events when resizing the <see cref="GameWindow"/>.
        /// </summary>
        /// <param name="sender">The object which trigger the event.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void ResizeEvent(object sender, ResizeEventArgs e);

        public delegate void MouseEnterEvent(object sender, MouseEnterEventArgs e);

        public delegate void MouseLeaveEvent(object sender, MouseLeaveEventArgs e);

        public delegate void GameWindowEvent(object sender, EventArgs e);

        #endregion

        #region Events

        public event ResizeEvent WindowSizeChange;

        public event MouseEnterEvent MouseEnter;

        public event MouseLeaveEvent MouseLeave;

        public event ResizeEvent FramebufferSizeChange;

        public event GameWindowEvent Closing;

        public event GameWindowEvent OnGotFocus;

        public event GameWindowEvent OnLostFocus;

        #endregion

        #region Private Members

        private void _initWindow()
        {
            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.SwapInterval(GameSettings.VSyncInterval);

            // Set the aspect ratio
            // GLFW.SetWindowAspectRatio(Handle, GameSettings.GameWindowAspectRatio[0], GameSettings.GameWindowAspectRatio[1]);
        }

        private void OnResize(Window window, int width, int height)
        {
            var size = new Sizei(width, height);
            WindowSizeChange?.Invoke(this, new ResizeEventArgs(size, Size));
            _size = size;
        }

        private void OnMouseLeaveEnter(Window window, bool entered)
        {
            if (entered)
                MouseEnter?.Invoke(this, new MouseEnterEventArgs(Input.MousePosition));
            else
                MouseLeave?.Invoke(this, new MouseLeaveEventArgs(Input.MousePosition));
        }

        private void OnFramebufferSizeChange(Window window, int width, int height)
        {
            var size = new Sizei(width, height);
            RendererManager.SetViewport(Point2i.Zero, size);
            FramebufferSizeChange?.Invoke(this, new ResizeEventArgs(size, FramebufferSize));
            _framebufferSize = size;
        }

        private void OnClose(Window window)
        {
            Closing?.Invoke(this, new EventArgs());
        }

        private void OnFocusChange(Window window, bool focused)
        {
            if (focused)
                OnGotFocus?.Invoke(this, new EventArgs());
            else
                OnLostFocus?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets or sets the <see cref="Cursor"/> of this <see cref="GameWindow"/>.
        /// </summary>
        public Cursor Cursor
        {
            get { return _cursor; }
            set { SetCursor(value); }
        }

        public Point2i Position
        {
            get
            {
                int x, y;
                GLFW.GetWindowPos(Handle, out x, out y);
                return new Point2i(x, y);
            }
            set { SetPosition(value); }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Position, Size); }
            set
            {
                Position = value.Location;
                Size = value.Size;
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is decorated
        /// (has border, close buttons, window's title, etc...).
        /// </summary>
        public bool Decorated => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Decorated);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is floating
        /// (is always-on-top).
        /// </summary>
        public bool Floating => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Floating);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is focused.
        /// </summary>
        public bool Focused => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Focused);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is iconified.
        /// </summary>
        public bool Minimized => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Iconified);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is maximized.
        /// </summary>
        public bool Maximized => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Maximized);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is resizable.
        /// </summary>
        public bool Resizable => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Resizable);

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is visible.
        /// </summary>
        public bool Visible => GLFW.GetWindowAttrib(Handle, GLFW.WindowAttrib.Visible);

        /// <summary>
        /// Gets or sets the title of this <see cref="GameWindow"/>.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                GLFW.SetWindowTitle(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of this <see cref="GameWindow"/>.
        /// </summary>
        public Sizei Size
        {
            get { return _size; }
            set
            {
                _size = value;
                GLFW.SetWindowSize(Handle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Gets the framebuffer size of this <see cref="GameWindow"/>.
        /// </summary>
        public Sizei FramebufferSize => _framebufferSize;

        /// <summary>
        /// Gets or sets the width of this <see cref="GameWindow"/>.
        /// </summary>
        public int Width
        {
            get { return _size.Width; }
            set
            {
                _size.Width = value;
                GLFW.SetWindowSize(Handle, value, _size.Height);
            }
        }

        /// <summary>
        /// Gets or sets the height of this <see cref="GameWindow"/>.
        /// </summary>
        public int Height
        {
            get { return _size.Height; }
            set
            {
                _size.Height = value;
                GLFW.SetWindowSize(Handle, _size.Width, value);
            }
        }

        /// <summary>
        /// Sets the current window position.
        /// </summary>
        /// <param name="position">The new position.</param>
        public void SetPosition(Point2i position)
        {
            GLFW.SetWindowPos(Handle, position.X, position.Y);
        }

        /// <summary>
        /// Make the context of this <see cref="GameWindow"/>
        /// current in the calling thread.
        /// </summary>
        public void MakeContextCurrent()
        {
            GLFW.MakeContextCurrent(Handle);
        }

        /// <summary>
        /// Gets framebuffer size.
        /// </summary>
        /// <param name="width">The framebuffer's width.</param>
        /// <param name="height">The framebuffer's height.</param>
        public void GetFramebufferSize(out int width, out int height)
        {
            GLFW.GetFramebufferSize(Handle, out width, out height);
        }

        /// <summary>
        /// Minimize the window;
        /// </summary>
        public void Minimize()
        {
            GLFW.IconifyWindow(Handle);
        }

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public void Maximize()
        {
            GLFW.MaximizeWindow(Handle);
        }

        /// <summary>
        /// Restore the window if it was previously maximized or iconified (minimized).
        /// </summary>
        public void Restore()
        {
            GLFW.RestoreWindow(Handle);
        }

        /// <summary>
        /// Make the window visible.
        /// </summary>
        public void Show()
        {
            GLFW.ShowWindow(Handle);
        }

        /// <summary>
        /// Determine if a window "close" event is being processed.
        /// </summary>
        /// <returns>true if the window is being closed, false otherwise.</returns>
        public bool ShouldClose()
        {
            return GLFW.WindowShouldClose(Handle);
        }

        /// <summary>
        /// Swaps the front and back buffers of the current window.
        /// </summary>
        public void SwapBuffers()
        {
            GLFW.SwapBuffers(Handle);
        }

        /// <summary>
        /// Sets the cursor image used in this <see cref="GameWindow"/>.
        /// </summary>
        /// <param name="cursor">The <see cref="Cursor"/> to use.</param>
        public void SetCursor(Cursor cursor)
        {
            _cursor = cursor;
            GLFW.SetCursor(Handle, cursor.Handle);
        }

        /// <summary>
        /// Gets the <see cref="CursorState"/> of the cursor in this <see cref="GameWindow"/>.
        /// </summary>
        /// <seealso cref="Input.GetCursorState"/>
        public CursorState GetCursorState()
        {
            return (CursorState) GLFW.GetInputMode(Handle, GLFW.InputMode.Cursor);
        }

        /// <summary>
        /// Launch the "close" event and close the window.
        /// </summary>
        public void Close()
        {
            GLFW.SetWindowShouldClose(Handle, true);
        }

        /// <summary>
        /// Destroys the window.
        /// </summary>
        public void Destroy()
        {
            GLFW.DestroyWindow(Handle);
        }

        /// <summary>
        /// Sets this <see cref="GameWindow"/> as the current ones.
        /// </summary>
        public void SetCurrent()
        {
            Game.Game.Instance.SetGameWindow(this);
            
            // Apply callbacks
            GLFW.SetWindowSizeCallback(Handle, (window, width, height) => Game.Game.Instance.Window.OnResize(window, width, height));
            GLFW.SetCursorEnterCallback(Handle, (window, entered) => Game.Game.Instance.Window.OnMouseLeaveEnter(window, entered));
            GLFW.SetFramebufferSizeCallback(Handle, (window, width, height) => Game.Game.Instance.Window.OnFramebufferSizeChange(window, width, height));
            GLFW.SetWindowCloseCallback(Handle, (window) => Game.Game.Instance.Window.OnClose(window));
            GLFW.SetWindowFocusCallback(Handle, (window, focused) => Game.Game.Instance.Window.OnFocusChange(window, focused));
        }

        #endregion

        #region Static members

        /// <summary>
        /// Gets a NULL window's pointer.
        /// </summary>
        public static GameWindow None => new GameWindow(Window.None);

        /// <summary>
        /// Makes current the given window's context.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void MakeContextCurrent(ref GameWindow window)
        {
            window.MakeContextCurrent();
        }

        /// <summary>
        /// Call all events in the queue.
        /// </summary>
        public static void PollEvents()
        {
            GLFW.PollEvents();
        }

        /// <summary>
        /// Swaps front and back buffers in the specified <see cref="GameWindow"/>.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void SwapBuffers(ref GameWindow window)
        {
            window.SwapBuffers();
        }

        /// <summary>
        /// Launch the "close" event and close the window.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void Close(ref GameWindow window)
        {
            window.Close();
        }

        /// <summary>
        /// Destroys the window.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void Destroy(ref GameWindow window)
        {
            window.Destroy();
        }

        #endregion
    }
}