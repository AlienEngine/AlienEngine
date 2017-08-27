using AlienEngine.Core.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienEngine
{
    public class GameElement
    {
        private Scene _parentScene;

        #region Static Members

        #region Properties
        internal Scene ParentScene
        {
            get { return _parentScene; }
            set { _parentScene = value; }
        }

        public static GameElement Empty { get { return new GameElement("GameElement"); } }

        private static Dictionary<string, int> _namesCounter;
        #endregion Properties

        #region Methods
        static GameElement()
        {
            _gameElements = new Dictionary<string, GameElement>();
            _namesCounter = new Dictionary<string, int>();
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
            if (_namesCounter.ContainsKey(gameElement.Name))
                _namesCounter[gameElement.Name]++;
            else
                _namesCounter[gameElement.Name] = 0;

            if (!Is(name))
                _gameElements.Add(name, gameElement);
            else
                _gameElements.Add(name + "___" + _namesCounter[gameElement.Name], gameElement);
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
                gameElement.Value.Stop();
        }
        #endregion Methods

        #endregion Static Members

        #region Private Members

        #region Fields
        private List<IComponent> _attachedComponents;
        private GameElementCollection _childs;
        private string _name;
        private GameElement _parent;
        private static Dictionary<string, GameElement> _gameElements;
        private Transform _worldTransform;
        #endregion Fields

        #region Properties
        private Vector3f _realScale { get { return (Parent != null) ? Parent._realScale * LocalTransform.Scale : LocalTransform.Scale; } }
        private Vector3f _realRotation { get { return (Parent != null) ? Parent._realRotation + LocalTransform.Rotation : LocalTransform.Rotation; } }
        private Vector3f _realPosition { get { return (Parent != null) ? Parent._realPosition + (LocalTransform.Translation * _realScale) : LocalTransform.Translation; } }
        #endregion Properties

        #endregion Private Members

        #region Public Members

        #region Properties
        public string Name { get { return _name; } }

        public GameElement Parent { get { return _parent; } }

        public bool HasChilds { get { return _childs.Length > 0; } }

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
                _worldTransform.SetTranslation(_realPosition);
                return _worldTransform;
            }
        }
        #endregion Properties

        #region Constructor
        public GameElement(string name)
        {
            _attachedComponents = new List<IComponent>();
            _childs = new GameElementCollection();
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
            foreach (GameElement c in _childs)
                if (c == child) return true;

            return false;
        }

        public bool HasChild(string name)
        {
            foreach (GameElement c in _childs)
                if (c.Name == name) return true;

            return false;
        }

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
                if (component is T) return component as T;

            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> collection = new List<T>();

            foreach (IComponent component in _attachedComponents)
                if (component is T) collection.Add(component as T);

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
            }
        }

        public void AttachComponents(params Component[] components)
        {
            foreach (Component component in components)
            {
                if (!HasComponent(component))
                {
                    component.SetGameElement(this);
                    _attachedComponents.Add(component);
                }
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
            foreach (IComponent component in _attachedComponents)
                if (component is T) return true;

            return false;
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
