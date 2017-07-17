﻿#region Copyright and License
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
using System.Text;

namespace AlienEngine.Core.Graphics.OpenGL
{
    using Delegates;

    namespace Delegates
    {
        /// <summary>
        /// Renders multiple instances of a range of elements.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="first">Start index in the array.</param>
        /// <param name="count">Number of elements to be rendered.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        public delegate void DrawArraysInstanced(BeginMode mode, int first, int count, int instancecount);

        internal delegate void DrawElementsInstanced(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount);

        /// <summary>
        /// Attaches a buffer object to the currently bound texture object.
        /// </summary>
        /// <param name="target">Must by <see cref="glTexBufferTarget.TEXTURE_BUFFER"/>.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void TexBuffer(TextureBufferTarget target, InternalFormat internalformat, uint buffer);

        /// <summary>
        /// Sets the primitive restart index.
        /// </summary>
        /// <param name="index">The value to be interpreted as the primitive restart index.</param>
        [CLSCompliant(false)]
        public delegate void PrimitiveRestartIndex(uint index);

        internal delegate void CopyBufferSubData_32(BufferTarget readTarget, BufferTarget writeTarget, int readOffset, int writeOffset, int size);
        internal delegate void CopyBufferSubData_64(BufferTarget readTarget, BufferTarget writeTarget, long readOffset, long writeOffset, long size);

        /// <summary>
        /// Returns the indices of named uniform variables.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformCount">Number of uniform indices to return.</param>
        /// <param name="uniformNames">The names of the uniform variables.</param>
        /// <param name="uniformIndices">Returns the requeste uniform indices.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformIndices(uint program, int uniformCount, string[] uniformNames, uint[] uniformIndices);

        /// <summary>
        /// Returns the value of parameters of active uniform variables.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformCount">Must be one.</param>
        /// <param name="uniformIndex">Index of the uniform. (<b>ref</b> for <c>const uint*</c>)</param>
        /// <param name="pname">A <see cref="glUniformParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetActiveUniformsi(uint program, int uniformCount, ref uint uniformIndex, ActiveUniformParameter pname, out int param); // ref for const uint*

        /// <summary>
        /// Returns the value(s) of parameters of active uniform variables.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformCount">Number of uniforms.</param>
        /// <param name="uniformIndices">Indices of the uniforms.</param>
        /// <param name="pname">A <see cref="glUniformParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetActiveUniformsiv(uint program, int uniformCount, uint[] uniformIndices, ActiveUniformParameter pname, int[] @params);

        internal delegate void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, out int length, StringBuilder uniformName);

        /// <summary>
        /// Returns the index of a uniform block.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformBlockName">The name of the uniform block.</param>
        /// <returns>The index of the uniform block.</returns>
        [CLSCompliant(false)]
        public delegate uint GetUniformBlockIndex(uint program, string uniformBlockName);

        /// <summary>
        /// Returns the value of parameters of active uniform blocks.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformBlockIndex">The index of the uniform block.</param>
        /// <param name="pname">A <see cref="glUniformBlockParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetActiveUniformBlocki(uint program, uint uniformBlockIndex, ActiveUniformBlockParameter pname, out int param);

        /// <summary>
        /// Returns the value(s) of parameters of active uniform blocks.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformBlockIndex">The index of the uniform block.</param>
        /// <param name="pname">A <see cref="glUniformBlockParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetActiveUniformBlockiv(uint program, uint uniformBlockIndex, ActiveUniformBlockParameter pname, int[] @params);

