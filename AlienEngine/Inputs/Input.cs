using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Inputs;

namespace AlienEngine
{
    /// <summary>
    /// Provides access to mouse, joystick and
    /// keyboard events.
    /// </summary>
    /// TODO: Review comments!!
    /// TODO: KeyDown, KeyUp, KeyPress
    public static class Input
    {
        #region Fields

        private static Vector2d _lastScrollOffset;

        /// <summary>
        /// Events trigerred when the user input a text.
        /// </summary>
        private static List<TextInputEvent> _textEvents;

        /// <summary>
        /// Events trigerred when the user press a key.
        /// </summary>
        private static List<KeyboardKeyEvent> _keyEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonDownEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonUpEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseWheelEvent> _mouseWheelEvents;

        /// <summary>
        /// Backup for text input events.
        /// </summary>
        private static List<TextInputEvent> _textEventsBackup;

        /// <summary>
        /// Backup for key press events.
        /// </summary>
        private static List<KeyboardKeyEvent> _keyEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonDownEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonUpEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseWheelEvent> _mouseWheelEventsBackup;

        #endregion

        #region Properties

        /// <summary>
        /// The current mouse position.
        /// </summary>
        public static Point2d MousePosition
        {
            get { return Mouse.Position; }
            set { Mouse.Position = value; }
        }

        /// <summary>
        /// The last position that the mouse has before
        /// the current <see cref="MousePosition"/>.
        /// </summary>
        public static Point2d PreviousMousePosition => Mouse.PreviousPosition;

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate used to handle text input events.
        /// </summary>
        /// <param name="e">The event.</param>
        public delegate void TextInputEvent(object sender, TextInputEventArgs e);

        /// <summary>
        /// Delegate used to handle key events.
        /// </summary>
        /// <param name="e">The event.</param>
        public delegate void KeyboardKeyEvent(object sender, KeyboardKeyEventArgs e);

        /// <summary>
        /// Delegate used to handle mouse move events.
        /// </summary>
        /// <param name="e">The event.</param>
        public delegate void MouseMoveEvent(object sender, MouseMoveEventArgs e);

        /// <summary>
        /// Delegate used to handle mouse button events.
        /// </summary>
        /// <param name="e">The event.</param>
        public delegate void MouseButtonEvent(object sender, MouseButtonEventArgs e);

        /// <summary>
        /// Delegate used to handle mouse wheel events.
        /// </summary>
        /// <param name="e">The event.</param>
        public delegate void MouseWheelEvent(object sender, MouseWheelEventArgs e);

        #endregion

        #region Initializer

        static Input()
        {
            _lastScrollOffset = Vector2d.Zero;

            _textEvents = new List<TextInputEvent>();
            _keyEvents = new List<KeyboardKeyEvent>();
            _mouseMoveEvents = new List<MouseMoveEvent>();
            _mouseButtonDownEvents = new List<MouseButtonEvent>();
            _mouseButtonUpEvents = new List<MouseButtonEvent>();
            _mouseWheelEvents = new List<MouseWheelEvent>();

            _textEventsBackup = null;
            _keyEventsBackup = null;
            _mouseMoveEventsBackup = null;
            _mouseButtonDownEventsBackup = null;
            _mouseButtonUpEventsBackup = null;
            _mouseWheelEventsBackup = null;
        }

        #endregion

        #region Members

        public static bool Holding(KeyCode key)
        {
            return Keyboard.GetKey(key);
        }

        public static bool Up(KeyCode key)
        {
            return Keyboard.GetKeyUp(key);
        }

        public static bool Pressed(KeyCode key)
        {
            return Keyboard.GetKeyDown(key);
        }

        public static bool Held(MouseButton key)
        {
            return Mouse.GetButton(key);
        }

        public static bool Up(MouseButton key)
        {
            return Mouse.GetButtonUp(key);
        }

        public static bool Pressed(MouseButton key)
        {
            return Mouse.GetButtonDown(key);
        }

        public static void GrabMouse(bool state = true)
        {
            Mouse.Grabbed = state;
        }

