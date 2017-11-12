using System;
using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Shaders.Samples
{
    [Version(330)]
    public class TexturedUIVertexShader : VertexShader
    {
        [Uniform] vec3 position;
        [Uniform] mat4 projection_matrix;

        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;
        [Layout(Location = GL.VERTEX_TEXTURE_COORD_LOCATION)] [In] vec2 in_uv;

        [Out] vec2 uv;

        void main()
        {
            uv = in_uv;
            vec4 pos = projection_matrix * new vec4(position + in_position, 1);
            gl_Position = pos.xyww;
        }
    }
}
