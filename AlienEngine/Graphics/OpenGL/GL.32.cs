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
        internal delegate void DrawElementsBaseVertex(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int basevertex);
        internal delegate void DrawRangeElementsBaseVertex(BeginMode mode, uint start, uint end, int count, DrawElementsType type, IntPtr indices, int basevertex);
        internal delegate void DrawElementsInstancedBaseVertex(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, int basevertex);
        internal delegate void MultiDrawElementsBaseVertex(BeginMode mode, int[] count, DrawElementsType type, IntPtr[] indices, int drawcount, int[] basevertex);

        /// <summary>
        /// Sets the provoking vertex for flat shading.
        /// </summary>
        /// <param name="mode">A <see cref="glProvokingVertexMode"/> specifying the vertex.</param>
        public delegate void ProvokingVertex(ProvokingVertexMode mode);

        /// <summary>
        /// Creates a sync object and inserts it into the command stream.
        /// </summary>
        /// <param name="condition">Must be <see cref="glSyncCondition.SYNC_GPU_COMMANDS_COMPLETE"/>.</param>
        /// <param name="flags">Must be zero.</param>
        /// <returns>Return the handle sync object.</returns>
        public delegate IntPtr FenceSync(SyncCondition condition, WaitSyncFlags flags);

        /// <summary>
        /// Determines if a handle is a sync object.
        /// </summary>
        /// <param name="sync">The handle to check.</param>
        /// <returns><b>true</b> if <paramref name="sync"/> is a sync object.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        public delegate bool IsSync(IntPtr sync);

        /// <summary>
        /// Deletes a sync object.
        /// </summary>
        /// <param name="sync">The handle to the sync object.</param>
        public delegate void DeleteSync(IntPtr sync);

        /// <summary>
        /// Waits for a sync object for a time.
        /// </summary>
        /// <param name="sync">The handle to the sync object.</param>
        /// <param name="flags">A <see cref="ClientWaitSyncFlag"/> controlling command flushing behavior.</param>
        /// <param name="timeout">Timeout in nanoseconds.</param>
        /// <returns>Returns information on the waiting operation.</returns>
        [CLSCompliant(false)]
        public delegate WaitSyncStatus ClientWaitSync(IntPtr sync, ClientWaitSyncFlags flags, ulong timeout);

        /// <summary>
        /// Instructs the GL server to block until the specified sync object becomes signaled.
        /// </summary>
        /// <param name="sync">The handle to the sync object.</param>
        /// <param name="flags">Must be zero.</param>
        /// <param name="timeout">Must be <see cref="GL.TIMEOUT_IGNORED"/>.</param>
        [CLSCompliant(false)]
        public delegate void WaitSync(IntPtr sync, WaitSyncFlags flags, ulong timeout);

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetInteger64Parameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetInteger64(GetInteger64Parameter pname, out long param);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetInteger64Parameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetInteger64v(GetInteger64Parameter pname, long[] @params);

        /// <summary>
        /// Returns the value of parameters of sync objects.
        /// </summary>
        /// <param name="sync">The handle of the sync object.</param>
        /// <param name="pname">A <see cref="SyncParameterName"/> specifying the parameter.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="length">Will be one.</param>
        /// <param name="value">The requested value.</param>
        public delegate void GetSynci(IntPtr sync, SyncParameterName pname, int bufSize, out int length, out int value);

        /// <summary>
        /// Returns the value(s) of parameters of sync objects.
        /// </summary>
        /// <param name="sync">The handle of the sync object.</param>
        /// <param name="pname">A <see cref="SyncParameterName"/> specifying the parameter.</param>
        /// <param name="bufSize">Size of the <paramref name="values"/> buffer.</param>
        /// <param name="length">The number of value(s) actually writter to <paramref name="values"/>.</param>
        /// <param name="values">The requested value(s).</param>
        public delegate void GetSynciv(IntPtr sync, SyncParameterName pname, int bufSize, out int length, int[] values);

        /// <summary>
        /// Returns the value of an indexed parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetInteger64Parameter"/> specifying the parameter.</param>
        /// <param name="index"></param>
        /// <param name="data">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetInteger64i_(GetInteger64IndexedParameter target, uint index, out long data);

        /// <summary>
        /// Returns the value(s) of an indexed parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetInteger64Parameter"/> specifying the parameter.</param>
        /// <param name="index"></param>
        /// <param name="data">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetInteger64i_v(GetInteger64IndexedParameter target, uint index, long[] data);

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetBufferParameteri64(BufferTarget target, BufferParameterName pname, out long param);

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetBufferParameteri64v(BufferTarget target, BufferParameterName pname, long[] @params);

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level of the texture.</param>
        [CLSCompliant(false)]
        public delegate void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level);

        /// <summary>
        /// Creates storage for a 2D multisample texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="samples">Number of samples.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public delegate void TexImage2DMultisample(TextureTarget target, int samples, PixelInternalFormat internalformat, int width, int height, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        /// <summary>
        /// Creates storage for a 3D multisample texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="samples">Number of samples.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public delegate void TexImage3DMultisample(TextureTarget target, int samples, PixelInternalFormat internalformat, int width, int height, int depth, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        /// <summary>
        /// Retrieves the location of a sample.
        /// </summary>
        /// <param name="pname">Must be <see cref="glMultisampleParameter.SAMPLE_POSITION"/>.</param>
        /// <param name="index">The index of the sample.</param>
        /// <param name="val">A <b>float[2]</b> to receive the sample position.</param>
        [CLSCompliant(false)]
        public delegate void GetMultisamplefv(GetMultisamplePName pname, uint index, float[] val);

        /// <summary>
        /// Sets the value of a sub-word of the sample mask.
        /// </summary>
        /// <param name="index">Specifies which 32-bit sub-word of the sample mask to update.</param>
        /// <param name="mask">The new mask value.</param>
        [CLSCompliant(false)]
        public delegate void SampleMaski(uint index, uint mask);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 3.2 is available.
        /// </summary>
        public static bool VERSION_3_2;

        #region Delegates
        private static DrawElementsBaseVertex _DrawElementsBaseVertex;
        private static DrawRangeElementsBaseVertex _DrawRangeElementsBaseVertex;
        private static DrawElementsInstancedBaseVertex _DrawElementsInstancedBaseVertex;
        private static MultiDrawElementsBaseVertex _MultiDrawElementsBaseVertex;

        /// <summary>
        /// Sets the provoking vertex for flat shading.
        /// </summary>
        public static ProvokingVertex ProvokingVertex;

        /// <summary>
        /// Creates a sync object and inserts it into the command stream.
        /// </summary>
        public static FenceSync FenceSync;

        /// <summary>
        /// Determines if a handle is a sync object.
        /// </summary>
        public static IsSync IsSync;

        /// <summary>
        /// Deletes a sync object.
        /// </summary>
        public static DeleteSync DeleteSync;

        /// <summary>
        /// Waits for a sync object for a time.
        /// </summary>
        [CLSCompliant(false)]
        public static ClientWaitSync ClientWaitSync;

        /// <summary>
        /// Instructs the GL server to block until the specified sync object becomes signaled.
        /// </summary>
        [CLSCompliant(false)]
        public static WaitSync WaitSync;

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        public static GetInteger64 GetInteger64;

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        public static GetInteger64v GetInteger64v;

        /// <summary>
        /// Returns the value of parameters of sync objects.
        /// </summary>
        public static GetSynci GetSynci;

        /// <summary>
        /// Returns the value(s) of parameters of sync objects.
        /// </summary>
        public static GetSynciv GetSynciv;

        /// <summary>
        /// Returns the value of an indexed parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetInteger64i_ GetInteger64i_;

        /// <summary>
        /// Returns the value(s) of an indexed parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetInteger64i_v GetInteger64i_v;

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        public static GetBufferParameteri64 GetBufferParameteri64;

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        public static GetBufferParameteri64v GetBufferParameteri64v;

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferTexture FramebufferTexture;

        /// <summary>
        /// Creates storage for a 2D multisample texture.
        /// </summary>
        public static TexImage2DMultisample TexImage2DMultisample;

        /// <summary>
        /// Creates storage for a 3D multisample texture.
        /// </summary>
        public static TexImage3DMultisample TexImage3DMultisample;

        /// <summary>
        /// Retrieves the location of a sample.
        /// </summary>
        [CLSCompliant(false)]
        public static GetMultisamplefv GetMultisamplefv;

        /// <summary>
        /// Sets the value of a sub-word of the sample mask.
        /// </summary>
        [CLSCompliant(false)]
        public static SampleMaski SampleMaski;
        #endregion

        #region Overloads
        #region DrawElementsBaseVertex
        /// <summary>
        /// Renders primitives from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void DrawElementsBaseVertex(BeginMode mode, int count, DrawElementsType type, int offset, int basevertex)
        {
            _DrawElementsBaseVertex(mode, count, type, (IntPtr)offset, basevertex);
        }

        /// <summary>
        /// Renders primitives from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void DrawElementsBaseVertex(BeginMode mode, int count, DrawElementsType type, long offset, int basevertex)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawElementsBaseVertex(mode, count, type, (IntPtr)offset, basevertex);
        }
        #endregion

        #region DrawRangeElementsBaseVertex
        /// <summary>
        /// Render primitives from array via a range of indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="start">Start of the range.</param>
        /// <param name="end">End of the range.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        [CLSCompliant(false)]
        public static void DrawRangeElementsBaseVertex(BeginMode mode, uint start, uint end, int count, DrawElementsType type, int offset, int basevertex)
        {
            _DrawRangeElementsBaseVertex(mode, start, end, count, type, (IntPtr)offset, basevertex);
        }

        /// <summary>
        /// Render primitives from array via a range of indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="start">Start of the range.</param>
        /// <param name="end">End of the range.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        [CLSCompliant(false)]
        public static void DrawRangeElementsBaseVertex(BeginMode mode, uint start, uint end, int count, DrawElementsType type, long offset, int basevertex)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawRangeElementsBaseVertex(mode, start, end, count, type, (IntPtr)offset, basevertex);
        }
        #endregion

        #region DrawElementsInstancedBaseVertex
        /// <summary>
        /// Renders multiple instances from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void DrawElementsInstancedBaseVertex(BeginMode mode, int count, DrawElementsType type, int offset, int instancecount, int basevertex)
        {
            _DrawElementsInstancedBaseVertex(mode, count, type, (IntPtr)offset, instancecount, basevertex);
        }

        /// <summary>
        /// Renders multiple instances from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="count">Number of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="instancecount">Number of instances to be rendered.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void DrawElementsInstancedBaseVertex(BeginMode mode, int count, DrawElementsType type, long offset, int instancecount, int basevertex)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _DrawElementsInstancedBaseVertex(mode, count, type, (IntPtr)offset, instancecount, basevertex);
        }
        #endregion

        #region MultiDrawElementsBaseVertex
        /// <summary>
        /// Renders primitives from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="count">Numbers of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offsets">The offsets into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="drawcount">Number of draws (Length of <paramref name="count"/> and <paramref name="offsets"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void MultiDrawElementsBaseVertex(BeginMode mode, int[] count, DrawElementsType type, int[] offsets, int drawcount, int[] basevertex)
        {
            IntPtr[] iOffsets = new IntPtr[drawcount];
            for (int i = 0; i < drawcount; i++) iOffsets[i] = (IntPtr)offsets[i];
            _MultiDrawElementsBaseVertex(mode, count, type, iOffsets, drawcount, basevertex);
        }

        /// <summary>
        /// Renders primitives from array via indices with a per-element offset.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="count">Numbers of indices.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="offsets">The offsets into the array bound to <see cref="BufferTarget.ElementArrayBuffer"/>.</param>
        /// <param name="drawcount">Number of draws (Length of <paramref name="count"/> and <paramref name="offsets"/>.</param>
        /// <param name="basevertex">The per-element offset.</param>
        public static void MultiDrawElementsBaseVertex(BeginMode mode, int[] count, DrawElementsType type, long[] offsets, int drawcount, int[] basevertex)
        {
            IntPtr[] iOffsets = new IntPtr[drawcount];
            for (int i = 0; i < drawcount; i++)
            {
                if (IntPtr.Size == 4 && ((long)offsets[i] >> 32) != 0) throw new ArgumentOutOfRangeException("offsets", PlatformArrayErrorString);
                iOffsets[i] = (IntPtr)offsets[i];
            }
            _MultiDrawElementsBaseVertex(mode, count, type, iOffsets, drawcount, basevertex);
        }
        #endregion
        #endregion

        private static void Load_VERSION_3_2()
        {
            _DrawElementsBaseVertex = GetAddress<DrawElementsBaseVertex>("glDrawElementsBaseVertex");
            _DrawRangeElementsBaseVertex = GetAddress<DrawRangeElementsBaseVertex>("glDrawRangeElementsBaseVertex");
            _DrawElementsInstancedBaseVertex = GetAddress<DrawElementsInstancedBaseVertex>("glDrawElementsInstancedBaseVertex");
            _MultiDrawElementsBaseVertex = GetAddress<MultiDrawElementsBaseVertex>("glMultiDrawElementsBaseVertex");
            ProvokingVertex = GetAddress<ProvokingVertex>("glProvokingVertex");
            FenceSync = GetAddress<FenceSync>("glFenceSync");
            IsSync = GetAddress<IsSync>("glIsSync");
            DeleteSync = GetAddress<DeleteSync>("glDeleteSync");
            ClientWaitSync = GetAddress<ClientWaitSync>("glClientWaitSync");
            WaitSync = GetAddress<WaitSync>("glWaitSync");
            GetInteger64 = GetAddress<GetInteger64>("glGetInteger64v");
            GetInteger64v = GetAddress<GetInteger64v>("glGetInteger64v");
            GetSynci = GetAddress<GetSynci>("glGetSynciv");
            GetSynciv = GetAddress<GetSynciv>("glGetSynciv");
            GetInteger64i_ = GetAddress<GetInteger64i_>("glGetInteger64i_v");
            GetInteger64i_v = GetAddress<GetInteger64i_v>("glGetInteger64i_v");
            GetBufferParameteri64 = GetAddress<GetBufferParameteri64>("glGetBufferParameteri64v");
            GetBufferParameteri64v = GetAddress<GetBufferParameteri64v>("glGetBufferParameteri64v");
            FramebufferTexture = GetAddress<FramebufferTexture>("glFramebufferTexture");
            TexImage2DMultisample = GetAddress<TexImage2DMultisample>("glTexImage2DMultisample");
            TexImage3DMultisample = GetAddress<TexImage3DMultisample>("glTexImage3DMultisample");
            GetMultisamplefv = GetAddress<GetMultisamplefv>("glGetMultisamplefv");
            SampleMaski = GetAddress<SampleMaski>("glSampleMaski");

            VERSION_3_2 = VERSION_3_1 && _DrawElementsBaseVertex != null && _DrawRangeElementsBaseVertex != null &&
                _DrawElementsInstancedBaseVertex != null && _MultiDrawElementsBaseVertex != null &&
                ProvokingVertex != null && FenceSync != null && IsSync != null && DeleteSync != null && ClientWaitSync != null &&
                WaitSync != null && GetInteger64v != null && GetSynciv != null && GetInteger64i_v != null && GetBufferParameteri64v != null &&
                FramebufferTexture != null && TexImage2DMultisample != null && TexImage3DMultisample != null &&
                GetMultisamplefv != null && SampleMaski != null;
        }
    }
}
