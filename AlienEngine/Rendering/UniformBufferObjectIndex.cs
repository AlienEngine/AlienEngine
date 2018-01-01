namespace AlienEngine.Core.Rendering
{
    public enum UniformBufferObjectIndex
    {
        /// <summary>
        /// Index of uniform buffer object storing matrices.
        /// </summary>
        Matrices = 0,
        
        /// <summary>
        /// Index of uniform buffer object storing light informations.
        /// </summary>
        Lights = 1,

        /// <summary>
        /// Index of uniform buffer object storing camera informations.
        /// </summary>
        Camera = 2
    }
}