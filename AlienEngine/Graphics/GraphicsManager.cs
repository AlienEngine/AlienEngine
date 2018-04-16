using System;
using AlienEngine.Core.Graphics.OpenGL.Windows;

namespace AlienEngine.Core.Graphics
{
    public static class GraphicsManager
    {
        /// <summary>
        /// Gets the cuurent OpenGL context.
        /// </summary>
        public static IntPtr CurrentOpenGLContext
        {
            get
            {
                if (Platform.IsWindows)
                    return WGL.GetCurrentContext();
                
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the current device context.
        /// </summary>
        public static IntPtr CurrentDeviceContext
        {
            get
            {
                if (Platform.IsWindows)
                    return WGL.GetCurrentDC();
                
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a graphics context for the given window handle.
        /// </summary>
        /// <param name="window">The pointer to the window handle.</param>
        /// <returns>The created graphics context.</returns>
        public static GraphicsContext CreateGraphicsContext(IntPtr window)
        {
            return new GraphicsContext(window);
        }

        /// <summary>
        /// Gets the device context of the given window handle.
        /// </summary>
        /// <param name="window">The pointer to the window handle.</param>
        /// <returns>The pointer to the device context.</returns>
        public static IntPtr GetDeviceContext(IntPtr window)
        {
            if (Platform.IsWindows)
                return WGL.GetDC(window);
            
            return IntPtr.Zero;
        }

        /// <summary>
        /// Releases a device context.
        /// </summary>
        /// <param name="window">The pointer to the window handle.</param>
        /// <param name="device">The pointer to the device context.</param>
        /// <returns><b>true</b> if succeed, <b>false</b> otherwise.</returns>
        public static bool ReleaseDeviceContext(IntPtr window, IntPtr device)
        {
            if (Platform.IsWindows)
                return WGL.ReleaseDC(window, device);

            return false;
        }
        
        /// <summary>
        /// Creates a render context on the given device context.
        /// </summary>
        /// <param name="device">The pointer device context.</param>
        /// <returns>The pointer to the render context.</returns>
        public static IntPtr CreateContext(IntPtr device)
        {
            if (Platform.IsWindows)
                return WGL.CreateContext(device);

            return device;
        }

        /// <summary>
        /// Makes a render context current.
        /// </summary>
        /// <param name="device">The pointer to the device context.</param>
        /// <param name="context">The pointer to the render context.</param>
        /// <returns><b>true</b> if succeed, <b>false</b> otherwise.</returns>
        public static bool MakeCurrent(IntPtr device, IntPtr context)
        {
            if (Platform.IsWindows)
                return WGL.MakeCurrent(device, context);

            return false;
        }

        /// <summary>
        /// Clears the current render context.
        /// </summary>
        /// <returns><b>true</b> if succeed, <b>false</b> otherwise.</returns>
        public static bool ClearCurrentContext()
        {
            return MakeCurrent(IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Deletes the given render context.
        /// </summary>
        /// <param name="context">The render context.</param>
        /// <returns><b>true</b> if succeed, <b>false</b> otherwise.</returns>
        public static bool DeleteContext(IntPtr context)
        {
            if (Platform.IsWindows)
                return WGL.DeleteContext(context);

            return false;
        }

        public static int ChoosePixelFormat(IntPtr dc, ref WGL.PixelFormatDescriptor pfd)
        {
            if (Platform.IsWindows)
                return WGL.ChoosePixelFormat(dc, ref pfd);

            return 0;
        }

        public static int DescribePixelFormat(IntPtr dc, int pfd, uint size, out WGL.PixelFormatDescriptor descriptor)
        {
            descriptor = WGL.PixelFormatDescriptor.Default;
            
            if (Platform.IsWindows)
                return WGL.DescribePixelFormat(dc, pfd, size, out descriptor);

            return 0;
        }

        public static bool SetPixelFormat(IntPtr dc, int pf, ref WGL.PixelFormatDescriptor pfd)
        {
            if (Platform.IsWindows)
                return WGL.SetPixelFormat(dc, pf, ref pfd);

            return false;
        }
    }
}