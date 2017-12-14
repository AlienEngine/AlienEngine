using System;

namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        /// <summary>
        /// ASL Shader attribute used to define size of arrays.
        /// </summary>
        [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
        public sealed class ArraySizeAttribute : Attribute
        {
            public ArraySizeAttribute(int size)
            { }

            public ArraySizeAttribute(string size)
            { }
        }

        /// <summary>
        /// ASL Shader attribute used to define a method, a field or a structure as a buil-in GLSL element.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Struct, AllowMultiple = false)]
        internal sealed class BuiltInAttribute : Attribute
        { }

        /// <summary>
        /// ASL Shader attribute used to add comments in the compiled GLSL code.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class CommentAttribute : Attribute
        {
            public CommentAttribute(string comment)
            { }
        }

        /// <summary>
        /// ASL Shader attribute used to enable debug capabilities when compiling the GLSL code.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public sealed class DebugAttribute : Attribute
        {
            public DebugAttribute(bool debug)
            {
                Debug = debug;
            }

            internal bool Debug { get; private set; }
        }

        /// <summary>
        /// ASL Shader attribute used to enable GLSL extensions.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        public sealed class ExtensionAttribute : Attribute
        {
            internal string ExtensionName { get; private set; }

            public ExtensionAttribute(string extensionName)
            {
                ExtensionName = extensionName;
            }
        }

        /// <summary>
        /// ASL Shader attribute used to create a GLSL member with the "in" qualifier.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class InAttribute : Attribute
        { }

        /// <summary>
        /// ASL Shader attribute used to create a GLSL interface block.
        /// </summary>
        [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class InterfaceBlockAttribute : Attribute
        {
            public InterfaceBlockAttribute()
            { }

            public InterfaceBlockAttribute(string blockNamespace)
            { }
        }

        /// <summary>
        /// ASL Shader attribute used to create a GLSL member with the "out" qualifier.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class OutAttribute : Attribute
        { }

        /// <summary>
        /// ASL Shader attribute used to create a GLSL member with the "uniform" qualifier.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class UniformAttribute : Attribute
        { }

        /// <summary>
        /// ASL Shader attribute used to define the version of the compiled GLSL code.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public sealed class VersionAttribute : Attribute
        {
            public VersionAttribute(string version)
            {
                Version = version;
            }

            public string Version { get; }
        }

        /// <summary>
        /// ASL Shader attribute used to include parts of GLSL codes.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        public sealed class IncludeAttribute : Attribute
        {
            internal string IncludeName { get; private set; }
            internal Type IncludeType { get; private set; }

            public IncludeAttribute(string includeName)
            {
                IncludeName = includeName;
            }

            public IncludeAttribute(Type includeType)
            {
                IncludeType = includeType;
            }
        }
    }
}
