namespace AlienEngine
{
    /// <summary>
    /// Cursor states.
    /// </summary>
    public enum CursorState
    {
        /// <summary>
        /// Makes the cursor visible and behaving normally.
        /// </summary>
        Normal = 0x00034001,

        /// <summary>
        /// Makes the cursor invisible when it is over the client area of the window but does
        /// not restrict the cursor from leaving.
        /// </summary>
        Hidden = 0x00034002,

        /// <summary>
        /// Hides and grabs the cursor, providing virtual and unlimited cursor movement. This is
        /// useful for implementing for example 3D camera controls.
        /// </summary>
        Grabbed = 0x00034003
    }
}
