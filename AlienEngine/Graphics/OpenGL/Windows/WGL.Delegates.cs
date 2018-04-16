using System;

namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    public static partial class WGL
    {
        #region WGL_ARB_create_context(-profile)

        internal delegate IntPtr CreateContextAttribsARBDelegate(IntPtr intPtr, IntPtr hShareContext, int[] attribList);

        #endregion

        #region WGL_ARB_extensions_string

        internal delegate IntPtr GetExtensionsStringARBDelegate(IntPtr intPtr);

        #endregion

        #region WGL_ARB_make_current_read

        /// <summary>
        /// Makes the device context(s) and rendering context current.
        /// </summary>
        /// <param name="hDrawDc">The IntPtr to the device context for drawing.</param>
        /// <param name="hReadDc">The IntPtr to the device context for reading.</param>
        /// <param name="intPtr">The IntPtr to the rendering context.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool MakeContextCurrentARBDelegate(IntPtr hDrawDc, IntPtr hReadDc, IntPtr intPtr);

        /// <summary>
        /// Returns the current device context for reading.
        /// </summary>
        /// <returns>The IntPtr to the device context for reading.</returns>
        public delegate IntPtr GetCurrentReadDCARBDelegate();

        #endregion

        #region WGL_ARB_buffer_region

        /// <summary>
        /// Creates a buffer region.
        /// </summary>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="uType">A <see cref="WGLBufferMaskARB"/>-bitmask specifying the buffers,</param>
        /// <returns>A IntPtr to the buffer region object.</returns>
        public delegate IntPtr CreateBufferRegionARBDelegate(IntPtr intPtr, int iLayerPlane, WGLBufferMaskARB uType);

        /// <summary>
        /// Deletes a buffer region.
        /// </summary>
        /// <param name="hRegion">The IntPtr to the buffer region object.</param>
        public delegate void DeleteBufferRegionARBDelegate(IntPtr hRegion);

        /// <summary>
        /// Saves the content of the buffer(s) specified for the buffer region object to the buffer region.
        /// </summary>
        /// <param name="hRegion">The IntPtr to the buffer region object.</param>
        /// <param name="x">The start position of the region in x-direction.</param>
        /// <param name="y">The start position of the region in y-direction.</param>
        /// <param name="width">The width of the region.</param>
        /// <param name="height">The height of the region.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool SaveBufferRegionARBDelegate(IntPtr hRegion, int x, int y, int width, int height);

        /// <summary>
        /// Restores the content of the buffer(s) specified for the buffer region object with the content save in the buffer region.
        /// </summary>
        /// <param name="hRegion">The IntPtr to the buffer region object.</param>
        /// <param name="x">The start position of the region in x-direction.</param>
        /// <param name="y">The start position of the region in x-direction.</param>
        /// <param name="width">The width of the region.</param>
        /// <param name="height">The height of the region.</param>
        /// <param name="xSrc">The start position of the region inside the buffer region in x-direction.</param>
        /// <param name="ySrc">The start position of the region inside the buffer region in y-direction.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool RestoreBufferRegionARBDelegate(IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc);

        #endregion

        #region WGL_ARB_pixel_format

        internal delegate bool GetPixelFormatAttribivARBOutDelegate(IntPtr intPtr, int iPixelFormat, int iLayerPlane, uint one, ref PixelFormatAttributeARB piAttributes, out int piValues);

        internal delegate bool GetPixelFormatAttribivARBArrayDelegate(IntPtr intPtr, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttributeARB[] piAttributes, int[] piValues);

        internal delegate bool GetPixelFormatAttribfvARBOutDelegate(IntPtr intPtr, int iPixelFormat, int iLayerPlane, uint one, ref PixelFormatAttributeARB piAttributes, out float pfValues);

        internal delegate bool GetPixelFormatAttribfvARBArrayDelegate(IntPtr intPtr, int iPixelFormat, int iLayerPlane, uint nAttributes, PixelFormatAttributeARB[] piAttributes, float[] pfValues);

        internal delegate bool ChoosePixelFormatARBOutDelegate(IntPtr intPtr, int[] piAttribIList, float[] pfAttribFList, uint one, out int piFormat, out uint nNumFormats);

        internal delegate bool ChoosePixelFormatARBArrayDelegate(IntPtr intPtr, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats);

        #endregion

        #region WGL_ARB_pbuffer

        internal delegate IntPtr CreatePbufferARBDelegate(IntPtr intPtr, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList);

        /// <summary>
        /// Creates a device context of a pbuffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <returns>The IntPtr to the device context.</returns>
        public delegate IntPtr GetPbufferDCARBDelegate(IntPtr hPbuffer);

        /// <summary>
        /// Releases a device context previously created with <see cref="WGL.GetPbufferDCARB"/>.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <returns><b>1</b> if the device context was released, otherwise <b>0</b> is returned.</returns>
        public delegate int ReleasePbufferDCARBDelegate(IntPtr hPbuffer, IntPtr intPtr);

        /// <summary>
        /// Destroys a pbuffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool DestroyPbufferARBDelegate(IntPtr hPbuffer);

        internal delegate bool QueryPbufferARBDelegate(IntPtr hPbuffer, PbufferAttributeARB iAttribute, out int piValue);

        #endregion

        #region WGL_ARB_render_texture

        internal delegate bool SetPbufferAttribARBDelegate(IntPtr hPbuffer, int[] piAttribList);

        /// <summary>
        /// Defines/binds a texture based on a pbuffer color buffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="iBuffer">A <see cref="BufferARB"/> specifying the buffer.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool BindTexImageARBDelegate(IntPtr hPbuffer, BufferARB iBuffer);

        /// <summary>
        /// Releases a texture binding from a pbuffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="iBuffer">A <see cref="BufferARB"/> specifying the buffer.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool ReleaseTexImageARBDelegate(IntPtr hPbuffer, BufferARB iBuffer);

        #endregion

        #region WGL_EXT_swap_control

        /// <summary>
        /// Returns the interval of minimum periodicity of color buffer swaps, measured in video frame periods.
        /// </summary>
        /// <returns>The interval of minimum periodicity of color buffer swaps, measured in video frame periods.</returns>
        public delegate int GetSwapIntervalEXTDelegate();

        /// <summary>
        /// Sets the interval of minimum periodicity of color buffer swaps, measured in video frame periods.
        /// </summary>
        /// <param name="interval">The interval of minimum periodicity of color buffer swaps, measured in video frame periods.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool SwapIntervalEXTDelegate(int interval);

        #endregion

        #region WGL_NV_copy_image (WGL sibling of glCopyImageSubData, available since 4.3)

        /// <summary>
        /// Performs a raw data copy between two images.
        /// </summary>
        /// <param name="hSrcRc">The IntPtr to the source rendering context.</param>
        /// <param name="srcName">The name of a texture or renderbuffer object from which to copy.</param>
        /// <param name="srcTarget">A <see cref="TextureTarget"/> specifying the namespaces of <paramref name="srcName"/>.</param>
        /// <param name="srcLevel">The level-of-detail to read form the source.</param>
        /// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcY">The Y coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcZ">The Z coordinate of the left edge of the souce region to copy.</param>
        /// <param name="hDstRc">The IntPtr to the destination rendering context.</param>
        /// <param name="dstName">The name of a texture or renderbuffer object to which to copy.</param>
        /// <param name="dstTarget">A <see cref="TextureTarget"/> specifying the namespaces of <paramref name="dstName"/>.</param>
        /// <param name="dstLevel">The level-of-detail of the target to write to.</param>
        /// <param name="dstX">The X coordinate of the left edge of the destination region.</param>
        /// <param name="dstY">The Y coordinate of the left edge of the destination region.</param>
        /// <param name="dstZ">The Z coordinate of the left edge of the destination region.</param>
        /// <param name="srcWidth">The width of the region.</param>
        /// <param name="srcHeight">The height of the region.</param>
        /// <param name="srcDepth">The depth of the region.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public delegate bool CopyImageSubDataNvDelegate(IntPtr hSrcRc, uint srcName, TextureTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, IntPtr hDstRc, uint dstName, TextureTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth);

        #endregion
    }
}