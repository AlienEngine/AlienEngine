#pragma warning disable

namespace AlienEngine.Shaders.ASL
{
    public abstract class TessellationEvaluationShader : Shaders.ASL.ASLShader
    {
        [In]
        [BuiltIn]
        protected readonly vec3 gl_TessCoord;

        [In]
        [BuiltIn]
        protected readonly int gl_PatchVerticesIn;

        [In]
        [BuiltIn]
        protected readonly int gl_PrimitiveID;

        [Out]
        [BuiltIn]
        protected vec4 gl_Position;

        [Out]
        [BuiltIn]
        protected float gl_PointSize;

        [Out]
        [BuiltIn]
        protected float[] gl_ClipDistance;
    }
}

#pragma warning restore