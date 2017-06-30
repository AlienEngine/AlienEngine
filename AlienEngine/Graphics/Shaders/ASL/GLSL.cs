using Mono.Cecil;
using System;
using System.Collections.Generic;

namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        internal static class GLSL
        {
            internal static string ToGLSL(TypeReference t)
            {
                var typeDef = t.Resolve();
                Type type = null;

                if (TypeMap.TryGetValue(typeDef.Name, out type))
                    return ToGLSL(type);

                return typeDef.Name;
            }

            internal static string ToGLSL(Type t)
            {
                string glslName;
                if (!Type.TryGetValue(t, out glslName))
                    throw new ASLException("ASL Error: " + t + " is currently not supported by GLSL module.");

                return glslName;
            }

            internal static readonly Dictionary<Type, string> Type = new Dictionary<Type, string>() {
                // ----------
                // Primitives
                // -----
                { typeof(int),      "int" },
                { typeof(int[]),    "int" },
                { typeof(float),    "float" },
                { typeof(float[]),  "float" },
                { typeof(uint),     "uint" },
                { typeof(uint[]),   "uint" },
                { typeof(bool),     "bool" },
                { typeof(bool[]),   "bool" },
                { typeof(double),   "double" },
                { typeof(double[]), "double" },
                { typeof(void),     "void" },
                // ----------
                
                // ----------
                // Vectors
                // -----
                // floats
                // -----
                { typeof(vec2),     "vec2" },
                { typeof(vec2[]),   "vec2" },
                { typeof(vec3),     "vec3" },
                { typeof(vec3[]),   "vec3" },
                { typeof(vec4),     "vec4" },
                { typeof(vec4[]),   "vec4" },
                // -----
                // ints
                // -----
                { typeof(ivec2),    "ivec2" },
                { typeof(ivec2[]),  "ivec2" },
                { typeof(ivec3),    "ivec3" },
                { typeof(ivec3[]),  "ivec3" },
                { typeof(ivec4),    "ivec4" },
                { typeof(ivec4[]),  "ivec4" },
                // -----
                // uints
                // -----
                { typeof(uvec2),    "uvec2" },
                { typeof(uvec2[]),  "uvec2" },
                { typeof(uvec3),    "uvec3" },
                { typeof(uvec3[]),  "uvec3" },
                { typeof(uvec4),    "uvec4" },
                { typeof(uvec4[]),  "uvec4" },
                // -----
                // booleans
                // -----
                { typeof(bvec2),    "bvec2" },
                { typeof(bvec2[]),  "bvec2" },
                { typeof(bvec3),    "bvec3" },
                { typeof(bvec3[]),  "bvec3" },
                { typeof(bvec4),    "bvec4" },
                { typeof(bvec4[]),  "bvec4" },
                // ----------

                // ----------
                // Matrices
                // -----
                // floats
                // -----
                { typeof(mat2),     "mat2" },
                { typeof(mat2[]),   "mat2" },
                { typeof(mat3),     "mat3" },
                { typeof(mat3[]),   "mat3" },
                { typeof(mat4),     "mat4" },
                { typeof(mat4[]),   "mat4" },
                { typeof(mat2x3),   "mat2x3" },
                { typeof(mat2x3[]), "mat2x3" },
                { typeof(mat2x4),   "mat2x4" },
                { typeof(mat2x4[]), "mat2x4" },
                { typeof(mat3x2),   "mat3x2" },
                { typeof(mat3x2[]), "mat3x2" },
                { typeof(mat3x4),   "mat3x4" },
                { typeof(mat3x4[]), "mat3x4" },
                { typeof(mat4x2),   "mat4x2" },
                { typeof(mat4x2[]), "mat4x2" },
                { typeof(mat4x3),   "mat4x3" },
                { typeof(mat4x3[]), "mat4x3" }
            };

            internal static readonly Dictionary<Type, string> Qualifiers = new Dictionary<Type, string>() {
                { typeof(InAttribute),      "in" },
                { typeof(OutAttribute),     "out" },
                { typeof(UniformAttribute), "uniform" },
                { typeof(ConstAttribute),   "const"}
            };

            internal static readonly Dictionary<string, Type> TypeMap = new Dictionary<string, Type> {
                // ----------
                // Primitives
                // -----
                { typeof(int).Name,        typeof(int) },
                { typeof(int[]).Name,      typeof(int) },
                { typeof(float).Name,      typeof(float) },
                { typeof(float[]).Name,    typeof(float) },
                { typeof(uint).Name,       typeof(uint) },
                { typeof(uint[]).Name,     typeof(uint) },
                { typeof(bool).Name,       typeof(bool) },
                { typeof(bool[]).Name,     typeof(bool) },
                { typeof(double).Name,     typeof(double) },
                { typeof(double[]).Name,   typeof(double) },
                { typeof(void).Name,       typeof(void) },
                // ----------
                
                // ----------
                // Vectors
                // -----
                // floats
                // -----
                { typeof(vec2).Name,       typeof(vec2) },
                { typeof(vec2[]).Name,     typeof(vec2) },
                { typeof(vec3).Name,       typeof(vec3) },
                { typeof(vec3[]).Name,     typeof(vec3) },
                { typeof(vec4).Name,       typeof(vec4) },
                { typeof(vec4[]).Name,     typeof(vec4) },
                // -----
                // ints
                // -----
                { typeof(ivec2).Name,      typeof(ivec2) },
                { typeof(ivec2[]).Name,    typeof(ivec2) },
                { typeof(ivec3).Name,      typeof(ivec3) },
                { typeof(ivec3[]).Name,    typeof(ivec3) },
                { typeof(ivec4).Name,      typeof(ivec4) },
                { typeof(ivec4[]).Name,    typeof(ivec4) },
                // -----
                // uints
                // -----
                { typeof(uvec2).Name,      typeof(uvec2) },
                { typeof(uvec2[]).Name,    typeof(uvec2) },
                { typeof(uvec3).Name,      typeof(uvec3) },
                { typeof(uvec3[]).Name,    typeof(uvec3) },
                { typeof(uvec4).Name,      typeof(uvec4) },
                { typeof(uvec4[]).Name,    typeof(uvec4) },
                // -----
                // booleans
                // -----
                { typeof(bvec2).Name,      typeof(bvec2) },
                { typeof(bvec2[]).Name,    typeof(bvec2) },
                { typeof(bvec3).Name,      typeof(bvec3) },
                { typeof(bvec3[]).Name,    typeof(bvec3) },
                { typeof(bvec4).Name,      typeof(bvec4) },
                { typeof(bvec4[]).Name,    typeof(bvec4) },
                // ----------

                // ----------
                // Matrices
                // -----
                // floats
                // -----
                { typeof(mat2).Name,       typeof(mat2) },
                { typeof(mat2[]).Name,     typeof(mat2) },
                { typeof(mat3).Name,       typeof(mat3) },
                { typeof(mat3[]).Name,     typeof(mat3) },
                { typeof(mat4).Name,       typeof(mat4) },
                { typeof(mat4[]).Name,     typeof(mat4) },
                { typeof(mat2x3).Name,     typeof(mat2x3) },
                { typeof(mat2x3[]).Name,   typeof(mat2x3) },
                { typeof(mat2x4).Name,     typeof(mat2x4) },
                { typeof(mat2x4[]).Name,   typeof(mat2x4) },
                { typeof(mat3x2).Name,     typeof(mat3x2) },
                { typeof(mat3x2[]).Name,   typeof(mat3x2) },
                { typeof(mat3x4).Name,     typeof(mat3x4) },
                { typeof(mat3x4[]).Name,   typeof(mat3x4) },
                { typeof(mat4x2).Name,     typeof(mat4x2) },
                { typeof(mat4x2[]).Name,   typeof(mat4x2) },
                { typeof(mat4x3).Name,     typeof(mat4x3) },
                { typeof(mat4x3[]).Name,   typeof(mat4x3) }
            };

            internal static readonly Dictionary<Type, Type> ArrayMap = new Dictionary<Type, Type> {
                // ----------
                // Primitives
                // -----
                { typeof(int),      typeof(int[]) },
                { typeof(float),    typeof(float[]) },
                { typeof(uint),     typeof(uint[]) },
                { typeof(bool),     typeof(bool[]) },
                { typeof(double),   typeof(double[]) },
                // ----------
                
                // ----------
                // Vectors
                // -----
                // floats
                // -----
                { typeof(vec2),     typeof(vec2[]) },
                { typeof(vec3),     typeof(vec3[]) },
                { typeof(vec4),     typeof(vec4[]) },
                // -----
                // ints
                // -----
                { typeof(ivec2),    typeof(ivec2[]) },
                { typeof(ivec3),    typeof(ivec3[]) },
                { typeof(ivec4),    typeof(ivec4[]) },
                // -----
                // uints
                // -----
                { typeof(uvec2),    typeof(uvec2[]) },
                { typeof(uvec3),    typeof(uvec3[]) },
                { typeof(uvec4),    typeof(uvec4[]) },
                // -----
                // booleans
                // -----
                { typeof(bvec2),    typeof(bvec2[]) },
                { typeof(bvec3),    typeof(bvec3[]) },
                { typeof(bvec4),    typeof(bvec4[]) },
                // ----------

                // ----------
                // Matrices
                // -----
                // floats
                // -----
                { typeof(mat2),     typeof(mat2[]) },
                { typeof(mat3),     typeof(mat3[]) },
                { typeof(mat4),     typeof(mat4[]) },
                { typeof(mat2x3),   typeof(mat2x3[]) },
                { typeof(mat2x4),   typeof(mat2x4[]) },
                { typeof(mat3x2),   typeof(mat3x2[]) },
                { typeof(mat3x4),   typeof(mat3x4[]) },
                { typeof(mat4x2),   typeof(mat4x2[]) },
                { typeof(mat4x3),   typeof(mat4x3[]) }
            };
        }
    }
}