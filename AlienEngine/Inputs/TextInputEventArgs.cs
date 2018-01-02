using System;

namespace AlienEngine
{
    public class TextInputEventArgs: EventArgs
    {
        public readonly char KeyChar;

        public TextInputEventArgs(char keyChar)
        {
            KeyChar = keyChar;
        }

        public TextInputEventArgs(uint code)
        {
            KeyChar = (char) code;
        }
    }
}