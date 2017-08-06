using AlienEngine.ASL;
using AlienEngine.Core.Graphics.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
