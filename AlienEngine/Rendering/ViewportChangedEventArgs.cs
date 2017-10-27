using System;

namespace AlienEngine.Core.Rendering
{
    public class ViewportChangedEventArgs: EventArgs
    {
        public readonly Rectangle Old;

        public readonly Rectangle New;
        
        public ViewportChangedEventArgs(Rectangle _old, Rectangle _new)
        {
            Old = _old;
            New = _new;
        }
    }
}