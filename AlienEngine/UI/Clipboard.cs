using System.Collections.Generic;

namespace AlienEngine.UI
{
    public static class Clipboard
    {
        private static readonly Stack<string> Clips;

        public static Stack<string> History => Clips;

        static Clipboard()
        {
            Clips = new Stack<string>();
        }

        public static void Copy(string text)
        {
            Clips.Push(text);
        }

        public static string Paste()
        {
            return Clips.Count > 0 ? Clips.Peek() : "";
        }

        public static string PasteRemove()
        {
            return Clips.Count > 0 ? Clips.Pop() : "";
        }
    }
}