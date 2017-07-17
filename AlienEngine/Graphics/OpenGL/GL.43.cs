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
using System.Text;

namespace AlienEngine.Core.Graphics.OpenGL
{
    using Delegates;

    namespace Delegates
    {
        internal delegate void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, IntPtr data);
        internal delegate void ClearBufferSubData_32(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, IntPtr data);
        internal delegate void ClearBufferSubData_64(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, IntPtr data);

        /// <summary>
        /// Launches one or more compute work groups.
        /// </summary>
        /// <param name="num_groups_x">The number of work groups to be launched in the X dimension.</param>
        /// <param name="num_groups_y">The number of work groups to be launched in the Y dimension.</param>
        /// <param name="num_groups_z">The number of work groups to be launched in the Z dimension.</param>
        [CLSCompliant(false)]
        public delegate void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);

        internal delegate void DispatchComputeIndirect_32(int indirect);
        internal delegate void DispatchComputeIndirect_64(long indirect);

        /// <summary>
        /// Performs a raw data copy between two images.
        /// </summary>
        /// <param name="srcName">The name of a texture or renderbuffer object from which to copy.</param>
        /// <param name="srcTarget">A <see cref="glTextureTarget"/> specifying the namespaces of <paramref name="srcName"/>.</param>
        /// <param name="srcLevel">The level-of-detail to read form the source.</param>
        /// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcY">The Y coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcZ">The Z coordinate of the left edge of the souce region to copy.</param>
        /// <param name="dstName">The name of a texture or renderbuffer object to which to copy.</param>
        /// <param name="dstTarget">A <see cref="glTextureTarget"/> specifying the namespaces of <paramref name="dstName"/>.</param>
        /// <param name="dstLevel">The level-of-detail of the target to write to.</param>
        /// <param name="dstX">The X coordinate of the left edge of the destination region.</param>
        /// <param name="dstY">The Y coordinate of the left edge of the destination region.</param>
        /// <param name="dstZ">The Z coordinate of the left edge of the destination region.</param>
        /// <param name="srcWidth">The width of the region.</param>
        /// <param name="srcHeight">The height of the region.</param>
        /// <param name="srcDepth">The depth of the region.</param>
        [CLSCompliant(false)]
        public delegate void CopyImageSubData(uint srcName, TextureTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, TextureTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth);

        /// <summary>
        /// Sets parameters of framebuffers.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter to set.</param>
        /// <param name="param">The value to set.</param>
        public delegate void FramebufferParameteri(FramebufferTarget target, FramebufferDefaultParameter pname, int param);

        /// <summary>
        /// Returns the parameter of framebuffers.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetFramebufferParameteri(FramebufferTarget target, FramebufferDefaultParameter pname, out int param);

        /// <summary>
        /// Returns the parameter of framebuffers.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="pname">A <see cref="glFramebufferParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetFramebufferParameteriv(FramebufferTarget target, FramebufferDefaultParameter pname, int[] @params);

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target the <paramref name="internalformat"/> is used for.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="pname">A <see cref="glInternalformatParameter"/> specifying the parameter.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetInternalformati64(TextureTarget target, InternalFormat internalformat, InternalFormatParameter pname, int bufSize, out long param);

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target the <paramref name="internalformat"/> is used for.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="pname">A <see cref="glInternalformatParameter"/> specifying the parameter.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetInternalformati64v(TextureTarget target, InternalFormat internalformat, InternalFormatParameter pname, int bufSize, long[] @params);

        /// <summary>
        /// Invalidates parts of texture images.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="xoffset">The X offset of the region to be invalidated.</param>
        /// <param name="yoffset">The Y offset of the region to be invalidated.</param>
        /// <param name="zoffset">The Z offset of the region to be invalidated.</param>
        /// <param name="width">The width of the region.</param>
        /// <param name="height">The height of the region.</param>
        /// <param name="depth">The depth of the region.</param>
        [CLSCompliant(false)]
        public delegate void InvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth);

        /// <summary>
        /// Invalidates an entire texture image.
        /// </summary>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level-of-detail.</param>
        [CLSCompliant(false)]
        public delegate void InvalidateTexImage(uint texture, int level);

        internal delegate void InvalidateBufferSubData_32(uint buffer, int offset, int length);
        internal delegate void InvalidateBufferSubData_64(uint buffer, long offset, long length);

        /// <summary>
        /// Invalidates an entire buffer object's data storage.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void InvalidateBufferData(uint buffer);

        /// <summary>
        /// Invalidates the content of some or all of a framebuffer's attachments.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="numAttachments">The number of attachments in <paramref name="attachments"/>.</param>
        /// <param name="attachments">An array of <see cref="FramebufferAttachment"/>s specifying the attachments.</param>
        public delegate void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, params FramebufferAttachment[] attachments);

        /// <summary>
        /// Invalidates the content of a region of some or all of a framebuffer's attachments.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="numAttachments">The number of attachments in <paramref name="attachments"/>.</param>
        /// <param name="attachments">An array of <see cref="FramebufferAttachment"/>s specifying the attachments.</param>
        /// <param name="x">The X offset of the region to be invalidated.</param>
        /// <param name="y">The Y offset of the region to be invalidated.</param>
        /// <param name="width">The width of the region to be invalidated.</param>
        /// <param name="height">The height of the region to be invalidated.</param>
        public delegate void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, FramebufferAttachment[] attachments, int x, int y, int width, int height);

        /// <summary>
        /// Renders multiple instances of primitives from array, taking parameters from memory.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="indirect">An array of structures containing the draw parameters.</param>
        /// <param name="drawcount">The number of elements in the array of draw parameter structures.</param>
        /// <param name="stride">The distance in bytes between elements of the draw parameter array. (Should be zero, here in .Net)</param>
        public delegate void MultiDrawArraysIndirect(BeginMode mode, DrawArraysIndirectCommand[] indirect, int drawcount, int stride);

        /// <summary>
        /// Renders multiple instances of primitives from array via indices, taking parameters from memory.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="indirect">The structure containing the draw parameters.</param>
        /// <param name="drawcount">The number of elements in the array of draw parameter structures.</param>
        /// <param name="stride">The distance in bytes between elements of the draw parameter array. (Should be zero, here in .Net)</param>
        public delegate void MultiDrawElementsIndirect(BeginMode mode, DrawElementsType type, DrawElementsIndirectCommand[] indirect, int drawcount, int stride);

        /// <summary>
        /// Returns parameters of program interfaces.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="pname">A <see cref="glProgramInterfaceParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetProgramInterfacei(uint program, ProgramInterface programInterface, ProgramInterfaceParameter pname, out int param);

        /// <summary>
        /// Returns parameters of program interfaces.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="pname">A <see cref="glProgramInterfaceParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetProgramInterfaceiv(uint program, ProgramInterface programInterface, ProgramInterfaceParameter pname, int[] @params);

        /// <summary>
        /// Returns the index program resources.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="name">The name of the program resources.</param>
        /// <returns>Tthe index program resource.</returns>
        [CLSCompliant(false)]
        public delegate uint GetProgramResourceIndex(uint program, ProgramInterface programInterface, string name);

        internal delegate void GetProgramResourceName(uint program, ProgramInterface programInterface, uint index, int bufSize, out int length, StringBuilder name);

        /// <summary>
        /// Returns the values of properties of active program resources.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="index">The index of the resource.</param>
        /// <param name="propCount">Must be one.</param>
        /// <param name="prop">A <see cref="glProgramResourceProperty"/> specifying the requested property.</param>
        /// <param name="bufSize">Must be one.</param>
        /// <param name="length">Will be one.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetProgramResourcei(uint program, ProgramInterface programInterface, uint index, int propCount, ref ProgramProperty prop, int bufSize, out int length, out int param);

        /// <summary>
        /// Returns the values of properties of active program resources.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="index">The index of the resource.</param>
        /// <param name="propCount">The number of properties requested.</param>
        /// <param name="props">An array of <see cref="glProgramResourceProperty"/> specifying the requested properties.</param>
        /// <param name="bufSize">The size of the buffer <paramref name="params"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="params"/>.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetProgramResourceiv(uint program, ProgramInterface programInterface, uint index, int propCount, ProgramProperty[] props, int bufSize, out int length, int[] @params);

        /// <summary>
        /// Returns the location of a named resource within a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="name">The name of the resource.</param>
        /// <returns>The location of the named resource within the program.</returns>
        [CLSCompliant(false)]
        public delegate int GetProgramResourceLocation(uint program, ProgramInterface programInterface, string name);

        /// <summary>
        /// Returns the fragment color index of a named variable within a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the program interface.</param>
        /// <param name="name">The name of the variable.</param>
        /// <returns>The fragment color index of the named variable within the program.</returns>
        [CLSCompliant(false)]
        public delegate int GetProgramResourceLocationIndex(uint program, ProgramInterface programInterface, string name);

        /// <summary>
        /// Sets the binding of an active shader storage block.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="storageBlockIndex">The index storage block within the program.</param>
        /// <param name="storageBlockBinding">The index storage block binding to associate with the specified storage block.</param>
        [CLSCompliant(false)]
        public delegate void ShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);

        internal delegate void TexBufferRange_32(BufferTarget target, InternalFormat internalformat, uint buffer, int offset, int size);
        internal delegate void TexBufferRange_64(BufferTarget target, InternalFormat internalformat, uint buffer, long offset, long size);

        /// <summary>
        /// Creates a storage for of a 2D multisample texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="samples">The number of samples in the texture.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public delegate void TexStorage2DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        /// <summary>
        /// Creates a storage for of a 3D multisample texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="samples">The number of samples in the texture.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public delegate void TexStorage3DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, int depth, [MarshalAs(UnmanagedType.I1)] bool fixedsamplelocations);

        /// <summary>
        /// Sets up a view to another texture's data store.
        /// </summary>
        /// <param name="texture">The name of the texture object to be initialized as a view.</param>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target to set up.</param>
        /// <param name="origtexture">The name of the texture object of which to make a view.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying </param>
        /// <param name="minlevel">The minimum level of the texture view.</param>
        /// <param name="numlevels">The number of levels of the texture view.</param>
        /// <param name="minlayer">The minimum layer number of the texture view.</param>
        /// <param name="numlayers">The number of layers of the texture view.</param>
        [CLSCompliant(false)]
        public delegate void TextureView(uint texture, TextureTarget target, uint origtexture, InternalFormat internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);

        internal delegate void BindVertexBuffer_32(uint bindingindex, uint buffer, int offset, int stride);
        internal delegate void BindVertexBuffer_64(uint bindingindex, uint buffer, long offset, int stride);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="normalized">Set <b>true</b> if data is normalized.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribFormat(uint attribindex, int size, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint relativeoffset);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribIFormat(uint attribindex, int size, VertexAttribType type, uint relativeoffset);

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        /// <param name="attribindex">The index of the vertex attribute.</param>
        /// <param name="size">The number of values per vertex that are stored in the array.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the type of the data stored in the array.</param>
        /// <param name="relativeoffset">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribLFormat(uint attribindex, int size, VertexAttribType type, uint relativeoffset);

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// </summary>
        /// <param name="attribindex">The index of the attribute to associate with a vertex buffer binding.</param>
        /// <param name="bindingindex">The index of the vertex buffer binding with which to associate the generic vertex attribute.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribBinding(uint attribindex, uint bindingindex);

        /// <summary>
        /// Sets the rate at which vertex attributes advance.
        /// </summary>
        /// <param name="bindingindex">The index of the binding.</param>
        /// <param name="divisor">The value for the instance step rate.</param>
        [CLSCompliant(false)]
        public delegate void VertexBindingDivisor(uint bindingindex, uint divisor);

        /// <summary>
        /// Controls the reporting of debug messages in a debug context.
        /// </summary>
        /// <param name="source">A <see cref="glDebugSource"/> specifying the message source.</param>
        /// <param name="type">A <see cref="glDebugType"/> specifying the message type.</param>
        /// <param name="severity">A <see cref="glDebugSeverity"/> specifying the severity of the message.</param>
        /// <param name="count">The number of ids in <paramref name="ids"/>.</param>
        /// <param name="ids">The ids of the messages.</param>
        /// <param name="enabled">The state the messages in <paramref name="ids"/> will be set to.</param>
        [CLSCompliant(false)]
        public delegate void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, [MarshalAs(UnmanagedType.I1)] bool enabled);

        /// <summary>
        /// Inserts a message into the debug message queue.
        /// </summary>
        /// <param name="source">A <see cref="glDebugSource"/> specifying the message source.</param>
        /// <param name="type">A <see cref="glDebugType"/> specifying the message type.</param>
        /// <param name="id">The id of the message.</param>
        /// <param name="severity">A <see cref="glDebugSeverity"/> specifying the severity of the message.</param>
        /// <param name="length">The length of the text in <paramref name="message"/>.</param>
        /// <param name="message">The message text.</param>
        [CLSCompliant(false)]
        public delegate void DebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, string message);

        /// <summary>
        /// Callback defintion for functions passed to <see cref="GL.DebugMessageCallback"/>.
        /// </summary>
        /// <param name="source">Gives a <see cref="glDebugSource"/> specifying the message source.</param>
        /// <param name="type">Gives a <see cref="glDebugType"/> specifying the message type.</param>
        /// <param name="id">Gives id of the message.</param>
        /// <param name="severity">Gives a <see cref="glDebugSeverity"/> specifying the severity of the message.</param>
        /// <param name="length">The length of the message.</param>
        /// <param name="message">The pointer to the array countaining the message.</param>
        /// <param name="userParam">The address of a user-supplied object passed to <see cref="GL.DebugMessageCallback"/>.</param>
        /// <remarks>Use <c>Marshal.PtrToStringAnsi(message, length)</c> to get a <b>string</b> of the message.</remarks>
        [CLSCompliant(false)]
        public delegate void DebugProc(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);

        /// <summary>
        /// Sets the callback to receive debugging messages.
        /// </summary>
        /// <param name="callback">A delegate of type <see cref="glDebugProc"/> to the function to call on messages.</param>
        /// <param name="userParam">The address of a user-supplied object that will be passed the the callback each time it is called.</param>
        [CLSCompliant(false)]
        public delegate void DebugMessageCallback(DebugProc callback, IntPtr userParam);

        internal delegate uint GetDebugMessageLog(uint count, int bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, int[] lengths, StringBuilder messageLog);

        /// <summary>
        /// Pushes a named debug group into the command stream.
        /// </summary>
        /// <param name="source">A <see cref="glDebugSource"/> specifying the message source.</param>
        /// <param name="id">The id of the message.</param>
        /// <param name="length">The length of the text in <paramref name="message"/>.</param>
        /// <param name="message">The message text.</param>
        [CLSCompliant(false)]
        public delegate void PushDebugGroup(DebugSource source, uint id, int length, string message);

        /// <summary>
        /// Pops the active debug group.
        /// </summary>
        public delegate void PopDebugGroup();

        /// <summary>
        /// Labels named objects identified within a namespace.
        /// </summary>
        /// <param name="identifier">A <see cref="glObjectNamespaceIdentifier"/> specifying the namesapce.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="length">The length of the <paramref name="label"/>.</param>
        /// <param name="label">The label.</param>
        [CLSCompliant(false)]
        public delegate void ObjectLabel(ObjectLabelIdentifier identifier, uint name, int length, string label);

        internal delegate void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, out int length, StringBuilder label);

        /// <summary>
        /// Labels objects identified by a handle (like sync objects).
        /// </summary>
        /// <param name="ptr">Handle to the object.</param>
        /// <param name="length">The length of the <paramref name="label"/>.</param>
        /// <param name="label">The label.</param>
        public delegate void ObjectPtrLabel(IntPtr ptr, int length, string label);

        internal delegate void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, StringBuilder label);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 4.3 is available.
        /// </summary>
        public static bool VERSION_4_3;

        #region Delegates
        private static ClearBufferData _ClearBufferData;
        private static ClearBufferSubData_32 ClearBufferSubData_32;
        private static ClearBufferSubData_64 ClearBufferSubData_64;

        /// <summary>
        /// Launches one or more compute work groups.
        /// </summary>
        [CLSCompliant(false)]
        public static DispatchCompute DispatchCompute;

        private static DispatchComputeIndirect_32 DispatchComputeIndirect_32;
        private static DispatchComputeIndirect_64 DispatchComputeIndirect_64;

        /// <summary>
        /// Performs a raw data copy between two images.
        /// </summary>
        [CLSCompliant(false)]
        public static CopyImageSubData CopyImageSubData;

        /// <summary>
        /// Sets parameters of framebuffers.
        /// </summary>
        public static FramebufferParameteri FramebufferParameteri;

        /// <summary>
        /// Returns the parameter of framebuffers.
        /// </summary>
        public static GetFramebufferParameteri GetFramebufferParameteri;

        /// <summary>
        /// Returns the parameter of framebuffers.
        /// </summary>
        public static GetFramebufferParameteriv GetFramebufferParameteriv;

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        public static GetInternalformati64 GetInternalformati64;

        /// <summary>
        /// Returns parameters of internal formats.
        /// </summary>
        public static GetInternalformati64v GetInternalformati64v;

        /// <summary>
        /// Invalidates parts of texture images.
        /// </summary>
        [CLSCompliant(false)]
        public static InvalidateTexSubImage InvalidateTexSubImage;

        /// <summary>
        /// Invalidates an entire texture image.
        /// </summary>
        [CLSCompliant(false)]
        public static InvalidateTexImage InvalidateTexImage;

        private static InvalidateBufferSubData_32 InvalidateBufferSubData_32;
        private static InvalidateBufferSubData_64 InvalidateBufferSubData_64;

        /// <summary>
        /// Invalidates an entire buffer object's data storage.
        /// </summary>
        [CLSCompliant(false)]
        public static InvalidateBufferData InvalidateBufferData;

        /// <summary>
        /// Invalidates the content of some or all of a framebuffer's attachments.
        /// </summary>
        public static InvalidateFramebuffer InvalidateFramebuffer;

        /// <summary>
        /// Invalidates the content of a region of some or all of a framebuffer's attachments.
        /// </summary>
        public static InvalidateSubFramebuffer InvalidateSubFramebuffer;

        /// <summary>
        /// Renders multiple instances of primitives from array, taking parameters from memory.
        /// </summary>
        public static MultiDrawArraysIndirect MultiDrawArraysIndirect;

        /// <summary>
        /// Renders multiple instances of primitives from array via indices, taking parameters from memory.
        /// </summary>
        public static MultiDrawElementsIndirect MultiDrawElementsIndirect;

        /// <summary>
        /// Returns parameters of program interfaces.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramInterfacei GetProgramInterfacei;

        /// <summary>
        /// Returns parameters of program interfaces.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramInterfaceiv GetProgramInterfaceiv;

        /// <summary>
        /// Returns the index program resources.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramResourceIndex GetProgramResourceIndex;

        private static GetProgramResourceName _GetProgramResourceName;

        /// <summary>
        /// Returns the values of properties of active program resources.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramResourcei GetProgramResourcei;

        /// <summary>
        /// Returns the values of properties of active program resources.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramResourceiv GetProgramResourceiv;

        /// <summary>
        /// Returns the location of a named resource within a program.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramResourceLocation GetProgramResourceLocation;

        /// <summary>
        /// Returns the fragment color index of a named variable within a program.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramResourceLocationIndex GetProgramResourceLocationIndex;

        /// <summary>
        /// Sets the binding of an active shader storage block.
        /// </summary>
        [CLSCompliant(false)]
        public static ShaderStorageBlockBinding ShaderStorageBlockBinding;

        private static TexBufferRange_32 TexBufferRange_32;
        private static TexBufferRange_64 TexBufferRange_64;

        /// <summary>
        /// Creates a storage for of a 2D multisample texture.
        /// </summary>
        public static TexStorage2DMultisample TexStorage2DMultisample;

        /// <summary>
        /// Creates a storage for of a 3D multisample texture.
        /// </summary>
        public static TexStorage3DMultisample TexStorage3DMultisample;

        /// <summary>
        /// Sets up a view to another texture's data store.
        /// </summary>
        [CLSCompliant(false)]
        public static TextureView TextureView;

        private static BindVertexBuffer_32 BindVertexBuffer_32;
        private static BindVertexBuffer_64 BindVertexBuffer_64;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribFormat VertexAttribFormat;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribIFormat VertexAttribIFormat;

        /// <summary>
        /// Sets the organization of vertex arrays.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribLFormat VertexAttribLFormat;

        /// <summary>
        /// Associate a vertex attribute and a vertex buffer binding for a vertex array object.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribBinding VertexAttribBinding;

        /// <summary>
        /// Sets the rate at which vertex attributes advance.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexBindingDivisor VertexBindingDivisor;

        /// <summary>
        /// Controls the reporting of debug messages in a debug context.
        /// </summary>
        [CLSCompliant(false)]
        public static DebugMessageControl DebugMessageControl;

        /// <summary>
        /// Inserts a message into the debug message queue.
        /// </summary>
        [CLSCompliant(false)]
        public static DebugMessageInsert DebugMessageInsert;

        /// <summary>
        /// Sets the callback to receive debugging messages.
        /// </summary>
        [CLSCompliant(false)]
        public static DebugMessageCallback DebugMessageCallback;

        private static GetDebugMessageLog _GetDebugMessageLog;

        /// <summary>
        /// Pushes a named debug group into the command stream.
        /// </summary>
        [CLSCompliant(false)]
        public static PushDebugGroup PushDebugGroup;

        /// <summary>
        /// Pops the active debug group.
        /// </summary>
        public static PopDebugGroup PopDebugGroup;

        /// <summary>
        /// Labels named objects identified within a namespace.
        /// </summary>
        [CLSCompliant(false)]
        public static ObjectLabel ObjectLabel;

        private static GetObjectLabel _GetObjectLabel;

        /// <summary>
        /// Labels objects identified by a handle (like sync objects).
        /// </summary>
        public static ObjectPtrLabel ObjectPtrLabel;

        private static GetObjectPtrLabel _GetObjectPtrLabel;
        #endregion

        #region Overloads
        #region ClearBufferData
        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, IntPtr data)
        {
            _ClearBufferData(target, internalformat, format, type, data);
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferData(BufferTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _ClearBufferData(target, internalformat, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region ClearBufferSubData
        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, IntPtr data)
        {
            if (IntPtr.Size == 4) ClearBufferSubData_32(target, internalformat, offset, size, format, type, data);
            else ClearBufferSubData_64(target, internalformat, offset, size, format, type, data);
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                ClearBufferSubData_32(target, internalformat, (int)offset, (int)size, format, type, data);
            }
            else ClearBufferSubData_64(target, internalformat, offset, size, format, type, data);
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, byte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, sbyte[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, short[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, ushort[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, int[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, uint[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, long[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        [CLSCompliant(false)]
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, ulong[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, float[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, int offset, int size, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }

        /// <summary>
        /// Fills all or parts a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The size of the region.</param>
        /// <param name="format">A <see cref="glPixelFormat"/> specifying the pixel format used in <paramref name="data"/>.</param>
        /// <param name="type">A <see cref="glPixelDataType"/> specifying the pixel data type used in <paramref name="data"/>.</param>
        /// <param name="data">The 'fixed' value.</param>
        public static void ClearBufferSubData(BufferTarget target, InternalFormat internalformat, long offset, long size, PixelFormat format, PixelType type, double[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                ClearBufferSubData(target, internalformat, offset, size, format, type, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region DispatchComputeIndirect
        /// <summary>
        /// Launches one or more compute work groups using parameters stored in a buffer.
        /// </summary>
        /// <param name="indirect">The offset into the buffer object currently bound to the <see cref="BufferTarget.DISPATCH_INDIRECT_BUFFER"/> buffer target at which the dispatch parameters are stored.</param>
        public static void DispatchComputeIndirect(int indirect)
        {
            if (IntPtr.Size == 4) DispatchComputeIndirect_32(indirect);
            else DispatchComputeIndirect_64(indirect);
        }

        /// <summary>
        /// Launches one or more compute work groups using parameters stored in a buffer.
        /// </summary>
        /// <param name="indirect">The offset into the buffer object currently bound to the <see cref="BufferTarget.DISPATCH_INDIRECT_BUFFER"/> buffer target at which the dispatch parameters are stored.</param>
        public static void DispatchComputeIndirect(long indirect)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)indirect >> 32) != 0) throw new ArgumentOutOfRangeException("indirect", PlatformErrorString);
                DispatchComputeIndirect_32((int)indirect);
            }
            else DispatchComputeIndirect_64(indirect);
        }
        #endregion

        #region InvalidateBufferSubData
        /// <summary>
        /// Invalidates parts of a buffer object's data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="length">The length of the region.</param>
        [CLSCompliant(false)]
        public static void InvalidateBufferSubData(uint buffer, int offset, int length)
        {
            if (IntPtr.Size == 4) InvalidateBufferSubData_32(buffer, offset, length);
            else InvalidateBufferSubData_64(buffer, offset, length);
        }

        /// <summary>
        /// Invalidates parts of a buffer object's data store.
        /// </summary>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="length">The length of the region.</param>
        [CLSCompliant(false)]
        public static void InvalidateBufferSubData(uint buffer, long offset, long length)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)length >> 32) != 0) throw new ArgumentOutOfRangeException("length", PlatformErrorString);
                InvalidateBufferSubData_32(buffer, (int)offset, (int)length);
            }
            else InvalidateBufferSubData_64(buffer, offset, length);
        }
        #endregion

        #region GetProgramResourceName
        /// <summary>
        /// Returns the names of program reources.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="programInterface">A <see cref="glProgramInterface"/> specifying the type of the resource.</param>
        /// <param name="index">The index of the resource.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="name">The name of the program resource.</param>
        [CLSCompliant(false)]
        public static void GetProgramResourceName(uint program, ProgramInterface programInterface, uint index, int bufSize, out int length, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetProgramResourceName(program, programInterface, index, bufSize + 1, out length, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region TexBufferRange
        /// <summary>
        /// Attaches a range of a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="target">Must by <see cref="glTexBufferTarget.TEXTURE_BUFFER"/>.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The length of the region.</param>
        [CLSCompliant(false)]
        public static void TexBufferRange(BufferTarget target, InternalFormat internalformat, uint buffer, int offset, int size)
        {
            if (IntPtr.Size == 4) TexBufferRange_32(target, internalformat, buffer, offset, size);
            else TexBufferRange_64(target, internalformat, buffer, offset, size);
        }

        /// <summary>
        /// Attaches a range of a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="target">Must by <see cref="glTexBufferTarget.TEXTURE_BUFFER"/>.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset into the data store.</param>
        /// <param name="size">The length of the region.</param>
        [CLSCompliant(false)]
        public static void TexBufferRange(BufferTarget target, InternalFormat internalformat, uint buffer, long offset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                TexBufferRange_32(target, internalformat, buffer, (int)offset, (int)size);
            }
            else TexBufferRange_64(target, internalformat, buffer, offset, size);
        }
        #endregion

        #region BindVertexBuffer
        /// <summary>
        /// Binds a buffer to a vertex buffer binding point.
        /// </summary>
        /// <param name="bindingindex">The index of the vertex buffer binding point to which to bind the buffer.</param>
        /// <param name="buffer">The name of a buffer.</param>
        /// <param name="offset">The offset of the first element of the buffer.</param>
        /// <param name="stride">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public static void BindVertexBuffer(uint bindingindex, uint buffer, int offset, int stride)
        {
            if (IntPtr.Size == 4) BindVertexBuffer_32(bindingindex, buffer, offset, stride);
            else BindVertexBuffer_64(bindingindex, buffer, offset, stride);
        }

        /// <summary>
        /// Binds a buffer to a vertex buffer binding point.
        /// </summary>
        /// <param name="bindingindex">The index of the vertex buffer binding point to which to bind the buffer.</param>
        /// <param name="buffer">The name of a buffer.</param>
        /// <param name="offset">The offset of the first element of the buffer.</param>
        /// <param name="stride">The distance between elements within the buffer.</param>
        [CLSCompliant(false)]
        public static void BindVertexBuffer(uint bindingindex, uint buffer, long offset, int stride)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                BindVertexBuffer_32(bindingindex, buffer, (int)offset, stride);
            }
            else BindVertexBuffer_64(bindingindex, buffer, offset, stride);
        }
        #endregion

        #region GetDebugMessageLog
        /// <summary>
        /// Returns the debug message log.
        /// </summary>
        /// <param name="count">The (maximum) number of messages to return.</param>
        /// <param name="bufSize">The size of the buffer used to retrive <paramref name="messageLog"/>.</param>
        /// <param name="sources">Returns the message sources as array of <see cref="glDebugSource"/>.</param>
        /// <param name="types">Returns the message types as array of <see cref="glDebugType"/>.</param>
        /// <param name="ids">Returns the ids of the messages.</param>
        /// <param name="severities">Returns the severities of the messages as array of <see cref="glDebugSeverity"/>.</param>
        /// <param name="lengths">Returns the lengths of the string written to <paramref name="messageLog"/>.</param>
        /// <param name="messageLog">Returns the message log.</param>
        [CLSCompliant(false)]
        public static void GetDebugMessageLog(uint count, int bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, int[] lengths, out string messageLog)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetDebugMessageLog(count, bufSize + 1, sources, types, ids, severities, lengths, tmp);
            messageLog = tmp.ToString();
        }
        #endregion

        #region GetObjectLabel
        /// <summary>
        /// Returns the label of named objects.
        /// </summary>
        /// <param name="identifier">A <see cref="glObjectNamespaceIdentifier"/> specifying the namesapce.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="bufSize">The size of the buffer used to retrive <paramref name="label"/>.</param>
        /// <param name="length">Returns the actual length of the data written to <paramref name="label"/>.</param>
        /// <param name="label">Returns the label.</param>
        [CLSCompliant(false)]
        public static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, out int length, out string label)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetObjectLabel(identifier, name, bufSize + 1, out length, tmp);
            label = tmp.ToString();
        }
        #endregion

        #region GetObjectPtrLabel
        /// <summary>
        /// Returns the label of objects identified by a handle (like sync objects).
        /// </summary>
        /// <param name="ptr">The handle to the object.</param>
        /// <param name="bufSize">The size of the buffer used to retrive <paramref name="label"/>.</param>
        /// <param name="length">Returns the actual length of the data written to <paramref name="label"/>.</param>
        /// <param name="label">Returns the label.</param>
        public static void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, out string label)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetObjectPtrLabel(ptr, bufSize + 1, out length, tmp);
            label = tmp.ToString();
        }
        #endregion

        #region GetUniformIndex
        /// <summary>
        /// Returns the index of a named uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="uniformName">The name of the uniform variable.</param>
        /// <returns>The index of the named uniform variable.</returns>
        [CLSCompliant(false)]
        public static uint GetUniformIndex(uint program, string uniformName)
        {
            if (GetProgramResourceIndex != null) return GetProgramResourceIndex(program, ProgramInterface.Uniform, uniformName);

            uint[] ret = new uint[1];
            GetUniformIndices(program, 1, new string[] { uniformName }, ret);
            return ret[0];
        }
        #endregion
        #endregion

        private static void Load_VERSION_4_3()
        {
            _ClearBufferData = GetAddress<ClearBufferData>("glClearBufferData");
            DispatchCompute = GetAddress<DispatchCompute>("glDispatchCompute");
            CopyImageSubData = GetAddress<CopyImageSubData>("glCopyImageSubData");
            FramebufferParameteri = GetAddress<FramebufferParameteri>("glFramebufferParameteri");
            GetFramebufferParameteri = GetAddress<GetFramebufferParameteri>("glGetFramebufferParameteriv");
            GetFramebufferParameteriv = GetAddress<GetFramebufferParameteriv>("glGetFramebufferParameteriv");
            GetInternalformati64 = GetAddress<GetInternalformati64>("glGetInternalformati64v");
            GetInternalformati64v = GetAddress<GetInternalformati64v>("glGetInternalformati64v");
            InvalidateTexSubImage = GetAddress<InvalidateTexSubImage>("glInvalidateTexSubImage");
            InvalidateTexImage = GetAddress<InvalidateTexImage>("glInvalidateTexImage");
            InvalidateBufferData = GetAddress<InvalidateBufferData>("glInvalidateBufferData");
            InvalidateFramebuffer = GetAddress<InvalidateFramebuffer>("glInvalidateFramebuffer");
            InvalidateSubFramebuffer = GetAddress<InvalidateSubFramebuffer>("glInvalidateSubFramebuffer");
            MultiDrawArraysIndirect = GetAddress<MultiDrawArraysIndirect>("glMultiDrawArraysIndirect");
            MultiDrawElementsIndirect = GetAddress<MultiDrawElementsIndirect>("glMultiDrawElementsIndirect");
            GetProgramInterfacei = GetAddress<GetProgramInterfacei>("glGetProgramInterfaceiv");
            GetProgramInterfaceiv = GetAddress<GetProgramInterfaceiv>("glGetProgramInterfaceiv");
            GetProgramResourceIndex = GetAddress<GetProgramResourceIndex>("glGetProgramResourceIndex");
            _GetProgramResourceName = GetAddress<GetProgramResourceName>("glGetProgramResourceName");
            GetProgramResourcei = GetAddress<GetProgramResourcei>("glGetProgramResourceiv");
            GetProgramResourceiv = GetAddress<GetProgramResourceiv>("glGetProgramResourceiv");
            GetProgramResourceLocation = GetAddress<GetProgramResourceLocation>("glGetProgramResourceLocation");
            GetProgramResourceLocationIndex = GetAddress<GetProgramResourceLocationIndex>("glGetProgramResourceLocationIndex");
            ShaderStorageBlockBinding = GetAddress<ShaderStorageBlockBinding>("glShaderStorageBlockBinding");
            TexStorage2DMultisample = GetAddress<TexStorage2DMultisample>("glTexStorage2DMultisample");
            TexStorage3DMultisample = GetAddress<TexStorage3DMultisample>("glTexStorage3DMultisample");
            TextureView = GetAddress<TextureView>("glTextureView");
            VertexAttribFormat = GetAddress<VertexAttribFormat>("glVertexAttribFormat");
            VertexAttribIFormat = GetAddress<VertexAttribIFormat>("glVertexAttribIFormat");
            VertexAttribLFormat = GetAddress<VertexAttribLFormat>("glVertexAttribLFormat");
            VertexAttribBinding = GetAddress<VertexAttribBinding>("glVertexAttribBinding");
            VertexBindingDivisor = GetAddress<VertexBindingDivisor>("glVertexBindingDivisor");
            DebugMessageControl = GetAddress<DebugMessageControl>("glDebugMessageControl");
            DebugMessageInsert = GetAddress<DebugMessageInsert>("glDebugMessageInsert");
            DebugMessageCallback = GetAddress<DebugMessageCallback>("glDebugMessageCallback");
            _GetDebugMessageLog = GetAddress<GetDebugMessageLog>("glGetDebugMessageLog");
            PushDebugGroup = GetAddress<PushDebugGroup>("glPushDebugGroup");
            PopDebugGroup = GetAddress<PopDebugGroup>("glPopDebugGroup");
            ObjectLabel = GetAddress<ObjectLabel>("glObjectLabel");
            _GetObjectLabel = GetAddress<GetObjectLabel>("glGetObjectLabel");
            ObjectPtrLabel = GetAddress<ObjectPtrLabel>("glObjectPtrLabel");
            _GetObjectPtrLabel = GetAddress<GetObjectPtrLabel>("glGetObjectPtrLabel");

            bool platformDependend;
            if (IntPtr.Size == 4)
            {
                ClearBufferSubData_32 = GetAddress<ClearBufferSubData_32>("glClearBufferSubData");
                DispatchComputeIndirect_32 = GetAddress<DispatchComputeIndirect_32>("glDispatchComputeIndirect");
                InvalidateBufferSubData_32 = GetAddress<InvalidateBufferSubData_32>("glInvalidateBufferSubData");
                TexBufferRange_32 = GetAddress<TexBufferRange_32>("glTexBufferRange");
                BindVertexBuffer_32 = GetAddress<BindVertexBuffer_32>("glBindVertexBuffer");

                platformDependend = ClearBufferSubData_32 != null && DispatchComputeIndirect_32 != null &&
                    InvalidateBufferSubData_32 != null && TexBufferRange_32 != null && BindVertexBuffer_32 != null;
            }
            else
            {
                ClearBufferSubData_64 = GetAddress<ClearBufferSubData_64>("glClearBufferSubData");
                DispatchComputeIndirect_64 = GetAddress<DispatchComputeIndirect_64>("glDispatchComputeIndirect");
                InvalidateBufferSubData_64 = GetAddress<InvalidateBufferSubData_64>("glInvalidateBufferSubData");
                TexBufferRange_64 = GetAddress<TexBufferRange_64>("glTexBufferRange");
                BindVertexBuffer_64 = GetAddress<BindVertexBuffer_64>("glBindVertexBuffer");

                platformDependend = ClearBufferSubData_64 != null && DispatchComputeIndirect_64 != null &&
                    InvalidateBufferSubData_64 != null && TexBufferRange_64 != null && BindVertexBuffer_64 != null;
            }

            VERSION_4_3 = VERSION_4_2 && _ClearBufferData != null && DispatchCompute != null && CopyImageSubData != null &&
                FramebufferParameteri != null && GetFramebufferParameteriv != null && GetInternalformati64v != null &&
                InvalidateTexSubImage != null && InvalidateTexImage != null && InvalidateBufferData != null &&
                InvalidateFramebuffer != null && InvalidateSubFramebuffer != null && MultiDrawArraysIndirect != null &&
                MultiDrawElementsIndirect != null && GetProgramInterfaceiv != null && GetProgramResourceIndex != null &&
                _GetProgramResourceName != null && GetProgramResourceiv != null && GetProgramResourceLocation != null &&
                GetProgramResourceLocationIndex != null && ShaderStorageBlockBinding != null && TexStorage2DMultisample != null &&
                TexStorage3DMultisample != null && TextureView != null && VertexAttribFormat != null && VertexAttribIFormat != null &&
                VertexAttribLFormat != null && VertexAttribBinding != null && VertexBindingDivisor != null &&
                DebugMessageControl != null && DebugMessageInsert != null && DebugMessageCallback != null &&
                _GetDebugMessageLog != null && PushDebugGroup != null && PopDebugGroup != null && ObjectLabel != null &&
                _GetObjectLabel != null && ObjectPtrLabel != null && _GetObjectPtrLabel != null && platformDependend;
        }
    }
}
