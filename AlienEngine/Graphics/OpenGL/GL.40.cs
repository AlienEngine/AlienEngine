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
        /// Sets the minimum rate at which sample shaing takes place.
        /// </summary>
        /// <param name="value">The rate at which samples are shaded within each covered pixel.</param>
        public delegate void MinSampleShading(float value);

        /// <summary>
        /// Sets the equation for blending of color and alpha values.
        /// </summary>
        /// <param name="buf">The index of the draw buffer.</param>
        /// <param name="mode">A <see cref="BlendEquationMode"/> specifying the blend equation.</param>
        [CLSCompliant(false)]
        public delegate void BlendEquationi(uint buf, BlendEquationMode mode);

        /// <summary>
        /// Sets the blend equation separately for color and alpha.
        /// </summary>
        /// <param name="buf">The index of the draw buffer.</param>
        /// <param name="modeRGB">A <see cref="BlendEquationMode"/> specifying the color blend equation.</param>
        /// <param name="modeAlpha">A <see cref="BlendEquationMode"/> specifying the alpha blend equation.</param>
        [CLSCompliant(false)]
        public delegate void BlendEquationSeparatei(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha);

        /// <summary>
        /// Sets the blend function factors.
        /// </summary>
        /// <param name="buf">The index of the draw buffer.</param>
        /// <param name="sfactor">Factor to the source value.</param>
        /// <param name="dfactor">Factor to the destination value.</param>
        [CLSCompliant(false)]
        public delegate void BlendFunci(uint buf, BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

        /// <summary>
        /// Sets the blend function factors separately for color and alpha.
        /// </summary>
        /// <param name="buf">The index of the draw buffer.</param>
        /// <param name="srcRGB">Factor to the source color value.</param>
        /// <param name="dstRGB">Factor to the destination color value.</param>
        /// <param name="srcAlpha">Factor to the source alpha value.</param>
        /// <param name="dstAlpha">Factor to the destination alpha value.</param>
        [CLSCompliant(false)]
        public delegate void BlendFuncSeparatei(uint buf, BlendingFactorSrc srcRGB, BlendingFactorDest dstRGB, BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha);

        /// <summary>
        /// Renders primitives from array, taking parameters from memory.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to be rendered.</param>
        /// <param name="indirect">The structure containing the draw parameters. (<b>ref</b> for <c>const DrawArraysIndirectCommand*</c>)</param>
        public delegate void DrawArraysIndirect(BeginMode mode, ref DrawArraysIndirectCommand indirect);

        /// <summary>
        /// Renders primitives from array via indices, taking parameters from memory.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitive to render.</param>
        /// <param name="type">A <see cref="DrawElementsType"/> specifying the data type of the indices.</param>
        /// <param name="indirect">The structure containing the draw parameters. (<b>ref</b> for <c>const DrawElementsIndirectCommand*</c>)</param>
        public delegate void DrawElementsIndirect(BeginMode mode, DrawElementsType type, ref DrawElementsIndirectCommand indirect);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="x">The value to set.</param>
        public delegate void Uniform1d(int location, double x);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="x">First value of a tuple to set.</param>
        /// <param name="y">Second value of a tuple to set.</param>
        public delegate void Uniform2d(int location, double x, double y);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="x">First value of a tuple to set.</param>
        /// <param name="y">Second value of a tuple to set.</param>
        /// <param name="z">Third value of a tuple to set.</param>
        public delegate void Uniform3d(int location, double x, double y, double z);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="x">First value of a tuple to set.</param>
        /// <param name="y">Second value of a tuple to set.</param>
        /// <param name="z">Third value of a tuple to set.</param>
        /// <param name="w">Fourth value of a tuple to set.</param>
        public delegate void Uniform4d(int location, double x, double y, double z, double w);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform1dv(int location, int count, double[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform2dv(int location, int count, double[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform3dv(int location, int count, double[] value);

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">The number of values to be set. (>1 if uniform is an array)</param>
        /// <param name="value">The value(s) to set.</param>
        public delegate void Uniform4dv(int location, int count, double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix2x3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix2x4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix3x2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix3x4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix4x2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        /// <param name="location">The location of the uniform.</param>
        /// <param name="count">Number of matrices to be loaded. (>1 if uniform is array of matrices)</param>
        /// <param name="transpose">Set <b>true</b> if the matrix is to be transposed.</param>
        /// <param name="value">The values of the matrix.</param>
        public delegate void UniformMatrix4x3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, params double[] value);

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="param">The value of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformd(uint program, int location, out double param);

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="location">The location of the uniform variable inside the program object.</param>
        /// <param name="params">The value(s) of the uniform variable.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformdv(uint program, int location, double[] @params);

        /// <summary>
        /// Returns the location of a shader subroutine.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="name">The name of the subroutine.</param>
        /// <returns>The location of a subroutine uniform.</returns>
        [CLSCompliant(false)]
        public delegate int GetSubroutineUniformLocation(uint program, ShaderType shadertype, string name);

        /// <summary>
        /// Returns the index of a shader subroutine.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="name">The name of the subroutine.</param>
        /// <returns>The index of a subroutine.</returns>
        [CLSCompliant(false)]
        public delegate uint GetSubroutineIndex(uint program, ShaderType shadertype, string name);

        /// <summary>
        /// Returns the value of a parameter of an active shader subroutine uniform.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="index">The location of the active shader subroutine uniform.</param>
        /// <param name="pname">A <see cref="glSubroutineUniformParameter"/> specifying the parameter.</param>
        /// <param name="value">The requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetActiveSubroutineUniformi(uint program, ShaderType shadertype, uint index, ActiveSubroutineUniformParameter pname, out int value);

        /// <summary>
        /// Returns the value(s) of a parameter of an active shader subroutine uniform.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="index">The location of the active shader subroutine uniform.</param>
        /// <param name="pname">A <see cref="glSubroutineUniformParameter"/> specifying the parameter.</param>
        /// <param name="values">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetActiveSubroutineUniformiv(uint program, ShaderType shadertype, uint index, ActiveSubroutineUniformParameter pname, int[] values);

        internal delegate void GetActiveSubroutineUniformName(uint program, ShaderType shadertype, uint index, int bufsize, out int length, StringBuilder name);
        internal delegate void GetActiveSubroutineName(uint program, ShaderType shadertype, uint index, int bufsize, out int length, StringBuilder name);

        /// <summary>
        /// Loads indices into the active subroutine's uniforms.
        /// </summary>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="count">The number of indices to load.</param>
        /// <param name="indices">The array of indices.</param>
        [CLSCompliant(false)]
        public delegate void UniformSubroutinesuiv(ShaderType shadertype, int count, params uint[] indices);

        /// <summary>
        /// Returns the value of a subroutine uniform of a given shader stage of the current program.
        /// </summary>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="location">The location of the subroutine uniform.</param>
        /// <param name="value">The requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetUniformSubroutineui(ShaderType shadertype, int location, out uint value);

        /// <summary>
        /// Returns the value(s) of a subroutine uniform of a given shader stage of the current program.
        /// </summary>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="location">The location of the subroutine uniform.</param>
        /// <param name="values">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetUniformSubroutineuiv(ShaderType shadertype, int location, uint[] values);

        /// <summary>
        /// Returns the value of parameter of a program shader stage.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the shader stage.</param>
        /// <param name="pname">A <see cref="glProgramStageParameter"/> specifying the parameter.</param>
        /// <param name="value">The requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetProgramStagei(uint program, ShaderType shadertype, ProgramStageParameter pname, out int value);

        /// <summary>
        /// Returns the value(s) of parameter of a program shader stage.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the shader stage.</param>
        /// <param name="pname">A <see cref="glProgramStageParameter"/> specifying the parameter.</param>
        /// <param name="values">The requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetProgramStageiv(uint program, ShaderType shadertype, ProgramStageParameter pname, int[] values);

        /// <summary>
        /// Sets patch parameters.
        /// </summary>
        /// <param name="pname">A <see cref="glPatchParameter"/> specifying the parameter.</param>
        /// <param name="value">The value to set.</param>
        public delegate void PatchParameteri(PatchParameterInt pname, int value);

        /// <summary>
        /// Sets patch parameters.
        /// </summary>
        /// <param name="pname">A <see cref="glPatchParameter"/> specifying the parameter.</param>
        /// <param name="values">The values to set.</param>
        public delegate void PatchParameterfv(PatchParameterFloat pname, float[] values);

        /// <summary>
        /// Binds a transform feedback object.
        /// </summary>
        /// <param name="target">Must be <see cref="glTransformFeedbackTarget.TRANSFORM_FEEDBACK"/>.</param>
        /// <param name="id">The name of the transform feedback object.</param>
        [CLSCompliant(false)]
        public delegate void BindTransformFeedback(TransformFeedbackTarget target, uint id);

        /// <summary>
        /// Releases <paramref name="count"/> many transform feedback object names.
        /// </summary>
        /// <param name="count">Number of transform feedback object names to be released.</param>
        /// <param name="ids">Array of transform feedback object names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteTransformFeedbacks(int count, params uint[] ids);

        internal delegate void GenTransformFeedback(int one, out uint id);
        internal delegate void GenTransformFeedbacks(int count, uint[] ids);

        /// <summary>
        /// Determines if a name is a transform feedback object name.
        /// </summary>
        /// <param name="id">The maybe transform feedback object name.</param>
        /// <returns><b>true</b> if <paramref name="id"/> is a transform feedback object name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsTransformFeedback(uint id);

        /// <summary>
        /// Pauses transform feedback operations.
        /// </summary>
        public delegate void PauseTransformFeedback();

        /// <summary>
        /// Resumes transform feedback operations.
        /// </summary>
        public delegate void ResumeTransformFeedback();

        /// <summary>
        /// Renders primitives using the count derived from transform feedback objects.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitives to render.</param>
        /// <param name="id">The name of the transform feedback object.</param>
        [CLSCompliant(false)]
        public delegate void DrawTransformFeedback(BeginMode mode, uint id);

        /// <summary>
        /// Renders primitives using the count derived from a specific stream of transform feedback objects.
        /// </summary>
        /// <param name="mode">A <see cref="BeginMode"/> specifying the type of primitives to render.</param>
        /// <param name="id">The name of the transform feedback object.</param>
        /// <param name="stream">The index of the stream.</param>
        [CLSCompliant(false)]
        public delegate void DrawTransformFeedbackStream(BeginMode mode, uint id, uint stream);

        /// <summary>
        /// Delimits the boundary of a query object on an indexed target.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="index">The index of the indexed target.</param>
        /// <param name="id">The query-ID to be used.</param>
        [CLSCompliant(false)]
        public delegate void BeginQueryIndexed(QueryTarget target, uint index, uint id);

        /// <summary>
        /// Delimits the boundary of a query object on an indexed target.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="index">The index of the indexed target.</param>
        [CLSCompliant(false)]
        public delegate void EndQueryIndexed(QueryTarget target, uint index);

        /// <summary>
        /// Returns the parameters of a query type on an indexed target.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="index">The index of the indexed target.</param>
        /// <param name="pname">A <see cref="GetQueryParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetQueryIndexedi(QueryTarget target, uint index, GetQueryParam pname, out int param);

        /// <summary>
        /// Returns the parameters of a query type on an indexed target.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="index">The index of the indexed target.</param>
        /// <param name="pname">A <see cref="GetQueryParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetQueryIndexediv(QueryTarget target, uint index, GetQueryParam pname, int[] @params);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 4.0 is available.
        /// </summary>
        public static bool VERSION_4_0;

        #region Delegates
        /// <summary>
        /// Sets the minimum rate at which sample shaing takes place.
        /// </summary>
        public static MinSampleShading MinSampleShading;

        /// <summary>
        /// Sets the equation for blending of color and alpha values.
        /// </summary>
        [CLSCompliant(false)]
        public static BlendEquationi BlendEquationi;

        /// <summary>
        /// Sets the blend equation separately for color and alpha.
        /// </summary>
        [CLSCompliant(false)]
        public static BlendEquationSeparatei BlendEquationSeparatei;

        /// <summary>
        /// Sets the blend function factors.
        /// </summary>
        [CLSCompliant(false)]
        public static BlendFunci BlendFunci;

        /// <summary>
        /// Sets the blend function factors separately for color and alpha.
        /// </summary>
        [CLSCompliant(false)]
        public static BlendFuncSeparatei BlendFuncSeparatei;

        /// <summary>
        /// Renders primitives from array, taking parameters from memory.
        /// </summary>
        public static DrawArraysIndirect DrawArraysIndirect;

        /// <summary>
        /// Renders primitives from array via indices, taking parameters from memory.
        /// </summary>
        public static DrawElementsIndirect DrawElementsIndirect;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1d Uniform1d;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2d Uniform2d;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3d Uniform3d;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4d Uniform4d;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform1dv Uniform1dv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform2dv Uniform2dv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform3dv Uniform3dv;

        /// <summary>
        /// Sets a uniform value.
        /// </summary>
        public static Uniform4dv Uniform4dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix2dv UniformMatrix2dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix3dv UniformMatrix3dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix4dv UniformMatrix4dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix2x3dv UniformMatrix2x3dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix2x4dv UniformMatrix2x4dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix3x2dv UniformMatrix3x2dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix3x4dv UniformMatrix3x4dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix4x2dv UniformMatrix4x2dv;

        /// <summary>
        /// Sets a uniform matrix value.
        /// </summary>
        public static UniformMatrix4x3dv UniformMatrix4x3dv;

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformd GetUniformd;

        /// <summary>
        /// Returns the value(s) of a uniform variable.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformdv GetUniformdv;

        /// <summary>
        /// Returns the location of a shader subroutine.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSubroutineUniformLocation GetSubroutineUniformLocation;

        /// <summary>
        /// Returns the index of a shader subroutine.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSubroutineIndex GetSubroutineIndex;

        /// <summary>
        /// Returns the value of a parameter of an active shader subroutine uniform.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveSubroutineUniformi GetActiveSubroutineUniformi;

        /// <summary>
        /// Returns the value(s) of a parameter of an active shader subroutine uniform.
        /// </summary>
        [CLSCompliant(false)]
        public static GetActiveSubroutineUniformiv GetActiveSubroutineUniformiv;

        private static GetActiveSubroutineUniformName _GetActiveSubroutineUniformName;
        private static GetActiveSubroutineName _GetActiveSubroutineName;

        /// <summary>
        /// Loads indices into the active subroutine's uniforms.
        /// </summary>
        [CLSCompliant(false)]
        public static UniformSubroutinesuiv UniformSubroutinesuiv;

        /// <summary>
        /// Returns the value of a subroutine uniform of a given shader stage of the current program.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformSubroutineui GetUniformSubroutineui;

        /// <summary>
        /// Returns the value(s) of a subroutine uniform of a given shader stage of the current program.
        /// </summary>
        [CLSCompliant(false)]
        public static GetUniformSubroutineuiv GetUniformSubroutineuiv;

        /// <summary>
        /// Returns the value of parameter of a program shader stage.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramStagei GetProgramStagei;

        /// <summary>
        /// Returns the value(s) of parameter of a program shader stage.
        /// </summary>
        [CLSCompliant(false)]
        public static GetProgramStageiv GetProgramStageiv;

        /// <summary>
        /// Sets patch parameters.
        /// </summary>
        public static PatchParameteri PatchParameteri;

        /// <summary>
        /// Sets patch parameters.
        /// </summary>
        public static PatchParameterfv PatchParameterfv;

        /// <summary>
        /// Binds a transform feedback object.
        /// </summary>
        [CLSCompliant(false)]
        public static BindTransformFeedback BindTransformFeedback;

        /// <summary>
        /// Releases multiple transform feedback object names at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteTransformFeedbacks DeleteTransformFeedbacks;

        private static GenTransformFeedback _GenTransformFeedback;
        private static GenTransformFeedbacks _GenTransformFeedbacks;

        /// <summary>
        /// Determines if a name is a transform feedback object name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsTransformFeedback IsTransformFeedback;

        /// <summary>
        /// Pauses transform feedback operations.
        /// </summary>
        public static PauseTransformFeedback PauseTransformFeedback;

        /// <summary>
        /// Resumes transform feedback operations.
        /// </summary>
        public static ResumeTransformFeedback ResumeTransformFeedback;

        /// <summary>
        /// Renders primitives using the count derived from transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static DrawTransformFeedback DrawTransformFeedback;

        /// <summary>
        /// Renders primitives using the count derived from a specific stream of transform feedback objects.
        /// </summary>
        [CLSCompliant(false)]
        public static DrawTransformFeedbackStream DrawTransformFeedbackStream;

        /// <summary>
        /// Delimits the boundary of a query object on an indexed target.
        /// </summary>
        [CLSCompliant(false)]
        public static BeginQueryIndexed BeginQueryIndexed;

        /// <summary>
        /// Delimits the boundary of a query object on an indexed target.
        /// </summary>
        [CLSCompliant(false)]
        public static EndQueryIndexed EndQueryIndexed;

        /// <summary>
        /// Returns the parameters of a query type on an indexed target.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryIndexedi GetQueryIndexedi;

        /// <summary>
        /// Returns the parameters of a query type on an indexed target.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryIndexediv GetQueryIndexediv;
        #endregion

        #region Overloads
        #region GetActiveSubroutineUniformName
        /// <summary>
        /// Returns the name of an active shader subroutine uniform.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="index">The index of the shader subroutine uniform.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="name">Returns the name of the shader subroutine uniform.</param>
        [CLSCompliant(false)]
        public static void GetActiveSubroutineUniformName(uint program, ShaderType shadertype, uint index, int bufSize, out int length, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveSubroutineUniformName(program, shadertype, index, bufSize + 1, out length, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region GetActiveSubroutineName
        /// <summary>
        /// Returns the name of an active shader subroutine.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="shadertype">A <see cref="glShaderType"/> specifying the type of the shader.</param>
        /// <param name="index">The index of the shader subroutine.</param>
        /// <param name="bufSize">The size of the buffer used to retrieve <paramref name="name"/>.</param>
        /// <param name="length">Returns the actual length of the result in <paramref name="name"/>.</param>
        /// <param name="name">Returns the name of the shader subroutine.</param>
        [CLSCompliant(false)]
        public static void GetActiveSubroutineName(uint program, ShaderType shadertype, uint index, int bufSize, out int length, out string name)
        {
            StringBuilder tmp = new StringBuilder(bufSize + 1);
            _GetActiveSubroutineName(program, shadertype, index, bufSize + 1, out length, tmp);
            name = tmp.ToString();
        }
        #endregion

        #region GenTransformFeedback(s)
        /// <summary>
        /// Generates one transform feedback object name and returns it.
        /// </summary>
        /// <returns>The new transform feedback object name.</returns>
        [CLSCompliant(false)]
        public static uint GenTransformFeedback()
        {
            uint ret;
            _GenTransformFeedback(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one transform feedback object name and returns it.
        /// </summary>
        /// <param name="id">The new transform feedback object name.</param>
        [CLSCompliant(false)]
        public static void GenTransformFeedback(out uint id)
        {
            _GenTransformFeedback(1, out id);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many transform feedback object names and returns them as array.
        /// </summary>
        /// <param name="count">The number of transform feedback object names to be generated.</param>
        /// <returns>The new transform feedback object names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenTransformFeedbacks(int count)
        {
            uint[] ret = new uint[count];
            _GenTransformFeedbacks(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many transform feedback object names.
        /// </summary>
        /// <param name="count">The number of transform feedback object names to be generated.</param>
        /// <param name="ids">The array that will receive the new transform feedback object names.</param>
        [CLSCompliant(false)]
        public static void GenTransformFeedbacks(int count, uint[] ids)
        {
            _GenTransformFeedbacks(count, ids);
        }
        #endregion
        #endregion

        private static void Load_VERSION_4_0()
        {
            MinSampleShading = GetAddress<MinSampleShading>("glMinSampleShading");
            BlendEquationi = GetAddress<BlendEquationi>("glBlendEquationi");
            BlendEquationSeparatei = GetAddress<BlendEquationSeparatei>("glBlendEquationSeparatei");
            BlendFunci = GetAddress<BlendFunci>("glBlendFunci");
            BlendFuncSeparatei = GetAddress<BlendFuncSeparatei>("glBlendFuncSeparatei");
            DrawArraysIndirect = GetAddress<DrawArraysIndirect>("glDrawArraysIndirect");
            DrawElementsIndirect = GetAddress<DrawElementsIndirect>("glDrawElementsIndirect");
            Uniform1d = GetAddress<Uniform1d>("glUniform1d");
            Uniform2d = GetAddress<Uniform2d>("glUniform2d");
            Uniform3d = GetAddress<Uniform3d>("glUniform3d");
            Uniform4d = GetAddress<Uniform4d>("glUniform4d");
            Uniform1dv = GetAddress<Uniform1dv>("glUniform1dv");
            Uniform2dv = GetAddress<Uniform2dv>("glUniform2dv");
            Uniform3dv = GetAddress<Uniform3dv>("glUniform3dv");
            Uniform4dv = GetAddress<Uniform4dv>("glUniform4dv");
            UniformMatrix2dv = GetAddress<UniformMatrix2dv>("glUniformMatrix2dv");
            UniformMatrix3dv = GetAddress<UniformMatrix3dv>("glUniformMatrix3dv");
            UniformMatrix4dv = GetAddress<UniformMatrix4dv>("glUniformMatrix4dv");
            UniformMatrix2x3dv = GetAddress<UniformMatrix2x3dv>("glUniformMatrix2x3dv");
            UniformMatrix2x4dv = GetAddress<UniformMatrix2x4dv>("glUniformMatrix2x4dv");
            UniformMatrix3x2dv = GetAddress<UniformMatrix3x2dv>("glUniformMatrix3x2dv");
            UniformMatrix3x4dv = GetAddress<UniformMatrix3x4dv>("glUniformMatrix3x4dv");
            UniformMatrix4x2dv = GetAddress<UniformMatrix4x2dv>("glUniformMatrix4x2dv");
            UniformMatrix4x3dv = GetAddress<UniformMatrix4x3dv>("glUniformMatrix4x3dv");
            GetUniformd = GetAddress<GetUniformd>("glGetUniformdv");
            GetUniformdv = GetAddress<GetUniformdv>("glGetUniformdv");
            GetSubroutineUniformLocation = GetAddress<GetSubroutineUniformLocation>("glGetSubroutineUniformLocation");
            GetSubroutineIndex = GetAddress<GetSubroutineIndex>("glGetSubroutineIndex");
            GetActiveSubroutineUniformi = GetAddress<GetActiveSubroutineUniformi>("glGetActiveSubroutineUniformiv");
            GetActiveSubroutineUniformiv = GetAddress<GetActiveSubroutineUniformiv>("glGetActiveSubroutineUniformiv");
            _GetActiveSubroutineUniformName = GetAddress<GetActiveSubroutineUniformName>("glGetActiveSubroutineUniformName");
            _GetActiveSubroutineName = GetAddress<GetActiveSubroutineName>("glGetActiveSubroutineName");
            UniformSubroutinesuiv = GetAddress<UniformSubroutinesuiv>("glUniformSubroutinesuiv");
            GetUniformSubroutineui = GetAddress<GetUniformSubroutineui>("glGetUniformSubroutineuiv");
            GetUniformSubroutineuiv = GetAddress<GetUniformSubroutineuiv>("glGetUniformSubroutineuiv");
            GetProgramStagei = GetAddress<GetProgramStagei>("glGetProgramStageiv");
            GetProgramStageiv = GetAddress<GetProgramStageiv>("glGetProgramStageiv");
            PatchParameteri = GetAddress<PatchParameteri>("glPatchParameteri");
            PatchParameterfv = GetAddress<PatchParameterfv>("glPatchParameterfv");
            BindTransformFeedback = GetAddress<BindTransformFeedback>("glBindTransformFeedback");
            DeleteTransformFeedbacks = GetAddress<DeleteTransformFeedbacks>("glDeleteTransformFeedbacks");
            _GenTransformFeedback = GetAddress<GenTransformFeedback>("glGenTransformFeedbacks");
            _GenTransformFeedbacks = GetAddress<GenTransformFeedbacks>("glGenTransformFeedbacks");
            IsTransformFeedback = GetAddress<IsTransformFeedback>("glIsTransformFeedback");
            PauseTransformFeedback = GetAddress<PauseTransformFeedback>("glPauseTransformFeedback");
            ResumeTransformFeedback = GetAddress<ResumeTransformFeedback>("glResumeTransformFeedback");
            DrawTransformFeedback = GetAddress<DrawTransformFeedback>("glDrawTransformFeedback");
            DrawTransformFeedbackStream = GetAddress<DrawTransformFeedbackStream>("glDrawTransformFeedbackStream");
            BeginQueryIndexed = GetAddress<BeginQueryIndexed>("glBeginQueryIndexed");
            EndQueryIndexed = GetAddress<EndQueryIndexed>("glEndQueryIndexed");
            GetQueryIndexedi = GetAddress<GetQueryIndexedi>("glGetQueryIndexediv");
            GetQueryIndexediv = GetAddress<GetQueryIndexediv>("glGetQueryIndexediv");

            VERSION_4_0 = VERSION_3_3 && MinSampleShading != null && BlendEquationi != null && BlendEquationSeparatei != null &&
                BlendFunci != null && BlendFuncSeparatei != null && DrawArraysIndirect != null && DrawElementsIndirect != null &&
                Uniform1d != null && Uniform2d != null && Uniform3d != null && Uniform4d != null &&
                Uniform1dv != null && Uniform2dv != null && Uniform3dv != null && Uniform4dv != null &&
                UniformMatrix2dv != null && UniformMatrix3dv != null && UniformMatrix4dv != null &&
                UniformMatrix2x3dv != null && UniformMatrix2x4dv != null && UniformMatrix3x2dv != null &&
                UniformMatrix3x4dv != null && UniformMatrix4x2dv != null && UniformMatrix4x3dv != null &&
                GetUniformdv != null && GetSubroutineUniformLocation != null && GetSubroutineIndex != null &&
                GetActiveSubroutineUniformiv != null && _GetActiveSubroutineUniformName != null &&
                _GetActiveSubroutineName != null && UniformSubroutinesuiv != null && GetUniformSubroutineuiv != null &&
                GetProgramStageiv != null && PatchParameteri != null && PatchParameterfv != null &&
                BindTransformFeedback != null && DeleteTransformFeedbacks != null && _GenTransformFeedbacks != null &&
                IsTransformFeedback != null && PauseTransformFeedback != null && ResumeTransformFeedback != null &&
                DrawTransformFeedback != null && DrawTransformFeedbackStream != null && BeginQueryIndexed != null &&
                EndQueryIndexed != null && GetQueryIndexediv != null;
        }
    }
}
