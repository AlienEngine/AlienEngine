namespace AlienEngine
{
    /// <summary>
    /// Key and button actions.
    /// </summary>
    public enum InputState : int
    {
        /// <summary>
        /// The key or mouse button was released.
        /// </summary>
        Release = 0,

        /// <summary>
        /// The key or mouse button was pressed.
        /// </summary>
        Press = 1,

        /// <summary>
        /// The key was held down until it repeated.
        /// </summary>
        Repeat = 2
    }
}
