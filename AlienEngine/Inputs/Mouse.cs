using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;

namespace AlienEngine.Core.Inputs
{
    internal static class Mouse
    {
        private static List<MouseButton> _currentButtons;
        private static Array _allKeys;
        private static Point2d _mousePosition;
        private static Point2d _prevMousePosition;

        public static Point2d Position
        {
            get { return _mousePosition; }
            set
            {
                _prevMousePosition = _mousePosition;
                _mousePosition = value;
                GLFW.SetCursorPos(Game.Game.Instance.Window.Handle, value.X, value.Y);
            }
        }

        public static Point2d PreviousPosition => _prevMousePosition;

        public static bool Grabbed
        {
            get
            {
                return GLFW.GetInputMode(Game.Game.Instance.Window.Handle, GLFW.InputMode.Cursor) ==
                       (int) GLFW.CursorMode.Disabled;
            }
            set
            {
                GLFW.SetInputMode(Game.Game.Instance.Window.Handle, GLFW.InputMode.Cursor,
                    value ? GLFW.CursorMode.Disabled : GLFW.CursorMode.Normal);
            }
        }

        public static bool Hidden
        {
            get
            {
                return GLFW.GetInputMode(Game.Game.Instance.Window.Handle, GLFW.InputMode.Cursor) ==
                       (int) GLFW.CursorMode.Hidden;
            }
            set
            {
                GLFW.SetInputMode(Game.Game.Instance.Window.Handle, GLFW.InputMode.Cursor,
                    value ? GLFW.CursorMode.Hidden : GLFW.CursorMode.Normal);
            }
        }

        static Mouse()
        {
            _allKeys = Enum.GetValues(typeof(MouseButton));
            _currentButtons = new List<MouseButton>();
        }

        public static void Init()
        {
        }

        public static void Update()
        {
            Point2d pos;
            GLFW.GetCursorPos(Game.Game.Instance.Window.Handle, out pos.X, out pos.Y);
            Position = pos;
            
            _currentButtons.Clear();
            foreach (MouseButton i in _allKeys)
                if (GetButton(i) && !_currentButtons.Contains(i))
                    _currentButtons.Add(i);
        }

        public static bool GetButton(MouseButton keyCode)
        {
            return GLFW.GetMouseButton(Game.Game.Instance.Window.Handle, keyCode);
        }

        public static bool GetButtonDown(MouseButton keyCode)
        {
            return GetButton(keyCode) && !_currentButtons.Contains(keyCode);
        }

        public static bool GetButtonUp(MouseButton keyCode)
        {
            return !GetButton(keyCode) && _currentButtons.Contains(keyCode);
        }
    }
}