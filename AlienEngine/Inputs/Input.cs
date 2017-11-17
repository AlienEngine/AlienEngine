using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core;
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

        /// <summary>
        /// The scroll offset of the last scroll event.
        /// </summary>
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
        /// Events trigerred when the user press a key;
        /// </summary>
        private static List<KeyboardKeyEvent> _keyDownEvents;

        /// <summary>
        /// Events trigerred when the user release a key;
        /// </summary>
        private static List<KeyboardKeyEvent> _keyUpEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEvents;

        /// <summary>
        /// Events trigerred when the user press a mouse button.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonDownEvents;

        /// <summary>
        /// Events trigerred when the user release a mouse button.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonUpEvents;

        /// <summary>
        /// Events trigerred when the user scroll the wheel.
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
        /// Backup for key down events.
        /// </summary>
        private static List<KeyboardKeyEvent> _keyDownEventsBackup;

        /// <summary>
        /// Backup for key up events.
        /// </summary>
        private static List<KeyboardKeyEvent> _keyUpEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEventsBackup;

        /// <summary>
        /// Backup for mouse button down events.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonDownEventsBackup;

        /// <summary>
        /// Backup for mouse button up events.
        /// </summary>
        private static List<MouseButtonEvent> _mouseButtonUpEventsBackup;

        /// <summary>
        /// Backup for mouse wheel events.
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

        /// <summary>
        /// Check if the mouse is currently grabbed in the <see cref="GameWindow"/>.
        /// </summary>
        public static bool MouseIsGrabbed => Mouse.Grabbed;

        /// <summary>
        /// Check if the mouse is currently hidden in the <see cref="GameWindow"/>.
        /// </summary>
        public static bool MouseIsHidden => Mouse.Hidden;

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

        /// <summary>
        /// Initialize the manager.
        /// </summary>
        static Input()
        {
            _lastScrollOffset = Vector2d.Zero;

            _textEvents = new List<TextInputEvent>();
            _keyEvents = new List<KeyboardKeyEvent>();
            _keyDownEvents = new List<KeyboardKeyEvent>();
            _keyUpEvents = new List<KeyboardKeyEvent>();
            _mouseMoveEvents = new List<MouseMoveEvent>();
            _mouseButtonDownEvents = new List<MouseButtonEvent>();
            _mouseButtonUpEvents = new List<MouseButtonEvent>();
            _mouseWheelEvents = new List<MouseWheelEvent>();

            _textEventsBackup = null;
            _keyEventsBackup = null;
            _keyDownEventsBackup = null;
            _keyUpEventsBackup = null;
            _mouseMoveEventsBackup = null;
            _mouseButtonDownEventsBackup = null;
            _mouseButtonUpEventsBackup = null;
            _mouseWheelEventsBackup = null;
        }

        #endregion

        #region Keyboard

        public static bool Holding(KeyCode key)
        {
            return Keyboard.GetKey(key);
        }

        public static bool Released(KeyCode key)
        {
            return Keyboard.GetKeyUp(key);
        }

        public static bool Pressed(KeyCode key)
        {
            return Keyboard.GetKeyDown(key);
        }

        #endregion

        #region Mouse

        public static bool Holding(MouseButton key)
        {
            return Mouse.GetButton(key);
        }

        public static bool Released(MouseButton key)
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

        #endregion

        #region Joystick

        #region Properties

        /// <summary>
        /// Gets the state of the 01st joystick.
        /// </summary>
        public static JoystickState Joystick01 => Joystick.GetState(JoystickDevice.Joystick01);

        /// <summary>
        /// Gets the state of the 02nd joystick.
        /// </summary>
        public static JoystickState Joystick02 => Joystick.GetState(JoystickDevice.Joystick02);

        /// <summary>
        /// Gets the state of the 03rd joystick.
        /// </summary>
        public static JoystickState Joystick03 => Joystick.GetState(JoystickDevice.Joystick03);

        /// <summary>
        /// Gets the state of the 04th joystick.
        /// </summary>
        public static JoystickState Joystick04 => Joystick.GetState(JoystickDevice.Joystick04);

        /// <summary>
        /// Gets the state of the 05th joystick.
        /// </summary>
        public static JoystickState Joystick05 => Joystick.GetState(JoystickDevice.Joystick05);

        /// <summary>
        /// Gets the state of the 06th joystick.
        /// </summary>
        public static JoystickState Joystick06 => Joystick.GetState(JoystickDevice.Joystick06);

        /// <summary>
        /// Gets the state of the 07th joystick.
        /// </summary>
        public static JoystickState Joystick07 => Joystick.GetState(JoystickDevice.Joystick07);

        /// <summary>
        /// Gets the state of the 08th joystick.
        /// </summary>
        public static JoystickState Joystick08 => Joystick.GetState(JoystickDevice.Joystick08);

        /// <summary>
        /// Gets the state of the 09th joystick.
        /// </summary>
        public static JoystickState Joystick09 => Joystick.GetState(JoystickDevice.Joystick09);

        /// <summary>
        /// Gets the state of the 10th joystick.
        /// </summary>
        public static JoystickState Joystick10 => Joystick.GetState(JoystickDevice.Joystick10);

        /// <summary>
        /// Gets the state of the 11th joystick.
        /// </summary>
        public static JoystickState Joystick11 => Joystick.GetState(JoystickDevice.Joystick11);

        /// <summary>
        /// Gets the state of the 12th joystick.
        /// </summary>
        public static JoystickState Joystick12 => Joystick.GetState(JoystickDevice.Joystick12);

        /// <summary>
        /// Gets the state of the 13th joystick.
        /// </summary>
        public static JoystickState Joystick13 => Joystick.GetState(JoystickDevice.Joystick13);

        /// <summary>
        /// Gets the state of the 14th joystick.
        /// </summary>
        public static JoystickState Joystick14 => Joystick.GetState(JoystickDevice.Joystick14);

        /// <summary>
        /// Gets the state of the 15th joystick.
        /// </summary>
        public static JoystickState Joystick15 => Joystick.GetState(JoystickDevice.Joystick15);

        /// <summary>
        /// Gets the state of the 16th joystick.
        /// </summary>
        public static JoystickState Joystick16 => Joystick.GetState(JoystickDevice.Joystick16);

        #endregion Properties

        #region Methods

        public static bool Holding(JoystickDevice joystick, JoystickButton button)
        {
            return Joystick.GetButton(joystick, button);
        }

        public static bool Released(JoystickDevice joystick, JoystickButton button)
        {
            return Joystick.GetButtonUp(joystick, button);
        }

        public static bool Pressed(JoystickDevice joystick, JoystickButton button)
        {
            return Joystick.GetButtonDown(joystick, button);
        }

        public static float Axis(JoystickDevice joystick, JoystickAxis axis)
        {
            return Joystick.GetAxis(joystick, axis);
        }

        public static JoystickState GetJoystickState(JoystickDevice joystick)
        {
            return Joystick.GetState(joystick);
        }

        public static bool JoystickIsConnected(JoystickDevice joystick)
        {
            return Joystick.IsPresent(joystick);
        }

        public static string GetJoystickName(JoystickDevice joystick)
        {
            return Joystick.GetName(joystick);
        }

        #endregion Methods

        #endregion Joystick

        #region Events

        public static void BackupEvents()
        {
            BackupKeyEvents();
            BackupKeyDownEvents();
            BackupKeyUpEvents();
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
            ClearKeyDownEvents();
            ClearKeyUpEvents();
            ClearMouseMoveEvents();
            ClearMouseButtonDownEvents();
            ClearMouseButtonUpEvents();
            ClearMouseWheelEvents();
            ClearTextInputEvents();
        }

        public static void RestoreEvents()
        {
            RestoreKeyEvents();
            RestoreKeyDownEvents();
            RestoreKeyUpEvents();
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

        public static void BackupKeyDownEvents()
        {
            _keyDownEventsBackup = _keyDownEvents;
        }

        public static void BackupKeyUpEvents()
        {
            _keyUpEventsBackup = _keyUpEvents;
        }

        public static void ClearKeyEvents(bool backup = false)
        {
            if (backup) BackupKeyEvents();

            _keyEvents = new List<KeyboardKeyEvent>();
            Refresh();
        }

        public static void ClearKeyDownEvents(bool backup = false)
        {
            if (backup) BackupKeyDownEvents();

            _keyDownEvents = new List<KeyboardKeyEvent>();
            Refresh();
        }

        public static void ClearKeyUpEvents(bool backup = false)
        {
            if (backup) BackupKeyUpEvents();

            _keyUpEvents = new List<KeyboardKeyEvent>();
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

        public static void RestoreKeyDownEvents()
        {
            if (_keyDownEventsBackup != null)
            {
                _keyDownEvents = _keyDownEventsBackup;
                _keyDownEventsBackup = null;
                Refresh();
            }
        }

        public static void RestoreKeyUpEvents()
        {
            if (_keyUpEventsBackup != null)
            {
                _keyUpEvents = _keyUpEventsBackup;
                _keyUpEventsBackup = null;
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

        public static int AddKeyDownEvent(KeyboardKeyEvent e)
        {
            _keyDownEvents.Add(e);
            Refresh();
            return _keyDownEvents.Count - 1;
        }

        public static int AddKeyUpEvent(KeyboardKeyEvent e)
        {
            _keyUpEvents.Add(e);
            Refresh();
            return _keyUpEvents.Count - 1;
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
                    e?.Invoke(null, new KeyboardKeyEventArgs(key, state, mods));

                switch (state)
                {
                    case InputState.Pressed:
                        foreach (var e in _keyDownEvents)
                            e?.Invoke(null, new KeyboardKeyEventArgs(key, state, mods));
                        break;

                    case InputState.Released:
                        foreach (var e in _keyUpEvents)
                    e?.Invoke(null, new KeyboardKeyEventArgs(key, state, mods));
                        break;
                }
            });

            GLFW.SetCharModsCallback(Game.Window.Handle, (w, code, mods) =>
            {
                foreach (var e in _textEvents)
                    e?.Invoke(null, new TextInputEventArgs(code));
            });

            GLFW.SetCursorPosCallback(Game.Window.Handle, (w, x, y) =>
            {
                foreach (var e in _mouseMoveEvents)
                    e?.Invoke(null, new MouseMoveEventArgs(new Point2d(x, y), PreviousMousePosition));
            });

            GLFW.SetMouseButtonCallback(Game.Window.Handle, (w, b, s, k) =>
            {
                switch (s)
                {
                    case InputState.Pressed:
                        foreach (var e in _mouseButtonDownEvents)
                            e?.Invoke(null, new MouseButtonEventArgs(MousePosition, b, s, k));
                        break;

                    case InputState.Released:
                        foreach (var e in _mouseButtonUpEvents)
                            e?.Invoke(null, new MouseButtonEventArgs(MousePosition, b, s, k));
                        break;
                }
            });

            GLFW.SetScrollCallback(Game.Window.Handle, (w, x, y) =>
            {
                var offset = new Vector2d(x, y);

                foreach (var e in _mouseWheelEvents)
                    e?.Invoke(null, new MouseWheelEventArgs(MousePosition, offset, offset - _lastScrollOffset));

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