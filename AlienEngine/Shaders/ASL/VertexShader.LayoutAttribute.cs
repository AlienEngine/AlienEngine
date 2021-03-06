﻿using System;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class VertexShader
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct, AllowMultiple = false)]
        public sealed class LayoutAttribute : Attribute
        {
            public int Location { get; set; }
            public UniformLayout[] UniformIDS { get; private set; }

            public LayoutAttribute(params UniformLayout[] ids)
            {
                UniformIDS = ids;
            }
        }
    }
}