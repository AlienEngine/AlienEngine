using System;

namespace AlienEngine.ASL
{
    public abstract partial class GeometryShader
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class LayoutAttribute : Attribute
        {
            public InputLayout InputID { get; private set; }

            public LayoutAttribute(InputLayout id)
            {
                InputID = id;
            }
        }
        
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public sealed class LayoutInAttribute : Attribute
        {
            public InputLayout InputID { get; private set; }

            public LayoutInAttribute(InputLayout id)
            {
                InputID = id;
            }
        }
        
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public sealed class LayoutOutAttribute : Attribute
        {
            public int MaxVertices { get; set; }
            public OutputLayout OutputID { get; private set; }

            public LayoutOutAttribute(OutputLayout id)
            {
                OutputID = id;
            }
        }

    }
}
