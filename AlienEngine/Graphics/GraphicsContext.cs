using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Graphics.OpenGL.Windows;
using AlienEngine.Core.Utils;

namespace AlienEngine.Core.Graphics
{
    public class GraphicsContext : IGraphicsContext
    {
        private readonly IGraphicsContext _graphicsContextImplementation;

        public ContextHandle DeviceHandle => _graphicsContextImplementation.DeviceHandle;

        public ContextHandle WindowHandle => _graphicsContextImplementation.WindowHandle;

        public bool IsPixelFormatSet => _graphicsContextImplementation.IsPixelFormatSet;

        public Exception LastPlatformException => _graphicsContextImplementation.LastPlatformException;

        public DevicePixelFormatCollection PixelsFormats => _graphicsContextImplementation.PixelsFormats;

        internal GraphicsContext(IntPtr window)
        {
            if (Platform.IsWindows)
                _graphicsContextImplementation = new WGLGraphicsContext(window);
            else
                throw new Exception();
        }

        public IntPtr CreateContext(IntPtr shared)
        {
            return _graphicsContextImplementation.CreateContext(shared);
        }

        public IntPtr CreateContextAttrib(IntPtr sharedContext, int[] attribsList, GraphicsApi api = GraphicsApi.OpenGL, int major = 3, int minor = 3, GraphicsProfile profile = GraphicsProfile.Core)
        {
            return _graphicsContextImplementation.CreateContextAttrib(sharedContext, attribsList, api, major, minor, profile);
        }

        public bool MakeCurrent(IntPtr context)
        {
            if (GraphicsManager.CurrentDeviceContext == _graphicsContextImplementation.DeviceHandle.Handle && GraphicsManager.CurrentOpenGLContext == context)
                return true;

            bool success = _graphicsContextImplementation.MakeCurrent(context);

            if (success)
                GL.LoadOpenGL();

            return success;
        }

        public bool DeleteContext(IntPtr context)
        {
            return _graphicsContextImplementation.DeleteContext(context);
        }

        public bool SwapBuffers()
        {
            return _graphicsContextImplementation.SwapBuffers();
        }

        public bool SwapInterval(int interval)
        {
            return _graphicsContextImplementation.SwapInterval(interval);
        }

        public void SetPixelFormat()
        {
            _graphicsContextImplementation.SetPixelFormat();
        }

        public void SetPixelFormat(DevicePixelFormat pixelFormat)
        {
            _graphicsContextImplementation.SetPixelFormat(pixelFormat);
        }

        public void ChoosePixelFormat(DevicePixelFormat pixelFormat)
        {
            _graphicsContextImplementation.ChoosePixelFormat(pixelFormat);
        }

        public void Dispose()
        {
            _graphicsContextImplementation.Dispose();
        }
    }

    internal interface IGraphicsContext : IDisposable
    {
        ContextHandle DeviceHandle { get; }

        ContextHandle WindowHandle { get; }

        bool IsPixelFormatSet { get; }

        Exception LastPlatformException { get; }

        DevicePixelFormatCollection PixelsFormats { get; }

        IntPtr CreateContext(IntPtr shared);
        
        IntPtr CreateContextAttrib(IntPtr sharedContext, int[] attribsList, GraphicsApi api, int major, int minor, GraphicsProfile profile);

        bool MakeCurrent(IntPtr context);

        bool DeleteContext(IntPtr context);

        bool SwapBuffers();

        bool SwapInterval(int interval);

        void SetPixelFormat();

        void SetPixelFormat(DevicePixelFormat pixelFormat);

        void ChoosePixelFormat(DevicePixelFormat pixelFormat);
    }

    internal abstract class BaseGrapicsContext : IGraphicsContext
    {
        private bool _isDisposed;

        protected ContextHandle DeviceHandleInternal;
        protected ContextHandle WindowHandleInternal;

        public ContextHandle DeviceHandle => DeviceHandleInternal;

        public ContextHandle WindowHandle => WindowHandleInternal;
        public abstract bool IsPixelFormatSet { get; }
        public abstract Exception LastPlatformException { get; }

