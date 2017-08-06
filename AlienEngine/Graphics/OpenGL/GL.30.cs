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
        /// <summary>
        /// Sets the color mask for color write operations for a specific draw buffer.
        /// </summary>
        /// <param name="index">The index of the draw buffer.</param>
        /// <param name="red">Wether or not the write the red components.</param>
        /// <param name="green">Wether or not the write the green components.</param>
        /// <param name="blue">Wether or not the write the blue components.</param>
        /// <param name="alpha">Wether or not the write the alpha components.</param>
        [CLSCompliant(false)]
        public delegate void ColorMaski(uint index, [MarshalAs(UnmanagedType.I1)] bool red, [MarshalAs(UnmanagedType.I1)] bool green, [MarshalAs(UnmanagedType.I1)] bool blue, [MarshalAs(UnmanagedType.I1)] bool alpha);

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetIndexedPName"/> specifying the parameter.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="data">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetBooleani_(GetIndexedPName target, uint index, [MarshalAs(UnmanagedType.I1)] out bool data);

        internal delegate void GetBooleani_v(GetIndexedPName target, uint index, IntPtr data); // bool[]

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetIndexedPName"/> specifying the parameter.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="data">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetIntegeri_(GetIndexedPName target, uint index, out int data);

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetIndexedPName"/> specifying the parameter.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="data">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetIntegeri_v(GetIndexedPName target, uint index, int[] data);

        /// <summary>
        /// Enables indexed OpenGL capabilities.
        /// </summary>
        /// <param name="target">The capability to be enabled.</param>
        /// <param name="index">The index of the indexed capability.</param>
        [CLSCompliant(false)]
        public delegate void Enablei(IndexedEnableCap target, uint index);

        /// <summary>
        /// Disables indexed OpenGL capabilities.
        /// </summary>
        /// <param name="target">The capability to be enabled.</param>
        /// <param name="index">The index of the indexed capability.</param>
        [CLSCompliant(false)]
        public delegate void Disablei(IndexedEnableCap target, uint index);

        /// <summary>
        /// Checks wether or not a indexed OpenGL capability is enabled.
        /// </summary>
        /// <param name="target">The capability to be enabled.</param>
        /// <param name="index">The index of the indexed capability.</param>
        /// <returns><b>true</b> if the indexed capability is enabled.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsEnabledi(IndexedEnableCap target, uint index);

        /// <summary>
        /// Starts transform feedback operation.
        /// </summary>
        /// <param name="primitiveMode">A <see cref="TransformFeedbackPrimitiveType"/> specifying the output type of the primitives.</param>
        public delegate void BeginTransformFeedback(TransformFeedbackPrimitiveType primitiveMode);

        /// <summary>
        /// Stops transform feedback operation.
        /// </summary>
        public delegate void EndTransformFeedback();

        internal delegate void BindBufferRange_32(BufferTarget target, uint index, uint buffer, int offset, int size);
        internal delegate void BindBufferRange_64(BufferTarget target, uint index, uint buffer, long offset, long size);

        /// <summary>
        /// Binds buffer objects to indexed buffer target.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer.</param>
        /// <param name="index">The index of the indexed buffer target.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void BindBufferBase(BufferTarget target, uint index, uint buffer);

        /// <summary>
        /// Sets values to record in transform feedback buffers.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="count">The number of varying variables.</param>
        /// <param name="varyings">The name(s) of the varying variable(s).</param>
        /// <param name="bufferMode">A <see cref="TransformFeedbackMode"/> specifying the transform feedback buffer mode.</param>
        [CLSCompliant(false)]
        public delegate void TransformFeedbackVaryings(uint program, int count, string[] varyings, TransformFeedbackMode bufferMode);

        internal delegate void GetTransformFeedbackVarying(uint program, uint index, int bufSize, out int length, out int size, out TransformFeedbackType type, StringBuilder name);

        /// <summary>
        /// Sets read color clamping states.
        /// </summary>
        /// <param name="target">Must be <see cref="ClampColorTarget.CLAMP_READ_COLOR"/>.</param>
        /// <param name="clamp">One of <see cref="ClampColorMode"/>.</param>
        public delegate void ClampColor(ClampColorTarget target, ClampColorMode clamp);

        /// <summary>
        /// Starts conditional rendering.
        /// </summary>
        /// <param name="id">Specifies the name of an occlusion query object whose results are used to determine if the rendering commands are discarded.</param>
        /// <param name="mode">A <see cref="ConditionalRenderType"/> specifying how <b>GL.BeginConditionalRender</b> interprets the results of the occlusion query.</param>
        [CLSCompliant(false)]
        public delegate void BeginConditionalRender(uint id, ConditionalRenderType mode);

        /// <summary>
        /// Stops conditional rendering.
        /// </summary>
        public delegate void EndConditionalRender();

        internal delegate void VertexAttribIPointer_32(uint index, int size, VertexAttribPointerType type, int stride, int pointer);
        internal delegate void VertexAttribIPointer_64(uint index, int size, VertexAttribPointerType type, int stride, long pointer);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribIi(uint index, VertexAttribParameter pname, out int param);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribIiv(uint index, VertexAttribParameter pname, int[] @params);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribIui(uint index, VertexAttribParameter pname, out uint param);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribIuiv(uint index, VertexAttribParameter pname, uint[] @params);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI1i(uint index, int x);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI2i(uint index, int x, int y);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI3i(uint index, int x, int y, int z);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4i(uint index, int x, int y, int z, int w);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI1ui(uint index, uint x);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI2ui(uint index, uint x, uint y);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI3ui(uint index, uint x, uint y, uint z);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI1iv(uint index, int[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI2iv(uint index, int[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI3iv(uint index, int[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4iv(uint index, int[] v);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI1uiv(uint index, uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI2uiv(uint index, uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI3uiv(uint index, uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4uiv(uint index, uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4bv(uint index, params sbyte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4sv(uint index, params short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4ubv(uint index, params byte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribI4usv(uint index, params ushort[] v);

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="param">The value of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformui(uint program, int location, out uint param);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformuiv(uint program, int location, uint[] @params);

        /// <summary>
        /// Binds a varing output variable to fragment shader color.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="color">The index of the color output.</param>
        /// <param name="name">The name of the varing output variable.</param>
        [CLSCompliant(false)]
        public delegate void BindFragDataLocation(uint program, uint color, string name);

        /// <summary>
        /// Returns the fragment shader color index of a bound varing output variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="name">The name of the varing output variable.</param>
        /// <returns>The color index of the bound varing output variable.</returns>
        [CLSCompliant(false)]
        public delegate int GetFragDataLocation(uint program, string name);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform1ui(int location, uint v0);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform2ui(int location, uint v0, uint v1);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Third value of a tuple to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform3ui(int location, uint v0, uint v1, uint v2);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Third value of a tuple to set.</param>
        /// <param name="v3">Fourth value of a tuple to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform1uiv(int location, int count, uint[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform2uiv(int location, int count, uint[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform3uiv(int location, int count, uint[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        [CLSCompliant(false)]
        public delegate void Uniform4uiv(int location, int count, uint[] value);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TexParameterIiv(TextureTarget target, TextureParameterName pname, params int[] @params);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void TexParameterIuiv(TextureTarget target, TextureParameterName pname, params uint[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTexParameterIi(TextureTarget target, TextureParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTexParameterIiv(TextureTarget target, TextureParameterName pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetTexParameterIui(TextureTarget target, TextureParameterName pname, out uint param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetTexParameterIuiv(TextureTarget target, TextureParameterName pname, uint[] @params);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="buffer">A <see cref="ClearBuffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="ClearBuffer.Color"/></param>
        /// <param name="value">The value to be set.</param>
        [CLSCompliant(false)]
        public delegate void ClearBufferiv(ClearBuffer buffer, int drawbuffer, params int[] value);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="buffer">A <see cref="ClearBuffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="ClearBuffer.Color"/></param>
        /// <param name="value">The value to be set.</param>
        [CLSCompliant(false)]
        public delegate void ClearBufferuiv(ClearBuffer buffer, int drawbuffer, params uint[] value);

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        /// <param name="buffer">A <see cref="ClearBuffer"/> specifying the buffer to be cleared.</param>
        /// <param name="drawbuffer">The index of the color buffer if <paramref name="buffer"/> is <see cref="ClearBuffer.Color"/></param>
        /// <param name="value">The value to be set.</param>
        public delegate void ClearBufferfv(ClearBuffer buffer, int drawbuffer, params float[] value);

        /// <summary>
        /// Clears/Resets the values of the depth-stencil-buffer to a specific value.
        /// </summary>
        /// <param name="buffer">Must be <see cref="ClearBufferCombined.DepthStencil"/>.</param>
        /// <param name="drawbuffer">Must be zero.</param>
        /// <param name="depth">The depth value to set.</param>
        /// <param name="stencil">The stencil value to set.</param>
        public delegate void ClearBufferfi(ClearBufferCombined buffer, int drawbuffer, float depth, int stencil);

        internal delegate IntPtr GetStringi(StringNameIndexed name, uint index);

        /// <summary>
        /// Determines if a name is a renderbuffer name.
        /// </summary>
        /// <param name="renderbuffer">The maybe renderbuffer name.</param>
        /// <returns><b>true</b> if <paramref name="renderbuffer"/> is a renderbuffer name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsRenderbuffer(uint renderbuffer);

        /// <summary>
        /// Binds a renderbuffer.
        /// </summary>
        /// <param name="target">Must be <see cref="glRenderbufferTarget.RENDERBUFFER"/>.</param>
        /// <param name="renderbuffer">The name of the renderbuffer to be bound.</param>
        [CLSCompliant(false)]
        public delegate void BindRenderbuffer(RenderbufferTarget target, uint renderbuffer);

        /// <summary>
        /// Releases <paramref name="count"/> many renderbuffer names.
        /// </summary>
        /// <param name="count">Number of renderbuffer names to be released.</param>
        /// <param name="renderbuffers">Array of renderbuffer names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteRenderbuffers(int count, params uint[] renderbuffers);

        internal delegate void GenRenderbuffer(int one, out uint renderbuffer);
        internal delegate void GenRenderbuffers(int count, uint[] renderbuffers);

        /// <summary>
        /// Creates a renderbuffer storage for the currently bound renderbuffer object.
        /// </summary>
        /// <param name="target">Must be <see cref="glRenderbufferTarget.RENDERBUFFER"/>.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format of the storage.</param>
        /// <param name="width">The width of the storage in pixels.</param>
        /// <param name="height">The height of the storage in pixels.</param>
        public delegate void RenderbufferStorage(RenderbufferTarget target, PixelInternalFormat internalformat, int width, int height);

        /// <summary>
        /// Returns the value of a renderbuffer parameter.
        /// </summary>
        /// <param name="target">Must be <see cref="RenderbufferTarget.Renderbuffer"/>.</param>
        /// <param name="pname">A <see cref="RenderbufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns requested the value.</param>
        public delegate void GetRenderbufferParameteri(RenderbufferTarget target, RenderbufferParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a renderbuffer parameter.
        /// </summary>
        /// <param name="target">Must be <see cref="glRenderbufferTarget.RENDERBUFFER"/>.</param>
        /// <param name="pname">A <see cref="RenderbufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns requested the value(s).</param>
        public delegate void GetRenderbufferParameteriv(RenderbufferTarget target, RenderbufferParameterName pname, int[] @params);

        /// <summary>
        /// Determines if a name is a framebuffer name.
        /// </summary>
        /// <param name="framebuffer">The maybe framebuffer name.</param>
        /// <returns><b>true</b> if <paramref name="framebuffer"/> is a framebuffer name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsFramebuffer(uint framebuffer);

        /// <summary>
        /// Binds a framebuffer to a framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="framebuffer">The name of the framebuffer to be bound.</param>
        [CLSCompliant(false)]
        public delegate void BindFramebuffer(FramebufferTarget target, uint framebuffer);

        /// <summary>
        /// Releases <paramref name="count"/> many framebuffer names.
        /// </summary>
        /// <param name="count">Number of framebuffer names to be released.</param>
        /// <param name="framebuffers">Array of framebuffer names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteFramebuffers(int count, params uint[] framebuffers);

        internal delegate void GenFramebuffer(int one, out uint framebuffer);
        internal delegate void GenFramebuffers(int count, uint[] framebuffers);

        /// <summary>
        /// Checks and returns the state of a framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="FramebufferTarget"/> specifying the framebuffer target.</param>
        /// <returns>A <see cref="FramebufferStatus"/> specifying the state of the framebuffer target</returns>
        public delegate FramebufferStatus CheckFramebufferStatus(FramebufferTarget target);

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="FramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="textarget">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level of the texture.</param>
        [CLSCompliant(false)]
        public delegate void FramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="textarget">A <see cref="glTexture2DTarget"/> specifying the texture target.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level of the texture.</param>
        [CLSCompliant(false)]
        public delegate void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);

        /// <summary>
        /// Attachs a layer of a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="textarget">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level of the texture.</param>
        /// <param name="layer">The 2D layer image within a 3D texture.</param>
        [CLSCompliant(false)]
        public delegate void FramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level, int layer);

        /// <summary>
        /// Attachs a renderbuffer as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="renderbuffertarget">Must be <see cref="glRenderbufferTarget.RENDERBUFFER"/>.</param>
        /// <param name="renderbuffer">The name of the renderbuffer.</param>
        [CLSCompliant(false)]
        public delegate void FramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);

        /// <summary>
        /// Returns the value of a framebuffer attachment parameter.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="pname">A <see cref="glFramebufferAttachmentParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetFramebufferAttachmentParameteri(FramebufferTarget target, FramebufferAttachment attachment, FramebufferParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a framebuffer attachment parameter.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="pname">A <see cref="glFramebufferAttachmentParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetFramebufferAttachmentParameteriv(FramebufferTarget target, FramebufferAttachment attachment, FramebufferParameterName pname, int[] @params);

        /// <summary>
        /// Generates the mipmap for the texture currently bound to a specific texture target.
        /// </summary>
        /// <param name="target">A <see cref="glTextureTarget"/> specifying the texture target.</param>
        public delegate void GenerateMipmap(GenerateMipmapTarget target);

        /// <summary>
        /// Copies a block of pixels from the framebuffer bound to <see cref="glFramebufferTarget.READ_FRAMEBUFFER"/> to the framebuffer bound to <see cref="glFramebufferTarget.DRAW_FRAMEBUFFER"/>.
        /// </summary>
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
        public delegate void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);

        /// <summary>
        /// Creates a multisample renderbuffer storage for the currently bound renderbuffer object.
        /// </summary>
        /// <param name="target">Must be <see cref="glRenderbufferTarget.RENDERBUFFER"/>.</param>
        /// <param name="samples">The number of samples.</param>
        /// <param name="internalformat">A <see cref="glInternalFormat"/> specifying the internal format of the storage.</param>
        /// <param name="width">The width of the storage in pixels.</param>
        /// <param name="height">The height of the storage in pixels.</param>
        public delegate void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, PixelInternalFormat internalformat, int width, int height);

        /// <summary>
        /// Attachs a layer of a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        /// <param name="target">A <see cref="glFramebufferTarget"/> specifying the framebuffer target.</param>
        /// <param name="attachment">The framebuffer attachment.</param>
        /// <param name="texture">The name of the texture.</param>
        /// <param name="level">The level of the texture.</param>
        /// <param name="layer">The 2D layer image within a 3D texture or the face of a cubemap (array).</param>
        [CLSCompliant(false)]
        public delegate void FramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer);

        internal delegate IntPtr MapBufferRange_32(BufferTarget target, int offset, int length, BufferAccessMask access);
        internal delegate IntPtr MapBufferRange_64(BufferTarget target, long offset, long length, BufferAccessMask access);
        internal delegate void FlushMappedBufferRange_32(BufferTarget target, int offset, int length);
        internal delegate void FlushMappedBufferRange_64(BufferTarget target, long offset, long length);

        /// <summary>
        /// Binds a vertex array object.
        /// </summary>
        /// <param name="array">The name of the vertex array.</param>
        [CLSCompliant(false)]
        public delegate void BindVertexArray(uint array);

        /// <summary>
        /// Releases <paramref name="count"/> many vertex array names.
        /// </summary>
        /// <param name="count">Number of vertex array names to be released.</param>
        /// <param name="arrays">Array of vertex array names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteVertexArrays(int count, params uint[] arrays);

        internal delegate void GenVertexArray(int one, out uint array);
        internal delegate void GenVertexArrays(int count, uint[] arrays);

        /// <summary>
        /// Determines if a name is a vertex array name.
        /// </summary>
        /// <param name="array">The maybe vertex array name.</param>
        /// <returns><b>true</b> if <paramref name="array"/> is a vertex array name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsVertexArray(uint array);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 3.0 is available.
        /// </summary>
        public static bool VERSION_3_0;

        #region Delegates
        /// <summary>
        /// Sets the color mask for color write operations for a specific draw buffer.
        /// </summary>
        [CLSCompliant(false)]
        public static ColorMaski ColorMaski;

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetBooleani_ GetBooleani_;

        private static GetBooleani_v _GetBooleani_v;

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetIntegeri_ GetIntegeri_;

        /// <summary>
        /// Returns the value of a index parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetIntegeri_v GetIntegeri_v;

        /// <summary>
        /// Enables indexed OpenGL capabilities.
        /// </summary>
        [CLSCompliant(false)]
        public static Enablei Enablei;

        /// <summary>
        /// Disables indexed OpenGL capabilities.
        /// </summary>
        [CLSCompliant(false)]
        public static Disablei Disablei;

        /// <summary>
        /// Checks wether or not a indexed OpenGL capability is enabled.
        /// </summary>
        [CLSCompliant(false)]
        public static IsEnabledi IsEnabledi;

        /// <summary>
        /// Starts transform feedback operation.
        /// </summary>
        public static BeginTransformFeedback BeginTransformFeedback;

        /// <summary>
        /// Stops transform feedback operation.
        /// </summary>
        public static EndTransformFeedback EndTransformFeedback;

        private static BindBufferRange_32 BindBufferRange_32;
        private static BindBufferRange_64 BindBufferRange_64;

        /// <summary>
        /// Binds buffer objects to indexed buffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static BindBufferBase BindBufferBase;

        /// <summary>
        /// Sets values to record in transform feedback buffers.
        /// </summary>
        [CLSCompliant(false)]
        public static TransformFeedbackVaryings TransformFeedbackVaryings;

        private static GetTransformFeedbackVarying _GetTransformFeedbackVarying;

        /// <summary>
        /// Sets read color clamping states.
        /// </summary>
        public static ClampColor ClampColor;

        /// <summary>
        /// Starts conditional rendering.
        /// </summary>
        [CLSCompliant(false)]
        public static BeginConditionalRender BeginConditionalRender;

        /// <summary>
        /// Stops conditional rendering.
        /// </summary>
        public static EndConditionalRender EndConditionalRender;

        private static VertexAttribIPointer_32 VertexAttribIPointer_32;
        private static VertexAttribIPointer_64 VertexAttribIPointer_64;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribIi GetVertexAttribIi;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribIiv GetVertexAttribIiv;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribIui GetVertexAttribIui;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribIuiv GetVertexAttribIuiv;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI1i VertexAttribI1i;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI2i VertexAttribI2i;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI3i VertexAttribI3i;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4i VertexAttribI4i;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI1ui VertexAttribI1ui;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI2ui VertexAttribI2ui;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI3ui VertexAttribI3ui;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4ui VertexAttribI4ui;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI1iv VertexAttribI1iv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI2iv VertexAttribI2iv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI3iv VertexAttribI3iv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4iv VertexAttribI4iv;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI1uiv VertexAttribI1uiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI2uiv VertexAttribI2uiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI3uiv VertexAttribI3uiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4uiv VertexAttribI4uiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4bv VertexAttribI4bv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4sv VertexAttribI4sv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4ubv VertexAttribI4ubv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribI4usv VertexAttribI4usv;

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformui GetUniformui;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformuiv GetUniformuiv;

        /// <summary>
        /// Binds a varing output variable to fragment shader color.
        /// </summary>
        [CLSCompliant(false)]
        public static BindFragDataLocation BindFragDataLocation;

        /// <summary>
        /// Returns the fragment shader color index of a bound varing output variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetFragDataLocation GetFragDataLocation;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform1ui Uniform1ui;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform2ui Uniform2ui;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform3ui Uniform3ui;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform4ui Uniform4ui;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform1uiv Uniform1uiv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform2uiv Uniform2uiv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform3uiv Uniform3uiv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        [CLSCompliant(false)]
        public static Uniform4uiv Uniform4uiv;

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TexParameterIiv TexParameterIiv;

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        [CLSCompliant(false)]
        public static TexParameterIuiv TexParameterIuiv;

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTexParameterIi GetTexParameterIi;

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTexParameterIiv GetTexParameterIiv;

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTexParameterIui GetTexParameterIui;

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        [CLSCompliant(false)]
        public static GetTexParameterIuiv GetTexParameterIuiv;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearBufferiv ClearBufferiv;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearBufferuiv ClearBufferuiv;

        /// <summary>
        /// Clears/Resets the values of a buffer to a specific value.
        /// </summary>
        [CLSCompliant(false)]
        public static ClearBufferfv ClearBufferfv;

        /// <summary>
        /// Clears/Resets the values of the depth-stencil-buffer to a specific value.
        /// </summary>
        public static ClearBufferfi ClearBufferfi;

        private static GetStringi _GetStringi;

        /// <summary>
        /// Determines if a name is a renderbuffer name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsRenderbuffer IsRenderbuffer;

        /// <summary>
        /// Binds a renderbuffer.
        /// </summary>
        [CLSCompliant(false)]
        public static BindRenderbuffer BindRenderbuffer;

        /// <summary>
        /// Releases multiple renderbuffer names at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteRenderbuffers DeleteRenderbuffers;

        private static GenRenderbuffer _GenRenderbuffer;
        private static GenRenderbuffers _GenRenderbuffers;

        /// <summary>
        /// Creates a renderbuffer storage for the currently bound renderbuffer object.
        /// </summary>
        public static Delegates.RenderbufferStorage RenderbufferStorage;

        /// <summary>
        /// Returns the value of a renderbuffer parameter.
        /// </summary>
        public static GetRenderbufferParameteri GetRenderbufferParameteri;

        /// <summary>
        /// Returns the value(s) of a renderbuffer parameter.
        /// </summary>
        public static GetRenderbufferParameteriv GetRenderbufferParameteriv;

        /// <summary>
        /// Determines if a name is a framebuffer name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsFramebuffer IsFramebuffer;

        /// <summary>
        /// Binds a framebuffer to a framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static BindFramebuffer BindFramebuffer;

        /// <summary>
        /// Releases multiple framebuffer names at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteFramebuffers DeleteFramebuffers;

        private static GenFramebuffer _GenFramebuffer;
        private static GenFramebuffers _GenFramebuffers;

        /// <summary>
        /// Checks and returns the state of a framebuffer target.
        /// </summary>
        public static CheckFramebufferStatus CheckFramebufferStatus;

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferTexture1D FramebufferTexture1D;

        /// <summary>
        /// Attachs a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferTexture2D FramebufferTexture2D;

        /// <summary>
        /// Attachs a layer of a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferTexture3D FramebufferTexture3D;

        /// <summary>
        /// Attachs a renderbuffer as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferRenderbuffer FramebufferRenderbuffer;

        /// <summary>
        /// Returns the value of a framebuffer attachment parameter.
        /// </summary>
        public static GetFramebufferAttachmentParameteri GetFramebufferAttachmentParameteri;

        /// <summary>
        /// Returns the value(s) of a framebuffer attachment parameter.
        /// </summary>
        public static GetFramebufferAttachmentParameteriv GetFramebufferAttachmentParameteriv;

        /// <summary>
        /// Generates the mipmap for the texture currently bound to a specific texture target.
        /// </summary>
        public static GenerateMipmap GenerateMipmap;

        /// <summary>
        /// Copies a block of pixels from the framebuffer bound to <see cref="glFramebufferTarget.READ_FRAMEBUFFER"/> to the framebuffer bound to <see cref="glFramebufferTarget.DRAW_FRAMEBUFFER"/>.
        /// </summary>
        public static BlitFramebuffer BlitFramebuffer;

        /// <summary>
        /// Creates a multisample renderbuffer storage for the currently bound renderbuffer object.
        /// </summary>
        public static RenderbufferStorageMultisample RenderbufferStorageMultisample;

        /// <summary>
        /// Attachs a layer of a level of a texture as a buffer to a attachment of the currently bound framebuffer bound to a specific framebuffer target.
        /// </summary>
        [CLSCompliant(false)]
        public static FramebufferTextureLayer FramebufferTextureLayer;

        private static MapBufferRange_32 MapBufferRange_32;
        private static MapBufferRange_64 MapBufferRange_64;
        private static FlushMappedBufferRange_32 FlushMappedBufferRange_32;
        private static FlushMappedBufferRange_64 FlushMappedBufferRange_64;

        /// <summary>
        /// Binds a vertex array object.
        /// </summary>
        [CLSCompliant(false)]
        public static BindVertexArray BindVertexArray;

        /// <summary>
        /// Releases multiple vertex array names.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteVertexArrays DeleteVertexArrays;
        private static GenVertexArray _GenVertexArray;
        private static GenVertexArrays _GenVertexArrays;

        /// <summary>
        /// Determines if a name is a vertex array name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsVertexArray IsVertexArray;
        #endregion

        #region Overloads
        #region GetBooleani_v
        /// <summary>
        /// Returns the value(s) of a index parameter.
        /// </summary>
        /// <param name="target">A <see cref="GetIndexedPName"/> specifying the parameter.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="data">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public static void GetBooleani_v(GetIndexedPName target, uint index, bool[] data)
        {
            GCHandle hData = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                _GetBooleani_v(target, index, hData.AddrOfPinnedObject());
            }
            finally
            {
                hData.Free();
            }
        }
        #endregion

        #region BindBufferRange
        /// <summary>
        /// Binds a range of a buffer objects to indexed buffer target.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer.</param>
        /// <param name="index">The index of the indexed buffer target.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset inside the buffer.</param>
        /// <param name="size">The size of the range.</param>
        [CLSCompliant(false)]
        public static void BindBufferRange(BufferTarget target, uint index, uint buffer, int offset, int size)
        {
            if (IntPtr.Size == 4) BindBufferRange_32(target, index, buffer, offset, size);
            else BindBufferRange_64(target, index, buffer, offset, size);
        }

        /// <summary>
        /// Binds a range of a buffer objects to indexed buffer target.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer.</param>
        /// <param name="index">The index of the indexed buffer target.</param>
        /// <param name="buffer">The name of the buffer object.</param>
        /// <param name="offset">The offset inside the buffer.</param>
        /// <param name="size">The size of the range.</param>
        [CLSCompliant(false)]
        public static void BindBufferRange(BufferTarget target, uint index, uint buffer, long offset, long size)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                BindBufferRange_32(target, index, buffer, (int)offset, (int)size);
            }
            else BindBufferRange_64(target, index, buffer, offset, size);
        }
        #endregion

        #region GetTransformFeedbackVarying
        /// <summary>
        /// Retrieves informations about varying variables selected for transform feedback.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="index">The index of the varying variable.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="size">Returns the size of the attribute variable.</param>
        /// <param name="type">Returns the type of the attribute variable as <see cref="glGLSLType"/> value.</param>
        /// <param name="name">Returns the name of the attribute variable.</param>
        [CLSCompliant(false)]
        public static void GetTransformFeedbackVarying(uint program, uint index, int bufSize, out int length, out int size, out TransformFeedbackType type, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetTransformFeedbackVarying(program, index, bufSize + 1, out length, out size, out type, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region VertexAttribIPointer
        /// <summary>
        /// Sets the address of an array of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="size">Size of the vertex attribute.</param>
        /// <param name="type">Data type of the vertex attribute data.</param>
        /// <param name="stride">The byte offset between consecutive vertex attributes.</param>
        /// <param name="pointer">Offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ARRAY_BUFFER"/>.</param>
        [CLSCompliant(false)]
        public static void VertexAttribIPointer(uint index, int size, VertexAttribPointerType type, int stride, int pointer)
        {
            if (IntPtr.Size == 4) VertexAttribIPointer_32(index, size, type, stride, pointer);
            else VertexAttribIPointer_64(index, size, type, stride, pointer);
        }

        /// <summary>
        /// Sets the address of an array of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="size">Size of the vertex attribute.</param>
        /// <param name="type">Data type of the vertex attribute data.</param>
        /// <param name="stride">The byte offset between consecutive vertex attributes.</param>
        /// <param name="pointer">Offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ARRAY_BUFFER"/>.</param>
        [CLSCompliant(false)]
        public static void VertexAttribIPointer(uint index, int size, VertexAttribPointerType type, int stride, long pointer)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)pointer >> 32) != 0) throw new ArgumentOutOfRangeException("pointer", PlatformErrorString);
                VertexAttribIPointer_32(index, size, type, stride, (int)pointer);
            }
            else VertexAttribIPointer_64(index, size, type, stride, pointer);
        }
        #endregion

        #region GetStringi
        /// <summary>
        /// Returns the values of indexed string parameters.
        /// </summary>
        /// <param name="name">A <see cref="glGetStringIndexedParameter"/> specifying the indexed string parameter.</param>
        /// <param name="index">The index.</param>
        /// <returns>The retquested value.</returns>
        [CLSCompliant(false)]
        public static string GetStringi(StringNameIndexed name, uint index)
        {
            return Marshal.PtrToStringAnsi(_GetStringi(name, index));
        }
        #endregion

        #region GenRenderbuffer(s)
        /// <summary>
        /// Generates one renderbuffer name and returns it.
        /// </summary>
        /// <returns>The new renderbuffer name.</returns>
        [CLSCompliant(false)]
        public static uint GenRenderbuffer()
        {
            uint ret;
            _GenRenderbuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one renderbuffer name and returns it.
        /// </summary>
        /// <param name="renderbuffer">The new renderbuffer name.</param>
        [CLSCompliant(false)]
        public static void GenRenderbuffer(out uint renderbuffer)
        {
            _GenRenderbuffer(1, out renderbuffer);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many renderbuffer names and returns them as array.
        /// </summary>
        /// <param name="count">The number of renderbuffer names to be generated.</param>
        /// <returns>The new renderbuffer names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenRenderbuffers(int count)
        {
            uint[] ret = new uint[count];
            _GenRenderbuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many renderbuffer names.
        /// </summary>
        /// <param name="count">The number of renderbuffer names to be generated.</param>
        /// <param name="renderbuffers">The array that will receive the new renderbuffer names.</param>
        [CLSCompliant(false)]
        public static void GenRenderbuffers(int count, uint[] renderbuffers)
        {
            _GenRenderbuffers(count, renderbuffers);
        }
        #endregion

        #region GenFramebuffer(s)
        /// <summary>
        /// Generates one framebuffer name and returns it.
        /// </summary>
        /// <returns>The new framebuffer name.</returns>
        [CLSCompliant(false)]
        public static uint GenFramebuffer()
        {
            uint ret;
            _GenFramebuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one framebuffer name and returns it.
        /// </summary>
        /// <param name="framebuffer">The new framebuffer name.</param>
        [CLSCompliant(false)]
        public static void GenFramebuffer(out uint framebuffer)
        {
            _GenFramebuffer(1, out framebuffer);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many framebuffer names and returns them as array.
        /// </summary>
        /// <param name="count">The number of framebuffer names to be generated.</param>
        /// <returns>The new framebuffer names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenFramebuffers(int count)
        {
            uint[] ret = new uint[count];
            _GenFramebuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many framebuffer names.
        /// </summary>
        /// <param name="count">The number of framebuffer names to be generated.</param>
        /// <param name="framebuffers">The array that will receive the new framebuffer names.</param>
        [CLSCompliant(false)]
        public static void GenFramebuffers(int count, uint[] framebuffers)
        {
            _GenFramebuffers(count, framebuffers);
        }
        #endregion

        #region MapBufferRange
        /// <summary>
        /// Maps all or parts of a data store into client memory.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        public static IntPtr MapBufferRange(BufferTarget target, int offset, int length, BufferAccessMask access)
        {
            if (IntPtr.Size == 4) return MapBufferRange_32(target, offset, length, access);
            return MapBufferRange_64(target, offset, length, access);
        }

        /// <summary>
        /// Maps all or parts of a data store into client memory.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        public static IntPtr MapBufferRange(BufferTarget target, long offset, long length, BufferAccessMask access)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)length >> 32) != 0) throw new ArgumentOutOfRangeException("length", PlatformErrorString);
                return MapBufferRange_32(target, (int)offset, (int)length, access);
            }
            return MapBufferRange_64(target, offset, length, access);
        }
        #endregion

        #region FlushMappedBufferRange
        /// <summary>
        /// Flushes modifications to a range of a mapped buffer.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        public static void FlushMappedBufferRange(BufferTarget target, int offset, int length)
        {
            if (IntPtr.Size == 4) FlushMappedBufferRange_32(target, offset, length);
            else FlushMappedBufferRange_64(target, offset, length);
        }

        /// <summary>
        /// Flushes modifications to a range of a mapped buffer.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the buffer target.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="length">The size of the region.</param>
        public static void FlushMappedBufferRange(BufferTarget target, long offset, long length)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)length >> 32) != 0) throw new ArgumentOutOfRangeException("length", PlatformErrorString);
                FlushMappedBufferRange_32(target, (int)offset, (int)length);
            }
            else FlushMappedBufferRange_64(target, offset, length);
        }
        #endregion

        #region GenVertexArray(s)
        /// <summary>
        /// Generates one vertex array name and returns it.
        /// </summary>
        /// <returns>The new vertex array name.</returns>
        [CLSCompliant(false)]
        public static uint GenVertexArray()
        {
            uint ret;
            _GenVertexArray(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one vertex array name and returns it.
        /// </summary>
        /// <param name="array">The new vertex array name.</param>
        [CLSCompliant(false)]
        public static void GenVertexArray(out uint array)
        {
            _GenVertexArray(1, out array);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many vertex array names and returns them as array.
        /// </summary>
        /// <param name="count">The number of vertex array names to be generated.</param>
        /// <returns>The new vertex array names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenVertexArrays(int count)
        {
            uint[] ret = new uint[count];
            _GenVertexArrays(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many vertex array names.
        /// </summary>
        /// <param name="count">The number of vertex array names to be generated.</param>
        /// <param name="arrays">The array that will receive the new vertex array names.</param>
        [CLSCompliant(false)]
        public static void GenVertexArrays(int count, uint[] arrays)
        {
            _GenVertexArrays(count, arrays);
        }
        #endregion
        #endregion

        private static void Load_VERSION_3_0()
        {
            ColorMaski = GetAddress<ColorMaski>("glColorMaski");
            GetBooleani_ = GetAddress<GetBooleani_>("glGetBooleani_v");
            _GetBooleani_v = GetAddress<GetBooleani_v>("glGetBooleani_v");
            GetIntegeri_ = GetAddress<GetIntegeri_>("glGetIntegeri_v");
            GetIntegeri_v = GetAddress<GetIntegeri_v>("glGetIntegeri_v");
            Enablei = GetAddress<Enablei>("glEnablei");
            Disablei = GetAddress<Disablei>("glDisablei");
            IsEnabledi = GetAddress<IsEnabledi>("glIsEnabledi");
            BeginTransformFeedback = GetAddress<BeginTransformFeedback>("glBeginTransformFeedback");
            EndTransformFeedback = GetAddress<EndTransformFeedback>("glEndTransformFeedback");
            BindBufferBase = GetAddress<BindBufferBase>("glBindBufferBase");
            TransformFeedbackVaryings = GetAddress<TransformFeedbackVaryings>("glTransformFeedbackVaryings");
            _GetTransformFeedbackVarying = GetAddress<GetTransformFeedbackVarying>("glGetTransformFeedbackVarying");
            ClampColor = GetAddress<ClampColor>("glClampColor");
            BeginConditionalRender = GetAddress<BeginConditionalRender>("glBeginConditionalRender");
            EndConditionalRender = GetAddress<EndConditionalRender>("glEndConditionalRender");
            GetVertexAttribIi = GetAddress<GetVertexAttribIi>("glGetVertexAttribIiv");
            GetVertexAttribIiv = GetAddress<GetVertexAttribIiv>("glGetVertexAttribIiv");
            GetVertexAttribIui = GetAddress<GetVertexAttribIui>("glGetVertexAttribIuiv");
            GetVertexAttribIuiv = GetAddress<GetVertexAttribIuiv>("glGetVertexAttribIuiv");
            VertexAttribI1i = GetAddress<VertexAttribI1i>("glVertexAttribI1i");
            VertexAttribI2i = GetAddress<VertexAttribI2i>("glVertexAttribI2i");
            VertexAttribI3i = GetAddress<VertexAttribI3i>("glVertexAttribI3i");
            VertexAttribI4i = GetAddress<VertexAttribI4i>("glVertexAttribI4i");
            VertexAttribI1ui = GetAddress<VertexAttribI1ui>("glVertexAttribI1ui");
            VertexAttribI2ui = GetAddress<VertexAttribI2ui>("glVertexAttribI2ui");
            VertexAttribI3ui = GetAddress<VertexAttribI3ui>("glVertexAttribI3ui");
            VertexAttribI4ui = GetAddress<VertexAttribI4ui>("glVertexAttribI4ui");
            VertexAttribI1iv = GetAddress<VertexAttribI1iv>("glVertexAttribI1iv");
            VertexAttribI2iv = GetAddress<VertexAttribI2iv>("glVertexAttribI2iv");
            VertexAttribI3iv = GetAddress<VertexAttribI3iv>("glVertexAttribI3iv");
            VertexAttribI4iv = GetAddress<VertexAttribI4iv>("glVertexAttribI4iv");
            VertexAttribI1uiv = GetAddress<VertexAttribI1uiv>("glVertexAttribI1uiv");
            VertexAttribI2uiv = GetAddress<VertexAttribI2uiv>("glVertexAttribI2uiv");
            VertexAttribI3uiv = GetAddress<VertexAttribI3uiv>("glVertexAttribI3uiv");
            VertexAttribI4uiv = GetAddress<VertexAttribI4uiv>("glVertexAttribI4uiv");
            VertexAttribI4bv = GetAddress<VertexAttribI4bv>("glVertexAttribI4bv");
            VertexAttribI4sv = GetAddress<VertexAttribI4sv>("glVertexAttribI4sv");
            VertexAttribI4ubv = GetAddress<VertexAttribI4ubv>("glVertexAttribI4ubv");
            VertexAttribI4usv = GetAddress<VertexAttribI4usv>("glVertexAttribI4usv");
            GetUniformui = GetAddress<GetUniformui>("glGetUniformuiv");
            GetUniformuiv = GetAddress<GetUniformuiv>("glGetUniformuiv");
            BindFragDataLocation = GetAddress<BindFragDataLocation>("glBindFragDataLocation");
            GetFragDataLocation = GetAddress<GetFragDataLocation>("glGetFragDataLocation");
            Uniform1ui = GetAddress<Uniform1ui>("glUniform1ui");
            Uniform2ui = GetAddress<Uniform2ui>("glUniform2ui");
            Uniform3ui = GetAddress<Uniform3ui>("glUniform3ui");
            Uniform4ui = GetAddress<Uniform4ui>("glUniform4ui");
            Uniform1uiv = GetAddress<Uniform1uiv>("glUniform1uiv");
            Uniform2uiv = GetAddress<Uniform2uiv>("glUniform2uiv");
            Uniform3uiv = GetAddress<Uniform3uiv>("glUniform3uiv");
            Uniform4uiv = GetAddress<Uniform4uiv>("glUniform4uiv");
            TexParameterIiv = GetAddress<TexParameterIiv>("glTexParameterIiv");
            TexParameterIuiv = GetAddress<TexParameterIuiv>("glTexParameterIuiv");
            GetTexParameterIi = GetAddress<GetTexParameterIi>("glGetTexParameterIiv");
            GetTexParameterIiv = GetAddress<GetTexParameterIiv>("glGetTexParameterIiv");
            GetTexParameterIui = GetAddress<GetTexParameterIui>("glGetTexParameterIuiv");
            GetTexParameterIuiv = GetAddress<GetTexParameterIuiv>("glGetTexParameterIuiv");
            ClearBufferiv = GetAddress<ClearBufferiv>("glClearBufferiv");
            ClearBufferuiv = GetAddress<ClearBufferuiv>("glClearBufferuiv");
            ClearBufferfv = GetAddress<ClearBufferfv>("glClearBufferfv");
            ClearBufferfi = GetAddress<ClearBufferfi>("glClearBufferfi");
            _GetStringi = GetAddress<GetStringi>("glGetStringi");
            IsRenderbuffer = GetAddress<IsRenderbuffer>("glIsRenderbuffer");
            BindRenderbuffer = GetAddress<BindRenderbuffer>("glBindRenderbuffer");
            DeleteRenderbuffers = GetAddress<DeleteRenderbuffers>("glDeleteRenderbuffers");
            _GenRenderbuffer = GetAddress<GenRenderbuffer>("glGenRenderbuffers");
            _GenRenderbuffers = GetAddress<GenRenderbuffers>("glGenRenderbuffers");
            RenderbufferStorage = GetAddress<Delegates.RenderbufferStorage>("glRenderbufferStorage");
            GetRenderbufferParameteri = GetAddress<GetRenderbufferParameteri>("glGetRenderbufferParameteriv");
            GetRenderbufferParameteriv = GetAddress<GetRenderbufferParameteriv>("glGetRenderbufferParameteriv");
            IsFramebuffer = GetAddress<IsFramebuffer>("glIsFramebuffer");
            BindFramebuffer = GetAddress<BindFramebuffer>("glBindFramebuffer");
            DeleteFramebuffers = GetAddress<DeleteFramebuffers>("glDeleteFramebuffers");
            _GenFramebuffer = GetAddress<GenFramebuffer>("glGenFramebuffers");
            _GenFramebuffers = GetAddress<GenFramebuffers>("glGenFramebuffers");
            CheckFramebufferStatus = GetAddress<CheckFramebufferStatus>("glCheckFramebufferStatus");
            FramebufferTexture1D = GetAddress<FramebufferTexture1D>("glFramebufferTexture1D");
            FramebufferTexture2D = GetAddress<FramebufferTexture2D>("glFramebufferTexture2D");
            FramebufferTexture3D = GetAddress<FramebufferTexture3D>("glFramebufferTexture3D");
            FramebufferRenderbuffer = GetAddress<FramebufferRenderbuffer>("glFramebufferRenderbuffer");
            GetFramebufferAttachmentParameteri = GetAddress<GetFramebufferAttachmentParameteri>("glGetFramebufferAttachmentParameteriv");
            GetFramebufferAttachmentParameteriv = GetAddress<GetFramebufferAttachmentParameteriv>("glGetFramebufferAttachmentParameteriv");
            GenerateMipmap = GetAddress<GenerateMipmap>("glGenerateMipmap");
            BlitFramebuffer = GetAddress<BlitFramebuffer>("glBlitFramebuffer");
            RenderbufferStorageMultisample = GetAddress<RenderbufferStorageMultisample>("glRenderbufferStorageMultisample");
            FramebufferTextureLayer = GetAddress<FramebufferTextureLayer>("glFramebufferTextureLayer");
            BindVertexArray = GetAddress<BindVertexArray>("glBindVertexArray");
            DeleteVertexArrays = GetAddress<DeleteVertexArrays>("glDeleteVertexArrays");
            _GenVertexArray = GetAddress<GenVertexArray>("glGenVertexArrays");
            _GenVertexArrays = GetAddress<GenVertexArrays>("glGenVertexArrays");
            IsVertexArray = GetAddress<IsVertexArray>("glIsVertexArray");

            bool platformDependend;
            if (IntPtr.Size == 4)
            {
                BindBufferRange_32 = GetAddress<BindBufferRange_32>("glBindBufferRange");
                VertexAttribIPointer_32 = GetAddress<VertexAttribIPointer_32>("glVertexAttribIPointer");
                MapBufferRange_32 = GetAddress<MapBufferRange_32>("glMapBufferRange");
                FlushMappedBufferRange_32 = GetAddress<FlushMappedBufferRange_32>("glFlushMappedBufferRange");

                platformDependend = BindBufferRange_32 != null && VertexAttribIPointer_32 != null &&
                    MapBufferRange_32 != null && FlushMappedBufferRange_32 != null;
            }
            else
            {
                BindBufferRange_64 = GetAddress<BindBufferRange_64>("glBindBufferRange");
                VertexAttribIPointer_64 = GetAddress<VertexAttribIPointer_64>("glVertexAttribIPointer");
                MapBufferRange_64 = GetAddress<MapBufferRange_64>("glMapBufferRange");
                FlushMappedBufferRange_64 = GetAddress<FlushMappedBufferRange_64>("glFlushMappedBufferRange");

                platformDependend = BindBufferRange_64 != null && VertexAttribIPointer_64 != null &&
                    MapBufferRange_64 != null && FlushMappedBufferRange_64 != null;
            }

            VERSION_3_0 = VERSION_2_1 && ColorMaski != null && _GetBooleani_v != null && GetIntegeri_v != null &&
                Enablei != null && Disablei != null && IsEnabledi != null && BeginTransformFeedback != null &&
                EndTransformFeedback != null && BindBufferBase != null && TransformFeedbackVaryings != null &&
                _GetTransformFeedbackVarying != null && ClampColor != null && BeginConditionalRender != null &&
                EndConditionalRender != null && GetVertexAttribIiv != null && GetVertexAttribIuiv != null &&
                VertexAttribI4i != null && VertexAttribI4ui != null && VertexAttribI4iv != null && VertexAttribI4uiv != null &&
                VertexAttribI4bv != null && VertexAttribI4sv != null && VertexAttribI4ubv != null &&
                VertexAttribI4usv != null && GetUniformuiv != null && BindFragDataLocation != null &&
                GetFragDataLocation != null && Uniform4ui != null && Uniform4uiv != null && TexParameterIiv != null &&
                TexParameterIuiv != null && GetTexParameterIiv != null && GetTexParameterIuiv != null &&
                ClearBufferiv != null && ClearBufferuiv != null && ClearBufferfv != null && ClearBufferfi != null &&
                _GetStringi != null && IsRenderbuffer != null && BindRenderbuffer != null && DeleteRenderbuffers != null &&
                _GenRenderbuffers != null && RenderbufferStorage != null && GetRenderbufferParameteriv != null &&
                IsFramebuffer != null && BindFramebuffer != null && DeleteFramebuffers != null &&
                _GenFramebuffers != null && CheckFramebufferStatus != null && FramebufferTexture1D != null &&
                FramebufferRenderbuffer != null && GetFramebufferAttachmentParameteriv != null && GenerateMipmap != null &&
                BlitFramebuffer != null && RenderbufferStorageMultisample != null && FramebufferTextureLayer != null &&
                BindVertexArray != null && DeleteVertexArrays != null && _GenVertexArrays != null &&
                IsVertexArray != null && platformDependend;
        }
    }
}
