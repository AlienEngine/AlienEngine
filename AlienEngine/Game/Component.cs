using System;

namespace AlienEngine
{
    /// <summary>
    /// Base class of all built-in and user defined
    /// game components.
    /// </summary>
    public abstract class Component : IComponent
    {
        // The enabled state of the component
        private bool _enabled = true;

        // Define if the component has already started
        private bool _started = false;

        // The game element who handling this component.
        private GameElement _gameElement = null;

        /// <summary>
        /// The <see cref="GameElement"/> in which
        /// this <see cref="Component"/> is attached.
        /// </summary>
        protected GameElement gameElement => _gameElement;

        /// <summary>
        /// Gets a boolean defining if this <see cref="Component"/>
        /// is enabled or not.
        /// </summary>
        protected bool Enabled => _enabled;

        /// <summary>
        /// Gets a boolean defining if this <see cref="GameElement"/>
        /// has started or not.
        /// </summary>
        protected bool Started => _started;

        /// <summary>
        /// Returns the <see cref="GameElement"/> in which
        /// this <see cref="Component"/> is attached.
        /// </summary>
        public GameElement GetGameElement()
        {
            return _gameElement;
        }

        /// <summary>
        /// Disable this <see cref="Component"/>.
        /// </summary>
        protected void Disable()
        {
            Enable(false);
        }

        /// <summary>
        /// Enable or disable this <see cref="Component"/>.
        /// </summary>
        /// <param name="value">true to enable, false otherwise.</param>
        protected void Enable(bool value = true)
        {
            _enabled = value;
        }

        /// <summary>
        /// Enable all components of type <typeparamref name="T"/>
        /// in this <see cref="GameElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/> to enable.</typeparam>
        protected void EnableAll<T>() where T : Component
        {
            var collection = gameElement.GetComponents<T>();
            foreach (var component in collection)
            {
                component.Enable();
            }
        }

        /// <summary>
        /// Disable all components of type <typeparamref name="T"/>
        /// in this <see cref="GameElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/> to enable.</typeparam>
        protected void DisableAll<T>() where T : Component
        {
            var collection = gameElement.GetComponents<T>();
            foreach (var component in collection)
            {
                component.Disable();
            }
        }

        /// <summary>
        /// Enable or disable all components of type <typeparamref name="T"/>
        /// in this <see cref="GameElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/> to enable.</typeparam>
        /// <param name="value">true to enable, false otherwise.</param>
        protected void EnableAll<T>(bool value) where T : Component
        {
            var collection = gameElement.GetComponents<T>();
            foreach (var component in collection)
            {
                component.Enable(value);
            }
        }

        /// <summary>
        /// Gets and returns the instance of the <see cref="Component"/>
        /// of type <typeparamref name="T"/> attached to this <see cref="GameElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/> to return.</typeparam>
        /// <remarks>
        /// In the case where more than one component of the type <typeparamref name="T"/>
        /// are attached to this game element, the first one will be returned.
        /// </remarks>
        protected T GetComponent<T>() where T : Component
        {
            return _gameElement != null ? _gameElement.GetComponent<T>() : null;
        }

        /// <summary>
        /// Gets and returns the instance of all <see cref="Component"/>s
        /// of type <typeparamref name="T"/> attached to this <see cref="GameElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/> to return.</typeparam>
        protected T[] GetComponents<T>() where T : Component
        {
            return _gameElement != null ? _gameElement.GetComponents<T>() : null;
        }

        /// <summary>
        /// Checks if the current <see cref="GameElement"/> has an
        /// attached <see cref="Component"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/>.</typeparam>
        protected bool HasComponent<T>() where T : Component
        {
            return _gameElement != null ? _gameElement.HasComponent<T>() : false;
        }

        /// <summary>
        /// Checks if the current <see cref="GameElement"/> has an
        /// attached <see cref="Component"/> of type <typeparamref name="T"/>
        /// with the specified instance.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Component"/>.</typeparam>
        /// <param name="component">The instance of <typeparamref name="T"/> to find.</param>
        protected bool HasComponent<T>(T component) where T : Component
        {
            return _gameElement != null ? _gameElement.HasComponent(component) : false;
        }

        /// <summary>
        /// The event used to define the action to execute when this
        /// <see cref="Component"/> is attached on a <see cref="GameElement"/>.
        /// </summary>
        protected event Action OnAttach;

        /// <summary>
        /// Call all actions defined in the <see cref="OnAttach"/> event.
        /// </summary>
        internal void TriggerAttachEvent()
        {
            OnAttach?.Invoke();
        }

        /// <summary>
        /// Defines the <see cref="GameElement"/> of this <see cref="Component"/>.
        /// </summary>
        /// <param name="gameElement">The <see cref="GameElement"/> who use this <see cref="Component"/>.</param>
        internal void SetGameElement(GameElement gameElement)
        {
            _gameElement = gameElement;
        }

        #region Overriden Methods

        /// <summary>
        /// Triggered when the <see cref="GameElement"/> of this
        /// <see cref="Component"/> is starting.
        /// </summary>
        public virtual void Start()
        {
            _started = true;
        }

        public void Load()
        {
        }

        /// <summary>
        /// Triggered before the <see cref="GameElement"/> of this
        /// <see cref="Component"/> is updated.
        /// </summary>
        public virtual void BeforeUpdate()
        {
        }

        /// <summary>
        /// Triggered when the <see cref="GameElement"/> of this
        /// <see cref="Component"/> is updating.
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        /// Triggered after the <see cref="GameElement"/> of this
        /// <see cref="Component"/> is updated.
        /// </summary>
        public virtual void AfterUpdate()
        {
        }

        public void Unload()
        {
        }

        /// <summary>
        /// Triggered when the <see cref="GameElement"/> of this
        /// <see cref="Component"/> is stopping.
        /// </summary>
        public virtual void Stop()
        {
            _started = false;
        }

        #region Physics triggers

        /// <summary>
        /// Triggered when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> hit another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        public virtual void OnColliderHit(Collider element)
        {
        }

        /// <summary>
        /// Triggered when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> enter in another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        public virtual void OnColliderEnter(Collider element)
        {
        }

        /// <summary>
        /// Triggered when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> is in another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        public virtual void OnColliderStay(Collider element)
        {
        }

        /// <summary>
        /// Triggered when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> exit out another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        public virtual void OnColliderExit(Collider element)
        {
        }

        #endregion

        #endregion

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}