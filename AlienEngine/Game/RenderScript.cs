namespace AlienEngine.Core.Game
{
    public class RenderScript : IRenderScript
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

        public virtual void BeforeRender()
        {
        }

        public virtual void AfterRender()
        {
        }

        public virtual void Unload()
        {
        }
    }
}