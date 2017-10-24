using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Graphics;

namespace AlienEngine.Core.Game
{
    public abstract class Game
    {
       /// <summary>
        /// The window who handle the game.
        /// </summary>
        private static GameWindow _gameWindow = GameWindow.None;

        /// <summary>
        /// The current scene.
        /// </summary>
        private static Scene _currentScene;

        /// <summary>
        /// Define if the game has already started.
        /// </summary>
        private static bool _hasStarted;

        /// <summary>
        /// The window who handle the game.
        /// </summary>
        public static GameWindow Window => _gameWindow;

        /// <summary>
        /// The current scene.
        /// </summary>
        public static Scene CurrentScene => _currentScene;

        public static bool HasStarted => _hasStarted;

        public static void Start()
        {
            _hasStarted = true;
        }

        public static void Stop()
        {
            _hasStarted = false;
        }

        public static void SetGameWindow(GameWindow w)
        {
            _gameWindow = w;
            Input.Refresh();
        }

        public static void LoadScene(Scene scene)
        {
            _currentScene = scene;
        }
    }
}