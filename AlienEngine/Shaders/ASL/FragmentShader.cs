using System;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class FragmentShader : RenderShader
    {
        [In]
        [BuiltIn]
        protected readonly int gl_SampleID;

        [In]
        [BuiltIn]
        protected readonly vec2 gl_SamplePosition;

        [In]
        [BuiltIn]
        protected readonly int[] gl_SampleMaskIn;

        [In]
        [BuiltIn]
        protected readonly int gl_Layer;

        [In]
        [BuiltIn]
        protected readonly int gl_ViewportIndex;

        [In]
        [BuiltIn]
        protected readonly vec4 gl_FragCoord;

        [In]
        [BuiltIn]
        protected readonly bool gl_FrontFacing;

        [In]
        [BuiltIn]
        protected readonly vec2 gl_PointCoord;

        [In]
        [BuiltIn]
        protected readonly float[] gl_ClipDistance;

        [In]
        [BuiltIn]
        protected readonly int gl_PrimitiveID;

        [Out]
        [BuiltIn]
        protected float gl_FragDepth;

        [Out]
        [BuiltIn]
        protected int[] gl_SampleMask;

        [Out]
        [BuiltIn]
        protected vec4 gl_FragColor;

        [BuiltIn]
        protected float dFdx(float p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec2 dFdx(vec2 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec3 dFdx(vec3 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 dFdx(vec4 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float dFdy(float p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec2 dFdy(vec2 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec3 dFdy(vec3 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 dFdy(vec4 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float fwidth(float p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec2 fwidth(vec2 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec3 fwidth(vec3 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 fwidth(vec4 p) { throw new NotImplementedException(); }
    }
}
