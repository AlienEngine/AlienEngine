using AlienEngine.ASL;

namespace AlienEngine.Shaders.Samples
{
    public class FontFragmentShader : FragmentShader
    {
        [In] vec2 texCoords;

        [Out] vec4 color;

        [Uniform] sampler2D text;
        [Uniform] vec4 textColor;

        void main()
        {
            vec4 t = new vec4(1, 1, 1, texture2D(text, texCoords).r);
            color = t * textColor;
        }
    }
}