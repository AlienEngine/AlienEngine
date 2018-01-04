using AlienEngine.Core.Shaders;
using AlienEngine.Core.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class ColoredUIShaderProgram: ShaderProgram
    {
        public ColoredUIShaderProgram(): base(new ColoredUIVertexShader(), new ColoredUIFragmentShader())
        {}

        public void SetProjectionMatrix(Matrix4f projection)
        {
            SetUniform("projection_matrix", projection);
        }

        public void SetPosition(Vector3f position)
        {
            SetUniform("position", position);
        }

        public void SetColor(Color4 color)
        {
            SetUniform("color", color);
        }
    }
}