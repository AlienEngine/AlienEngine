using AlienEngine.Core.Physics;
using AlienEngine.Core.Threading;
using System;
using AlienEngine.Core.Rendering;

namespace AlienEngine.Core.Game
{
    public class Scene : IDisposable
    {
        // Game elements collections
        private GameElementCollection _gameElements;
        private GameElementCollection _lights;
        private GameElementCollection _cameras;
        private GameElementCollection _audioSources;
        private GameElementCollection _audioReverbZones;

        // Unique game elements
        private GameElement _audioListener;
        private GameElement _primaryCamera;

        // Physics
        private Space _space;
        private ParallelLooper _parallelLooper;

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/>.
        /// </summary>
        public GameElementCollection GameElements
        {
            get { return _gameElements; }
        }

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="Light"/> component.
        /// </summary>
        public GameElementCollection Lights
        {
            get { return _lights; }
        }

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="Camera"/> component.
        /// </summary>
        public GameElementCollection Cameras
        {
            get { return _cameras; }
        }

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="AudioSource"/> component.
        /// </summary>
        public GameElementCollection AudioSources
        {
            get { return _audioSources; }
        }

        /// <summary>
        /// Gets a collection of all <see cref="GameElement"/>s
        /// in the current <see cref="Scene"/> which have a
        /// <see cref="AudioReverbZone"/> component.
        /// </summary>
        public GameElementCollection AudioReverbZones
        {
            get { return _audioReverbZones; }
        }

        /// <summary>
        /// Gets the unique <see cref="GameElement"/> in the
        /// current <see cref="Scene"/> which has a enable
        /// <see cref="AlienEngine.AudioListener"/> component.
        /// </summary>
        public GameElement AudioListener
        {
            get { return _audioListener; }
        }

        /// <summary>
        /// Gets the unique <see cref="GameElement"/> in the
        /// current <see cref="Scene"/> which has a enabled
        /// <see cref="Camera"/> component.
        /// </summary>
        public GameElement PrimaryCamera
        {
            get { return _primaryCamera; }
        }

        /// <summary>
        /// Creates a new scene.
        /// </summary>
        public Scene()
        {
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

            var components = gameElement.GetComponents<Component>();
            
            foreach (Component component in components)
            {
                if (component is IRenderable)
                    Renderer.RegisterRenderable(component as IRenderable);

                if (component is IPostRenderable)
                    Renderer.RegisterPostRenderable(component as IPostRenderable);
            }
            
            foreach (GameElement child in gameElement.Childs)
            {
                AddGameElement(child);
            }
        }

        /// <summary>
        /// Removes a <see cref="GameElement"/> from the <see cref="Scene"/>.
        /// </summary>
        /// <param name="element">The game element to remove.</param>
        public void RemoveGameElement(GameElement element)
        {
            if (_gameElements.Contains(element))
            {
                var components = element.GetComponents<Component>();
            
                foreach (Component component in components)
                {
                    if (component is IRenderable)
                        Renderer.UnregisterRenderable(component as IRenderable);

                    if (component is IPostRenderable)
                        Renderer.UnregisterPostRenderable(component as IPostRenderable);
                }
                
                _gameElements.Remove(element);
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
        /// Renders the current scene.
        /// </summary>
        public void Render()
        {

        }

        /// <summary>
        /// Process physics simulation for one frame.
        /// </summary>
        public void SimulatePhysics()
        {
            _space.Update((float)Time.DeltaTime);
        }

        /// <summary>
        /// Process physics simulation for one frame.
        /// </summary>
        public void SimulatePhysics(float dt)
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
