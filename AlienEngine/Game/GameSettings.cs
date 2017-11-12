using AlienEngine.Core.Utils;

namespace AlienEngine.Core.Game
{
    /// <summary>
    /// Load game settings from the game settings file
    /// (game.ini) and give read only access to its values.
    /// </summary>
    public static class GameSettings
    {
        // --------------------
        // Multisample
        // --------------------
        // Enabled/Disabled state
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> will use multisample
        /// when rendering.
        /// </summary>
        public static readonly bool MultisampleEnabled;
        // ----------
        // Level
        // ----------
        /// <summary>
        /// The level of multisampling.
        /// </summary>
        public static readonly int MultisampleLevel;
        // --------------------

        // --------------------
        // V-Sync
        // --------------------
        // Enabled/Disabled state
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> will use V-Sync.
        /// </summary>
        public static readonly bool VSyncEnabled;
        // ----------
        // Interval
        // ----------
        /// <summary>
        /// The V-Sync interval.
        /// </summary>
        public static readonly int VSyncInterval;
        // --------------------

        // --------------------
        // Window
        // --------------------
        // Window sizes
        // ----------
        /// <summary>
        /// The game window sizes.
        /// </summary>
        public static readonly Sizei GameWindowSize;
        // ----------
        // Aspect ratio
        // ----------
        public static readonly int[] GameWindowAspectRatio;
        // ----------
        // Fullscreen mode
        // ----------
        /// <summary>
        /// Define if the game window is in fullscreen mode.
        /// </summary>
        public static readonly bool GameWindowFullscreenMode;
        // ----------
        // Resizable
        // ----------
        /// <summary>
        /// Define if the game window is resizable or not.
        /// </summary>
        public static readonly bool GameWindowResizable;
        // --------------------

        /// <summary>
        /// Load game settings from the configuration file.
        /// </summary>
        static GameSettings()
        {
            int _int1, _int2;

            // Parse the config file
            IniParser config = new IniParser("game.ini");

            // Get parsed values
            if (int.TryParse(config.RawResult["MultisampleEnabled"], out _int1))
                MultisampleEnabled = _int1 == 1;
            else
                MultisampleEnabled = false;

            if (int.TryParse(config.RawResult["MultisampleLevel"], out _int1))
                MultisampleLevel = _int1;
            else
                MultisampleLevel = 0;

            if (int.TryParse(config.RawResult["VSyncEnabled"], out _int1))
                VSyncEnabled = _int1 == 1;
            else
                VSyncEnabled = false;

            if (int.TryParse(config.RawResult["VSyncInterval"], out _int1))
                VSyncInterval = _int1;
            else
                VSyncInterval = 0;

            if (int.TryParse(config.RawResult["Width"], out _int1) && int.TryParse(config.RawResult["Height"], out _int2))
                GameWindowSize = new Sizei(_int1, _int2);
            else
                GameWindowSize = Sizei.Zero;

            if (config.RawResult["AspectRatio"].Length > 0)
            {
                var ratio = config.RawResult["AspectRatio"].Split(':');
                if (int.TryParse(ratio[0].Trim(), out _int1) && int.TryParse(ratio[1].Trim(), out _int2))
                    GameWindowAspectRatio = new int[] { _int1, _int2 };
                else
                    GameWindowAspectRatio = new int[] { 16, 9 };
            }
            else
                GameWindowAspectRatio = new int[] { 16, 9 };

            if (int.TryParse(config.RawResult["FullscreenMode"], out _int1))
                GameWindowFullscreenMode = _int1 == 1;
            else
                GameWindowFullscreenMode = false;

            if (int.TryParse(config.RawResult["Resizable"], out _int1))
                GameWindowResizable = _int1 == 1;
            else
                GameWindowResizable = true;
        }
    }
}
