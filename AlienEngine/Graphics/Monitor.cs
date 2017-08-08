using AlienEngine.Core.Graphics.GLFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get { return new Monitor(GLFW.GLFW.Monitor.None); }
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
        internal readonly GLFW.GLFW.Monitor Handle;
        #endregion

        #region Private members
        private Monitor(GLFW.GLFW.Monitor handle)
        {
            Handle = handle;
        }
        #endregion
    }
}
