using System;
using AlienEngine.Core.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using AlienEngine.Shaders;
using AlienEngine.Core.Game;
using AlienEngine.Core.Resources;
using AlienEngine.Core.Graphics.DevIL;

namespace AlienEngine.Graphics
{
    public class Cubemap : IDisposable, IRenderable
    {
        private string[] _textures;
        private uint _textureID;
        private VAO _cube;
        private CubemapShaderProgram _program;
        private bool _loaded;

        private static TextureTarget[] _types = new TextureTarget[6] {
            TextureTarget.TextureCubeMapPositiveX,
            TextureTarget.TextureCubeMapNegativeX,
            TextureTarget.TextureCubeMapPositiveY,
            TextureTarget.TextureCubeMapNegativeY,
            TextureTarget.TextureCubeMapPositiveZ,
            TextureTarget.TextureCubeMapNegativeZ
        };

        public Cubemap(string posx, string negx, string posy, string negy, string posz, string negz)
        {
            _textures = new string[6];

            _textures[0] = posx;
            _textures[1] = negx;
            _textures[2] = posy;
            _textures[3] = negy;
            _textures[4] = posz;
            _textures[5] = negz;

            _textureID = 0;
        }

        #region Methods

        private void _loadCubeSide(uint sideID)
        {
            switch (new FileInfo(_textures[sideID]).Extension.ToLower())
            {
                //case ".dds":
                //    _loadDDS(sideID);
                //    break;
                default:
                    _loadBitmap(sideID);
                    break;
            }
        }

