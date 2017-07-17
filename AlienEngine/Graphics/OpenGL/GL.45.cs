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
        /// Controls the clipping volume behavior and the clip coordinate to window coordinate transformation behavior.
        /// </summary>
        /// <param name="origin">A <see cref="OrientationOrigin"/> specifying the clip control origin.</param>
        /// <param name="depth">A <see cref="glClipDepthMode"/> specifying the clip control depth mode.</param>
        public delegate void ClipControl(OrientationOrigin origin, ClipDepthMode depth);

        internal delegate void CreateTransformFeedback(int one, out uint id);
        internal delegate void CreateTransformFeedbacks(int count, uint[] ids);

        /// <summary>
        /// Binds a buffer object to a transform feedback object.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback object.</param>
        /// <param name="index">The index of the binding point of the transform feedback buffer object.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void TransformFeedbackBufferBase(uint xfb, uint index, uint buffer);

        internal delegate void TransformFeedbackBufferRange_32(uint xfb, uint index, uint buffer, int offset, int size);
        internal delegate void TransformFeedbackBufferRange_64(uint xfb, uint index, uint buffer, long offset, long size);

        /// <summary>
        /// Returns the parameters of transform feedback objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbacki(uint xfb, TransformFeedbackParameter pname, out int param);

        /// <summary>
        /// Returns the parameters of transform feedback objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested valu(e).</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbackiv(uint xfb, TransformFeedbackParameter pname, int[] param);

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="index">The index of the buffer binding point.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbacki_(uint xfb, TransformFeedbackParameter pname, uint index, out int param);

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="index">The index of the buffer binding point.</param>
        /// <param name="param">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbacki_v(uint xfb, TransformFeedbackParameter pname, uint index, int[] param);

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="index">The index of the buffer binding point.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbacki64_(uint xfb, TransformFeedbackParameter pname, uint index, out long param);

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="pname">A <see cref="glTransformFeedbackParameter"/> specifying the parameter.</param>
        /// <param name="index">The index of the buffer binding point.</param>
        /// <param name="param">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTransformFeedbacki64_v(uint xfb, TransformFeedbackParameter pname, uint index, long[] param);

        internal delegate void CreateBuffer(int one, out uint buffer);
        internal delegate void CreateBuffers(int count, uint[] buffers);
        internal delegate void NamedBufferStorage_32(uint buffer, int size, IntPtr data, BufferStorageFlags flags);
        internal delegate void NamedBufferStorage_64(uint buffer, long size, IntPtr data, BufferStorageFlags flags);
        internal delegate void NamedBufferData_32(uint buffer, int size, IntPtr data, BufferUsageHint usage);
        internal delegate void NamedBufferData_64(uint buffer, long size, IntPtr data, BufferUsageHint usage);
        internal delegate void NamedBufferSubData_32(uint buffer, int offset, int size, IntPtr data);
        internal delegate void NamedBufferSubData_64(uint buffer, long offset, long size, IntPtr data);
        internal delegate void CopyNamedBufferSubData_32(uint readBuffer, uint writeBuffer, int readOffset, int writeOffset, int size);
        internal delegate void CopyNamedBufferSubData_64(uint readBuffer, uint writeBuffer, long readOffset, long writeOffset, long size);
        internal delegate void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, IntPtr data);
        internal delegate void ClearNamedBufferSubData_32(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, IntPtr data);
        internal delegate void ClearNamedBufferSubData_64(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, IntPtr data);

        /// <summary>
        /// Maps a data store into client memory.
        /// </summary>
        /// <param name="buffer">The name of buffer object.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        [CLSCompliant(false)]
        public delegate IntPtr MapNamedBuffer(uint buffer, BufferAccess access);

        internal delegate IntPtr MapNamedBufferRange_32(uint buffer, int offset, int length, BufferAccessMask access);
        internal delegate IntPtr MapNamedBufferRange_64(uint buffer, long offset, long length, BufferAccessMask access);

        /// <summary>
        /// Releases a mapped data store.
        /// </summary>
        /// <param name="buffer">The name of buffer object.</param>
        /// <returns><b>true</b> unless the data store contents have become corrupt during the time the data store was mapped. If <b>false</b> is returned an application must reinitialize the data store.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool UnmapNamedBuffer(uint buffer);

        internal delegate void FlushMappedNamedBufferRange_32(uint buffer, int offset, int length);
        internal delegate void FlushMappedNamedBufferRange_64(uint buffer, long offset, long length);

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedBufferParameteri(uint buffer, BufferParameterName pname, out int param);

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetNamedBufferParameteriv(uint buffer, BufferParameterName pname, int[] @params);

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedBufferParameteri64(uint buffer, BufferParameterName pname, out long param);

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetNamedBufferParameteri64v(uint buffer, BufferParameterName pname, long[] @params);

        /// <summary>
        /// Returns the pointer to a mapped data store of a buffer object.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="pname">Must be <see cref="BufferParameterName.BUFFER_MAP_POINTER"/>.</param>
        /// <param name="param">The pointer to the mapped data store.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedBufferPointerv(uint buffer, BufferParameterName pname, out IntPtr param);

        internal delegate void GetNamedBufferSubData_32(uint buffer, int offset, int size, IntPtr data);
        internal delegate void GetNamedBufferSubData_64(uint buffer, long offset, long size, IntPtr data);
        internal delegate void CreateFramebuffer(int one, out uint framebuffer);
        internal delegate void CreateFramebuffers(int count, uint[] framebuffers);

        /// <summary>
        /// Attaches renderbuffers as a logical buffer of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="attachment">A <see cref="Buffer"/> specifying the framebuffer attachment.</param>
        /// <param name="renderbuffertarget">A <see cref="glRenderbufferTarget"/> specifying the renderbuffer target.</param>
        /// <param name="renderbuffer">The name of the renderbuffer.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferRenderbuffer(uint framebuffer, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);

        /// <summary>
        /// Sets parameters of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter.</param>
        /// <param name="param">The new value.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferParameteri(uint framebuffer, FramebufferDefaultParameter pname, int param);

        /// <summary>
        /// Attaches levels of texture objects as a logical buffer of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="attachment">A <see cref="Buffer"/> specifying the framebuffer attachment.</param>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferTexture(uint framebuffer, FramebufferAttachment attachment, uint texture, int level);

        /// <summary>
        /// Attaches layers of texture objects as a logical buffer of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="attachment">A <see cref="Buffer"/> specifying the framebuffer attachment.</param>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="layer">The layer number.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferTextureLayer(uint framebuffer, FramebufferAttachment attachment, uint texture, int level, int layer);

        /// <summary>
        /// Sets the color buffers to draw into.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object. (Zero for the default framebuffer.)</param>
        /// <param name="buf">A <see cref="Buffer"/> specifying the buffer.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferDrawBuffer(uint framebuffer, DrawBufferMode buf);

        /// <summary>
        /// Sets the color buffers to draw into.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object. (Zero for the default framebuffer.)</param>
        /// <param name="count">Number of buffers.</param>
        /// <param name="bufs">A array of <see cref="Buffer"/>s specifying the buffers.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferDrawBuffers(uint framebuffer, int count, params DrawBufferMode[] bufs);

        /// <summary>
        /// Sets the color buffers to read from.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object. (Zero for the default framebuffer.)</param>
        /// <param name="src">A <see cref="Buffer"/> specifying the buffer.</param>
        [CLSCompliant(false)]
        public delegate void NamedFramebufferReadBuffer(uint framebuffer, ReadBufferMode src);

        /// <summary>
        /// Invalidates the content of some or all of a framebuffer's attachments.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="numAttachments">The number of attachments in <paramref name="attachments"/>.</param>
        /// <param name="attachments">An array of <see cref="Buffer"/>s specifying the attachments.</param>
        [CLSCompliant(false)]
        public delegate void InvalidateNamedFramebufferData(uint framebuffer, int numAttachments, params FramebufferAttachment[] attachments);

        /// <summary>
        /// Invalidates the content of a region of some or all of a framebuffer's attachments.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="numAttachments">The number of attachments in <paramref name="attachments"/>.</param>
        /// <param name="attachments">An array of <see cref="Buffer"/>s specifying the attachments.</param>
        /// <param name="x">The X offset of the region to be invalidated.</param>
        /// <param name="y">The Y offset of the region to be invalidated.</param>
        /// <param name="width">The width of the region to be invalidated.</param>
        /// <param name="height">The height of the region to be invalidated.</param>
        [CLSCompliant(false)]
        public delegate void InvalidateNamedFramebufferSubData(uint framebuffer, int numAttachments, FramebufferAttachment[] attachments, int x, int y, int width, int height);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="buffer">A <see cref="Buffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="Buffer.COLOR"/></param>
        /// <param name="value">The value to be set.</param>
        [CLSCompliant(false)]
        public delegate void ClearNamedFramebufferiv(uint framebuffer, ClearBuffer buffer, int drawbuffer, params int[] value);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="buffer">A <see cref="Buffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="Buffer.COLOR"/></param>
        /// <param name="value">The value to be set.</param>
        [CLSCompliant(false)]
        public delegate void ClearNamedFramebufferuiv(uint framebuffer, ClearBuffer buffer, int drawbuffer, params uint[] value);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="buffer">A <see cref="Buffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="Buffer.COLOR"/></param>
        /// <param name="value">The value to be set.</param>
        [CLSCompliant(false)]
        public delegate void ClearNamedFramebufferfv(uint framebuffer, ClearBuffer buffer, int drawbuffer, params float[] value);

        /// <summary>
        /// Clears/Resets the values of the depth-stencil-buffer to a specific value.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="buffer">Must be <see cref="Buffer.DEPTH_STENCIL"/>.</param>
        /// <param name="drawbuffer">Must be zero.</param>
        /// <param name="depth">The depth value to set.</param>
        /// <param name="stencil">The stencil value to set.</param>
        [CLSCompliant(false)]
        public delegate void ClearNamedFramebufferfi(uint framebuffer, ClearBuffer buffer, int drawbuffer, float depth, int stencil);

        /// <summary>
        /// Copies a block of pixels between two framebuffer objects.
        /// </summary>
        /// <param name="readFramebuffer">The name of the framebuffer object to read from.</param>
        /// <param name="drawFramebuffer">The name of the framebuffer object to write to.</param>
        /// <param name="srcX0">The left bound of the region to copy.</param>
        /// <param name="srcY0">The bottom bound of the region to copy.</param>
        /// <param name="srcX1">The right bound of the region to copy.</param>
        /// <param name="srcY1">The top bound of the region to copy.</param>
        /// <param name="dstX0">The left bound of the region to be copied in.</param>
        /// <param name="dstY0">The bottom bound of the region to be copied in.</param>
        /// <param name="dstX1">The right bound of the region to be copied in.</param>
        /// <param name="dstY1">The top bound of the region to be copied in.</param>
        /// <param name="mask">A <see cref="BufferMask"/> specifying the values to copy.</param>
        /// <param name="filter">A <see cref="glFilter"/> specifying the interpolation methode to use when resizing.</param>
        [CLSCompliant(false)]
        public delegate void BlitNamedFramebuffer(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);

        /// <summary>
        /// Checks and returns the state of a framebuffer target.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the target against which the framebuffer completeness ist checked.</param>
        /// <returns>A <see cref="glFramebufferStatus"/> specifying the state of the framebuffer target</returns>
        [CLSCompliant(false)]
        public delegate FramebufferStatus CheckNamedFramebufferStatus(uint framebuffer, FramebufferTarget target);

        /// <summary>
        /// Returns the parameters of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedFramebufferParameteri(uint framebuffer, FramebufferDefaultParameter pname, out int param);

        /// <summary>
        /// Returns the parameters of framebuffer objects.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetNamedFramebufferParameteriv(uint framebuffer, FramebufferDefaultParameter pname, int[] @params);

        /// <summary>
        /// Returns the parameters of framebuffer object attachments.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="attachment">A <see cref="Buffer"/> specifying the attachment.</param>
        /// <param name="pname">A <see cref="glFramebufferAttachmentParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedFramebufferAttachmentParameteri(uint framebuffer, FramebufferAttachment attachment, FramebufferParameterName pname, out int param);

        /// <summary>
        /// Returns the parameters of framebuffer object attachments.
        /// </summary>
        /// <param name="framebuffer">The name of the framebuffer object.</param>
        /// <param name="attachment">A <see cref="Buffer"/> specifying the attachment.</param>
        /// <param name="pname">A <see cref="glFramebufferAttachmentParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetNamedFramebufferAttachmentParameteriv(uint framebuffer, FramebufferAttachment attachment, FramebufferParameterName pname, int[] @params);

        internal delegate void CreateRenderbuffer(int one, out uint renderbuffer);
        internal delegate void CreateRenderbuffers(int count, uint[] renderbuffers);

        /// <summary>
        /// Creates renderbuffer storages for renderbuffer objects.
        /// </summary>
        /// <param name="renderbuffer">The name of the renderbuffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format of the storage.</param>
        /// <param name="width">The width of the storage in pixels.</param>
        /// <param name="height">The height of the storage in pixels.</param>
        [CLSCompliant(false)]
        public delegate void NamedRenderbufferStorage(uint renderbuffer, InternalFormat internalformat, int width, int height);

        /// <summary>
        /// Creates multisample renderbuffer storages for renderbuffer objects.
        /// </summary>
        /// <param name="renderbuffer">The name of the renderbuffer object.</param>
        /// <param name="samples">The number of samples.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format of the storage.</param>
        /// <param name="width">The width of the storage in pixels.</param>
        /// <param name="height">The height of the storage in pixels.</param>
        [CLSCompliant(false)]
        public delegate void NamedRenderbufferStorageMultisample(uint renderbuffer, int samples, InternalFormat internalformat, int width, int height);

        /// <summary>
        /// Returns parameters of renderbuffer objects.
        /// </summary>
        /// <param name="renderbuffer">The name of the renderbuffer object.</param>
        /// <param name="pname">A <see cref="RenderbufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetNamedRenderbufferParameteri(uint renderbuffer, RenderbufferParameterName pname, out int param);

        /// <summary>
        /// Returns parameters of renderbuffer objects.
        /// </summary>
        /// <param name="renderbuffer">The name of the renderbuffer object.</param>
        /// <param name="pname">A <see cref="RenderbufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetNamedRenderbufferParameteriv(uint renderbuffer, RenderbufferParameterName pname, int[] @params);

        internal delegate void CreateTexture(TextureTarget target, int one, out uint texture);
        internal delegate void CreateTextures(TextureTarget target, int count, uint[] textures);

        /// <summary>
        /// Attaches buffer objects to texture objects.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void TextureBuffer(uint texture, InternalFormat internalformat, uint buffer);

        internal delegate void TextureBufferRange_32(uint texture, InternalFormat internalformat, uint buffer, int offset, int size);
        internal delegate void TextureBufferRange_64(uint texture, InternalFormat internalformat, uint buffer, long offset, long size);

        /// <summary>
        /// Creates a storage for all levels of a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        [CLSCompliant(false)]
        public delegate void TextureStorage1D(uint texture, int levels, InternalFormat internalformat, int width);

        /// <summary>
        /// Creates a storage for all levels of a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        [CLSCompliant(false)]
        public delegate void TextureStorage2D(uint texture, int levels, InternalFormat internalformat, int width, int height);

        /// <summary>
        /// Creates a storage for all levels of a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="levels">Number of levels.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        [CLSCompliant(false)]
        public delegate void TextureStorage3D(uint texture, int levels, InternalFormat internalformat, int width, int height, int depth);

        /// <summary>
        /// Creates a storage for of a 2D multisample texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="samples">The number of samples in the texture.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        [CLSCompliant(false)]
        public delegate void TextureStorage2DMultisample(uint texture, int samples, InternalFormat internalformat, int width, int height, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        /// <summary>
        /// Creates a storage for of a 3D multisample texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="samples">The number of samples in the texture.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        [CLSCompliant(false)]
        public delegate void TextureStorage3DMultisample(uint texture, int samples, InternalFormat internalformat, int width, int height, int depth, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        internal delegate void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, IntPtr pixels);
        internal delegate void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels);
        internal delegate void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr pixels);
        internal delegate void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, IntPtr data);
        internal delegate void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, IntPtr data);
        internal delegate void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, IntPtr data);

        /// <summary>
        /// Copies pixels inside a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="x">Horizontal start position of the region to be copied, in window coordinates.</param>
        /// <param name="y">Vertical start position of the region to be copied, in window coordinates.</param>
        /// <param name="width">The width of the texture.</param>
        [CLSCompliant(false)]
        public delegate void CopyTextureSubImage1D(uint texture, int level, int xoffset, int x, int y, int width);

        /// <summary>
        /// Copies pixels inside a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="x">Horizontal start position of the region to be copied, in window coordinates.</param>
        /// <param name="y">Vertical start position of the region to be copied, in window coordinates.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        [CLSCompliant(false)]
        public delegate void CopyTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height);

        /// <summary>
        /// Copies pixels inside a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="x">Horizontal start position of the region to be copied, in window coordinates.</param>
        /// <param name="y">Vertical start position of the region to be copied, in window coordinates.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        [CLSCompliant(false)]
        public delegate void CopyTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TextureParameterf(uint texture, TextureParameterName pname, float param);

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TextureParameterfv(uint texture, TextureParameterName pname, params float[] @params);

        internal delegate void TextureParameteri(uint texture, TextureParameterName pname, int param);

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TextureParameteriv(uint texture, TextureParameterName pname, params int[] @params);

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TextureParameterIiv(uint texture, TextureParameterName pname, params int[] @params);

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TextureParameterIuiv(uint texture, TextureParameterName pname, params uint[] @params);

        /// <summary>
        /// Generates the mipmap of a texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        [CLSCompliant(false)]
        public delegate void GenerateTextureMipmap(uint texture);

        /// <summary>
        /// Bind a texture object to a texture unit.
        /// </summary>
        /// <param name="unit">The texture unit.</param>
        /// <param name="texture">The name of the texture.</param>
        [CLSCompliant(false)]
        public delegate void BindTextureUnit(uint unit, uint texture);

        internal delegate void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, IntPtr pixels);
        internal delegate void GetCompressedTextureImage(uint texture, int level, int bufSize, IntPtr pixels);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTextureLevelParameterf(uint texture, int level, GetTextureParameter pname, out float param);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTextureLevelParameterfv(uint texture, int level, GetTextureParameter pname, float[] @params);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTextureLevelParameteri(uint texture, int level, GetTextureParameter pname, out int param);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTextureLevelParameteriv(uint texture, int level, GetTextureParameter pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterf(uint texture, GetTextureParameter pname, out float param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterfv(uint texture, GetTextureParameter pname, float[] @params);

        internal delegate void GetTextureParameteri(uint texture, GetTextureParameter pname, out int param);
        internal delegate void GetTextureParameteriv(uint texture, GetTextureParameter pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterIi(uint texture, GetTextureParameter pname, out int param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterIiv(uint texture, GetTextureParameter pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterIui(uint texture, GetTextureParameter pname, out uint param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTextureParameterIuiv(uint texture, TextureParameter pname, uint[] @params);

        internal delegate void CreateVertexArray(int one, out uint array);
        internal delegate void CreateVertexArrays(int count, uint[] arrays);

        /// <summary>
        /// Disables a vertex array attribute.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        [CLSCompliant(false)]
        public delegate void DisableVertexArrayAttrib(uint vaobj, uint index);

        /// <summary>
        /// Enables a vertex array attribute.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        [CLSCompliant(false)]
        public delegate void EnableVertexArrayAttrib(uint vaobj, uint index);

        /// <summary>
        /// Sets the element array buffer binding of a vertex array object.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayElementBuffer(uint vaobj, uint buffer);

        internal delegate void VertexArrayVertexBuffer_32(uint vaobj, uint bindingindex, uint buffer, int offset, int stride);
        internal delegate void VertexArrayVertexBuffer_64(uint vaobj, uint bindingindex, uint buffer, long offset, int stride);
        internal delegate void VertexArrayVertexBuffers_32(uint vaobj, uint first, int count, uint[] buffers, int[] offsets, int[] strides);
        internal delegate void VertexArrayVertexBuffers_64(uint vaobj, uint first, int count, uint[] buffers, long[] offsets, int[] strides);

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="attribindex">The index of the attribute.</param>
        /// <param name="bindingindex">The index of the vertex buffer binding with which to associate the generic vertex attribute.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayAttribBinding(uint vaobj, uint attribindex, uint bindingindex);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="normalized">Set <b>true</b> if data is normalized.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayAttribFormat(uint vaobj, uint attribindex, int size, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint relativeoffset);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayAttribIFormat(uint vaobj, uint attribindex, int size, VertexAttribType type, uint relativeoffset);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayAttribLFormat(uint vaobj, uint attribindex, int size, VertexAttribType type, uint relativeoffset);

        /// <summary>
        /// Sets the rate at which vertex attributes advance.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="bindingindex">The index of the binding.</param>
        /// <param name="divisor">The value for the instance step rate.</param>
        [CLSCompliant(false)]
        public delegate void VertexArrayBindingDivisor(uint vaobj, uint bindingindex, uint divisor);

        /// <summary>
        /// Returns the parameters of vertex array objects.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="pname">Must be <see cref="glVertexArrayParameter.ELEMENT_ARRAY_BUFFER_BINDING"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayi(uint vaobj, VertexArrayParameter pname, out int param);

        /// <summary>
        /// Returns the parameters of vertex array objects.
        /// </summary>
        /// <param name="vaobj">The name of the vertex attribute array object.</param>
        /// <param name="pname">Must be <see cref="glVertexArrayParameter.ELEMENT_ARRAY_BUFFER_BINDING"/>.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayiv(uint vaobj, VertexArrayParameter pname, int[] @params);

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayIndexedi(uint vaobj, uint index, VertexAttribParameter pname, out int param);

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayIndexediv(uint vaobj, uint index, VertexAttribParameter pname, int[] @params);

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">Must be <see cref="glVertexAttribParameter.VERTEX_BINDING_OFFSET"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayIndexed64i(uint vaobj, uint index, VertexAttribParameter pname, out long param);

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">Must be <see cref="glVertexAttribParameter.VERTEX_BINDING_OFFSET"/>.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexArrayIndexed64iv(uint vaobj, uint index, VertexAttribParameter pname, long[] @params);

        internal delegate void CreateSampler(int one, out uint sampler);
        internal delegate void CreateSamplers(int count, uint[] samplers);
        internal delegate void CreateProgramPipeline(int one, out uint pipeline);
        internal delegate void CreateProgramPipelines(int count, uint[] pipelines);
        internal delegate void CreateQuery(QueryTarget target, int one, out uint id);
        internal delegate void CreateQueries(QueryTarget target, int count, uint[] ids);
        internal delegate void GetQueryBufferObjecti64v_32(uint id, uint buffer, GetQueryObjectParam pname, int offset);
        internal delegate void GetQueryBufferObjecti64v_64(uint id, uint buffer, GetQueryObjectParam pname, long offset);
        internal delegate void GetQueryBufferObjectiv_32(uint id, uint buffer, GetQueryObjectParam pname, int offset);
        internal delegate void GetQueryBufferObjectiv_64(uint id, uint buffer, GetQueryObjectParam pname, long offset);
        internal delegate void GetQueryBufferObjectui64v_32(uint id, uint buffer, GetQueryObjectParam pname, int offset);
        internal delegate void GetQueryBufferObjectui64v_64(uint id, uint buffer, GetQueryObjectParam pname, long offset);
        internal delegate void GetQueryBufferObjectuiv_32(uint id, uint buffer, GetQueryObjectParam pname, int offset);
        internal delegate void GetQueryBufferObjectuiv_64(uint id, uint buffer, GetQueryObjectParam pname, long offset);

        /// <summary>
        /// Orders memory transactions for regions issued prior to this command relative to those issued after this.
        /// </summary>
        /// <param name="barriers">A <see cref="glMemoryBarrierMask"/> specifying the kind of memory transactions to be ordered.</param>
        public delegate void MemoryBarrierByRegion(MemoryBarrierMask barriers);

        internal delegate void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, IntPtr pixels);
        internal delegate void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, IntPtr pixels);

        /// <summary>
        /// Returns if the rendering context has not been lost due to software or hardware issues.
        /// </summary>
        /// <returns><see cref="glGraphicsResetStatus.NO_ERROR"/> if the rendering context wasn't lost.</returns>
        public delegate ResetStatus GetGraphicsResetStatus();

        internal delegate void GetnCompressedTexImage(TextureTarget target, int level, int bufSize, IntPtr pixels);
        internal delegate void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, IntPtr pixels);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="bufSize">The number of elements available in <paramref name="params"/>.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetnUniformdv(uint program, int location, int bufSize, double[] @params);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="bufSize">The number of elements available in <paramref name="params"/>.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetnUniformfv(uint program, int location, int bufSize, float[] @params);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="bufSize">The number of elements available in <paramref name="params"/>.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetnUniformiv(uint program, int location, int bufSize, int[] @params);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="bufSize">The number of elements available in <paramref name="params"/>.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetnUniformuiv(uint program, int location, int bufSize, uint[] @params);

        internal delegate void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr pixels);

        /// <summary>
        /// Controls the ordering of reads and writes to rendered fragments across drawing commands.
        /// </summary>
        public delegate void TextureBarrier();
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 4.5 is available.
        /// </summary>
        public static bool VERSION_4_5;

        #region Delegates
        /// <summary>
        /// Controls the clipping volume behavior and the clip coordinate to window coordinate transformation behavior.
        /// </summary>
        public static Delegates.ClipControl ClipControl;

        private static CreateTransformFeedback _CreateTransformFeedback;
        private static CreateTransformFeedbacks _CreateTransformFeedbacks;

        /// <summary>
        /// Binds a buffer object to a transform feedback object.
        /// </summary>
        [CLSCompliant(false)]
        public static TransformFeedbackBufferBase TransformFeedbackBufferBase;

        private static TransformFeedbackBufferRange_32 TransformFeedbackBufferRange_32;
        private static TransformFeedbackBufferRange_64 TransformFeedbackBufferRange_64;

        /// <summary>
        /// Returns the parameters of transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbacki GetTransformFeedbacki;

        /// <summary>
        /// Returns the parameters of transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbackiv GetTransformFeedbackiv;

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbacki_ GetTransformFeedbacki_;

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbacki_v GetTransformFeedbacki_v;

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbacki64_ GetTransformFeedbacki64_;

        /// <summary>
        /// Returns the parameters of transform feedback buffer buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTransformFeedbacki64_v GetTransformFeedbacki64_v;

        private static CreateBuffer _CreateBuffer;
        private static CreateBuffers _CreateBuffers;
        private static NamedBufferStorage_32 NamedBufferStorage_32;
        private static NamedBufferStorage_64 NamedBufferStorage_64;
        private static NamedBufferData_32 NamedBufferData_32;
        private static NamedBufferData_64 NamedBufferData_64;
        private static NamedBufferSubData_32 NamedBufferSubData_32;
        private static NamedBufferSubData_64 NamedBufferSubData_64;
        private static CopyNamedBufferSubData_32 CopyNamedBufferSubData_32;
        private static CopyNamedBufferSubData_64 CopyNamedBufferSubData_64;
        private static ClearNamedBufferData _ClearNamedBufferData;
        private static ClearNamedBufferSubData_32 ClearNamedBufferSubData_32;
        private static ClearNamedBufferSubData_64 ClearNamedBufferSubData_64;

        /// <summary>
        /// Maps a data store into client memory.
        /// </summary>
        [CLSCompliant(false)]
        public static MapNamedBuffer MapNamedBuffer;

        private static MapNamedBufferRange_32 MapNamedBufferRange_32;
        private static MapNamedBufferRange_64 MapNamedBufferRange_64;

        /// <summary>
        /// Releases a mapped data store.
        /// </summary>
        [CLSCompliant(false)]
        public static UnmapNamedBuffer UnmapNamedBuffer;

        private static FlushMappedNamedBufferRange_32 FlushMappedNamedBufferRange_32;
        private static FlushMappedNamedBufferRange_64 FlushMappedNamedBufferRange_64;

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedBufferParameteri GetNamedBufferParameteri;

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedBufferParameteriv GetNamedBufferParameteriv;

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedBufferParameteri64 GetNamedBufferParameteri64;

        /// <summary>
        /// Returns the parameters of buffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedBufferParameteri64v GetNamedBufferParameteri64v;

        /// <summary>
        /// Returns the pointer to a mapped data store of a buffer object.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedBufferPointerv GetNamedBufferPointerv;

        private static GetNamedBufferSubData_32 GetNamedBufferSubData_32;
        private static GetNamedBufferSubData_64 GetNamedBufferSubData_64;
        private static CreateFramebuffer _CreateFramebuffer;
        private static CreateFramebuffers _CreateFramebuffers;

        /// <summary>
        /// Attaches a renderbuffers as a logical buffer of a framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferRenderbuffer NamedFramebufferRenderbuffer;

        /// <summary>
        /// Sets parameters of framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferParameteri NamedFramebufferParameteri;

        /// <summary>
        /// Attaches levels of a texture objects as a logical buffer of framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferTexture NamedFramebufferTexture;

        /// <summary>
        /// Attaches layers of texture objects as a logical buffer of framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferTextureLayer NamedFramebufferTextureLayer;

        /// <summary>
        /// Sets the color buffers to draw into.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferDrawBuffer NamedFramebufferDrawBuffer;

        /// <summary>
        /// Sets the color buffers to draw into.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferDrawBuffers NamedFramebufferDrawBuffers;

        /// <summary>
        /// Sets the color buffers to read from.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedFramebufferReadBuffer NamedFramebufferReadBuffer;

        /// <summary>
        /// Invalidates the content of some or all of a framebuffer's attachments.
        /// </summary>
        [CLSCompliant(false)]
        public static InvalidateNamedFramebufferData InvalidateNamedFramebufferData;

        /// <summary>
        /// Invalidates the content of a region of some or all of a framebuffer's attachments.
        /// </summary>
        [CLSCompliant(false)]
        public static InvalidateNamedFramebufferSubData InvalidateNamedFramebufferSubData;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearNamedFramebufferiv ClearNamedFramebufferiv;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearNamedFramebufferuiv ClearNamedFramebufferuiv;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearNamedFramebufferfv ClearNamedFramebufferfv;

        /// <summary>
        /// Clears/Resets the values of the depth-stencil-buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearNamedFramebufferfi ClearNamedFramebufferfi;

        /// <summary>
        /// Copies a block of pixels between two framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static BlitNamedFramebuffer BlitNamedFramebuffer;

        /// <summary>
        /// Checks and returns the state of a framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static CheckNamedFramebufferStatus CheckNamedFramebufferStatus;

        /// <summary>
        /// Returns the parameters of framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedFramebufferParameteri GetNamedFramebufferParameteri;

        /// <summary>
        /// Returns the parameters of framebuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedFramebufferParameteriv GetNamedFramebufferParameteriv;

        /// <summary>
        /// Returns the parameters of framebuffer object attachments.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedFramebufferAttachmentParameteri GetNamedFramebufferAttachmentParameteri;

        /// <summary>
        /// Returns the parameters of framebuffer object attachments.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedFramebufferAttachmentParameteriv GetNamedFramebufferAttachmentParameteriv;

        private static CreateRenderbuffer _CreateRenderbuffer;
        private static CreateRenderbuffers _CreateRenderbuffers;

        /// <summary>
        /// Creates renderbuffer storages for renderbuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedRenderbufferStorage NamedRenderbufferStorage;

        /// <summary>
        /// Creates multisample renderbuffer storages for renderbuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static NamedRenderbufferStorageMultisample NamedRenderbufferStorageMultisample;

        /// <summary>
        /// Returns parameters of renderbuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedRenderbufferParameteri GetNamedRenderbufferParameteri;

        /// <summary>
        /// Returns parameters of renderbuffer objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetNamedRenderbufferParameteriv GetNamedRenderbufferParameteriv;

        private static CreateTexture _CreateTexture;
        private static CreateTextures _CreateTextures;

        /// <summary>
        /// Attaches buffer objects to texture objects.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureBuffer TextureBuffer;

        private static TextureBufferRange_32 TextureBufferRange_32;
        private static TextureBufferRange_64 TextureBufferRange_64;

        /// <summary>
        /// Creates a storage for all levels of a 1D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureStorage1D TextureStorage1D;

        /// <summary>
        /// Creates a storage for all levels of a 2D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureStorage2D TextureStorage2D;

        /// <summary>
        /// Creates a storage for all levels of a 3D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureStorage3D TextureStorage3D;

        /// <summary>
        /// Creates a storage for of a 3D multisample texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureStorage2DMultisample TextureStorage2DMultisample;

        /// <summary>
        /// Creates a storage for of a 3D multisample texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureStorage3DMultisample TextureStorage3DMultisample;

        private static TextureSubImage1D _TextureSubImage1D;
        private static TextureSubImage2D _TextureSubImage2D;
        private static TextureSubImage3D _TextureSubImage3D;
        private static CompressedTextureSubImage1D _CompressedTextureSubImage1D;
        private static CompressedTextureSubImage2D _CompressedTextureSubImage2D;
        private static CompressedTextureSubImage3D _CompressedTextureSubImage3D;

        /// <summary>
        /// Copies pixels inside a 1D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static CopyTextureSubImage1D CopyTextureSubImage1D;

        /// <summary>
        /// Copies pixels inside a 2D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static CopyTextureSubImage2D CopyTextureSubImage2D;

        /// <summary>
        /// Copies pixels inside a 3D texture.
        /// </summary>
        [CLSCompliant(false)]
        public static CopyTextureSubImage3D CopyTextureSubImage3D;

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureParameterf TextureParameterf;

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureParameterfv TextureParameterfv;

        private static TextureParameteri _TextureParameteri;

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureParameteriv TextureParameteriv;

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureParameterIiv TextureParameterIiv;

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureParameterIuiv TextureParameterIuiv;

        /// <summary>
        /// Generates the mipmap of a texture object.
        /// </summary>
        [CLSCompliant(false)]
        public static GenerateTextureMipmap GenerateTextureMipmap;

        /// <summary>
        /// Bind a texture object to a texture unit.
        /// </summary>
        [CLSCompliant(false)]
        public static BindTextureUnit BindTextureUnit;

        private static GetTextureImage _GetTextureImage;
        private static GetCompressedTextureImage _GetCompressedTextureImage;

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureLevelParameterf GetTextureLevelParameterf;

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureLevelParameterfv GetTextureLevelParameterfv;

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureLevelParameteri GetTextureLevelParameteri;

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureLevelParameteriv GetTextureLevelParameteriv;

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterf GetTextureParameterf;

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterfv GetTextureParameterfv;

        private static GetTextureParameteri _GetTextureParameteri;
        private static GetTextureParameteriv _GetTextureParameteriv;

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterIi GetTextureParameterIi;

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterIiv GetTextureParameterIiv;

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterIui GetTextureParameterIui;

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTextureParameterIuiv GetTextureParameterIuiv;

        private static CreateVertexArray _CreateVertexArray;
        private static CreateVertexArrays _CreateVertexArrays;

        /// <summary>
        /// Disables a vertex array attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static DisableVertexArrayAttrib DisableVertexArrayAttrib;

        /// <summary>
        /// Enables a vertex array attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static EnableVertexArrayAttrib EnableVertexArrayAttrib;

        /// <summary>
        /// Sets the element array buffer binding of a vertex array object.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayElementBuffer VertexArrayElementBuffer;

        private static VertexArrayVertexBuffer_32 VertexArrayVertexBuffer_32;
        private static VertexArrayVertexBuffer_64 VertexArrayVertexBuffer_64;
        private static VertexArrayVertexBuffers_32 VertexArrayVertexBuffers_32;
        private static VertexArrayVertexBuffers_64 VertexArrayVertexBuffers_64;

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayAttribBinding VertexArrayAttribBinding;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayAttribFormat VertexArrayAttribFormat;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayAttribIFormat VertexArrayAttribIFormat;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayAttribLFormat VertexArrayAttribLFormat;

        /// <summary>
        /// Sets the rate at which vertex attributes advance.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexArrayBindingDivisor VertexArrayBindingDivisor;

        /// <summary>
        /// Returns the parameters of vertex array objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayi GetVertexArrayi;

        /// <summary>
        /// Returns the parameters of vertex array objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayiv GetVertexArrayiv;

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayIndexedi GetVertexArrayIndexedi;

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayIndexediv GetVertexArrayIndexediv;

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayIndexed64i GetVertexArrayIndexed64i;

        /// <summary>
        /// Returns the parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexArrayIndexed64iv GetVertexArrayIndexed64iv;

        private static CreateSampler _CreateSampler;
        private static CreateSamplers _CreateSamplers;
        private static CreateProgramPipeline _CreateProgramPipeline;
        private static CreateProgramPipelines _CreateProgramPipelines;
        private static CreateQuery _CreateQuery;
        private static CreateQueries _CreateQueries;
        private static GetQueryBufferObjecti64v_32 GetQueryBufferObjecti64v_32;
        private static GetQueryBufferObjecti64v_64 GetQueryBufferObjecti64v_64;
        private static GetQueryBufferObjectiv_32 GetQueryBufferObjectiv_32;
        private static GetQueryBufferObjectiv_64 GetQueryBufferObjectiv_64;
        private static GetQueryBufferObjectui64v_32 GetQueryBufferObjectui64v_32;
        private static GetQueryBufferObjectui64v_64 GetQueryBufferObjectui64v_64;
        private static GetQueryBufferObjectuiv_32 GetQueryBufferObjectuiv_32;
        private static GetQueryBufferObjectuiv_64 GetQueryBufferObjectuiv_64;

        /// <summary>
        /// Orders memory transactions for regions issued prior to this command relative to those issued after this.
        /// </summary>
        public static MemoryBarrierByRegion MemoryBarrierByRegion;

        private static GetTextureSubImage _GetTextureSubImage;
        private static GetCompressedTextureSubImage _GetCompressedTextureSubImage;

        /// <summary>
        /// Returns if the rendering context has not been lost due to software or hardware issues.
        /// </summary>
        public static GetGraphicsResetStatus GetGraphicsResetStatus;

        private static GetnCompressedTexImage _GetnCompressedTexImage;
        private static GetnTexImage _GetnTexImage;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetnUniformdv GetnUniformdv;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetnUniformfv GetnUniformfv;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetnUniformiv GetnUniformiv;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetnUniformuiv GetnUniformuiv;

        private static ReadnPixels _ReadnPixels;

        /// <summary>
        /// Controls the ordering of reads and writes to rendered fragments across drawing commands.
        /// </summary>
        public static TextureBarrier TextureBarrier;
        #endregion

        #region Overloads
        #region CreateTransformFeedback(s)
        /// <summary>
        /// Creates one transform feedback object and returns it's name.
        /// </summary>
        /// <returns>The name of the new transform feedback object.</returns>
        [CLSCompliant(false)]
        public static uint CreateTransformFeedback()
        {
            uint ret;
            _CreateTransformFeedback(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one transform feedback object and returns it's name.
        /// </summary>
        /// <param name="id">Returns the name of the new transform feedback object.</param>
        [CLSCompliant(false)]
        public static void CreateTransformFeedback(out uint id)
        {
            _CreateTransformFeedback(1, out id);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many transform feedback objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of transform feedback objects to be created.</param>
        /// <returns>The names of the new transform feedback objects as array.</returns>
        [CLSCompliant(false)]
        public static uint[] CreateTransformFeedbacks(int count)
        {
            uint[] ret = new uint[count];
            _CreateTransformFeedbacks(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many transform feedback objects.
        /// </summary>
        /// <param name="count">The number of transform feedback objects to be created.</param>
        /// <param name="ids">Returns the name of the new transform feedback objects.</param>
        [CLSCompliant(false)]
        public static void CreateTransformFeedbacks(int count, uint[] ids)
        {
            _CreateTransformFeedbacks(count, ids);
        }
        #endregion

        #region TransformFeedbackBufferRange
        /// <summary>
        /// Binds a range within a buffer object to a transform feedback buffer object.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="index">The index of the transform feedback stream.</param>
        /// <param name="buffer">The name of the buffer.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="size">The size of the region.</param>
        [CLSCompliant(false)]
        public static void TransformFeedbackBufferRange(uint xfb, uint index, uint buffer, int offset, int size)
        {
            if (IntPtr.Size == 4) TransformFeedbackBufferRange_32(xfb, index, buffer, offset, size);
            else TransformFeedbackBufferRange_64(xfb, index, buffer, offset, size);
        }

        /// <summary>
        /// Binds a range within a buffer object to a transform feedback buffer object.
        /// </summary>
        /// <param name="xfb">The name of the transform feedback buffer object.</param>
        /// <param name="index">The index of the transform feedback stream.</param>
        /// <param name="buffer">The name of the buffer.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="size">The size of the region.</param>
        [CLSCompliant(false)]
        public static void TransformFeedbackBufferRange(uint xfb, uint index, uint buffer, long offset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                TransformFeedbackBufferRange_32(xfb, index, buffer, (int)offset, (int)size);
            }
            else TransformFeedbackBufferRange_64(xfb, index, buffer, offset, size);
        }
        #endregion

        #region CreateBuffer(s)
        /// <summary>
        /// Creates one buffer object and returns it's name.
        /// </summary>
        /// <returns>The name of the new buffer object.</returns>
        [CLSCompliant(false)]
        public static uint CreateBuffer()
        {
            uint ret;
            _CreateBuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one buffer object and returns it's name.
        /// </summary>
        /// <param name="buffer">Returns the name of the new buffer object.</param>
        [CLSCompliant(false)]
        public static void CreateBuffer(out uint buffer)
        {
            _CreateBuffer(1, out buffer);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many buffer objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of buffer objects to be created.</param>
        /// <returns>The names of the new buffer objects as array.</returns>
        [CLSCompliant(false)]
        public static uint[] CreateBuffers(int count)
        {
            uint[] ret = new uint[count];
            _CreateBuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many buffer objects.
        /// </summary>
        /// <param name="count">The number of buffer objects to be created.</param>
        /// <param name="buffers">Returns the name of the new buffer objects.</param>
        [CLSCompliant(false)]
        public static void CreateBuffers(int count, uint[] buffers)
        {
            _CreateBuffers(count, buffers);
        }
        #endregion

        #region NamedBufferStorage
        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, IntPtr data, BufferStorageFlags flags)
        {
            if (IntPtr.Size == 4) NamedBufferStorage_32(buffer, size, data, flags);
            else NamedBufferStorage_64(buffer, size, data, flags);
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, IntPtr data, BufferStorageFlags flags)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                NamedBufferStorage_32(buffer, (int)size, data, flags);
            }
            else NamedBufferStorage_64(buffer, size, data, flags);
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, byte[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, byte[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, sbyte[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, sbyte[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, short[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, short[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, ushort[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, ushort[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, int[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, int[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, uint[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, uint[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, long[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, long[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, ulong[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, ulong[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, float[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, float[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, int size, double[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's immutable data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the storage in bytes.</param>
        /// <param name="data">The data used to initializes the buffer.</param>
        /// <param name="flags">A mask of <see cref="BufferStorageFlags"/>s specifying the usage of the buffer's data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferStorage(uint buffer, long size, double[] data, BufferStorageFlags flags)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferStorage(buffer, size, hData.AddrOfPinnedObject(), flags);
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region NamedBufferData
        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>IntPtr.Zero</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, IntPtr data, BufferUsageHint usage)
        {
            if (IntPtr.Size == 4) NamedBufferData_32(buffer, size, data, usage);
            else NamedBufferData_64(buffer, size, data, usage);
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>IntPtr.Zero</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, IntPtr data, BufferUsageHint usage)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                NamedBufferData_32(buffer, (int)size, data, usage);
            }
            else NamedBufferData_64(buffer, size, data, usage);
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, byte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, byte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, sbyte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, sbyte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, short[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, short[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, ushort[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, ushort[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, int[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, int[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, uint[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, uint[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, long[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, long[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, ulong[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, ulong[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, float[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, float[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, int size, double[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void NamedBufferData(uint buffer, long size, double[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferData(buffer, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }
        #endregion

        #region NamedBufferSubData
        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, IntPtr data)
        {
            if (IntPtr.Size == 4) NamedBufferSubData_32(buffer, offset, size, data);
            else NamedBufferSubData_64(buffer, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                NamedBufferSubData_32(buffer, (int)offset, (int)size, data);
            }
            else NamedBufferSubData_64(buffer, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, int offset, int size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void NamedBufferSubData(uint buffer, long offset, long size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }
        #endregion

        #region CopyNamedBufferSubData
        /// <summary>
        /// Copies data between buffer objects.
        /// </summary>
        /// <param name="readbuffer">The name of the buffer object to read from.</param>
        /// <param name="writebuffer">The name of the buffer object to write to.</param>
        /// <param name="readOffset">The offset into the read buffer.</param>
        /// <param name="writeOffset">The offset into the write buffer.</param>
        /// <param name="size">The size of the data block to be copied.</param>
        [CLSCompliant(false)]
        public static void CopyNamedBufferSubData(uint readbuffer, uint writebuffer, int readOffset, int writeOffset, int size)
        {
            if (IntPtr.Size == 4) CopyNamedBufferSubData_32(readbuffer, writebuffer, readOffset, writeOffset, size);
            else CopyNamedBufferSubData_64(readbuffer, writebuffer, readOffset, writeOffset, size);
        }

        /// <summary>
        /// Copies data between buffer objects.
        /// </summary>
        /// <param name="readbuffer">The name of the buffer object to read from.</param>
        /// <param name="writebuffer">The name of the buffer object to write to.</param>
        /// <param name="readOffset">The offset into the read buffer.</param>
        /// <param name="writeOffset">The offset into the write buffer.</param>
        /// <param name="size">The size of the data block to be copied.</param>
        [CLSCompliant(false)]
        public static void CopyNamedBufferSubData(uint readbuffer, uint writebuffer, long readOffset, long writeOffset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)readOffset >> 32) != 0) throw new ArgumentOutOfRangeException("readOffset", PlatformErrorString);
                if (((long)writeOffset >> 32) != 0) throw new ArgumentOutOfRangeException("writeOffset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                CopyNamedBufferSubData_32(readbuffer, writebuffer, (int)readOffset, (int)writeOffset, (int)size);
            }
            else CopyNamedBufferSubData_64(readbuffer, writebuffer, readOffset, writeOffset, size);
        }
        #endregion

        #region ClearNamedBufferData
        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, IntPtr data)
        {
            _ClearNamedBufferData(buffer, internalformat, format, type, data);
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferData(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearNamedBufferData(buffer, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region ClearNamedBufferSubData
        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, IntPtr data)
        {
            if (IntPtr.Size == 4) ClearNamedBufferSubData_32(buffer, internalformat, offset, size, format, type, data);
            else ClearNamedBufferSubData_64(buffer, internalformat, offset, size, format, type, data);
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                ClearNamedBufferSubData_32(buffer, internalformat, (int)offset, (int)size, format, type, data);
            }
            else ClearNamedBufferSubData_64(buffer, internalformat, offset, size, format, type, data);
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearNamedBufferSubData(uint buffer, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region MapNamedBufferRange
        /// <summary>
        /// Maps all or parts of a data store into client memory.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        public static IntPtr MapNamedBufferRange(uint buffer, int offset, int length, BufferAccessMask access)
        {
            if (IntPtr.Size == 4) return MapNamedBufferRange_32(buffer, offset, length, access);
            return MapNamedBufferRange_64(buffer, offset, length, access);
        }

        /// <summary>
        /// Maps all or parts of a data store into client memory.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        public static IntPtr MapNamedBufferRange(uint buffer, long offset, long length, BufferAccessMask access)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)length >> 32) != 0) throw new ArgumentOutOfRangeException("length", PlatformErrorString);
                return MapNamedBufferRange_32(buffer, (int)offset, (int)length, access);
            }
            return MapNamedBufferRange_64(buffer, offset, length, access);
        }
        #endregion

        #region FlushMappedNamedBufferRange
        /// <summary>
        /// Flushes modifications to a range of a mapped buffer.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        public static void FlushMappedNamedBufferRange(uint buffer, int offset, int length)
        {
            if (IntPtr.Size == 4) FlushMappedNamedBufferRange_32(buffer, offset, length);
            else FlushMappedNamedBufferRange_64(buffer, offset, length);
        }

        /// <summary>
        /// Flushes modifications to a range of a mapped buffer.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        public static void FlushMappedNamedBufferRange(uint buffer, long offset, long length)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)length >> 32) != 0) throw new ArgumentOutOfRangeException("length", PlatformErrorString);
                FlushMappedNamedBufferRange_32(buffer, (int)offset, (int)length);
            }
            else FlushMappedNamedBufferRange_64(buffer, offset, length);
        }
        #endregion

        #region GetNamedBufferSubData
        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, IntPtr data)
        {
            if (IntPtr.Size == 4) GetNamedBufferSubData_32(buffer, offset, size, data);
            else GetNamedBufferSubData_64(buffer, offset, size, data);
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                GetNamedBufferSubData_32(buffer, (int)offset, (int)size, data);
            }
            else GetNamedBufferSubData_64(buffer, offset, size, data);
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, int offset, int size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetNamedBufferSubData(uint buffer, long offset, long size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetNamedBufferSubData(buffer, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }
        #endregion

        #region CreateFramebuffer(s)
        /// <summary>
        /// Creates one framebuffer object and returns it's name.
        /// </summary>
        /// <returns>The name of the new framebuffer object.</returns>
        public static uint CreateFramebuffer()
        {
            uint ret;
            _CreateFramebuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one framebuffer object and returns it's name.
        /// </summary>
        /// <param name="framebuffer">Returns the name of the new framebuffer object.</param>
        public static void CreateFramebuffer(out uint framebuffer)
        {
            _CreateFramebuffer(1, out framebuffer);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many framebuffer objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of framebuffer objects to be created.</param>
        /// <returns>The names of the new framebuffer objects as array.</returns>
        public static uint[] CreateFramebuffers(int count)
        {
            uint[] ret = new uint[count];
            _CreateFramebuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many framebuffer objects.
        /// </summary>
        /// <param name="count">The number of framebuffer objects to be created.</param>
        /// <param name="framebuffers">Returns the name of the new framebuffer objects.</param>
        public static void CreateFramebuffers(int count, uint[] framebuffers)
        {
            _CreateFramebuffers(count, framebuffers);
        }
        #endregion

        #region CreateRenderbuffer(s)
        /// <summary>
        /// Creates one renderbuffer object and returns it's name.
        /// </summary>
        /// <returns>The name of the new renderbuffer object.</returns>
        public static uint CreateRenderbuffer()
        {
            uint ret;
            _CreateRenderbuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one renderbuffer object and returns it's name.
        /// </summary>
        /// <param name="renderbuffer">Returns the name of the new renderbuffer object.</param>
        public static void CreateRenderbuffer(out uint renderbuffer)
        {
            _CreateRenderbuffer(1, out renderbuffer);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many renderbuffer objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of renderbuffer objects to be created.</param>
        /// <returns>The names of the new renderbuffer objects as array.</returns>
        public static uint[] CreateRenderbuffers(int count)
        {
            uint[] ret = new uint[count];
            _CreateRenderbuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many renderbuffer objects.
        /// </summary>
        /// <param name="count">The number of renderbuffer objects to be created.</param>
        /// <param name="renderbuffers">Returns the name of the new renderbuffer objects.</param>
        public static void CreateRenderbuffers(int count, uint[] renderbuffers)
        {
            _CreateRenderbuffers(count, renderbuffers);
        }
        #endregion

        #region CreateTexture(s)
        /// <summary>
        /// Creates one texture object and returns it's name.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the effective texture target.</param>
        /// <returns>The name of the new texture object.</returns>
        public static uint CreateTexture(TextureTarget target)
        {
            uint ret;
            _CreateTexture(target, 1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one texture object and returns it's name.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the effective texture target.</param>
        /// <param name="texture">Returns the name of the new texture object.</param>
        public static void CreateTexture(TextureTarget target, out uint texture)
        {
            _CreateTexture(target, 1, out texture);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many texture objects and returns their names as array.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the effective texture target.</param>
        /// <param name="count">The number of texture objects to be created.</param>
        /// <returns>The names of the new texture objects as array.</returns>
        public static uint[] CreateTextures(TextureTarget target, int count)
        {
            uint[] ret = new uint[count];
            _CreateTextures(target, count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many texture objects.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the effective texture target.</param>
        /// <param name="count">The number of texture objects to be created.</param>
        /// <param name="textures">Returns the name of the new texture objects.</param>
        public static void CreateTextures(TextureTarget target, int count, uint[] textures)
        {
            _CreateTextures(target, count, textures);
        }
        #endregion

        #region TextureBufferRange
        /// <summary>
        /// Attaches a range of a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The length of the region.</param>
        public static void TextureBufferRange(uint texture, InternalFormat internalformat, uint buffer, int offset, int size)
        {
            if (IntPtr.Size == 4) TextureBufferRange_32(texture, internalformat, buffer, offset, size);
            else TextureBufferRange_64(texture, internalformat, buffer, offset, size);
        }

        /// <summary>
        /// Attaches a range of a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The length of the region.</param>
        public static void TextureBufferRange(uint texture, InternalFormat internalformat, uint buffer, long offset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                TextureBufferRange_32(texture, internalformat, buffer, (int)offset, (int)size);
            }
            else TextureBufferRange_64(texture, internalformat, buffer, offset, size);
        }
        #endregion

        #region TextureSubImage1D
        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, IntPtr pixels)
        {
            _TextureSubImage1D(texture, level, xoffset, width, format, type, pixels);
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, int offset)
        {
            _TextureSubImage1D(texture, level, xoffset, width, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _TextureSubImage1D(texture, level, xoffset, width, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage1D(texture, level, xoffset, width, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region TextureSubImage2D
        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
        {
            _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, pixels);
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, int offset)
        {
            _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region TextureSubImage3D
        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr pixels)
        {
            _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int offset)
        {
            _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Loads a part a 3D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _TextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region CompressedTextureSubImage1D
        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, int offset)
        {
            _CompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region CompressedTextureSubImage2D
        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, int offset)
        {
            _CompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region CompressedTextureSubImage3D
        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, int offset)
        {
            _CompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region TextureParameteri
        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, int param)
        {
            _TextureParameteri(texture, pname, param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, TextureMagFilter param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, TextureMinFilter param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set. Only one of the texture wrapping parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, TextureWrapMode param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_MODE"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, TextureCompareMode param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, TextureParameter param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameters of texture object.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.DEPTH_STENCIL_TEXTURE_MODE"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        public static void TextureParameteri(uint texture, TextureParameterName pname, DepthStencilTextureMode param)
        {
            _TextureParameteri(texture, pname, (int)param);
        }
        #endregion

        #region GetTextureImage
        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, IntPtr pixels)
        {
            _GetTextureImage(texture, level, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, int offset)
        {
            _GetTextureImage(texture, level, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetTextureImage(texture, level, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureImage(texture, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region GetCompressedTextureImage
        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTextureImage(uint texture, int level, int bufSize, int offset)
        {
            _GetCompressedTextureImage(texture, level, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTextureImage(uint texture, int level, int bufSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetCompressedTextureImage(texture, level, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetCompressedTextureImage(uint texture, int level, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetCompressedTextureImage(texture, level, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region GetTextureParameteri(v)
        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out int param)
        {
            _GetTextureParameteri(texture, pname, out param);
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureMagFilter param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureMagFilter)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureMinFilter param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureMinFilter)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureParameter param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureParameter)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureWrapMode param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureWrapMode)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_MODE"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureCompareMode param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureCompareMode)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out AlphaFunction param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (AlphaFunction)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out DepthFunction param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (DepthFunction)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.DEPTH_STENCIL_TEXTURE_MODE"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out DepthStencilTextureMode param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (DepthStencilTextureMode)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_TARGET"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out TextureTarget param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (TextureTarget)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.IMAGE_FORMAT_COMPATIBILITY_TYPE"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        public static void GetTextureParameteri(uint texture, GetTextureParameter pname, out ImageFormatCompatibilityType param)
        {
            int ret;
            _GetTextureParameteri(texture, pname, out ret);
            param = (ImageFormatCompatibilityType)ret;
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        public static void GetTextureParameteriv(uint texture, GetTextureParameter pname, int[] @params)
        {
            _GetTextureParameteriv(texture, pname, @params);
        }

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        public static void GetTextureParameteriv(uint texture, GetTextureParameter pname, TextureParameter[] @params)
        {
            int[] ret = new int[@params.Length];
            _GetTextureParameteriv(texture, pname, ret);
            for (int i = 0; i < ret.Length; i++) @params[i] = (TextureParameter)ret[i];
        }
        #endregion

        #region CreateVertexArray(s)
        /// <summary>
        /// Creates one vertex array object and returns it's name.
        /// </summary>
        /// <returns>The name of the new vertex array object.</returns>
        public static uint CreateVertexArray()
        {
            uint ret;
            _CreateVertexArray(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one vertex array object and returns it's name.
        /// </summary>
        /// <param name="array">Returns the name of the new vertex array object.</param>
        public static void CreateVertexArray(out uint array)
        {
            _CreateVertexArray(1, out array);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many vertex array objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of vertex array objects to be created.</param>
        /// <returns>The names of the new vertex array objects as array.</returns>
        public static uint[] CreateVertexArrays(int count)
        {
            uint[] ret = new uint[count];
            _CreateVertexArrays(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many vertex array objects.
        /// </summary>
        /// <param name="count">The number of vertex array objects to be created.</param>
        /// <param name="arrays">Returns the name of the new vertex array objects.</param>
        public static void CreateVertexArrays(int count, uint[] arrays)
        {
            _CreateVertexArrays(count, arrays);
        }
        #endregion

        #region VertexArrayVertexBuffer
        /// <summary>
        /// Binds a buffer to a vertex buffer binding point.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="bindingindex">The index of the vertex buffer binding point to which to bind the buffer.</param>
        /// <param name="buffer">The name of a buffer.</param>
        /// <param name="offset">The offset of the first element of the buffer.</param>
        /// <param name="stride">The distance between elements within the buffer.</param>
        public static void VertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, int offset, int stride)
        {
            if (IntPtr.Size == 4) VertexArrayVertexBuffer_32(vaobj, bindingindex, buffer, offset, stride);
            else VertexArrayVertexBuffer_64(vaobj, bindingindex, buffer, offset, stride);
        }

        /// <summary>
        /// Binds a buffer to a vertex buffer binding point.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="bindingindex">The index of the vertex buffer binding point to which to bind the buffer.</param>
        /// <param name="buffer">The name of a buffer.</param>
        /// <param name="offset">The offset of the first element of the buffer.</param>
        /// <param name="stride">The distance between elements within the buffer.</param>
        public static void VertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, long offset, int stride)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                VertexArrayVertexBuffer_32(vaobj, bindingindex, buffer, (int)offset, stride);
            }
            else VertexArrayVertexBuffer_64(vaobj, bindingindex, buffer, offset, stride);
        }
        #endregion

        #region VertexArrayVertexBuffers
        /// <summary>
        /// Attaches multiple buffer objects to a vertex array object.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="first">The first vertex buffer binding point to which a buffer object is to be bound.</param>
        /// <param name="count">The number of buffers to bind.</param>
        /// <param name="buffers">The buffers to bind.</param>
        /// <param name="offsets">The offsets to associate with the binding points.</param>
        /// <param name="strides">The strides to associate with the binding points.</param>
        public static void VertexArrayVertexBuffers(uint vaobj, uint first, int count, uint[] buffers, int[] offsets, int[] strides)
        {
            if (IntPtr.Size == 4) VertexArrayVertexBuffers_32(vaobj, first, count, buffers, offsets, strides);
            else
            {
                if (buffers == null)
                {
                    VertexArrayVertexBuffers_64(vaobj, first, count, null, null, null);
                    return;
                }

                long[] lOffsets = new long[offsets.Length];
                Array.Copy(offsets, lOffsets, offsets.Length);

                VertexArrayVertexBuffers_64(vaobj, first, count, buffers, lOffsets, strides);
            }
        }

        /// <summary>
        /// Attaches multiple buffer objects to a vertex array object.
        /// </summary>
        /// <param name="vaobj">The name of the vertex array object.</param>
        /// <param name="first">The first vertex buffer binding point to which a buffer object is to be bound.</param>
        /// <param name="count">The number of buffers to bind.</param>
        /// <param name="buffers">The buffers to bind.</param>
        /// <param name="offsets">The offsets to associate with the binding points.</param>
        /// <param name="strides">The strides to associate with the binding points.</param>
        public static void VertexArrayVertexBuffers(uint vaobj, uint first, int count, uint[] buffers, long[] offsets, int[] strides)
        {
            if (IntPtr.Size == 4)
            {
                if (buffers == null)
                {
                    VertexArrayVertexBuffers_32(vaobj, first, count, null, null, null);
                    return;
                }

                int[] iOffsets = new int[first + count];
                for (int i = 0; i < count; i++)
                {
                    long offset = offsets[first + i];
                    if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offsets", PlatformArrayErrorString);
                    iOffsets[first + i] = (int)offset;
                }

                VertexArrayVertexBuffers_32(vaobj, first, count, buffers, iOffsets, strides);
            }
            else VertexArrayVertexBuffers_64(vaobj, first, count, buffers, offsets, strides);
        }
        #endregion

        #region CreateSampler(s)
        /// <summary>
        /// Creates one sampler object and returns it's name.
        /// </summary>
        /// <returns>The name of the new sampler object.</returns>
        public static uint CreateSampler()
        {
            uint ret;
            _CreateSampler(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one sampler object and returns it's name.
        /// </summary>
        /// <param name="sampler">Returns the name of the new sampler object.</param>
        public static void CreateSampler(out uint sampler)
        {
            _CreateSampler(1, out sampler);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many sampler objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of sampler objects to be created.</param>
        /// <returns>The names of the new sampler objects as array.</returns>
        public static uint[] CreateSamplers(int count)
        {
            uint[] ret = new uint[count];
            _CreateSamplers(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many sampler objects.
        /// </summary>
        /// <param name="count">The number of sampler objects to be created.</param>
        /// <param name="samplers">Returns the name of the new sampler objects.</param>
        public static void CreateSamplers(int count, uint[] samplers)
        {
            _CreateSamplers(count, samplers);
        }
        #endregion

        #region CreateProgramPipeline(s)
        /// <summary>
        /// Creates one program pipeline object and returns it's name.
        /// </summary>
        /// <returns>The name of the new program pipeline object.</returns>
        public static uint CreateProgramPipeline()
        {
            uint ret;
            _CreateProgramPipeline(1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one program pipeline object and returns it's name.
        /// </summary>
        /// <param name="pipeline">Returns the name of the new program pipeline object.</param>
        public static void CreateProgramPipeline(out uint pipeline)
        {
            _CreateProgramPipeline(1, out pipeline);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many program pipeline objects and returns their names as array.
        /// </summary>
        /// <param name="count">The number of program pipeline objects to be created.</param>
        /// <returns>The names of the new program pipeline objects as array.</returns>
        public static uint[] CreateProgramPipelines(int count)
        {
            uint[] ret = new uint[count];
            _CreateProgramPipelines(count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many program pipeline objects.
        /// </summary>
        /// <param name="count">The number of program pipeline objects to be created.</param>
        /// <param name="pipelines">Returns the name of the new program pipeline objects.</param>
        public static void CreateProgramPipelines(int count, uint[] pipelines)
        {
            _CreateProgramPipelines(count, pipelines);
        }
        #endregion

        #region CreateQuery/CreateQueries
        /// <summary>
        /// Creates one query object and returns it's name.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the query type.</param>
        /// <returns>The name of the new query object.</returns>
        public static uint CreateQuery(QueryTarget target)
        {
            uint ret;
            _CreateQuery(target, 1, out ret);
            return ret;
        }

        /// <summary>
        /// Creates one query object and returns it's name.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the query type.</param>
        /// <param name="id">Returns the name of the new query object.</param>
        public static void CreateQuery(QueryTarget target, out uint id)
        {
            _CreateQuery(target, 1, out id);
        }

        /// <summary>
        /// Creates <paramref name="count"/> many query objects and returns their names as array.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the query type.</param>
        /// <param name="count">The number of query objects to be created.</param>
        /// <returns>The names of the new query objects as array.</returns>
        public static uint[] CreateQueries(QueryTarget target, int count)
        {
            uint[] ret = new uint[count];
            _CreateQueries(target, count, ret);
            return ret;
        }

        /// <summary>
        /// Creates <paramref name="count"/> many query objects.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the query type.</param>
        /// <param name="count">The number of query objects to be created.</param>
        /// <param name="ids">Returns the name of the new query objects.</param>
        public static void CreateQueries(QueryTarget target, int count, uint[] ids)
        {
            _CreateQueries(target, count, ids);
        }
        #endregion

        #region GetQueryBufferObject
        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjecti64v(uint id, uint buffer, GetQueryObjectParam pname, int offset)
        {
            if (IntPtr.Size == 4) GetQueryBufferObjecti64v_32(id, buffer, pname, offset);
            else GetQueryBufferObjecti64v_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjecti64v(uint id, uint buffer, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                GetQueryBufferObjecti64v_32(id, buffer, pname, (int)offset);
            }
            else GetQueryBufferObjecti64v_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectiv(uint id, uint buffer, GetQueryObjectParam pname, int offset)
        {
            if (IntPtr.Size == 4) GetQueryBufferObjectiv_32(id, buffer, pname, offset);
            else GetQueryBufferObjectiv_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectiv(uint id, uint buffer, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                GetQueryBufferObjectiv_32(id, buffer, pname, (int)offset);
            }
            else GetQueryBufferObjectiv_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectui64v(uint id, uint buffer, GetQueryObjectParam pname, int offset)
        {
            if (IntPtr.Size == 4) GetQueryBufferObjectui64v_32(id, buffer, pname, offset);
            else GetQueryBufferObjectui64v_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectui64v(uint id, uint buffer, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                GetQueryBufferObjectui64v_32(id, buffer, pname, (int)offset);
            }
            else GetQueryBufferObjectui64v_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectuiv(uint id, uint buffer, GetQueryObjectParam pname, int offset)
        {
            if (IntPtr.Size == 4) GetQueryBufferObjectuiv_32(id, buffer, pname, offset);
            else GetQueryBufferObjectuiv_64(id, buffer, pname, offset);
        }

        /// <summary>
        /// Writes the parameters of a query into a query buffer object.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="buffer">The name of the query buffer object to write into.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The object into the query buffer object to write into.</param>
        public static void GetQueryBufferObjectuiv(uint id, uint buffer, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                GetQueryBufferObjectuiv_32(id, buffer, pname, (int)offset);
            }
            else GetQueryBufferObjectuiv_64(id, buffer, pname, offset);
        }
        #endregion

        #region GetTextureSubImage
        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, IntPtr pixels)
        {
            _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, int offset)
        {
            _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, long offset)
        {
            _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region GetCompressedTextureSubImage
        /// <summary>
        /// Reads/Copies all or part of a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/> as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, int offset)
        {
            _GetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/> as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies all or part of a texture into client memory as compressed texture.
        /// </summary>
        /// <param name="texture">The name of the texture object.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in Z direction.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region GetnCompressedTexImage
        /// <summary>
        /// Reads/Copies a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/> as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetnCompressedTexImage(TextureTarget target, int level, int bufSize, int offset)
        {
            _GetnCompressedTexImage(target, level, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/> as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetnCompressedTexImage(TextureTarget target, int level, int bufSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetnCompressedTexImage(target, level, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies a texture into client memory as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnCompressedTexImage(TextureTarget target, int level, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnCompressedTexImage(target, level, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region GetnTexImage
        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, IntPtr pixels)
        {
            _GetnTexImage(target, level, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Reads/Copies a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, int offset)
        {
            _GetnTexImage(target, level, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies a texture into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetnTexImage(target, level, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads/Copies a texture into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void GetnTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _GetnTexImage(target, level, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion

        #region ReadnPixels
        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, IntPtr pixels)
        {
            _ReadnPixels(x, y, width, height, format, type, bufSize, pixels);
        }

        /// <summary>
        /// Reads pixels form the framebuffer into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, int offset)
        {
            _ReadnPixels(x, y, width, height, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads pixels form the framebuffer into <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of the receiving buffer in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, long offset)
        {
            _ReadnPixels(x, y, width, height, format, type, bufSize, (IntPtr)offset);
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, sbyte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, short[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ushort[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, int[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, uint[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, long[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, ulong[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, float[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        /// <summary>
        /// Reads pixels form the framebuffer into client memory. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="bufSize">Size of <paramref name="pixels"/> in bytes.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, double[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _ReadnPixels(x, y, width, height, format, type, bufSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }
        #endregion
        #endregion

        private static void Load_VERSION_4_5()
        {
            ClipControl = GetAddress<Delegates.ClipControl>("glClipControl");
            _CreateTransformFeedback = GetAddress<CreateTransformFeedback>("glCreateTransformFeedbacks");
            _CreateTransformFeedbacks = GetAddress<CreateTransformFeedbacks>("glCreateTransformFeedbacks");
            TransformFeedbackBufferBase = GetAddress<TransformFeedbackBufferBase>("glTransformFeedbackBufferBase");
            GetTransformFeedbacki = GetAddress<GetTransformFeedbacki>("glGetTransformFeedbackiv");
            GetTransformFeedbackiv = GetAddress<GetTransformFeedbackiv>("glGetTransformFeedbackiv");
            GetTransformFeedbacki_ = GetAddress<GetTransformFeedbacki_>("glGetTransformFeedbacki_v");
            GetTransformFeedbacki_v = GetAddress<GetTransformFeedbacki_v>("glGetTransformFeedbacki_v");
            GetTransformFeedbacki64_ = GetAddress<GetTransformFeedbacki64_>("glGetTransformFeedbacki64_v");
            GetTransformFeedbacki64_v = GetAddress<GetTransformFeedbacki64_v>("glGetTransformFeedbacki64_v");
            _CreateBuffer = GetAddress<CreateBuffer>("glCreateBuffers");
            _CreateBuffers = GetAddress<CreateBuffers>("glCreateBuffers");
            _ClearNamedBufferData = GetAddress<ClearNamedBufferData>("glClearNamedBufferData");
            MapNamedBuffer = GetAddress<MapNamedBuffer>("glMapNamedBuffer");
            UnmapNamedBuffer = GetAddress<UnmapNamedBuffer>("glUnmapNamedBuffer");
            GetNamedBufferParameteri = GetAddress<GetNamedBufferParameteri>("glGetNamedBufferParameteriv");
            GetNamedBufferParameteriv = GetAddress<GetNamedBufferParameteriv>("glGetNamedBufferParameteriv");
            GetNamedBufferParameteri64 = GetAddress<GetNamedBufferParameteri64>("glGetNamedBufferParameteri64v");
            GetNamedBufferParameteri64v = GetAddress<GetNamedBufferParameteri64v>("glGetNamedBufferParameteri64v");
            GetNamedBufferPointerv = GetAddress<GetNamedBufferPointerv>("glGetNamedBufferPointerv");
            _CreateFramebuffer = GetAddress<CreateFramebuffer>("glCreateFramebuffers");
            _CreateFramebuffers = GetAddress<CreateFramebuffers>("glCreateFramebuffers");
            NamedFramebufferRenderbuffer = GetAddress<NamedFramebufferRenderbuffer>("glNamedFramebufferRenderbuffer");
            NamedFramebufferParameteri = GetAddress<NamedFramebufferParameteri>("glNamedFramebufferParameteri");
            NamedFramebufferTexture = GetAddress<NamedFramebufferTexture>("glNamedFramebufferTexture");
            NamedFramebufferTextureLayer = GetAddress<NamedFramebufferTextureLayer>("glNamedFramebufferTextureLayer");
            NamedFramebufferDrawBuffer = GetAddress<NamedFramebufferDrawBuffer>("glNamedFramebufferDrawBuffer");
            NamedFramebufferDrawBuffers = GetAddress<NamedFramebufferDrawBuffers>("glNamedFramebufferDrawBuffers");
            NamedFramebufferReadBuffer = GetAddress<NamedFramebufferReadBuffer>("glNamedFramebufferReadBuffer");
            InvalidateNamedFramebufferData = GetAddress<InvalidateNamedFramebufferData>("glInvalidateNamedFramebufferData");
            InvalidateNamedFramebufferSubData = GetAddress<InvalidateNamedFramebufferSubData>("glInvalidateNamedFramebufferSubData");
            ClearNamedFramebufferiv = GetAddress<ClearNamedFramebufferiv>("glClearNamedFramebufferiv");
            ClearNamedFramebufferuiv = GetAddress<ClearNamedFramebufferuiv>("glClearNamedFramebufferuiv");
            ClearNamedFramebufferfv = GetAddress<ClearNamedFramebufferfv>("glClearNamedFramebufferfv");
            ClearNamedFramebufferfi = GetAddress<ClearNamedFramebufferfi>("glClearNamedFramebufferfi");
            BlitNamedFramebuffer = GetAddress<BlitNamedFramebuffer>("glBlitNamedFramebuffer");
            CheckNamedFramebufferStatus = GetAddress<CheckNamedFramebufferStatus>("glCheckNamedFramebufferStatus");
            GetNamedFramebufferParameteri = GetAddress<GetNamedFramebufferParameteri>("glGetNamedFramebufferParameteriv");
            GetNamedFramebufferParameteriv = GetAddress<GetNamedFramebufferParameteriv>("glGetNamedFramebufferParameteriv");
            GetNamedFramebufferAttachmentParameteri = GetAddress<GetNamedFramebufferAttachmentParameteri>("glGetNamedFramebufferAttachmentParameteriv");
            GetNamedFramebufferAttachmentParameteriv = GetAddress<GetNamedFramebufferAttachmentParameteriv>("glGetNamedFramebufferAttachmentParameteriv");
            _CreateRenderbuffer = GetAddress<CreateRenderbuffer>("glCreateRenderbuffers");
            _CreateRenderbuffers = GetAddress<CreateRenderbuffers>("glCreateRenderbuffers");
            NamedRenderbufferStorage = GetAddress<NamedRenderbufferStorage>("glNamedRenderbufferStorage");
            NamedRenderbufferStorageMultisample = GetAddress<NamedRenderbufferStorageMultisample>("glNamedRenderbufferStorageMultisample");
            GetNamedRenderbufferParameteri = GetAddress<GetNamedRenderbufferParameteri>("glGetNamedRenderbufferParameteriv");
            GetNamedRenderbufferParameteriv = GetAddress<GetNamedRenderbufferParameteriv>("glGetNamedRenderbufferParameteriv");
            _CreateTexture = GetAddress<CreateTexture>("glCreateTextures");
            _CreateTextures = GetAddress<CreateTextures>("glCreateTextures");
            TextureBuffer = GetAddress<TextureBuffer>("glTextureBuffer");
            TextureStorage1D = GetAddress<TextureStorage1D>("glTextureStorage1D");
            TextureStorage2D = GetAddress<TextureStorage2D>("glTextureStorage2D");
            TextureStorage3D = GetAddress<TextureStorage3D>("glTextureStorage3D");
            TextureStorage2DMultisample = GetAddress<TextureStorage2DMultisample>("glTextureStorage2DMultisample");
            TextureStorage3DMultisample = GetAddress<TextureStorage3DMultisample>("glTextureStorage3DMultisample");
            _TextureSubImage1D = GetAddress<TextureSubImage1D>("glTextureSubImage1D");
            _TextureSubImage2D = GetAddress<TextureSubImage2D>("glTextureSubImage2D");
            _TextureSubImage3D = GetAddress<TextureSubImage3D>("glTextureSubImage3D");
            _CompressedTextureSubImage1D = GetAddress<CompressedTextureSubImage1D>("glCompressedTextureSubImage1D");
            _CompressedTextureSubImage2D = GetAddress<CompressedTextureSubImage2D>("glCompressedTextureSubImage2D");
            _CompressedTextureSubImage3D = GetAddress<CompressedTextureSubImage3D>("glCompressedTextureSubImage3D");
            CopyTextureSubImage1D = GetAddress<CopyTextureSubImage1D>("glCopyTextureSubImage1D");
            CopyTextureSubImage2D = GetAddress<CopyTextureSubImage2D>("glCopyTextureSubImage2D");
            CopyTextureSubImage3D = GetAddress<CopyTextureSubImage3D>("glCopyTextureSubImage3D");
            TextureParameterf = GetAddress<TextureParameterf>("glTextureParameterf");
            TextureParameterfv = GetAddress<TextureParameterfv>("glTextureParameterfv");
            _TextureParameteri = GetAddress<TextureParameteri>("glTextureParameteri");
            TextureParameteriv = GetAddress<TextureParameteriv>("glTextureParameteriv");
            TextureParameterIiv = GetAddress<TextureParameterIiv>("glTextureParameterIiv");
            TextureParameterIuiv = GetAddress<TextureParameterIuiv>("glTextureParameterIuiv");
            GenerateTextureMipmap = GetAddress<GenerateTextureMipmap>("glGenerateTextureMipmap");
            BindTextureUnit = GetAddress<BindTextureUnit>("glBindTextureUnit");
            _GetTextureImage = GetAddress<GetTextureImage>("glGetTextureImage");
            _GetCompressedTextureImage = GetAddress<GetCompressedTextureImage>("glGetCompressedTextureImage");
            GetTextureLevelParameterf = GetAddress<GetTextureLevelParameterf>("glGetTextureLevelParameterfv");
            GetTextureLevelParameterfv = GetAddress<GetTextureLevelParameterfv>("glGetTextureLevelParameterfv");
            GetTextureLevelParameteri = GetAddress<GetTextureLevelParameteri>("glGetTextureLevelParameteriv");
            GetTextureLevelParameteriv = GetAddress<GetTextureLevelParameteriv>("glGetTextureLevelParameteriv");
            GetTextureParameterf = GetAddress<GetTextureParameterf>("glGetTextureParameterfv");
            GetTextureParameterfv = GetAddress<GetTextureParameterfv>("glGetTextureParameterfv");
            _GetTextureParameteri = GetAddress<GetTextureParameteri>("glGetTextureParameteriv");
            _GetTextureParameteriv = GetAddress<GetTextureParameteriv>("glGetTextureParameteriv");
            GetTextureParameterIi = GetAddress<GetTextureParameterIi>("glGetTextureParameterIiv");
            GetTextureParameterIiv = GetAddress<GetTextureParameterIiv>("glGetTextureParameterIiv");
            GetTextureParameterIui = GetAddress<GetTextureParameterIui>("glGetTextureParameterIuiv");
            GetTextureParameterIuiv = GetAddress<GetTextureParameterIuiv>("glGetTextureParameterIuiv");
            _CreateVertexArray = GetAddress<CreateVertexArray>("glCreateVertexArrays");
            _CreateVertexArrays = GetAddress<CreateVertexArrays>("glCreateVertexArrays");
            DisableVertexArrayAttrib = GetAddress<DisableVertexArrayAttrib>("glDisableVertexArrayAttrib");
            EnableVertexArrayAttrib = GetAddress<EnableVertexArrayAttrib>("glEnableVertexArrayAttrib");
            VertexArrayElementBuffer = GetAddress<VertexArrayElementBuffer>("glVertexArrayElementBuffer");
            VertexArrayAttribBinding = GetAddress<VertexArrayAttribBinding>("glVertexArrayAttribBinding");
            VertexArrayAttribFormat = GetAddress<VertexArrayAttribFormat>("glVertexArrayAttribFormat");
            VertexArrayAttribIFormat = GetAddress<VertexArrayAttribIFormat>("glVertexArrayAttribIFormat");
            VertexArrayAttribLFormat = GetAddress<VertexArrayAttribLFormat>("glVertexArrayAttribLFormat");
            VertexArrayBindingDivisor = GetAddress<VertexArrayBindingDivisor>("glVertexArrayBindingDivisor");
            GetVertexArrayi = GetAddress<GetVertexArrayi>("glGetVertexArrayiv");
            GetVertexArrayiv = GetAddress<GetVertexArrayiv>("glGetVertexArrayiv");
            GetVertexArrayIndexedi = GetAddress<GetVertexArrayIndexedi>("glGetVertexArrayIndexediv");
            GetVertexArrayIndexediv = GetAddress<GetVertexArrayIndexediv>("glGetVertexArrayIndexediv");
            GetVertexArrayIndexed64i = GetAddress<GetVertexArrayIndexed64i>("glGetVertexArrayIndexed64iv");
            GetVertexArrayIndexed64iv = GetAddress<GetVertexArrayIndexed64iv>("glGetVertexArrayIndexed64iv");
            _CreateSampler = GetAddress<CreateSampler>("glCreateSamplers");
            _CreateSamplers = GetAddress<CreateSamplers>("glCreateSamplers");
            _CreateProgramPipeline = GetAddress<CreateProgramPipeline>("glCreateProgramPipelines");
            _CreateProgramPipelines = GetAddress<CreateProgramPipelines>("glCreateProgramPipelines");
            _CreateQuery = GetAddress<CreateQuery>("glCreateQueries");
            _CreateQueries = GetAddress<CreateQueries>("glCreateQueries");
            MemoryBarrierByRegion = GetAddress<MemoryBarrierByRegion>("glMemoryBarrierByRegion");
            _GetTextureSubImage = GetAddress<GetTextureSubImage>("glGetTextureSubImage");
            _GetCompressedTextureSubImage = GetAddress<GetCompressedTextureSubImage>("glGetCompressedTextureSubImage");
            GetGraphicsResetStatus = GetAddress<GetGraphicsResetStatus>("glGetGraphicsResetStatus");
            _GetnCompressedTexImage = GetAddress<GetnCompressedTexImage>("glGetnCompressedTexImage");
            _GetnTexImage = GetAddress<GetnTexImage>("glGetnTexImage");
            GetnUniformdv = GetAddress<GetnUniformdv>("glGetnUniformdv");
            GetnUniformfv = GetAddress<GetnUniformfv>("glGetnUniformfv");
            GetnUniformiv = GetAddress<GetnUniformiv>("glGetnUniformiv");
            GetnUniformuiv = GetAddress<GetnUniformuiv>("glGetnUniformuiv");
            _ReadnPixels = GetAddress<ReadnPixels>("glReadnPixels");
            TextureBarrier = GetAddress<TextureBarrier>("glTextureBarrier");

            bool platformDependend;
            if (IntPtr.Size == 4)
            {
                TransformFeedbackBufferRange_32 = GetAddress<TransformFeedbackBufferRange_32>("glTransformFeedbackBufferRange");
                NamedBufferStorage_32 = GetAddress<NamedBufferStorage_32>("glNamedBufferStorage");
                NamedBufferData_32 = GetAddress<NamedBufferData_32>("glNamedBufferData");
                NamedBufferSubData_32 = GetAddress<NamedBufferSubData_32>("glNamedBufferSubData");
                CopyNamedBufferSubData_32 = GetAddress<CopyNamedBufferSubData_32>("glCopyNamedBufferSubData");
                ClearNamedBufferSubData_32 = GetAddress<ClearNamedBufferSubData_32>("glClearNamedBufferSubData");
                MapNamedBufferRange_32 = GetAddress<MapNamedBufferRange_32>("glMapNamedBufferRange");
                FlushMappedNamedBufferRange_32 = GetAddress<FlushMappedNamedBufferRange_32>("glFlushMappedNamedBufferRange");
                GetNamedBufferSubData_32 = GetAddress<GetNamedBufferSubData_32>("glGetNamedBufferSubData");
                TextureBufferRange_32 = GetAddress<TextureBufferRange_32>("glTextureBufferRange");
                VertexArrayVertexBuffer_32 = GetAddress<VertexArrayVertexBuffer_32>("glVertexArrayVertexBuffer");
                VertexArrayVertexBuffers_32 = GetAddress<VertexArrayVertexBuffers_32>("glVertexArrayVertexBuffers");
                GetQueryBufferObjecti64v_32 = GetAddress<GetQueryBufferObjecti64v_32>("glGetQueryBufferObjecti64v");
                GetQueryBufferObjectiv_32 = GetAddress<GetQueryBufferObjectiv_32>("glGetQueryBufferObjectiv");
                GetQueryBufferObjectui64v_32 = GetAddress<GetQueryBufferObjectui64v_32>("glGetQueryBufferObjectui64v");
                GetQueryBufferObjectuiv_32 = GetAddress<GetQueryBufferObjectuiv_32>("glGetQueryBufferObjectuiv");

                platformDependend = TransformFeedbackBufferRange_32 != null && NamedBufferStorage_32 != null && NamedBufferData_32 != null &&
                    NamedBufferSubData_32 != null && CopyNamedBufferSubData_32 != null && ClearNamedBufferSubData_32 != null &&
                    MapNamedBufferRange_32 != null && FlushMappedNamedBufferRange_32 != null && GetNamedBufferSubData_32 != null &&
                    TextureBufferRange_32 != null && VertexArrayVertexBuffer_32 != null && VertexArrayVertexBuffers_32 != null &&
                    GetQueryBufferObjecti64v_32 != null && GetQueryBufferObjectiv_32 != null && GetQueryBufferObjectui64v_32 != null &&
                    GetQueryBufferObjectuiv_32 != null;
            }
            else
            {
                TransformFeedbackBufferRange_64 = GetAddress<TransformFeedbackBufferRange_64>("glTransformFeedbackBufferRange");
                NamedBufferStorage_64 = GetAddress<NamedBufferStorage_64>("glNamedBufferStorage");
                NamedBufferData_64 = GetAddress<NamedBufferData_64>("glNamedBufferData");
                NamedBufferSubData_64 = GetAddress<NamedBufferSubData_64>("glNamedBufferSubData");
                CopyNamedBufferSubData_64 = GetAddress<CopyNamedBufferSubData_64>("glCopyNamedBufferSubData");
                ClearNamedBufferSubData_64 = GetAddress<ClearNamedBufferSubData_64>("glClearNamedBufferSubData");
                MapNamedBufferRange_64 = GetAddress<MapNamedBufferRange_64>("glMapNamedBufferRange");
                FlushMappedNamedBufferRange_64 = GetAddress<FlushMappedNamedBufferRange_64>("glFlushMappedNamedBufferRange");
                GetNamedBufferSubData_64 = GetAddress<GetNamedBufferSubData_64>("glGetNamedBufferSubData");
                TextureBufferRange_64 = GetAddress<TextureBufferRange_64>("glTextureBufferRange");
                VertexArrayVertexBuffer_64 = GetAddress<VertexArrayVertexBuffer_64>("glVertexArrayVertexBuffer");
                VertexArrayVertexBuffers_64 = GetAddress<VertexArrayVertexBuffers_64>("glVertexArrayVertexBuffers");
                GetQueryBufferObjecti64v_64 = GetAddress<GetQueryBufferObjecti64v_64>("glGetQueryBufferObjecti64v");
                GetQueryBufferObjectiv_64 = GetAddress<GetQueryBufferObjectiv_64>("glGetQueryBufferObjectiv");
                GetQueryBufferObjectui64v_64 = GetAddress<GetQueryBufferObjectui64v_64>("glGetQueryBufferObjectui64v");
                GetQueryBufferObjectuiv_64 = GetAddress<GetQueryBufferObjectuiv_64>("glGetQueryBufferObjectuiv");

                platformDependend = TransformFeedbackBufferRange_64 != null && NamedBufferStorage_64 != null && NamedBufferData_64 != null &&
                    NamedBufferSubData_64 != null && CopyNamedBufferSubData_64 != null && ClearNamedBufferSubData_64 != null &&
                    MapNamedBufferRange_64 != null && FlushMappedNamedBufferRange_64 != null && GetNamedBufferSubData_64 != null &&
                    TextureBufferRange_64 != null && VertexArrayVertexBuffer_64 != null && VertexArrayVertexBuffers_64 != null &&
                    GetQueryBufferObjecti64v_64 != null && GetQueryBufferObjectiv_64 != null && GetQueryBufferObjectui64v_64 != null &&
                    GetQueryBufferObjectuiv_64 != null;
            }

            VERSION_4_5 = VERSION_4_4 && ClipControl != null && _CreateTransformFeedbacks != null && TransformFeedbackBufferBase != null &&
                GetTransformFeedbackiv != null && GetTransformFeedbacki_v != null && GetTransformFeedbacki64_v != null && _CreateBuffers != null &&
                _ClearNamedBufferData != null && MapNamedBuffer != null && UnmapNamedBuffer != null && GetNamedBufferParameteriv != null &&
                GetNamedBufferParameteri64v != null && GetNamedBufferPointerv != null && _CreateFramebuffers != null && NamedFramebufferRenderbuffer != null &&
                NamedFramebufferParameteri != null && NamedFramebufferTexture != null && NamedFramebufferTextureLayer != null &&
                NamedFramebufferDrawBuffers != null && NamedFramebufferReadBuffer != null && InvalidateNamedFramebufferData != null &&
                InvalidateNamedFramebufferSubData != null && ClearNamedFramebufferiv != null && ClearNamedFramebufferuiv != null &&
                ClearNamedFramebufferfv != null && ClearNamedFramebufferfi != null && BlitNamedFramebuffer != null && CheckNamedFramebufferStatus != null &&
                GetNamedFramebufferParameteriv != null && GetNamedFramebufferAttachmentParameteriv != null && _CreateRenderbuffers != null &&
                NamedRenderbufferStorage != null && NamedRenderbufferStorageMultisample != null && GetNamedRenderbufferParameteriv != null &&
                _CreateTextures != null && TextureBuffer != null && TextureStorage1D != null && TextureStorage2D != null && TextureStorage3D != null &&
                TextureStorage2DMultisample != null && TextureStorage3DMultisample != null && _TextureSubImage1D != null && _TextureSubImage2D != null &&
                _TextureSubImage3D != null && _CompressedTextureSubImage1D != null && _CompressedTextureSubImage2D != null &&
                _CompressedTextureSubImage3D != null && CopyTextureSubImage1D != null && CopyTextureSubImage2D != null && CopyTextureSubImage3D != null &&
                TextureParameterfv != null && TextureParameteriv != null && TextureParameterIiv != null &&
                TextureParameterIuiv != null && GenerateTextureMipmap != null && BindTextureUnit != null && _GetTextureImage != null &&
                _GetCompressedTextureImage != null && GetTextureLevelParameterfv != null && GetTextureLevelParameteriv != null &&
                GetTextureParameterfv != null && _GetTextureParameteriv != null && GetTextureParameterIiv != null && GetTextureParameterIuiv != null &&
                _CreateVertexArrays != null && DisableVertexArrayAttrib != null && EnableVertexArrayAttrib != null && VertexArrayElementBuffer != null &&
                VertexArrayAttribBinding != null && VertexArrayAttribFormat != null && VertexArrayAttribIFormat != null && VertexArrayAttribLFormat != null &&
                VertexArrayBindingDivisor != null && GetVertexArrayiv != null && GetVertexArrayIndexediv != null && GetVertexArrayIndexed64iv != null &&
                _CreateSamplers != null && _CreateProgramPipelines != null && _CreateQueries != null && MemoryBarrierByRegion != null && _GetTextureSubImage != null &&
                _GetCompressedTextureSubImage != null && GetGraphicsResetStatus != null && _GetnCompressedTexImage != null && _GetnTexImage != null &&
                GetnUniformdv != null && GetnUniformfv != null && GetnUniformiv != null && GetnUniformuiv != null && _ReadnPixels != null &&
                TextureBarrier != null && platformDependend;
        }
    }
}
