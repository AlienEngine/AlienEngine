using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Graphics
{
    /// <summary>
    /// Encapsulates a frame buffer and its associated depth buffer (if applicable).
    /// </summary>
    public class FBO : IDisposable
    {
        private Dictionary<FramebufferAttachment, uint> _attachementMap;

        #region Properties
        /// <summary>
        /// The ID for the entire framebuffer object.
        /// </summary>
        [CLSCompliant(false)]
        public uint BufferID { get; private set; }

        /// <summary>
        /// The IDs for each of the renderbuffer attachments.
        /// </summary>
        [CLSCompliant(false)]
        public uint[] TextureID { get; private set; }

        /// <summary>
        /// The ID for the single depth buffer attachment.
        /// </summary>
        [CLSCompliant(false)]
        public uint DepthID { get; private set; }

        /// <summary>
        /// The size (in pixels) of all renderbuffers associated with this framebuffer.
        /// </summary>
        public Sizei Size { get; private set; }

        /// <summary>
        /// The attachments used by this framebuffer.
        /// </summary>
        public FramebufferAttachment[] Attachments { get; private set; }

        /// <summary>
        /// The internal pixel format for each of the renderbuffers (depth buffer not included).
        /// </summary>
        public PixelInternalFormat Format { get; private set; }

        /// <summary>
        /// Specifies whether to build mipmaps after the frame buffer is unbound.
        /// </summary>
        public bool MipMaps { get; private set; }

        /// <summary>
        /// Specifies whether the FBO is multisampled.
        /// </summary>
        public bool Multisampled { get; private set; }
        #endregion

        #region Constructor and Destructor
        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="width">Specifies the width (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="height">Specifies the height (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachment">Specifies the attachment to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        public FBO(int width, int height, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true, bool renderbuffer = true, bool multisampled = false)
            : this(new Sizei(width, height), new FramebufferAttachment[] { attachment }, format, mipmaps)
        {
        }

        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="size">Specifies the size (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachment">Specifies the attachment to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        public FBO(Sizei size, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true, bool renderbuffer = true, bool multisampled = false)
            : this(size, new FramebufferAttachment[] { attachment }, format, mipmaps)
        {
        }

        /// <summary>
        /// Creates a framebuffer object and its associated resources (depth and frame buffers).
        /// </summary>
        /// <param name="size">Specifies the size (in pixels) of the framebuffer and its associated buffers.</param>
        /// <param name="attachments">Specifies the attachments to use for the frame buffer.</param>
        /// <param name="format">Specifies the internal pixel format for the frame buffer.</param>
        /// <param name="mipmaps">Specifies whether to build mipmaps after the frame buffer is unbound.</param>
        /// <param name="filterType">Specifies the type of filtering to apply to the frame buffer when bound as a texture.</param>
        /// <param name="pixelType">Specifies the pixel type to use for the underlying format of the frame buffer.</param>
        public FBO(Sizei size, FramebufferAttachment[] attachments, PixelInternalFormat format, bool mipmaps = false, TextureParameter filterType = TextureParameter.Linear, PixelType pixelType = PixelType.UnsignedByte, bool renderbuffer = true, bool multisampled = false)
        {
            Size = size;
            Attachments = attachments;
            Format = format;
            MipMaps = mipmaps;
            Multisampled = multisampled;

            // First create the framebuffer
            BufferID = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);

            _attachementMap = new Dictionary<FramebufferAttachment, uint>();
            TextureTarget textureTarget = Multisampled ? TextureTarget.Texture2DMultisample : TextureTarget.Texture2D;

            if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
            {
                // if this is a depth attachment only
                TextureID = new uint[] { GL.GenTexture() };
                GL.BindTexture(textureTarget, TextureID[0]);

                if (Multisampled)
                {
                    GL.TexImage2DMultisample(textureTarget, GameSettings.MultisampleLevel, Format, Size.Width, Size.Height, true);
                }
                else
                {
                    GL.TexImage2D(textureTarget, 0, Format, Size.Width, Size.Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
                    GL.TexParameteri(textureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                    GL.TexParameteri(textureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                    GL.TexParameteri(textureTarget, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                    GL.TexParameteri(textureTarget, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                }

                GL.BindTexture(textureTarget, 0);
                GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, textureTarget, TextureID[0], 0);
                GL.DrawBuffer(DrawBufferMode.None);
                GL.ReadBuffer(ReadBufferMode.None);

                _attachementMap.Add(FramebufferAttachment.DepthAttachment, 0);
            }
            else
            {
                // Create n texture buffers (known by the number of attachments)
                TextureID = new uint[Attachments.Length];
                GL.GenTextures(Attachments.Length, TextureID);

                // Bind the n texture buffers to the framebuffer
                for (int i = 0; i < Attachments.Length; i++)
                {
                    GL.BindTexture(textureTarget, TextureID[i]);

                    if (Multisampled)
                    {
                        GL.TexImage2DMultisample(textureTarget, GameSettings.MultisampleLevel, Format, Size.Width, Size.Height, true);
                    }
                    else
                    {
                        GL.TexImage2D(textureTarget, 0, Format, Size.Width, Size.Height, 0, PixelFormat.Rgba, pixelType, IntPtr.Zero);

                        if (MipMaps)
                        {
                            GL.TexParameteri(textureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
                            GL.TexParameteri(textureTarget, TextureParameterName.TextureMinFilter, TextureParameter.LinearMipMapLinear);
                            GL.GenerateMipmap(Multisampled ? GenerateMipmapTarget.Texture2DMultisample : GenerateMipmapTarget.Texture2D);
                        }
                        else
                        {
                            GL.TexParameteri(textureTarget, TextureParameterName.TextureMagFilter, filterType);
                            GL.TexParameteri(textureTarget, TextureParameterName.TextureMinFilter, filterType);
                        }
                    }

                    GL.BindTexture(textureTarget, 0);
                    GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, Attachments[i], textureTarget, TextureID[i], 0);

                    _attachementMap.Add(Attachments[i], TextureID[i]);
                }

                if (renderbuffer)
                {
                    // Create and attach a 24-bit depth buffer to the framebuffer
                    DepthID = GL.GenRenderbuffer();
                    GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, DepthID);

                    if (Multisampled)
                        GL.RenderbufferStorageMultisample(RenderbufferTarget.Renderbuffer, GameSettings.MultisampleLevel, PixelInternalFormat.Depth32fStencil8, Size.Width, Size.Height);
                    else
                        GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, PixelInternalFormat.Depth24Stencil8, Size.Width, Size.Height);

                    GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
                    GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer, DepthID);

                    //GL.TexParameteri(textureTarget, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                    //GL.TexParameteri(textureTarget, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                    //GL.TexParameteri(textureTarget, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                    //GL.TexParameteri(textureTarget, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

                    //GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, textureTarget, DepthID, 0);
                    //GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.StencilAttachment, textureTarget, DepthID, 0);

                    _attachementMap.Add(FramebufferAttachment.DepthStencilAttachment, DepthID);
                    //_attachementMap.Add(FramebufferAttachment.StencilAttachment, DepthID);
                }
            }

            // Build the framebuffer and check for errors
            FramebufferStatus status = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            if (status != FramebufferStatus.FramebufferComplete)
            {
                Console.WriteLine("Frame buffer did not compile correctly.  Returned {0}, glError: {1}", status.ToString(), GL.GetError().ToString());
            }

            // Make sure this framebuffer is not modified from outside
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            // Register this framebuffer as a disposable object
            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Check to ensure that the FBO was disposed of properly.
        /// </summary>
        ~FBO()
        {
            Dispose(false);
        }
        #endregion

        #region Enable and Disable
        /// <summary>
        /// Binds the framebuffer and all of the renderbuffers.
        /// Clears the buffer bits and sets viewport size.
        /// Perform all rendering after this call.
        /// </summary>
        /// <param name="clear">True to clear both the color and depth buffer bits of the FBO before enabling.</param>
        public void Enable(bool clear = true)
        {
            TextureTarget textureTarget = Multisampled ? TextureTarget.Texture2DMultisample : TextureTarget.Texture2D;
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);

            if (Attachments.Length == 1)
            {
                GL.BindTexture(textureTarget, TextureID[0]);
                GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, Attachments[0], textureTarget, TextureID[0], 0);
            }
            else
            {
                DrawBuffersEnum[] buffers = new DrawBuffersEnum[Attachments.Length];

                for (int i = 0; i < Attachments.Length; i++)
                {
                    GL.BindTexture(textureTarget, TextureID[i]);
                    GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, Attachments[i], textureTarget, TextureID[i], 0);
                    buffers[i] = (DrawBuffersEnum)Attachments[i];
                }

                GL.BindTexture(textureTarget, DepthID);
                GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, textureTarget, DepthID, 0);

                if (Attachments.Length > 1) GL.DrawBuffers(Attachments.Length, buffers);
            }

            GL.Viewport(0, 0, Size.Width, Size.Height);

            // configurably clear the buffer and color bits
            if (clear)
            {
                if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
                    RendererManager.ClearScreen(ClearBufferMask.DepthBufferBit);
                else
                    RendererManager.ClearScreen(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
            }
        }

        /// <summary>
        /// Unbinds the framebuffer and then generates the mipmaps of each renderbuffer.
        /// </summary>
        public void Disable(FBO screenFBO = null)
        {
            // Copy framebuffer texture to a not multisampled FBO if this one is.
            if (Multisampled)
            {
                GL.BindFramebuffer(FramebufferTarget.ReadFramebuffer, BufferID);
                GL.BindFramebuffer(FramebufferTarget.DrawFramebuffer, (screenFBO != null) ? screenFBO.BufferID : 0);
                GL.BlitFramebuffer(0, 0, Size.Width, Size.Height, 0, 0, Size.Width, Size.Height, ClearBufferMask.ColorBufferBit, BlitFramebufferFilter.Nearest);
            }

            // Unbind this framebuffer (does not guarantee the correct framebuffer is bound)
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            if (MipMaps)
            {
                // Have to generate mipmaps here
                for (int i = 0; i < Attachments.Length && MipMaps; i++)
                {
                    GL.BindTexture(Multisampled ? TextureTarget.Texture2DMultisample : TextureTarget.Texture2D, TextureID[i]);
                    GL.GenerateMipmap(Multisampled ? GenerateMipmapTarget.Texture2DMultisample : GenerateMipmapTarget.Texture2D);
                }
            }
        }
        #endregion

        #region Get Texture ID
        [CLSCompliant(false)]
        public uint GetTextureID(FramebufferAttachment attachement)
        {
            return _attachementMap[attachement];
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (DepthID != 0 || BufferID != 0 || TextureID != null)
            {
                GL.DeleteTextures(TextureID.Length, TextureID);
                GL.DeleteFramebuffers(1, new uint[] { BufferID });
                GL.DeleteFramebuffers(1, new uint[] { DepthID });

                BufferID = 0;
                DepthID = 0;
                TextureID = null;
            }
        }
        #endregion
    }
}
