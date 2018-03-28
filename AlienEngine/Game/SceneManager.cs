using System;
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

        public static Scene CurrentScene
        {
            get
            {
                if (_sceneIsRegistered(_currentSceneIndex, out Scene scene))
                    return scene;

                return null;
            }
        }

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
        public static int AddScene(Scene scene)
        {
            _sceneRegistry.Add(scene);
            return SceneCount - 1;
        }

        /// <summary>
        /// Returns a registered <see cref="Scene"/>.
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        public static Scene GetScene(string name)
        {
            foreach (Scene scene in _sceneRegistry)
            {
                if (scene.Name == name)
                    return scene;
            }

            return null;
        }

        /// <summary>
        /// Loads a <see cref="Scene"/> in the <see cref="Game"/> and set it current.
        /// </summary>
        /// <param name="name">The name of the scene</param>
        public static void LoadScene(string name)
        {
            if (_sceneIsRegistered(name, out Scene scene))
                _loadScene(scene);
            else
                // TODO: Create a GameException class.
                throw new System.Exception("Can't load an unregistered scene.");
        }

        /// <summary>
        /// Loads a <see cref="Scene"/> in the <see cref="Game"/> and set it current.
        /// </summary>
        /// <param name="index">The index of the scene</param>
        public static void LoadScene(int index)
        {
            if (_sceneIsRegistered(index, out Scene scene))
                _loadScene(scene);
            else
                // TODO: Create a GameException class.
                throw new System.Exception("Can't load an unregistered scene.");
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
        /// <param name="index">The index of the scene.</param>
        public static bool IsRegistered(int index)
        {
            return MathHelper.Between(index, 0, SceneCount);
        }

        private static bool _sceneIsRegistered(int index, out Scene scene)
        {
            scene = null;

            if (MathHelper.Between(index, 0, SceneCount))
            {
                scene = _sceneRegistry[index];
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

        /// <summary>
        /// Returns the index of the <see cref="Scene"/>.
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        private static int _getSceneIndex(string name)
        {
            var result = -1;

            for (int i = 0, l = SceneCount; i < l; i++)
            {
                if (_sceneRegistry[i].Name == name)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        private static void _loadScene(Scene scene)
        {
            try
            {
                Game.Instance.SetNeedReload();
                Game.Instance.SetHasStarted(false);

                // Unload the last scene
                CurrentScene?.Unload();

                // Change the current scene
                _currentSceneIndex = _getSceneIndex(scene.Name);

                // Load the new scene
                CurrentScene?.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}