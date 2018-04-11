using AlienEngine.Shaders.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class ColoredUIFragmentShader: FragmentShader
    {
        [Uniform] vec4 color;

        [Out] vec4 outColor;

        void main()
        {
            outColor = color;
        }
    }
}