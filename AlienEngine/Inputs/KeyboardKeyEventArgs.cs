using System;

namespace AlienEngine
{
    public class KeyboardKeyEventArgs : EventArgs
    {
        public readonly KeyCode Key;

        public readonly InputState KeyState;
        
        public readonly SpecialKeys SpecialKey;

        public KeyboardKeyEventArgs(KeyCode code, InputState keyState, SpecialKeys modifiers)
        {
            Key = code;
            KeyState = keyState;
            SpecialKey = modifiers;
        }

        public bool Shift => SpecialKey.HasFlag(SpecialKeys.Shift);

        public bool Control => SpecialKey.HasFlag(SpecialKeys.Control);

        public bool Alt => SpecialKey.HasFlag(SpecialKeys.Alt);

        public bool Super => SpecialKey.HasFlag(SpecialKeys.Super);

        public bool None => SpecialKey == SpecialKeys.None;
    }
}