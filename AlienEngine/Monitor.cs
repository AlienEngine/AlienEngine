using AlienEngine.Core.Graphics.GLFW;
using GLFWMonitor = AlienEngine.Core.Graphics.GLFW.GLFW.Monitor;

namespace AlienEngine.Core
{
    /// <summary>
    /// Handle and manage monitors.
    /// </summary>
    public class Monitor
    {
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

        #region Public members

        /// <summary>
        /// Gets the name of this <see cref="Monitor"/>.
        /// </summary>
        public string Name => GLFW.GetMonitorName(Handle);

        #endregion

        #region Static members

        /// <summary>
        /// Gets a NULL monitor's pointer.
        /// </summary>
        public static Monitor None => new Monitor(GLFWMonitor.None);

        /// <summary>
        /// Gets the primary monitor.
        /// </summary>
        public static Monitor PrimaryMonitor => new Monitor(GLFW.GetPrimaryMonitor());

        /// <summary>
        /// Gets the total number of monitors.
        /// </summary>
        public static int MonitorsCount
        {
            get
            {
                var monitors = GetMonitors();
                return monitors.Length;
            }
        }

        /// <summary>
        /// Get all monitors connected.
        /// </summary>
        /// <returns>An array of <see cref="Monitor"/>.</returns>
        public static Monitor[] GetMonitors()
        {
            var glfwMonitors = GLFW.GetMonitors();
            var monitors = new Monitor[glfwMonitors.Length];

            for (int i = 0, l = glfwMonitors.Length; i < l; i++)
            {
                monitors[i] = new Monitor(glfwMonitors[i]);
            }

            return monitors;
        }

        #endregion
    }
}