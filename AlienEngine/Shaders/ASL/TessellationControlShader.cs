#pragma warning disable

namespace AlienEngine.Shaders.ASL
{
    public abstract class TessellationControlShader : Shaders.ASL.ASLShader
    {
        [In]
        [BuiltIn]
        protected readonly int gl_PatchVerticesIn;
        
        [In]
        [BuiltIn]
        protected readonly int gl_PrimitiveID;
        
        [In] 
        [BuiltIn]
        protected readonly int gl_InvocationID;
        
        [Out]
        [BuiltIn]
        protected float[] gl_TessLevelOuter;
        
        [Out]
        [BuiltIn]
        protected float[] gl_TessLevelInner;
    }
}

#pragma warning restore