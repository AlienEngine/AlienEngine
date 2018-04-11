using AlienEngine.Shaders.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class FontFragmentShader : FragmentShader
    {
        [In] vec2 texCoords;

        [Out] vec4 color;

        [Uniform] sampler2D text;
        [Uniform] vec4 textColor;

        void main()
        {
            vec4 t = new vec4(1, 1, 1, texture(text, texCoords).r);
            color = t * textColor;
        }
    }
}