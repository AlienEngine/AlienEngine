namespace AlienEngine.Core.Graphics
{
    public class DevicePixelFormat
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public DevicePixelFormat()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colorBits"></param>
        public DevicePixelFormat(int colorBits)
        {
            RgbaUnsigned = true;
            RenderWindow = true;
            ColorBits = colorBits;
        }

        #endregion

        #region Format Identification

        /// <summary>
        /// Pixel format index.
        /// </summary>
        public int FormatIndex;

        #endregion

        #region Pixel Type

        /// <summary>
        /// Flag indicating whether this pixel format provide canonical (normalized) unsigned integer RGBA color.
        /// </summary>
        public bool RgbaUnsigned;

        /// <summary>
        /// Flag indicating whether this pixel format provide RGBA color composed by single-precision floating-point.
        /// </summary>
        public bool RgbaFloat;

        #endregion

        #region Surfaces

        /// <summary>
        /// Pixel format can be used for rendering on windows.
        /// </summary>
        public bool RenderWindow;

        /// <summary>
        /// Pixel format can be used for rendering on memory buffers.
        /// </summary>
        public bool RenderBuffer;

        /// <summary>
        /// Pixel format can be used for rendering on pixel buffer objects.
        /// </summary>
        public bool RenderPBuffer;

        #endregion

        #region Double Buffering

        /// <summary>
        /// Pixel format support double buffering.
        /// </summary>
        public bool DoubleBuffer;

        /// <summary>
        /// Method used for swapping back buffers (WGL only).
        /// </summary>
        /// <remarks>
        /// It can assume the values Wgl.SWAP_EXCHANGE, SWAP_COPY, or SWAP_UNDEFINED in the case DoubleBuffer is false.
        /// </remarks>
        public int SwapMethod;

        /// <summary>
        /// Pixel format support stereo buffering.
        /// </summary>
        public bool StereoBuffer;

        #endregion

        #region Buffers bits

        /// <summary>
        /// Color bits (without alpha).
        /// </summary>
        public int ColorBits;

        /// <summary>
        /// Red bits.
        /// </summary>
        public int RedBits;

        /// <summary>
        /// Green bits.
        /// </summary>
        public int GreenBits;

        /// <summary>
        /// Blue bits.
        /// </summary>
        public int BlueBits;

        /// <summary>
        /// Alpha bits.
        /// </summary>
        public int AlphaBits;

        /// <summary>
        /// Depth buffer bits.
        /// </summary>
        public int DepthBits;

        /// <summary>
        /// Stencil buffer bits.
        /// </summary>
        public int StencilBits;

        /// <summary>
        /// Multisample bits.
        /// </summary>
        public int MultisampleBits;

        /// <summary>
        /// sRGB conversion capability.
        /// </summary>
        public bool SRGBCapable;

        #endregion

        #region Copy

        /// <summary>
        /// Copy this DevicePixelFormat
        /// </summary>
        /// <returns>
        /// It returns a <see cref="DevicePixelFormat"/> equals to this DevicePixelFormat.
        /// </returns>
        public DevicePixelFormat Copy()
        {
            DevicePixelFormat copy = (DevicePixelFormat) MemberwiseClone();

            return (copy);
        }

        #endregion
    }
}