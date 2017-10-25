namespace AlienEngine.UI
{
    public struct Padding
    {
        public int Left, Top, Right, Bottom;

        public int Horizontal
        {
            get { return Left + Right; }
        }

        public int Vertical
        {
            get { return Top + Bottom; }
        }

        public Padding(int all)
        {
            Left = Top = Right = Bottom = all;
        }

        public Padding(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}