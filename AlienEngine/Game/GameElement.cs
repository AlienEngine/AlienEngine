using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienEngine
{
    public class GameElement
    {
        #region Static Members

        #region Properties
        public static GameElement Empty { get { return new GameElement("GameElement"); } }
        #endregion Properties

        #region Methods
        static GameElement()
        {
            _gameElements = new Dictionary<string, GameElement>();
        }

        public static GameElement Get(string name)
        {
            if (_gameElements.ContainsKey(name))
                return _gameElements[name];
            else
                return null;
        }

        public static bool Is(string name)
        {
            return _gameElements.ContainsKey(name);
        }

        public static void Add(string name, GameElement gameElement)
        {
            if (!Is(name))
                _gameElements.Add(name, gameElement);
            else
                throw new InvalidOperationException();
        }

        public static void Remove(string name)
        {
            _gameElements.Remove(name);
        }

        public static void StartAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Start();
        }

        public static void BeforeUpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.BeforeUpdate();
        }

        public static void UpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Update();
        }

        public static void AfterUpdateAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.AfterUpdate();
        }

        public static void StopAll()
        {
            foreach (var gameElement in _gameElements)
                gameElement.Value.Start();
        }
        #endregion Methods

        #endregion Static Members

        #region Private Members

        #region Fields
        private List<IComponent> _attachedComponents;
        private List<GameElement> _childs;
        private string _name;
        private GameElement _parent;
        private static Dictionary<string, GameElement> _gameElements;
        private Transform _worldTransform;
        #endregion Fields

        #region Properties
        private Vector3f _realScale { get { return (Parent != null) ? Parent._realScale * LocalTransform.Scale : LocalTransform.Scale; } }
        private Vector3f _realRotation { get { return (Parent != null) ? Parent._realRotation + LocalTransform.Rotation : LocalTransform.Rotation; } }
        private Vector3f _realPosition { get { return (Parent != null) ? Parent._realPosition + (LocalTransform.Position * _realScale) : LocalTransform.Position; } }
        #endregion Properties

        #endregion Private Members

        #region Public Members

        #region Properties
        public string Name { get { return _name; } }

        public GameElement Parent { get { return _parent; } }

        public bool HasChilds { get { return _childs.Count > 0; } }

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
                _worldTransform.SetPosition(_realPosition);
                return _worldTransform;
            }
        }
        #endregion Properties

        #region Constructor
        public GameElement(string name)
        {
            _attachedComponents = new List<IComponent>();
            _childs = new List<GameElement>();
            _name = name;
            _worldTransform = new Transform();
            LocalTransform = new Transform();

            GameElement.Add(_name, this);
        }
        #endregion

        #region Methods
        public void AddChild(GameElement child)
        {
            if (!HasChild(child))
            {
                child._parent = this;
                _childs.Add(child);
            }
        }

        public bool HasChild(GameElement child)
        {
            bool found = false;

            foreach (GameElement c in _childs)
                if (c == child) found = true;

            return found;
        }

        public bool HasChild(string name)
        {
            bool found = false;

            foreach (GameElement c in _childs)
                if (c.Name == name) found = true;

            return found;
        }

        public GameElement FindChild(string name)
        {
            foreach (GameElement c in _childs)
                if (c.Name == name) return c;

            return null;
        }

        public GameElement[] FindChilds(string name)
        {
            List<GameElement> collection = new List<GameElement>();

            foreach (GameElement c in _childs)
                if (c.Name == name) collection.Add(c);

            return collection.ToArray();
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (IComponent component in _attachedComponents)
                if (component is T) return (T)component;

            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> collection = new List<T>();

            foreach (IComponent component in _attachedComponents)
                if (component is T) collection.Add((T)component);

            return collection.ToArray();
        }

        public void AttachComponent<T>(T component) where T : Component
        {
            if (!HasComponent(component))
            {
                component.SetGameElement(this);
                _attachedComponents.Add(component);
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
                foreach (IComponent component in _attachedComponents)
                    if (component is T) DetachComponent((T)component);
            }
        }

        public bool HasComponent<T>(T component) where T : Component
        {
            return _attachedComponents.Contains(component);
        }

        public bool HasComponent<T>() where T : Component
        {
            bool exists = false;
            foreach (IComponent component in _attachedComponents)
                if (component is T) exists = true;

            return exists;
        }

        public void Start()
        {
            foreach (IComponent component in _attachedComponents)
                component.Start();
        }

        public void BeforeUpdate()
        {
            foreach (IComponent component in _attachedComponents)
                component.BeforeUpdate();
        }

        public void Update()
        {
            foreach (IComponent component in _attachedComponents)
                component.Update();
        }

        public void AfterUpdate()
        {
            foreach (IComponent component in _attachedComponents)
                component.AfterUpdate();
        }

        public void Stop()
        {
            foreach (IComponent component in _attachedComponents)
                component.Stop();
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion

        #endregion Public Members
    }
}
