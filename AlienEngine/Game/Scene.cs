using AlienEngine.Core.Physics;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Threading;
using System;

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
        /// Creates a new scene.
        /// </summary>
        public Scene(string name)
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

            // Setup Physics
            _setupPhysics();
        }

        /// <summary>
        /// Adds a <see cref="GameElement"/> in the scene.
        /// </summary>
        /// <param name="gameElement">The <see cref="GameElement"/> to add.</param>
        public void AddGameElement(GameElement gameElement)
        {
            if (!_gameElements.Contains(gameElement))
            {
                gameElement.SetParentScene(this);

                _gameElements.Add(gameElement);

                if (gameElement.HasComponent<Light>())
                {
                    _lights.Add(gameElement);
                }

                if (gameElement.HasComponent<Camera>())
                {
                    Camera cm = gameElement.GetComponent<Camera>();
                    _cameras.Add(gameElement);

                    if (cm.IsPrimary)
                        _primaryCamera = gameElement;
                }

                if (gameElement.HasComponent<AudioSource>())
                {
                    _audioSources.Add(gameElement);
                }

                if (gameElement.HasComponent<AudioReverbZone>())
                {
                    _audioReverbZones.Add(gameElement);
                }

                if (gameElement.HasComponent<AudioListener>())
                {
                    _audioListener = gameElement;
                }

                foreach (GameElement child in gameElement.Childs)
                {
                    AddGameElement(child);
                }

                OnAddGameElement();
            }
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
        /// Initialize the <see cref="Scene"/> when loading it in
        /// the <see cref="Game"/>.
        /// </summary>
        public virtual void Load()
        { }

        /// <summary>
        /// Action executed when the <see cref="Scene"/> is unloaded from
        /// the <see cref="Game"/>.
        /// </summary>
        public virtual void Unload()
        { }

        public virtual void Start()
        {
            foreach (GameElement element in _gameElements)
                element.Start();
        }

        public virtual void BeforeUpdate()
        {
            foreach (GameElement element in _gameElements)
                element.BeforeUpdate();
        }

        /// <summary>
        /// Updates the <see cref="Scene"/> and all attached <see cref="GameElement"/>s.
        /// </summary>
        public virtual void Update()
        {
            foreach (GameElement element in _gameElements)
                element.Update();
        }

        public virtual void AfterUpdate()
        {
            foreach (GameElement element in _gameElements)
                element.AfterUpdate();
        }

        public virtual void Stop()
        {
            foreach (GameElement element in _gameElements)
                element.Stop();
        }

        /// <summary>
        /// Action executed when a <see cref="GameElement"/> is
        /// added in the <see cref="Scene"/>.
        /// </summary>
        protected virtual void OnAddGameElement()
        { }

        protected virtual void BeforeRender()
        { }

        /// <summary>
        /// Renders the current scene.
        /// </summary>
        internal void Render()
        {
            BeforeRender();
            RendererManager.RenderAll();
            AfterRender();
        }

        protected virtual void AfterRender()
        { }

        /// <summary>
        /// Process physics simulation for one frame.
        /// </summary>
        internal void SimulatePhysics()
        {
            _space.Update((float)Time.DeltaTime);
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
        private void _setupPhysics()
        {
            _parallelLooper = new ParallelLooper();
            //This section lets the engine know that it can make use of multithreaded systems
            //by adding threads to its thread pool.
            if (Environment.ProcessorCount > 1)
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    _parallelLooper.AddThread();
                }
            }

            _space = new Space(_parallelLooper);
            _space.ForceUpdater.Gravity = VectorHelper.Down * 9.81f;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_parallelLooper != null)
                        _parallelLooper.Dispose();
                }

                disposedValue = true;
            }
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
