using AlienEngine.ASL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    internal class CubemapFragmentShader : FragmentShader
    {
        [Out] vec4 FragColor;

        [In] vec3 position;

        [Uniform] samplerCube textureCubemap;

        void main()
        {
            FragColor = texture(textureCubemap, position);
        }
    }
}
