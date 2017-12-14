using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class FontShaderProgram: ShaderProgram
    {
        public FontShaderProgram() : base(new FontVertexShader(), new FontFragmentShader())
        { }
    }
}