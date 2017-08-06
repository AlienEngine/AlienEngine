using AlienEngine.Core.Graphics.Shaders;

namespace AlienEngine.Shaders
{
    public class CubemapShaderProgram : ShaderProgram
    {
        public CubemapShaderProgram() : base(new CubemapVertexShader(), new CubemapFragmentShader())
        { }
    }
}
