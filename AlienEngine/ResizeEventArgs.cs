namespace AlienEngine.Core
{
    public class ResizeEventArgs
    {
        public readonly Sizei NewSize;

        public readonly Sizei LastSize;
        
        public ResizeEventArgs(Sizei newSize, Sizei lastSize)
        {
            NewSize = newSize;
            LastSize = lastSize;
        }
    }
}