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
    public static partial class GL
    {
        /// <summary>
        /// Sets what side(s) of a polygon is/are not rasterized.
        /// </summary>
        /// <param name="mode">A <see cref="CullFaceMode"/> specifying the face(s).</param>
        [DllImport(DLLName, EntryPoint = "glCullFace")]
        public static extern void CullFace(CullFaceMode mode);

        /// <summary>
        /// Sets the order, in which vertices are arranged, to define the front of a polygon.
        /// </summary>
        /// <param name="dir">A <see cref="FrontFaceDirection"/> specifying the order.</param>
        [DllImport(DLLName, EntryPoint = "glFrontFace")]
        public static extern void FrontFace(FrontFaceDirection dir);

        /// <summary>
        /// Controls OpenGL behavior (via hints).
        /// </summary>
        /// <param name="target">A <see cref="HintTarget"/> specifying the hint.</param>
        /// <param name="mode">A <see cref="HintMode"/> specifying the mode.</param>
        [DllImport(DLLName, EntryPoint = "glHint")]
        public static extern void Hint(HintTarget target, HintMode mode);

        /// <summary>
        /// Sets the line width.
        /// </summary>
        /// <param name="width">The new line width.</param>
        [DllImport(DLLName, EntryPoint = "glLineWidth")]
        public static extern void LineWidth(float width);

        /// <summary>
        /// Sets the point size.
        /// </summary>
        /// <param name="size">The new point size.</param>
        [DllImport(DLLName, EntryPoint = "glPointSize")]
        public static extern void PointSize(float size);

        /// <summary>
        /// Sets the polygon rasterization mode.
        /// </summary>
        /// <param name="face">Must be <see cref="Face.FRONT_AND_BACK"/>.</param>
        /// <param name="mode">A <see cref="PolygonMode"/> specifying the rasterization methode.</param>
        [DllImport(DLLName, EntryPoint = "glPolygonMode")]
        public static extern void PolygonMode(PolygonFace face, PolygonMode mode);

        /// <summary>
        /// Defines the scissor rectane for all viewports.
        /// </summary>
        /// <param name="left">Left start position of rectane.</param>
        /// <param name="bottom">Bottom start position of rectane.</param>
        /// <param name="width">Width of rectane.</param>
        /// <param name="height">Height of rectane.</param>
        [DllImport(DLLName, EntryPoint = "glScissor")]
        public static extern void Scissor(int left, int bottom, int width, int height);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameterf")]
        public static extern void TexParameterf(TextureTarget target, TextureParameterName pname, float param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameterfv")]
        public static extern void TexParameterfv(TextureTarget target, TextureParameterName pname, params float[] @params);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, int param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set.</param>
        /// <param name="params">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteriv")]
        public static extern void TexParameteriv(TextureTarget target, TextureParameterName pname, params int[] @params);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, TextureMagFilter param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, TextureMinFilter param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> selecting the parameter to be set. Only one of the texture wrapping parameter is allowed.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, TextureWrapMode param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.TextureCompareMode"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, TextureCompareMode param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.TextureCompareFunc"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, AlphaFunction param);

        /// <summary>
        /// Sets texture parameter for the currently bound texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.DepthTextureMode"/>.</param>
        /// <param name="param">The value the parameter is set to.</param>
        [DllImport(DLLName, EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(TextureTarget target, TextureParameterName pname, DepthStencilTextureMode param);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, IntPtr pixels);

        #region Overloads for TexImage1D
        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, int offset)
        {
            TexImage1D(target, level, internalformat, width, border, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            TexImage1D(target, level, internalformat, width, border, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, byte[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        [CLSCompliant(false)]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, sbyte[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, short[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        [CLSCompliant(false)]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, ushort[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, int[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        [CLSCompliant(false)]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, uint[] pixels);

        /// <summary>
        /// Loads a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, long[] pixels);

        /// <summary>
        /// Loads a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        [CLSCompliant(false)]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, ulong[] pixels);

        /// <summary>
        /// Loads a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, float[] pixels);

        /// <summary>
        /// Loads a 1D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, double[] pixels);
        #endregion

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels);

        #region Overloads for TexImage2D
        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, int offset)
        {
            TexImage2D(target, level, internalformat, width, height, border, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            TexImage2D(target, level, internalformat, width, height, border, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, byte[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        [CLSCompliant(false)]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, sbyte[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, short[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        [CLSCompliant(false)]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, ushort[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, int[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        [CLSCompliant(false)]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, uint[] pixels);

        /// <summary>
        /// Loads a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, long[] pixels);

        /// <summary>
        /// Loads a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        [CLSCompliant(false)]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, ulong[] pixels);

        /// <summary>
        /// Loads a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, float[] pixels);

        /// <summary>
        /// Loads a 2D texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="Texture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="InternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given in.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given in.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        [DllImport(DLLName, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, double[] pixels);
        #endregion

        /// <summary>
        /// Sets the draw buffer.
        /// </summary>
        /// <param name="buf">A <see cref="Buffer"/> specifying the buffer(s).</param>
        [DllImport(DLLName, EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer(DrawBufferMode buf);

        /// <summary>
        /// Clears buffers.
        /// </summary>
        /// <param name="mask">A <see cref="BufferMask"/> specifying the buffers.</param>
        [DllImport(DLLName, EntryPoint = "glClear")]
        public static extern void Clear(ClearBufferMask mask);

        /// <summary>
        /// Sets the clear color for color buffers.
        /// </summary>
        /// <param name="red">Red value.</param>
        /// <param name="green">Green value.</param>
        /// <param name="blue">Blue value.</param>
        /// <param name="alpha">Alpha value.</param>
        [DllImport(DLLName, EntryPoint = "glClearColor")]
        public static extern void ClearColor(float red, float green, float blue, float alpha);

        /// <summary>
        /// Sets the stencil value for clear operations on stencil buffers.
        /// </summary>
        /// <param name="s">Stencil value.</param>
        [DllImport(DLLName, EntryPoint = "glClearStencil")]
        public static extern void ClearStencil(int s);

        /// <summary>
        /// Sets the depth value for clear operations on depth buffers.
        /// </summary>
        /// <param name="depth">Depth value.</param>
        [DllImport(DLLName, EntryPoint = "glClearDepth")]
        public static extern void ClearDepth(double depth);

        /// <summary>
        /// Sets the stencil mask for stencil write operations.
        /// </summary>
        /// <param name="mask">The bitmask.</param>
        [DllImport(DLLName, EntryPoint = "glStencilMask")]
        [CLSCompliant(false)]
        public static extern void StencilMask(uint mask);

        /// <summary>
        /// Sets the color mask for color write operations.
        /// </summary>
        /// <param name="red">Wether or not the write the red components.</param>
        /// <param name="green">Wether or not the write the green components.</param>
        /// <param name="blue">Wether or not the write the blue components.</param>
        /// <param name="alpha">Wether or not the write the alpha components.</param>
        [DllImport(DLLName, EntryPoint = "glColorMask")]
        public static extern void ColorMask([MarshalAs(UnmanagedType.I1)] bool red, [MarshalAs(UnmanagedType.I1)] bool green,
            [MarshalAs(UnmanagedType.I1)] bool blue, [MarshalAs(UnmanagedType.I1)] bool alpha);

        /// <summary>
        /// Sets the mask for depth operations.
        /// </summary>
        /// <param name="flag">>Wether or not the write the depth values.</param>
        [DllImport(DLLName, EntryPoint = "glDepthMask")]
        public static extern void DepthMask([MarshalAs(UnmanagedType.I1)] bool flag);

        /// <summary>
        /// Disables OpenGL capabilities.
        /// </summary>
        /// <param name="cap">The capability to be disabled.</param>
        [DllImport(DLLName, EntryPoint = "glDisable")]
        public static extern void Disable(EnableCap cap);

        /// <summary>
        /// Enables OpenGL capabilities.
        /// </summary>
        /// <param name="cap">The capability to be enabled.</param>
        [DllImport(DLLName, EntryPoint = "glEnable")]
        public static extern void Enable(EnableCap cap);

        /// <summary>
        /// Finishes all outstandig OpenGL operations before returning.
        /// </summary>
        [DllImport(DLLName, EntryPoint = "glFinish")]
        public static extern void Finish();

        /// <summary>
        /// Forces outstandig OpenGL operations to execute.
        /// </summary>
        [DllImport(DLLName, EntryPoint = "glFlush")]
        public static extern void Flush();

        /// <summary>
        /// Sets the blend function factors.
        /// </summary>
        /// <param name="sfactor">Factor to the source value.</param>
        /// <param name="dfactor">Factor to the destination value.</param>
        [DllImport(DLLName, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

        /// <summary>
        /// Sets the logical pixel operation to perform.
        /// </summary>
        /// <param name="opcode">A <see cref="LogicOpMode"/> specifying the logical operation.</param>
        [DllImport(DLLName, EntryPoint = "glLogicOp")]
        public static extern void LogicOp(LogicOp opcode);

        /// <summary>
        /// Sets the stencil test function.
        /// </summary>
        /// <param name="func">A <see cref="Func"/> specifying the test function.</param>
        /// <param name="refvalue">The reference value.</param>
        /// <param name="mask">The bitmask for the operation.</param>
        [DllImport(DLLName, EntryPoint = "glStencilFunc")]
        [CLSCompliant(false)]
        public static extern void StencilFunc(StencilFunction func, int refvalue, uint mask);

        /// <summary>
        /// Sets the stencil operation.
        /// </summary>
        /// <param name="fail">A <see cref="StencilOp"/> specifying the action to take when the stencil test fails.</param>
        /// <param name="zfail">A <see cref="StencilOp"/> specifying the action to take when the stencil test passed, but the depth test fails.</param>
        /// <param name="zpass">A <see cref="StencilOp"/> specifying the action to take when the stencil and depth test passes.</param>
        [DllImport(DLLName, EntryPoint = "glStencilOp")]
        public static extern void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass);

        /// <summary>
        /// Sets the depth test function.
        /// </summary>
        /// <param name="func">A <see cref="Func"/> specifying the test function.</param>
        [DllImport(DLLName, EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc(DepthFunction func);

        /// <summary>
        /// Sets the parameter for pixel pack or unpack operations.
        /// </summary>
        /// <param name="pname">A <see cref="PixelStoreParameter"/> specifying the parameter.</param>
        /// <param name="param">The value.</param>
        [DllImport(DLLName, EntryPoint = "glPixelStoref")]
        public static extern void PixelStoref(PixelStoreParameter pname, float param);

        /// <summary>
        /// Sets the parameter for pixel pack or unpack operations.
        /// </summary>
        /// <param name="pname">A <see cref="PixelStoreParameter"/> specifying the parameter.</param>
        /// <param name="param">The value.</param>
        [DllImport(DLLName, EntryPoint = "glPixelStorei")]
        public static extern void PixelStorei(PixelStoreParameter pname, int param);

        /// <summary>
        /// Sets the read buffer.
        /// </summary>
        /// <param name="src">A <see cref="Buffer"/> specifying the buffer(s).</param>
        [DllImport(DLLName, EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer(ReadBufferMode src);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, IntPtr pixels);

        #region Overloads for ReadPixels
        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int offset)
        {
            ReadPixels(x, y, width, height, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            ReadPixels(x, y, width, height, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        [CLSCompliant(false)]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, sbyte[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        [CLSCompliant(false)]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, short[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        [CLSCompliant(false)]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, ushort[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        [CLSCompliant(false)]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, uint[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, long[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        [CLSCompliant(false)]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, ulong[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer.
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, float[] pixels);

        /// <summary>
        /// Reads pixels form the frame buffer. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="x">The start position in x-direction from which to read.</param>
        /// <param name="y">The start position in y-direction from which to read.</param>
        /// <param name="width">The width of the rectane to read.</param>
        /// <param name="height">The height of the rectane to read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, double[] pixels);
        #endregion

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetPName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetBooleanv")]
        public static extern void GetBooleanv(GetPName pname, [MarshalAs(UnmanagedType.I1)] out bool param);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetPName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetBooleanv")]
        public static extern void GetBooleanv(GetPName pname, byte[] @params);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetPName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetBooleanv")]
        private static extern void GetBooleanv(GetPName pname, IntPtr @params);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetPName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public static void GetBooleanv(GetPName pname, bool[] @params)
        {
            GCHandle pin = GCHandle.Alloc(@params, GCHandleType.Pinned);
            GetBooleanv(pname, pin.AddrOfPinnedObject());
            pin.Free();
        }

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetDoublev")]
        public static extern void GetDoublev(GetPName pname, out double param);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetDoublev")]
        public static extern void GetDoublev(GetPName pname, double[] @params);

        /// <summary>
        /// Returns the error code.
        /// </summary>
        /// <returns>A <see cref="ErrorCode"/> specifying the error.</returns>
        [DllImport(DLLName, EntryPoint = "glGetError")]
        public static extern ErrorCode GetError();

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetFloatv")]
        public static extern void GetFloatv(GetPName pname, out float param);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetFloatv")]
        public static extern void GetFloatv(GetPName pname, float[] @params);

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetIntegerParameter"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetIntegerv")]
        public static extern void GetIntegerv(GetPName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetIntegerParameter"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetIntegerv")]
        public static extern void GetIntegerv(GetPName pname, int[] @params);

        [DllImport(DLLName, EntryPoint = "glGetString")]
        private static extern IntPtr GetStringAsIntPtr(StringName pname);

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetStringParameter"/> specifying the parameter.</param>
        /// <returns>The requested value as <b>string</b>.</returns>
        public static string GetString(StringName pname)
        {
            return Marshal.PtrToStringAnsi(GetStringAsIntPtr(pname));
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, IntPtr pixels);

        #region Overloads for GetTexImage
        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int offset)
        {
            GetTexImage(target, level, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            GetTexImage(target, level, format, type, (IntPtr)offset);
        }

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.UNSIGNED_BYTE"/>, <see cref="glPixelDataType.UNSIGNED_BYTE_3_3_2"/> or <see cref="glPixelDataType.UNSIGNED_BYTE_2_3_3_REV"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, byte[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.BYTE"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        [CLSCompliant(false)]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, sbyte[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.SHORT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        [CLSCompliant(false)]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, short[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_SHORT*</b>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        [CLSCompliant(false)]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, ushort[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.INT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, int[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <b>PixelType.UNSIGNED_INT*</b>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        [CLSCompliant(false)]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, uint[] pixels);

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, long[] pixels);

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        [CLSCompliant(false)]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, ulong[] pixels);

        /// <summary>
        /// Reads a texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out. Must be <see cref="glPixelDataType.FLOAT"/>.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, float[] pixels);

        /// <summary>
        /// Reads a texture. (For future use. Type not yet supported.)
        /// </summary>
        /// <param name="target">A <see cref="TextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="format">A <see cref="PixelFormat"/> specifying the format the pixels a given out.</param>
        /// <param name="type">A <see cref="PixelDataType"/> specifying the data type the pixels a given out.</param>
        /// <param name="pixels">Pointer to the buffer for the returning data.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, double[] pixels);
        #endregion

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameterfv")]
        public static extern void GetTexParameterfv(TextureTarget target, TextureParameterName pname, out float param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameterfv")]
        public static extern void GetTexParameterfv(TextureTarget target, TextureParameterName pname, float[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out int param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, int[] @params);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureMagFilter param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter. Only one of the texture filtering parameter is allowed.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureMinFilter param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter. Only one of the texture wrapping parameter is allowed.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureWrapMode param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.TextureCompareMode"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureCompareMode param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.TextureCompareFunc"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out AlphaFunction param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.DepthStencilTextureMode"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out DepthStencilTextureMode param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.TEXTURE_TARGET"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureTarget param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">Must be <see cref="TextureParameterName.IMAGE_FORMAT_COMPATIBILITY_TYPE"/>.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out ImageFormatCompatibilityType param);

        /// <summary>
        /// Returns the value of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, out TextureParameter param);

        /// <summary>
        /// Returns the value(s) of a texture parameter.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(TextureTarget target, TextureParameterName pname, TextureParameter[] @params);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexLevelParameterfv")]
        public static extern void GetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, out float param);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetTexLevelParameterfv")]
        public static extern void GetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, float[] @params);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [DllImport(DLLName, EntryPoint = "glGetTexLevelParameteriv")]
        public static extern void GetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, out int param);

        /// <summary>
        /// Returns the texture parameter of a texture level.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail.</param>
        /// <param name="pname">A <see cref="TextureParameterName"/> specifying the texture parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        [DllImport(DLLName, EntryPoint = "glGetTexLevelParameteriv")]
        public static extern void GetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, int[] @params);

        /// <summary>
        /// Checks wether or not a OpenGL capability is enabled.
        /// </summary>
        /// <param name="cap">A <see cref="Capability"/> specifying the capability to check.</param>
        /// <returns><b>true</b> if the capability is enabled.</returns>
        [DllImport(DLLName, EntryPoint = "glIsEnabled")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsEnabled(EnableCap cap);

        /// <summary>
        /// Sets the depth range.
        /// </summary>
        /// <param name="zNear">The near value.</param>
        /// <param name="zFar">The far value.</param>
        [DllImport(DLLName, EntryPoint = "glDepthRange")]
        public static extern void DepthRange(double zNear, double zFar);

        /// <summary>
        /// Sets the viewport.
        /// </summary>
        /// <param name="x">The start position in x-direction.</param>
        /// <param name="y">The start position in y-direction.</param>
        /// <param name="width">The width of the viewport.</param>
        /// <param name="height">The height of the viewport.</param>
        [DllImport(DLLName, EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int width, int height);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Push and pop the current matrix stack
        /// </summary>
        [DllImport(DLLName, EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix();

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Multiply the current matrix by a translation matrix
        /// </summary>
        /// <param name="x"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        /// <param name="y"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        /// <param name="z"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glTranslated")]
        public static extern void Translate(Double x, Double y, Double z);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Multiply the current matrix by a translation matrix
        /// </summary>
        /// <param name="x"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        /// <param name="y"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        /// <param name="z"> 
        /// Specify the x, y, and z coordinates of a translation vector.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glTranslatef")]
        public static extern void Translate(Single x, Single y, Single z);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3b")]
        [CLSCompliant(false)]
        public static extern void Color3(SByte red, SByte green, SByte blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3bv")]
        [CLSCompliant(false)]
        public static extern void Color3(SByte[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3bv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref SByte v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3bv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(SByte* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3d")]
        public static extern void Color3(Double red, Double green, Double blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3dv")]
        [CLSCompliant(false)]
        public static extern void Color3(Double[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3dv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref Double v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3dv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(Double* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3f")]
        public static extern void Color3(Single red, Single green, Single blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3fv")]
        [CLSCompliant(false)]
        public static extern void Color3(Single[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3fv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref Single v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3fv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(Single* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3i")]
        public static extern void Color3(Int32 red, Int32 green, Int32 blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3iv")]
        [CLSCompliant(false)]
        public static extern void Color3(Int32[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3iv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref Int32 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3iv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(Int32* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3s")]
        public static extern void Color3(Int16 red, Int16 green, Int16 blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3sv")]
        [CLSCompliant(false)]
        public static extern void Color3(Int16[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3sv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref Int16 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3sv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(Int16* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3ub")]
        public static extern void Color3(Byte red, Byte green, Byte blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3ubv")]
        [CLSCompliant(false)]
        public static extern void Color3(Byte[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3ubv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref Byte v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3ubv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(Byte* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3ui")]
        [CLSCompliant(false)]
        public static extern void Color3(UInt32 red, UInt32 green, UInt32 blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3uiv")]
        [CLSCompliant(false)]
        public static extern void Color3(UInt32[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3uiv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref UInt32 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3uiv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(UInt32* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3us")]
        [CLSCompliant(false)]
        public static extern void Color3(UInt16 red, UInt16 green, UInt16 blue);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3usv")]
        [CLSCompliant(false)]
        public static extern void Color3(UInt16[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3usv")]
        [CLSCompliant(false)]
        public static extern void Color3(ref UInt16 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 3] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor3usv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color3(UInt16* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4b")]
        [CLSCompliant(false)]
        public static extern void Color4(SByte red, SByte green, SByte blue, SByte alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4bv")]
        [CLSCompliant(false)]
        public static extern void Color4(SByte[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4bv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref SByte v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4bv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(SByte* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4d")]
        public static extern void Color4(Double red, Double green, Double blue, Double alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4dv")]
        [CLSCompliant(false)]
        public static extern void Color4(Double[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4dv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref Double v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4dv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(Double* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4f")]
        public static extern void Color4(Single red, Single green, Single blue, Single alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4fv")]
        [CLSCompliant(false)]
        public static extern void Color4(Single[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4fv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref Single v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4fv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(Single* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4i")]
        public static extern void Color4(Int32 red, Int32 green, Int32 blue, Int32 alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4iv")]
        [CLSCompliant(false)]
        public static extern void Color4(Int32[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4iv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref Int32 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4iv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(Int32* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4s")]
        public static extern void Color4(Int16 red, Int16 green, Int16 blue, Int16 alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4sv")]
        [CLSCompliant(false)]
        public static extern void Color4(Int16[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4sv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref Int16 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4sv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(Int16* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4ub")]
        public static extern void Color4(Byte red, Byte green, Byte blue, Byte alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4ubv")]
        [CLSCompliant(false)]
        public static extern void Color4(Byte[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4ubv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref Byte v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4ubv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(Byte* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4ui")]
        [CLSCompliant(false)]
        public static extern void Color4(UInt32 red, UInt32 green, UInt32 blue, UInt32 alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4uiv")]
        [CLSCompliant(false)]
        public static extern void Color4(UInt32[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4uiv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref UInt32 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4uiv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(UInt32* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="red"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="green"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="blue"> 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        /// <param name="alpha"> 
        /// Specifies a new alpha value for the current color. Included only in the four-argument glColor4 commands.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4us")]
        [CLSCompliant(false)]
        public static extern void Color4(UInt16 red, UInt16 green, UInt16 blue, UInt16 alpha);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4usv")]
        [CLSCompliant(false)]
        public static extern void Color4(UInt16[] v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4usv")]
        [CLSCompliant(false)]
        public static extern void Color4(ref UInt16 v);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Set the current color
        /// </summary>
        /// <param name="v">[length: 4] 
        /// Specify new red, green, and blue values for the current color.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glColor4usv")]
        [CLSCompliant(false)]
        public static extern unsafe void Color4(UInt16* v);

        /// <summary>[requires: v1.0][deprecated: v3.2]</summary>
        [DllImport(DLLName, EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix();

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Specify which matrix is the current matrix
        /// </summary>
        /// <param name="mode"> 
        /// Specifies which matrix stack is the target for subsequent matrix operations. Three values are accepted: Modelview, Projection, and Texture. The initial value is Modelview. Additionally, if the ARB_imaging extension is supported, Color is also accepted.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode(MatrixMode mode);

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Replace the current matrix with the identity matrix
        /// </summary>
        [DllImport(DLLName, EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity();

        /// <summary>[requires: v1.0][deprecated: v3.2]
        /// Multiply the current matrix with an orthographic matrix
        /// </summary>
        /// <param name="left"> 
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="right"> 
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="bottom"> 
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="top"> 
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="zNear"> 
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be behind the viewer.
        /// </param>
        /// <param name="zFar"> 
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be behind the viewer.
        /// </param>
        [DllImport(DLLName, EntryPoint = "glOrtho")]
        public static extern void Ortho(Double left, Double right, Double bottom, Double top, Double zNear,
            Double zFar);
        
        #region Get*
        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <returns>The requested value.</returns>
        public static double GetDouble(GetPName pname)
        {
            double ret;
            GetDoublev(pname, out ret);
            return ret;
        }

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="size">The number of values.</param>
        /// <returns>The requested value(s).</returns>
        public static double[] GetDoubles(GetPName pname, int size)
        {
            double[] res = new double[size];
            GetDoublev(pname, res);
            return res;
        }

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <returns>The requested value.</returns>
        public static float GetFloat(GetPName pname)
        {
            float ret;
            GetFloatv(pname, out ret);
            return ret;
        }

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetFloatParameter"/> specifying the parameter.</param>
        /// <param name="size">The number of values.</param>
        /// <returns>The requested value(s).</returns>
        public static float[] GetFloats(GetPName pname, int size)
        {
            float[] res = new float[size];
            GetFloatv(pname, res);
            return res;
        }

        /// <summary>
        /// Returns the value of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetIntegerParameter"/> specifying the parameter.</param>
        /// <returns>The requested value.</returns>
        public static int GetInteger(GetPName pname)
        {
            int ret;
            GetIntegerv(pname, out ret);
            return ret;
        }

        /// <summary>
        /// Returns the value(s) of a parameter.
        /// </summary>
        /// <param name="pname">A <see cref="GetIntegerParameter"/> specifying the parameter.</param>
        /// <param name="size">The number of values.</param>
        /// <returns>The requested value(s).</returns>
        public static int[] GetIntegers(GetPName pname, int size)
        {
            int[] res = new int[size];
            GetIntegerv(pname, res);
            return res;
        }
        #endregion
    }
}
