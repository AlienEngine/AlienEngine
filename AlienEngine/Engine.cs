using System.Collections.Generic;
using AlienEngine.Core.Audio;
using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Graphics.DevIL.Unmanaged;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Physics.BroadPhaseEntries;
using AlienEngine.Core.Resources;
using AlienEngine.Core.Threading;

namespace AlienEngine.Core
{
    /// <summary>
    /// AlienEngine Manager.
    /// </summary>
    public static class Engine
    {
        private static bool _started;
        private static AudioContext _audioContext;

        private static List<Task> _physicsTasks;
        private static List<Task> _renderingTasks;
        private static List<Task> _audioTasks;

        private static Worker _physicsWorker;
        private static Worker _renderingWorker;
        private static Worker _audioWorker;
        
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
            
            _renderingTasks = new List<Task>();
            _physicsTasks = new List<Task>();
            _audioTasks = new List<Task>();
            
            _renderingWorker = new Worker(new WorkStealingScheduler(1), (int)WorkerItemIndex.Renderer);
            _physicsWorker = new Worker(new WorkStealingScheduler(1), (int)WorkerItemIndex.Physics);
            _audioWorker = new Worker(new WorkStealingScheduler(1), (int)WorkerItemIndex.Audio);
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
