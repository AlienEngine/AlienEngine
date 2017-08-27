namespace AlienEngine
{
    /// <summary>
    /// Load an instance from <see cref="System.String"/>.
    /// </summary>
    internal interface ILoadFromString
    {
        /// <summary>
        /// Load values for this instance from a <see cref="System.String"/>.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> to convert into this instance.</param>
        void FromString(string value);
    }
}