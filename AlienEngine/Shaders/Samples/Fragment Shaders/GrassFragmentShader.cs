using AlienEngine.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class GrassFragmentShader : FragmentShader
    {
        [In] vec2 uv;

        [Uniform] sampler2D grassTexture;

        void main()
        {
            vec4 texColor = texture(grassTexture, uv);
            if (texColor.a < 0.1f)
            {
                __output("discard");
            }

            gl_FragColor = texColor;
        }
    }
}
