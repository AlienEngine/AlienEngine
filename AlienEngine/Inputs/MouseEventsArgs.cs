using System;

namespace AlienEngine
{
    public enum SpecialKey
    {
        Alt, Control, Shift
    };

    public class MouseEventArgs : EventArgs
    {
        public Point2i Location { get; private set; }
        public Point2i LastLocaton { get; private set; }
        public Input.MouseButton Button { get; private set; }
        public Input.InputState State { get; private set; }

        public MouseEventArgs(Click MousePosition, Click LastMousePosition)
            : this(new Point2i(MousePosition.X, MousePosition.Y), MousePosition.Button, MousePosition.State)
        {
            this.LastLocaton = new Point2i(LastMousePosition.X, LastMousePosition.Y);
        }

        public MouseEventArgs()
            : this(new Point2i(0, 0))
        {
        }

        public MouseEventArgs(Point2i Location)
        {
            this.LastLocaton = new Point2i(Location.X, Location.Y);
            this.Location = this.LastLocaton;
        }

        public MouseEventArgs(Point2i Location, Input.MouseButton Button, Input.InputState State)
        {
            this.LastLocaton = new Point2i(Location.X, Location.Y);
            this.Location = this.LastLocaton;
            this.Button = Button;
            this.State = State;
        }

        internal void SetLocation(Point2i Location)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point2i(Location.X, Location.Y);
        }

        internal void SetState(Point2i Location, Input.MouseButton Button, Input.InputState State)
        {
            this.LastLocaton = this.Location;
            this.Location = new Point2i(Location.X, Location.Y);
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
        public Input.MouseButton Button;

        /// <summary>
        /// True if the mouse button has been pressed, false if it has been released.
        /// </summary>
        public Input.InputState State;
        #endregion

        #region Methods
        /// <summary>
        /// A new click object with x, y and button data.
        /// </summary>
        /// <param name="x">The x-location of the mouse wrt the top-left.</param>
        /// <param name="y">The y-location of the mouse wrt the top-left.</param>
        /// <param name="button">The mouse button pressed on the click event.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        public Click(int x, int y, Input.MouseButton button, Input.InputState state)
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
            this(x, y, (left ? Input.MouseButton.LeftClick : (right ? Input.MouseButton.RightClick : Input.MouseButton.MiddleClick)), pressed ? Input.InputState.Press : Input.InputState.Release) { }

        /// <summary>
        /// A new click object with button data.
        /// </summary>
        /// <param name="left">True if the left button is pressed.</param>
        /// <param name="middle">True if the middle button is pressed.</param>
        /// <param name="right">True if the right button is pressed.</param>
        /// <param name="pressed">True if the mouse has been pressed, false if released.</param>
        //public Click(bool left, bool middle, bool right, bool pressed) :
        //    this(Input.MousePosition.x, Input.MousePosition.y, left, middle, right, pressed) { }

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
