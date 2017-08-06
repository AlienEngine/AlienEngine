using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Graphics.Shaders.Samples;

namespace AlienEngine.Shaders
{
    public class BumpedDiffuseShaderProgram : ShaderProgram
    {
        public BumpedDiffuseShaderProgram() : base(new DiffuseVertexShader(), new BumpedDiffuseFragmentShader())
        {
            SetGlobal("MAX_NUMBER_OF_LIGHTS", System.Math.Max(1, Game.CurrentScene.Lights.Length).ToString());
        }
    }
}
