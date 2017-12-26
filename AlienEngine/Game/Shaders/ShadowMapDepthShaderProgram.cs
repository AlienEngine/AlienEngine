using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    internal class ShadowMapDepthShaderProgram: ShaderProgram
    {
        public ShadowMapDepthShaderProgram(): base(new ShadowMapDepthVertexShader(), new ShadowMapDepthFragmentShader())
        { }
    }
}