using AlienEngine.ASL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics.Shaders.Samples
{
    [Version("330 core")]
    public class GrassFragmentShader : FragmentShader
    {
        [In] vec2 uv;

        [Uniform] sampler2D grassTexture;

        void main()
        {
            vec4 texColor = texture(grassTexture, uv);
            if (texColor.a < 0.1)
            {
                __output("discard");
            }

            gl_FragColor = texColor;
        }
    }
}
