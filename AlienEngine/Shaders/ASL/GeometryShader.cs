using System;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class GeometryShader : RenderShader
    {
        [In]
        [BuiltIn]
        protected readonly int gl_PrimitiveIDIn;

        [In]
        [BuiltIn]
        protected readonly int gl_InvocationID;

        [BuiltIn]
        protected struct gl_Vertex
        {
            public vec4 gl_Position;
            public float gl_PointSize;
            public float[] gl_ClipDistance;
        }

        [In]
        [BuiltIn]
        protected gl_Vertex[] gl_in;

        [Out]
        [BuiltIn]
        protected vec4 gl_Position;

        [Out]
        [BuiltIn]
        protected float gl_PointSize;

        [Out]
        [BuiltIn]
        protected float[] gl_ClipDistance;

        [Out]
        [BuiltIn]
        protected int gl_PrimitiveID;

        [Out]
        [BuiltIn]
        protected int gl_Layer;

        [Out]
        [BuiltIn]
        protected int gl_ViewportIndex;

        [BuiltIn]
        protected void EmitVertex() { throw new NotImplementedException(); }

        [BuiltIn]
        protected void EndPrimitive() { throw new NotImplementedException(); }
    }
}
