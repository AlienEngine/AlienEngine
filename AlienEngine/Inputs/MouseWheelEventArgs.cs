using System;

namespace AlienEngine
{
    /// <summary>
    /// Stores event data for mouse wheel events.
    /// </summary>
    public class MouseWheelEventArgs : MouseEventArgs
    {
        /// <summary>
        /// The change in value of the wheel for this event.
        /// </summary>
        private Vector2d _delta;

        /// <summary>
        /// Gets the value of the wheel in integer units.
        /// To support high-precision mice, it is recommended to use <see cref="ValuePrecise"/> instead.
        /// </summary>
        public Vector2d Value => State.Scroll;

        /// <summary>
        /// Gets the change in value of the wheel for this event in integer units.
        /// To support high-precision mice, it is recommended to use <see cref="DeltaPrecise"/> instead.
        /// </summary>
        public Vector2d Delta => _delta;

        public MouseWheelEventArgs(Point2d location, Vector2d value, Vector2d delta) : base(location, MouseButton.Unknown,
            InputState.Unknown, value)
        {
            _delta = delta;
        }

        /// <summary>
        /// Constructs a new <see cref="MouseWheelEventArgs"/> instance.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="value">The value of the wheel.</param>
        /// <param name="delta">The change in value of the wheel for this event.</param>
        public MouseWheelEventArgs(double x, double y, Vector2d value, Vector2d delta) : base(new Point2d(x, y), MouseButton.Unknown,
            InputState.Unknown, value)
        {
            _delta = delta;
        }

        /// <summary>
        /// Constructs a new <see cref="MouseWheelEventArgs"/> instance.
        /// </summary>
        /// <param name="args">The <see cref="MouseWheelEventArgs"/> instance to clone.</param>
        public MouseWheelEventArgs(MouseWheelEventArgs args)
            : this(args.X, args.Y, args.Value, args.Delta)
        {
        }
    }
}