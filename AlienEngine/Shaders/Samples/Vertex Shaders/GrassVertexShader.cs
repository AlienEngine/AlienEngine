using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;
using System;

namespace AlienEngine.Core.Graphics.Shaders.Samples
{
    [Version("330 core")]
    internal class GrassVertexShader : VertexShader
    {
        #region VAO Objects
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;
        [Layout(Location = GL.VERTEX_TEXTURE_COORD_LOCATION)] [In] vec2 in_uv;
        #endregion

        #region Fragment shader inputs
        [Out] vec2 uv;
        #endregion

        #region Transformation matrices
        // Transformation (model-view-projection) matrix
        [Uniform] mat4 wvp_matrix;
        #endregion

        void main()
        {
            // Setting texture coordinates
            uv = in_uv;

            // Output the position
            gl_Position = wvp_matrix * new vec4(in_position, 1);
        }
    }
}
