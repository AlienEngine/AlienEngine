using AlienEngine.Core.Audio;
using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core
{
    /// <summary>
    /// AlienEngine Manager.
    /// </summary>
    public static class Engine
    {
        private static bool _started;
        private static AudioContext _audioContext;

        /// <summary>
        /// Checks if the engine has already started.
        /// </summary>
        public static bool HasStarted => _started;

        /// <summary>
        /// Initialize the manager.
        /// </summary>
        static Engine()
        {
            _started = false;
        }

        /// <summary>
        /// Start the engine. Load common libraries and
        /// initialize graphics and audio contexts.
        /// </summary>
        public static void Start()
        {
            if (!_started)
            {
                // --------------------
                // OpenGL
                // --------------------
                // Initialize OpenGL
                GL.LoadOpenGL();
                // --------------------

                // --------------------
                // DevIL
                // --------------------
                // Initialize DevIL
                IL.Initialize();
                ILU.Initialize();
                // --------------------

                // --------------------
                // OpenAL
                // --------------------
                // Initialize OpenAL and EFX
                _audioContext = new AudioContext();
                if (!_audioContext.IsCurrent)
                    _audioContext.MakeCurrent();
                // --------------------
                // Disable OpenAL rolloff algorithms
                AL.DistanceModel(ALDistanceModel.None);
                // --------------------

                _started = true;
            }
        }

        /// <summary>
        /// Stop the engine. Free all managed and unmanaged resources
        /// used during the game.
        /// </summary>
        public static void Stop()
        {
            // --------------------
            // DevIL
            // --------------------
            // Shutdown DevIL
            IL.Shutdown();
            // --------------------

            // Dispose all used (managed or unmanaged) resources
            ResourcesManager.DisposeResources();
        }
    }
}
