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
        /// Define if the game has already started.
        /// </summary>
        private bool _hasStarted;

        /// <summary>
        /// Defines if the game is paused.
        /// </summary>
        private bool _isPaused;

        /// <summary>
        /// Defines if the game has to be reloaded.
        /// </summary>
        private bool _needReload;

        /// <summary>
        /// The window who handle the game.
        /// </summary>
        public GameWindow Window => _gameWindow;

        /// <summary>
        /// Defines if the <see cref="Game"/> has already started.
        /// </summary>
        public bool Running => _hasStarted;

        /// <summary>
        /// Defines if the <see cref="Game"/> is paused.
        /// </summary>
        public bool Paused => _isPaused;

        /// <summary>
        /// Defines if the <see cref="Game"/> has to be reloaded after a scene load.
        /// </summary>
        public bool NeedReload => _needReload;
        
        /// <summary>
        /// The unique game instance.
        /// </summary>
        public static Game Instance => _instance;

        /// <summary>
        /// Initialize the game.
        /// </summary>
        protected Game()
        {
            if (_instance == null)
            {
                SceneManager.Initialize();
                _instance = this;
            }
        }

        /// <summary>
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public virtual void Start()
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.Start();
                _hasStarted = true;
                _needReload = false;
            }
            else throw new System.Exception("Can't start the game without a scene. Use Game.LoadScene() first.");
        }

        /// <summary>
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public void Reload()
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.Start();
                _hasStarted = true;
                _needReload = false;
            }
            else throw new System.Exception("Can't start the game without a scene. Use Game.LoadScene() first.");
        }

        /// <summary>
        /// Stops the <see cref="Game"/>.
        /// </summary>
        public virtual void Stop()
        {
            if (SceneManager.CurrentScene != null)
                SceneManager.CurrentScene.Stop();

            _hasStarted = false;
            _needReload = false;
        }

        /// <summary>
        /// Trigerred before the <see cref="Game"/> updates.
        /// </summary>
        public void BeforeUpdate()
        {
            if (_hasStarted)
                SceneManager.CurrentScene.BeforeUpdate();
        }

        /// <summary>
        /// Updates the <see cref="Game"/> on each frames.
        /// </summary>
        public void Update()
        {
            if (_hasStarted)
                SceneManager.CurrentScene.Update();
        }

        /// <summary>
        /// Trigerred after the <see cref="Game"/> updates.
        /// </summary>
        public void AfterUpdate()
        {
            if (_hasStarted)
                SceneManager.CurrentScene.AfterUpdate();
        }

        /// <summary>
        /// Render the <see cref="Game"/> on each frames.
        /// </summary>
        public void Render()
        {
            if (_hasStarted)
                SceneManager.CurrentScene.Render();
        }
        
        /// <summary>
        /// Pauses the <see cref="Game"/>.
        /// </summary>
        public void Pause(bool state = true)
        {
            _isPaused = state;
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

        internal void SetNeedReload(bool state = true)
        {
            _needReload = state;
        }

        internal void SetHasStarted(bool state = true)
        {
            _hasStarted = state;
        }
    }
}