        public abstract IntPtr CreateContext(IntPtr shared);
        public abstract bool MakeCurrent(IntPtr context);
        public abstract bool DeleteContext(IntPtr context);
        public abstract bool SwapBuffers();
        public abstract bool SwapInterval(int interval);
        public abstract void SetPixelFormat();
        public abstract void SetPixelFormat(DevicePixelFormat pixelFormat);
        public abstract void ChoosePixelFormat(DevicePixelFormat pixelFormat);
        public abstract IntPtr CreateContextAttrib(IntPtr sharedContext, int[] attribsList, GraphicsApi api, int major, int minor, GraphicsProfile profile);

        public bool Disposed => _isDisposed;
        public abstract DevicePixelFormatCollection PixelsFormats { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

    internal class WGLGraphicsContext : BaseGrapicsContext
    {
        private bool _isPixelFormatSet;

        private DevicePixelFormatCollection _pixelFormatCache;

        public override bool IsPixelFormatSet => _isPixelFormatSet;

        public override Exception LastPlatformException
        {
            get
            {
                Exception platformException = null;

                int win32Error = Marshal.GetLastWin32Error();
                if (win32Error != 0)
                    platformException = new Win32Exception(win32Error);

                return platformException;
            }
        }

        public WGLGraphicsContext(IntPtr window)
        {
            if (window == IntPtr.Zero)
                throw new ArgumentNullException(nameof(window));

            WindowHandleInternal = new ContextHandle(window);
            DeviceHandleInternal = (ContextHandle) WGL.GetDC(window);

            if (DeviceHandle == ContextHandle.Zero)
                throw new GraphicsContextException("Unable to get the device context.");
        }

        public override IntPtr CreateContext(IntPtr shared)
        {
            IntPtr renderContext = WGL.CreateContext(DeviceHandle.Handle);

            if (renderContext == IntPtr.Zero)
                throw new GraphicsContextException($"Unable to create a render context. The error code is: {Marshal.GetLastWin32Error()}");

            if (shared != IntPtr.Zero)
            {
                bool success = WGL.ShareLists(renderContext, shared);
                if (!success)
                    throw new GraphicsContextException($"Unable to share the created render context. The error code is: {Marshal.GetLastWin32Error()}");
            }

            return renderContext;
        }

        public override bool MakeCurrent(IntPtr context)
        {
            return WGL.MakeCurrent(DeviceHandle.Handle, context);
        }

        public override bool DeleteContext(IntPtr context)
        {
            if (context == IntPtr.Zero)
                throw new ArgumentException("Invalid given context to delete.", nameof(context));

            return WGL.DeleteContext(context);
        }

        public override bool SwapBuffers()
        {
            return WGL.SwapBuffers(DeviceHandle.Handle);
        }

        public override bool SwapInterval(int interval)
        {
            if (!WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.SwapControl))
                throw new InvalidOperationException($"The extension {WGL.EXT.SwapControl} isn't supported.");

            if (interval == -1 && !WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.SwapControlTear))
                throw new InvalidOperationException($"The extension {WGL.EXT.SwapControlTear} isn't supported.");

            return WGL.SwapIntervalEXT(interval);
        }

        /// <summary>
        /// Set the device pixel format.
        /// </summary>
        /// <param name="pixelFormat">
        /// A <see cref="DevicePixelFormat"/> that specifies the pixel format to set.
        /// </param>
        public override void ChoosePixelFormat(DevicePixelFormat pixelFormat)
        {
            if (pixelFormat == null)
                throw new ArgumentNullException(nameof(pixelFormat));

            if (IsPixelFormatSet)
                throw new InvalidOperationException("pixel format already set");

            // Choose pixel format
            int pixelFormatIndex = _choosePixelFormat(DeviceHandle.Handle, pixelFormat);

            // Set choosen pixel format
            WGL.PixelFormatDescriptor pDescriptor = WGL.PixelFormatDescriptor.Default;

            if (WGL.SetPixelFormat(DeviceHandle.Handle, pixelFormatIndex, ref pDescriptor) == false)
                throw new InvalidOperationException("Unable to set pixel format.", LastPlatformException);

            _isPixelFormatSet = true;
        }

