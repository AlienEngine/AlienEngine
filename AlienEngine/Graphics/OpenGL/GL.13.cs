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
        /// Sets the active texture unit.
        /// </summary>
        /// <param name="texture">A <see cref="TextureUnit"/> specifying the texture unit.</param>
        public delegate void ActiveTexture(uint texture);

        /// <summary>
        /// Sets multisample coverage parameters.
        /// </summary>
        /// <param name="value">Sample coverage value.</param>
        /// <param name="invert">Set <b>true</b> if coverage mask should be inverted.</param>
        public delegate void SampleCoverage(float value, [MarshalAs(UnmanagedType.I1)] bool invert);

        internal delegate void CompressedTexImage3D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int depth, int border, int imageSize, IntPtr data);

        internal delegate void CompressedTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int border, int imageSize, IntPtr data);

        internal delegate void CompressedTexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int border, int imageSize, IntPtr data);

        internal delegate void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset,
            int zoffset, int width, int height, int depth, PixelInternalFormat format, int imageSize, IntPtr data);

        internal delegate void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset,
            int width, int height, PixelInternalFormat format, int imageSize, IntPtr data);

        internal delegate void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width,
            PixelInternalFormat format, int imageSize, IntPtr data);

        internal delegate void GetCompressedTexImage(TextureTarget target, int level, IntPtr img);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 1.3 is available.
        /// </summary>
        public static bool VERSION_1_3;

        #region Delegates

        /// <summary>
        /// Sets the active texture unit.
        /// </summary>
        public static ActiveTexture _ActiveTexture;

        /// <summary>
        /// Sets multisample coverage parameters.
        /// </summary>
        public static SampleCoverage SampleCoverage;

        private static CompressedTexImage1D _CompressedTexImage1D;
        private static CompressedTexImage2D _CompressedTexImage2D;
        private static CompressedTexImage3D _CompressedTexImage3D;
        private static CompressedTexSubImage1D _CompressedTexSubImage1D;
        private static CompressedTexSubImage2D _CompressedTexSubImage2D;
        private static CompressedTexSubImage3D _CompressedTexSubImage3D;
        private static GetCompressedTexImage _GetCompressedTexImage;

        #endregion

        #region Overloads

        #region ActiveTexture

        /// <summary>
        /// Sets the active texture unit.
        /// </summary>
        [CLSCompliant(false)]
        public static void ActiveTexture(uint textureUnit)
        {
            _ActiveTexture((uint) TextureUnit.Texture0 + textureUnit);
        }

        #endregion

        #region CompressedTexImage1D

        /// <summary>
        /// Loads a compressed 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int border, int imageSize, int offset)
        {
            _CompressedTexImage1D(target, level, internalformat, width, border, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int border, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexImage1D(target, level, internalformat, width, border, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture1DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int border, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexImage1D(target, level, internalformat, width, border, imageSize,
                    hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region CompressedTexImage2D

        /// <summary>
        /// Loads a compressed 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int border, int imageSize, int offset)
        {
            _CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int border, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int border, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize,
                    hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region CompressedTexImage3D

        /// <summary>
        /// Loads a compressed 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage3D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int depth, int border, int imageSize, int offset)
        {
            _CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexImage3D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int depth, int border, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture3DProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="internalformat">A <see cref="PixelInternalFormat"/> specifying the internal format to be used.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="border">Must be zero for core profile.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexImage3D(TextureTarget target, int level, PixelInternalFormat internalformat,
            int width, int height, int depth, int border, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize,
                    hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region CompressedTexSubImage1D

        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width,
            PixelInternalFormat format, int imageSize, int offset)
        {
            _CompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width,
            PixelInternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 1D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width,
            PixelInternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexSubImage1D(target, level, xoffset, width, format, imageSize,
                    hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region CompressedTexSubImage2D

        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width,
            int height, PixelInternalFormat format, int imageSize, int offset)
        {
            _CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width,
            int height, PixelInternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 2D texture.
        /// </summary>
        /// <param name="target">A <see cref="glTexture2DTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width,
            int height, PixelInternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize,
                    hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region CompressedTexSubImage3D

        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset,
            int zoffset, int width, int height, int depth, PixelInternalFormat format, int imageSize, int offset)
        {
            _CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_UNPACK_BUFFER"/>.</param>
        public static void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset,
            int zoffset, int width, int height, int depth, PixelInternalFormat format, int imageSize, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize,
                (IntPtr) offset);
        }

        /// <summary>
        /// Loads a compressed texture as part a 3D texture.
        /// </summary>
        /// <param name="target">A <see cref="TextureTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be filled.</param>
        /// <param name="xoffset">The horizontal texel offset.</param>
        /// <param name="yoffset">The vertical texel offset.</param>
        /// <param name="zoffset">The texel offset in z-direction.</param>
        /// <param name="width">The width of the texture subimage.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="depth">The depth of the texture.</param>
        /// <param name="format">A <see cref="PixelInternalFormat"/> specifying the format of the compressed data.</param>
        /// <param name="imageSize">Size of the compressed texture in bytes.</param>
        /// <param name="pixels">Pointer to the pixels.</param>
        public static void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset,
            int zoffset, int width, int height, int depth, PixelInternalFormat format, int imageSize, byte[] pixels)
        {
            GCHandle hPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                _CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format,
                    imageSize, hPixels.AddrOfPinnedObject());
            }
            finally
            {
                hPixels.Free();
            }
        }

        #endregion

        #region GetCompressedTexImage

        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTexImage(TextureTarget target, int level, int offset)
        {
            _GetCompressedTexImage(target, level, (IntPtr) offset);
        }

        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.PIXEL_PACK_BUFFER"/>.</param>
        public static void GetCompressedTexImage(TextureTarget target, int level, long offset)
        {
            if (IntPtr.Size == 4 && ((long) offset >> 32) != 0)
                throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetCompressedTexImage(target, level, (IntPtr) offset);
        }

        /// <summary>
        /// Read a texture as compressed texture.
        /// </summary>
        /// <param name="target">A <see cref="glTextureProxyTarget"/> specifying the texture target.</param>
        /// <param name="level">The level-of-detail to be read.</param>
        /// <param name="img">Pointer to the buffer for the returning data.</param>
        public static void GetCompressedTexImage(TextureTarget target, int level, byte[] img)
        {
            GCHandle hImg = GCHandle.Alloc(img, GCHandleType.Pinned);
            try
            {
                _GetCompressedTexImage(target, level, hImg.AddrOfPinnedObject());
            }
            finally
            {
                hImg.Free();
            }
        }

        #endregion

        #endregion

        private static void Load_VERSION_1_3()
        {
            _ActiveTexture = GetAddress<ActiveTexture>("glActiveTexture");
            SampleCoverage = GetAddress<SampleCoverage>("glSampleCoverage");
            _CompressedTexImage1D = GetAddress<CompressedTexImage1D>("glCompressedTexImage1D");
            _CompressedTexImage2D = GetAddress<CompressedTexImage2D>("glCompressedTexImage2D");
            _CompressedTexImage3D = GetAddress<CompressedTexImage3D>("glCompressedTexImage3D");
            _CompressedTexSubImage1D = GetAddress<CompressedTexSubImage1D>("glCompressedTexSubImage1D");
            _CompressedTexSubImage2D = GetAddress<CompressedTexSubImage2D>("glCompressedTexSubImage2D");
            _CompressedTexSubImage3D = GetAddress<CompressedTexSubImage3D>("glCompressedTexSubImage3D");
            _GetCompressedTexImage = GetAddress<GetCompressedTexImage>("glGetCompressedTexImage");

            VERSION_1_3 = VERSION_1_2 && _ActiveTexture != null && SampleCoverage != null &&
                          _CompressedTexImage3D != null &&
                          _CompressedTexSubImage3D != null && _GetCompressedTexImage != null;
        }
    }
}