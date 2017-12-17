using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    internal class DiffuseVertexShader : VertexShader
    {
        #region VAO Objects
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;
        //[Layout(Location = GL.VERTEX_COLOR_LOCATION)] [In] vec4 in_color;
        [Layout(Location = GL.VERTEX_TEXTURE_COORD_LOCATION)] [In] vec2 in_uv;
        [Layout(Location = GL.VERTEX_NORMAL_LOCATION)] [In] vec3 in_normal;
        //[Layout(Location = GL.VERTEX_TANGENT_LOCATION)] [In] vec3 in_tangent;
        //[Layout(Location = GL.VERTEX_BITANGENT_LOCATION)] [In] vec3 in_bitangent;
        #endregion

        #region Fragment shader inputs
        [InterfaceBlock("vs_out")]
        [Out]
        struct VS_OUT
        {
            public vec3 normal;
            public vec2 uv;
            public vec3 position;
        };

        VS_OUT vs_out;
        #endregion

        #region Transformation matrices
        // Normal matrix
        [Uniform] mat3 n_matrix;
        // World (model) matrix
        [Uniform] mat4 w_matrix;
        // Camera (view) matrix
        //[Uniform] mat4 v_matrix;
        // Model-View matrix
        //[Uniform] mat4 wv_matrix;
        // Projection matrix
        //[Uniform] mat4 p_matrix;
        // Transformation (model-view-projection) matrix
        [Uniform] mat4 wvp_matrix;
        // Inversed World (model) matrix
        //[Uniform] mat4 i_w_matrix;
        // Inversed Camera (view) matrix
        //[Uniform] mat4 i_v_matrix;
        // Inversed Model-View matrix
        //[Uniform] mat4 i_wv_matrix;
        // Inversed Projection matrix
        //[Uniform] mat4 i_p_matrix;
        // Inversed Transformation (model-view-projection) matrix
        //[Uniform] mat4 i_wvp_matrix;
        #endregion

        void main()
        {
            // Setting normals
            vec3 normalView = (length(in_normal) == 0 ? new vec3(0) : n_matrix * in_normal);
            vs_out.normal = normalView;

            // Setting texture coordinates
            vs_out.uv = in_uv;

            // Setting vertices position
            vs_out.position = (w_matrix * new vec4(in_position, 1)).xyz;

            //// Setting tangents
            //vec3 vTangent = normalize(in_tangent);

            //// Tangent to view
            //vec3 tbnT = normalize(n_matrix * vTangent);
            //vec3 tbnB = normalize(n_matrix * in_bitangent);
            //vec3 tbnN = normalView;
            //// re-orthogonalize T with respect to N
            //// tbnT = normalize(tbnT - dot(tbnT, tbnN) * tbnN);
            //tbn = new mat3(tbnT, tbnB, tbnN);

            gl_Position = wvp_matrix * new vec4(in_position, 1);
        }
    }
}
