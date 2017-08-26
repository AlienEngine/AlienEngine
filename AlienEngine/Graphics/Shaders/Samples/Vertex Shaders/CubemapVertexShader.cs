using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics.Shaders
{
    internal class CubemapVertexShader : VertexShader
    {
        // Default VAO objects
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;

        [Out] vec3 position;

        // Projection matrix
        [Uniform] mat4 pcm_matrix;
        // --------------------

        void main()
        {
            position = in_position;
            vec4 pos = pcm_matrix * new vec4(in_position, 1);
            gl_Position = pos.xyww;
        }
    }
}