        public static void HideMouse(bool state = true)
        {
            Mouse.Hidden = state;
        }

        public static CursorState GetCursorState()
        {
            return Game.Window.GetCursorState();
        }

        public static void BackupEvents()
        {
            BackupKeyEvents();
            BackupMouseMoveEvents();
            BackupMouseButtonDownEvents();
            BackupMouseButtonUpEvents();
            BackupMouseWheelEvents();
            BackupTextInputEvents();
        }

        public static void ClearEvents(bool backup = false)
        {
            if (backup) BackupEvents();

            ClearKeyEvents();
            ClearMouseMoveEvents();
            ClearMouseButtonDownEvents();
            ClearMouseButtonUpEvents();
            ClearMouseWheelEvents();
            ClearTextInputEvents();
        }

        public static void RestoreEvents()
        {
            RestoreKeyEvents();
            RestoreMouseMoveEvents();
            RestoreMouseButtonDownEvents();
            RestoreMouseButtonUpEvents();
            RestoreMouseWheelEvents();
            RestoreTextInputEvents();
        }

        public static void BackupKeyEvents()
        {
            _keyEventsBackup = _keyEvents;
        }

        public static void ClearKeyEvents(bool backup = false)
        {
            if (backup) BackupKeyEvents();

            _keyEvents = new List<KeyboardKeyEvent>();
            Refresh();
        }

        public static void RestoreKeyEvents()
        {
            if (_keyEventsBackup != null)
            {
                _keyEvents = _keyEventsBackup;
                _keyEventsBackup = null;
                Refresh();
            }
        }

        public static void BackupTextInputEvents()
        {
            _textEventsBackup = _textEvents;
        }

        public static void ClearTextInputEvents(bool backup = false)
        {
            if (backup) BackupTextInputEvents();

            _textEvents = new List<TextInputEvent>();
            Refresh();
        }

        public static void RestoreTextInputEvents()
        {
            if (_textEventsBackup != null)
            {
                _textEvents = _textEventsBackup;
                _textEventsBackup = null;
                Refresh();
            }
        }

        public static void BackupMouseMoveEvents()
        {
            _mouseMoveEventsBackup = _mouseMoveEvents;
        }

        public static void ClearMouseMoveEvents(bool backup = false)
        {
            if (backup) BackupMouseMoveEvents();

            _mouseMoveEvents = new List<MouseMoveEvent>();
            Refresh();
        }

        public static void RestoreMouseMoveEvents()
        {
            if (_mouseMoveEventsBackup != null)
            {
                _mouseMoveEvents = _mouseMoveEventsBackup;
                _mouseMoveEventsBackup = null;
                Refresh();
            }
        }

        public static void BackupMouseButtonDownEvents()
        {
            _mouseButtonDownEventsBackup = _mouseButtonDownEvents;
        }

        public static void ClearMouseButtonDownEvents(bool backup = false)
        {
            if (backup) BackupMouseButtonDownEvents();

            _mouseButtonDownEvents = new List<MouseButtonEvent>();
            Refresh();
        }

        public static void RestoreMouseButtonDownEvents()
        {
            if (_mouseButtonDownEventsBackup != null)
            {
                _mouseButtonDownEvents = _mouseButtonDownEventsBackup;
                _mouseButtonDownEventsBackup = null;
                Refresh();
            }
        }

        public static void BackupMouseButtonUpEvents()
        {
            _mouseButtonUpEventsBackup = _mouseButtonUpEvents;
        }

        public static void ClearMouseButtonUpEvents(bool backup = false)
        {
            if (backup) BackupMouseButtonUpEvents();

            _mouseButtonUpEvents = new List<MouseButtonEvent>();
            Refresh();
        }

        public static void RestoreMouseButtonUpEvents()
        {
            if (_mouseButtonUpEventsBackup != null)
            {
                _mouseButtonUpEvents = _mouseButtonUpEventsBackup;
                _mouseButtonUpEventsBackup = null;
                Refresh();
            }
        }

