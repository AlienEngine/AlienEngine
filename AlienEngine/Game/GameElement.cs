using AlienEngine.Core.Game;
using AlienEngine.Core.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlienEngine.Core.Graphics;

namespace AlienEngine
{
    /// <summary>
    /// <see cref="GameElement"/>s are objects in <see cref="Scene"/>.
    /// They can interact with the user and have defined behaviour
    /// through <see cref="Component"/>s.
    /// </summary>
    public class GameElement : IDisposable
    {
        #region Static Members

        #region Fields

        /// <summary>
        /// An internal counter used to automaticaly rename
        /// <see cref="GameElement"/>s with the same name.
        /// </summary>
        private static Dictionary<string, int> _namesCounter;

        /// <summary>
        /// The list of registered <see cref="GameElement"/>s.
        /// </summary>
        private static Dictionary<string, GameElement> _gameElements;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Create a new empty <see cref="GameElement"/>.
        /// </summary>
        public static GameElement Empty => new GameElement("GameElement");

        /// <summary>
        /// Gets the list 
        /// </summary>
        public static IReadOnlyDictionary<string, GameElement> GameElements => _gameElements;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialize static data.
        /// </summary>
        static GameElement()
        {
            _gameElements = new Dictionary<string, GameElement>();
            _namesCounter = new Dictionary<string, int>();
        }

        /// <summary>
        /// Returns a <see cref="GameElement"/> with the provided name.
        /// </summary>
        /// <param name="name">The name of the <see cref="GameElement"/> to return.</param>
        /// <returns><see cref="GameElement"/></returns>
        public static GameElement Get(string name)
        {
            if (_gameElements.ContainsKey(name))
                return _gameElements[name];

            return null;
        }

        /// <summary>
        /// Checks if the <see cref="GameElement"/> with the provided name
        /// exist.
        /// </summary>
        /// <param name="name">The name of the <see cref="GameElement"/>.</param>
        /// <returns>true if the <see cref="GameElement"/> exist, false otherwise.</returns>
        public static bool Is(string name)
        {
            return _gameElements.ContainsKey(name);
        }

        /// <summary>
        /// Register a new <see cref="GameElement"/> with the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="GameElement"/> to add.</param>
        /// <param name="gameElement">The instance</param>
        public static void Add(string name, GameElement gameElement)
        {
            if (_namesCounter.ContainsKey(gameElement.Name))
                _namesCounter[gameElement.Name]++;
            else
                _namesCounter[gameElement.Name] = 0;

            if (!Is(name))
                _gameElements.Add(name, gameElement);
            else
                _gameElements.Add(name + "___" + _namesCounter[gameElement.Name], gameElement);
        }

        /// <summary>
        /// Unregister a <see cref="GameElement"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="GameElement"/> to remove.</param>
        public static void Remove(string name)
        {
            _gameElements.Remove(name);
        }

        /// <summary>
        /// Clears the current list of <see cref="GameElement"/>s.
        /// </summary>
        public static void Clear()
        {
            _gameElements.Clear();
        }

        /// <summary>
        /// Executes <see cref="Component.Start()"/> in all components of all
        /// registered <see cref="GameElement"/>s.
        /// </summary>
        public static void StartAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Start();
        }

