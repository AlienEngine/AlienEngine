using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class DiffuseShaderProgram : ShaderProgram
    {
        public DiffuseShaderProgram() : base(new DiffuseVertexShader(), new DiffuseFragmentShader())
        { }
    }
}
