using AlienEngine.Core;
using AlienEngine.Core.Graphics.GLFW;

namespace AlienEngine
{
    /// <summary>
    /// Describes a single screen mode of a <see cref="Monitor"/>.
    /// </summary>
    public struct ScreenMode
    {
        #region Fields

        /// <summary>
        /// The width of the resolution.
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// The height of the resolution.
        /// </summary>
        public readonly int Height;

        /// <summary>
        /// The refresh rate in Hz.
        /// </summary>
        public readonly int RefreshRate;

        /// <summary>
        /// The bit depth of the red channel of the screen mode.
        /// </summary>
        public readonly int RedBits;

        /// <summary>
        /// The bit depth of the green channel of the screen mode.
        /// </summary>
        public readonly int GreenBits;

        /// <summary>
        /// The bit depth of the blue channel of the screen mode.
        /// </summary>
        public readonly int BlueBits;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="ScreenMode"/>.
        /// </summary>
        /// <param name="width">The width of the screen mode.</param>
        /// <param name="height">The height of the screen mode.</param>
        /// <param name="refreshRate">The refresf rate of the screen mode.</param>
        /// <param name="redBits">The bith depth of the red channel of the screen mode.</param>
        /// <param name="blueBits">The bith depth of the blue channel of the screen mode.</param>
        /// <param name="greenBits">The bith depth of the green channel of the screen mode.</param>
        private ScreenMode(int width, int height, int refreshRate, int redBits, int blueBits, int greenBits)
        {
            Width = width;
            Height = height;
            RefreshRate = refreshRate;
            RedBits = redBits;
            BlueBits = blueBits;
            GreenBits = greenBits;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets the resoluion of this <see cref="ScreenMode"/>.
        /// </summary>
        public Sizei Resolution => new Sizei(Width, Height);
        
        /// <summary>
        /// Gets the hash code of this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                hash = hash * 23 + RedBits.GetHashCode();
                hash = hash * 23 + GreenBits.GetHashCode();
                hash = hash * 23 + BlueBits.GetHashCode();
                hash = hash * 23 + RefreshRate.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region Static members

        /// <summary>
        /// Gets the supported screen modes of a <see cref="Monitor"/>.
        /// </summary>
        /// <param name="monitor">The monitor.</param>
        /// <returns>An array of <see cref="ScreenMode"/>.</returns>
        public static ScreenMode[] GetScreenModes(Monitor monitor)
        {
            var modes = GLFW.GetVideoModes(monitor.Handle);
            var screens = new ScreenMode[modes.Length];

            for (int i = 0, l = modes.Length; i < l; i++)
            {
                var currentMode = modes[i];
                screens[i] = new ScreenMode(currentMode.Width, currentMode.Height, currentMode.RefreshRate,
                    currentMode.RedBits, currentMode.BlueBits, currentMode.RedBits);
            }

            return screens;
        }

        #endregion
    }
}