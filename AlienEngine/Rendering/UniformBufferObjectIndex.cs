namespace AlienEngine.Core.Rendering
{
    public enum UniformBufferObjectIndex: uint
    {
        /// <summary>
        /// Index of uniform buffer object storing matrices.
        /// </summary>
        Matrices = 0,
        
        /// <summary>
        /// Index of uniform buffer object storing light informations.
        /// </summary>
        Lights = 1
    }
}