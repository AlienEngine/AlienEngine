using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Graphics;
using System.Collections.Generic;

namespace AlienEngine.Core.Game
{
    public abstract class Game
    {
        /// <summary>
        /// The unique instance of the <see cref="Game"/>.
        /// </summary>
        private static Game _instance;

        /// <summary>
        /// The window who handle the game.
        /// </summary>
        private GameWindow _gameWindow = GameWindow.None;

        /// <summary>
        /// The current scene.
        /// </summary>
        private Scene _currentScene;

        /// <summary>
        /// The list of <see cref="Scene"/>s in the <see cref="Game"/>.
        /// </summary>
        private List<Scene> _registeredScenes;

        /// <summary>
        /// Define if the game has already started.
        /// </summary>
        private bool _hasStarted;

        /// <summary>
        /// Defines if the game is paused.
        /// </summary>
        private bool _isPaused;

        /// <summary>
        /// The window who handle the game.
        /// </summary>
        public GameWindow Window => _gameWindow;

        /// <summary>
        /// The current scene.
        /// </summary>
        public Scene CurrentScene => _currentScene;

        /// <summary>
        /// Defines if the <see cref="Game"/> has already started.
        /// </summary>
        public bool Started => _hasStarted;

        /// <summary>
        /// Defines if the <see cref="Game"/> is paused.
        /// </summary>
        public bool Paused => _isPaused;

        /// <summary>
        /// The unique game instance.
        /// </summary>
        public static Game Instance
        {
            get { return _instance; }
            private set
            {
                if (_instance == null)
                    _instance = value;
            }
        }

        /// <summary>
        /// Initialize the game.
        /// </summary>
        protected Game()
        {
            Instance = this;

            _registeredScenes = new List<Scene>();
        }

        /// <summary>
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public virtual void Start()
        {
            if (_currentScene != null)
            {
                _currentScene.Start();
                _hasStarted = true;
            }
            else throw new System.Exception("Can't start the game without a scene. Use Game.LoadScene() first.");
        }

        /// <summary>
        /// Stops the <see cref="Game"/>.
        /// </summary>
        public virtual void Stop()
        {
            if (_currentScene != null)
                _currentScene.Stop();

            _hasStarted = false;
        }

        /// <summary>
        /// Loads a <see cref="Scene"/> in the <see cref="Game"/> and set it current.
        /// </summary>
        /// <param name="name">The name of the scene</param>
        public void LoadScene(string name)
        {
            if (_sceneIsRegistered(name))
                _loadScene(_getRegisteredScene(name));
            else
                // TODO: Create a GameException class.
                throw new System.Exception("Can't load an unregistered scene.");
        }

        /// <summary>
        /// Loads a <see cref="Scene"/> in the <see cref="Game"/> and set it current.
        /// </summary>
        /// <param name="index">The index of the scene</param>
        public void LoadScene(int index)
        {
            try
            {
                _loadScene(_registeredScenes[index]);
            }
            catch (System.Exception)
            {
                // TODO: Create a GameException class.
                throw new System.Exception("Can't load an unregistered scene.");
            }
        }

        /// <summary>
        /// Updates the <see cref="Game"/> on each frames.
        /// </summary>
        public void Update()
        {
            _currentScene.Update();
        }

        /// <summary>
        /// Pauses the <see cref="Game"/>.
        /// </summary>
        public void Pause()
        {
            _isPaused = true;
        }

        /// <summary>
        /// Adds a <see cref="Scene"/> in the <see cref="Game"/>.
        /// </summary>
        /// <param name="scene">The scene to add.</param>
        protected int AddScene(Scene scene)
        {
            _registeredScenes.Add(scene);
            return _registeredScenes.Count - 1;
        }

        internal void SetGameWindow(GameWindow w)
        {
            SetGameWindow(ref w);
        }

        internal void SetGameWindow(ref GameWindow w)
        {
            _gameWindow = w;
            Input.Refresh();
        }

        private void _loadScene(Scene scene)
        {
            if (_currentScene != null)
                _currentScene.Unload();

            _currentScene = scene;

            _currentScene.Load();
        }

        /// <summary>
        /// Checks if the given scene's name is registered
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        /// <returns></returns>
        private bool _sceneIsRegistered(string name)
        {
            bool result = false;

            foreach (var  item in _registeredScenes)
            {
                if (item.Name == name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a registered <see cref="Scene"/>.
        /// </summary>
        /// <param name="name">The nme of the scene.</param>
        private Scene _getRegisteredScene(string name)
        {
            foreach (Scene scene in _registeredScenes)
            {
                if (scene.Name == name)
                    return scene;
            }

            return null;
        }

        /// <summary>
        /// Returns the index of the <see cref="Scene"/>.
        /// </summary>
        /// <param name="name">The name of the scene.</param>
        private int _getSceneIndex(string name)
        {
            var result = -1;

            for (int i = 0, l = _registeredScenes.Count; i < l; i++)
            {
                if (_registeredScenes[i].Name == name)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}