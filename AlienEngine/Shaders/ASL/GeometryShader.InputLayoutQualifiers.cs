namespace AlienEngine.Shaders.ASL
{
    public abstract partial class GeometryShader
    {
        public enum InputLayout
        {
            Points = 1,
            Lines = 2,
            LinesAdjacency = 4,
            Triangles = 3,
            TrianglesAdjacency = 6
        };
    }
}
