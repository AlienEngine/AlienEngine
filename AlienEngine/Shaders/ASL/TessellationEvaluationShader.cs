#pragma warning disable

namespace AlienEngine.ASL
{
    public abstract class TessellationEvaluationShader : ASLShader
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