        internal delegate void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, out int length, StringBuilder uniformBlockName);

        /// <summary>
        /// Assignes a binding point (buffer) to an active uniform block.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformBlockIndex">The index of the uniform block.</param>
        /// <param name="uniformBlockBinding">The binding point (buffer).</param>
        [CLSCompliant(false)]
        public delegate void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 3.1 is available.
        /// </summary>
        public static bool VERSION_3_1;

        #region Delegates
        /// <summary>
        /// Renders multiple instances of a range of elements.
        /// </summary>
        public static DrawArraysInstanced DrawArraysInstanced;

        private static DrawElementsInstanced _DrawElementsInstanced;

        /// <summary>
        /// Attaches a buffer object to the currently bound texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TexBuffer TexBuffer;

        /// <summary>
        /// Sets the primitive restart index.
        /// </summary>
        [CLSCompliant(false)]
        public static PrimitiveRestartIndex PrimitiveRestartIndex;

        private static CopyBufferSubData_32 CopyBufferSubData_32;
        private static CopyBufferSubData_64 CopyBufferSubData_64;

        /// <summary>
        /// Returns the indices of named uniform variables.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformIndices GetUniformIndices;

        /// <summary>
        /// Returns the value of parameters of active uniform variables.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveUniformsi GetActiveUniformsi;

        /// <summary>
        /// Returns the value(s) of parameters of active uniform variables.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveUniformsiv GetActiveUniformsiv;

        private static GetActiveUniformName _GetActiveUniformName;

        /// <summary>
        /// Returns the index of a uniform block.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformBlockIndex GetUniformBlockIndex;

        /// <summary>
        /// Returns the value of parameters of active uniform blocks.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveUniformBlocki GetActiveUniformBlocki;

        /// <summary>
        /// Returns the value(s) of parameters of active uniform blocks.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveUniformBlockiv GetActiveUniformBlockiv;

        private static GetActiveUniformBlockName _GetActiveUniformBlockName;

        /// <summary>
        /// Assignes a binding point (buffer) to an active uniform block.
        /// </summary>
        [CLSCompliant(false)]
        public static UniformBlockBinding UniformBlockBinding;
        #endregion

        #region Overloads
        #region DrawElementsInstanced
        /// <summary>
        /// Renders multiple instances from array via indices.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        public static void DrawElementsInstanced(BeginMode mode, int count, DrawElementsType type, int offset, int instancecount)
        {
            _DrawElementsInstanced(mode, count, type, (IntPtr)offset, instancecount);
        }

        /// <summary>
        /// Renders multiple instances from array via indices.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        public static void DrawElementsInstanced(BeginMode mode, int count, DrawElementsType type, long offset, int instancecount)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawElementsInstanced(mode, count, type, (IntPtr)offset, instancecount);
        }
        #endregion

        #region CopyBufferSubData
        /// <summary>
        /// Copies a region between buffers.
        /// </summary>
        /// <param name="readTarget">A <see cref="BufferTarget"/> specifying the read target.</param>
        /// <param name="writeTarget">A <see cref="BufferTarget"/> specifying the write target.</param>
        /// <param name="readOffset">The offset into the read buffer.</param>
        /// <param name="writeOffset">The offset into the write buffer.</param>
        /// <param name="size">The size of the region.</param>
        public static void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget, int readOffset, int writeOffset, int size)
        {
            if (IntPtr.Size == 4) CopyBufferSubData_32(readTarget, writeTarget, readOffset, writeOffset, size);
            else CopyBufferSubData_64(readTarget, writeTarget, readOffset, writeOffset, size);
        }

        /// <summary>
        /// Copies a region between buffers.
        /// </summary>
        /// <param name="readTarget">A <see cref="BufferTarget"/> specifying the read target.</param>
        /// <param name="writeTarget">A <see cref="BufferTarget"/> specifying the write target.</param>
        /// <param name="readOffset">The offset into the read buffer.</param>
        /// <param name="writeOffset">The offset into the write buffer.</param>
        /// <param name="size">The size of the region.</param>
        public static void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget, long readOffset, long writeOffset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)readOffset >> 32) != 0) throw new ArgumentOutOfRangeException("readOffset", PlatformErrorString);
                if (((long)writeOffset >> 32) != 0) throw new ArgumentOutOfRangeException("writeOffset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                CopyBufferSubData_32(readTarget, writeTarget, (int)readOffset, (int)writeOffset, (int)size);
            }
            else CopyBufferSubData_64(readTarget, writeTarget, readOffset, writeOffset, size);
        }
        #endregion

        #region GetActiveUniformName
        /// <summary>
        /// Returns the name of an active uniform.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformIndex">The index of the uniform.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="uniformName"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="uniformName"/>.</param>
        /// <param name="uniformName">Returns the name of the uniform.</param>
        [CLSCompliant(false)]
        public static void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, out int length, out string uniformName)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveUniformName(program, uniformIndex, bufSize + 1, out length, tmp);
            uniformName = tmp.ToString();
        }
        #endregion

        #region GetActiveUniformBlockName
        /// <summary>
        /// Returns the name of an active uniform block.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformBlockIndex">The index of the uniform block.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="uniformBlockName"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="uniformBlockName"/>.</param>
        /// <param name="uniformBlockName">Returns the name of the uniform block.</param>
        [CLSCompliant(false)]
        public static void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, out int length, out string uniformBlockName)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveUniformBlockName(program, uniformBlockIndex, bufSize + 1, out length, tmp);
            uniformBlockName = tmp.ToString();
        }
        #endregion
        #endregion

        private static void Load_VERSION_3_1()
        {
            DrawArraysInstanced = GetAddress<DrawArraysInstanced>("glDrawArraysInstanced");
            _DrawElementsInstanced = GetAddress<DrawElementsInstanced>("glDrawElementsInstanced");
            TexBuffer = GetAddress<TexBuffer>("glTexBuffer");
            PrimitiveRestartIndex = GetAddress<PrimitiveRestartIndex>("glPrimitiveRestartIndex");
            GetUniformIndices = GetAddress<GetUniformIndices>("glGetUniformIndices");
            GetActiveUniformsi = GetAddress<GetActiveUniformsi>("glGetActiveUniformsi");
            GetActiveUniformsiv = GetAddress<GetActiveUniformsiv>("glGetActiveUniformsiv");
            _GetActiveUniformName = GetAddress<GetActiveUniformName>("glGetActiveUniformName");
            GetUniformBlockIndex = GetAddress<GetUniformBlockIndex>("glGetUniformBlockIndex");
            GetActiveUniformBlocki = GetAddress<GetActiveUniformBlocki>("glGetActiveUniformBlocki");
            GetActiveUniformBlockiv = GetAddress<GetActiveUniformBlockiv>("glGetActiveUniformBlockiv");
            _GetActiveUniformBlockName = GetAddress<GetActiveUniformBlockName>("glGetActiveUniformBlockName");
            UniformBlockBinding = GetAddress<UniformBlockBinding>("glUniformBlockBinding");

            if (IntPtr.Size == 4) CopyBufferSubData_32 = GetAddress<CopyBufferSubData_32>("glCopyBufferSubData");
            else CopyBufferSubData_64 = GetAddress<CopyBufferSubData_64>("glCopyBufferSubData");
            bool CopyBufferSubData = CopyBufferSubData_32 != null || CopyBufferSubData_64 != null;

            VERSION_3_1 = VERSION_3_0 && DrawArraysInstanced != null && _DrawElementsInstanced != null && TexBuffer != null &&
                PrimitiveRestartIndex != null && GetUniformIndices != null && GetActiveUniformsiv != null &&
                _GetActiveUniformName != null && GetUniformBlockIndex != null && GetActiveUniformBlockiv != null &&
                _GetActiveUniformBlockName != null && UniformBlockBinding != null && CopyBufferSubData;
        }
    }
}
