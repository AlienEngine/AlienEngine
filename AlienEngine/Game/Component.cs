namespace AlienEngine
{
    public abstract class Component : IComponent
    {
        private bool _enabled = true;
        private GameElement _gameElement = null;

        protected GameElement gameElement
        {
            get { return _gameElement; }
        }

        public bool Enabled { get { return _enabled; } }

        public void Enable()
        {
            Enable(true);
        }

        public void Disable()
        {
            Enable(false);
        }

        public void Enable(bool value)
        {
            _enabled = value;
        }

        public T GetComponent<T>() where T : Component
        {
            return _gameElement != null ? _gameElement.GetComponent<T>() : null;
        }

        internal void SetGameElement(GameElement gameElement)
        {
            _gameElement = gameElement;
        }

        #region Overriden Methods

        public virtual void Start()
        { }

        public virtual void BeforeUpdate()
        { }

        public virtual void Update()
        { }

        public virtual void AfterUpdate()
        { }

        public virtual void Stop()
        { }

        #endregion
    }
}