        public static void BackupMouseWheelEvents()
        {
            _mouseWheelEventsBackup = _mouseWheelEvents;
        }

        public static void ClearMouseWheelEvents(bool backup = false)
        {
            if (backup) BackupMouseWheelEvents();

            _mouseWheelEvents = new List<MouseWheelEvent>();
            Refresh();
        }

        public static void RestoreMouseWheelEvents()
        {
            if (_mouseWheelEventsBackup != null)
            {
                _mouseWheelEvents = _mouseWheelEventsBackup;
                _mouseWheelEventsBackup = null;
                Refresh();
            }
        }

        public static int AddKeyEvent(KeyboardKeyEvent e)
        {
            _keyEvents.Add(e);
            Refresh();
            return _keyEvents.Count - 1;
        }

        public static int AddTextInputEvent(TextInputEvent e)
        {
            _textEvents.Add(e);
            Refresh();
            return _textEvents.Count - 1;
        }

        public static int AddMouseMoveEvent(MouseMoveEvent e)
        {
            _mouseMoveEvents.Add(e);
            Refresh();
            return _mouseMoveEvents.Count - 1;
        }

        public static int AddMouseButtonDownEvent(MouseButtonEvent e)
        {
            _mouseButtonDownEvents.Add(e);
            Refresh();
            return _mouseButtonDownEvents.Count - 1;
        }

        public static int AddMouseButtonUpEvent(MouseButtonEvent e)
        {
            _mouseButtonUpEvents.Add(e);
            Refresh();
            return _mouseButtonUpEvents.Count - 1;
        }

        public static int AddMouseWheelEvent(MouseWheelEvent e)
        {
            _mouseWheelEvents.Add(e);
            Refresh();
            return _mouseWheelEvents.Count - 1;
        }

        public static void RemoveKeyEvent(int id)
        {
            _keyEvents.RemoveAt(id);
            Refresh();
        }

        public static void RemoveTextInputEvent(int id)
        {
            _textEvents.RemoveAt(id);
            Refresh();
        }

        public static void RemoveMouseMoveEvent(int id)
        {
            _mouseMoveEvents.RemoveAt(id);
            Refresh();
        }

        public static void Refresh()
        {
            GLFW.SetKeyCallback(Game.Window.Handle, (w, key, scancode, state, mods) =>
            {
                foreach (var e in _keyEvents)
                {
                    if (e != null) e(null, new KeyboardKeyEventArgs(key, state, mods));
                }
            });

            GLFW.SetCharModsCallback(Game.Window.Handle, (w, code, mods) =>
            {
                foreach (var e in _textEvents)
                {
                    if (e != null) e(null, new TextInputEventArgs(code));
                }
            });

            GLFW.SetCursorPosCallback(Game.Window.Handle, (w, x, y) =>
            {
                foreach (var e in _mouseMoveEvents)
                {
                    if (e != null) e(null, new MouseMoveEventArgs(new Point2d(x, y), PreviousMousePosition));
                }
            });

            GLFW.SetMouseButtonCallback(Game.Window.Handle, (w, b, s, k) =>
            {
                switch (s)
                {
                    case InputState.Pressed:
                        foreach (var e in _mouseButtonDownEvents)
                            if (e != null) e(null, new MouseButtonEventArgs(MousePosition, b, s, k));
                        break;

                    case InputState.Released:
                        foreach (var e in _mouseButtonUpEvents)
                            if (e != null) e(null, new MouseButtonEventArgs(MousePosition, b, s, k));
                        break;
                }
            });

            GLFW.SetScrollCallback(Game.Window.Handle, (w, x, y) =>
            {
                var offset = new Vector2d(x, y);

                foreach (var e in _mouseWheelEvents)
                {
                    if (e != null) e(null, new MouseWheelEventArgs(MousePosition, offset, offset - _lastScrollOffset));
                }

                _lastScrollOffset = offset;
            });
        }

        public static void Update()
        {
            Keyboard.Update();
            Mouse.Update();
            Joystick.Update();
        }

        #endregion
    }
}