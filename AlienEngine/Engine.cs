using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Audio;
using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core
{
    public static class Engine
    {
        private static AudioContext _audioContext;

        public static void Start()
        {
            // Initialize OpenGL
            GL.LoadOpenGL();

            // Initialize DevIL
            IL.Init();
            ILU.Init();
            ILUT.Init();

            // Set DevIL default renderer
            ILUT.Renderer(ILUT.ILUT_OPENGL);

            // Initialize OpenAL and EFX
            _audioContext = new AudioContext();
            if (!_audioContext.IsCurrent)
                _audioContext.MakeCurrent();
        }

        public static void Stop()
        {
            // Dispose OpenAL
            _audioContext.Dispose();

            // Dispose all other resources
            ResourcesManager.DisposeResources();
        }
    }
}
