using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class ShadowMapDepthVertexShader: VertexShader
    {
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;

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

        #region Transformation matrices

        // World (model) matrix
        [Uniform] mat4 w_matrix;

        #endregion

        void main()
        {
            gl_Position = matrices.lm * w_matrix * new vec4(in_position, 1.0f);
        }
    }
}