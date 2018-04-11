using Mono.Cecil;
using System.Collections.Generic;

namespace AlienEngine.Shaders.ASL
{
    internal sealed class ASLShaderStruct
    {
        internal string Name { get; private set; }

        internal bool IsInterfaceBlock { get; private set; }

        internal TypeReference InterfaceType { get; private set; }

        internal string InterfaceBlockNamespace { get; private set; }

        internal IEnumerable<ASLShaderVariable> Fields { get; private set; }

        internal CustomAttribute LayoutAttribute { get; set; }

        internal ASLShaderStruct(string name, bool isInterfaceBlock, TypeReference interfaceType, string blockNamespace, IEnumerable<ASLShaderVariable> fields, CustomAttribute layoutAttr)
        {
            Name = name;
            IsInterfaceBlock = isInterfaceBlock;
            InterfaceType = interfaceType;
            InterfaceBlockNamespace = blockNamespace;
            Fields = fields;
            LayoutAttribute = layoutAttr;
        }
    }
}
