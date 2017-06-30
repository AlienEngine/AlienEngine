using Mono.Cecil;
using System.Collections.Generic;

namespace AlienEngine.ASL
{
    internal sealed class ASLShaderStruct
    {
        internal string Name { get; private set; }

        internal bool IsInterfaceBlock { get; private set; }

        internal TypeReference InterfaceType { get; private set; }

        internal IEnumerable<ASLShaderVariable> Fields { get; private set; }

        internal CustomAttribute LayoutAttribute { get; set; }

        internal ASLShaderStruct(string name, bool isInterfaceBlock, TypeReference interfaceType, IEnumerable<ASLShaderVariable> fields, CustomAttribute layoutAttr)
        {
            Name = name;
            IsInterfaceBlock = isInterfaceBlock;
            InterfaceType = interfaceType;
            Fields = fields;
            LayoutAttribute = layoutAttr;
        }
    }
}
