using AlienEngine.Shaders.ASL;
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

        [Layout(Location = GL.VERTEX_TANGENT_LOCATION)] [In] vec3 in_tangent;

        [Layout(Location = GL.VERTEX_BITANGENT_LOCATION)] [In] vec3 in_bitangent;

        #endregion

        #region Fragment shader inputs

        [InterfaceBlock("vs_out")]
        [Out]
        struct VS_OUT
        {
            public vec3 normal;
            public vec2 uv;
            public vec3 positionRelativeToWorld;
            public vec4 positionRelativeToCamera;
            public float shadowDistance;
            public vec4 fragPosLightSpace;
            public mat3 tbn;
        };

        VS_OUT vs_out;

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

        #region Camera informations

        [Uniform]
        [InterfaceBlock("camera")]
        [Layout(UniformLayout.STD140)]
        struct Camera
        {
            // Position
            public vec3 position;
            // Rotation
            public vec3 rotation;
            // Near/Far planes distances
            public vec2 depthDistances;
        }

        private Camera camera;

        #endregion

        #region Transformation matrices

        // Normal matrix
        [Uniform] mat3 n_matrix;

        // World (model) matrix
        [Uniform] mat4 w_matrix;

        #endregion

        void main()
        {
            // Setting normals
            vec3 normalView = (length(in_normal) == 0 ? new vec3(0) : n_matrix * in_normal);
            vs_out.normal = normalView;

            // Setting texture coordinates
            vs_out.uv = in_uv;

            // Setting vertices position
            vec4 worldPosition = w_matrix * new vec4(in_position, 1);
            vs_out.positionRelativeToWorld = worldPosition.xyz;
            vs_out.positionRelativeToCamera = matrices.v * worldPosition;

            // Setting shadow map
            vs_out.fragPosLightSpace = matrices.lm * worldPosition;

            float distance = length(vs_out.positionRelativeToCamera.xyz);
            distance = distance - (150 - 10);
            distance = distance / 10;
            vs_out.shadowDistance = clamp(1.0f - distance, 0.0f, 1.0f);

            //// Setting tangents
            //vec3 vTangent = normalize(in_tangent);

            //// Tangent to view
            vec3 T = normalize(new vec3(w_matrix * new vec4(in_tangent, 0.0f)));
            // vec3 B = normalize(new vec3(w_matrix * new vec4(in_bitangent, 0.0f)));
            vec3 N = normalize(new vec3(w_matrix * new vec4(in_normal, 0.0f)));
            T = normalize(T - dot(T, N) * N);
            // then retrieve perpendicular vector B with the cross product of T and N
            vec3 B = cross(N, T);
            vs_out.tbn = transpose(new mat3(T, B, N));
            //vec3 tbnT = normalize(n_matrix * vTangent);
            //vec3 tbnB = normalize(n_matrix * in_bitangent);
            //vec3 tbnN = normalView;
            //// re-orthogonalize T with respect to N
            //// tbnT = normalize(tbnT - dot(tbnT, tbnN) * tbnN);
            //tbn = new mat3(tbnT, tbnB, tbnN);

            gl_Position = matrices.p * vs_out.positionRelativeToCamera;
        }
    }
}