        /// <summary>
        /// Set the device pixel format.
        /// </summary>
        /// <param name="pixelFormat">
        /// A <see cref="DevicePixelFormat"/> that specifies the pixel format to set.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown if <paramref name="pixelFormat"/> is null.
        /// </exception>
        public override void SetPixelFormat(DevicePixelFormat pixelFormat)
        {
            if (pixelFormat == null)
                throw new ArgumentNullException(nameof(pixelFormat));
            if (IsPixelFormatSet)
                throw new InvalidOperationException("pixel format already set");

            try
            {
                WGL.PixelFormatDescriptor pDescriptor = WGL.PixelFormatDescriptor.Default;

                // Note (from MSDN): Setting the pixel format of a window more than once can lead to significant complications for the Window Manager
                // and for multithread applications, so it is not allowed. An application can only set the pixel format of a window one time. Once a
                // window's pixel format is set, it cannot be changed.

                if (WGL.DescribePixelFormat(DeviceHandle.Handle, pixelFormat.FormatIndex, (uint) pDescriptor.nSize, out pDescriptor) == 0)
                    throw new InvalidOperationException($"unable to describe pixel format {pixelFormat.FormatIndex}", LastPlatformException);

                // Set choosen pixel format
                if (!WGL.SetPixelFormat(DeviceHandle.Handle, pixelFormat.FormatIndex, ref pDescriptor))
                    throw new InvalidOperationException($"unable to set pixel format {pixelFormat.FormatIndex}", LastPlatformException);
            }
            catch (InvalidOperationException)
            {
                // Try using default ChoosePixelFormat*
                SetPixelFormat();
            }

            _isPixelFormatSet = true;
        }

        public override void SetPixelFormat()
        {
            List<int> attribIList = new List<int>();
            List<float> attribFList = new List<float>();
            WGL.PixelFormatDescriptor pDescriptor = new WGL.PixelFormatDescriptor();
            uint countFormatAttribsValues;
            int[] choosenFormats = new int[4];

            // Let choose pixel formats
            if (!WGL.ChoosePixelFormatARB(DeviceHandle.Handle, attribIList.ToArray(), attribFList.ToArray(), choosenFormats, out countFormatAttribsValues))
            {
                Win32Exception innerException = new Win32Exception(Marshal.GetLastWin32Error());
                throw new InvalidOperationException($"unable to choose pixel format: {innerException.Message}", innerException);
            }

            // Set choosen pixel format
            if (WGL.SetPixelFormat(DeviceHandle.Handle, choosenFormats[0], ref pDescriptor) == false)
            {
                Win32Exception innerException = new Win32Exception(Marshal.GetLastWin32Error());
                throw new InvalidOperationException($"unable to set pixel format: {innerException.Message}", innerException);
            }
        }

        /// <summary>
        /// Creates a context, specifying attributes.
        /// </summary>
        /// <param name="sharedContext">
        /// A <see cref="IntPtr"/> that specify a context that will share objects with the returned one. If
        /// it is IntPtr.Zero, no sharing is performed.
        /// </param>
        /// <param name="attribsList">
        /// A <see cref="T:Int32[]"/> that specifies the attributes list.
        /// </param>
        /// <param name="api">
        /// A <see cref="GraphicsApi"/> that specifies the API to be implemented by the returned context. It can be null indicating the
        /// default API for this DeviceContext implementation. If it is possible, try to determine the API version also.
        /// </param>
        /// <param name="profile">
        /// A <see cref="GraphicsProfile"/> that specifies the profile to use when creating the render context.
        /// </param>
        /// <returns>
        /// A <see cref="IntPtr"/> that represents the handle of the created context. If the context cannot be
        /// created, it returns IntPtr.Zero.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown if <paramref name="attribsList"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Exception thrown if <paramref name="attribsList"/> length is zero or if the last item of <paramref name="attribsList"/>
        /// is not zero.
        /// </exception>
        public override IntPtr CreateContextAttrib(IntPtr sharedContext, int[] attribsList, GraphicsApi api, int major, int minor, GraphicsProfile profile)
        {
            if (!WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.CreateContext))
                throw new InvalidOperationException("WGL_ARB_create_context not supported");
            
