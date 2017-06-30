using System;

namespace AlienEngine
{
    public static class Time
    {
        /// <summary>
        /// The delta time.
        /// </summary>
        private static double _delta;

        /// <summary>
        ///  The base date used to calculate the time.
        /// </summary>
        private static readonly DateTime _baseDate = new DateTime(1970, 1, 1); 

        /// <summary>
        /// Represend a second.
        /// </summary>
        public static long SECOND = 1000L;

        /// <summary>
        /// The delta time.
        /// </summary>
        public static double DeltaTime
        {
            get { return _delta; }
        }

        public static long GetTime()
        {
            return (long)DateTime.Now.Subtract(_baseDate).TotalMilliseconds;
        }

        public static double GetDelta()
        {
            return _delta;
        }

        public static void SetDelta(double delta)
        {
            _delta = delta;
        }
    }
}
