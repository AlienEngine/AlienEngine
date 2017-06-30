using System;

namespace AlienEngine.ASL
{
    public abstract partial class GeometryShader
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class LayoutAttribute : ASLShaderAttribute
        {
            public int MaxVertices { get; set; }
            public InputLayout InputID { get; private set; }
            public OutputLayout OutputID { get; private set; }
            public UniformLayout[] UniformIDS { get; private set; }

            public LayoutAttribute(OutputLayout id)
            {
                OutputID = id;
            }

            public LayoutAttribute(InputLayout id)
            {
                InputID = id;
            }

            public LayoutAttribute(params UniformLayout[] ids)
            {
                UniformIDS = ids;
            }
        }
    }
}
