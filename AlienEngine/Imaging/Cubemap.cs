using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Imaging.DevIL;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.Shaders;
using System;

namespace AlienEngine.Imaging
{
    public class Cubemap : IResource
    {
        private string[] _textures;
        private Image[] _images;
        private uint _textureID;
        private Mesh _cube;
        private CubemapShaderProgram _program;
        private bool _loaded;
        private Camera _camera;

        private static readonly TextureTarget[] Types = new TextureTarget[6]
        {
            TextureTarget.TextureCubeMapPositiveX,
            TextureTarget.TextureCubeMapNegativeX,
            TextureTarget.TextureCubeMapPositiveY,
            TextureTarget.TextureCubeMapNegativeY,
            TextureTarget.TextureCubeMapPositiveZ,
            TextureTarget.TextureCubeMapNegativeZ
        };

        public Cubemap()
        {
            _textures = new string[6];
            _images = new Image[6] {null, null, null, null, null, null};

            _textureID = 0;
        }
        
        public Cubemap(string posx, string negx, string posy, string negy, string posz, string negz): this()
        {
            _textures[0] = posx;
            _textures[1] = negx;
            _textures[2] = posy;
            _textures[3] = negy;
            _textures[4] = posz;
            _textures[5] = negz;
        }

        #region Methods

        private void _loadCubeSide(uint sideID)
        {
            _loadBitmap(sideID);
        }

        private void _loadBitmap(uint sideID)
        {
            if (_images[sideID] == null)
            {
                // Create the image
                _images[sideID] = Image.FromFile(_textures[sideID]);
            }

            GL.TexImage2D(Types[sideID], 0, PixelInternalFormat.Rgba8, _images[sideID].Width, _images[sideID].Height, 0,
                PixelFormat.Bgra, PixelType.UnsignedByte, _images[sideID].Pixels);
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
        }

        public bool Load()
        {
            if (!_loaded)
            {
                _camera = Game.Instance.CurrentScene.PrimaryCamera.GetComponent<Camera>();
                _program = new CubemapShaderProgram();
                _cube = MeshFactory.CreateCube(Vector3f.One * -_camera.Far / 2, Vector3f.One * _camera.Far / 2);

                _textureID = GL.GenTexture();
                GL.BindTexture(TextureTarget.TextureCubeMap, _textureID);

                for (uint i = 0; i < Types.Length; i++)
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

        public bool Load(string paths)
        {
            var sides = paths.Split(' ');

            if (sides.Length != 6)
                return false;

            for (int i = 0; i < 6; i++)
                _textures[i] = sides[i];

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
            RendererManager.BackupState(RendererBackupMode.FaceCulling);
            RendererManager.FaceCulling(false);

            RendererManager.BackupState(RendererBackupMode.DepthMask);
            RendererManager.DepthMask(false);

            _program.Bind();
            _program.SetUniform("pcm_matrix", _camera.CubemapMatrix * _camera.ProjectionMatrix);
            _program.SetUniform("textureCubemap", GL.DIFFUSE_TEXTURE_UNIT_INDEX);

            GL.BindVertexArray(_cube.VAO);

            Bind(GL.DIFFUSE_TEXTURE_UNIT_INDEX);
            _cube.Render();
            Unbind();

            GL.BindVertexArray(0);

            RendererManager.RestoreState(RendererBackupMode.DepthMask);
            RendererManager.RestoreState(RendererBackupMode.FaceCulling);
        }

        #endregion

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_textureID != 0)
                    GL.DeleteTexture(_textureID);

                if (_images != null)
                    for (int i = 0; i < _images.Length; i++)
                        if (_images[i] != null)
                            _images[i].Dispose();

                _disposedValue = true;
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