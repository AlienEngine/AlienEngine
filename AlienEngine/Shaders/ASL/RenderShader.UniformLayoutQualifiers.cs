namespace AlienEngine.Shaders.ASL
{
    public abstract partial class RenderShader
    {
        public enum UniformLayout : uint
        {
            Shared,
            Packed,
            STD140,
            RowMajor,
            ColumnMajor
        };
    }
}
