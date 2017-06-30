#pragma warning disable

namespace AlienEngine.ASL
{
    public abstract partial class VertexShader : RenderShader
    {
        [In]
        [BuiltIn]
        protected readonly int gl_VertexId;

        [In]
        [BuiltIn]
        protected readonly int gl_InstanceId;

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