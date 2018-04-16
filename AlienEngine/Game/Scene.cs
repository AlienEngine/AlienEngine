using AlienEngine.Core.Physics;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Threading;
using System;
using System.Collections.Generic;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Game
{
    public abstract class Scene : IDisposable
    {
        /// <summary>
        /// The name of the scene.
        /// </summary>
        private string _name;

        /// <summary>
        /// A collection of all <see cref="GameElement"/>s in the <see cref="Scene"/>.
        /// </summary>
        private GameElementCollection _gameElements;

        /// <summary>
        /// A collection of all <see cref="GameElement"/>s with <see cref="Light"/>
        /// component.
        /// </summary>
        private GameElementCollection _lights;

        /// <summary>
        /// A collection of all <see cref="GameElement"/>s with <see cref="Camera"/>
        /// component.
        /// </summary>
        private GameElementCollection _cameras;

        /// <summary>
        /// A collection of all <see cref="GameElement"/>s with <see cref="AudioSource"/>
        /// component.
        /// </summary>
        private GameElementCollection _audioSources;

        /// <summary>
        /// A collection of all <see cref="GameElement"/>s with <see cref="AudioReverbZone"/>
        /// component.
        /// </summary>
        private GameElementCollection _audioReverbZones;

        /// <summary>
        /// The unique <see cref="GameElement"/> with <see cref="AlienEngine.AudioListener"/>
        /// component.
        /// </summary>
        /// <remarks>
        /// If more than one audio listener exist in the scene, only the last one created is used.
        /// </remarks>
        private GameElement _audioListener;

        /// <summary>
        /// The unique <see cref="GameElement"/> with <see cref="Camera"/>
        /// component.
        /// </summary>
        /// <remarks>
        /// If more than one camera exist in the scene, only the camera set to current is used.
        /// </remarks>
        private GameElement _primaryCamera;

        /// <summary>
        /// The handler of all rigid bodies.
        /// </summary>
        private Space _space;

        /// <summary>
        /// The multi threading helper for physics simulations.
        /// </summary>
        private ParallelLooper _parallelLooper;

        /// <summary>
        /// The list of <see cref="FrameScript"/> registered in this scene.
        /// </summary>
        private List<FrameScript> _frameScripts;

        /// <summary>
        /// The list of <see cref="RenderScript"/> registered in this scene.
        /// </summary>
        private List<RenderScript> _renderScripts;

        /// <summary>
        /// Defines if this <see cref="Scene"/> has started or not.
        /// </summary>
        private bool _started;

        /// <summary>
        /// The name of this <see cref="Scene"/>.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/>.
        /// </summary>
        public GameElementCollection GameElements => _gameElements;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="Light"/> component.
        /// </summary>
        public GameElementCollection Lights => _lights;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="Camera"/> component.
        /// </summary>
        public GameElementCollection Cameras => _cameras;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="AudioSource"/> component.
        /// </summary>
        public GameElementCollection AudioSources => _audioSources;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="AudioReverbZone"/> component.
        /// </summary>
        public GameElementCollection AudioReverbZones => _audioReverbZones;

        /// <summary>
        /// Gets the unique <see cref="GameElement"/> in the
        /// current <see cref="Scene"/> which has a enable
        /// <see cref="AlienEngine.AudioListener"/> component.
        /// </summary>
        public GameElement AudioListener => _audioListener;

        /// <summary>
        /// Gets the unique <see cref="GameElement"/> in the
        /// current <see cref="Scene"/> which has a enabled
        /// <see cref="Camera"/> component.
        /// </summary>
        public GameElement PrimaryCamera => _primaryCamera;

        /// <summary>
        /// The list of <see cref="FrameScript"/> registered in this <see cref="Scene"/>.
        /// </summary>
        public List<FrameScript> FrameScripts => _frameScripts;

        /// <summary>
        /// The list of <see cref="RenderScript"/> registered in this <see cref="Scene"/>.
        /// </summary>
        public List<RenderScript> RenderScripts => _renderScripts;

        /// <summary>
        /// Defines if this <see cref="Scene"/> has started or not.
        /// </summary>
        public bool Started => _started;

        /// <summary>
        /// Event triggered when a <see cref="GameElement"/> is added in this <see cref="Scene"/>.
        /// </summary>
        public event Action<Scene, GameElement> GameElementAdded;

        /// <summary>
        /// Event triggered when a <see cref="GameElement"/> is removed in this <see cref="Scene"/>.
        /// </summary>
        public event Action<Scene, GameElement> GameElementRemoved;

        /// <summary>
        /// Creates a new scene.
        /// </summary>
        protected Scene(string name)
        {
            _name = name;

            // Default camera
            GameElement _dummyCamera = new GameElement("_dummy_generated_camera");
            _dummyCamera.AttachComponent(Camera.None);

            // Initializing
            _gameElements = new GameElementCollection();
            _lights = new GameElementCollection();
            _cameras = new GameElementCollection();
            _audioSources = new GameElementCollection();
            _audioReverbZones = new GameElementCollection();
            _audioListener = null;
            _primaryCamera = _dummyCamera;
            _frameScripts = new List<FrameScript>();
            _renderScripts = new List<RenderScript>();

            // Register this in the resource manager
            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Adds a <see cref="GameElement"/> in the scene.
        /// </summary>
        /// <param name="gameElement">The <see cref="GameElement"/> to add.</param>
        public void AddGameElement(GameElement gameElement)
        {
            if (_gameElements.Contains(gameElement)) return;

            gameElement.SetParentScene(this);

            _gameElements.Add(gameElement);

            if (gameElement.HasComponent<Light>())
                _lights.Add(gameElement);

            if (gameElement.HasComponent<Camera>())
            {
                Camera cm = gameElement.GetComponent<Camera>();
                _cameras.Add(gameElement);

                if (cm.IsPrimary)
                    _primaryCamera = gameElement;
            }

            if (gameElement.HasComponent<AudioSource>())
                _audioSources.Add(gameElement);

            if (gameElement.HasComponent<AudioReverbZone>())
                _audioReverbZones.Add(gameElement);

            if (gameElement.HasComponent<AudioListener>())
                _audioListener = gameElement;

            foreach (GameElement child in gameElement.Childs)
                AddGameElement(child);

            gameElement.OnAddToScene(this);

            OnAddGameElement(gameElement);
        }

        /// <summary>
        /// Removes a <see cref="GameElement"/> in the scene.
        /// </summary>
        /// <param name="gameElement">The <see cref="GameElement"/> to add.</param>
        public void RemoveGameElement(GameElement gameElement)
        {
            if (!_gameElements.Contains(gameElement)) return;

            gameElement.SetParentScene(null);

            _gameElements.Remove(gameElement);

            if (gameElement.HasComponent<Light>())
                _lights.Remove(gameElement);

            if (gameElement.HasComponent<Camera>())
            {
                Camera cm = gameElement.GetComponent<Camera>();
                _cameras.Remove(gameElement);

                if (cm.IsPrimary)
                    _primaryCamera = null;
            }

            if (gameElement.HasComponent<AudioSource>())
                _audioSources.Remove(gameElement);

            if (gameElement.HasComponent<AudioReverbZone>())
                _audioReverbZones.Remove(gameElement);

            if (gameElement.HasComponent<AudioListener>())
                _audioListener = null;

            foreach (GameElement child in gameElement.Childs)
                RemoveGameElement(child);

            gameElement.OnRemoveFromScene(this);

            OnRemoveGameElement(gameElement);
        }

        /// <summary>
        /// Sets the primary camera of the scene.
        /// </summary>
        /// <param name="c">The camera.</param>
        public void SetPrimaryCamera(GameElement c)
        {
            if (c.HasComponent<Camera>())
                _primaryCamera = c;
        }

        /// <summary>
        /// Sets the audio listener of the scene.
        /// </summary>
        /// <param name="l">The audio listener.</param>
        public void SetAudioListener(GameElement l)
        {
            if (l.HasComponent<AudioListener>())
                _audioListener = l;
        }

        /// <summary>
        /// Adds a <see cref="FrameScript"/> in this <see cref="Scene"/>.
        /// </summary>
        /// <param name="script">The framescript to add.</param>
        public void AddFrameScript(FrameScript script)
        {
            _frameScripts.Add(script);
            script.SetParentScene(this);
        }

        /// <summary>
        /// Removes a <see cref="FrameScript"/> from this <see cref="Scene"/>.
        /// </summary>
        /// <param name="script">The framescript to remove.</param>
        public void RemoveFrameScript(FrameScript script)
        {
            _frameScripts.Remove(script);
            script.SetParentScene(null);
        }

        /// <summary>
        /// Adds a <see cref="RenderScript"/> in this <see cref="Scene"/>.
        /// </summary>
        /// <param name="script">The renderscript to add.</param>
        public void AddRenderScript(RenderScript script)
        {
            _renderScripts.Add(script);
            script.SetParentScene(this);
        }

        /// <summary>
        /// Removes a <see cref="RenderScript"/> from this <see cref="Scene"/>.
        /// </summary>
        /// <param name="script">The renderscript to remove.</param>
        public void RemoveRenderScript(RenderScript script)
        {
            _renderScripts.Remove(script);
            script.SetParentScene(null);
        }

        /// <summary>
        /// Initialize the <see cref="Scene"/> when loading it in
        /// the <see cref="Game"/>.
        /// </summary>
        public virtual void Load()
        {
            RenderScript[] arrayRenderScripts = _renderScripts.ToArray();

            for (int i = 0, l = arrayRenderScripts.Length; i < l; i++)
                arrayRenderScripts[i].Load();

            arrayRenderScripts = null;

            // Setup Physics
            _loadPhysics();
        }

        /// <summary>
        /// Action executed when the <see cref="Scene"/> is unloaded from
        /// the <see cref="Game"/>.
        /// </summary>
        public virtual void Unload()
        {
            RenderScript[] arrayRenderScripts = _renderScripts.ToArray();

            for (int i = 0, l = arrayRenderScripts.Length; i < l; i++)
                arrayRenderScripts[i].Unload();

            arrayRenderScripts = null;

            // Unload physics.
            _unloadPhysics();

            GameElement[] arrayGameElements = _gameElements.ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
            {
                RemoveGameElement(arrayGameElements[i]);
                arrayGameElements[i].Dispose();
            }

            arrayGameElements = null;

            _gameElements.Clear();

            GameElement.Clear();
        }

        /// <summary>
        /// Starts the <see cref="Scene"/>.
        /// </summary>
        public virtual void Start()
        {
            _gameElements.Start();

            _started = true;
        }

        /// <summary>
        /// Triggered before the frame's update of the <see cref="Scene"/>.
        /// </summary>
        public virtual void BeforeUpdate()
        {
            FrameScript[] arrayFrameScripts = _frameScripts.ToArray();

            for (int i = 0, l = arrayFrameScripts.Length; i < l; i++)
                arrayFrameScripts[i].BeforeUpdate();

            arrayFrameScripts = null;

            _gameElements.BeforeUpdate();
        }

        /// <summary>
        /// Updates the <see cref="Scene"/> and all attached <see cref="GameElement"/>s.
        /// </summary>
        public virtual void Update()
        {
            FrameScript[] arrayFrameScripts = _frameScripts.ToArray();

            for (int i = 0, l = arrayFrameScripts.Length; i < l; i++)
                arrayFrameScripts[i].Update();

            arrayFrameScripts = null;

            _gameElements.Update();
        }

        /// <summary>
        /// Triggered after the frame's update of the <see cref="Scene"/>.
        /// </summary>
        public virtual void AfterUpdate()
        {
            FrameScript[] arrayFrameScripts = _frameScripts.ToArray();

            for (int i = 0, l = arrayFrameScripts.Length; i < l; i++)
                arrayFrameScripts[i].AfterUpdate();

            arrayFrameScripts = null;

            _gameElements.AfterUpdate();
        }

        /// <summary>
        /// Stops the  <see cref="Scene"/>.
        /// </summary>
        public virtual void Stop()
        {
            _gameElements.Stop();

            _started = false;
        }

        /// <summary>
        /// Action executed when a <see cref="GameElement"/> is
        /// added in the <see cref="Scene"/>.
        /// </summary>
        protected virtual void OnAddGameElement(GameElement gameElement)
        {
            GameElementAdded?.Invoke(this, gameElement);
        }

        /// <summary>
        /// Action executed when a <see cref="GameElement"/> is
        /// removed from the <see cref="Scene"/>.
        /// </summary>
        protected virtual void OnRemoveGameElement(GameElement gameElement)
        {
            GameElementRemoved?.Invoke(this, gameElement);
        }

        /// <summary>
        /// Executes actions before the render process.
        /// </summary>
        protected virtual void BeforeRender()
        {
            RenderScript[] arrayRenderScripts = _renderScripts.ToArray();

            for (int i = 0, l = arrayRenderScripts.Length; i < l; i++)
                arrayRenderScripts[i].BeforeRender();

            arrayRenderScripts = null;
        }

        /// <summary>
        /// Renders the current scene.
        /// </summary>
        public void Render()
        {
            BeforeRender();
            RendererManager.RenderAll();
            AfterRender();
        }

        /// <summary>
        /// Executes actions after the render process.
        /// </summary>
        protected virtual void AfterRender()
        {
            RenderScript[] arrayRenderScripts = _renderScripts.ToArray();

            for (int i = 0, l = arrayRenderScripts.Length; i < l; i++)
                arrayRenderScripts[i].AfterRender();

            arrayRenderScripts = null;
        }

        /// <summary>
        /// Process physics simulation for one frame.
        /// </summary>
        internal void SimulatePhysics()
        {
            _space.Update((float) Time.DeltaTime);
        }

        /// <summary>
        /// Process physics simulation for many timesteps as necessary.
        /// </summary>
        internal void SimulatePhysics(float dt)
        {
            _space.Update(dt);
        }

        /// <summary>
        /// Register a rigidbody in the scene.
        /// </summary>
        /// <param name="r">The rigidbody.</param>
        internal void RegisterRigidBody(GameElement r)
        {
            if (r.HasComponent<RigidBody>())
            {
                RigidBody rb = r.GetComponent<RigidBody>();
                _space.Add(rb.InnerRigidBody);
            }
        }

        /// <summary>
        /// Unregister a rigidbody in the scene.
        /// </summary>
        /// <param name="r">The rigidbody.</param>
        internal void UnregisterRigidBody(GameElement r)
        {
            if (r.HasComponent<RigidBody>())
            {
                RigidBody rb = r.GetComponent<RigidBody>();
                _space.Remove(rb.InnerRigidBody);
            }
        }

        /// <summary>
        /// Initialize physics.
        /// </summary>
        private void _loadPhysics()
        {
            _parallelLooper?.Dispose();

            _parallelLooper = new ParallelLooper();

            // This section lets the engine know that it can make use of multithreaded systems
            // by adding threads to its thread pool.
            if (Environment.ProcessorCount > 1)
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    _parallelLooper.AddThread();
                }
            }

            _space = new Space(_parallelLooper)
            {
                ForceUpdater =
                {
                    Gravity = VectorHelper.Down * 9.81f,
                    TimeStepSettings = {TimeStepDuration = 1.0f / GameSettings.GameFps}
                }
            };
        }

        /// <summary>
        /// Deinitialize physics.
        /// </summary>
        private void _unloadPhysics()
        {
            if (_parallelLooper == null) return;

            if (Environment.ProcessorCount > 1)
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    _parallelLooper.RemoveThread();
                }
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                if (_parallelLooper != null)
                    _parallelLooper.Dispose();

                GameElement[] arrayGameElements = _gameElements.ToArray();

                for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                {
                    RemoveGameElement(arrayGameElements[i]);
                    arrayGameElements[i].Dispose();
                }

                arrayGameElements = null;

                _gameElements.Dispose();
                _gameElements = null;

                GameElement.Clear();
            }

            _disposedValue = true;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Scene() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}