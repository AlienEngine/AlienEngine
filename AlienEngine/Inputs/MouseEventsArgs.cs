using System;

namespace AlienEngine
{
    /// <summary>
    /// Stores data about a mouse event.
    /// </summary>
    public class MouseEventArgs : EventArgs
    {
        /// <summary>
        /// The state of the mouse when the event is raised.
        /// </summary>
        public readonly MouseState State;

        /// <summary>
        /// The location of the mouse at the screen
        /// when the event is raised.
        /// </summary>
        public Point2d Location => State.Location;

        /// <summary>
        /// The mouse button which rise the event
        /// </summary>
        public MouseButton Button => State.Button;

        /// <summary>
        /// The input mouse button state.
        /// </summary>
        public InputState ButtonState => State.ButtonState;

        /// <summary>
        /// The X position of the mouse.
        /// </summary>
        public double X => Location.X;

        /// <summary>
        /// The Y position of the mouse.
        /// </summary>
        public double Y => Location.Y;
        
        /// <summary>
        /// Creates a new mouse event with no data.
        /// </summary>
        public MouseEventArgs()
        {
            State = new MouseState(Point2d.Zero);
        }

        /// <summary>
        /// Creates a new mouse event.
        /// </summary>
        /// <param name="x">The X position of the mouse.</param>
        /// <param name="y">The Y position of the mouse.</param>
        public MouseEventArgs(double x, double y)
        {
            State = new MouseState(new Point2d(x, y));
        }
        
        /// <summary>
        /// Creates a new mouse event with mouse location.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        public MouseEventArgs(Point2d location)
        {
            State = new MouseState(location);
        }

        /// <summary>
        /// Creates a new mouse event.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="button">The active button.</param>
        /// <param name="buttonState">The state of the active button.</param>
        public MouseEventArgs(Point2d location, MouseButton button, InputState buttonState)
        {
            State = new MouseState(location, button, buttonState, Vector2d.Zero);
        }

        /// <summary>
        /// Creates a new mouse event.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="button">The active button.</param>
        /// <param name="buttonState">The state of the active button.</param>
        /// <param name="scroll">The value of the wheel.</param>
        public MouseEventArgs(Point2d location, MouseButton button, InputState buttonState, Vector2d scroll)
        {
            State = new MouseState(location, button, buttonState, scroll);
        }

        /// <summary>
        /// Creates a new mouse event.
        /// </summary>
        /// <param name="state">The mouse state when this event occurs.</param>
        public MouseEventArgs(MouseState state)
        {
            State = state;
        }
    }
}