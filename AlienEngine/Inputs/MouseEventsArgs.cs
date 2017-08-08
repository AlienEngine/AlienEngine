using System;

namespace AlienEngine
{
    public enum SpecialKey
    {
        Alt, Control, Shift
    };

    public class MouseEventArgs : EventArgs
    {
        public Point2d Location { get; private set; }
        public Point2d LastLocaton { get; private set; }
        public MouseButton Button { get; private set; }
        public InputState State { get; private set; }

        public MouseEventArgs(Click MousePosition, Click LastMousePosition)
            : this(new Point2d(MousePosition.X, MousePosition.Y), MousePosition.Button, MousePosition.State)
        {
            this.LastLocaton = new Point2d(LastMousePosition.X, LastMousePosition.Y);
        }

        public MouseEventArgs()
            : this(new Point2d(0, 0))
        {
        }

        public MouseEventArgs(Point2d Location)
        {
            this.LastLocaton = new Point2d(Location.X, Location.Y);
            this.Location = this.LastLocaton;
        }

        public MouseEventArgs(Point2d Location, MouseButton Button, InputState State)
        {
            this.LastLocaton = new Point2d(Location.X, Location.Y);
            this.Location = this.LastLocaton;
            this.Button = Button;
            this.State = State;
        }

        internal void SetLocation(Point2d Location)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point2d(Location.X, Location.Y);
        }

        internal void SetState(Point2d Location, MouseButton Button, InputState State)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point2d(Location.X, Location.Y);
            this.Button = Button;
            this.State = State;
        }
    }

    /// <summary>
    /// A click stores information about the mouse location
    /// and button at the time of a click event.
    /// </summary>
    public struct Click
    {
        #region Fields
        /// <summary>
        /// The x-location of the mouse wrt the top-left.
        /// </summary>
        public int X;

        /// <summary>
        /// The y-location of the mouse wrt the top-left.
        /// </summary>
        public int Y;

        /// <summary>
        /// The mouse button pressed on the click event.
        /// </summary>
        public MouseButton Button;

        /// <summary>
        /// True if the mouse button has been pressed, false if it has been released.
        /// </summary>
        public InputState State;
        #endregion

        #region Methods
        /// <summary>
        /// A new click object with x, y and button data.
        /// </summary>
        /// <param name="x">The x-location of the mouse wrt the top-left.</param>
        /// <param name="y">The y-location of the mouse wrt the top-left.</param>
        /// <param name="button">The mouse button pressed on the click event.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        public Click(int x, int y, MouseButton button, InputState state)
        {
            X = x;
            Y = y;
            Button = button;
            State = state;
        }

        /// <summary>
        /// A new click object with x, y and button data.
        /// </summary>
        /// <param name="_x">The x-location of the mouse wrt the top-left.</param>
        /// <param name="_y">The y-location of the mouse wrt the top-left.</param>
        /// <param name="left">True if the left button is pressed.</param>
        /// <param name="middle">True if the middle button is pressed.</param>
        /// <param name="right">True if the right button is pressed.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        public Click(int x, int y, bool left, bool middle, bool right, bool pressed) :
            this(x, y, (left ? MouseButton.LeftClick : (right ? MouseButton.RightClick : MouseButton.MiddleClick)), pressed ? InputState.Press : InputState.Release) { }

        /// <summary>
        /// A new click object with button data.
        /// </summary>
        /// <param name="left">True if the left button is pressed.</param>
        /// <param name="middle">True if the middle button is pressed.</param>
        /// <param name="right">True if the right button is pressed.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        //public Click(bool left, bool middle, bool right, bool pressed) :
        //    this(MousePosition.x, MousePosition.y, left, middle, right, pressed) { }

        /// <summary>
        /// ToString override to give some information about the mouse state.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Mouse at {0},{1} and is {2}.", X, Y, State);
        }
        #endregion
    }
}
