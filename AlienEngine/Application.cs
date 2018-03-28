using AlienEngine.Core;
using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using System;
using System.Threading;
using AlienEngine.Core.Graphics.Buffers;

namespace AlienEngine
{
    public abstract class Application
    {
        #region Fields

        /// <summary>
        /// The game window.
        /// </summary>
        private GameWindow _window;

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
        protected Application()
        {
            if (_instance == null)
            {
                // Initialize game settings
                GameSettings.PreLoad();

                // Create the game window
                _window = new GameWindow(GameSettings.GameWindowSize, GameSettings.GameWindowTitle);

                // Store this instance
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
            if (!Game.Instance.Running)
                _run();
        }

        private void _run()
        {
            try
            {
                // Run the game loop
                _loop();
            }
            finally
            {
				// Destroy the game
                _destroy();
            }
        }

        private void _loop()
        {
            if (Game.Instance.NeedReload)
            {
				// Reload the game
                Reload();
            }
            else
            {
                // Initialize the game
                Initialize();

                // Show the game window
                _window.Show();
            }

            int frames = 0;
            int frameCounter = 0;

            double frameTime = Time.SECOND / GameSettings.GameFps;

            // Save the last frame time
            double lastTime = Time.GetTime();
            double unprocessedTime = 0;

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
                frameCounter += (int) passedTime;

                Game.Instance.BeforeUpdate();

                while (unprocessedTime >= frameTime)
                {
                    if (_window.ShouldClose())
                    {
                        _stop();
                    }

                    if (frameCounter >= Time.SECOND)
                    {
                        frames = 0;
                        frameCounter = 0;
                    }

                    rend = true;

                    // Sets the delta time
                    Time.SetDelta(Game.Instance.Paused ? 0 : deltaTime);

                    // Update all game elements and components
                    Game.Instance.Update();

                    // Update input manager
                    Input.Update();

                    unprocessedTime -= frameTime;
                }

                Game.Instance.AfterUpdate();

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
            
            if (Game.Instance.NeedReload)
                _loop();
        }

        private void _stop()
        {
            if (Game.Instance.Running)
                Game.Instance.Stop();
        }

        private void _destroy()
        {
            // Close the game window
            _window.Destroy();

            // Stop the engine
            Engine.Stop();
        }

        public virtual void Initialize()
        {
            // Set the created window current
            _window.SetCurrent();

            // Make the OpenGL context current
            GameWindow.MakeContextCurrent(ref _window);

            // Initialize AlienEngine
            Engine.Start();

            // Set the renderer viewport and the aspect ratio
            int wi, he;
            _window.GetFramebufferSize(out wi, out he);

            if (GameSettings.GameWindowHasAspectRatio)
                RendererManager.SetViewportWithAspectRatio(wi, he);
            else
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

            // Start the game.
            Game.Instance.Start();

            // Initialize the renderer manager
            RendererManager.Initialize();
        }

        public virtual void Reload()
        {
            // Reload the game
            Game.Instance.Reload();

            // Initialize the renderer manager
            // RendererManager.Initialize();
        }
        
        public void Render()
        {
            // Process rendering
            RendererManager.Process();

            // Swap front and back buffers
            GameWindow.SwapBuffers(ref _window);

            // Poll for and process events
            GameWindow.PollEvents();
        }
    }
}