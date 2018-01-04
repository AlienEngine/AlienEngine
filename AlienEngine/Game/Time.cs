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
        /// The base date used to calculate the time.
        /// </summary>
        private static readonly DateTime _baseDate; 

        /// <summary>
        /// Represent the number of ticks in one second.
        /// </summary>
        public const int SECOND = 1000;

        /// <summary>
        /// The delta time between two frames.
        /// </summary>
        public static double DeltaTime => _delta;

        static Time()
        {
            _baseDate = DateTime.Now;
        }

        /// <summary>
        /// Gets the <see cref="Time"/> elapsed from the start of the <see cref="Core.Game.Game"/>.
        /// </summary>
        public static double GetTime()
        {
            return AlienEngine.Core.Graphics.GLFW.GLFW.GetTime() * SECOND;
        }

        /// <summary>
        /// Gets the delta time between two frames.
        /// </summary>
        public static double GetDelta()
        {
            return _delta;
        }

        /// <summary>
        /// Sets the delta time between two frames.
        /// </summary>
        /// <param name="delta">The delta time.</param>
        public static void SetDelta(double delta)
        {
            _delta = delta;
        }
    }
}
