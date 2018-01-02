using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class BumpedDiffuseShaderProgram : ShaderProgram
    {
        public BumpedDiffuseShaderProgram() : base(new DiffuseVertexShader(), new BumpedDiffuseFragmentShader())
        { }
    }
}
