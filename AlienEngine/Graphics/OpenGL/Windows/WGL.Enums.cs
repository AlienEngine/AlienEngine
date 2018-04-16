using System;

namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    public static partial class WGL
    {
        /// <summary>
        /// Specifies the properties of the layer plane. Used as type for <see cref="LayerPlaneDescriptor.dwFlags"/>.
        /// </summary>
        [Flags]
        public enum LayerPlaneDescriptorFlags : uint
        {
            /// <summary>
            /// The layer plane is double-buffered. A layer plane can be double-buffered even when the main plane is single-buffered and vice versa.
            /// </summary>
            DoubleBuffer = 0x00000001,

            /// <summary>
            /// The layer plane is stereoscopic. A layer plane can be stereoscopic even when the main plane is monoscopic and vice versa.
            /// </summary>
            Stereo = 0x00000002,

            /// <summary>
            /// The layer plane supports GDI drawing. The current implementation of OpenGL doesn't support this flag.
            /// </summary>
            SupportGDI = 0x00000010,

            /// <summary>
            /// The layer plane supports OpenGL drawing.
            /// </summary>
            SupportOpenGL = 0x00000020,

            /// <summary>
            /// The layer plane shares the depth buffer with the main plane.
            /// </summary>
            ShareDepth = 0x00000040,

            /// <summary>
            /// The layer plane shares the stencil buffer with the main plane.
            /// </summary>
            ShareStencil = 0x00000080,

            /// <summary>
            /// The layer plane shares the accumulation buffer with the main plane.
            /// </summary>
            ShareAccum = 0x00000100,

            /// <summary>
            /// In a double-buffered layer plane, swapping the color buffer exchanges the front buffer and back buffer contents. The back buffer
            /// then contains the contents of the front buffer before the swap. This flag is a hint only and might not be provided by a driver.
            /// </summary>
            SwapExchange = 0x00000200,

            /// <summary>
            /// In a double-buffered layer plane, swapping the color buffer copies the back buffer contents to the front buffer. The swap does
            /// not affect the back buffer contents. This flag is a hint only and might not be provided by a driver.
            /// </summary>
            SwapCopy = 0x00000400,

            /// <summary>
            /// The <see cref="LayerPlaneDescriptor.crTransparent">crTransparent</see> member of the <see cref="LayerPlaneDescriptor"/> structure
            /// contains a transparent color or index value that enables underlying layers to show through this layer.
            /// All layer planes, except the lowest-numbered underlay layer, have a transparent color or index.
            /// </summary>
            Transparent = 0x00001000
        }

        /// <summary>
        /// Specifies the properties of the layer plane. Used as type for <see cref="PixelFormatDescriptor.dwFlags"/>.
        /// </summary>
        [Flags]
        public enum PixelFormatDescriptorFlags : uint
        {
            /// <summary>
            /// The layer plane is double-buffered. A layer plane can be double-buffered even when the main plane is single-buffered and vice versa.
            /// </summary>
            DoubleBuffer = 0x00000001,

            /// <summary>
            /// The layer plane is stereoscopic. A layer plane can be stereoscopic even when the main plane is monoscopic and vice versa.
            /// </summary>
            Stereo = 0x00000002,

            /// <summary>
            /// The layer plane can draw to a window or device surface.
            /// </summary>
            DrawToWindow = 0x00000004,

            /// <summary>
            /// The layer plane can draw to a memory bitmap.
            /// </summary>
            DrawToBitmap = 0x00000008,

            /// <summary>
            /// The layer plane supports GDI drawing. The current implementation of OpenGL doesn't support this flag.
            /// </summary>
            SupportGDI = 0x00000010,

            /// <summary>
            /// The layer plane supports OpenGL drawing.
            /// </summary>
            SupportOpenGL = 0x00000020,

            /// <summary>
            /// The pixel format is supported by the GDI software implementation, which is also known as the generic implementation.
            /// If this bit is clear, the pixel format is supported by a device driver or hardware.
            /// </summary>
            GenericFormat = 0x00000040,

            /// <summary>
            /// The layer plane uses RGBA pixels on a palette-managed device. A logical palette is required to achieve the best results for
            /// this pixel type. Colors in the palette should be specified according to the values of the cRedBits, cRedShift, cGreenBits,
            /// cGreenShift, cBluebits, and cBlueShift members. The palette should be created and realized in the device context before
            /// calling wglMakeCurrent.
            /// </summary>
            NeedPalette = 0x00000080,

            /// <summary>
            /// Defined in the pixel format descriptors of hardware that supports one hardware palette in 256-color mode only. For such
            /// systems to use hardware acceleration, the hardware palette must be in a fixed order (for example, 3-3-2) when in RGBA
            /// mode or must match the logical palette when in color-index mode.
            /// When this flag is set, you must call SetSystemPaletteUse in your program to force a one-to-one mapping of the logical
            /// palette and the system palette. If your OpenGL hardware supports multiple hardware palettes and the device driver can
            /// allocate spare hardware palettes for OpenGL, this flag is typically clear.
            /// </summary>
            /// <remarks>
            /// This flag is not set in the generic pixel formats.
            /// </remarks>
            NeedSystemPalette = 0x00000100,

            /// <summary>
            /// In a double-buffered layer plane, swapping the color buffer exchanges the front buffer and back buffer contents. The back buffer
            /// then contains the contents of the front buffer before the swap. This flag is a hint only and might not be provided by a driver.
            /// </summary>
            SwapExchange = 0x00000200,

            /// <summary>
            /// In a double-buffered layer plane, swapping the color buffer copies the back buffer contents to the front buffer. The swap does
            /// not affect the back buffer contents. This flag is a hint only and might not be provided by a driver.
            /// </summary>
            SwapCopy = 0x00000400,

            /// <summary>
            /// Indicates whether a device can swap individual layer planes with pixel formats that include double-buffered
            /// overlay or underlay planes. Otherwise all layer planes are swapped together as a group. When this flag is set,
            /// wglSwapLayerBuffers is supported.
            /// </summary>
            SwapLayerBuffer = 0x00000800,

            /// <summary>
            /// The pixel format is supported by a device driver that accelerates the generic implementation. If this flag is clear
            /// and the PFD_GENERIC_FORMAT flag is set, the pixel format is supported by the generic implementation only.
            /// </summary>
            GenericAccelerated = 0x00001000,

            SupportDirectDraw = 0x00002000,

            Direct3DAccelerated = 0x00004000,

            SupportComposition = 0x00008000,

            /// <summary>
            /// The requested pixel format can either have or not have a depth buffer. To select a pixel format without
            /// a depth buffer, you must specify this flag. The requested pixel format can be with or without a depth
            /// buffer. Otherwise, only pixel formats with a depth buffer are considered.
            /// </summary>
            /// <remarks>
            /// This value can be used only with <see cref="ChoosePixelFormat(IntPtr, ref PixelFormatDescriptor)"/>.
            /// </remarks>
            DepthDontCare = 0x20000000,

            /// <summary>
            /// The requested pixel format can be either single- or double-buffered.
            /// </summary>
            /// <remarks>
            /// This value can be used only with <see cref="ChoosePixelFormat(IntPtr, ref PixelFormatDescriptor)"/>.
            /// </remarks>
            DoubleBufferContCare = 0x40000000,

            /// <summary>
            /// The requested pixel format can be either monoscopic or stereoscopic.
            /// </summary>
            /// <remarks>
            /// This value can be used only with <see cref="ChoosePixelFormat(IntPtr, ref PixelFormatDescriptor)"/>.
            /// </remarks>
            StereoDontCare = 0x80000000
        }

        /// <summary>
        /// Specifies the type of pixel data. Used as type for <see cref="PixelFormatDescriptor.iPixelType"/>.
        /// </summary>
        public enum DescriptorPixelType : byte
        {
            /// <summary>
            /// RGBA pixels. Each pixel has four components: red, green, blue, and alpha.
            /// </summary>
            RGBA = 0,

            /// <summary>
            /// Color-index pixels. Each pixel uses a color-index value.
            /// </summary>
            [Obsolete("Palettes and indexed colors aren't supported in the OpenGL core profile anymore.")]
            ColorIndex = 1
        }

        /// <summary>
        /// Additional error codes (see <b>GetLastError()</b>) returned be WGL-functions.
        /// </summary>
        public enum WGLError
        {
            /// <summary>
            /// Pixel type don't match.
            /// </summary>
            InvalidPixelTypeARB = 0x2043,

            /// <summary>
            /// Device contexts are not compatible.
            /// </summary>
            IncompatibleDeviceContextsARB = 0x2054,

            /// <summary>
            /// Invalid version number.
            /// </summary>
            InvalidVersionARB = 0x2095,

            /// <summary>
            /// Invalid profile name.
            /// </summary>
            InvalidProfileARB = 0x2096,
        }

        /// <summary>
        /// Specifying the format to use in display lists.
        /// </summary>
        [Obsolete("Display list aren't supported in the OpenGL core profile anymore.")]
        public enum WGLFont : uint
        {
            /// <summary>
            /// Format of the display list will be lines.
            /// </summary>
            Lines = 0,

            /// <summary>
            /// Format of the display list will be polygons.
            /// </summary>
            Polygons = 1
        }

        /// <summary>
        /// Bitmask specifying the layer planes for swapping operations.
        /// </summary>
        [Flags]
        public enum PixelFormatDescriptorLayerType : uint
        {
            /// <summary>
            /// Main plane.
            /// </summary>
            MainPlane = 0x00000001,

            /// <summary>
            /// 1. Overlay plane.
            /// </summary>
            Overlay1 = 0x00000002,

            /// <summary>
            /// 2. Overlay plane.
            /// </summary>
            Overlay2 = 0x00000004,

            /// <summary>
            /// 3. Overlay plane.
            /// </summary>
            Overlay3 = 0x00000008,

            /// <summary>
            /// 4. Overlay plane.
            /// </summary>
            Overlay4 = 0x00000010,

            /// <summary>
            /// 5. Overlay plane.
            /// </summary>
            Overlay5 = 0x00000020,

            /// <summary>
            /// 6. Overlay plane.
            /// </summary>
            Overlay6 = 0x00000040,

            /// <summary>
            /// 7. Overlay plane.
            /// </summary>
            Overlay7 = 0x00000080,

            /// <summary>
            /// 8. Overlay plane.
            /// </summary>
            Overlay8 = 0x00000100,

            /// <summary>
            /// 9. Overlay plane.
            /// </summary>
            Overlay9 = 0x00000200,

            /// <summary>
            /// 10. Overlay plane.
            /// </summary>
            Overlay10 = 0x00000400,

            /// <summary>
            /// 11. Overlay plane.
            /// </summary>
            Overlay11 = 0x00000800,

            /// <summary>
            /// 12. Overlay plane.
            /// </summary>
            Overlay12 = 0x00001000,

            /// <summary>
            /// 13. Overlay plane.
            /// </summary>
            Overlay13 = 0x00002000,

            /// <summary>
            /// 14. Overlay plane.
            /// </summary>
            Overlay14 = 0x00004000,

            /// <summary>
            /// 15. Overlay plane.
            /// </summary>
            Overlay15 = 0x00008000,

            /// <summary>
            /// 1. Underlay plane.
            /// </summary>
            Underlay1 = 0x00010000,

            /// <summary>
            /// 2. Underlay plane.
            /// </summary>
            Underlay2 = 0x00020000,

            /// <summary>
            /// 3. Underlay plane.
            /// </summary>
            Underlay3 = 0x00040000,

            /// <summary>
            /// 4. Underlay plane.
            /// </summary>
            Underlay4 = 0x00080000,

            /// <summary>
            /// 5. Underlay plane.
            /// </summary>
            Underlay5 = 0x00100000,

            /// <summary>
            /// 6. Underlay plane.
            /// </summary>
            Underlay6 = 0x00200000,

            /// <summary>
            /// 7. Underlay plane.
            /// </summary>
            Underlay7 = 0x00400000,

            /// <summary>
            /// 8. Underlay plane.
            /// </summary>
            Underlay8 = 0x00800000,

            /// <summary>
            /// 9. Underlay plane.
            /// </summary>
            Underlay9 = 0x01000000,

            /// <summary>
            /// 10. Underlay plane.
            /// </summary>
            Underlay10 = 0x02000000,

            /// <summary>
            /// 11. Underlay plane.
            /// </summary>
            Underlay11 = 0x04000000,

            /// <summary>
            /// 12. Underlay plane.
            /// </summary>
            Underlay12 = 0x08000000,

            /// <summary>
            /// 13. Underlay plane.
            /// </summary>
            Underlay13 = 0x10000000,

            /// <summary>
            /// 14. Underlay plane.
            /// </summary>
            Underlay14 = 0x20000000,

            /// <summary>
            /// 15. Underlay plane.
            /// </summary>
            Underlay15 = 0x40000000
        }

        /// <summary>
        /// Specifies the type of driver support.
        /// </summary>
        public enum AccelerationModeARB : int
        {
            /// <summary>
            /// Software renderer.
            /// </summary>
            NoAccelerationARB = 0x2025,

            /// <summary>
            /// Software renderer supported by a MCD driver.
            /// </summary>
            GenericAccelerationARB = 0x2026,

            /// <summary>
            /// Hardware renderer via an ICD driver.
            /// </summary>
            FullAccelerationARB = 0x2027,
        }

        /// <summary>
        /// Specifies a color buffer. Used be <see cref="WGL.BindTexImageARB"/> and <see cref="WGL.ReleaseTexImageARB"/>.
        /// </summary>
        public enum BufferARB : int
        {
            /// <summary>
            /// Front left.
            /// </summary>
            FrontLeftARB = 0x2083,

            /// <summary>
            /// Front right.
            /// </summary>
            FrontRightARB = 0x2084,

            /// <summary>
            /// Back left.
            /// </summary>
            BackLeftARB = 0x2085,

            /// <summary>
            /// back right.
            /// </summary>
            BackRightARB = 0x2086,

            /// <summary>
            /// Auxilary buffer 0.
            /// </summary>
            Aux0ARB = 0x2087,

            /// <summary>
            /// Auxilary buffer 1.
            /// </summary>
            Aux1ARB = 0x2088,

            /// <summary>
            /// Auxilary buffer 2.
            /// </summary>
            Aux2ARB = 0x2089,

            /// <summary>
            /// Auxilary buffer 3.
            /// </summary>
            Aux3ARB = 0x208A,

            /// <summary>
            /// Auxilary buffer 4.
            /// </summary>
            Aux4ARB = 0x208B,

            /// <summary>
            /// Auxilary buffer 5.
            /// </summary>
            Aux5ARB = 0x208C,

            /// <summary>
            /// Auxilary buffer 6.
            /// </summary>
            Aux6ARB = 0x208D,

            /// <summary>
            /// Auxilary buffer 7.
            /// </summary>
            Aux7ARB = 0x208E,

            /// <summary>
            /// Auxilary buffer 8.
            /// </summary>
            Aux8ARB = 0x208F,

            /// <summary>
            /// Auxilary buffer 9.
            /// </summary>
            Aux9ARB = 0x2090,

            #region WGL_NV_render_depth_texture

            /// <summary>
            /// Depth buffer.
            /// </summary>
            DepthComponentNv = 0x20A7,

            #endregion
        }

        /// <summary>
        /// Defines buffers.
        /// </summary>
        [Flags]
        public enum WGLBufferMaskARB : uint
        {
            /// <summary>
            /// Front color buffer.
            /// </summary>
            FrontColorBufferBitARB = 0x00000001,

            /// <summary>
            /// Back color buffer.
            /// </summary>
            BackColorBufferBitARB = 0x00000002,

            /// <summary>
            /// Depth buffer.
            /// </summary>
            DepthBufferBitARB = 0x00000004,

            /// <summary>
            /// Stencil buffer.
            /// </summary>
            StencilBufferBitARB = 0x00000008,
        }

        /// <summary>
        /// Specifies the attributes available for context creation with <see cref="O:Win32.WGL.WGL.CreateContextAttribsARB">WGL.CreateContextAttribsARB</see>.
        /// </summary>
        public enum ContextAttributeARB : int
        {
            #region WGL_ARB_create_context(-profile)

            /// <summary>
            /// Requests the major version. Default is 1.
            /// </summary>
            ContextMajorVersionARB = 0x2091,

            /// <summary>
            /// Requests the minor version. Default is 0.
            /// </summary>
            ContextMinorVersionARB = 0x2092,

            /// <summary>
            /// Specifies the layer plane that the rendering context is to be bound to. See <see cref="WGL.CreateLayerContext"/>.
            /// </summary>
            ContextLayerPlaneARB = 0x2093,

            /// <summary>
            /// Requests context abilities, see <see cref="WGLContextFlagsARB"/>. Default is 0.
            /// </summary>
            ContextFlagsARB = 0x2094,

            /// <summary>
            /// Requests the profile (core or compatibility). Default is <see cref="WGL.ContextProfileMaskARB.ContextCoreProfileBitARB"/>.
            /// </summary>
            ContextProfileMaskARB = 0x9126,

            #endregion

            #region WGL_ARB_create_context_robustness

            /// <summary>
            /// Set the reset notification strategy for the rendering context. Default is <see cref="WGLContextResetNotificationStrategyARB.NoResetNotificationARB"/>.
            /// </summary>
            ContextResetNotificationStrategyARB = 0x8256,

            #endregion

            #region WGL_ARB_context_flush_control

            /// <summary>
            /// Requests the context release behaviour. Default is <see cref="WGLContextReleaseBehaviour.FlushARB"/>. (Available since OpenGL 4.5.)
            /// </summary>
            ContextReleaseBehaviorARB = 0x2097,

            #endregion
        }

        /// <summary>
        /// Bitmask for the values of <see cref="ContextAttributeARB.ContextFlagsARB"/> at <see cref="O:Win32.WGL.WGL.CreateContextAttribsARB">WGL.CreateContextAttribsARB</see>.
        /// </summary>
        [Flags]
        public enum WGLContextFlagsARB : int
        {
            /// <summary>
            /// Requests a debug context.
            /// </summary>
            ContextDebugBitARB = 0x0001,

            /// <summary>
            /// Requests a forward compatible context.
            /// </summary>
            ContextForwardCompatibleBitARB = 0x0002,

            /// <summary>
            /// Requests a context supporting robust buffer access.
            /// </summary>
            ContextRobustAccessBitARB = 0x00000004,

            /// <summary>
            /// Requests isolation support for graphics resets.
            /// </summary>
            ContextResetIsolationBitARB = 0x00000008,
        }

        /// <summary>
        /// Values of <see cref="ContextAttributeARB.ContextProfileMaskARB"/> at <see cref="O:Win32.WGL.WGL.CreateContextAttribsARB">WGL.CreateContextAttribsARB</see>.
        /// </summary>
        public enum ContextProfileMaskARB : int
        {
            /// <summary>
            /// Requests a core-profile.
            /// </summary>
            ContextCoreProfileBitARB = 0x00000001,

            /// <summary>
            /// Requests a compalibility-profile.
            /// </summary>
            ContextCompatibilityProfileBitARB = 0x00000002,

            /// <summary>
            /// Requests a OpenGL ES compatible context.
            /// </summary>
            ContextEsProfileBitEXT = 0x00000004,

            /// <summary>
            /// Requests a OpenGL ES compatible context.
            /// </summary>
            ContextEs2ProfileBitEXT = 0x00000004,
        }

        /// <summary>
        /// Values for <see cref="ContextAttributeARB.ContextReleaseBehaviorARB"/>.
        /// </summary>
        public enum WGLContextReleaseBehaviour : int
        {
            /// <summary>
            /// No flush on context release.
            /// </summary>
            NoneARB = 0x0000,

            /// <summary>
            /// Implicit flush all pending commands of the context before releasing it.
            /// </summary>
            FlushARB = 0x2098,
        }

        /// <summary>
        /// Values of <see cref="ContextAttributeARB.ContextResetNotificationStrategyARB"/> at <see cref="O:Win32.WGL.WGL.CreateContextAttribsARB">WGL.CreateContextAttribsARB</see>.
        /// </summary>
        public enum WGLContextResetNotificationStrategyARB : int
        {
            /// <summary>
            /// Loss of all context state on graphics resets, requiring the recreation of all associated objects.
            /// </summary>
            LoseContextOnResetARB = 0x8252,

            /// <summary>
            /// No notifications of reset events.
            /// </summary>
            NoResetNotificationARB = 0x8261,
        }

        /// <summary>
        /// Specifies the depth texture format. Used as value for <see cref="PbufferAttributeARB.DepthTextureFormatNv"/>
        /// </summary>
        public enum DepthTextureFormatNv : int
        {
            /// <summary>
            /// Depth texture.
            /// </summary>
            TextureDepthComponentNv = 0x20A6,

            /// <summary>
            /// No texture.
            /// </summary>
            NoTextureARB = 0x2077,
        }

        /// <summary>
        /// Specifies attributes which can be used to create pbuffers, and to set or query attributes of/from pbuffers.
        /// </summary>
        public enum PbufferAttributeARB : int
        {
            #region WGL_ARB_pbuffer

            /// <summary>
            /// If set on pbuffer creation, a smaller pbuffer will be created, if the specified size is not possible.
            /// </summary>
            PbufferLargestARB = 0x2033,

            /// <summary>
            /// Query the width of the pbuffers.
            /// </summary>
            PbufferWidthARB = 0x2034,

            /// <summary>
            /// Query the height of the pbuffers.
            /// </summary>
            PbufferHeightARB = 0x2035,

            /// <summary>
            /// Check if the pbuffer is lost.
            /// </summary>
            PbufferLostARB = 0x2036,

            #endregion

            #region WGL_ARB_render_texture

            /// <summary>
            /// Specifies the texture format. Values of type <see cref="WGLTextureFormatARB"/>.
            /// </summary>
            TextureFormatARB = 0x2072,

            /// <summary>
            /// Specifies the texture target. Values of type <see cref="WGLTextureTargetARB"/>.
            /// </summary>
            TextureTargetARB = 0x2073,

            /// <summary>
            /// Specifies that mipmap shall be supported and storage is allocated. Default is <b>false</b>.
            /// </summary>
            MipmapTextureARB = 0x2074,

            /// <summary>
            /// Sets or queries the mipmap level which should be/is rendered to.
            /// </summary>
            MipmapLevelARB = 0x207B,

            /// <summary>
            /// Sets or queries the cube map face. Values of type <see cref="WGLTextureCubeMapFaceARB"/>.
            /// </summary>
            CubeMapFaceARB = 0x207C,

            #endregion

            #region WGL_NV_render_depth_texture

            /// <summary>
            /// Specifies the depth texture format. Values of type <see cref="WGL.DepthTextureFormatNv"/>.
            /// </summary>
            DepthTextureFormatNv = 0x20A5,

            #endregion
        }

        /// <summary>
        /// Specifies attributes for pixel formats. Used by <see cref="O:Win32.WGL.WGL.ChoosePixelFormatARB">WGL.ChoosePixelFormatARB</see> and
        /// <see cref="O:Win32.WGL.WGL.GetPixelFormatAttribivARB">WGL.GetPixelFormatAttribivARB</see>.
        /// </summary>
        public enum PixelFormatAttributeARB : int
        {
            #region WGL_ARB_pixel_format

            /// <summary>
            /// The number of pixel formats for the device context.
            /// </summary>
            NumberPixelFormatsARB = 0x2000,

            /// <summary>
            /// <b>true</b> if the pixel format can be used with a window.
            /// </summary>
            DrawToWindowARB = 0x2001,

            /// <summary>
            /// <b>true</b> if the pixel format can be used with a memory bitmap.
            /// </summary>
            DrawToBitmapARB = 0x2002,

            /// <summary>
            /// A <see cref="AccelerationModeARB"/> indicating whether the pixel format is supported by the driver.
            /// </summary>
            AccelerationARB = 0x2003,

            /// <summary>
            /// A logical palette is required to achieve the best results for this pixel format. Paletted colors are not supported in OpenGL core profile.
            /// </summary>
            NeedPaletteARB = 0x2004,

            /// <summary>
            /// The hardware supports one hardware palette in 256-color mode only. Paletted colors are not supported in OpenGL core profile.
            /// </summary>
            NeedSystemPaletteARB = 0x2005,

            /// <summary>
            /// <b>true</b> if the pixel format supports swapping layer planes independently of the main planes.
            /// </summary>
            SwapLayerBuffersARB = 0x2006,

            /// <summary>
            /// A <see cref="WGLSwapMethodeARB"/> indicating how back and front buffer are swapped.
            /// </summary>
            SwapMethodARB = 0x2007,

            /// <summary>
            /// The number of overlay planes.
            /// </summary>
            NumberOverlaysARB = 0x2008,

            /// <summary>
            /// The number of underlay planes.
            /// </summary>
            NumberUnderlaysARB = 0x2009,

            /// <summary>
            /// <b>true</b> if transparency is supported.
            /// </summary>
            TransparentARB = 0x200A,

            /// <summary>
            /// The transparent red color value.
            /// </summary>
            TransparentRedValueARB = 0x2037,

            /// <summary>
            /// The transparent green color value.
            /// </summary>
            TransparentGreenValueARB = 0x2038,

            /// <summary>
            /// The transparent blue color value.
            /// </summary>
            TransparentBlueValueARB = 0x2039,

            /// <summary>
            /// The transparent alpha color value.
            /// </summary>
            TransparentAlphaValueARB = 0x203A,

            /// <summary>
            /// The transparent color index value.
            /// </summary>
            TransparentIndexValueARB = 0x203B,

            /// <summary>
            /// <b>true</b> if the layer plane shares the depth buffer with the main planes.
            /// </summary>
            ShareDepthARB = 0x200C,

            /// <summary>
            /// <b>true</b> if the layer plane shares the stencil buffer with the main planes.
            /// </summary>
            ShareStencilARB = 0x200D,

            /// <summary>
            /// <b>true</b> if the layer plane shares the accumulation buffer with the main planes. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            ShareAccumARB = 0x200E,

            /// <summary>
            /// <b>true</b> if GDI rendering is supported. GDI rendering does not support the OpenGL core profile.
            /// </summary>
            SupportGDIARB = 0x200F,

            /// <summary>
            /// <b>true</b> if OpenGL is supported.
            /// </summary>
            SupportOpenglARB = 0x2010,

            /// <summary>
            /// <b>true</b> if the color buffer has back/front pairs.
            /// </summary>
            DoubleBufferARB = 0x2011,

            /// <summary>
            /// <b>true</b> if the color buffer has left/right pairs.
            /// </summary>
            StereoARB = 0x2012,

            /// <summary>
            /// A <see cref="WGL.PixelTypeARB"/> specifying the type of pixel data.
            /// </summary>
            PixelTypeARB = 0x2013,

            /// <summary>
            /// The number of color bitplanes in each color buffer.
            /// </summary>
            ColorBitsARB = 0x2014,

            /// <summary>
            /// The number of red bitplanes in each RGBA color buffer.
            /// </summary>
            RedBitsARB = 0x2015,

            /// <summary>
            /// The shift count for red bitplanes in each RGBA color buffer.
            /// </summary>
            RedShiftARB = 0x2016,

            /// <summary>
            /// The number of green bitplanes in each RGBA color buffer.
            /// </summary>
            GreenBitsARB = 0x2017,

            /// <summary>
            /// The shift count for green bitplanes in each RGBA color buffer.
            /// </summary>
            GreenShiftARB = 0x2018,

            /// <summary>
            /// The number of blue bitplanes in each RGBA color buffer.
            /// </summary>
            BlueBitsARB = 0x2019,

            /// <summary>
            /// The shift count for blue bitplanes in each RGBA color buffer.
            /// </summary>
            BlueShiftARB = 0x201A,

            /// <summary>
            /// The number of alpha bitplanes in each RGBA color buffer.
            /// </summary>
            AlphaBitsARB = 0x201B,

            /// <summary>
            /// The shift count for alpha bitplanes in each RGBA color buffer.
            /// </summary>
            AlphaShiftARB = 0x201C,

            /// <summary>
            /// The total number of bitplanes in the accumulation buffer. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            AccumBitsARB = 0x201D,

            /// <summary>
            /// The number of red bitplanes in the accumulation buffer. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            AccumRedBitsARB = 0x201E,

            /// <summary>
            /// The number of green bitplanes in the accumulation buffer. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            AccumGreenBitsARB = 0x201F,

            /// <summary>
            /// The number of blue bitplanes in the accumulation buffer. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            AccumBlueBitsARB = 0x2020,

            /// <summary>
            /// The number of alpha bitplanes in the accumulation buffer. Accumulation buffer are not supported in OpenGL core profile.
            /// </summary>
            AccumAlphaBitsARB = 0x2021,

            /// <summary>
            /// The depth of the depth buffer.
            /// </summary>
            DepthBitsARB = 0x2022,

            /// <summary>
            /// The depth of the stencil buffer.
            /// </summary>
            StencilBitsARB = 0x2023,

            /// <summary>
            /// The number of auxiliary buffers. Auxiliary buffers are not supported in OpenGL core profile.
            /// </summary>
            AuxBuffersARB = 0x2024,

            #endregion

            #region WGL_ARB_pbuffer

            /// <summary>
            /// <b>true</b> if the pixel format supports pbuffers
            /// </summary>
            DrawToPbufferARB = 0x202D,

            /// <summary>
            /// The maximum pixels in a pbuffer.
            /// </summary>
            MaxPbufferPixelsARB = 0x202E,

            /// <summary>
            /// The maximum pixels width of a pbuffer in pixels.
            /// </summary>
            MaxPbufferWidthARB = 0x202F,

            /// <summary>
            /// The maximum pixels height of a pbuffer in pixels.
            /// </summary>
            MaxPbufferHeightARB = 0x2030,

            #endregion

            #region WGL_ARB_render_texture

            /// <summary>
            /// <b>true</b> if the color buffers can be bound to a RGB texture.
            /// </summary>
            BindToTextureRgbARB = 0x2070,

            /// <summary>
            /// <b>true</b> if the color buffers can be bound to a RGBA texture.
            /// </summary>
            BindToTextureRGBAARB = 0x2071,

            #endregion

            #region WGL_ARB_multisample

            /// <summary>
            /// The number of available multisample buffers. (Currently only 1 multisample buffer is supported. Zero is returned if no multisample buffer is available.)
            /// </summary>
            SampleBuffersARB = 0x2041,

            /// <summary>
            /// The number of samples per pixel.
            /// </summary>
            SamplesARB = 0x2042, // = WGL_COVERAGE_SAMPLES_NV

            #endregion

            #region WGL_ARB_framebuffer_sRGB

            /// <summary>
            /// <b>true</b> if the pixel format supports sRGB.
            /// </summary>
            FramebufferSRGBCapableARB = 0x20A9,

            #endregion

            #region WGL_EXT_depth_float

            /// <summary>
            /// <b>true</b> if the pixel format supports floating point depth buffer.
            /// </summary>
            DepthFloatEXT = 0x2040,

            #endregion

            #region WGL_NV_render_texture_rectangle

            /// <summary>
            /// <b>true</b> if the pixel format supports binding pbuffers as RGB texture rectangle.
            /// </summary>
            BindToTextureRectangleRgbNv = 0x20A0,

            /// <summary>
            /// <b>true</b> if the pixel format supports binding pbuffers as RGBA texture rectangle.
            /// </summary>
            BindToTextureRectangleRGBANv = 0x20A1,

            #endregion

            #region WGL_NV_render_depth_texture

            /// <summary>
            /// <b>true</b> if the pixel format supports binding depth buffers as textures.
            /// </summary>
            BindToTextureDepthNv = 0x20A3,

            /// <summary>
            /// <b>true</b> if the pixel format supports binding depth buffers as texture rectangle.
            /// </summary>
            BindToTextureRectangleDepthNv = 0x20A4,

            #endregion
        }

        /// <summary>
        /// Specifies pixel types for pixel formats.
        /// </summary>
        public enum PixelTypeARB : int
        {
            /// <summary>
            /// RGBA.
            /// </summary>
            RGBAARB = 0x202B,

            /// <summary>
            /// Paletted/indexed colors. Not supported be the OpenGL core profile.
            /// </summary>
            ColorindexARB = 0x202C,

            #region WGL_ARB_pixel_format_float

            /// <summary>
            /// Floating point RGBA.
            /// </summary>
            RGBAFloatARB = 0x21A0,

            #endregion

            #region WGL_EXT_pixel_format_packed_float

            /// <summary>
            /// Unsigned floating points RGBA.
            /// </summary>
            RGBAUnsignedFloatEXT = 0x20A8,

            #endregion
        }

        /// <summary>
        /// Specifies swap methodes.
        /// </summary>
        public enum WGLSwapMethodeARB : int
        {
            /// <summary>
            /// Front and back buffer will be exchanged.
            /// </summary>
            ExchangeARB = 0x2028,

            /// <summary>
            /// Back buffer will be copied to front.
            /// </summary>
            CopyARB = 0x2029,

            /// <summary>
            /// Double buffering is not supported.
            /// </summary>
            UndefinedARB = 0x202A,
        }

        /// <summary>
        /// Specifies the cube map faces. Used as value for <see cref="PbufferAttributeARB.CubeMapFaceARB"/>.
        /// </summary>
        public enum WGLTextureCubeMapFaceARB : int
        {
            /// <summary>
            /// Positive X.
            /// </summary>
            PositiveXARB = 0x207D,

            /// <summary>
            /// Negative X.
            /// </summary>
            NegativeXARB = 0x207E,

            /// <summary>
            /// Positive Y.
            /// </summary>
            PositiveYARB = 0x207F,

            /// <summary>
            /// Negative Y.
            /// </summary>
            NegativeYARB = 0x2080,

            /// <summary>
            /// Positive Z.
            /// </summary>
            PositiveZARB = 0x2081,

            /// <summary>
            /// Negative Z.
            /// </summary>
            NegativeZARB = 0x2082,
        }

        /// <summary>
        /// Specifies the texture format. Used as value for <see cref="PbufferAttributeARB.TextureFormatARB"/>
        /// </summary>
        public enum WGLTextureFormatARB : int
        {
            /// <summary>
            /// RGB texture.
            /// </summary>
            TextureRgbARB = 0x2075,

            /// <summary>
            /// RGBA texture.
            /// </summary>
            TextureRGBAARB = 0x2076,

            /// <summary>
            /// No texture.
            /// </summary>
            NoTextureARB = 0x2077,
        }

        /// <summary>
        /// Specifies the texture target. Used as value for <see cref="PbufferAttributeARB.TextureTargetARB"/>
        /// </summary>
        public enum WGLTextureTargetARB : int
        {
            /// <summary>
            /// Cube map texture.
            /// </summary>
            TextureCubeMapARB = 0x2078,

            /// <summary>
            /// 1D texture.
            /// </summary>
            Texture_1DARB = 0x2079,

            /// <summary>
            /// 2D texture.
            /// </summary>
            Texture_2DARB = 0x207A,

            /// <summary>
            /// No texture.
            /// </summary>
            NoTextureARB = 0x2077,

            #region WGL_NV_render_texture_rectangle

            /// <summary>
            /// Rectangle texture.
            /// </summary>
            TextureRectangleNv = 0x20A2,

            #endregion
        }
    }
}