        private void _loadBitmap(uint sideID)
        {
            Bitmap BitmapImage = (Bitmap)Image.FromFile(_textures[sideID]);

            // must be Format32bppArgb file format, so convert it if it isn't in that format
            BitmapData bitmapData = BitmapImage.LockBits(new System.Drawing.Rectangle(0, 0, BitmapImage.Width, BitmapImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(_types[sideID], 0, PixelInternalFormat.Rgba8, BitmapImage.Width, BitmapImage.Height, 0, Core.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, TextureParameter.ClampToEdge);

            BitmapImage.UnlockBits(bitmapData);
            BitmapImage.Dispose();
        }

        //private void _loadDDS(uint sideID)
        //{
        //    using (BinaryReader stream = new BinaryReader(new FileStream(_textures[sideID], FileMode.Open)))
        //    {
        //        string filecode = new string(stream.ReadChars(4));
        //        if (filecode != "DDS ")                                 // first 4 chars should be "DDS "
        //            throw new Exception("File was not a DDS file format.");

        //        DDS.DDSURFACEDESC2 imageData = DDS.DDSURFACEDESC2.FromBinaryReader(stream);//new DDS.DDSURFACEDESC2(stream);  // read the DirectDraw surface descriptor

        //        if (imageData.LinearSize == 0)
        //            throw new Exception("The linear scan line size was zero.");

        //        bool compressed = true;
        //        int factor = 0, buffersize = 0, blocksize = 0;
        //        PixelInternalFormat format;
        //        switch (imageData.PixelFormat.FourCC)       // check the compression type
        //        {
        //            case "DXT1":    // DXT1 compression ratio is 8:1
        //                format = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
        //                factor = 2;
        //                blocksize = 8;
        //                break;
        //            case "DXT3":    // DXT3 compression ratio is 4:1
        //                format = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
        //                factor = 4;
        //                blocksize = 16;
        //                break;
        //            case "DXT5":    // DXT5 compression ratio is 4:1
        //                format = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
        //                factor = 4;
        //                blocksize = 16;
        //                break;
        //            default:
        //                compressed = false;
        //                if (imageData.PixelFormat.ABitMask == 0xf000 && imageData.PixelFormat.RBitMask == 0x0f00 &&
        //                    imageData.PixelFormat.GBitMask == 0x00f0 && imageData.PixelFormat.BBitMask == 0x000f &&
        //                    imageData.PixelFormat.RGBBitCount == 16) format = PixelInternalFormat.Rgba;
        //                else if (imageData.PixelFormat.ABitMask == unchecked((int)0xff000000) && imageData.PixelFormat.RBitMask == 0x00ff0000 &&
        //                    imageData.PixelFormat.GBitMask == 0x0000ff00 && imageData.PixelFormat.BBitMask == 0x000000ff &&
        //                    imageData.PixelFormat.RGBBitCount == 32) format = PixelInternalFormat.Rgba;
        //                else throw new Exception(string.Format("File compression \"{0}\" is not supported.", imageData.PixelFormat.FourCC));
        //                break;
        //        }

        //        if (imageData.LinearSize != 0) buffersize = (int)((imageData.MipmapCount > 1) ? imageData.LinearSize * factor : imageData.LinearSize);
        //        else buffersize = (int)(stream.BaseStream.Length - stream.BaseStream.Position);

        //        // read the pixel data and then pin it to memory so that the garbage collector
        //        // doesn't shuffle the data around while OpenGL is decompressing it
        //        byte[] pixels = stream.ReadBytes(buffersize);

        //        try
        //        {
        //            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
        //            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
        //            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
        //            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
        //            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, TextureParameter.ClampToEdge);

        //            int nOffset = 0, nWidth = (int)imageData.Width, nHeight = (int)imageData.Height;

        //            for (int i = 0; i < (imageData.MipmapCount == 0 ? 1 : imageData.MipmapCount); ++i)
        //            {
        //                if (nWidth == 0) nWidth = 1;        // smallest mipmap is 1x1 pixels
        //                if (nHeight == 0) nHeight = 1;
        //                int nSize = 0;

        //                if (compressed)
        //                {
        //                    nSize = ((nWidth + 3) / 4) * ((nHeight + 3) / 4) * blocksize;
        //                    GL.CompressedTexImage2D(_types[sideID], i, format, nWidth, nHeight, 0, nSize, pixels);
        //                }
        //                else
        //                {
        //                    PixelType pixelType = imageData.PixelFormat.RGBBitCount == 16 ? PixelType.UnsignedShort4444Reversed : PixelType.UnsignedInt8888Reversed;

        //                    nSize = nWidth * nHeight * imageData.PixelFormat.RGBBitCount / 8;
        //                    GL.TexImage2D(_types[sideID], i, format, nWidth, nHeight, 0, Core.Graphics.OpenGL.PixelFormat.Bgra, pixelType, pixels);
        //                }

        //                nOffset += nSize;
        //                nWidth /= 2;
        //                nHeight /= 2;
        //            }
        //        }
        //        catch (Exception)
        //        {   // There was some sort of Dll related error, or the target GPU does not support glCompressedTexImage2DARB
        //            throw;
        //        }
        //    }
        //}

        public bool Load()
        {
            if (!_loaded)
            {
                Camera _camera = Game.CurrentCamera.GetComponent<Camera>();

                _program = new CubemapShaderProgram();
                _cube = Geometry.CreateCube(_program, Vector3f.One * -_camera.Far / 2, Vector3f.One * _camera.Far / 2);

                _textureID = GL.GenTexture();
                GL.BindTexture(TextureTarget.TextureCubeMap, _textureID);

                for (uint i = 0; i < _types.Length; i++)
                {
                    try
                    {
                        _loadCubeSide(i);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                ResourcesManager.AddDisposableResource(this);

                _loaded = true;
            }

            return true;
        }

        [CLSCompliant(false)]
        public void Bind(uint textureUnit)
        {
            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget.TextureCubeMap, _textureID);
        }

        public void Render()
        {
            Camera _camera = Game.CurrentCamera.GetComponent<Camera>();

            GL.DepthMask(false);
            _cube.Program.Bind();
            _cube.Program.SetUniform("p_matrix", _camera.ProjectionMatrix);
            _cube.Program.SetUniform("cm_matrix", _camera.CubemapMatrix);
            _cube.Program.SetUniform("textureCubemap", GL.COLOR_TEXTURE_UNIT_INDEX);
            Bind(GL.COLOR_TEXTURE_UNIT_INDEX);
            _cube.Draw();
            GL.DepthMask(true);
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_textureID != 0)
                    GL.DeleteTextures(1, new uint[] { _textureID });

                disposedValue = true;
            }
        }

        ~Cubemap()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
