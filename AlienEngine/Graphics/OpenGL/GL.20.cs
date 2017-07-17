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
        /// Sets the blend equation separately for color and alpha.
        /// </summary>
        /// <param name="modeRGB">A <see cref="BlendEquationMode"/> specifying the color blend equation.</param>
        /// <param name="modeAlpha">A <see cref="BlendEquationMode"/> specifying the alpha blend equation.</param>
        public delegate void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha);

        /// <summary>
        /// Sets the buffers to be drawn into.
        /// </summary>
        /// <param name="count">Number of buffers.</param>
        /// <param name="bufs">A array of <see cref="DrawBufferMode"/>s specifying the buffers.</param>
        public delegate void DrawBuffers(int count, params DrawBuffersEnum[] bufs);

        /// <summary>
        /// Sets the front and/or back face stencil operation.
        /// </summary>
        /// <param name="face">A <see cref="StencilFace"/> specifying the face(s).</param>
        /// <param name="sfail">A <see cref="StencilOp"/> specifying the action to take when the stencil test fails.</param>
        /// <param name="dpfail">A <see cref="StencilOp"/> specifying the action to take when the stencil test passed, but the depth test fails.</param>
        /// <param name="dppass">A <see cref="StencilOp"/> specifying the action to take when the stencil and depth test passes.</param>
        public delegate void StencilOpSeparate(StencilFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);

        /// <summary>
        /// Sets the front and/or back face stencil test function.
        /// </summary>
        /// <param name="face">A <see cref="StencilFace"/> specifying the face(s).</param>
        /// <param name="func">A <see cref="StencilFunction"/> specifying the test function.</param>
        /// <param name="ref">The reference value.</param>
        /// <param name="mask">The bitmask for the operation.</param>
        [CLSCompliant(false)]
        public delegate void StencilFuncSeparate(StencilFace face, StencilFunction func, int @ref, uint mask);

        /// <summary>
        /// Sets the front and/or back face stencil mask for stencil write operations.
        /// </summary>
        /// <param name="face">A <see cref="StencilFace"/> specifying the face(s).</param>
        /// <param name="mask">The bitmask.</param>
        [CLSCompliant(false)]
        public delegate void StencilMaskSeparate(StencilFace face, uint mask);

        /// <summary>
        /// Attaches a shader to a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shader">The name of the shader.</param>
        [CLSCompliant(false)]
        public delegate void AttachShader(uint program, uint shader);

        /// <summary>
        /// Binds a vertex attribute index to a named attribute vertex shader variable.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="index">The attribute index to be bound.</param>
        /// <param name="name">The name of the vertex shader variable.</param>
        [CLSCompliant(false)]
        public delegate void BindAttribLocation(uint program, uint index, string name);

        /// <summary>
        /// Compiles a shader.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        [CLSCompliant(false)]
        public delegate void CompileShader(uint shader);

        /// <summary>
        /// Creates a program and returns the name of the program.
        /// </summary>
        /// <returns>The name of the program.</returns>
        [CLSCompliant(false)]
        public delegate uint CreateProgram();

        /// <summary>
        /// Creates a shader of a specific type and returns the name of the shader object.
        /// </summary>
        /// <param name="type">A <see cref="glShaderType"/> specifying the shader type.</param>
        /// <returns>The name of the shader object.</returns>
        [CLSCompliant(false)]
        public delegate uint CreateShader(ShaderType type);

        /// <summary>
        /// Releases/Destroys a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        [CLSCompliant(false)]
        public delegate void DeleteProgram(uint program);

        /// <summary>
        /// Releases/Destroys a shader.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        [CLSCompliant(false)]
        public delegate void DeleteShader(uint shader);

        /// <summary>
        /// Detaches a shader from a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shader">The name of the shader.</param>
        [CLSCompliant(false)]
        public delegate void DetachShader(uint program, uint shader);

        /// <summary>
        /// Disables a vertex attribute array.
        /// </summary>
        /// <param name="index">The index of the vertex attribute array.</param>
        [CLSCompliant(false)]
        public delegate void DisableVertexAttribArray(uint index);

        /// <summary>
        /// Enables a vertex attribute array.
        /// </summary>
        /// <param name="index">The index of the vertex attribute array.</param>
        [CLSCompliant(false)]
        public delegate void EnableVertexAttribArray(uint index);

        internal delegate void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out ActiveAttribType type, StringBuilder name);
        internal delegate void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out ActiveUniformType type, StringBuilder name);

        /// <summary>
        /// Returns the attached shaders of a program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="maxCount">The maximum number of shader names to be returned. (Size of the <paramref name="obj"/> array.)</param>
        /// <param name="count">Returns the number of actual returned shader names.</param>
        /// <param name="obj">Returns the shader names.</param>
        [CLSCompliant(false)]
        public delegate void GetAttachedShaders(uint program, int maxCount, out int count, uint[] obj);

        /// <summary>
        /// Returns the location of a vertex attribute that is bound to a named attribute variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="name">The name of the attribute variable.</param>
        /// <returns>The index of the vertex attribute.</returns>
        [CLSCompliant(false)]
        public delegate int GetAttribLocation(uint program, string name);

        /// <summary>
        /// Returns the parameters of program object.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="pname">A <see cref="glProgramParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetProgrami(uint program, GetProgramParameterName pname, out int param);

        /// <summary>
        /// Returns the parameters of program object.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="pname">A <see cref="glProgramParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetProgramiv(uint program, GetProgramParameterName pname, int[] @params);

        internal delegate void GetProgramInfoLog(uint program, int maxLength, out int length, StringBuilder infoLog);

        /// <summary>
        /// Returns the parameters of shader object.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="pname">A <see cref="glShaderParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetShaderi(uint shader, ShaderParameter pname, out int param);

        /// <summary>
        /// Returns the parameters of shader object.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="pname">A <see cref="glShaderParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetShaderiv(uint shader, ShaderParameter pname, int[] @params);

        internal delegate void GetShaderInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog);
        internal delegate void GetShaderSource(uint shader, int bufSize, out int length, StringBuilder source);

        /// <summary>
        /// Returns the location of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="name">The name of the uniform variable.</param>
        /// <returns>The location of the uniform variable inside the program object.</returns>
        [CLSCompliant(false)]
        public delegate int GetUniformLocation(uint program, string name);

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="param">The value of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformf(uint program, int location, out float param);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformfv(uint program, int location, float[] @params);

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="param">The value of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformi(uint program, int location, out int param);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformiv(uint program, int location, int[] @params);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribd(uint index, VertexAttribParameter pname, out double param);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribdv(uint index, VertexAttribParameter pname, double[] @params);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribf(uint index, VertexAttribParameter pname, out float param);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribfv(uint index, VertexAttribParameter pname, float[] @params);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribi(uint index, VertexAttribParameter pname, out int param);

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">A <see cref="glVertexAttribParameter"/> specifying the parameter.</param>
        /// <param name="params">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetVertexAttribiv(uint index, VertexAttribParameter pname, int[] @params);

        internal delegate void GetVertexAttribPointerv_32(uint index, VertexAttribPointerParameter pname, out int pointer);
        internal delegate void GetVertexAttribPointerv_64(uint index, VertexAttribPointerParameter pname, out long pointer);

        /// <summary>
        /// Determines if a name is a program name.
        /// </summary>
        /// <param name="program">>The maybe program name.</param>
        /// <returns><b>true</b> if <paramref name="program"/> is a program name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsProgram(uint program);

        /// <summary>
        /// Determines if a name is a shader name.
        /// </summary>
        /// <param name="shader">>The maybe shader name.</param>
        /// <returns><b>true</b> if <paramref name="shader"/> is a shader name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsShader(uint shader);

        /// <summary>
        /// Links a program object.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        [CLSCompliant(false)]
        public delegate void LinkProgram(uint program);

        internal delegate void ShaderSource(uint shader, int count, string[] strings, int[] lengths);

        /// <summary>
        /// Sets the active program.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        [CLSCompliant(false)]
        public delegate void UseProgram(uint program);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">The value to set.</param>
        public delegate void Uniform1f(int location, float v0);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        public delegate void Uniform2f(int location, float v0, float v1);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Thrid value of a tuple to set.</param>
        public delegate void Uniform3f(int location, float v0, float v1, float v2);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Third value of a tuple to set.</param>
        /// <param name="v3">Fourth value of a tuple to set.</param>
        public delegate void Uniform4f(int location, float v0, float v1, float v2, float v3);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">The value to set.</param>
        public delegate void Uniform1i(int location, int v0);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        public delegate void Uniform2i(int location, int v0, int v1);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Thrid value of a tuple to set.</param>
        public delegate void Uniform3i(int location, int v0, int v1, int v2);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="v0">First value of a tuple to set.</param>
        /// <param name="v1">Second value of a tuple to set.</param>
        /// <param name="v2">Third value of a tuple to set.</param>
        /// <param name="v3">Fourth value of a tuple to set.</param>
        public delegate void Uniform4i(int location, int v0, int v1, int v2, int v3);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform1fv(int location, int count, params float[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform2fv(int location, int count, params float[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform3fv(int location, int count, params float[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform4fv(int location, int count, params float[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform1iv(int location, int count, params int[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform2iv(int location, int count, params int[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform3iv(int location, int count, params int[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform4iv(int location, int count, params int[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix2fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params float[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix3fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params float[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix4fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params float[] value);

        /// <summary>
        /// Validates a program. The status of the validation will be stored in <see cref="glProgramParameter.VALIDATE_STATUS"/>.
        /// </summary>
        /// <param name="program">The name of the program to be validated.</param>
        [CLSCompliant(false)]
        public delegate void ValidateProgram(uint program);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1d(uint index, double x);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1dv(uint index, double[] v);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1f(uint index, float x);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1fv(uint index, float[] v);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1s(uint index, short x);

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib1sv(uint index, short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2d(uint index, double x, double y);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2dv(uint index, double[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2f(uint index, float x, float y);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2fv(uint index, float[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2s(uint index, short x, short y);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib2sv(uint index, short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3d(uint index, double x, double y, double z);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3dv(uint index, double[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3f(uint index, float x, float y, float z);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3fv(uint index, float[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3s(uint index, short x, short y, short z);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib3sv(uint index, short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nbv(uint index, params sbyte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Niv(uint index, params int[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nsv(uint index, params short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nubv(uint index, byte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nuiv(uint index, params uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4Nusv(uint index, params ushort[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4bv(uint index, params sbyte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4d(uint index, double x, double y, double z, double w);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4dv(uint index, double[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4f(uint index, float x, float y, float z, float w);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4fv(uint index, float[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4iv(uint index, params int[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="x">First value to set.</param>
        /// <param name="y">Second value to set.</param>
        /// <param name="z">Third value to set.</param>
        /// <param name="w">Fourth value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4s(uint index, short x, short y, short z, short w);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4sv(uint index, short[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4ubv(uint index, params byte[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4uiv(uint index, params uint[] v);

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="v">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttrib4usv(uint index, params ushort[] v);

        internal delegate void VertexAttribPointer_32(uint index, int size, VertexAttribPointerType type, [MarshalAs(UnmanagedType.I1)] bool normalized, int stride, int pointer);
        internal delegate void VertexAttribPointer_64(uint index, int size, VertexAttribPointerType type, [MarshalAs(UnmanagedType.I1)] bool normalized, int stride, long pointer);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 2.0 is available.
        /// </summary>
        public static bool VERSION_2_0;

        #region Delegates
        /// <summary>
        /// Sets the blend equation separately for color and alpha.
        /// </summary>
        public static BlendEquationSeparate BlendEquationSeparate;

        /// <summary>
        /// Sets the buffers to be drawn into.
        /// </summary>
        public static DrawBuffers DrawBuffers;

        /// <summary>
        /// Sets the front and/or back face stencil operation.
        /// </summary>
        public static StencilOpSeparate StencilOpSeparate;

        /// <summary>
        /// Sets the front and/or back face stencil test function.
        /// </summary>
        [CLSCompliant(false)]
        public static StencilFuncSeparate StencilFuncSeparate;

        /// <summary>
        /// Sets the front and/or back face stencil mask for stencil write operations.
        /// </summary>
        [CLSCompliant(false)]
        public static StencilMaskSeparate StencilMaskSeparate;

        /// <summary>
        /// Attaches a shader to a program.
        /// </summary>
        [CLSCompliant(false)]
        public static AttachShader AttachShader;

        /// <summary>
        /// Binds a vertex attribute index to a named attribute vertex shader variable.
        /// </summary>
        [CLSCompliant(false)]
        public static BindAttribLocation BindAttribLocation;

        /// <summary>
        /// Compiles a shader.
        /// </summary>
        [CLSCompliant(false)]
        public static CompileShader CompileShader;

        /// <summary>
        /// Creates a program and returns the name of the program.
        /// </summary>
        [CLSCompliant(false)]
        public static CreateProgram CreateProgram;

        /// <summary>
        /// Creates a shader of a specific type and returns the name of the shader object.
        /// </summary>
        [CLSCompliant(false)]
        public static CreateShader CreateShader;

        /// <summary>
        /// Releases/Destroys a program.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteProgram DeleteProgram;

        /// <summary>
        /// Releases/Destroys a shader.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteShader DeleteShader;

        /// <summary>
        /// Detaches a shader from a program.
        /// </summary>
        [CLSCompliant(false)]
        public static DetachShader DetachShader;

        /// <summary>
        /// Disables a vertex attribute array.
        /// </summary>
        [CLSCompliant(false)]
        public static DisableVertexAttribArray DisableVertexAttribArray;

        /// <summary>
        /// Enables a vertex attribute array.
        /// </summary>
        [CLSCompliant(false)]
        public static EnableVertexAttribArray EnableVertexAttribArray;

        private static GetActiveAttrib _GetActiveAttrib;
        private static GetActiveUniform _GetActiveUniform;

        /// <summary>
        /// Returns the attached shaders of a program.
        /// </summary>
        [CLSCompliant(false)]
        public static GetAttachedShaders GetAttachedShaders;

        /// <summary>
        /// Returns the location of a vertex attribute that is bound to a named attribute variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetAttribLocation GetAttribLocation;

        /// <summary>
        /// Returns the parameters of program object.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgrami GetProgrami;

        /// <summary>
        /// Returns the parameters of program object.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramiv GetProgramiv;

        private static GetProgramInfoLog _GetProgramInfoLog;

        /// <summary>
        /// Returns the parameters of shader object.
        /// </summary>
        [CLSCompliant(false)]
        public static GetShaderi GetShaderi;

        /// <summary>
        /// Returns the parameters of shader object.
        /// </summary>
        [CLSCompliant(false)]
        public static GetShaderiv GetShaderiv;

        private static GetShaderInfoLog _GetShaderInfoLog;
        private static GetShaderSource _GetShaderSource;

        /// <summary>
        /// Returns the location of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformLocation GetUniformLocation;

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformf GetUniformf;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformfv GetUniformfv;

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformi GetUniformi;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformiv GetUniformiv;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribd GetVertexAttribd;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribdv GetVertexAttribdv;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribf GetVertexAttribf;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribfv GetVertexAttribfv;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribi GetVertexAttribi;

        /// <summary>
        /// Returns parameters of vertex attributes.
        /// </summary>
        [CLSCompliant(false)]
        public static GetVertexAttribiv GetVertexAttribiv;

        private static GetVertexAttribPointerv_32 GetVertexAttribPointerv_32;
        private static GetVertexAttribPointerv_64 GetVertexAttribPointerv_64;

        /// <summary>
        /// Determines if a name is a program name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsProgram IsProgram;

        /// <summary>
        /// Determines if a name is a shader name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsShader IsShader;

        /// <summary>
        /// Links a program object.
        /// </summary>
        [CLSCompliant(false)]
        public static LinkProgram LinkProgram;

        private static ShaderSource _ShaderSource;

        /// <summary>
        /// Sets the active program.
        /// </summary>
        [CLSCompliant(false)]
        public static UseProgram UseProgram;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1f Uniform1f;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2f Uniform2f;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3f Uniform3f;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4f Uniform4f;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1i Uniform1i;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2i Uniform2i;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3i Uniform3i;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4i Uniform4i;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1fv Uniform1fv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2fv Uniform2fv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3fv Uniform3fv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4fv Uniform4fv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1iv Uniform1iv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2iv Uniform2iv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3iv Uniform3iv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4iv Uniform4iv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix2fv UniformMatrix2fv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix3fv UniformMatrix3fv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix4fv UniformMatrix4fv;

        /// <summary>
        /// Validates a program. The status of the validation will be stored in <see cref="glProgramParameter.VALIDATE_STATUS"/>.
        /// </summary>
        [CLSCompliant(false)]
        public static ValidateProgram ValidateProgram;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1d VertexAttrib1d;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1dv VertexAttrib1dv;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1f VertexAttrib1f;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1fv VertexAttrib1fv;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1s VertexAttrib1s;

        /// <summary>
        /// Sets the value of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib1sv VertexAttrib1sv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2d VertexAttrib2d;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2dv VertexAttrib2dv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2f VertexAttrib2f;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2fv VertexAttrib2fv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2s VertexAttrib2s;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib2sv VertexAttrib2sv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3d VertexAttrib3d;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3dv VertexAttrib3dv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3f VertexAttrib3f;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3fv VertexAttrib3fv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3s VertexAttrib3s;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib3sv VertexAttrib3sv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nbv VertexAttrib4Nbv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Niv VertexAttrib4Niv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nsv VertexAttrib4Nsv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nub VertexAttrib4Nub;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nubv VertexAttrib4Nubv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nuiv VertexAttrib4Nuiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4Nusv VertexAttrib4Nusv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4bv VertexAttrib4bv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4d VertexAttrib4d;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4dv VertexAttrib4dv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4f VertexAttrib4f;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4fv VertexAttrib4fv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4iv VertexAttrib4iv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4s VertexAttrib4s;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4sv VertexAttrib4sv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4ubv VertexAttrib4ubv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4uiv VertexAttrib4uiv;

        /// <summary>
        /// Sets the values of a vertex attribute.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttrib4usv VertexAttrib4usv;

        private static VertexAttribPointer_32 VertexAttribPointer_32;
        private static VertexAttribPointer_64 VertexAttribPointer_64;
        #endregion

        #region Overloads
        #region GetActiveAttrib
        /// <summary>
        /// Returns multiple informations about an active attribute variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="index">The index of the attribute variable.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="size">Returns the size of the attribute variable.</param>
        /// <param name="type">Returns the type of the attribute variable as <see cref="ActiveAttribType"/> value.</param>
        /// <param name="name">Returns the name of the attribute variable.</param>
        [CLSCompliant(false)]
        public static void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out ActiveAttribType type, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveAttrib(program, index, bufSize + 1, out length, out size, out type, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region GetActiveUniform
        /// <summary>
        /// Returns multiple informations about an active uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="index">The index of the uniform variable.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="size">Returns the size of the uniform variable.</param>
        /// <param name="type">Returns the type of the uniform variable as <see cref="ActiveUniformType"/> value.</param>
        /// <param name="name">Returns the name of the uniform variable.</param>
        [CLSCompliant(false)]
        public static void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, ref ActiveUniformType type, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveUniform(program, index, bufSize + 1, out length, out size, out type, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region GetProgramInfoLog
        /// <summary>
        /// Returns the information log for a program object.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="maxLength">The size of the buffer used to retrieve <paramref name="infoLog"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="infoLog"/>.</param>
        /// <param name="infoLog">Returns the information log.</param>
        [CLSCompliant(false)]
        public static void GetProgramInfoLog(uint program, int maxLength, out int length, out string infoLog)
        {
            StringBuilder tmp = new StringBuilder(maxLength + 1);
            _GetProgramInfoLog(program, maxLength + 1, out length, tmp);
            infoLog = tmp.ToString();
        }
        #endregion

        #region GetShaderInfoLog
        /// <summary>
        /// Returns the information log for a shader object.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="maxLength">The size of the buffer used to retrieve <paramref name="infoLog"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="infoLog"/>.</param>
        /// <param name="infoLog">Returns the information log.</param>
        [CLSCompliant(false)]
        public static void GetShaderInfoLog(uint shader, int maxLength, out int length, out string infoLog)
        {
            StringBuilder tmp = new StringBuilder(maxLength + 1);
            _GetShaderInfoLog(shader, maxLength + 1, out length, tmp);
            infoLog = tmp.ToString();
        }
        #endregion

        #region GetShaderSource
        /// <summary>
        /// Returns the source code for a shader.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="maxLength">The size of the buffer used to retrieve <paramref name="source"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="source"/>.</param>
        /// <param name="source">Returns the information log.</param>
        [CLSCompliant(false)]
        public static void GetShaderSource(uint shader, int maxLength, out int length, out string source)
        {
            StringBuilder tmp = new StringBuilder(maxLength + 1);
            _GetShaderSource(shader, maxLength + 1, out length, tmp);
            source = tmp.ToString();
        }
        #endregion

        #region GetVertexAttribPointerv
        /// <summary>
        /// Returns the address of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">Must be <see cref="glVertexAttribPointerParameter.VERTEX_ATTRIB_ARRAY_POINTER"/>.</param>
        /// <param name="pointer">Returns a offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ARRAY_BUFFER"/>.</param>
        [CLSCompliant(false)]
        public static void GetVertexAttribPointerv(uint index, VertexAttribPointerParameter pname, out int pointer)
        {
            if (IntPtr.Size == 4) GetVertexAttribPointerv_32(index, pname, out pointer);
            else
            {
                long lPointer;
                GetVertexAttribPointerv_64(index, pname, out lPointer);
                if (((long)lPointer >> 32) != 0) throw new ArgumentOutOfRangeException("pointer", PlatformWrongTypeErrorString);
                pointer = (int)lPointer;
            }
        }

        /// <summary>
        /// Returns the address of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="pname">Must be <see cref="glVertexAttribPointerParameter.VERTEX_ATTRIB_ARRAY_POINTER"/>.</param>
        /// <param name="pointer">Returns a offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ARRAY_BUFFER"/></param>
        [CLSCompliant(false)]
        public static void GetVertexAttribPointerv(uint index, VertexAttribPointerParameter pname, out long pointer)
        {
            if (IntPtr.Size == 4)
            {
                int iPointer;
                GetVertexAttribPointerv_32(index, pname, out iPointer);
                pointer = iPointer;
            }
            else GetVertexAttribPointerv_64(index, pname, out pointer);
        }
        #endregion

        #region ShaderSource
        /// <summary>
        /// Sets the source code for a shader.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="count">Number of strings (source code lines)</param>
        /// <param name="strings">Array of strings countaining the source code.</param>
        /// <param name="lengths">Array of lengths of the strings in <paramref name="strings"/></param>
        [CLSCompliant(false)]
        public static void ShaderSource(uint shader, int count, string[] strings, int[] lengths)
        {
            _ShaderSource(shader, count, strings, lengths);
        }

        /// <summary>
        /// Sets the source code for a shader.
        /// </summary>
        /// <param name="shader">The name of the shader.</param>
        /// <param name="strings">Array of strings countaining the source code.</param>
        [CLSCompliant(false)]
        public static void ShaderSource(uint shader, params string[] strings)
        {
            _ShaderSource(shader, strings.Length, strings, null);
        }
        #endregion

        #region VertexAttribPointer
        /// <summary>
        /// Sets the address of an array of vertex attributes.
        /// </summary>
        /// <overloads>Sets the address of an array of vertex attributes.</overloads>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="size">Size of the vertex attribute. Can be <see cref="GL.BGRA"/>.</param>
        /// <param name="type">Data type of the vertex attribute data.</param>
        /// <param name="normalized">Set <b>true</b> if data is normalized.</param>
        /// <param name="stride">The byte offset between consecutive vertex attributes.</param>
        /// <param name="pointer">Offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ArrayBuffer"/>.</param>
        [CLSCompliant(false)]
        public static void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, int pointer)
        {
            if (IntPtr.Size == 4) VertexAttribPointer_32(index, size, type, normalized, stride, pointer);
            else VertexAttribPointer_64(index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        /// Sets the address of an array of vertex attributes.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="size">Size of the vertex attribute. Can be <see cref="GL.BGRA"/>.</param>
        /// <param name="type">Data type of the vertex attribute data.</param>
        /// <param name="normalized">Set <b>true</b> if data is normalized.</param>
        /// <param name="stride">The byte offset between consecutive vertex attributes.</param>
        /// <param name="pointer">Offset in bytes into the data store of the buffer bound to <see cref="BufferTarget.ArrayBuffer"/>.</param>
        [CLSCompliant(false)]
        public static void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, long pointer)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)pointer >> 32) != 0) throw new ArgumentOutOfRangeException("pointer", PlatformErrorString);
                VertexAttribPointer_32(index, size, type, normalized, stride, (int)pointer);
            }
            else VertexAttribPointer_64(index, size, type, normalized, stride, pointer);
        }
        #endregion
        #endregion

        private static void Load_VERSION_2_0()
        {
            BlendEquationSeparate = GetAddress<BlendEquationSeparate>("glBlendEquationSeparate");
            DrawBuffers = GetAddress<DrawBuffers>("glDrawBuffers");
            StencilOpSeparate = GetAddress<StencilOpSeparate>("glStencilOpSeparate");
            StencilFuncSeparate = GetAddress<StencilFuncSeparate>("glStencilFuncSeparate");
            StencilMaskSeparate = GetAddress<StencilMaskSeparate>("glStencilMaskSeparate");
            AttachShader = GetAddress<AttachShader>("glAttachShader");
            BindAttribLocation = GetAddress<BindAttribLocation>("glBindAttribLocation");
            CompileShader = GetAddress<CompileShader>("glCompileShader");
            CreateProgram = GetAddress<CreateProgram>("glCreateProgram");
            CreateShader = GetAddress<CreateShader>("glCreateShader");
            DeleteProgram = GetAddress<DeleteProgram>("glDeleteProgram");
            DeleteShader = GetAddress<DeleteShader>("glDeleteShader");
            DetachShader = GetAddress<DetachShader>("glDetachShader");
            DisableVertexAttribArray = GetAddress<DisableVertexAttribArray>("glDisableVertexAttribArray");
            EnableVertexAttribArray = GetAddress<EnableVertexAttribArray>("glEnableVertexAttribArray");
            _GetActiveAttrib = GetAddress<GetActiveAttrib>("glGetActiveAttrib");
            _GetActiveUniform = GetAddress<GetActiveUniform>("glGetActiveUniform");
            GetAttachedShaders = GetAddress<GetAttachedShaders>("glGetAttachedShaders");
            GetAttribLocation = GetAddress<GetAttribLocation>("glGetAttribLocation");
            GetProgrami = GetAddress<GetProgrami>("glGetProgramiv");
            GetProgramiv = GetAddress<GetProgramiv>("glGetProgramiv");
            _GetProgramInfoLog = GetAddress<GetProgramInfoLog>("glGetProgramInfoLog");
            GetShaderi = GetAddress<GetShaderi>("glGetShaderiv");
            GetShaderiv = GetAddress<GetShaderiv>("glGetShaderiv");
            _GetShaderInfoLog = GetAddress<GetShaderInfoLog>("glGetShaderInfoLog");
            _GetShaderSource = GetAddress<GetShaderSource>("glGetShaderSource");
            GetUniformLocation = GetAddress<GetUniformLocation>("glGetUniformLocation");
            GetUniformf = GetAddress<GetUniformf>("glGetUniformfv");
            GetUniformfv = GetAddress<GetUniformfv>("glGetUniformfv");
            GetUniformi = GetAddress<GetUniformi>("glGetUniformiv");
            GetUniformiv = GetAddress<GetUniformiv>("glGetUniformiv");
            GetVertexAttribd = GetAddress<GetVertexAttribd>("glGetVertexAttribdv");
            GetVertexAttribdv = GetAddress<GetVertexAttribdv>("glGetVertexAttribdv");
            GetVertexAttribf = GetAddress<GetVertexAttribf>("glGetVertexAttribfv");
            GetVertexAttribfv = GetAddress<GetVertexAttribfv>("glGetVertexAttribfv");
            GetVertexAttribi = GetAddress<GetVertexAttribi>("glGetVertexAttribiv");
            GetVertexAttribiv = GetAddress<GetVertexAttribiv>("glGetVertexAttribiv");
            IsProgram = GetAddress<IsProgram>("glIsProgram");
            IsShader = GetAddress<IsShader>("glIsShader");
            LinkProgram = GetAddress<LinkProgram>("glLinkProgram");
            _ShaderSource = GetAddress<ShaderSource>("glShaderSource");
            UseProgram = GetAddress<UseProgram>("glUseProgram");
            Uniform1f = GetAddress<Uniform1f>("glUniform1f");
            Uniform2f = GetAddress<Uniform2f>("glUniform2f");
            Uniform3f = GetAddress<Uniform3f>("glUniform3f");
            Uniform4f = GetAddress<Uniform4f>("glUniform4f");
            Uniform1i = GetAddress<Uniform1i>("glUniform1i");
            Uniform2i = GetAddress<Uniform2i>("glUniform2i");
            Uniform3i = GetAddress<Uniform3i>("glUniform3i");
            Uniform4i = GetAddress<Uniform4i>("glUniform4i");
            Uniform1fv = GetAddress<Uniform1fv>("glUniform1fv");
            Uniform2fv = GetAddress<Uniform2fv>("glUniform2fv");
            Uniform3fv = GetAddress<Uniform3fv>("glUniform3fv");
            Uniform4fv = GetAddress<Uniform4fv>("glUniform4fv");
            Uniform1iv = GetAddress<Uniform1iv>("glUniform1iv");
            Uniform2iv = GetAddress<Uniform2iv>("glUniform2iv");
            Uniform3iv = GetAddress<Uniform3iv>("glUniform3iv");
            Uniform4iv = GetAddress<Uniform4iv>("glUniform4iv");
            UniformMatrix2fv = GetAddress<UniformMatrix2fv>("glUniformMatrix2fv");
            UniformMatrix3fv = GetAddress<UniformMatrix3fv>("glUniformMatrix3fv");
            UniformMatrix4fv = GetAddress<UniformMatrix4fv>("glUniformMatrix4fv");
            ValidateProgram = GetAddress<ValidateProgram>("glValidateProgram");
            VertexAttrib1d = GetAddress<VertexAttrib1d>("glVertexAttrib1d");
            VertexAttrib1dv = GetAddress<VertexAttrib1dv>("glVertexAttrib1dv");
            VertexAttrib1f = GetAddress<VertexAttrib1f>("glVertexAttrib1f");
            VertexAttrib1fv = GetAddress<VertexAttrib1fv>("glVertexAttrib1fv");
            VertexAttrib1s = GetAddress<VertexAttrib1s>("glVertexAttrib1s");
            VertexAttrib1sv = GetAddress<VertexAttrib1sv>("glVertexAttrib1sv");
            VertexAttrib2d = GetAddress<VertexAttrib2d>("glVertexAttrib2d");
            VertexAttrib2dv = GetAddress<VertexAttrib2dv>("glVertexAttrib2dv");
            VertexAttrib2f = GetAddress<VertexAttrib2f>("glVertexAttrib2f");
            VertexAttrib2fv = GetAddress<VertexAttrib2fv>("glVertexAttrib2fv");
            VertexAttrib2s = GetAddress<VertexAttrib2s>("glVertexAttrib2s");
            VertexAttrib2sv = GetAddress<VertexAttrib2sv>("glVertexAttrib2sv");
            VertexAttrib3d = GetAddress<VertexAttrib3d>("glVertexAttrib3d");
            VertexAttrib3dv = GetAddress<VertexAttrib3dv>("glVertexAttrib3dv");
            VertexAttrib3f = GetAddress<VertexAttrib3f>("glVertexAttrib3f");
            VertexAttrib3fv = GetAddress<VertexAttrib3fv>("glVertexAttrib3fv");
            VertexAttrib3s = GetAddress<VertexAttrib3s>("glVertexAttrib3s");
            VertexAttrib3sv = GetAddress<VertexAttrib3sv>("glVertexAttrib3sv");
            VertexAttrib4Nbv = GetAddress<VertexAttrib4Nbv>("glVertexAttrib4Nbv");
            VertexAttrib4Niv = GetAddress<VertexAttrib4Niv>("glVertexAttrib4Niv");
            VertexAttrib4Nsv = GetAddress<VertexAttrib4Nsv>("glVertexAttrib4Nsv");
            VertexAttrib4Nub = GetAddress<VertexAttrib4Nub>("glVertexAttrib4Nub");
            VertexAttrib4Nubv = GetAddress<VertexAttrib4Nubv>("glVertexAttrib4Nubv");
            VertexAttrib4Nuiv = GetAddress<VertexAttrib4Nuiv>("glVertexAttrib4Nuiv");
            VertexAttrib4Nusv = GetAddress<VertexAttrib4Nusv>("glVertexAttrib4Nusv");
            VertexAttrib4bv = GetAddress<VertexAttrib4bv>("glVertexAttrib4bv");
            VertexAttrib4d = GetAddress<VertexAttrib4d>("glVertexAttrib4d");
            VertexAttrib4dv = GetAddress<VertexAttrib4dv>("glVertexAttrib4dv");
            VertexAttrib4f = GetAddress<VertexAttrib4f>("glVertexAttrib4f");
            VertexAttrib4fv = GetAddress<VertexAttrib4fv>("glVertexAttrib4fv");
            VertexAttrib4iv = GetAddress<VertexAttrib4iv>("glVertexAttrib4iv");
            VertexAttrib4s = GetAddress<VertexAttrib4s>("glVertexAttrib4s");
            VertexAttrib4sv = GetAddress<VertexAttrib4sv>("glVertexAttrib4sv");
            VertexAttrib4ubv = GetAddress<VertexAttrib4ubv>("glVertexAttrib4ubv");
            VertexAttrib4uiv = GetAddress<VertexAttrib4uiv>("glVertexAttrib4uiv");
            VertexAttrib4usv = GetAddress<VertexAttrib4usv>("glVertexAttrib4usv");

            bool platformDependend;
            if (IntPtr.Size == 4)
            {
                GetVertexAttribPointerv_32 = GetAddress<GetVertexAttribPointerv_32>("glGetVertexAttribPointerv");
                VertexAttribPointer_32 = GetAddress<VertexAttribPointer_32>("glVertexAttribPointer");

                platformDependend = GetVertexAttribPointerv_32 != null && VertexAttribPointer_32 != null;
            }
            else
            {
                GetVertexAttribPointerv_64 = GetAddress<GetVertexAttribPointerv_64>("glGetVertexAttribPointerv");
                VertexAttribPointer_64 = GetAddress<VertexAttribPointer_64>("glVertexAttribPointer");

                platformDependend = GetVertexAttribPointerv_64 != null && VertexAttribPointer_64 != null;
            }

            VERSION_2_0 = VERSION_1_5 && BlendEquationSeparate != null && DrawBuffers != null && StencilOpSeparate != null &&
                StencilFuncSeparate != null && StencilMaskSeparate != null && AttachShader != null &&
                BindAttribLocation != null && CompileShader != null && CreateProgram != null &&
                CreateShader != null && DeleteProgram != null && DeleteShader != null &&
                DetachShader != null && DisableVertexAttribArray != null && EnableVertexAttribArray != null &&
                _GetActiveAttrib != null && _GetActiveUniform != null && GetAttachedShaders != null &&
                GetAttribLocation != null && GetProgramiv != null && _GetProgramInfoLog != null &&
                GetShaderiv != null && _GetShaderInfoLog != null && _GetShaderSource != null &&
                GetUniformLocation != null && GetUniformfv != null && GetUniformiv != null &&
                GetVertexAttribdv != null && GetVertexAttribfv != null && GetVertexAttribiv != null &&
                IsProgram != null && IsShader != null && LinkProgram != null && _ShaderSource != null &&
                UseProgram != null && Uniform4f != null && Uniform4i != null && Uniform4fv != null &&
                Uniform4iv != null && UniformMatrix4fv != null && ValidateProgram != null &&
                VertexAttrib1dv != null && VertexAttrib2dv != null && VertexAttrib3dv != null &&
                VertexAttrib4dv != null && VertexAttrib4Niv != null && platformDependend;
        }
    }
}
