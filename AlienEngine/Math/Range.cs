namespace AlienEngine
{
    public struct Range
    {
        private int _start;

        private int _end;

        public int Start => _start;

        public int End => _end;

        public int Length
        {
            get { return _end - _start; }
            set { _end = _start + value; }
        }

        public Range(int start, int end)
        {
            _start = start;
            _end = end;
        }
    }
}