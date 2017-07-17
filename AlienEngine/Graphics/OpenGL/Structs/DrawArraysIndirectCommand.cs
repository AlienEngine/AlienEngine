#region Copyright and License
// Copyright (c) 2013-2014 The Khronos Group Inc.
// Copyright (c) of C# port 2014 by Shinta <shintadono@gooemail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and/or associated documentation files (the
// "Materials"), to deal in the Materials without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Materials, and to
// permit persons to whom the Materials are furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Materials.
//
// THE MATERIALS ARE PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.
#endregion

using System;
using System.Runtime.InteropServices;

namespace AlienEngine.Core.Graphics.OpenGL
{
    /// <summary>
    /// Data structure holding draw arrays commands. Used by <see cref="GL.DrawArraysIndirect"/> and
    /// <see cref="GL.MultiDrawArraysIndirect"/>.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DrawArraysIndirectCommand
    {
        /// <summary>
        /// Number of indices (in an instance) to be drawn.
        /// </summary>
        [FieldOffset(0)]
        [CLSCompliant(false)]
        public uint Count;

        /// <summary>
        /// Number of instance to be drawn.
        /// </summary>
        [FieldOffset(4)]
        [CLSCompliant(false)]
        public uint InstanceCount;

        /// <summary>
        /// Starting index in the enabled arrays.
        /// </summary>
        [FieldOffset(8)]
        [CLSCompliant(false)]
        public uint First;

        /// <summary>
        /// Base instance for use in fetching instanced vertex attributes.
        /// </summary>
        [FieldOffset(12)]
        [CLSCompliant(false)]
        public uint BaseInstance;
    }
}
