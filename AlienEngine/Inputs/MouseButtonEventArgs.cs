namespace AlienEngine
{
    /// <summary>
    /// Stores event data for mouse button events.
    /// </summary>
    public class MouseButtonEventArgs : MouseEventArgs
    {
        public readonly SpecialKeys SpecialKeys;
        
        /// <summary>
        /// Creates a new mouse button event.
        /// </summary>
        /// <param name="state">The state of the mouse.</param>
        public MouseButtonEventArgs(MouseState state, SpecialKeys keys = SpecialKeys.None) : base(state)
        {
            SpecialKeys = keys;
        }

        /// <summary>
        /// Creates a new mouse button event.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="button">The button which rise the event.</param>
        /// <param name="state">The input state of the button.</param>
        public MouseButtonEventArgs(Point2d location, MouseButton button, InputState state, SpecialKeys keys = SpecialKeys.None) : base(location, button,
            state, Vector2d.Zero)
        {
            SpecialKeys = keys;
        }

        public MouseButtonEventArgs(double x, double y, MouseButton button, bool pressed, SpecialKeys keys = SpecialKeys.None) : base(new Point2d(x, y),
            button, pressed ? InputState.Pressed : InputState.Released, Vector2d.Zero)
        {
            SpecialKeys = keys;
        }
        
        public bool IsPressed => ButtonState == InputState.Pressed;

        public bool IsReleased => ButtonState == InputState.Released;

        public bool IsRepeated => ButtonState == InputState.Repeated;
        
        public bool IsLeftButtonPressed()
        {
            return Button == MouseButton.Left && ButtonState == InputState.Pressed;
        }

        public bool IsMiddleButtonPressed()
        {
            return Button == MouseButton.Middle && ButtonState == InputState.Pressed;
        }

        public bool IsRightButtonPressed()
        {
            return Button == MouseButton.Right && ButtonState == InputState.Pressed;
        }

        public bool IsLeftButtonReleased()
        {
            return Button == MouseButton.Left && ButtonState == InputState.Released;
        }

        public bool IsMiddleButtonReleased()
        {
            return Button == MouseButton.Middle && ButtonState == InputState.Released;
        }

        public bool IsRightButtonReleased()
        {
            return Button == MouseButton.Right && ButtonState == InputState.Released;
        }

        public bool IsLeftButtonRepeated()
        {
            return Button == MouseButton.Left && ButtonState == InputState.Repeated;
        }

        public bool IsMiddleButtonRepeated()
        {
            return Button == MouseButton.Middle && ButtonState == InputState.Repeated;
        }

        public bool IsRightButtonRepeated()
        {
            return Button == MouseButton.Right && ButtonState == InputState.Repeated;
        }
    }
}