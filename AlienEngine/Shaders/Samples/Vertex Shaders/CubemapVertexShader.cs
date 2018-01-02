using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Shaders.Samples
{
    internal class CubemapVertexShader : VertexShader
    {
        // Default VAO objects
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;

        [Out] vec3 position;

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

        void main()
        {
            position = in_position;
            vec4 pos = matrices.p * matrices.cm * new vec4(in_position, 1);
            gl_Position = pos.xyww;
        }
    }
}
