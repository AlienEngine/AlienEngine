using System;

namespace AlienEngine
{
    /// <summary>
    /// Store data about the state of the mouse
    /// at a given time.
    /// </summary>
    public struct MouseState : IEquatable<MouseState>
    {
        /// <summary>
        /// The active button in this state.
        /// </summary>
        public readonly MouseButton Button;

        /// <summary>
        /// The state of the active button.
        /// </summary>
        public readonly InputState ButtonState;

        /// <summary>
        /// The location of the mouse in this state.
        /// </summary>
        public readonly Point2d Location;

        /// <summary>
        /// The scroll offset
        /// </summary>
        public readonly Vector2d Scroll;

        /// <summary>
        /// Creates and store data about a <see cref="MouseState"/>.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        /// <param name="button">The active button of the mouse.</param>
        /// <param name="buttonState">The state of the active butron.</param>
        /// <param name="scroll">The value of the wheel.</param>
        public MouseState(Point2d location, MouseButton button, InputState buttonState, Vector2d scroll)
        {
            Location = location;
            Button = button;
            ButtonState = buttonState;
            Scroll = scroll;
        }

        /// <summary>
        /// Creates and store data about a <see cref="MouseState"/>.
        /// </summary>
        /// <param name="location">The location of the mouse.</param>
        public MouseState(Point2d location)
        {
            Location = location;
            Button = MouseButton.Unknown;
            ButtonState = InputState.Unknown;
            Scroll = Vector2d.Zero;
        }

        /// <summary>
        /// Compares two instances of <see cref="MouseState"/> for equality.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>true if equals, false otherwise</returns>
        public bool Equals(MouseState other)
        {
            return Location == other.Location && Button == other.Button && ButtonState == other.ButtonState;
        }

        /// <summary>
        /// Compares this instance of <see cref="MouseState"/>
        /// with another <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>true if equals, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is MouseState && Equals((MouseState) obj);
        }

        /// <summary>
        /// Gets the hash code of this instance.
        /// </summary>
        /// <returns>The hash code of this instance</returns>
        public override int GetHashCode()
        {
            return Location.GetHashCode() ^ (int) Button ^ (int) ButtonState ^ Scroll.GetHashCode();
        }

        /// <summary>
        /// Compares two instances of <see cref="MouseState"/> for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>true if equals, false otherwise</returns>
        public static bool operator ==(MouseState left, MouseState right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances of <see cref="MouseState"/> for difference.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>true if differents, false otherwise</returns>
        public static bool operator !=(MouseState left, MouseState right)
        {
            return !left.Equals(right);
        }
    }
}