using AlienEngine.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class ColoredUIFragmentShader: FragmentShader
    {
        [Uniform] vec4 color;

        void main()
        {
            gl_FragColor = color;
        }
    }
}