using System.Linq;
using Mono.Cecil;

namespace AlienEngine.ASL
{
    internal static class ASLShaderAttributeHelper
    {
        private static readonly int _uniformToken = typeof(ASLShader.UniformAttribute).MetadataToken;

        private static readonly int[] _attribToken = new[]
        {
            typeof(ASLShader.VaryingAttribute).MetadataToken,
            typeof(ASLShader.InAttribute).MetadataToken,
            typeof(ASLShader.OutAttribute).MetadataToken,
            typeof(ASLShader.BuiltInAttribute).MetadataToken
        };

        public static bool IsUniform(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _uniformToken;
        }

        public static bool IsVarying(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[0];
        }

        public static bool IsIn(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[1];
        }

        public static bool IsOut(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[2];
        }

        public static bool IsBuiltIn(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[3];
        }

        public static bool IsAttribute(this TypeReference t)
        {
            return _attribToken.Contains(t.Resolve().MetadataToken.ToInt32());
        }

        public static bool Is<T>(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == typeof(T).MetadataToken;
        }

        public static bool HasAttribute<T>(this IMemberDefinition t)
        {
            return t.HasCustomAttributes && t.CustomAttributes.Where(a => a.AttributeType.Is<T>()).Count() > 0;
        }
    }
}