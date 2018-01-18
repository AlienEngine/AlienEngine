namespace AlienEngine.Core.Rendering.Shadows
{
    /// <summary>
    /// Defines the quality of the rendered shadow map.
    /// </summary>
    public enum ShadowMapQuality
    {
        /// <summary>
        /// Low quality.
        /// </summary>
        /// <remarks>
        /// A low quality shadow map, will be a single
        /// shadow map with a texture size of 512 pixels.
        /// </remarks>
        Low = 0,

        /// <summary>
        /// Normal quality.
        /// </summary>
        /// <remarks>
        /// A normal quality shadow map, will be a single
        /// shadow map with a texture size of 1024 pixels.
        /// </remarks>
        Normal = 1,

        /// <summary>
        /// High quality.
        /// </summary>
        /// <remarks>
        /// A high quality shadow map, will be a two level
        /// cascaded shadow map with a texture size of 2048 pixels.
        /// </remarks>
        High = 2,

        /// <summary>
        /// Very high quality.
        /// </summary>
        /// <remarks>
        /// A very high quality shadow map, will be a three level
        /// cascaded shadow map with a texture size of 4096 pixels.
        /// </remarks>
        VeryHigh = 3,

        /// <summary>
        /// Ultra quality.
        /// </summary>
        /// <remarks>
        /// An ultra quality shadow map, will be a four level
        /// cascaded shadow map with a texture size of 8192 pixels.
        /// </remarks>
        Ultra = 4
    }
}