using System;
using AlienEngine.Core.Graphics.OpenGL.Windows;

namespace AlienEngine.Core.Graphics.OpenGL
{
    public static partial class GL
    {
        public static class PlatformExtensions
        {
            public static bool IsSupported(IntPtr device, string name)
            {
                if (Platform.IsWindows)
                    return WGL.IsExtensionSupported(device, name);

                return false;
            }

            public static readonly string CreateContextARB;
            public static readonly string CreateContextProfileARB;
            public static readonly string CreateContextRobustnessARB;

            static PlatformExtensions()
            {
                CreateContextARB = Platform.IsWindows ? WGL.ARB.CreateContext : "";
                CreateContextProfileARB = Platform.IsWindows ? WGL.ARB.CreateContextProfile : "";
                CreateContextRobustnessARB = Platform.IsWindows ? WGL.ARB.CreateContextRobustness : "";
            }
        }
        
        public static class EXT
        {
            public const string _422Pixels = "GL_EXT_422_pixels";
            public const string EglImageStorage = "GL_EXT_EGL_image_storage";
            public const string Abgr = "GL_EXT_abgr";
            public const string Bgra = "GL_EXT_bgra";
            public const string BindableUniform = "GL_EXT_bindable_uniform";
            public const string BlendColor = "GL_EXT_blend_color";
            public const string BlendEquationSeparate = "GL_EXT_blend_equation_separate";
            public const string BlendFuncSeparate = "GL_EXT_blend_func_separate";
            public const string BlendLogicOp = "GL_EXT_blend_logic_op";
            public const string BlendMinmax = "GL_EXT_blend_minmax";
            public const string BlendSubtract = "GL_EXT_blend_subtract";
            public const string ClipVolumeHint = "GL_EXT_clip_volume_hint";
            public const string Cmyka = "GL_EXT_cmyka";
            public const string ColorSubtable = "GL_EXT_color_subtable";
            public const string CompiledVertexArray = "GL_EXT_compiled_vertex_array";
            public const string Convolution = "GL_EXT_convolution";
            public const string CoordinateFrame = "GL_EXT_coordinate_frame";
            public const string CopyTexture = "GL_EXT_copy_texture";
            public const string CullVertex = "GL_EXT_cull_vertex";
            public const string DebugLabel = "GL_EXT_debug_label";
            public const string DebugMarker = "GL_EXT_debug_marker";
            public const string DepthBoundsTest = "GL_EXT_depth_bounds_test";
            public const string DirectStateAccess = "GL_EXT_direct_state_access";
            public const string DrawBuffers2 = "GL_EXT_draw_buffers2";
            public const string DrawInstanced = "GL_EXT_draw_instanced";
            public const string DrawRangeElements = "GL_EXT_draw_range_elements";
            public const string ExternalBuffer = "GL_EXT_external_buffer";
            public const string FogCoord = "GL_EXT_fog_coord";
            public const string FramebufferBlit = "GL_EXT_framebuffer_blit";
            public const string FramebufferMultisample = "GL_EXT_framebuffer_multisample";
            public const string FramebufferMultisampleBlitScaled = "GL_EXT_framebuffer_multisample_blit_scaled";
            public const string FramebufferObject = "GL_EXT_framebuffer_object";
            public const string FramebufferSRGB = "GL_EXT_framebuffer_sRGB";
            public const string GeometryShader4 = "GL_EXT_geometry_shader4";
            public const string GpuProgramParameters = "GL_EXT_gpu_program_parameters";
            public const string GpuShader4 = "GL_EXT_gpu_shader4";
            public const string Histogram = "GL_EXT_histogram";
            public const string IndexArrayFormats = "GL_EXT_index_array_formats";
            public const string IndexFunc = "GL_EXT_index_func";
            public const string IndexMaterial = "GL_EXT_index_material";
            public const string IndexTexture = "GL_EXT_index_texture";
            public const string LightTexture = "GL_EXT_light_texture";
            public const string MemoryObject = "GL_EXT_memory_object";
            public const string MemoryObjectFd = "GL_EXT_memory_object_fd";
            public const string MemoryObjectWin32 = "GL_EXT_memory_object_win32";
            public const string MiscAttribute = "GL_EXT_misc_attribute";
            public const string MultiDrawArrays = "GL_EXT_multi_draw_arrays";
            public const string Multisample = "GL_EXT_multisample";
            public const string PackedDepthStencil = "GL_EXT_packed_depth_stencil";
            public const string PackedFloat = "GL_EXT_packed_float";
            public const string PackedPixels = "GL_EXT_packed_pixels";
            public const string PalettedTexture = "GL_EXT_paletted_texture";
            public const string PixelBufferObject = "GL_EXT_pixel_buffer_object";
            public const string PixelTransform = "GL_EXT_pixel_transform";
            public const string PixelTransformColorTable = "GL_EXT_pixel_transform_color_table";
            public const string PointParameters = "GL_EXT_point_parameters";
            public const string PolygonOffset = "GL_EXT_polygon_offset";
            public const string PolygonOffsetClamp = "GL_EXT_polygon_offset_clamp";
            public const string PostDepthCoverage = "GL_EXT_post_depth_coverage";
            public const string ProvokingVertex = "GL_EXT_provoking_vertex";
            public const string RasterMultisample = "GL_EXT_raster_multisample";
            public const string RescaleNormal = "GL_EXT_rescale_normal";
            public const string SecondaryColor = "GL_EXT_secondary_color";
            public const string Semaphore = "GL_EXT_semaphore";
            public const string SemaphoreFd = "GL_EXT_semaphore_fd";
            public const string SemaphoreWin32 = "GL_EXT_semaphore_win32";
            public const string SeparateShaderObjects = "GL_EXT_separate_shader_objects";
            public const string SeparateSpecularColor = "GL_EXT_separate_specular_color";
            public const string ShaderFramebufferFetch = "GL_EXT_shader_framebuffer_fetch";
            public const string ShaderFramebufferFetchNonCoherent = "GL_EXT_shader_framebuffer_fetch_non_coherent";
            public const string ShaderImageLoadFormatted = "GL_EXT_shader_image_load_formatted";
            public const string ShaderImageLoadStore = "GL_EXT_shader_image_load_store";
            public const string ShaderIntegerMix = "GL_EXT_shader_integer_mix";
            public const string ShadowFuncs = "GL_EXT_shadow_funcs";
            public const string SharedTexturePalette = "GL_EXT_shared_texture_palette";
            public const string SparseTexture2 = "GL_EXT_sparse_texture2";
            public const string StencilClearTag = "GL_EXT_stencil_clear_tag";
            public const string StencilTwoSide = "GL_EXT_stencil_two_side";
            public const string StencilWrap = "GL_EXT_stencil_wrap";
            public const string Subtexture = "GL_EXT_subtexture";
            public const string Texture = "GL_EXT_texture";
            public const string Texture3D = "GL_EXT_texture3D";
            public const string TextureArray = "GL_EXT_texture_array";
            public const string TextureBufferObject = "GL_EXT_texture_buffer_object";
            public const string TextureCompressionLatc = "GL_EXT_texture_compression_latc";
            public const string TextureCompressionRgtc = "GL_EXT_texture_compression_rgtc";
            public const string TextureCompressionS3Tc = "GL_EXT_texture_compression_s3tc";
            public const string TextureCubeMap = "GL_EXT_texture_cube_map";
            public const string TextureEnvAdd = "GL_EXT_texture_env_add";
            public const string TextureEnvCombine = "GL_EXT_texture_env_combine";
            public const string TextureEnvDot3 = "GL_EXT_texture_env_dot3";
            public const string TextureFilterAnisotropic = "GL_EXT_texture_filter_anisotropic";
            public const string TextureFilterMinmax = "GL_EXT_texture_filter_minmax";
            public const string TextureInteger = "GL_EXT_texture_integer";
            public const string TextureLodBias = "GL_EXT_texture_lod_bias";
            public const string TextureMirrorClamp = "GL_EXT_texture_mirror_clamp";
            public const string TextureObject = "GL_EXT_texture_object";
            public const string TexturePerturbNormal = "GL_EXT_texture_perturb_normal";
            public const string TextureSRGB = "GL_EXT_texture_sRGB";
            public const string TextureSRGBDecode = "GL_EXT_texture_sRGB_decode";
            public const string TextureSharedExponent = "GL_EXT_texture_shared_exponent";
            public const string TextureSnorm = "GL_EXT_texture_snorm";
            public const string TextureSwizzle = "GL_EXT_texture_swizzle";
            public const string TimerQuery = "GL_EXT_timer_query";
            public const string TransformFeedback = "GL_EXT_transform_feedback";
            public const string VertexArray = "GL_EXT_vertex_array";
            public const string VertexArrayBgra = "GL_EXT_vertex_array_bgra";
            public const string VertexAttrib64Bit = "GL_EXT_vertex_attrib_64bit";
            public const string VertexShader = "GL_EXT_vertex_shader";
            public const string VertexWeighting = "GL_EXT_vertex_weighting";
            public const string Win32KeyedMutex = "GL_EXT_win32_keyed_mutex";
            public const string WindowRectangles = "GL_EXT_window_rectangles";
            public const string X11SyncObject = "GL_EXT_x11_sync_object";
        }
    }
}