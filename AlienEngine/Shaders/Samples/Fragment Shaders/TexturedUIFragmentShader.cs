using AlienEngine.Shaders.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class TexturedUIFragmentShader : FragmentShader
    {
        [Out] vec4 FragColor;

        [Uniform] sampler2D active_texture;

        [In] vec2 uv;

        void main()
        {
            FragColor = texture(active_texture, uv);
        }
    }
}
