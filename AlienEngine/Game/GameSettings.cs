using AlienEngine.Core.Rendering;
using AlienEngine.Core.Utils;
using AlienEngine.Core.Rendering.Shadows;

namespace AlienEngine.Core.Game
{
    /// <summary>
    /// Load game settings from the game settings file
    /// (game.ini) and give read only access to its values.
    /// </summary>
    public static class GameSettings
    {
        // --------------------
        // Rendering
        // --------------------
        // Enable/Disable gamma correction
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> uses gamma correction.
        /// </summary>
        public static readonly bool GammaCorrectionEnabled;
        // ----------
        // Enable/Disable shadow map
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> uses shadow map.
        /// </summary>
        public static readonly bool ShadowMapEnabled;
        // ----------
        // Shadow map quality
        // ----------
        /// <summary>
        /// The quality of the texture of the shadow map.
        /// </summary>
        public static readonly ShadowMapQuality ShadowMapQuality;
        // --------------------
        
        // --------------------
        // Multisample Anti Aliasing
        // --------------------
        // Enable/Disable MSAA
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
        // Enable/Disable V-Sync
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
        /// <summary>
        /// Defines the aspect ratio of the game window.
        /// </summary>
        public static readonly int[] GameWindowAspectRatio;
        // ----------
        // Fullscreen mode
        // ----------
        /// <summary>
        /// Defines if the game window is in fullscreen mode.
        /// </summary>
        public static readonly bool GameWindowFullscreenMode;
        // ----------
        // Resizable
        // ----------
        /// <summary>
        /// Defines if the game window is resizable or not.
        /// </summary>
        public static readonly bool GameWindowResizable;
        // ----------
        // Title
        // ----------
        /// <summary>
        /// The game window's title.
        /// </summary>
        public static readonly string GameWindowTitle;
        // --------------------

        // --------------------
        // Game
        // --------------------
        // Frames Per Secons
        // ----------
        /// <summary>
        /// The game FPS.
        /// </summary>
        public static readonly int GameFps;
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
            if (int.TryParse(config.SectionedResult["Rendering"]["GammaCorrection"], out _int1))
                GammaCorrectionEnabled = _int1 == 1;
            else
                GammaCorrectionEnabled = false;
            
            if (int.TryParse(config.SectionedResult["Rendering"]["ShadowMap"], out _int1))
                ShadowMapEnabled = _int1 == 1;
            else
                ShadowMapEnabled = false;

            if (int.TryParse(config.SectionedResult["Rendering"]["ShadowMapQuality"], out _int1))
                ShadowMapQuality = (ShadowMapQuality)_int1;
            else
                ShadowMapQuality = ShadowMapQuality.Low;

            if (int.TryParse(config.SectionedResult["Multisample"]["MultisampleEnabled"], out _int1))
                MultisampleEnabled = _int1 == 1;
            else
                MultisampleEnabled = false;

            if (int.TryParse(config.SectionedResult["Multisample"]["MultisampleLevel"], out _int1))
                MultisampleLevel = _int1;
            else
                MultisampleLevel = 0;

            if (int.TryParse(config.SectionedResult["VSync"]["VSyncEnabled"], out _int1))
                VSyncEnabled = _int1 == 1;
            else
                VSyncEnabled = false;

            if (int.TryParse(config.SectionedResult["VSync"]["VSyncInterval"], out _int1))
                VSyncInterval = _int1;
            else
                VSyncInterval = 0;

            if (int.TryParse(config.SectionedResult["Window"]["Width"], out _int1) && int.TryParse(config.SectionedResult["Window"]["Height"], out _int2))
                GameWindowSize = new Sizei(_int1, _int2);
            else
                GameWindowSize = Sizei.Zero;

            if (config.SectionedResult["Window"]["AspectRatio"].Length > 0)
            {
                var ratio = config.SectionedResult["Window"]["AspectRatio"].Split(':');
                if (int.TryParse(ratio[0].Trim(), out _int1) && int.TryParse(ratio[1].Trim(), out _int2))
                    GameWindowAspectRatio = new int[] { _int1, _int2 };
                else
                    GameWindowAspectRatio = new int[] { 16, 9 };
            }
            else
                GameWindowAspectRatio = new int[] { 16, 9 };

            if (int.TryParse(config.SectionedResult["Window"]["FullscreenMode"], out _int1))
                GameWindowFullscreenMode = _int1 == 1;
            else
                GameWindowFullscreenMode = false;

            if (int.TryParse(config.SectionedResult["Window"]["Resizable"], out _int1))
                GameWindowResizable = _int1 == 1;
            else
                GameWindowResizable = true;

            if (config.SectionedResult["Window"]["Title"].Length > 0)
                GameWindowTitle = config.SectionedResult["Window"]["Title"];
            else
                GameWindowTitle = "AlienEngine Game";

            if (int.TryParse(config.SectionedResult["Game"]["FPS"], out _int1))
                GameFps = _int1;
            else
                GameFps = 60;

        }
    }
}