        /// <summary>
        /// Executes <see cref="Component.BeforeUpdate()"/> in all components of all
        /// registered <see cref="GameElement"/>s.
        /// </summary>
        public static void BeforeUpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.BeforeUpdate();
        }

        /// <summary>
        /// Executes <see cref="Component.Update()"/> in all components of all
        /// registered <see cref="GameElement"/>s.
        /// </summary>
        public static void UpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Update();
        }

        /// <summary>
        /// Executes <see cref="Component.AfterUpdate()"/> in all components of all
        /// registered <see cref="GameElement"/>s.
        /// </summary>
        public static void AfterUpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.AfterUpdate();
        }

        /// <summary>
        /// Executes <see cref="Component.Stop()"/> in all components of all
        /// registered <see cref="GameElement"/>s.
        /// </summary>
        public static void StopAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Stop();
        }

        #endregion Methods

        #endregion Static Members

        #region Private Members

        #region Fields

        /// <summary>
        /// The scene in which this game element is.
        /// </summary>
        private Scene _parentScene;

        /// <summary>
        /// The list of attached components in the current
        /// <see cref="GameElement"/>.
        /// </summary>
        private List<Component> _attachedComponents;

        /// <summary>
        /// The list of childs in the current <see cref="GameElement"/>.
        /// </summary>
        private GameElementCollection _childs;

        /// <summary>
        /// The name of the current <see cref="GameElement"/>.
        /// </summary>
        private string _name;

        /// <summary>
        /// The tag group of the current <see cref="GameElement"/>.
        /// </summary>
        private string _tag;

        /// <summary>
        /// The parent of this <see cref="GameElement"/>.
        /// </summary>
        /// <remarks>
        /// If this <see cref="GameElement"/> has no parents, <see cref="null"/> is returned.
        /// </remarks>
        private GameElement _parent;

        /// <summary>
        /// The world transformation of this <see cref="GameElement"/>.
        /// </summary>
        private Transform _worldTransform;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The real scale of this element.
        /// </summary>
        private Vector3f _realScale =>
            (Parent != null) ? Parent._realScale * LocalTransform.Scale : LocalTransform.Scale;

        /// <summary>
        /// The real rotation of this element.
        /// </summary>
        private Vector3f _realRotation =>
            (Parent != null) ? Parent._realRotation + LocalTransform.Rotation : LocalTransform.Rotation;

        /// <summary>
        /// The real translation of this element.
        /// </summary>
        private Vector3f _realTranslation => (Parent != null)
            ? Parent._realTranslation + (LocalTransform.Translation * _realScale)
            : LocalTransform.Translation;

        #endregion Properties

        #endregion Private Members

        #region Public Members

        #region Properties

        /// <summary>
        /// The scene in which this <see cref="GameElement"/> is.
        /// </summary>
        public Scene ParentScene => _parentScene;

        /// <summary>
        /// The collection of this <see cref="GameElement"/>'s childs.
        /// </summary>
        public GameElementCollection Childs => _childs;

        /// <summary>
        /// The list of attached <see cref="Component"/>s to this <see cref="GameElement"/>.
        /// </summary>
        public List<Component> Components => _attachedComponents;

        /// <summary>
        /// The name of this <see cref="GameElement"/>.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The tag group of this <see cref="GameElement"/>.
        /// </summary>
        public string Tag => _tag;

        /// <summary>
        /// The parent <see cref="GameElement"/> of this one. If this
        /// <see cref="GameElement"/> is in the top of the hierarchy (the world)
        /// <see cref="Parent"/> = <see cref="null"/>.
        /// </summary>
        public GameElement Parent => _parent;

        /// <summary>
        /// Checks if this <see cref="GameElement"/> has childs.
        /// </summary>
        public bool HasChilds => _childs.Length > 0;

        /// <summary>
        /// Get local transformations for this <see cref="GameElement"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="LocalTransform"/> is determined by taking the <see cref="Parent"/>
        /// as the reference. If the <see cref="Parent"/> is null, then <see cref="LocalTransform"/>
        /// will have the same value as <see cref="WorldTransform"/>, which represents the position,
        /// rotation and scale of this <see cref="GameElement"/> in the world.
        /// </remarks>
        public Transform LocalTransform;

        /// <summary>
        /// Get world transformations for this <see cref="GameElement"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="WorldTransform"/> always use the world as the reference.
        /// </remarks>
        public Transform WorldTransform
        {
            get
            {
                _worldTransform.SetScale(_realScale);
                _worldTransform.SetRotation(_realRotation);
                _worldTransform.SetTranslation(_realTranslation);
                return _worldTransform;
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Create a new <see cref="GameElement"/> with a name.
        /// </summary>
        /// <param name="name">The name of the new element.</param>
        public GameElement(string name)
        {
            _attachedComponents = new List<Component>();
            _childs = new GameElementCollection();
            _name = name;
            _worldTransform = new Transform();
            LocalTransform = new Transform();

            GameElement.Add(_name, this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add a child in this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="child">The child.</param>
        public void AddChild(GameElement child)
        {
            if (!HasChild(child))
            {
                child._parent = this;
                _childs.Add(child);
            }
        }

        /// <summary>
        /// Checks if the given <paramref name="child"/> is a child of
        /// this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="child">The child to find.</param>
        public bool HasChild(GameElement child)
        {
            foreach (GameElement c in _childs)
                if (c == child)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if this <see cref="GameElement"/> has a child with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the child to find.</param>
        public bool HasChild(string name)
        {
            foreach (GameElement c in _childs)
                if (c.Name == name)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns the child with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the child to find.</param>
        public GameElement FindChild(string name)
        {
            foreach (GameElement c in _childs)
            {
                if (c.Name == name) return c;
                else
                {
                    GameElement ret = c.FindChild(name);
                    if (ret != null) return ret;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the list of childs with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name"></param>
        public GameElement[] FindChilds(string name)
        {
            List<GameElement> collection = new List<GameElement>();

            foreach (GameElement c in _childs)
                if (c.Name == name)
                    collection.Add(c);

            return collection.ToArray();
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (IComponent component in _attachedComponents)
                if (component is T)
                    return component as T;

            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> collection = new List<T>();

            foreach (IComponent component in _attachedComponents)
                if (component is T)
                    collection.Add(component as T);

            return collection.ToArray();
        }

        public T[] GetComponentsChilds<T>() where T : Component
        {
            List<T> collection = new List<T>();

            collection.AddRange(GetComponents<T>());

            foreach (GameElement c in _childs)
                collection.AddRange(c.GetComponents<T>());

            return collection.ToArray();
        }

        public void AttachComponent<T>(T component) where T : Component
        {
            if (!HasComponent(component))
            {
                component.SetGameElement(this);
                _attachedComponents.Add(component);

                component.TriggerAttachEvent();
            }
        }

        public void AttachComponents(params Component[] components)
        {
            foreach (Component component in components)
            {
                AttachComponent(component);
            }
        }

        public void DetachComponent<T>(T component) where T : Component
        {
            if (HasComponent(component))
            {
                component.SetGameElement(null);
                _attachedComponents.Remove(component);
            }
        }

        public void DetachComponents<T>() where T : Component
        {
            if (HasComponent<T>())
            {
                foreach (Component component in _attachedComponents)
                    if (component is T)
                        DetachComponent((T) component);
            }
        }

        public bool HasComponent<T>(T component) where T : Component
        {
            return _attachedComponents.Contains(component);
        }

        public bool HasComponent<T>() where T : Component
        {
            foreach (Component component in _attachedComponents)
                if (component is T)
                    return true;

            return false;
        }

        public bool HasComponent<T>(out T comonent) where T : Component
        {
            comonent = null;

            foreach (Component c in _attachedComponents)
            {
                if (c is T)
                {
                    comonent = c as T;
                    return true;
                }
            }

            return false;
        }

        public void Start()
        {
            if (_attachedComponents == null) return;

            Component[] arrayComponents = _attachedComponents.ToArray();

            for (int i = 0, l = arrayComponents.Length; i < l; i++)
                arrayComponents[i].Start();

            arrayComponents = null;
        }

        public void BeforeUpdate()
        {
            if (_attachedComponents == null) return;

            Component[] arrayComponents = _attachedComponents.ToArray();

            for (int i = 0, l = arrayComponents.Length; i < l; i++)
                arrayComponents[i].BeforeUpdate();

            arrayComponents = null;
        }

        public void Update()
        {
            if (_attachedComponents == null) return;

            Component[] arrayComponents = _attachedComponents.ToArray();

            for (int i = 0, l = arrayComponents.Length; i < l; i++)
                arrayComponents[i].Update();

            arrayComponents = null;
        }

        public void AfterUpdate()
        {
            if (_attachedComponents == null) return;

            Component[] arrayComponents = _attachedComponents.ToArray();

            for (int i = 0, l = arrayComponents.Length; i < l; i++)
                arrayComponents[i].AfterUpdate();

            arrayComponents = null;
        }

        public void Stop()
        {
            if (_attachedComponents == null) return;

            Component[] arrayComponents = _attachedComponents.ToArray();

            for (int i = 0, l = arrayComponents.Length; i < l; i++)
                arrayComponents[i].Stop();

            arrayComponents = null;
        }

        internal virtual void OnAddToScene(Scene scene)
        {
            foreach (var component in _attachedComponents)
            {
                if (component is IRenderable)
                    RendererManager.RegisterRenderable(component as IRenderable);

                if (component is IPostRenderable)
                    RendererManager.RegisterPostRenderable(component as IPostRenderable);
            }
        }

        internal virtual void OnRemoveFromScene(Scene scene)
        {
            foreach (var component in _attachedComponents)
            {
                if (component is IRenderable)
                    RendererManager.UnregisterRenderable(component as IRenderable);

                if (component is IPostRenderable)
                    RendererManager.UnregisterPostRenderable(component as IPostRenderable);
            }
        }

        internal void SetParentScene(Scene parent)
        {
            _parentScene = parent;
        }

        public GameElement Clone()
        {
            var element = (GameElement) MemberwiseClone();
            element._childs = Childs;
            element._attachedComponents = _attachedComponents;
            element._name = Name;
            element._parent = Parent;
            element._parentScene = ParentScene;
            element._tag = Tag;
            element.LocalTransform = LocalTransform;
            return element;
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #endregion Public Members

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Component[] arrayComponents = _attachedComponents.ToArray();

                for (int i = 0, l = arrayComponents.Length; i < l; i++)
                {
                    DetachComponent(arrayComponents[i]);
                    arrayComponents[i].Dispose();
                }

                arrayComponents = null;

                _attachedComponents.Clear();
                _attachedComponents = null;

                _childs.Dispose();
                _childs = null;
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}