using System.Linq;
using ICSharpCode.Decompiler.TypeSystem;
using Mono.Cecil;

namespace AlienEngine.Shaders.ASL
{
    internal static class ASLShaderAttributeHelper
    {
        private static readonly int UniformToken = typeof(Shaders.ASL.ASLShader.UniformAttribute).MetadataToken;

        private static readonly int[] AttribToken = new[]
        {
            typeof(Shaders.ASL.ASLShader.InAttribute).MetadataToken,
            typeof(Shaders.ASL.ASLShader.OutAttribute).MetadataToken,
            typeof(Shaders.ASL.ASLShader.BuiltInAttribute).MetadataToken
        };

        public static bool IsUniform(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == UniformToken;
        }

        public static bool IsIn(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == AttribToken[0];
        }

        public static bool IsOut(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == AttribToken[1];
        }

        public static bool IsBuiltIn(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == AttribToken[2];
        }

        public static bool IsAttribute(this TypeReference t)
        {
            return AttribToken.Contains(t.Resolve().MetadataToken.ToInt32());
        }

        public static bool Is<T>(this IType t)
        {
            return t.Name == typeof(T).Name;
        }

        public static bool Is<T>(this TypeReference t)
        {
            return t.Name == typeof(T).Name;
        }

        public static bool IsArray(this IType t)
        {
            return t.Kind == TypeKind.Array;
        }

        public static bool HasAttribute<T>(this IMethod m)
        {
            return m.HasCustomAttributes() && m.Attributes.Any(a => a.AttributeType.Is<T>());
        }

        public static bool HasAttribute<T>(this TypeDefinition m)
        {
            return m.HasCustomAttributes() && m.CustomAttributes.Any(a => a.AttributeType.Is<T>());
        }

        public static bool HasCustomAttributes(this TypeDefinition m)
        {
            return m.HasCustomAttributes;
        }

        public static bool HasCustomAttributes(this IMethod m)
        {
            return m.Attributes.Count > 0;
        }

        public static bool HasCustomAttributes(this IParameter p)
        {
            return p.Attributes.Count > 0;
        }
    }
}