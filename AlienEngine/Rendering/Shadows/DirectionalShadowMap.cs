using System;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Rendering.Shadows;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Rendering.Shadows
{
    public class DirectionalShadowMap : IShadowMap, IDisposable
    {
        // The texutre size
        private Sizei _textureSize;

        // The depth buffer id
        private uint _depthMap;

        // The depth buffer texure
        private uint _depthMapTexture;

        private bool _cascaded;
        
        /// <summary>
        /// The FBO ID of this shadow map.
        /// </summary>
        public uint BufferID => _depthMap;

        /// <summary>
        /// The texture ID used by this shadow map.
        /// </summary>
        public uint TextureID => _depthMapTexture;

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

        public bool Cascaded => _cascaded;

        public DirectionalShadowMap(int textureSize, int splitsCount = 1)
        {
            // Save the texture size
            _textureSize = Sizei.One * textureSize;

            // Generate the frame buffer
            _depthMap = GL.GenFramebuffer();

            // Generate the texture
            _depthMapTexture = GL.GenTexture();

            // Cascaded shadow mapping default state
            _cascaded = false;

            if (splitsCount == 1)
            {
                // Bind the texture
                GL.BindTexture(TextureTarget.Texture2D, _depthMapTexture);

                // Set the texture type
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.DepthComponent, Width, Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);

                // Set texture parameters
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureMagFilter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureMagFilter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToBorder);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToBorder);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.DepthTextureMode, DepthTextureMode.Intensity);
                GL.TexParameterfv(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor, 1.0f, 1.0f, 1.0f, 1.0f);

                // Make sure this texture is not altered from the outside
                GL.BindTexture(TextureTarget.Texture2D, 0);

                // Bind the framebuffer
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, _depthMap);

                // Attach depth texture as framebuffer object's depth buffer
                GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureTarget.Texture2D, _depthMapTexture, 0);
            }
            else
            {
                // Cascaded shadow mapping
                _cascaded = true;
                
                // Bind the texture
                GL.BindTexture(TextureTarget.Texture2DArray, _depthMapTexture);

                // Set the texture type
                GL.TexStorage3D(TextureTarget.Texture2DArray, 1, PixelInternalFormat.DepthComponent, Width, Height, splitsCount);

                // Make sure this texture is not altered from the outside
                GL.BindTexture(TextureTarget.Texture2DArray, 0);

                // Bind the framebuffer
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, _depthMap);

                // Attach depth texture as framebuffer object's depth buffer
                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, _depthMapTexture, 0);
            }

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
            {
                GL.ClearDepth(1.0);
                RendererManager.ClearScreen(ClearBufferMask.DepthBufferBit);
            }
        }

        public void End()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        public void BindTexture()
        {
            GL.ActiveTexture(GL.SHADOW_TEXTURE_UNIT_INDEX);
            GL.BindTexture(_cascaded ? TextureTarget.Texture2DArray : TextureTarget.Texture2D, _depthMapTexture);
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

        ~DirectionalShadowMap()
        {
            ReleaseUnmanagedResources();
        }
    }
}