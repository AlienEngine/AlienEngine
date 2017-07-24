namespace AlienEngine
{
    /// <summary>
    /// <see cref="AudioSource"/> state information.
    /// </summary>
    public enum AudioSourceState
    {
        /// <summary>
        /// Default State when loaded.
        /// </summary>
        Initial = 0x1011,

        /// <summary>
        /// The source is currently playing.
        /// </summary>
        Playing = 0x1012,

        /// <summary>The source has paused playback.
        /// </summary>
        Paused = 0x1013,

        /// <summary>The source is not playing.
        /// </summary>
        Stopped = 0x1014
    }
}
