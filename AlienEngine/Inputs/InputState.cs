namespace AlienEngine
{
    /// <summary>
    /// Key and button actions.
    /// </summary>
    public enum InputState
    {
        /// <summary>
        /// References an unknown state.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// The key or mouse button was released.
        /// </summary>
        Released = 0,

        /// <summary>
        /// The key or mouse button was pressed.
        /// </summary>
        Pressed = 1,

        /// <summary>
        /// The key was held down until it repeated.
        /// </summary>
        Repeated = 2
    }
}