#region Copyrights and Licenses

// Copyright (c) 2013-2014 The Khronos Group Inc.
// Copyright (c) of C# port 2014 by Shinta <shintadono@gooemail.com>
// Copyright (c) 2017 AlienGames
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and/or associated documentation files (the
// "Materials"), to deal in the Materials without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Materials, and to
// permit persons to whom the Materials are furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Materials.
//
// THE MATERIALS ARE PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    /// <summary>
    /// OpenGL window binding for the Microsoft Windows OS.
    /// </summary>
    [SuppressUnmanagedCodeSecurityAttribute()]
    public static partial class WGL
    {
        private const string Library = "opengl32.dll";
        private const string TypeNotSupportedMessage = "Type not supported.";

        #region Renderer properties

        /// <summary>
        /// After <see cref="LoadWGLExtensions"/> was called, this property contains the version string of the OpenGL implementation used.
        /// </summary>
        public static string Version { get; private set; }

        /// <summary>
        /// After <see cref="LoadWGLExtensions"/> was called, this property contains the vendor name of the OpenGL implementation used.
        /// </summary>
        public static string Vendor { get; private set; }

        /// <summary>
        /// After <see cref="LoadWGLExtensions"/> was called, this property contains the renderer name of the OpenGL implementation used.
        /// </summary>
        public static string Renderer { get; private set; }

        private static int _majorVersion = 1;

        /// <summary>
        /// After <see cref="LoadWGLExtensions"/> was called, this property contains the major version number of the OpenGL implementation used.
        /// </summary>
        public static int MajorVersion
        {
            get { return _majorVersion; }
            private set { _majorVersion = value; }
        }

        private static int _minorVersion = 1;

        /// <summary>
        /// After <see cref="LoadWGLExtensions"/> was called, this property contains the minor version number of the OpenGL implementation used.
        /// </summary>
        public static int MinorVersion
        {
            get { return _minorVersion; }
            private set { _minorVersion = value; }
        }

        #endregion

        /// <summary>
        /// Maximum number of (layered) buffer swap operations that can be performed at once (with <see cref="SwapMultipleBuffers">WGL.SwapMultipleBuffers</see>).
        /// </summary>
        public const int SwapMultipleMax = 16;

        /// <summary>
        /// Swaps the front and back buffers of the given device.
        /// </summary>
        /// <param name="device">The pointer to the device context.</param>
        /// <returns><b>true</b> if succeeds, <b>false</b> otherwise.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SwapBuffers", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SwapBuffers([In] IntPtr device);

        /// <summary>
        /// Gets the device context associated to the given <paramref name="windowHandle">window handle</paramref>.
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <returns><b>true</b> if succeeds, <b>false</b> otherwise.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr windowHandle);

        /// <summary>
        /// Releases the given device context.
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <param name="deviceContext">The device context to release.</param>
        /// <returns><b>true</b> if succeeds, <b>false</b> otherwise.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ReleaseDC")]
        public static extern bool ReleaseDC(IntPtr windowHandle, IntPtr deviceContext);

        #region Original WGL functions

        /// <summary>
        /// Creates a new OpenGL rendering context, which is suitable for drawing on the device referenced by <paramref name="device"/>.
        /// The rendering context has the same pixel format as the device context.
        /// </summary>
        /// <param name="device">The pointer to the device context.</param>
        /// <returns>The pointer to the rendering context.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglCreateContext", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateContext(IntPtr device);

        /// <summary>
        /// Creates a new OpenGL rendering context for drawing to a specified layer plane on a device context.
        /// </summary>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="iLayerPlane">The layer plane to which you want to bind a rendering context.</param>
        /// <returns>The IntPtr to the rendering context.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglCreateLayerContext", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateLayerContext(IntPtr intPtr, int iLayerPlane);

        /// <summary>
        /// Deletes a specified OpenGL rendering context.
        /// </summary>
        /// <param name="context">The pointer to the rendering context.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglDeleteContext", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteContext(IntPtr context);

        /// <summary>
        /// Obtains information about the layer planes of a given pixel format.
        /// </summary>
        /// <param name="intPtr">The IntPtr to the device context of a window whose layer planes are to be described.</param>
        /// <param name="iPixelFormat">The pixel format to be described.</param>
        /// <param name="iLayerPlane">The layer plane number. Positive number are overlay planes, negative numbers are underlay planes.</param>
        /// <param name="nBytes">The size, in bytes, of the structure pointed to by plpd.</param>
        /// <param name="plpd">Returns the description of the layer plane.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglDescribeLayerPlane", ExactSpelling = true, SetLastError = true)]
        public static extern bool DescribeLayerPlane(IntPtr intPtr, int iPixelFormat, int iLayerPlane, uint nBytes, out LayerPlaneDescriptor plpd);

        /// <summary>
        /// Obtains a IntPtr to the current OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns>The IntPtr to the rendering context.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglGetCurrentContext", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetCurrentContext();

        /// <summary>
        /// Obtains a IntPtr to the device context that is associated with the current OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns>The IntPtr to the device context.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglGetCurrentDC", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetCurrentDC();

        /// <summary>
        /// Obtains a IntPtr to the a WGL function.
        /// </summary>
        /// <param name="lpszProc"></param>
        /// <returns></returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglGetProcAddress", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr _GetProcAddress(string lpszProc);

        /// <summary>
        /// Makes a specified OpenGL rendering context the calling thread's current rendering context.
        /// </summary>
        /// <param name="device">The IntPtr to the device context.</param>
        /// <param name="context">The IntPtr to the rendering context.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglMakeCurrent", ExactSpelling = true, SetLastError = true)]
        public static extern bool MakeCurrent(IntPtr device, IntPtr context);

        /// <summary>
        /// Defines the pixel format to use on the given device context.
        /// </summary>
        /// <param name="deviceContext"></param>
        /// <param name="pixelFormatDescriptor"></param>
        /// <returns></returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglChoosePixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern unsafe int ChoosePixelFormat(IntPtr deviceContext, [In] ref PixelFormatDescriptor pixelFormatDescriptor);

        /// <summary>
        /// Describes a pixel format.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="iPixelFormat"></param>
        /// <param name="nBytes"></param>
        /// <param name="ppfd"></param>
        /// <returns></returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglDescribePixelFormat", ExactSpelling = true, SetLastError = true)]
        private static extern unsafe int DescribePixelFormatInternal(IntPtr hdc, int iPixelFormat, uint nBytes, [In, Out] ref PixelFormatDescriptor ppfd);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglGetPixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern int GetPixelFormat(IntPtr hdc);

        /// <summary>
        /// Sets a pixel format on a device context.
        /// </summary>
        /// <param name="deviceContext"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="pixelFormatDescriptor"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetPixelFormat(IntPtr dc, int format, ref PixelFormatDescriptor pfd);

        /// <summary>
        /// Enables multiple OpenGL rendering contexts to share object resources (e.g. display lists [deprecated], textures, VBO,...).
        /// </summary>
        /// <param name="context">The pointer to the OpenGL rendering context with which to share.</param>
        /// <param name="share">The pointer to the OpenGL rendering context to share with <paramref name="context"/>.
        /// The <paramref name="share"/> parameter should not contain any existing resources when <see cref="ShareLists">WGL.ShareLists</see> is called.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglShareLists", ExactSpelling = true, SetLastError = true)]
        public static extern bool ShareLists(IntPtr context, IntPtr share);

        /// <summary>
        /// Swaps the front and back buffers in the overlay, underlay, and main planes of the window referenced by a specified device context.
        /// </summary>
        /// <param name="device">The IntPtr to the device context.</param>
        /// <param name="planes"><see cref="PixelFormatDescriptorLayerType"/>-bitmask specifying the planes to be swapped.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglSwapLayerBuffers", ExactSpelling = true, SetLastError = true)]
        public static extern bool SwapLayerBuffers(IntPtr device, PixelFormatDescriptorLayerType planes);

        /// <summary>
        /// Allows to swap more than one window at one time.
        /// </summary>
        /// <remarks>For example if you have four views like in a CAD application, if you call
        /// <see cref="WGL.SwapLayerBuffers"/> or <b>SwapBuffers</b> (GDI) in sequence
        /// for each of them there is a small delay because it's a blocking call. It's annoying
        /// during playback of animation, because the contexts can be seen to swaping clockwise,
        /// for example (though it can be minimized). It's probably not implemented, like the
        /// DirectDraw flag (good intension only).
        /// </remarks>
        /// <param name="count">The number of swaps to perform. Maximum is defined by <see cref="WGL.SwapMultipleMax"/>.</param>
        /// <param name="swaps">An array of at least <paramref name="count"/> <see cref="PixelFormatDescriptorLayerType"/> structures specifying the (layered) buffer swap operations to perform.</param>
        /// <returns>Returns the number of perfomed swap operations.</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Library, EntryPoint = "wglSwapMultipleBuffers", ExactSpelling = true, SetLastError = true)]
        public static extern uint SwapMultipleBuffers(uint count, PixelFormatDescriptorLayerType[] swaps);

        #endregion

        #region Delegate variables

        private static CreateContextAttribsARBDelegate _createContextAttribsARB;

        private static GetExtensionsStringARBDelegate _getExtensionsStringARB;

        /// <summary>
        /// Makes the device context(s) and rendering context current.
        /// </summary>
        public static MakeContextCurrentARBDelegate MakeContextCurrentARB;

        /// <summary>
        /// Returns the current device context for reading.
        /// </summary>
        public static GetCurrentReadDCARBDelegate GetCurrentReadDCARB;

        /// <summary>
        /// Creates a buffer region.
        /// </summary>
        public static CreateBufferRegionARBDelegate CreateBufferRegionARB;

        /// <summary>
        /// Deletes a buffer region.
        /// </summary>
        public static DeleteBufferRegionARBDelegate DeleteBufferRegionARB;

        /// <summary>
        /// Saves the content of the buffer(s) specified for the buffer region object to the buffer region.
        /// </summary>
        public static SaveBufferRegionARBDelegate SaveBufferRegionARB;

        /// <summary>
        /// Restores the content of the buffer(s) specified for the buffer region object with the content save in the buffer region.
        /// </summary>
        public static RestoreBufferRegionARBDelegate RestoreBufferRegionARB;

        private static GetPixelFormatAttribivARBOutDelegate _getPixelFormatAttribivARBOut;
        private static GetPixelFormatAttribivARBArrayDelegate _getPixelFormatAttribivARBArray;
        private static GetPixelFormatAttribfvARBOutDelegate _getPixelFormatAttribfvARBOut;
        private static GetPixelFormatAttribfvARBArrayDelegate _getPixelFormatAttribfvARBArray;
        private static ChoosePixelFormatARBOutDelegate _choosePixelFormatARBOut;
        private static ChoosePixelFormatARBArrayDelegate _choosePixelFormatARBArray;
        private static CreatePbufferARBDelegate _createPbufferARB;

        /// <summary>
        /// Creates a device context of a pbuffer.
        /// </summary>
        public static GetPbufferDCARBDelegate GetPbufferDcarb;

        /// <summary>
        /// Releases a device context previously created with <see cref="GetPbufferDcarb"/>.
        /// </summary>
        public static ReleasePbufferDCARBDelegate ReleasePbufferDcarb;

        /// <summary>
        /// Destroys a pbuffer.
        /// </summary>
        public static DestroyPbufferARBDelegate DestroyPbufferARB;

        private static QueryPbufferARBDelegate _queryPbufferARB;
        private static SetPbufferAttribARBDelegate _setPbufferAttribARB;

        /// <summary>
        /// Defines/binds a texture based on a pbuffer color buffer.
        /// </summary>
        public static BindTexImageARBDelegate BindTexImageARB;

        /// <summary>
        /// Releases a texture binding from a pbuffer.
        /// </summary>
        public static ReleaseTexImageARBDelegate ReleaseTexImageARB;

        /// <summary>
        /// Returns the interval of minimum periodicity of color buffer swaps, measured in video frame periods.
        /// </summary>
        public static GetSwapIntervalEXTDelegate GetSwapIntervalEXT;

        /// <summary>
        /// Sets the interval of minimum periodicity of color buffer swaps, measured in video frame periods.
        /// </summary>
        public static SwapIntervalEXTDelegate SwapIntervalEXT;

        /// <summary>
        /// Performs a raw data copy between two images.
        /// </summary>
        public static CopyImageSubDataNvDelegate CopyImageSubDataNv;

        #endregion

        #region Overrides/Overloads

        /// <summary>
        /// Returns a delegate of type <typeparamref name="TDelegate"/> to an OpenGL (extension) function for use with the current OpenGL rendering context.
        /// </summary>
        /// <typeparam name="TDelegate">The type of delegate to return.</typeparam>
        /// <param name="name">The name of the (extension) function.</param>
        /// <returns>The address of an OpenGL (extension) function.</returns>
        public static TDelegate GetProcAddress<TDelegate>(string name) where TDelegate : class
        {
            IntPtr addr = _GetProcAddress(name);
            if (addr == IntPtr.Zero) return null;
            return (TDelegate) (object) Marshal.GetDelegateForFunctionPointer(addr, typeof(TDelegate));
        }

        public static int DescribePixelFormat(IntPtr hdc, int iPixelFormat, uint nBytes, out PixelFormatDescriptor ppfd)
        {
            ppfd = new PixelFormatDescriptor();
            return DescribePixelFormatInternal(hdc, iPixelFormat, nBytes, ref ppfd);
        }
        
        /// <summary>
        /// Creates a new OpenGL rendering context that, if successful created, will satisfy all(*) the user-specified demands.
        /// </summary>
        /// <remarks>
        /// * If the extension is not available, the <b>wglCreateContext</b> and if necessary <b>wglShareLists</b> function will be used, to create the context. None of the user-specified attributes will be used in this case.
        /// </remarks>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="hShareContext">A IntPtr to a rendering context with which to share objects. Set <b>0</b> (zero) if no sharing is needed.</param>
        /// <param name="attribList">A null-terminated list of attributes (name-value pairs) for the rendering context.</param>
        /// <returns>The IntPtr to the rendering context.</returns>
        public static IntPtr CreateContextAttribsARB(IntPtr intPtr, IntPtr hShareContext, params int[] attribList)
        {
            if (_createContextAttribsARB != null) return _createContextAttribsARB(intPtr, hShareContext, attribList);

            // Try the antique way.
            IntPtr ret = CreateContext(intPtr);
            if (hShareContext != IntPtr.Zero) ShareLists(ret, hShareContext);
            return ret;
        }

        /// <summary>
        /// Creates a new OpenGL rendering context that, if successful created, will satisfy all(*) the user-specified demands.
        /// </summary>
        /// <remarks>
        /// * If the extension is not available, the <b>wglCreateContext</b> and if necessary <b>wglShareLists</b> function will be used, to create the context. None of the user-specified attributes will be used in this case.
        /// </remarks>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="hShareContext">A IntPtr to a rendering context with which to share objects. Set <b>0</b> (zero) if no sharing is needed.</param>
        /// <param name="pAttribList">A dictionary containing the attributes for the pixel format.</param>
        /// <returns>The IntPtr to the rendering context.</returns>
        public static IntPtr CreateContextAttribsARB(IntPtr intPtr, IntPtr hShareContext, Dictionary<ContextAttributeARB, object> pAttribList)
        {
            if (pAttribList == null || pAttribList.Count == 0) return IntPtr.Zero;

            if (_createContextAttribsARB != null)
            {
                int[] piAttribList = new int[pAttribList.Count * 2 + 1];
                int ints = 0;

                foreach (ContextAttributeARB key in pAttribList.Keys)
                {
                    if (key == 0) continue;
                    object value = pAttribList[key];

                    if (!(value is int || value is uint || value is bool || value is Enum)) continue;

                    if (value is int)
                    {
                        piAttribList[ints + 1] = (int) value;
                    }
                    else if (value is uint)
                    {
                        piAttribList[ints + 1] = (int) (uint) value;
                    }
                    else if (value is bool)
                    {
                        piAttribList[ints + 1] = ((bool) value) ? GL.TRUE : GL.FALSE;
                    }
                    else if (value is Enum)
                    {
                        Type vType = value.GetType().GetEnumUnderlyingType();

                        if (vType == typeof(int))
                            piAttribList[ints + 1] = (int) value;
                        else if (vType == typeof(uint))
                            piAttribList[ints + 1] = (int) (uint) value;
                        else
                            continue;
                    }

                    piAttribList[ints] = (int) key;
                    ints += 2;
                }

                piAttribList[ints] = 0;

                return _createContextAttribsARB(intPtr, hShareContext, piAttribList);
            }

            // Try the antique way.
            IntPtr ret = CreateContext(intPtr);
            if (hShareContext != IntPtr.Zero) ShareLists(ret, hShareContext);
            return ret;
        }

        /// <summary>
        /// Returns a list of supported WGL-extensions.
        /// </summary>
        /// <param name="device">The device context to query extensions for.</param>
        /// <returns>A list of supported WGL-extensions as <b>string</b>.</returns>
        public static string GetExtensionsStringARB(IntPtr device)
        {
            return Marshal.PtrToStringAnsi(_getExtensionsStringARB(device));
        }

        /// <summary>
        /// Retrieves information about pixel formats.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piAttributes">A <see cref="PixelFormatAttributeARB"/> specifying the attribute.</param>
        /// <param name="piValue">Returns the requested information.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, PixelFormatAttributeARB piAttributes, out int piValue)
        {
            return _getPixelFormatAttribivARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref piAttributes, out piValue);
        }

        /// <summary>
        /// Retrieves information about pixel formats.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piAttributes">A <see cref="PixelFormatAttributeARB"/> specifying the attribute.</param>
        /// <param name="pbValue">Returns the requested information.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, PixelFormatAttributeARB piAttributes, out bool pbValue)
        {
            int value;
            bool ret = _getPixelFormatAttribivARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref piAttributes, out value);
            pbValue = value != 0;
            return ret;
        }

        /// <summary>
        /// Retrieves acceleration mode (<see cref="PixelFormatAttributeARB.AccelerationARB"/>) of a pixel format.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piValue">Returns the acceleration mode as <see cref="AccelerationModeARB"/>.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, out AccelerationModeARB piValue)
        {
            PixelFormatAttributeARB piAttributes = PixelFormatAttributeARB.AccelerationARB;
            int value;
            bool ret = _getPixelFormatAttribivARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref piAttributes, out value);
            piValue = (AccelerationModeARB) value;
            return ret;
        }

        /// <summary>
        /// Retrieves swapping method (<see cref="PixelFormatAttributeARB.SwapMethodARB"/>) of a pixel format.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piValue">Returns the swap methode as <see cref="WGLSwapMethodeARB"/>.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, out WGLSwapMethodeARB piValue)
        {
            PixelFormatAttributeARB piAttributes = PixelFormatAttributeARB.SwapMethodARB;
            int value;
            bool ret = _getPixelFormatAttribivARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref piAttributes, out value);
            piValue = (WGLSwapMethodeARB) value;
            return ret;
        }

        /// <summary>
        /// Retrieves pixel type (<see cref="PixelFormatAttributeARB.PixelTypeARB"/>) of a pixel format.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piValue">Returns the spixel type as <see cref="PixelTypeARB"/>.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, out PixelTypeARB piValue)
        {
            PixelFormatAttributeARB piAttributes = PixelFormatAttributeARB.PixelTypeARB;
            int value;
            bool ret = _getPixelFormatAttribivARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref piAttributes, out value);
            piValue = (PixelTypeARB) value;
            return ret;
        }

        /// <summary>
        /// Retrieves information about pixel formats.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="piAttributes">An array of <see cref="PixelFormatAttributeARB"/>s specifying the attributes.</param>
        /// <param name="piValues">The array to receive the requested values.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribivARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, PixelFormatAttributeARB[] piAttributes, int[] piValues)
        {
            return _getPixelFormatAttribivARBArray(intPtr, iPixelFormat, iLayerPlane, (uint) Math.Min(piAttributes.Length, piValues.Length), piAttributes, piValues);
        }

        /// <summary>
        /// Retrieves information about pixel formats.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="pfAttributes">A <see cref="PixelFormatAttributeARB"/> specifying the attribute.</param>
        /// <param name="pfValue">Returns the requested information.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribfvARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, PixelFormatAttributeARB pfAttributes, out float pfValue)
        {
            return _getPixelFormatAttribfvARBOut(intPtr, iPixelFormat, iLayerPlane, 1, ref pfAttributes, out pfValue);
        }

        /// <summary>
        /// Retrieves information about pixel formats.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="iPixelFormat">The pixel format to query informations for.</param>
        /// <param name="iLayerPlane">The layer plane.</param>
        /// <param name="pfAttributes">An array of <see cref="PixelFormatAttributeARB"/>s specifying the attributes.</param>
        /// <param name="pfValues">The array to receive the requested values.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool GetPixelFormatAttribfvARB(IntPtr intPtr, int iPixelFormat, int iLayerPlane, PixelFormatAttributeARB[] pfAttributes, float[] pfValues)
        {
            return _getPixelFormatAttribfvARBArray(intPtr, iPixelFormat, iLayerPlane, (uint) Math.Min(pfAttributes.Length, pfValues.Length), pfAttributes, pfValues);
        }

        /// <summary>
        /// Returns the best fitting pixel format for given attributes.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="piAttribIList">Null-terminated list of key-value-pairs (integers and enums) specifying the attributes for the pixel format.</param>
        /// <param name="pfAttribFList">Null-terminated list of key-value-pairs (floating point values) specifying the attributes for the pixel format.</param>
        /// <param name="piFormat">Returns the pixel format.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool ChoosePixelFormatARB(IntPtr intPtr, int[] piAttribIList, float[] pfAttribFList, out int piFormat)
        {
            uint nNumFormats;
            bool ret = _choosePixelFormatARBOut(intPtr, piAttribIList, pfAttribFList, 1, out piFormat, out nNumFormats);
            return ret && nNumFormats > 0; // Here should 'nNumFormats==1' be correct, but there seems to be some incorrect implementations around, that return the maximum number instead of the actual returned number.
        }

        /// <summary>
        /// Returns the best fitting pixel format for given attributes.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="pAttribList">A dictionary containing the attributes for the pixel format.</param>
        /// <param name="piFormat">Returns the pixel format.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool ChoosePixelFormatARB(IntPtr intPtr, Dictionary<PixelFormatAttributeARB, object> pAttribList, out int piFormat)
        {
            piFormat = 0;
            if (pAttribList == null || pAttribList.Count == 0) return false;

            int ints = 0, floats = 0;
            foreach (object value in pAttribList.Values)
            {
                if (value is float || value is double)
                {
                    floats++;
                    continue;
                }

                if (value is int || value is uint || value is bool || value is Enum)
                {
                    ints++;
                    continue;
                }

                throw new NotSupportedException(TypeNotSupportedMessage);
            }

            if (ints == 0 && floats == 0) return false;

            int[] piAttribIList = new int[ints * 2 + 1];
            float[] pfAttribFList = new float[floats * 2 + 1];
            ints = 0;
            floats = 0;

            foreach (PixelFormatAttributeARB key in pAttribList.Keys)
            {
                if (key == 0) continue;
                object value = pAttribList[key];

                if (value is float || value is double)
                {
                    pfAttribFList[floats++] = (float) (int) key; // is this correct? don't we need a static_cast<float> to preserve the enum bits?
                    if (value is float) pfAttribFList[floats++] = (float) value;
                    else pfAttribFList[floats++] = (float) (double) value;
                    continue;
                }

                if (value is int || value is uint || value is bool || value is Enum)
                {
                    if (value is int) piAttribIList[ints + 1] = (int) value;
                    else if (value is uint)
                        piAttribIList[ints + 1] = (int) (uint) value;
                    else if (value is bool)
                        piAttribIList[ints + 1] = ((bool) value) ? GL.TRUE : GL.FALSE;
                    else if (value is Enum)
                    {
                        Type vType = value.GetType().GetEnumUnderlyingType();
                        if (vType == typeof(int)) piAttribIList[ints + 1] = (int) value;
                        else if (vType == typeof(uint))
                            piAttribIList[ints + 1] = (int) (uint) value;
                        else
                            continue;
                    }

                    piAttribIList[ints] = (int) key;
                    ints += 2;

                    continue;
                }
            }

            piAttribIList[ints] = 0;
            pfAttribFList[floats] = 0;

            return ChoosePixelFormatARB(intPtr, piAttribIList, pfAttribFList, out piFormat);
        }

        /// <summary>
        /// Returns the best fitting pixel formats for given attributes.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="piAttribIList">Null-terminated list of key-value-pairs (integers and enums) specifying the attributes for the pixel format.</param>
        /// <param name="pfAttribFList">Null-terminated list of key-value-pairs (floating point values) specifying the attributes for the pixel format.</param>
        /// <param name="piFormats">Returns the pixel formats.</param>
        /// <param name="nNumFormats">Returns the number of returned pixel formats (in <paramref name="piFormats"/>).</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool ChoosePixelFormatARB(IntPtr intPtr, int[] piAttribIList, float[] pfAttribFList, int[] piFormats, out uint nNumFormats)
        {
            nNumFormats = 0;
            if (piFormats == null || piFormats.Length == 0) return false;

            bool ret = _choosePixelFormatARBArray(intPtr, piAttribIList, pfAttribFList, (uint) piFormats.Length, piFormats, out nNumFormats);
            return ret && nNumFormats > 0;
        }

        /// <summary>
        /// Returns the best fitting pixel formats for given attributes.
        /// </summary>
        /// <param name="intPtr">The device context to query informations for.</param>
        /// <param name="pAttribList">A dictionary containing the attributes for the pixel format.</param>
        /// <param name="piFormats">Returns the pixel formats.</param>
        /// <param name="nNumFormats">Returns the number of returned pixel formats (in <paramref name="piFormats"/>).</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool ChoosePixelFormatARB(IntPtr intPtr, Dictionary<PixelFormatAttributeARB, object> pAttribList, int[] piFormats, out uint nNumFormats)
        {
            nNumFormats = 0;
            if (pAttribList == null || pAttribList.Count == 0 || piFormats == null || piFormats.Length == 0) return false;

            int ints = 0, floats = 0;
            foreach (object value in pAttribList.Values)
            {
                if (value is float || value is double)
                {
                    floats++;
                    continue;
                }

                if (value is int || value is uint || value is bool || value is Enum)
                {
                    ints++;
                    continue;
                }

                throw new NotSupportedException(TypeNotSupportedMessage);
            }

            if (ints == 0 && floats == 0) return false;

            int[] piAttribIList = new int[ints * 2 + 1];
            float[] pfAttribFList = new float[floats * 2 + 1];
            ints = 0;
            floats = 0;

            foreach (PixelFormatAttributeARB key in pAttribList.Keys)
            {
                if (key == 0) continue;
                object value = pAttribList[key];

                if (value is float || value is double)
                {
                    pfAttribFList[floats++] = (float) (int) key; // is this correct? don't we need a static_cast<float> to preserve the enum bits?
                    if (value is float) pfAttribFList[floats++] = (float) value;
                    else pfAttribFList[floats++] = (float) (double) value;
                    continue;
                }

                if (value is int || value is uint || value is bool || value is Enum)
                {
                    if (value is int) piAttribIList[ints + 1] = (int) value;
                    else if (value is uint)
                        piAttribIList[ints + 1] = (int) (uint) value;
                    else if (value is bool)
                        piAttribIList[ints + 1] = ((bool) value) ? GL.TRUE : GL.FALSE;
                    else if (value is Enum)
                    {
                        Type vType = value.GetType().GetEnumUnderlyingType();
                        if (vType == typeof(int)) piAttribIList[ints + 1] = (int) value;
                        else if (vType == typeof(uint))
                            piAttribIList[ints + 1] = (int) (uint) value;
                        else
                            continue;
                    }

                    piAttribIList[ints] = (int) key;
                    ints += 2;
                }
            }

            piAttribIList[ints] = 0;
            pfAttribFList[floats] = 0;

            return ChoosePixelFormatARB(intPtr, piAttribIList, pfAttribFList, piFormats, out nNumFormats);
        }

        /// <summary>
        /// Creates a pbuffer.
        /// </summary>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="iPixelFormat">The pixel format.</param>
        /// <param name="iWidth">The width of the pbuffer.</param>
        /// <param name="iHeight">The height of the pbuffer.</param>
        /// <param name="piAttribList">A null-terminated list of name-value pairs, specifying attributes for the pbuffer.</param>
        /// <returns>The IntPtr to the pbuffer.</returns>
        public static IntPtr CreatePbufferARB(IntPtr intPtr, int iPixelFormat, int iWidth, int iHeight, params int[] piAttribList)
        {
            return _createPbufferARB(intPtr, iPixelFormat, iWidth, iHeight, piAttribList);
        }

        /// <summary>
        /// Creates a pbuffer.
        /// </summary>
        /// <param name="intPtr">The IntPtr to the device context.</param>
        /// <param name="iPixelFormat">The pixel format.</param>
        /// <param name="iWidth">The width of the pbuffer.</param>
        /// <param name="iHeight">The height of the pbuffer.</param>
        /// <param name="pAttribList">A dictionary containing the attributes for the pbuffer.</param>
        /// <returns>The IntPtr to the pbuffer.</returns>
        public static IntPtr CreatePbufferARB(IntPtr intPtr, int iPixelFormat, int iWidth, int iHeight, Dictionary<PbufferAttributeARB, object> pAttribList)
        {
            if (pAttribList == null || pAttribList.Count == 0) return IntPtr.Zero;

            int[] piAttribList = new int[pAttribList.Count * 2 + 1];
            int ints = 0;

            foreach (PbufferAttributeARB key in pAttribList.Keys)
            {
                if (key == 0) continue;
                object value = pAttribList[key];

                if (!(value is int || value is uint || value is bool || value is Enum)) continue;

                if (value is int) piAttribList[ints + 1] = (int) value;
                else if (value is uint)
                    piAttribList[ints + 1] = (int) (uint) value;
                else if (value is bool)
                    piAttribList[ints + 1] = ((bool) value) ? GL.TRUE : GL.FALSE;
                else if (value is Enum)
                {
                    Type vType = value.GetType().GetEnumUnderlyingType();
                    if (vType == typeof(int)) piAttribList[ints + 1] = (int) value;
                    else if (vType == typeof(uint))
                        piAttribList[ints + 1] = (int) (uint) value;
                    else
                        continue;
                }

                piAttribList[ints] = (int) key;
                ints += 2;
            }

            piAttribList[ints] = 0;

            return _createPbufferARB(intPtr, iPixelFormat, iWidth, iHeight, piAttribList);
        }

        /// <summary>
        /// Queries attributes of pbuffers.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="iAttribute">A <see cref="PbufferAttributeARB"/> specifying the attribute to query.</param>
        /// <param name="piValue">Returns the requested value.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool QueryPbufferARB(IntPtr hPbuffer, PbufferAttributeARB iAttribute, out int piValue)
        {
            return _queryPbufferARB(hPbuffer, iAttribute, out piValue);
        }

        /// <summary>
        /// Queries attributes of pbuffers.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="iAttribute">A <see cref="PbufferAttributeARB"/> specifying the attribute to query.</param>
        /// <param name="pbValue">Returns the requested value.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool QueryPbufferARB(IntPtr hPbuffer, PbufferAttributeARB iAttribute, out bool pbValue)
        {
            int piValue;
            bool ret = _queryPbufferARB(hPbuffer, iAttribute, out piValue);
            pbValue = piValue != 0;
            return ret;
        }

        /// <summary>
        /// Queries <see cref="PbufferAttributeARB.TextureFormatARB"/> attribute of pbuffers.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="pValue">Returns the texture format.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool QueryPbufferARB(IntPtr hPbuffer, out WGLTextureFormatARB pValue)
        {
            int piValue;
            bool ret = _queryPbufferARB(hPbuffer, PbufferAttributeARB.TextureFormatARB, out piValue);
            pValue = (WGLTextureFormatARB) piValue;
            return ret;
        }

        /// <summary>
        /// Queries <see cref="PbufferAttributeARB.TextureTargetARB"/> attribute of pbuffers.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="pValue">Returns the texture target.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool QueryPbufferARB(IntPtr hPbuffer, out WGLTextureTargetARB pValue)
        {
            int piValue;
            bool ret = _queryPbufferARB(hPbuffer, PbufferAttributeARB.TextureTargetARB, out piValue);
            pValue = (WGLTextureTargetARB) piValue;
            return ret;
        }

        /// <summary>
        /// Queries <see cref="PbufferAttributeARB.CubeMapFaceARB"/> attribute of pbuffers.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="pValue">Returns the current cube map face.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool QueryPbufferARB(IntPtr hPbuffer, out WGLTextureCubeMapFaceARB pValue)
        {
            int piValue;
            bool ret = _queryPbufferARB(hPbuffer, PbufferAttributeARB.CubeMapFaceARB, out piValue);
            pValue = (WGLTextureCubeMapFaceARB) piValue;
            return ret;
        }

        /// <summary>
        /// Sets attributes of a pbuffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="piAttribList">Null-terminated list of name-value pairs, specifying attributes for the pbuffer.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool SetPbufferAttribARB(IntPtr hPbuffer, params int[] piAttribList)
        {
            return _setPbufferAttribARB(hPbuffer, piAttribList);
        }

        /// <summary>
        /// Sets attributes of a pbuffer.
        /// </summary>
        /// <param name="hPbuffer">The IntPtr to the pbuffer.</param>
        /// <param name="pAttribList">Null-terminated list of name-value pairs, specifying attributes for the pbuffer.</param>
        /// <returns><b>true</b> if the function succeeds, otherwise <b>false</b>.</returns>
        public static bool SetPbufferAttribARB(IntPtr hPbuffer, Dictionary<PbufferAttributeARB, object> pAttribList)
        {
            if (pAttribList == null || pAttribList.Count == 0) return false;

            int[] piAttribList = new int[pAttribList.Count * 2 + 1];
            int ints = 0;

            foreach (PbufferAttributeARB key in pAttribList.Keys)
            {
                if (key == 0) continue;
                object value = pAttribList[key];

                if (!(value is int || value is uint || value is bool || value is Enum)) continue;

                if (value is int) piAttribList[ints + 1] = (int) value;
                else if (value is uint)
                    piAttribList[ints + 1] = (int) (uint) value;
                else if (value is bool)
                    piAttribList[ints + 1] = ((bool) value) ? GL.TRUE : GL.FALSE;
                else if (value is Enum)
                {
                    Type vType = value.GetType().GetEnumUnderlyingType();
                    if (vType == typeof(int)) piAttribList[ints + 1] = (int) value;
                    else if (vType == typeof(uint))
                        piAttribList[ints + 1] = (int) (uint) value;
                    else
                        continue;
                }

                piAttribList[ints] = (int) key;
                ints += 2;
            }

            piAttribList[ints] = 0;

            return _setPbufferAttribARB(hPbuffer, piAttribList);
        }

        #endregion

        /// <summary>
        /// Loads available functions of the OpenGL window binding for the Microsoft Windows OS provided by the currently active ICD.
        /// </summary>
        /// <returns><b>true</b> if the extensions <c>WGL_ARB_create_context(-profile)</c>, <c>WGL_ARB_make_current_read</c> and
        /// <c>WGL_ARB_pixel_format</c> are available.</returns>
        public static bool LoadWGLExtensions()
        {
            // Fill renderer properties
            Version = GL.GetString(StringName.Version);
            Vendor = GL.GetString(StringName.Vendor);
            Renderer = GL.GetString(StringName.Renderer);

            GL.GetError();

            // This will most likely not work before version 3.0
            _majorVersion = GL.GetInteger(GetPName.MajorVersion);
            _minorVersion = GL.GetInteger(GetPName.MinorVersion);

            // So, if the enums are not known, try to split up the version string
            if (GL.GetError() == ErrorCode.InvalidEnum)
            {
                try
                {
                    string[] parts = Version.Split('.', ' ');
                    _majorVersion = int.Parse(parts[0]);
                    _minorVersion = int.Parse(parts[1]);
                }
                catch
                {
                    _majorVersion = _minorVersion = 1; // assume version 1.1
                }
            }

            _createContextAttribsARB = GetProcAddress<CreateContextAttribsARBDelegate>("wglCreateContextAttribsARB");
            _getExtensionsStringARB = GetProcAddress<GetExtensionsStringARBDelegate>("wglGetExtensionsStringARB");
            MakeContextCurrentARB = GetProcAddress<MakeContextCurrentARBDelegate>("wglMakeContextCurrentARB");
            GetCurrentReadDCARB = GetProcAddress<GetCurrentReadDCARBDelegate>("wglGetCurrentReadDCARB");
            CreateBufferRegionARB = GetProcAddress<CreateBufferRegionARBDelegate>("wglCreateBufferRegionARB");
            DeleteBufferRegionARB = GetProcAddress<DeleteBufferRegionARBDelegate>("wglDeleteBufferRegionARB");
            SaveBufferRegionARB = GetProcAddress<SaveBufferRegionARBDelegate>("wglSaveBufferRegionARB");
            RestoreBufferRegionARB = GetProcAddress<RestoreBufferRegionARBDelegate>("wglRestoreBufferRegionARB");
            _getPixelFormatAttribivARBOut = GetProcAddress<GetPixelFormatAttribivARBOutDelegate>("wglGetPixelFormatAttribivARB");
            _getPixelFormatAttribivARBArray = GetProcAddress<GetPixelFormatAttribivARBArrayDelegate>("wglGetPixelFormatAttribivARB");
            _getPixelFormatAttribfvARBOut = GetProcAddress<GetPixelFormatAttribfvARBOutDelegate>("wglGetPixelFormatAttribfvARB");
            _getPixelFormatAttribfvARBArray = GetProcAddress<GetPixelFormatAttribfvARBArrayDelegate>("wglGetPixelFormatAttribfvARB");
            _choosePixelFormatARBOut = GetProcAddress<ChoosePixelFormatARBOutDelegate>("wglChoosePixelFormatARB");
            _choosePixelFormatARBArray = GetProcAddress<ChoosePixelFormatARBArrayDelegate>("wglChoosePixelFormatARB");
            _createPbufferARB = GetProcAddress<CreatePbufferARBDelegate>("wglCreatePbufferARB");
            GetPbufferDcarb = GetProcAddress<GetPbufferDCARBDelegate>("wglGetPbufferDCARB");
            ReleasePbufferDcarb = GetProcAddress<ReleasePbufferDCARBDelegate>("wglReleasePbufferDCARB");
            DestroyPbufferARB = GetProcAddress<DestroyPbufferARBDelegate>("wglDestroyPbufferARB");
            _queryPbufferARB = GetProcAddress<QueryPbufferARBDelegate>("wglQueryPbufferARB");
            _setPbufferAttribARB = GetProcAddress<SetPbufferAttribARBDelegate>("wglSetPbufferAttribARB");
            BindTexImageARB = GetProcAddress<BindTexImageARBDelegate>("wglBindTexImageARB");
            ReleaseTexImageARB = GetProcAddress<ReleaseTexImageARBDelegate>("wglReleaseTexImageARB");

            // Some extension functions
            GetSwapIntervalEXT = GetProcAddress<GetSwapIntervalEXTDelegate>("wglGetSwapIntervalEXT");
            SwapIntervalEXT = GetProcAddress<SwapIntervalEXTDelegate>("wglSwapIntervalEXT");
            CopyImageSubDataNv = GetProcAddress<CopyImageSubDataNvDelegate>("wglCopyImageSubDataNV");

            return MakeContextCurrentARB != null && _choosePixelFormatARBOut != null && _getPixelFormatAttribivARBOut != null;
        }
    }
}