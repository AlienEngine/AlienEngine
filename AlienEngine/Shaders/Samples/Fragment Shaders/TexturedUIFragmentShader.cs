using System;
using AlienEngine.ASL;

namespace AlienEngine.Shaders.Samples
{
    [Version(330)]
    public class TexturedUIFragmentShader : FragmentShader
    {
        [Uniform] sampler2D active_texture;

        [In] vec2 uv;

        void main()
        {
            gl_FragColor = texture(active_texture, uv);
        }
    }
}