            if (attribsList != null && attribsList.Length == 0)
                throw new ArgumentException("zero length array", nameof(attribsList));
            
            if (attribsList != null && attribsList[attribsList.Length - 1] != GL.NONE)
                throw new ArgumentException("not zero-terminated array", nameof(attribsList));

            // Defaults null attributes
            if (attribsList == null)
                attribsList = new[] {GL.NONE};

            IntPtr ctx;

            if (api != GraphicsApi.None)
            {
                List<int> adulteredAttribs = new List<int>(attribsList);

                // Support check
                switch (api)
                {
                    case GraphicsApi.OpenGL:
                        break;
                    case GraphicsApi.OpenGLEs1:
                    case GraphicsApi.OpenGLEs2:
                    case GraphicsApi.OpenGLSc2:
                        if (!WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.CreateContextESProfile))
                            throw new NotSupportedException("OpenGL ES API not supported");
                        break;
                    default:
                        throw new NotSupportedException($"'{api}' API not supported");
                }

                // Remove trailing 0
                if (adulteredAttribs.Count > 0 && adulteredAttribs[adulteredAttribs.Count - 1] == GL.NONE)
                    adulteredAttribs.RemoveAt(adulteredAttribs.Count - 1);

                // Add required attributes
                int profileMask = 0;

                switch (api)
                {
                    case GraphicsApi.OpenGL:
                        switch (profile)
                        {
                            case GraphicsProfile.Compatibility:
                                profileMask |= (int) WGL.ContextProfileMaskARB.ContextCompatibilityProfileBitARB;
                                break;
                            case GraphicsProfile.Core:
                                profileMask |= (int) WGL.ContextProfileMaskARB.ContextCoreProfileBitARB;
                                break;
                            default:
                                throw new NotSupportedException($"'{profile}' Profile not supported");
                        }

                        break;
                    case GraphicsApi.OpenGLEs1:
                        // Ignore API version: force always to 1.0
                        major = 1;
                        minor = 0;
                        profileMask |= (int) WGL.ContextProfileMaskARB.ContextEsProfileBitEXT;
                        break;
                    case GraphicsApi.OpenGLEs2:
                    case GraphicsApi.OpenGLSc2:
                        major = 2;
                        minor = 0;
                        profileMask |= (int) WGL.ContextProfileMaskARB.ContextEs2ProfileBitEXT;
                        break;
                    default:
                        throw new NotSupportedException($"'{api}' API not supported");
                }

                // Add/Replace attributes
                int majorVersionIndex, minorVersionIndex;

                if ((majorVersionIndex = adulteredAttribs.FindIndex(item => item == (int) WGL.ContextAttributeARB.ContextMajorVersionARB)) >= 0)
                    adulteredAttribs[majorVersionIndex + 1] = major;
                else
                    adulteredAttribs.AddRange(new[] {(int) WGL.ContextAttributeARB.ContextMajorVersionARB, major});

                if ((minorVersionIndex = adulteredAttribs.FindIndex(item => item == (int) WGL.ContextAttributeARB.ContextMinorVersionARB)) >= 0)
                    adulteredAttribs[minorVersionIndex + 1] = minor;
                else
                    adulteredAttribs.AddRange(new[] {(int) WGL.ContextAttributeARB.ContextMinorVersionARB, minor});

                if (profileMask != 0)
                {
                    int profileMaskIndex;
                    if ((profileMaskIndex = adulteredAttribs.FindIndex(item => item == (int) WGL.ContextAttributeARB.ContextProfileMaskARB)) >= 0)
                        adulteredAttribs[profileMaskIndex + 1] = profileMask;
                    else
                        adulteredAttribs.AddRange(new[] {(int) WGL.ContextAttributeARB.ContextProfileMaskARB, profileMask});
                }

