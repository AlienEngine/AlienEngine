using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core.Game;
using AlienEngine.Core.Inputs;

namespace AlienEngine
{
    public static class Input
    {
        #region Fields
        /// <summary>
        /// Events trigerred when the user input a text.
        /// </summary>
        private static List<TextInputEvent> _textEvents;

        /// <summary>
        /// Events trigerred when the user press a key.
        /// </summary>
        private static List<KeyEvent> _keyEvents;

        /// <summary>
        /// Events trigerred when the user move the cursor.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEvents;

        /// <summary>
        /// Backup for text input events.
        /// </summary>
        private static List<TextInputEvent> _textEventsBackup;

        /// <summary>
        /// Backup for key press events.
        /// </summary>
        private static List<KeyEvent> _keyEventsBackup;

        /// <summary>
        /// Backup for mouse move events.
        /// </summary>
        private static List<MouseMoveEvent> _mouseMoveEventsBackup;
        #endregion

        #region Properties
        public static Point2d MousePosition
        {
            get { return Mouse.Position; }
            set { Mouse.Position = value; }
        }

        public static Point2d PreviousMousePosition
        {
            get { return Mouse.PreviousPosition; }
            set { Mouse.PreviousPosition = value; }
        }
        #endregion

        #region Delegates
        public delegate void TextInputEvent(char text);

        public delegate void KeyEvent(KeyCode code, InputState state, KeyMods mods);

        public delegate void MouseMoveEvent(double x, double y);
        #endregion

        #region Initializer
        static Input()
        {
            _textEvents = new List<TextInputEvent>();
            _keyEvents = new List<KeyEvent>();
            _mouseMoveEvents = new List<MouseMoveEvent>();

            _textEventsBackup = null;
            _keyEventsBackup = null;
            _mouseMoveEventsBackup = null;
        }
        #endregion

        #region Members
        public static bool Held(KeyCode key)
        {
            return Keyboard.GetKey(key);
        }

        public static bool Up(KeyCode key)
        {
            return Keyboard.GetKeyUp(key);
        }

        public static bool Down(KeyCode key)
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

        public static bool Down(MouseButton key)
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
            return (CursorState)GLFW.GetInputMode(Game.Window, GLFW.InputMode.Cursor);
        }

        internal static void BackupEvents()
        {
            BackupKeyEvents();
            BackupMouseMoveEvents();
            BackupTextInputEvents();
        }

        internal static void ClearEvents(bool backup = false)
        {
            if (backup) BackupEvents();

            ClearKeyEvents();
            ClearMouseMoveEvents();
            ClearTextInputEvents();
        }

        internal static void RestoreEvents()
        {
            RestoreKeyEvents();
            RestoreMouseMoveEvents();
            RestoreTextInputEvents();
        }

        internal static void BackupKeyEvents()
        {
            _keyEventsBackup = _keyEvents;
        }

        internal static void ClearKeyEvents(bool backup = false)
        {
            if (backup) BackupKeyEvents();

            _keyEvents = new List<KeyEvent>();
            Refresh();
        }

        internal static void RestoreKeyEvents()
        {
            if (_keyEventsBackup != null)
            {
                _keyEvents = _keyEventsBackup;
                _keyEventsBackup = null;
                Refresh();
            }
        }

        internal static void BackupTextInputEvents()
        {
            _textEventsBackup = _textEvents;
        }

        internal static void ClearTextInputEvents(bool backup = false)
        {
            if (backup) BackupTextInputEvents();

            _textEvents = new List<TextInputEvent>();
            Refresh();
        }

        internal static void RestoreTextInputEvents()
        {
            if (_textEventsBackup != null)
            {
                _textEvents = _textEventsBackup;
                _textEventsBackup = null;
                Refresh();
            }
        }

        internal static void BackupMouseMoveEvents()
        {
            _mouseMoveEventsBackup = _mouseMoveEvents;
        }

        internal static void ClearMouseMoveEvents(bool backup = false)
        {
            if (backup) BackupMouseMoveEvents();

            _mouseMoveEvents = new List<MouseMoveEvent>();
            Refresh();
        }

        internal static void RestoreMouseMoveEvents()
        {
            if (_mouseMoveEventsBackup != null)
            {
                _mouseMoveEvents = _mouseMoveEventsBackup;
                _mouseMoveEventsBackup = null;
                Refresh();
            }
        }

        public static int AddKeyEvent(KeyEvent e)
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
            GLFW.SetKeyCallback(Game.Window, null);
            GLFW.SetKeyCallback(Game.Window, (w, key, scancode, state, mods) =>
            {
                foreach (var e in _keyEvents)
                {
                    if (e != null) e(key, state, mods);
                }
            });

            GLFW.SetCharCallback(Game.Window, null);
            GLFW.SetCharCallback(Game.Window, (w, code) =>
            {
                foreach (var e in _textEvents)
                {
                    if (e != null) e((char)code);
                }
            });

            GLFW.SetCursorPosCallback(Game.Window, null);
            GLFW.SetCursorPosCallback(Game.Window, (w, x, y) =>
            {
                foreach (var e in _mouseMoveEvents)
                {
                    if (e != null) e(x, y);
                }
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
