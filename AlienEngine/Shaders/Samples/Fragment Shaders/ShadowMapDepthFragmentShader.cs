using AlienEngine.Shaders.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class ShadowMapDepthFragmentShader: FragmentShader
    {
        [Out] vec4 FragColor;

        void main()
        {
            FragColor = new vec4(0, 0, 0, 1);
        }
    }
}