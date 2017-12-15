using AlienEngine.Core;
using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using System;
using System.Threading;

namespace AlienEngine
{
    public abstract class Application
    {
        #region Fields
        
        /// <summary>
        /// The game window.
        /// </summary>
        private GameWindow _window;

        private FBO _renderFBO;

        private FBO _screenFBO;

        private static Application _instance;

        #endregion

        #region Properties

        public static Application Instance => _instance;

        /// <summary>
        /// The game window.
        /// </summary>
        public GameWindow Window => _window;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Application()
        {
            if (_instance == null)
            {
                // Create the game window
                _window = new GameWindow(GameSettings.GameWindowSize, GameSettings.GameWindowTitle);

                _instance = this;
            }
        }

        /// <summary>
        /// Stop the <see cref="Game"/>, dispose all
        /// resources and close the application.
        /// </summary>
        public static void Quit()
        {
            _instance._stop();
        }

        public void Start()
        {
            if (Game.Instance.Running) return;
            else _run();
        }

        private void _run()
        {
            try
            {
                // Initialize the game
                Init();

                // Show the game window
                _window.Show();

                // Run the game loop
                _loop();
            }
            finally
            {
                _destroy();
            }
        }

        private void _loop()
        {
            int frames = 0;
            int frameCounter = 0;

            double frameTime = Time.SECOND / GameSettings.GameFPS;

            // Save the last frame time
            double lastTime = Time.GetTime();
            double unprocessedTime = 0;

            // Start the game.
            Game.Instance.Start();

            // Run the rendering loop until the user has attempted to close the window.
            while (Game.Instance.Running)
            {
                bool rend = false;

                // Save the first frame time
                double startTime = Time.GetTime();

                // The time between the fist and the last time
                double passedTime = startTime - lastTime;

                // Restore the last frame time
                lastTime = startTime;

                double deltaTime = passedTime / Time.SECOND;

                unprocessedTime += passedTime;
                frameCounter += (int)passedTime;

                Game.Instance.CurrentScene.BeforeUpdate();

                while (unprocessedTime >= frameTime)
                {
                    rend = true;

                    // Sets the delta time
                    Time.SetDelta(Game.Instance.Paused ? 0 : deltaTime);

                    // Update all game elements and components
                    Game.Instance.Update();

                    // Update input manager
                    Input.Update();

                    if (_window.ShouldClose())
                    {
                        _stop();
                    }

                    if (frameCounter >= Time.SECOND)
                    {
                        frames = 0;
                        frameCounter = 0;
                    }

                    unprocessedTime -= frameTime;
                }

                Game.Instance.CurrentScene.AfterUpdate();

                if (rend)
                {
                    Render();
                    frames++;
                }
                else
                {
                    try
                    {
                        Thread.Sleep(1);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private void _stop()
        {
            if (!Game.Instance.Running) return;
            else Game.Instance.Stop();
        }

        private void _destroy()
        {
            // Close the game window
            _window.Destroy();

            // Stop the engine
            Engine.Stop();
        }

        public virtual void Init()
        {
            // Set the created window current
            _window.SetCurrent();

            // Make the OpenGL context current
            GameWindow.MakeContextCurrent(ref _window);

            // Initialize AlienEngine
            Engine.Start();

            // Create framebuffer objects
            _renderFBO = new FBO(GameSettings.GameWindowSize, mipmaps: false, multisampled: GameSettings.MultisampleEnabled);
            _screenFBO = new FBO(_renderFBO.Size, mipmaps: false);

            // Set the renderer viewport
            int wi, he;
            _window.GetFramebufferSize(out wi, out he);
            RendererManager.SetViewport(0, 0, wi, he);

            // Enable depth testing
            RendererManager.DepthTest();

            // Enable blending
            RendererManager.Blending();

            // Enable face culling
            RendererManager.FaceCulling();

            // Enable Multi Samples
            RendererManager.MultiSample();

            // Enable depth mask
            RendererManager.DepthMask();

            // Initialize inputs
            Input.Init();
        }

        public void Render()
        {
            // Clear the screen
            RendererManager.ClearScreen(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            // Enable Framebuffer
            _renderFBO.Enable();

            // Render the scene.
            Game.Instance.CurrentScene.Render();

            // Disable framebufer
            _renderFBO.Disable(_screenFBO);

            // Render the screen (output of the frame buffer)
            RendererManager.RenderScreen(GameSettings.MultisampleEnabled ? _screenFBO : _renderFBO);

            // Swap front and back buffers
            GameWindow.SwapBuffers(ref _window);

            // Poll for and process events
            GameWindow.PollEvents();
        }
    }
}
