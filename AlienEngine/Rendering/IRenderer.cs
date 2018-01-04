namespace AlienEngine.Core.Rendering
{
    /// <summary>
    /// Describe the behavior of a renderer.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Initialize the renderer.
        /// </summary>
        void Init();
        
        /// <summary>
        /// Execute the renderer.
        /// </summary>
        void Process();
    }
}