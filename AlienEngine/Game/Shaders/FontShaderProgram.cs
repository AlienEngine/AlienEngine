using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class FontShaderProgram: ShaderProgram
    {
        public FontShaderProgram() : base(new FontVertexShader(), new FontFragmentShader())
        {
            
        }
    }
}