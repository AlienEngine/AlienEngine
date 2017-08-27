using GLFWMonitor = AlienEngine.Core.Graphics.GLFW.GLFW.Monitor;

namespace AlienEngine.Core.Graphics
{
    public class Monitor
    {
        #region Static members
        /// <summary>
        /// Gets a NULL monitor's pointer.
        /// </summary>
        public static Monitor None
        {
            get { return new Monitor(GLFWMonitor.None); }
        }

        /// <summary>
        /// Gets the primary monitor.
        /// </summary>
        public static Monitor PrimaryMonitor
        {
            get { return new Monitor(GLFW.GLFW.GetPrimaryMonitor()); }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The internal monitor's pointer.
        /// </summary>
        internal readonly GLFWMonitor Handle;
        #endregion

        #region Private members
        /// <summary>
        /// Initialize a new <see cref="Monitor"/> instance with the given
        /// <see cref="Handle"/>.
        /// </summary>
        /// <param name="handle">The GLFW monitor.</param>
        private Monitor(GLFWMonitor handle)
        {
            Handle = handle;
        }
        #endregion
    }
}
