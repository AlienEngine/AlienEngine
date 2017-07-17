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
        /// Binds a varying output variable to a fragment shader color number and index.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="colorNumber">The color number to bind the varying output variable to.</param>
        /// <param name="index">The index of the color input to bind the varying output variable to.</param>
        /// <param name="name">The name of the varing output variable.</param>
        [CLSCompliant(false)]
        public delegate void BindFragDataLocationIndexed(uint program, uint colorNumber, uint index, string name);

        /// <summary>
        /// Returns the color indices of varying output variables.
        /// </summary>
        /// <param name="program">The name of the program.</param>
        /// <param name="name">The name of the varing output variable.</param>
        /// <returns>The color index.</returns>
        [CLSCompliant(false)]
        public delegate int GetFragDataIndex(uint program, string name);

        internal delegate void GenSampler(int one, out uint sampler);
        internal delegate void GenSamplers(int count, uint[] samplers);

        /// <summary>
        /// Releases <paramref name="count"/> many sampler names.
        /// </summary>
        /// <param name="count">Number of sampler names to be released.</param>
        /// <param name="samplers">Array of sampler names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteSamplers(int count, params uint[] samplers);

        /// <summary>
        /// Determines if a name is a sampler name.
        /// </summary>
        /// <param name="sampler">The maybe sampler name.</param>
        /// <returns><b>true</b> if <paramref name="sampler"/> is a sampler name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsSampler(uint sampler);

        /// <summary>
        /// Binds a sampler to a texturing unit.
        /// </summary>
        /// <param name="unit">The texture unit.</param>
        /// <param name="sampler">The name of the sampler.</param>
        [CLSCompliant(false)]
        public delegate void BindSampler(uint unit, uint sampler);

        internal delegate void SamplerParameteri(uint sampler, SamplerParameterName pname, int param);

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void SamplerParameteriv(uint sampler, SamplerParameterName pname, int[] @params);

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void SamplerParameterf(uint sampler, SamplerParameterName pname, float param);

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void SamplerParameterfv(uint sampler, SamplerParameterName pname, float[] @params);

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void SamplerParameterIiv(uint sampler, SamplerParameterName pname, params int[] @params);

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public delegate void SamplerParameterIuiv(uint sampler, SamplerParameterName pname, params uint[] @params);

        internal delegate void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameteriv(uint sampler, SamplerParameterName pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterIi(uint sampler, SamplerParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterIiv(uint sampler, SamplerParameterName pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterf(uint sampler, SamplerParameterName pname, out float param);

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterfv(uint sampler, SamplerParameterName pname, float[] @params);

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterIui(uint sampler, SamplerParameterName pname, out uint param);

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetSamplerParameterIuiv(uint sampler, SamplerParameterName pname, uint[] @params);

        /// <summary>
        /// Records the GL time into a query object after all previous commands have reached the GL server but have not yet necessarily executed.
        /// </summary>
        /// <param name="id">The name of the query object into which to record.</param>
        /// <param name="target">Must by <see cref="QueryTarget.Timestamp"/></param>
        [CLSCompliant(false)]
        public delegate void QueryCounter(uint id, QueryTarget target);

        /// <summary>
        /// Returns the value of parameters of query objects.
        /// </summary>
        /// <param name="id">The name of the query object.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetQueryObjecti64(uint id, GetQueryObjectParam pname, out long param);

        /// <summary>
        /// Returns the value(s) of parameters of query objects.
        /// </summary>
        /// <param name="id">The name of the query object.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetQueryObjecti64v(uint id, GetQueryObjectParam pname, long[] @params);

        /// <summary>
        /// Returns the value of parameters of query objects.
        /// </summary>
        /// <param name="id">The name of the query object.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetQueryObjectui64(uint id, GetQueryObjectParam pname, out ulong param);

        /// <summary>
        /// Returns the value(s) of parameters of query objects.
        /// </summary>
        /// <param name="id">The name of the query object.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [CLSCompliant(false)]
        public delegate void GetQueryObjectui64v(uint id, GetQueryObjectParam pname, ulong[] @params);

        /// <summary>
        /// Sets the rate at which vertex attributes advance during instanced rendering.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="divisor">The number of instances that will pass between updates.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribDivisor(uint index, uint divisor);

        /// <summary>
        /// Sets the value of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed value.</param>
        /// <param name="normalized">Set <b>true</b> if the value are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP1ui(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint value);

        /// <summary>
        /// Sets the value of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed value.</param>
        /// <param name="normalized">Set <b>true</b> if the value are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The value to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP1uiv(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint[] value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP2ui(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP2uiv(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint[] value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP3ui(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP3uiv(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint[] value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP4ui(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint value);

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        /// <param name="index">The index of the vertex attribute.</param>
        /// <param name="type">A <see cref="glVertexAttribType"/> specifying the data type of the packed values.</param>
        /// <param name="normalized">Set <b>true</b> if the values are to be normalized on conversion to floating-point.</param>
        /// <param name="value">The values to set.</param>
        [CLSCompliant(false)]
        public delegate void VertexAttribP4uiv(uint index, VertexAttribType type, [MarshalAs(UnmanagedType.I1)] bool normalized, uint[] value);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 3.3 is available.
        /// </summary>
        public static bool VERSION_3_3;

        #region Delegates
        /// <summary>
        /// Binds a varying output variable to a fragment shader color number and index.
        /// </summary>
        [CLSCompliant(false)]
        public static BindFragDataLocationIndexed BindFragDataLocationIndexed;

        /// <summary>
        /// Returns the color indices of varying output variables.
        /// </summary>
        [CLSCompliant(false)]
        public static GetFragDataIndex GetFragDataIndex;

        private static GenSampler _GenSampler;
        private static GenSamplers _GenSamplers;

        /// <summary>
        /// Releases multiple sampler names at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteSamplers DeleteSamplers;

        /// <summary>
        /// Determines if a name is a sampler name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsSampler IsSampler;

        /// <summary>
        /// Binds a sampler to a texturing unit.
        /// </summary>
        [CLSCompliant(false)]
        public static BindSampler BindSampler;

        private static SamplerParameteri _SamplerParameteri;

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static SamplerParameteriv SamplerParameteriv;

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static SamplerParameterf SamplerParameterf;

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static SamplerParameterfv SamplerParameterfv;

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static SamplerParameterIiv SamplerParameterIiv;

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static SamplerParameterIuiv SamplerParameterIuiv;

        private static GetSamplerParameteri _GetSamplerParameteri;

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameteriv GetSamplerParameteriv;

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterIi GetSamplerParameterIi;

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterIiv GetSamplerParameterIiv;

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterf GetSamplerParameterf;

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterfv GetSamplerParameterfv;

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterIui GetSamplerParameterIui;

        /// <summary>
        /// Returns the value(s) of a texture parameter of a sampler.
        /// </summary>
        [CLSCompliant(false)]
        public static GetSamplerParameterIuiv GetSamplerParameterIuiv;

        /// <summary>
        /// Records the GL time into a query object after all previous commands have reached the GL server but have not yet necessarily executed.
        /// </summary>
        [CLSCompliant(false)]
        public static QueryCounter QueryCounter;

        /// <summary>
        /// Returns the value of parameters of query objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryObjecti64 GetQueryObjecti64;

        /// <summary>
        /// Returns the value(s) of parameters of query objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryObjecti64v GetQueryObjecti64v;

        /// <summary>
        /// Returns the value of parameters of query objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryObjectui64 GetQueryObjectui64;

        /// <summary>
        /// Returns the value(s) of parameters of query objects.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryObjectui64v GetQueryObjectui64v;

        /// <summary>
        /// Sets the rate at which vertex attributes advance during instanced rendering.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribDivisor VertexAttribDivisor;

        /// <summary>
        /// Sets the value of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP1ui VertexAttribP1ui;

        /// <summary>
        /// Sets the value of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP1uiv VertexAttribP1uiv;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP2ui VertexAttribP2ui;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP2uiv VertexAttribP2uiv;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP3ui VertexAttribP3ui;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP3uiv VertexAttribP3uiv;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP4ui VertexAttribP4ui;

        /// <summary>
        /// Sets the values of a vertex attribute in packed form.
        /// </summary>
        [CLSCompliant(false)]
        public static VertexAttribP4uiv VertexAttribP4uiv;
        #endregion

        #region Overloads
        #region GenSampler(s)
        /// <summary>
        /// Generates one sampler name and returns it.
        /// </summary>
        /// <returns>The new sampler name.</returns>
        [CLSCompliant(false)]
        public static uint GenSampler()
        {
            uint ret;
            _GenSampler(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one sampler name and returns it.
        /// </summary>
        /// <param name="sampler">The new sampler name.</param>
        [CLSCompliant(false)]
        public static void GenSampler(out uint sampler)
        {
            _GenSampler(1, out sampler);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many sampler names and returns them as array.
        /// </summary>
        /// <param name="count">The number of sampler names to be generated.</param>
        /// <returns>The new sampler names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenSamplers(int count)
        {
            uint[] ret = new uint[count];
            _GenSamplers(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many sampler names.
        /// </summary>
        /// <param name="count">The number of sampler names to be generated.</param>
        /// <param name="samplers">The array that will receive the new sampler names.</param>
        [CLSCompliant(false)]
        public static void GenSamplers(int count, uint[] samplers)
        {
            _GenSamplers(count, samplers);
        }
        #endregion

        #region GetSamplerParameteri
        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out int param)
        {
            _GetSamplerParameteri(sampler, pname, out param);
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out TextureWrapMode param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (TextureWrapMode)p;
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="SamplerParameterName.TextureCompareMode"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out TextureCompareMode param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (TextureCompareMode)p;
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out AlphaFunction param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (AlphaFunction)p;
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out DepthFunction param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (DepthFunction)p;
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out TextureMagFilter param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (TextureMagFilter)p;
        }

        /// <summary>
        /// Returns the value of a texture parameter of a sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetSamplerParameteri(uint sampler, SamplerParameterName pname, out TextureMinFilter param)
        {
            int p;
            _GetSamplerParameteri(sampler, pname, out p);
            param = (TextureMinFilter)p;
        }
        #endregion

        #region SamplerParameteri
        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, int param)
        {
            _SamplerParameteri(sampler, pname, param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, TextureMagFilter param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, TextureMinFilter param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">A <see cref="glTextureParameter"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, TextureWrapMode param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_MODE"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, TextureCompareMode param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, AlphaFunction param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }

        /// <summary>
        /// Sets texture parameter for the sampler.
        /// </summary>
        /// <param name="sampler">The name of the sampler.</param>
        /// <param name="pname">Must be <see cref="glTextureParameter.TEXTURE_COMPARE_FUNC"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [CLSCompliant(false)]
        public static void SamplerParameteri(uint sampler, SamplerParameterName pname, DepthFunction param)
        {
            _SamplerParameteri(sampler, pname, (int)param);
        }
        #endregion
        #endregion

        private static void Load_VERSION_3_3()
        {
            BindFragDataLocationIndexed = GetAddress<BindFragDataLocationIndexed>("glBindFragDataLocationIndexed");
            GetFragDataIndex = GetAddress<GetFragDataIndex>("glGetFragDataIndex");
            _GenSampler = GetAddress<GenSampler>("glGenSamplers");
            _GenSamplers = GetAddress<GenSamplers>("glGenSamplers");
            DeleteSamplers = GetAddress<DeleteSamplers>("glDeleteSamplers");
            IsSampler = GetAddress<IsSampler>("glIsSampler");
            BindSampler = GetAddress<BindSampler>("glBindSampler");
            _SamplerParameteri = GetAddress<SamplerParameteri>("glSamplerParameteri");
            SamplerParameteriv = GetAddress<SamplerParameteriv>("glSamplerParameteriv");
            SamplerParameterf = GetAddress<SamplerParameterf>("glSamplerParameterf");
            SamplerParameterfv = GetAddress<SamplerParameterfv>("glSamplerParameterfv");
            SamplerParameterIiv = GetAddress<SamplerParameterIiv>("glSamplerParameterIiv");
            SamplerParameterIuiv = GetAddress<SamplerParameterIuiv>("glSamplerParameterIuiv");
            _GetSamplerParameteri = GetAddress<GetSamplerParameteri>("glGetSamplerParameteriv");
            GetSamplerParameteriv = GetAddress<GetSamplerParameteriv>("glGetSamplerParameteriv");
            GetSamplerParameterIi = GetAddress<GetSamplerParameterIi>("glGetSamplerParameterIiv");
            GetSamplerParameterIiv = GetAddress<GetSamplerParameterIiv>("glGetSamplerParameterIiv");
            GetSamplerParameterf = GetAddress<GetSamplerParameterf>("glGetSamplerParameterfv");
            GetSamplerParameterfv = GetAddress<GetSamplerParameterfv>("glGetSamplerParameterfv");
            GetSamplerParameterIui = GetAddress<GetSamplerParameterIui>("glGetSamplerParameterIuiv");
            GetSamplerParameterIuiv = GetAddress<GetSamplerParameterIuiv>("glGetSamplerParameterIuiv");
            QueryCounter = GetAddress<QueryCounter>("glQueryCounter");
            GetQueryObjecti64 = GetAddress<GetQueryObjecti64>("glGetQueryObjecti64v");
            GetQueryObjecti64v = GetAddress<GetQueryObjecti64v>("glGetQueryObjecti64v");
            GetQueryObjectui64 = GetAddress<GetQueryObjectui64>("glGetQueryObjectui64v");
            GetQueryObjectui64v = GetAddress<GetQueryObjectui64v>("glGetQueryObjectui64v");
            VertexAttribDivisor = GetAddress<VertexAttribDivisor>("glVertexAttribDivisor");
            VertexAttribP1ui = GetAddress<VertexAttribP1ui>("glVertexAttribP1ui");
            VertexAttribP1uiv = GetAddress<VertexAttribP1uiv>("glVertexAttribP1uiv");
            VertexAttribP2ui = GetAddress<VertexAttribP2ui>("glVertexAttribP2ui");
            VertexAttribP2uiv = GetAddress<VertexAttribP2uiv>("glVertexAttribP2uiv");
            VertexAttribP3ui = GetAddress<VertexAttribP3ui>("glVertexAttribP3ui");
            VertexAttribP3uiv = GetAddress<VertexAttribP3uiv>("glVertexAttribP3uiv");
            VertexAttribP4ui = GetAddress<VertexAttribP4ui>("glVertexAttribP4ui");
            VertexAttribP4uiv = GetAddress<VertexAttribP4uiv>("glVertexAttribP4uiv");

            VERSION_3_3 = VERSION_3_2 && BindFragDataLocationIndexed != null && GetFragDataIndex != null && _GenSamplers != null &&
                DeleteSamplers != null && IsSampler != null && BindSampler != null && _SamplerParameteri != null &&
                SamplerParameteriv != null && SamplerParameterf != null && SamplerParameterfv != null && SamplerParameterIiv != null &&
                SamplerParameterIuiv != null && GetSamplerParameteriv != null && GetSamplerParameterIiv != null &&
                GetSamplerParameterfv != null && GetSamplerParameterIuiv != null && QueryCounter != null &&
                GetQueryObjecti64v != null && GetQueryObjectui64v != null && VertexAttribDivisor != null && VertexAttribP1uiv != null &&
                VertexAttribP2uiv != null && VertexAttribP3uiv != null && VertexAttribP4uiv != null;
        }
    }
}
