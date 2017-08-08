using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core.Game;

namespace AlienEngine.Core.Inputs
{
    public static class Mouse
    {
        private static List<MouseButton> _currentButtons;
        private static Array _allKeys;
        private static Point2d mousePosition;
        private static Point2d prevMousePosition;

        public static Point2d Position
        {
            get { return mousePosition; }
            set
            {
                PreviousPosition = mousePosition;
                mousePosition = value;
                GLFW.SetCursorPos(Game.Game.Window.Handle, value.X, value.Y);
            }
        }

        public static Point2d PreviousPosition
        {
            get { return prevMousePosition; }
            set { prevMousePosition = value; }
        }

        public static bool Grabbed
        {
            get
            {
                return GLFW.GetInputMode(Game.Game.Window.Handle, GLFW.InputMode.Cursor) == (int)GLFW.CursorMode.Disabled;
            }
            set
            {
                GLFW.SetInputMode(Game.Game.Window.Handle, GLFW.InputMode.Cursor, value ? GLFW.CursorMode.Disabled : GLFW.CursorMode.Normal);
            }
        }

        public static bool Hidden
        {
            get
            {
                return GLFW.GetInputMode(Game.Game.Window.Handle, GLFW.InputMode.Cursor) == (int)GLFW.CursorMode.Hidden;
            }
            set
            {
                GLFW.SetInputMode(Game.Game.Window.Handle, GLFW.InputMode.Cursor, value ? GLFW.CursorMode.Hidden : GLFW.CursorMode.Normal);
            }
        }

        static Mouse()
        {
            _allKeys = Enum.GetValues(typeof(MouseButton));
            _currentButtons = new List<MouseButton>();
        }

        public static void Update()
        {
            Point2d pos;
            GLFW.GetCursorPos(Game.Game.Window.Handle, out pos.X, out pos.Y);
            Position = pos;

            _currentButtons.Clear();
            foreach (MouseButton i in _allKeys)
                if (GetButton(i))
                    _currentButtons.Add(i);
        }

        public static bool GetButton(MouseButton keyCode)
        {
            return GLFW.GetMouseButton(Game.Game.Window.Handle, keyCode);
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
