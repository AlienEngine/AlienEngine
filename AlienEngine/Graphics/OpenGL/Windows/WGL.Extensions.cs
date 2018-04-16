namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    // TODO: Register all WGL extemsions from the Khronos registry.
    public static partial class WGL
    {
        public static class ARB
        {
            public const string PixelFormat = "WGL_ARB_pixel_format";

            public const string Multisample = "WGL_ARB_multisample";

            public const string PBuffer = "WGL_ARB_pbuffer";
            
            public const string FramebufferSRGB = "WGL_ARB_framebuffer_sRGB";

            public const string CreateContext = "WGL_ARB_create_context";

            public const string CreateContextProfile = "WGL_ARB_create_context_profile";

            public const string CreateContextRobustness = "WGL_ARB_create_context_robustness";
        }
        
        public static class EXT
        {
            public const string PixelFormat = "WGL_EXT_pixel_format";
            
            public const string SwapControl = "WGL_EXT_swap_control";

            public const string SwapControlTear = "WGL_EXT_swap_control_tear";
            
            public const string Multisample = "WGL_EXT_multisample";

            public const string PBuffer = "WGL_EXT_pbuffer";

            public const string FramebufferSRGB = "WGL_EXT_framebuffer_sRGB";

            public const string CreateContextESProfile = "WGL_EXT_create_context_es_profile";
            
            public const string CreateContextES2Profile = "WGL_EXT_create_context_es2_profile";
        }
    }
}