                // Restore trailing 0
                adulteredAttribs.Add(GL.NONE);

                ctx = WGL.CreateContextAttribsARB(DeviceHandle.Handle, sharedContext, adulteredAttribs.ToArray());
            }
            else
            {
                ctx = WGL.CreateContextAttribsARB(DeviceHandle.Handle, sharedContext, attribsList);
            }

            if (ctx == IntPtr.Zero)
                throw LastPlatformException;

            return (ctx);
        }


        /// <summary>
        /// Get the pixel formats supported by this device.
        /// </summary>
        public override DevicePixelFormatCollection PixelsFormats
        {
            get
            {
                // Use cached pixel formats
                if (_pixelFormatCache != null)
                    return _pixelFormatCache;

                // Query pixel formats
                _pixelFormatCache = WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.PixelFormat) ? _getPixelFormatsARB() : _getPixelFormatsWin32();

                return _pixelFormatCache;
            }
        }

        private DevicePixelFormatCollection _getPixelFormatsARB()
        {
            // Get the number of pixel formats
            WGL.PixelFormatAttributeARB[] countFormatAttribsCodes = {WGL.PixelFormatAttributeARB.NumberPixelFormatsARB};
            int[] countFormatAttribsValues = new int[countFormatAttribsCodes.Length];

            WGL.GetPixelFormatAttribivARB(DeviceHandle.Handle, 1, 0, countFormatAttribsCodes, countFormatAttribsValues);

            // Request configurations
            List<WGL.PixelFormatAttributeARB> pixelFormatAttribsCodes = new List<WGL.PixelFormatAttributeARB>(12)
            {
                WGL.PixelFormatAttributeARB.SupportOpenglARB, // Required to be Gl.TRUE
                WGL.PixelFormatAttributeARB.AccelerationARB, // Required to be WGL.FULL_ACCELERATION or WGL.ACCELERATION_ARB
                WGL.PixelFormatAttributeARB.PixelTypeARB,
                WGL.PixelFormatAttributeARB.DrawToWindowARB,
                WGL.PixelFormatAttributeARB.DrawToBitmapARB,
                WGL.PixelFormatAttributeARB.DoubleBufferARB,
                WGL.PixelFormatAttributeARB.SwapMethodARB,
                WGL.PixelFormatAttributeARB.StereoARB,
                WGL.PixelFormatAttributeARB.ColorBitsARB,
                WGL.PixelFormatAttributeARB.DepthBitsARB,
                WGL.PixelFormatAttributeARB.StencilBitsARB
            };

            // Multisample extension
            if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.Multisample) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.Multisample))
            {
                pixelFormatAttribsCodes.Add(WGL.PixelFormatAttributeARB.SampleBuffersARB);
                pixelFormatAttribsCodes.Add(WGL.PixelFormatAttributeARB.SamplesARB);
            }

            int pixelFormatAttribMultisampleIndex = pixelFormatAttribsCodes.Count - 1;

            if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.PBuffer) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.PBuffer))
            {
                pixelFormatAttribsCodes.Add(WGL.PixelFormatAttributeARB.DrawToPbufferARB);
            }

            int pixelFormatAttribPBufferIndex = pixelFormatAttribsCodes.Count - 1;

            // Framebuffer sRGB extension
            if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.FramebufferSRGB) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.FramebufferSRGB))
                pixelFormatAttribsCodes.Add(WGL.PixelFormatAttributeARB.FramebufferSRGBCapableARB);
            int pixelFormatAttribFramebufferSrgbIndex = pixelFormatAttribsCodes.Count - 1;

            // Create pixel format collection
            DevicePixelFormatCollection pixelFormats = new DevicePixelFormatCollection();

            // Retrieve information about available pixel formats
            int[] pixelFormatAttribValues = new int[pixelFormatAttribsCodes.Count];

            for (int pixelFormatIndex = 1; pixelFormatIndex < countFormatAttribsValues[0]; pixelFormatIndex++)
            {
                DevicePixelFormat pixelFormat = new DevicePixelFormat();

                WGL.GetPixelFormatAttribivARB(DeviceHandle.Handle, pixelFormatIndex, 0, pixelFormatAttribsCodes.ToArray(), pixelFormatAttribValues);

                // Check minimum requirements
                if (pixelFormatAttribValues[0] != GL.TRUE)
                    continue; // No OpenGL support
                if (pixelFormatAttribValues[1] != (int) WGL.AccelerationModeARB.FullAccelerationARB)
                    continue; // No hardware acceleration

                switch ((WGL.PixelTypeARB) pixelFormatAttribValues[2])
                {
                    case WGL.PixelTypeARB.RGBAARB:
                    case WGL.PixelTypeARB.RGBAFloatARB:
                    case WGL.PixelTypeARB.RGBAUnsignedFloatEXT:
                        break;
                    default:
                        continue; // Ignored pixel type
                }

                // Collect pixel format attributes
                pixelFormat.FormatIndex = pixelFormatIndex;

                switch ((WGL.PixelTypeARB) pixelFormatAttribValues[2])
                {
                    case WGL.PixelTypeARB.RGBAARB:
                        pixelFormat.RgbaUnsigned = true;
                        break;
                    case WGL.PixelTypeARB.RGBAFloatARB:
                        pixelFormat.RgbaFloat = true;
                        break;
                    case WGL.PixelTypeARB.RGBAUnsignedFloatEXT:
                        pixelFormat.RgbaFloat = pixelFormat.RgbaUnsigned = true;
                        break;
                }

                pixelFormat.RenderWindow = pixelFormatAttribValues[3] == GL.TRUE;
                pixelFormat.RenderBuffer = pixelFormatAttribValues[4] == GL.TRUE;

                pixelFormat.DoubleBuffer = pixelFormatAttribValues[5] == GL.TRUE;
                pixelFormat.SwapMethod = pixelFormatAttribValues[6];
                pixelFormat.StereoBuffer = pixelFormatAttribValues[7] == GL.TRUE;

                pixelFormat.ColorBits = pixelFormatAttribValues[8];
                pixelFormat.DepthBits = pixelFormatAttribValues[9];
                pixelFormat.StencilBits = pixelFormatAttribValues[10];

                if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.Multisample) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.Multisample))
                {
                    Debug.Assert(pixelFormatAttribMultisampleIndex >= 0);
                    pixelFormat.MultisampleBits = pixelFormatAttribValues[pixelFormatAttribMultisampleIndex];
                }

                if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.PBuffer) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.PBuffer))
                {
                    Debug.Assert(pixelFormatAttribPBufferIndex >= 0);
                    pixelFormat.RenderPBuffer = pixelFormatAttribValues[pixelFormatAttribPBufferIndex] == GL.TRUE;
                }

                if (WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.ARB.FramebufferSRGB) || WGL.IsExtensionSupported(DeviceHandle.Handle, WGL.EXT.FramebufferSRGB))
                {
                    Debug.Assert(pixelFormatAttribFramebufferSrgbIndex >= 0);
                    pixelFormat.SRGBCapable = pixelFormatAttribValues[pixelFormatAttribFramebufferSrgbIndex] != 0;
                }

                pixelFormats.Add(pixelFormat);
            }

            return pixelFormats;
        }

        private DevicePixelFormatCollection _getPixelFormatsWin32()
        {
            DevicePixelFormatCollection pixelFormats = new DevicePixelFormatCollection();
            WGL.PixelFormatDescriptor pixelDescr;

            int pixelFormatsCount = WGL.DescribePixelFormat(DeviceHandle.Handle, 0, 0, out pixelDescr);

            pixelDescr = WGL.PixelFormatDescriptor.Default;
            for (int i = 1; i <= pixelFormatsCount; i++)
            {
                WGL.DescribePixelFormat(DeviceHandle.Handle, i, (uint) pixelDescr.nSize, out pixelDescr);

                if ((pixelDescr.dwFlags & WGL.PixelFormatDescriptorFlags.SupportOpenGL) == 0)
                    continue;

                DevicePixelFormat pixelFormat = new DevicePixelFormat
                {
                    FormatIndex = i,
                    RgbaUnsigned = true,
                    RgbaFloat = false,
                    RenderWindow = true,
                    RenderBuffer = false,
                    DoubleBuffer = (pixelDescr.dwFlags & WGL.PixelFormatDescriptorFlags.DoubleBuffer) != 0,
                    SwapMethod = 0,
                    StereoBuffer = (pixelDescr.dwFlags & WGL.PixelFormatDescriptorFlags.Stereo) != 0,
                    ColorBits = pixelDescr.cColorBits,
                    DepthBits = pixelDescr.cDepthBits,
                    StencilBits = pixelDescr.cStencilBits,
                    MultisampleBits = 0,
                    RenderPBuffer = false,
                    SRGBCapable = false
                };

                pixelFormats.Add(pixelFormat);
            }

            return pixelFormats;
        }

        /// <summary>
        /// Set the device pixel format.
        /// </summary>
        /// <param name="deviceContext"></param>
        /// <param name="pixelFormat">
        /// A <see cref="DevicePixelFormat"/> that specifies the pixel format to set.
        /// </param>
        private int _choosePixelFormat(IntPtr deviceContext, DevicePixelFormat pixelFormat)
        {
            if (pixelFormat == null)
                throw new ArgumentNullException(nameof(pixelFormat));
            Dictionary<WGL.PixelFormatAttributeARB, object> pAttributes = new Dictionary<WGL.PixelFormatAttributeARB, object>();
            uint countFormatAttribsValues;
            int[] choosenFormats = new int[4];
            pAttributes[WGL.PixelFormatAttributeARB.SupportOpenglARB] = true;
            if (pixelFormat.RenderWindow)
                pAttributes[WGL.PixelFormatAttributeARB.DrawToWindowARB] = true;
            if (pixelFormat.RenderPBuffer)
                pAttributes[WGL.PixelFormatAttributeARB.DrawToPbufferARB] = true;
            if (pixelFormat.RgbaUnsigned)
                pAttributes[WGL.PixelFormatAttributeARB.PixelTypeARB] = WGL.PixelTypeARB.RGBAARB;
            if (pixelFormat.RgbaFloat)
                pAttributes[WGL.PixelFormatAttributeARB.PixelTypeARB] = WGL.PixelTypeARB.RGBAFloatARB;
            if (pixelFormat.ColorBits > 0)
                pAttributes[WGL.PixelFormatAttributeARB.ColorBitsARB] = pixelFormat.ColorBits;
            if (pixelFormat.DepthBits > 0)
                pAttributes[WGL.PixelFormatAttributeARB.DepthBitsARB] = pixelFormat.DepthBits;
            if (pixelFormat.StencilBits > 0)
                pAttributes[WGL.PixelFormatAttributeARB.StencilBitsARB] = pixelFormat.StencilBits;
            if (pixelFormat.DoubleBuffer)
                pAttributes[WGL.PixelFormatAttributeARB.DoubleBufferARB] = 1;

            // Let choose pixel formats
            if (!WGL.ChoosePixelFormatARB(deviceContext, pAttributes, choosenFormats, out countFormatAttribsValues))
                throw new InvalidOperationException("unable to choose pixel format", LastPlatformException);
            return choosenFormats[0];
        }

        protected override void Dispose(bool disposing)
        {
            if (DeviceHandleInternal != ContextHandle.Zero)
            {
                WGL.ReleaseDC(WindowHandleInternal.Handle, DeviceHandleInternal.Handle);
                DeviceHandleInternal = ContextHandle.Zero;
                WindowHandleInternal = ContextHandle.Zero;
            }

            base.Dispose(disposing);
        }
    }

    public class GraphicsContextException : Exception
    {
        public GraphicsContextException(string message) : base(message)
        {
        }
    }
}