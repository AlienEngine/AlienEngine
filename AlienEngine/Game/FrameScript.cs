namespace AlienEngine.Core.Game
{
    public class FrameScript : IFrameScript
    {
        private Scene _scene;

        public Scene ParentScene => _scene;

        internal void SetParentScene(Scene scene)
        {
            _scene = scene;
        }

        public virtual void Dispose()
        {
        }

        public virtual void Load()
        {
        }

        public virtual void BeforeUpdate()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void AfterUpdate()
        {
        }

        public virtual void Unload()
        {
        }
    }
}