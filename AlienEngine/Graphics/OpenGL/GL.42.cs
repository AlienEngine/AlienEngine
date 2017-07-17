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
    using Delegates;

    namespace Delegates
    {
        /// <summary>
        /// Renders multiple instances of a range of elements with an offset to all instanced vertex attributes.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="first">Start index in the array.</param>
        /// <param name="count">Number of elements to be rendered.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="baseinstance">Offset to all instanced vertex attributes.</param>
        [CLSCompliant(false)]
        public delegate void DrawArraysInstancedBaseInstance(BeginMode mode, int first, int count, int instancecount, uint baseinstance);

        internal delegate void DrawElementsInstancedBaseInstance(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, uint baseinstance);
        internal delegate void DrawElementsInstancedBaseVertexBaseInstance(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, int basevertex, uint baseinstance);

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target the <paramref name="internalformat"/> is used for.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="pname">A <see cref="glInternalformatParameter"/> specifying the parameter.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetInternalformati(TextureTarget target, InternalFormat internalformat, InternalFormatParameter pname, int bufSize, out int param);

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target the <paramref name="internalformat"/> is used for.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="pname">A <see cref="glInternalformatParameter"/> specifying the parameter.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetInternalformativ(TextureTarget target, InternalFormat internalformat, InternalFormatParameter pname, int bufSize, int[] @params);

        /// <summary>
        /// Returns parameter of atomic counter buffer objects.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="bufferIndex">The index of the active atomic counter.</param>
        /// <param name="pname">A <see cref="AtomicCounterBufferParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetActiveAtomicCounterBufferi(uint program, uint bufferIndex, AtomicCounterBufferParameter pname, out int param);

        /// <summary>
        /// Returns parameter of atomic counter buffer objects.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="bufferIndex">The index of the active atomic counter.</param>
        /// <param name="pname">A <see cref="AtomicCounterBufferParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, AtomicCounterBufferParameter pname, int[] @params);

        /// <summary>
        /// Binds a texture to an image unit.
        /// </summary>
        /// <param name="unit">The image unit.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail of the texture.</param>
        /// <param name="layered">Set <b>true</b> if the whole level is to be bound, <b>false</b> if only the layer specified by <paramref name="layer"/> is to be bound.</param>
        /// <param name="layer">If <paramref name="layered"/> is <b>false</b> only this layer will be bound.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the kind of access.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        [CLSCompliant(false)]
        public delegate void BindImageTexture(uint unit, uint texture, int level, [MarshalAs(UnmanagedType.I1)] bool layered, int layer, BufferAccess access, PixelInternalFormat format);

        /// <summary>
        /// Orders memory transactions issued prior to this command relative to those issued after this.
        /// </summary>
        /// <param name="barriers">A <see cref="glMemoryBarrierMask"/> specifying the kind of memory transactions to be ordered.</param>
        public delegate void MemoryBarrier(MemoryBarrierMask barriers);

        /// <summary>
        /// Creates a storage for all levels of a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        public delegate void TexStorage1D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width);

        /// <summary>
        /// Creates a storage for all levels of a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        public delegate void TexStorage2D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width, int height);

        /// <summary>
        /// Creates a storage for all levels of a 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        public delegate void TexStorage3D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width, int height, int depth);

        /// <summary>
        /// Renders multiple instances of primitives using the count derived from transform feedback objects.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitives to render.</param>
        /// <param name="id">The name of the transform feedback object.</param>
        /// <param name="instancecount">The number of instances.</param>
        [CLSCompliant(false)]
        public delegate void DrawTransformFeedbackInstanced(BeginMode mode, uint id, int instancecount);

        /// <summary>
        /// Renders multiple instances of primitives using the count derived from a specific stream of transform feedback objects.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitives to render.</param>
        /// <param name="id">The name of the transform feedback object.</param>
        /// <param name="stream">The index of the stream.</param>
        /// <param name="instancecount">The number of instances.</param>
        [CLSCompliant(false)]
        public delegate void DrawTransformFeedbackStreamInstanced(BeginMode mode, uint id, uint stream, int instancecount);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 4.2 is available.
        /// </summary>
        public static bool VERSION_4_2;

        #region Delegates
        /// <summary>
        /// Renders multiple instances of a range of elements with an offset to all instanced vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static DrawArraysInstancedBaseInstance DrawArraysInstancedBaseInstance;

        private static DrawElementsInstancedBaseInstance _DrawElementsInstancedBaseInstance;
        private static DrawElementsInstancedBaseVertexBaseInstance _DrawElementsInstancedBaseVertexBaseInstance;

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        public static GetInternalformati GetInternalformati;

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        public static GetInternalformativ GetInternalformativ;

        /// <summary>
        /// Returns parameter of atomic counter buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveAtomicCounterBufferi GetActiveAtomicCounterBufferi;

        /// <summary>
        /// Returns parameter of atomic counter buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveAtomicCounterBufferiv GetActiveAtomicCounterBufferiv;

        /// <summary>
        /// Binds a texture to an image unit.
        /// </summary>
        [CLSCompliant(false)]
        public static BindImageTexture BindImageTexture;

        /// <summary>
        /// Orders memory transactions issued prior to this command relative to those issued after this.
        /// </summary>
        public static MemoryBarrier MemoryBarrier;

        /// <summary>
        /// Creates a storage for all levels of a 1D texture.
        /// </summary>
        public static TexStorage1D TexStorage1D;

        /// <summary>
        /// Creates a storage for all levels of a 2D texture.
        /// </summary>
        public static TexStorage2D TexStorage2D;

        /// <summary>
        /// Creates a storage for all levels of a 3D texture.
        /// </summary>
        public static TexStorage3D TexStorage3D;

        /// <summary>
        /// Renders multiple instances of primitives using the count derived from transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static DrawTransformFeedbackInstanced DrawTransformFeedbackInstanced;

        /// <summary>
        /// Renders multiple instances of primitives using the count derived from a specific stream of transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static DrawTransformFeedbackStreamInstanced DrawTransformFeedbackStreamInstanced;
        #endregion

        #region Overloads
        #region DrawElementsInstancedBaseInstance
        /// <summary>
        /// Renders multiple instances from array via indices with an offset to all instanced vertex attributes.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="baseinstance">Offset to all instanced vertex attributes.</param>
        [CLSCompliant(false)]
        public static void DrawElementsInstancedBaseInstance(BeginMode mode, int count, DrawElementsType type, int offset, int instancecount, uint baseinstance)
        {
            _DrawElementsInstancedBaseInstance(mode, count, type, (IntPtr)offset, instancecount, baseinstance);
        }

        /// <summary>
        /// Renders multiple instances from array via indices with an offset to all instanced vertex attributes.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="baseinstance">Offset to all instanced vertex attributes.</param>
        [CLSCompliant(false)]
        public static void DrawElementsInstancedBaseInstance(BeginMode mode, int count, DrawElementsType type, long offset, int instancecount, uint baseinstance)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawElementsInstancedBaseInstance(mode, count, type, (IntPtr)offset, instancecount, baseinstance);
        }
        #endregion

        #region DrawElementsInstancedBaseVertexBaseInstance
        /// <summary>
        /// Renders multiple instances from array via indices with a per-element offset and an offset to all instanced vertex attributes.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="basevertex">The per-element offset.</param>
        /// <param name="baseinstance">Offset to all instanced vertex attributes.</param>
        [CLSCompliant(false)]
        public static void DrawElementsInstancedBaseVertexBaseInstance(BeginMode mode, int count, DrawElementsType type, int offset, int instancecount, int basevertex, uint baseinstance)
        {
            _DrawElementsInstancedBaseVertexBaseInstance(mode, count, type, (IntPtr)offset, instancecount, basevertex, baseinstance);
        }

        /// <summary>
        /// Renders multiple instances from array via indices with a per-element offset and an offset to all instanced vertex attributes.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="basevertex">The per-element offset.</param>
        /// <param name="baseinstance">Offset to all instanced vertex attributes.</param>
        [CLSCompliant(false)]
        public static void DrawElementsInstancedBaseVertexBaseInstance(BeginMode mode, int count, DrawElementsType type, long offset, int instancecount, int basevertex, uint baseinstance)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawElementsInstancedBaseVertexBaseInstance(mode, count, type, (IntPtr)offset, instancecount, basevertex, baseinstance);
        }
        #endregion
        #endregion

        private static void Load_VERSION_4_2()
        {
            DrawArraysInstancedBaseInstance = GetAddress<DrawArraysInstancedBaseInstance>("glDrawArraysInstancedBaseInstance");
            _DrawElementsInstancedBaseInstance = GetAddress<DrawElementsInstancedBaseInstance>("glDrawElementsInstancedBaseInstance");
            _DrawElementsInstancedBaseVertexBaseInstance = GetAddress<DrawElementsInstancedBaseVertexBaseInstance>("glDrawElementsInstancedBaseVertexBaseInstance");
            GetInternalformati = GetAddress<GetInternalformati>("glGetInternalformativ");
            GetInternalformativ = GetAddress<GetInternalformativ>("glGetInternalformativ");
            GetActiveAtomicCounterBufferi = GetAddress<GetActiveAtomicCounterBufferi>("glGetActiveAtomicCounterBufferiv");
            GetActiveAtomicCounterBufferiv = GetAddress<GetActiveAtomicCounterBufferiv>("glGetActiveAtomicCounterBufferiv");
            BindImageTexture = GetAddress<BindImageTexture>("glBindImageTexture");
            MemoryBarrier = GetAddress<MemoryBarrier>("glMemoryBarrier");
            TexStorage1D = GetAddress<TexStorage1D>("glTexStorage1D");
            TexStorage2D = GetAddress<TexStorage2D>("glTexStorage2D");
            TexStorage3D = GetAddress<TexStorage3D>("glTexStorage3D");
            DrawTransformFeedbackInstanced = GetAddress<DrawTransformFeedbackInstanced>("glDrawTransformFeedbackInstanced");
            DrawTransformFeedbackStreamInstanced = GetAddress<DrawTransformFeedbackStreamInstanced>("glDrawTransformFeedbackStreamInstanced");

            VERSION_4_2 = VERSION_4_1 && DrawArraysInstancedBaseInstance != null && _DrawElementsInstancedBaseInstance != null &&
                _DrawElementsInstancedBaseVertexBaseInstance != null && GetInternalformati != null && GetInternalformativ != null &&
                GetActiveAtomicCounterBufferi != null && GetActiveAtomicCounterBufferiv != null && BindImageTexture != null &&
                MemoryBarrier != null && TexStorage1D != null && TexStorage2D != null && TexStorage3D != null &&
                DrawTransformFeedbackInstanced != null && DrawTransformFeedbackStreamInstanced != null;
        }
    }
}
