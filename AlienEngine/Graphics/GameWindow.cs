using AlienEngine.Core.Game;
using System;
using Window = AlienEngine.Core.Graphics.GLFW.GLFW.Window;

namespace AlienEngine.Core.Graphics
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
        #region Static members
        /// <summary>
        /// Gets a NULL window's pointer.
        /// </summary>
        public static GameWindow None
        {
            get { return new GameWindow(Window.None); }
        }
        #endregion

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
            if (!GLFW.GLFW.Initialize())
                Environment.Exit(-1);
            // --------------------
        }

        /// <summary>
        /// Create a new game window with game settings.
        /// </summary>
        /// <param name="title">The title of the <see cref="GameWindow"/>.</param>
        public GameWindow(string title) : this(title, GameWindow.None)
        { }

        /// <summary>
        /// Create a new game window with game settings.
        /// </summary>
        /// <param name="title">The title of the <see cref="GameWindow"/>.</param>
        /// <param name="share">The window to share context resources with.</param>
        public GameWindow(string title, GameWindow share) : this()
        {
            // Set default window hints
            GLFW.GLFW.DefaultWindowHints();
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Resizable, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.AutoIconify, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Doublebuffer, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Visible, false);

            if (GameSettings.MultisampleEnabled)
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, 0);

            Handle = GLFW.GLFW.CreateWindow(GameSettings.GameWindowSize.Width, GameSettings.GameWindowSize.Height, title, (GameSettings.GameWindowFullscreenMode) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle, (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.GLFW.Shutdown();
                Environment.Exit(-1);
            }

            // Make the window's context current
            GLFW.GLFW.MakeContextCurrent(Handle);

            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.GLFW.SwapInterval(GameSettings.VSyncInterval);
        }

        public GameWindow(Sizei size, string title) : this(size, title, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title) : this(new Sizei(width, height), title, GameWindow.None)
        { }

        public GameWindow(Sizei size, string title, GameWindow share) : this()
        {
            // Set default window hints
            GLFW.GLFW.DefaultWindowHints();
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Resizable, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.AutoIconify, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Visible, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Doublebuffer, true);

            if (GameSettings.MultisampleEnabled)
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, 0);

            Handle = GLFW.GLFW.CreateWindow(size.Width, size.Height, title, (GameSettings.GameWindowFullscreenMode) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle, (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.GLFW.Shutdown();
                Environment.Exit(-1);
            }

            // Make the window's context current
            GLFW.GLFW.MakeContextCurrent(Handle);

            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.GLFW.SwapInterval(GameSettings.VSyncInterval);
        }

        public GameWindow(int width, int height, string title, GameWindow share) : this(new Sizei(width, height), title, share)
        { }

        /// <summary>
        /// Create a new game window
        /// </summary>
        /// <param name="size">The size of the window.</param>
        /// <param name="title">The title of the window.</param>
        /// <param name="fullscreen">Define if the window is in fullscreen mode on the primary <see cref="Monitor"/>.</param>
        public GameWindow(Sizei size, string title, bool fullscreen) : this(size, title, fullscreen, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, bool fullscreen) : this(new Sizei(width, height), title, fullscreen, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, bool fullscreen, GameWindow share) : this(new Sizei(width, height), title, fullscreen, share)
        { }

        public GameWindow(Sizei size, string title, bool fullscreen, GameWindow share) : this()
        {
            // Set default window hints
            GLFW.GLFW.DefaultWindowHints();
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Resizable, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.AutoIconify, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Doublebuffer, true);

            if (GameSettings.MultisampleEnabled)
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, 0);

            Handle = GLFW.GLFW.CreateWindow(size.Width, size.Height, title, (fullscreen) ? Monitor.PrimaryMonitor.Handle : Monitor.None.Handle, (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.GLFW.Shutdown();
                Environment.Exit(-1);
            }

            // Make the window's context current
            GLFW.GLFW.MakeContextCurrent(Handle);

            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.GLFW.SwapInterval(GameSettings.VSyncInterval);
        }

        public GameWindow(Sizei size, string title, Monitor monitor) : this(size, title, monitor, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, Monitor monitor) : this(new Sizei(width, height), title, monitor, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, Monitor monitor, GameWindow share) : this(new Sizei(width, height), title, monitor, share)
        { }

        public GameWindow(Sizei size, string title, Monitor monitor, GameWindow share) : this()
        {
            // Set default window hints
            GLFW.GLFW.DefaultWindowHints();
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Resizable, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.AutoIconify, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Doublebuffer, true);

            if (GameSettings.MultisampleEnabled)
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, 0);

            Handle = GLFW.GLFW.CreateWindow(size.Width, size.Height, title, (GameSettings.GameWindowFullscreenMode) ? monitor.Handle : Monitor.None.Handle, (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.GLFW.Shutdown();
                Environment.Exit(-1);
            }

            // Make the window's context current
            GLFW.GLFW.MakeContextCurrent(Handle);

            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.GLFW.SwapInterval(GameSettings.VSyncInterval);
        }

        public GameWindow(Sizei size, string title, bool fullscreen, Monitor monitor) : this(size, title, fullscreen, monitor, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, bool fullscreen, Monitor monitor) : this(new Sizei(width, height), title, fullscreen, monitor, GameWindow.None)
        { }

        public GameWindow(int width, int height, string title, bool fullscreen, Monitor monitor, GameWindow share) : this(new Sizei(width, height), title, fullscreen, monitor, share)
        { }

        public GameWindow(Sizei size, string title, bool fullscreen, Monitor monitor, GameWindow share) : this()
        {
            // Set default window hints
            GLFW.GLFW.DefaultWindowHints();
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Resizable, false);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.AutoIconify, true);
            GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Doublebuffer, true);

            if (GameSettings.MultisampleEnabled)
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, GameSettings.MultisampleLevel);
            else
                GLFW.GLFW.WindowHint(GLFW.GLFW.Hint.Samples, 0);

            Handle = GLFW.GLFW.CreateWindow(size.Width, size.Height, title, (GameSettings.GameWindowFullscreenMode) ? monitor.Handle : Monitor.None.Handle, (share != null) ? share.Handle : None.Handle);

            if (!Handle)
            {
                GLFW.GLFW.Shutdown();
                Environment.Exit(-1);
            }

            // Make the window's context current
            GLFW.GLFW.MakeContextCurrent(Handle);

            // Enable V-Sync
            if (GameSettings.VSyncEnabled)
                GLFW.GLFW.SwapInterval(GameSettings.VSyncInterval);
        }
        #endregion

        #region Public members
        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is decorated
        /// (has border, close buttons, window's title, etc...).
        /// </summary>
        public bool Decorated
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Decorated);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is floating
        /// (is always-on-top).
        /// </summary>
        public bool Floating
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Floating);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is focused.
        /// </summary>
        public bool Focused
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Focused);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is iconified.
        /// </summary>
        public bool Iconified
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Iconified);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is maximized.
        /// </summary>
        public bool Maximized
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Maximized);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is resizable.
        /// </summary>
        public bool Resizable
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Resizable);
            }
        }

        /// <summary>
        /// Gets a boolean defining if the <see cref="GameWindow"/> is visible.
        /// </summary>
        public bool Visible
        {
            get
            {
                return GLFW.GLFW.GetWindowAttrib(Handle, GLFW.GLFW.WindowAttrib.Visible);
            }
        }

        /// <summary>
        /// Gets or sets the title of this <see cref="GameWindow"/>.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                GLFW.GLFW.SetWindowTitle(Handle, value);
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
                GLFW.GLFW.SetWindowSize(Handle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Gets or sets the width of this <see cref="GameWindow"/>.
        /// </summary>
        public int Width
        {
            get { return _size.Width; }
            set
            {
                _size.Width = value;
                GLFW.GLFW.SetWindowSize(Handle, value, _size.Height);
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
                GLFW.GLFW.SetWindowSize(Handle, _size.Width, value);
            }
        }

        /// <summary>
        /// Gets framebuffer size.
        /// </summary>
        /// <param name="width">The framebuffer's width.</param>
        /// <param name="height">The framebuffer's height.</param>
        public void GetFramebufferSize(out int width, out int height)
        {
            GLFW.GLFW.GetFramebufferSize(Handle, out width, out height);
        }

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public void Maximize()
        {
            GLFW.GLFW.MaximizeWindow(Handle);
        }

        /// <summary>
        /// Restore the window if it was previously maximized or iconified (minimized).
        /// </summary>
        public void Restore()
        {
            GLFW.GLFW.RestoreWindow(Handle);
        }

        /// <summary>
        /// Make the window visible.
        /// </summary>
        public void Show()
        {
            GLFW.GLFW.ShowWindow(Handle);
        }

        /// <summary>
        /// Determine if a window "close" event is being processed.
        /// </summary>
        /// <returns>true if the window is being closed, false otherwise.</returns>
        public bool ShouldClose()
        {
            return GLFW.GLFW.WindowShouldClose(Handle);
        }

        /// <summary>
        /// Swaps the front and back buffers of the current window.
        /// </summary>
        public void SwapBuffers()
        {
            GLFW.GLFW.SwapBuffers(Handle);
        }

        /// <summary>
        /// Sets the cursor image used in the window.
        /// </summary>
        /// <param name="cursor">The <see cref="Cursor"/> to use.</param>
        public void SetCursor(Cursor cursor)
        {
            GLFW.GLFW.SetCursor(Handle, cursor.Handle);
        }

        /// <summary>
        /// Gets the <see cref="CursorState"/> of the cursor in this <see cref="GameWindow"/>.
        /// </summary>
        /// <seealso cref="Input.GetCursorState"/>
        public CursorState GetCursorState()
        {
            return (CursorState)GLFW.GLFW.GetInputMode(Handle, GLFW.GLFW.InputMode.Cursor);
        }

        /// <summary>
        /// Launch the "close" event and close the window.
        /// </summary>
        public void Close()
        {
            GLFW.GLFW.SetWindowShouldClose(Handle, true);
        }

        /// <summary>
        /// Destroys the window.
        /// </summary>
        public void Destroy()
        {
            GLFW.GLFW.DestroyWindow(Handle);
        }
        #endregion

        #region Static members
        /// <summary>
        /// Call all events in the queue.
        /// </summary>
        public static void PollEvents()
        {
            GLFW.GLFW.PollEvents();
        }

        /// <summary>
        /// Swaps front and back buffers in the specified <see cref="GameWindow"/>.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void SwapBuffers(GameWindow window)
        {
            GLFW.GLFW.SwapBuffers(window.Handle);
        }
        #endregion
    }
}
