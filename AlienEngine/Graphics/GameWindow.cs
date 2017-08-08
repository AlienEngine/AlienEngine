using AlienEngine.Core.Game;
using System;
using Window = AlienEngine.Core.Graphics.GLFW.GLFW.Window;

namespace AlienEngine.Core.Graphics
{
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
        #endregion

        #region Constructors
        private GameWindow(Window handle) : this()
        {
            Handle = handle;
        }

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
        /// Gets framebuffer size.
        /// </summary>
        /// <param name="width">The framebuffer's width.</param>
        /// <param name="height">The framebuffer's height.</param>
        public void GetFramebufferSize(out int width, out int height)
        {
            GLFW.GLFW.GetFramebufferSize(Handle, out width, out height);
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
        /// Sets the cursor image showed in the window.
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
        #endregion
    }
}
