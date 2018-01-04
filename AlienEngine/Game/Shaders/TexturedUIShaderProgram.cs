using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class TexturedUIShaderProgram : ShaderProgram
    {
        public TexturedUIShaderProgram() : base(new TexturedUIVertexShader(), new TexturedUIFragmentShader())
        { }

        public void SetProjectionMatrix(Matrix4f projection)
        {
            SetUniform("projection_matrix", projection);
        }

        public void SetPosition(Vector3f position)
        {
            SetUniform("position", position);
        }

        public void SetTexture(uint textureUnit)
        {
            SetUniform("active_texture", textureUnit);
        }
    }
}
