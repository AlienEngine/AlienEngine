namespace AlienEngine.Core.Rendering.Shadows
{
    public interface IShadowMap
    {
        /// <summary>
        /// The FBO ID of this shadow map.
        /// </summary>
        uint BufferID { get; }

        /// <summary>
        /// The texture ID used by this shadow map.
        /// </summary>
        uint TextureID { get; }

        /// <summary>
        /// Defines if the shadow map is cascaded.
        /// </summary>
        bool Cascaded { get; }
        
        /// <summary>
        /// The texture size of the shadow map.
        /// </summary>
        Sizei TextureSize { get; }

        /// <summary>
        /// The texture width of the shadow map.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The texture height of the shadow map.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Initialize the first pass of shadow mapping.
        /// </summary>
        /// <param name="clear">If we want to clear the previous depth buffer.</param>
        void Begin(bool clear = true);

        /// <summary>
        /// Initialize the second pass of shadow mapping.
        /// </summary>
        void End();

        /// <summary>
        /// Binds the texture of the shadow map.
        /// </summary>
        void BindTexture();
    }
}
