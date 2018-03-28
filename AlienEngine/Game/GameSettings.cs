using AlienEngine.Core.Graphics.OpenGL;
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
        public static bool GammaCorrectionEnabled;

        // ----------
        // Enable/Disable shadow map
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> uses shadow map.
        /// </summary>
        public static bool ShadowMapEnabled;

        // ----------
        // Shadow map quality
        // ----------
        /// <summary>
        /// The quality of the texture of the shadow map.
        /// </summary>
        public static ShadowMapQuality ShadowMapQuality;

        // ----------
        // Anisotropy level
        // ----------
        /// <summary>
        /// The level of texture anisotropy.
        /// </summary>
        public static float AnisotropyLevel;
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
        public static bool MultisampleEnabled;

        // ----------
        // Level
        // ----------
        /// <summary>
        /// The level of multisampling.
        /// </summary>
        public static int MultisampleLevel;
        // --------------------

        // --------------------
        // V-Sync
        // --------------------
        // Enable/Disable V-Sync
        // ----------
        /// <summary>
        /// Define if the <see cref="Game"/> will use V-Sync.
        /// </summary>
        public static bool VSyncEnabled;

        // ----------
        // Interval
        // ----------
        /// <summary>
        /// The V-Sync interval.
        /// </summary>
        public static int VSyncInterval;
        // --------------------

        // --------------------
        // Window
        // --------------------
        // Window sizes
        // ----------
        /// <summary>
        /// The game window sizes.
        /// </summary>
        public static Sizei GameWindowSize;

        // ----------
        // Aspect ratio
        // ----------
        /// <summary>
        /// Defines if the game window's aspect ratio is defined.
        /// </summary>
        public static bool GameWindowHasAspectRatio;

        /// <summary>
        /// Defines the aspect ratio of the game window.
        /// </summary>
        public static int[] GameWindowAspectRatio;

        // ----------
        // Fullscreen mode
        // ----------
        /// <summary>
        /// Defines if the game window is in fullscreen mode.
        /// </summary>
        public static bool GameWindowFullscreenMode;

        // ----------
        // Resizable
        // ----------
        /// <summary>
        /// Defines if the game window is resizable or not.
        /// </summary>
        public static bool GameWindowResizable;

        // ----------
        // Title
        // ----------
        /// <summary>
        /// The game window's title.
        /// </summary>
        public static string GameWindowTitle;
        // --------------------

        // --------------------
        // Game
        // --------------------
        // Frames Per Secons
        // ----------
        /// <summary>
        /// The game FPS.
        /// </summary>
        public static int GameFps;
        // --------------------

        /// <summary>
        /// Stores the parsed config file.
        /// </summary>
        private static IniParser _config;
        
        static GameSettings()
        {
            // Parse the config file
            _config = new IniParser("game.ini");
        }
        
        /// <summary>
        /// Load game settings from the configuration file.
        /// These settings are loaded before the engine has started.
        /// </summary>
        public static void PreLoad()
        {
            int _int1, _int2;
            float _float1;

            if (int.TryParse(_config.SectionedResult["VSync"]["VSyncEnabled"], out _int1))
                VSyncEnabled = _int1 == 1;
            else
                VSyncEnabled = false;

            if (int.TryParse(_config.SectionedResult["VSync"]["VSyncInterval"], out _int1))
                VSyncInterval = _int1;
            else
                VSyncInterval = 0;

            if (int.TryParse(_config.SectionedResult["Window"]["Width"], out _int1) && int.TryParse(_config.SectionedResult["Window"]["Height"], out _int2))
                GameWindowSize = new Sizei(_int1, _int2);
            else
                GameWindowSize = Sizei.Zero;

            if (_config.SectionedResult["Window"]["AspectRatio"].Length > 0)
            {
                var ratio = _config.SectionedResult["Window"]["AspectRatio"].Split(':');
                if (ratio.Length == 2 && int.TryParse(ratio[0].Trim(), out _int1) && int.TryParse(ratio[1].Trim(), out _int2))
                {
                    GameWindowAspectRatio = new[] {_int1, _int2};
                    GameWindowHasAspectRatio = true;
                }
                else
                {
                    GameWindowAspectRatio = new[] {1, 1};
                    GameWindowHasAspectRatio = false;
                }
            }
            else
            {
                GameWindowAspectRatio = new[] {1, 1};
                GameWindowHasAspectRatio = false;
            }

            if (int.TryParse(_config.SectionedResult["Window"]["FullscreenMode"], out _int1))
                GameWindowFullscreenMode = _int1 == 1;
            else
                GameWindowFullscreenMode = false;

            if (int.TryParse(_config.SectionedResult["Window"]["Resizable"], out _int1))
                GameWindowResizable = _int1 == 1;
            else
                GameWindowResizable = true;

            if (_config.SectionedResult["Window"]["Title"].Length > 0)
                GameWindowTitle = _config.SectionedResult["Window"]["Title"];
            else
                GameWindowTitle = "AlienEngine Game";

            if (int.TryParse(_config.SectionedResult["Game"]["FPS"], out _int1))
                GameFps = _int1;
            else
                GameFps = 60;
        }

        /// <summary>
        /// Load game settings from the configuration file.
        /// These settings are loaded after the engine has started.
        /// </summary>
        public static void Initialize()
        {
            int _int1, _int2;
            float _float1;

            if (int.TryParse(_config.SectionedResult["Rendering"]["GammaCorrectionEnabled"], out _int1))
                GammaCorrectionEnabled = _int1 == 1;
            else
                GammaCorrectionEnabled = false;

            if (int.TryParse(_config.SectionedResult["Rendering"]["ShadowMapEnabled"], out _int1))
                ShadowMapEnabled = _int1 == 1;
            else
                ShadowMapEnabled = false;

            if (int.TryParse(_config.SectionedResult["Rendering"]["ShadowMapQuality"], out _int1))
                ShadowMapQuality = (ShadowMapQuality) _int1;
            else
                ShadowMapQuality = ShadowMapQuality.Low;

            if (float.TryParse(_config.SectionedResult["Rendering"]["AnisotropyLevel"], out _float1))
            {
                var aniso = GL.IsExtensionSupported(GL.EXT.TextureFilterAnisotropic) ? GL.GetFloat(GetPName.MaxTextureMaxAnisotropyExt) : 0.0f;
                AnisotropyLevel = MathHelper.Clamp(_float1, 0.0f, aniso);
            }
            else
            {
                AnisotropyLevel = 0.0f;
            }

            if (int.TryParse(_config.SectionedResult["Multisample"]["MultisampleEnabled"], out _int1))
                MultisampleEnabled = _int1 == 1;
            else
                MultisampleEnabled = false;

            if (int.TryParse(_config.SectionedResult["Multisample"]["MultisampleLevel"], out _int1))
                MultisampleLevel = _int1;
            else
                MultisampleLevel = 0;
        }
    }
}