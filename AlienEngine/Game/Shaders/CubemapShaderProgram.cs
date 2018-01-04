using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class CubemapShaderProgram : ShaderProgram
    {
        public CubemapShaderProgram() : base(new CubemapVertexShader(), new CubemapFragmentShader())
        { }
    }
}
