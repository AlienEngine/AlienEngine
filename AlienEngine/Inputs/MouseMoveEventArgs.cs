using AlienEngine.Core.Inputs;

namespace AlienEngine
{
    /// <summary>
    /// Stores event data for mouse move events.
    /// </summary>
    public class MouseMoveEventArgs : MouseEventArgs
    {
        /// <summary>
        /// The change in X position produced by this event.
        /// </summary>
        private double _x;

        /// <summary>
        /// The change in Y position produced by this event.
        /// </summary>
        private double _y;

        /// <summary>
        /// Gets the change in X position produced by this event.
        /// </summary>
        public double XDelta => _x;

        /// <summary>
        /// Gets the change in Y position produced by this event.
        /// </summary>
        public double YDelta => _y;

        /// <summary>
        /// Creates a new mouse move event.
        /// </summary>
        /// <param name="state">The state of the mouse while moving.</param>
        /// <param name="deltaX">The change in X position produced by this event.</param>
        /// <param name="deltaY">The change in Y position produced by this event.</param>
        public MouseMoveEventArgs(MouseState state, double deltaX, double deltaY) : base(state)
        {
            _x = deltaX;
            _y = deltaY;
        }

        /// <summary>
        /// Creates a new mouse move event.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="deltaX">The change in X position produced by this event.</param>
        /// <param name="deltaY">The change in Y position produced by this event.</param>
        public MouseMoveEventArgs(Point2d location, double deltaX, double deltaY) : base(location)
        {
            _x = deltaX;
            _y = deltaY;
        }

        /// <summary>
        /// Creates a new mouse move event.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="lastLocation">The previous location of the mouse.</param>
        public MouseMoveEventArgs(Point2d location, Point2d lastLocation) : base(location)
        {
            _x = location.X - lastLocation.X;
            _y = location.Y - lastLocation.Y;
        }

        /// <summary>
        /// Creates a new mouse move event.
        /// </summary>
        /// <param name="locationX">The X location of the mouse.</param>
        /// <param name="locationY">The Y location of the mouse.</param>
        /// <param name="deltaX">The change in X position produced by this event.</param>
        /// <param name="deltaY">The change in Y position produced by this event.</param>
        public MouseMoveEventArgs(double locationX, double locationY, double deltaX, double deltaY) : base(locationX,
            locationY)
        {
            _x = deltaX;
            _y = deltaY;
        }

        /// <summary>
        /// Creates a new mouse move event.
        /// </summary>
        /// <param name="e">The <see cref="MouseMoveEventArgs"/> to clone.</param>
        public MouseMoveEventArgs(MouseMoveEventArgs e) : this(e.State, e._x, e._y)
        {
        }
    }
}