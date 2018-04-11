using System;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class ASLShader
    {
        [BuiltIn]
        protected struct mat2
        {
            public mat2(float diag) { throw new NotImplementedException(); }
            public mat2(mat3 matrix) { throw new NotImplementedException(); }
            public mat2(mat4 matrix) { throw new NotImplementedException(); }
            public mat2(vec2 col0, vec2 col1) { throw new NotImplementedException(); }

            public mat2(
                float x0y0, float x0y1,
                float x1y0, float x1y1
            ) { throw new NotImplementedException(); }

            public vec2 this[int column] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static mat2 operator +(mat2 left, mat2 right) { throw new NotImplementedException(); }
            public static mat2 operator -(mat2 left, mat2 right) { throw new NotImplementedException(); }
            public static mat2 operator *(mat2 left, mat2 right) { throw new NotImplementedException(); }
            public static mat2 operator /(mat2 left, mat2 right) { throw new NotImplementedException(); }

            public static vec2 operator *(mat2 left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator *(vec2 left, mat2 right) { throw new NotImplementedException(); }
        }

        [BuiltIn]
        protected struct mat3
        {
            public mat3(float diag) { throw new NotImplementedException(); }
            public mat3(mat2 matrix) { throw new NotImplementedException(); }
            public mat3(mat4 matrix) { throw new NotImplementedException(); }
            public mat3(vec3 col0, vec3 col1, vec3 col2) { throw new NotImplementedException(); }

            public mat3(
                float x0y0, float x0y1, float x0y2,
                float x1y0, float x1y1, float x1y2,
                float x2y0, float x2y1, float x2y2
            ) { throw new NotImplementedException(); }

            public vec3 this[int column] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static mat3 operator +(mat3 left, mat3 right) { throw new NotImplementedException(); }
            public static mat3 operator -(mat3 left, mat3 right) { throw new NotImplementedException(); }
            public static mat3 operator *(mat3 left, mat3 right) { throw new NotImplementedException(); }
            public static mat3 operator /(mat3 left, mat3 right) { throw new NotImplementedException(); }

            public static vec3 operator *(mat3 left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator *(vec3 left, mat3 right) { throw new NotImplementedException(); }
        }

        [BuiltIn]
        protected struct mat4
        {
            public mat4(float diag) { throw new NotImplementedException(); }
            public mat4(mat2 matrix) { throw new NotImplementedException(); }
            public mat4(mat3 matrix) { throw new NotImplementedException(); }
            public mat4(vec4 col0, vec4 col1, vec4 col2, vec4 col3) { throw new NotImplementedException(); }

            public mat4(
                float x0y0, float x0y1, float x0y2, float x0y3,
                float x1y0, float x1y1, float x1y2, float x1y3,
                float x2y0, float x2y1, float x2y2, float x2y3,
                float x3y0, float x3y1, float x3y2, float x3y3
            ) { throw new NotImplementedException(); }

            public vec4 this[int column] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static mat4 operator +(mat4 left, mat4 right) { throw new NotImplementedException(); }
            public static mat4 operator -(mat4 left, mat4 right) { throw new NotImplementedException(); }
            public static mat4 operator *(mat4 left, mat4 right) { throw new NotImplementedException(); }
            public static mat4 operator *(float left, mat4 right) { throw new NotImplementedException(); }
            public static mat4 operator /(mat4 left, mat4 right) { throw new NotImplementedException(); }

            public static vec4 operator *(mat4 left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator *(vec4 left, mat4 right) { throw new NotImplementedException(); }
        }

        [BuiltIn]
        protected struct mat2x3
        { }

        [BuiltIn]
        protected struct mat2x4
        { }

        [BuiltIn]
        protected struct mat3x2
        { }

        [BuiltIn]
        protected struct mat3x4
        { }

        [BuiltIn]
        protected struct mat4x2
        { }

        [BuiltIn]
        protected struct mat4x3
        { }
    }
}
