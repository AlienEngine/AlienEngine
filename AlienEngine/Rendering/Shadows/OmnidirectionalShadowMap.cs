using System;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Rendering.Shadows
{
    public class OmnidirectionalShadowMap: IShadowMap, IDisposable
    {
        // The texutre size
        private Sizei _textureSize;

        // The depth buffer id
        private uint _depthMap;

        // The depth buffer texure
        private uint _depthMapTexture;

        /// <summary>
        /// The FBO ID of this shadow map.
        /// </summary>
        public uint BufferID => _depthMap;

        /// <summary>
        /// The texture ID used by this shadow map.
        /// </summary>
        public uint TextureID => _depthMapTexture;

        public bool Cascaded { get; }

        /// <summary>
        /// The texture size of the shadow map.
        /// </summary>
        public Sizei TextureSize => _textureSize;

        /// <summary>
        /// The texture width of the shadow map.
        /// </summary>
        public int Width => _textureSize.Width;

        /// <summary>
        /// The texture height of the shadow map.
        /// </summary>
        public int Height => _textureSize.Height;

        public OmnidirectionalShadowMap(int textureSize)
        {
            // Save the texture size
            _textureSize = Sizei.One * textureSize;

            // Generate the frame buffer
            _depthMap = GL.GenFramebuffer();

            // Generate the texture
            _depthMapTexture = GL.GenTexture();

            // Bind the texture
            GL.BindTexture(TextureTarget.TextureCubeMap, _depthMapTexture);

            // Set the texture type
            GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
            GL.TexImage2D(TextureTarget.TextureCubeMapNegativeX, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
            GL.TexImage2D(TextureTarget.TextureCubeMapPositiveY, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
            GL.TexImage2D(TextureTarget.TextureCubeMapNegativeY, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
            GL.TexImage2D(TextureTarget.TextureCubeMapPositiveZ, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
            GL.TexImage2D(TextureTarget.TextureCubeMapNegativeZ, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);

            // Set texture parameters
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureMagFilter.Nearest);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureMagFilter.Nearest);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, TextureParameter.ClampToEdge);

            // Bind the framebuffer
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, _depthMap);

            // Attach depth texture as framebuffer object's depth buffer
            GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, _depthMapTexture, 0);
            GL.DrawBuffer(DrawBufferMode.None);
            GL.ReadBuffer(ReadBufferMode.None);

            // Avoid changes on this FBO from the outside
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            // Register this resource as a renderable resource
            ResourcesManager.AddDisposableResource(this);
        }

        public void Begin(bool clear = true)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);

            // Configurably clear the depth buffer bits
            if (clear)
                RendererManager.ClearScreen(ClearBufferMask.DepthBufferBit);
        }

        public void End()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        public void BindTexture()
        {
            throw new NotImplementedException();
        }


        private void ReleaseUnmanagedResources()
        {
            if (_depthMapTexture != 0)
                GL.DeleteTexture(_depthMapTexture);

            if (_depthMap != 0)
                GL.DeleteFramebuffers(1, new uint[] { _depthMap });
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~OmnidirectionalShadowMap()
        {
            ReleaseUnmanagedResources();
        }
    }
}