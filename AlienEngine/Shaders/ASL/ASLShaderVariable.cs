using Mono.Cecil;

namespace AlienEngine.Shaders.ASL
{
    internal sealed class ASLShaderVariable
    {
        internal string Type { get; private set; }

        internal string Name { get; private set; }

        internal string UserComment { get; private set; }

        internal string DebugComment { get; private set; }

        internal bool IsArray { get; private set; }

        internal string ArraySize { get; private set; }

        internal TypeReference AttributeType { get; private set; }

        internal CustomAttribute LayoutAttribute { get; private set; }

        public ASLShaderVariable(string type, bool isArray, string arraySize, string name, string userComment, string debugComment, TypeReference attrType, CustomAttribute layoutAttr)
        {
            Type = type;
            IsArray = isArray;
            ArraySize = arraySize;
            Name = name;
            UserComment = userComment;
            DebugComment = debugComment;
            AttributeType = attrType;
            LayoutAttribute = layoutAttr;
        }
    }
}