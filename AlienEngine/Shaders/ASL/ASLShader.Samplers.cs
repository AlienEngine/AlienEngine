namespace AlienEngine.Shaders.ASL
{
    public abstract partial class ASLShader
    {
        // Floating Point Sampler Types

        [BuiltIn]
        protected struct sampler1D { }
        [BuiltIn]
        protected struct sampler2D { }
        [BuiltIn]
        protected struct sampler3D { }
        [BuiltIn]
        protected struct sampler4D { }
        [BuiltIn]
        protected struct samplerCube { }
        [BuiltIn]
        protected struct samplerCubeShadow { }
        [BuiltIn]
        protected struct sampler2DRect { }
        [BuiltIn]
        protected struct sampler1DShadow { }
        [BuiltIn]
        protected struct sampler2DShadow { }
        [BuiltIn]
        protected struct sampler2DRectShadow { }
        [BuiltIn]
        protected struct sampler1DArray { }
        [BuiltIn]
        protected struct sampler2DArray { }
        [BuiltIn]
        protected struct sampler1DArrayShadow { }
        [BuiltIn]
        protected struct sampler2DArrayShadow { }
        [BuiltIn]
        protected struct samplerBuffer { }
        [BuiltIn]
        protected struct sampler2DMS { }
        [BuiltIn]
        protected struct sampler2DMSArray { }

        // Integer Sampler Types

        [BuiltIn]
        protected struct isampler1D { }
        [BuiltIn]
        protected struct isampler2D { }
        [BuiltIn]
        protected struct isampler3D { }
        [BuiltIn]
        protected struct isampler4D { }
        [BuiltIn]
        protected struct isamplerCube { }
        [BuiltIn]
        protected struct isampler2DRect { }
        [BuiltIn]
        protected struct isampler1DArray { }
        [BuiltIn]
        protected struct isampler2DArray { }
        [BuiltIn]
        protected struct isamplerBuffer { }
        [BuiltIn]
        protected struct isampler2DMS { }
        [BuiltIn]
        protected struct isampler2DMSArray { }

        // Unsigned Integer Sampler Types

        [BuiltIn]
        protected struct usampler1D { }
        [BuiltIn]
        protected struct usampler2D { }
        [BuiltIn]
        protected struct usampler3D { }
        [BuiltIn]
        protected struct usampler4D { }
        [BuiltIn]
        protected struct usamplerCube { }
        [BuiltIn]
        protected struct usampler2DRect { }
        [BuiltIn]
        protected struct usampler1DArray { }
        [BuiltIn]
        protected struct usampler2DArray { }
        [BuiltIn]
        protected struct usamplerBuffer { }
        [BuiltIn]
        protected struct usampler2DMS { }
        [BuiltIn]
        protected struct usampler2DMSArray { }
    }
}
