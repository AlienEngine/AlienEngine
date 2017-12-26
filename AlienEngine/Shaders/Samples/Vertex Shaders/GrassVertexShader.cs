using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Shaders.Samples
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

        #region Uniform blocks

        [InterfaceBlock("matrices")]
        [Layout(UniformLayout.STD140)]
        [Uniform]
        struct Matrices
        {
            // Projection matrix
            public mat4 p;

            // Inversed Projection matrix
            public mat4 i_p;

            // Camera (view) matrix
            public mat4 v;

            // Inversed Camera (view) matrix
            public mat4 i_v;
            
            // Cubemap matrix
            public mat4 cm;
            
            // Light space matrix
            public mat4 lm;
        }

        private Matrices matrices;
        
        #endregion

        [Uniform] mat4 w_matrix;
        
        void main()
        {
            // Setting texture coordinates
            uv = in_uv;

            // Output the position
            gl_Position = matrices.p * matrices.v * w_matrix * new vec4(in_position, 1);
        }
    }
}
