using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Graphics.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class BumpedDiffuseShaderProgram : ShaderProgram
    {
        public BumpedDiffuseShaderProgram() : base(new DiffuseVertexShader(), new BumpedDiffuseFragmentShader())
        { }
    }
}
