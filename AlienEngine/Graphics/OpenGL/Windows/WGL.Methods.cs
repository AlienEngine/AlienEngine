using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    public static partial class WGL
    {
        private static Dictionary<IntPtr, List<string>> _supportedExtensions;

        static WGL()
        {
            _supportedExtensions = new Dictionary<IntPtr, List<string>>();
        }
        
        public static bool IsExtensionSupported(IntPtr context, string name)
        {
            if (!_supportedExtensions.ContainsKey(context))
            {
                string extensions = WGL.GetExtensionsStringARB(context);
                _supportedExtensions[context] = new List<string>(extensions.Split(' '));
            }

            return _supportedExtensions[context].Contains(name);
        }
    }
}