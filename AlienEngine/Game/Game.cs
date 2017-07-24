using AlienEngine.Core.Graphics.GLFW;

namespace AlienEngine.Core.Game
{
    public static class Game
    {
        /// <summary>
        /// The window who handle the game.
        /// </summary>
        private static GLFW.Window _gameWindow = GLFW.Window.None;

        /// <summary>
        /// The current scene.
        /// </summary>
        private static Scene _currentScene;

        /// <summary>
        /// The current camera of the scene.
        /// </summary>
        private static GameElement _currentCamera = null;

        /// <summary>
        /// The current sound listener of the scene.
        /// </summary>
        private static GameElement _currentAudioListener = null;

        /// <summary>
        /// Define if the game has already started.
        /// </summary>
        private static bool _hasStarted = false;

        /// <summary>
        /// The window who handle the game.
        /// </summary>
        public static GLFW.Window Window
        {
            get { return _gameWindow; }
        }

        /// <summary>
        /// The current scene.
        /// </summary>
        public static Scene CurrentScene
        {
            get { return _currentScene; }
        }

        /// <summary>
        /// The primary camera (the currently used one) of the game.
        /// </summary>
        public static GameElement CurrentCamera
        {
            get { return _currentCamera; }
        }

        /// <summary>
        /// The current sound listener.
        /// </summary>
        public static GameElement CurrentAudioListener
        {
            get { return _currentAudioListener; }
        }

        public static bool HasStarted
        {
            get { return _hasStarted; }
        }

        public static void Start()
        {
            _hasStarted = true;
        }

        public static void Stop()
        {
            _hasStarted = false;
        }

        public static void SetPrimaryCamera(GameElement c)
        {
            if (c.HasComponent<Camera>())
                _currentCamera = c;
        }

        public static void SetGameWindow(GLFW.Window w)
        {
            _gameWindow = w;
            Input.Refresh();
        }

        public static void SetCurrentAudioListener(GameElement c)
        {
            if (c.HasComponent<AudioListener>())
                _currentAudioListener = c;
        }

        public static void SetCurrentScene(Scene scene)
        {
            _currentScene = scene;
        }
    }
}