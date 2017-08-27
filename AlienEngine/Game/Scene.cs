using BulletSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Game
{
    public class Scene : IDisposable
    {
        // Game elements collections
        private GameElementCollection _gameElements;
        private GameElementCollection _lights;
        private GameElementCollection _cameras;

        // Unique game elements
        private GameElement _audioListener;
        private GameElement _primaryCamera;

        // Physics
        private DynamicsWorld _world;
        private BroadphaseInterface _broadPhase;
        private CollisionConfiguration _collisionConfig;
        private Dispatcher _collisionDispatcher;
        private ConstraintSolver _solver;

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
            gameElement.ParentScene = this;

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

            if (gameElement.HasComponent<AudioListener>())
            {
                _audioListener = gameElement;
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
            _world.StepSimulation((float)Time.DeltaTime);
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
                _world.AddRigidBody(rb.InnerRigidBody);
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
                _world.RemoveCollisionObject(rb.InnerRigidBody);
            }
        }

        /// <summary>
        /// Initialize physics.
        /// </summary>
        private void _setupPhysics()
        {
            _broadPhase = new DbvtBroadphase();
            _collisionConfig = new DefaultCollisionConfiguration();
            _collisionDispatcher = new CollisionDispatcher(_collisionConfig);
            _solver = new SequentialImpulseConstraintSolver();

            _world = new DiscreteDynamicsWorld(_collisionDispatcher, _broadPhase, _solver, _collisionConfig);
            _world.Gravity = Vector3.UnitY * -10;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_world != null)
                    {
                        _collisionDispatcher.Dispose();
                        _collisionConfig.Dispose();
                        _solver.Dispose();
                        _broadPhase.Dispose();
                        _world.Dispose();
                    }
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
