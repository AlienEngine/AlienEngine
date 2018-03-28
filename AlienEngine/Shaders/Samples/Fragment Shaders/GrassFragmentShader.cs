using AlienEngine.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class GrassFragmentShader : FragmentShader
    {
        [In] vec2 uv;

        [Out] vec4 color;
        
        [Uniform] sampler2D grassTexture;

        void main()
        {
            vec4 texColor = texture(grassTexture, uv);
            if (texColor.a < 0.1f)
            {
                __output("discard");
            }

            color = texColor;
        }
    }
}
