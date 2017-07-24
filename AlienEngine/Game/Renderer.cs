using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Game
{
    public static class Renderer
    {
        private static List<IRenderable> _renderables;

        static Renderer()
        {
            _renderables = new List<IRenderable>();
        }

        public static void RegisterRenderable(IRenderable _object)
        {
            if (!HasRenderable(_object))
                _renderables.Add(_object);
        }

        public static void UnregisterRenderable(IRenderable _object)
        {
            if (HasRenderable(_object))
                _renderables.Remove(_object);
        }

        public static bool HasRenderable(IRenderable _object)
        {
            return _renderables.Contains(_object);
        }

        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Camera _camera = Game.CurrentCamera.GetComponent<Camera>();

            switch (_camera.ClearScreenType)
            {
                case Camera.ClearScreenTypes.Color:
                    GL.ClearColor(_camera.ClearColor);
                    break;
                case Camera.ClearScreenTypes.Cubemap:
                    if (_camera.Cubemap != null)
                        _camera.Cubemap.Render();
                    break;
            }
        }

        public static void RenderAll()
        {
            foreach (IRenderable _object in _renderables)
                _object.Render();
        }
    }
}
