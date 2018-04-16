using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AlienEngine.Core.Graphics.OpenGL.Windows
{
    public static partial class WGL
    {
        /// <summary>
        /// Structure to describe the pixel format of a drawing surface.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PixelFormatDescriptor
        {
            public static PixelFormatDescriptor Default = new PixelFormatDescriptor(24);

            #region Constructors

            /// <summary>
            /// Construct a pixel format descriptor.
            /// </summary>
            /// <param name="colorBits">
            /// Specifies the number of color bitplanes in each color buffer. It is the size of the color buffer, excluding the alpha
            /// bitplanes.
            /// </param>
            public PixelFormatDescriptor(byte colorBits)
            {
                nVersion = 1;
                nSize = (short) Marshal.SizeOf(typeof(PixelFormatDescriptor));

                iLayerType = PixelFormatDescriptorLayerType.MainPlane;
                dwFlags = PixelFormatDescriptorFlags.SupportOpenGL | PixelFormatDescriptorFlags.DrawToWindow | PixelFormatDescriptorFlags.DoubleBuffer;
                iPixelType = DescriptorPixelType.RGBA;

                dwLayerMask = 0;
                dwVisibleMask = 0;
                dwDamageMask = 0;
                cAuxBuffers = 0;
                bReserved = 0;

                cColorBits = colorBits;

                cRedBits = 0;
                cRedShift = 0;
                cGreenBits = 0;
                cGreenShift = 0;
                cBlueBits = 0;
                cBlueShift = 0;
                cAlphaBits = 0;
                cAlphaShift = 0;
                cDepthBits = 0;
                cStencilBits = 0;
                cAccumBits = 0;
                cAccumRedBits = 0;
                cAccumGreenBits = 0;
                cAccumBlueBits = 0;
                cAccumAlphaBits = 0;
            }

            #endregion

            #region Structure

            /// <summary>
            /// Specifies the size of this data structure. This value should be set to <c>sizeof(PixelFormatDescriptor)</c>.
            /// </summary>
            public short nSize;

            /// <summary>
            /// Specifies the version of this data structure. This value should be set to 1.
            /// </summary>
            public short nVersion;

            /// <summary>
            /// A set of bit flags that specify properties of the pixel buffer. The properties are generally not mutually exclusive;
            /// you can set any combination of bit flags, with the exceptions noted.
            /// </summary>
            public PixelFormatDescriptorFlags dwFlags;

            /// <summary>
            /// Specifies the type of pixel data. The following types are defined.
            /// </summary>
            public DescriptorPixelType iPixelType;

            /// <summary>
            /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size
            /// of the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the
            /// color-index buffer.
            /// </summary>
            public byte cColorBits;

            /// <summary>
            /// Specifies the number of red bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cRedBits;

            /// <summary>
            /// Specifies the shift count for red bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cRedShift;

            /// <summary>
            /// Specifies the number of green bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cGreenBits;

            /// <summary>
            /// Specifies the shift count for green bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cGreenShift;

            /// <summary>
            /// Specifies the number of blue bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cBlueBits;

            /// <summary>
            /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cBlueShift;

            /// <summary>
            /// Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public byte cAlphaBits;

            /// <summary>
            /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public byte cAlphaShift;

            /// <summary>
            /// Specifies the total number of bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumBits;

            /// <summary>
            /// Specifies the number of red bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumRedBits;

            /// <summary>
            /// Specifies the number of green bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumGreenBits;

            /// <summary>
            /// Specifies the number of blue bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumBlueBits;

            /// <summary>
            /// Specifies the number of alpha bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumAlphaBits;

            /// <summary>
            /// Specifies the depth of the depth (z-axis) buffer.
            /// </summary>
            public byte cDepthBits;

            /// <summary>
            /// Specifies the depth of the stencil buffer.
            /// </summary>
            public byte cStencilBits;

            /// <summary>
            /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported.
            /// </summary>
            public byte cAuxBuffers;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>Specifies the type of layer.</remarks>
            public PixelFormatDescriptorLayerType iLayerType;

            /// <summary>
            /// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 overlay planes and
            /// bits 4 through 7 specify up to 15 underlay planes.
            /// </summary>
            public byte bReserved;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            public int dwLayerMask;

            /// <summary>
            /// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA, <b>dwVisibleMask</b>
            /// is a transparent RGB color value. When the pixel type is color index, it is a transparent index value.
            /// </summary>
            public int dwVisibleMask;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            public int dwDamageMask;

            #endregion

            #region Object Overrides

            ///<summary>
            /// Converts this PixelFormatDescriptor into a human-legible string representation.
            ///</summary>
            ///<returns>
            /// The string representation of this instance.
            ///</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("PixelFormatDescriptor={");
                sb.AppendFormat("PixelType={0},", iPixelType);
                if (cColorBits != 0)
                    sb.AppendFormat("ColorBits={0},", cColorBits);
                if (cDepthBits != 0)
                    sb.AppendFormat("DepthBits={0},", cDepthBits);
                if (cStencilBits != 0)
                    sb.AppendFormat("StencilBits={0},", cStencilBits);
                sb.AppendFormat("Flags={0},", dwFlags);
                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return (sb.ToString());
            }

            #endregion
        }

        /// <summary>
        /// Describes the pixel format of a drawing surface.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct LayerPlaneDescriptor
        {
            /// <summary>
            /// Specifies the size of this data structure. Set this value to Marshal.SizeOf(new LayerPlaneDescriptor())=32.
            /// </summary>
            public ushort nSize;

            /// <summary>
            /// Specifies the version of this data structure. Set this value to 1.
            /// </summary>
            public ushort nVersion;

            /// <summary>
            /// A set of bit flags that specify properties of the layer plane.
            /// </summary>
            public LayerPlaneDescriptorFlags dwFlags;

            /// <summary>
            /// Specifies the type of pixel data.
            /// </summary>
            public DescriptorPixelType iPixelType;

            /// <summary>
            /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size of the color buffer,
            /// excluding the alpha bitplanes. For color-index pixels, it is the size of the color-index buffer.
            /// </summary>
            public byte cColorBits;

            /// <summary>
            /// Specifies the number of red bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cRedBits;

            /// <summary>
            /// Specifies the shift count for red bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cRedShift;

            /// <summary>
            /// Specifies the number of green bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cGreenBits;

            /// <summary>
            /// Specifies the shift count for green bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cGreenShift;

            /// <summary>
            /// Specifies the number of blue bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cBlueBits;

            /// <summary>
            /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
            /// </summary>
            public byte cBlueShift;

            /// <summary>
            /// Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported by the GDI.
            /// </summary>
            public byte cAlphaBits;

            /// <summary>
            /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported by the GDI.
            /// </summary>
            public byte cAlphaShift;

            /// <summary>
            /// Specifies the total number of bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumBits;

            /// <summary>
            /// Specifies the number of red bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumRedBits;

            /// <summary>
            /// Specifies the number of green bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumGreenBits;

            /// <summary>
            /// Specifies the number of blue bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumBlueBits;

            /// <summary>
            /// Specifies the number of alpha bitplanes in the accumulation buffer.
            /// </summary>
            public byte cAccumAlphaBits;

            /// <summary>
            /// Specifies the depth of the depth (z-axis) buffer.
            /// </summary>
            public byte cDepthBits;

            /// <summary>
            /// Specifies the depth of the stencil buffer.
            /// </summary>
            public byte cStencilBits;

            /// <summary>
            /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported by the GDI.
            /// </summary>
            public byte cAuxBuffers;

            /// <summary>
            /// Specifies the layer plane number. Positive number are overlay planes, negative numbers are underlay planes.
            /// </summary>
            public sbyte iLayerPlane;

            /// <summary>
            /// Not used. Must be zero.
            /// </summary>
            public byte bReserved;

            /// <summary>
            /// When the <see cref="LayerPlaneDescriptorFlags.Transparent"/> flag is set, specifies the transparent color or index value. Typically the value is zero.
            /// </summary>
            public uint crTransparent;
        }

        /// <summary>
        /// Structure for specifying for (layered) buffer swap operations.
        /// </summary>
        public struct WGLSwap
        {
            /// <summary>
            /// The handle to the device context.
            /// </summary>
            public IntPtr Handle;

            /// <summary>
            /// <see cref="PixelFormatDescriptorLayerType"/>-bitmask specifying the planes to be swapped.
            /// </summary>
            public PixelFormatDescriptorLayerType Flags;
        }
    }
}