using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.Shaders;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AlienEngine.Imaging
{
    public class Cubemap : IDisposable, IRenderable
    {
        private string[] _textures;
        private Core.Graphics.DevIL.Image[] _images;
        private uint _textureID;
        private VAO _cube;
        private CubemapShaderProgram _program;
        private bool _loaded;
        private Camera _camera;

        private static TextureTarget[] _types = new TextureTarget[6]
        {
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
            _images = new Core.Graphics.DevIL.Image[6];

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
            var extension = new FileInfo(_textures[sideID]).Extension.ToLower();
            switch (extension)
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
            // Import the image
            ImageImporter _importer = new ImageImporter();
            _images[sideID] = _importer.LoadImage(_textures[sideID]);

            // Dispose the importer
            _importer.Dispose();

            // Bind the impi]orted Image
            _images[sideID].Bind();

            // Generate bitmap from image
            Bitmap BitmapImage = _images[sideID].ToBitmap();

            // Must be Format32bppArgb file format, so convert it if it isn't in that format
            BitmapData bitmapData =
                BitmapImage.LockBits(new System.Drawing.Rectangle(0, 0, BitmapImage.Width, BitmapImage.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(_types[sideID], 0, PixelInternalFormat.Rgba8, BitmapImage.Width, BitmapImage.Height, 0,
                Core.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter,
                TextureParameter.Linear);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter,
                TextureParameter.Linear);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS,
                TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT,
                TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR,
                TextureParameter.ClampToEdge);

            // Dispose bitmap (it will not longer be used)
            BitmapImage.UnlockBits(bitmapData);
            BitmapImage.Dispose();

            // Make sure the Image will not be modified from the outside
            _images[sideID].Unbind();
        }

        public bool Load()
        {
            if (!_loaded)
            {
                _camera = Game.CurrentScene.PrimaryCamera.GetComponent<Camera>();
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

                GL.BindTexture(TextureTarget.TextureCubeMap, 0);

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

        public void Unbind()
        {
            GL.BindTexture(TextureTarget.TextureCubeMap, 0);
        }
        
        public void Render()
        {
            Renderer.BackupState(RendererBackupMode.FaceCulling);
            Renderer.FaceCulling(false);

            _cube.Program.Bind();
            _cube.Program.SetUniform("pcm_matrix", _camera.CubemapMatrix * _camera.ProjectionMatrix);
            _cube.Program.SetUniform("textureCubemap", GL.COLOR_TEXTURE_UNIT_INDEX);
            Bind(GL.COLOR_TEXTURE_UNIT_INDEX);
            _cube.Draw();
            Unbind();

            Renderer.RestoreState(RendererBackupMode.FaceCulling);
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_textureID != 0)
                    GL.DeleteTextures(1, new uint[] {_textureID});

                if (_images != null)
                    for (int i = 0; i < _images.Length; i++)
                        if (_images[i] != null)
                            _images[i].Dispose();

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