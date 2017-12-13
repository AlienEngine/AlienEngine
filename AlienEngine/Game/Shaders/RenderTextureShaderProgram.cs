using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class RenderTextureShaderProgram : ShaderProgram
    {
        public PostEffectMode PostEffectMode
        {
            set
            {
                Bind();
                SetUniform("postEffectMode", (int)value);
                Unbind();
            }
        }

        public int Width
        {
            set
            {
                Bind();
                SetUniform("width", value);
                Unbind();
            }
        }

        public int Height
        {
            set
            {
                Bind();
                SetUniform("height", value);
                Unbind();
            }
        }

        public RenderTextureShaderProgram() : base(new RenderTextureVertexShader(), new RenderTextureFragmentShader())
        { }
    }
}
