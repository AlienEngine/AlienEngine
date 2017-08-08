using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;
using AlienEngine.Core.Game;

namespace AlienEngine.Core.Inputs
{
    public static class Keyboard
    {
        private static List<KeyCode> _currentKeys;
        private static Array _allKeys;

        static Keyboard()
        {
            _allKeys = Enum.GetValues(typeof(KeyCode));
            _currentKeys = new List<KeyCode>();
        }

        public static void Update()
        {
            _currentKeys.Clear();
            foreach (KeyCode i in _allKeys)
                if (GetKey(i))
                    _currentKeys.Add(i);
        }

        public static bool GetKey(KeyCode keyCode)
        {
            return GLFW.GetKey(Game.Game.Window.Handle, (int)keyCode);
        }

        public static bool GetKeyDown(KeyCode keyCode)
        {
            return GetKey(keyCode) && !_currentKeys.Contains(keyCode);
        }

        public static bool GetKeyUp(KeyCode keyCode)
        {
            return !GetKey(keyCode) && _currentKeys.Contains(keyCode);
        }
    }
}
