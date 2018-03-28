using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace AlienEngine.Core.Game
{
    /// <summary>
    /// Manages all <see cref="Scene"/>s in the <see cref="Game"/>.
    /// </summary>
    public static class SceneManager
    {
        /// <summary>
        /// The collections of registered scenes.
        /// </summary>
        private static List<Scene> _sceneRegistry;

        /// <summary>
        /// Store the current scene's index.
        /// </summary>
        private static int _currentSceneIndex;
        
        /// <summary>
        /// Gets the number of registered scenes.
        /// </summary>
        public static int SceneCount => _sceneRegistry.Count;

        /// <summary>
        /// SceneManager initializer.
        /// </summary>
        internal static void Initialize()
        {
            _sceneRegistry = new List<Scene>();
        }

        /// <summary>
        /// SceneManager deinitializer.
        /// </summary>
        internal static void Shutdown()
        {
            for (int i = 0, l = SceneCount; i < l; i++)
                _sceneRegistry[i].Unload();
            
            _sceneRegistry.Clear();
            _sceneRegistry = null;
        }

        /// <summary>
        /// Adds a <see cref="Scene"/> to the registry.
        /// </summary>
        /// <param name="scene"></param>
        public static void AddScene(Scene scene)
        {
            _sceneRegistry.Add(scene);
        }

        /// <summary>
        /// Checks if the given scene's name is registered.
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        public static bool IsRegistered(string name)
        {
            foreach (Scene item in _sceneRegistry)
            {
                if (item.Name != name) continue;
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Checks if the given scene's name is registered.
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        /// <param name="scene">The found scene.</param>
        private static bool _sceneIsRegistered(string name, out Scene scene)
        {
            scene = null;
            
            foreach (Scene item in _sceneRegistry)
            {
                if (item.Name != name) continue;
                
                scene = item;
                return true;
            }

            return false;
        }

    }
}