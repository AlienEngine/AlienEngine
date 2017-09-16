namespace AlienEngine
{
    /// <summary>
    /// Rollof algorithms used by 3D <see cref="AudioSource"/>s.
    /// </summary>
    public enum AudioRolloffAlgorithm
    {
        /// <summary>
        /// No volume rollof algorithm is used for this <see cref="AudioSource"/>.
        /// </summary>
        None,

        /// <summary>
        /// Rollof the volume with the inverse of the distance between the
        /// <see cref="AudioSource"/> and the <see cref="AudioListener"/>.
        /// </summary>
        InverseDistance,

        /// <summary>
        /// Rollof the volume with the inverse of the distance between the
        /// <see cref="AudioSource"/> and the <see cref="AudioListener"/>.
        /// The distance is clamped between the <see cref="AudioSource.ReferenceDistance"/>
        /// and the <see cref="AudioSource.MaxDistance"/>.
        /// </summary>
        InverseDistanceClamped,

        /// <summary>
        /// Rollof the volume with the distance between the <see cref="AudioSource"/>
        /// and the <see cref="AudioListener"/> over the exponent of the <see cref="AudioSource.ReferenceDistance"/>.
        /// </summary>
        ExponentDistance,

        /// <summary>
        /// Rollof the volume with the distance between the <see cref="AudioSource"/>
        /// and the <see cref="AudioListener"/> over the exponent of the <see cref="AudioSource.ReferenceDistance"/>.
        /// The distance is clamped between the <see cref="AudioSource.ReferenceDistance"/>
        /// and the <see cref="AudioSource.MaxDistance"/>.
        /// </summary>
        ExponentDistanceClamped,

        /// <summary>
        /// Rollof the volume with the distance between the <see cref="AudioSource"/>
        /// and the <see cref="AudioListener"/>.
        /// </summary>
        LinearDistance,

        /// <summary>
        /// Rollof the volume with the distance between the <see cref="AudioSource"/>
        /// and the <see cref="AudioListener"/>.
        /// The distance is clamped between the <see cref="AudioSource.ReferenceDistance"/>
        /// and the <see cref="AudioSource.MaxDistance"/>.
        /// </summary>
        LinearDistanceClamped,

        /// <summary>
        /// Rollof the volume with a custom algorithm.
        /// </summary>
        Custom
    }
}
