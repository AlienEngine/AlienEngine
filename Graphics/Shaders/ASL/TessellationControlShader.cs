#pragma warning disable

namespace AlienEngine.ASL
{
    public abstract class TessellationControlShader : ASLShader
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