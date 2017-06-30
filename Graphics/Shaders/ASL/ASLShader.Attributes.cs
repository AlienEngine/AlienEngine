﻿using System;

namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        /// <summary>
        /// ASL Shader attribute used to define size of arrays.
        /// </summary>
        [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
        public class ArraySizeAttribute : Attribute
        {
            protected int _arraySize;

            public ArraySizeAttribute(int size)
            {
                ArraySize = size;
            }

            public int ArraySize
            {
                get { return _arraySize; }
                protected set
                {
                    _arraySize = value > 0 ? value : 0;
                }
            }
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
            private string _comment = string.Empty;

            public CommentAttribute(string comment)
            {
                Comment = _comment;
            }

            public string Comment { get; private set; }
        }

        /// <summary>
        /// ASL Shader attribute used to enable debug capabilities when compiling the GLSL code.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        public class DebugAttribute : Attribute
        {
            public DebugAttribute(bool debug)
            {
                Debug = debug;
            }

            public bool Debug { get; private set; }
        }

        /// <summary>
        /// ASL Shader attribute used to enable GLSL extensions.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        public class ExtensionAttribute : Attribute
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
        { }

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
        public class VersionAttribute : Attribute
        {
            private int _v = DefaultShaderVersion;

            public VersionAttribute(int version)
            {
                Version = version;
            }

            public int Version
            {
                get { return _v; }
                private set { _v = value; }
            }
        }
    }
}
