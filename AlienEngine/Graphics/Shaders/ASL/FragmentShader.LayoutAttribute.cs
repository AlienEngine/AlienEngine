using System;

namespace AlienEngine.ASL
{
    public abstract partial class FragmentShader
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class LayoutAttribute : ASLShaderAttribute
        {
            public int Location { get; set; }
            public int Index { get; set; }
            public InputLayout[] InputIDS { get; private set; }
            public UniformLayout[] UniformIDS { get; private set; }

            public LayoutAttribute(InputLayout id)
            {
                InputIDS[0] = id;
            }

            public LayoutAttribute(InputLayout id1, InputLayout id2)
            {
                InputIDS[0] = id1;
                InputIDS[1] = id2;
            }

            public LayoutAttribute(params UniformLayout[] ids)
            {
                UniformIDS = ids;
            }
        }
    }
}
