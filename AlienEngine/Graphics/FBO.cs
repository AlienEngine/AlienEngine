using System;
using System.Drawing;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Graphics
{
    /// <summary>
    /// Encapsulates a frame buffer and its associated depth buffer (if applicable).
    /// </summary>
    public class FBO : IDisposable
    {
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
        public FBO(int width, int height, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true)
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
        public FBO(Sizei size, FramebufferAttachment attachment = FramebufferAttachment.ColorAttachment0, PixelInternalFormat format = PixelInternalFormat.Rgba8, bool mipmaps = true)
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
        public FBO(Sizei size, FramebufferAttachment[] attachments, PixelInternalFormat format, bool mipmaps = false, TextureParameter filterType = TextureParameter.Linear, PixelType pixelType = PixelType.UnsignedByte)
        {
            this.Size = size;
            this.Attachments = attachments;
            this.Format = format;
            this.MipMaps = mipmaps;

            // First create the framebuffer
            BufferID = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);

            if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
            {
                // if this is a depth attachment only
                TextureID = new uint[] { GL.GenTexture() };
                GL.BindTexture(TextureTarget.Texture2D, TextureID[0]);

                GL.TexImage2D(TextureTarget.Texture2D, 0, Format, Size.Width, Size.Height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureID[0], 0);
                GL.DrawBuffer(DrawBufferMode.None);
                GL.ReadBuffer(ReadBufferMode.None);
            }
            else
            {
                // Create n texture buffers (known by the number of attachments)
                TextureID = new uint[Attachments.Length];
                GL.GenTextures(Attachments.Length, TextureID);

                // Bind the n texture buffers to the framebuffer
                for (int i = 0; i < Attachments.Length; i++)
                {
                    GL.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, Format, Size.Width, Size.Height, 0, PixelFormat.Rgba, pixelType, IntPtr.Zero);
                    if (MipMaps)
                    {
                        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
                        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.LinearMipMapLinear);
                        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                    }
                    else
                    {
                        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, filterType);
                        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, filterType);
                    }
                    GL.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[i], TextureID[i], 0);
                }

                // Create and attach a 24-bit depth buffer to the framebuffer
                DepthID = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, DepthID);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Depth24Stencil8, Size.Width, Size.Height, 0, PixelFormat.DepthStencil, PixelType.UnsignedInt248, IntPtr.Zero);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, DepthID, 0);
                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.StencilAttachment, DepthID, 0);
            }

            // Build the framebuffer and check for errors
            FramebufferStatus status = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            if (status != FramebufferStatus.FramebufferComplete)
            {
                Console.WriteLine("Frame buffer did not compile correctly.  Returned {0}, glError: {1}", status.ToString(), GL.GetError().ToString());
            }

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
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
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, BufferID);
            if (Attachments.Length == 1)
            {
                GL.BindTexture(TextureTarget.Texture2D, TextureID[0]);
                GL.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[0], TextureID[0], 0);
            }
            else
            {
                DrawBuffersEnum[] buffers = new DrawBuffersEnum[Attachments.Length];

                for (int i = 0; i < Attachments.Length; i++)
                {
                    GL.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                    GL.FramebufferTexture(FramebufferTarget.Framebuffer, Attachments[i], TextureID[i], 0);
                    buffers[i] = (DrawBuffersEnum)Attachments[i];
                }

                GL.BindTexture(TextureTarget.Texture2D, DepthID);
                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, DepthID, 0);

                if (Attachments.Length > 1) GL.DrawBuffers(Attachments.Length, buffers);
            }

            GL.Viewport(0, 0, Size.Width, Size.Height);

            // configurably clear the buffer and color bits
            if (clear)
            {
                if (Attachments.Length == 1 && Attachments[0] == FramebufferAttachment.DepthAttachment)
                    GL.Clear(ClearBufferMask.DepthBufferBit);
                else
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            }
        }

        /// <summary>
        /// Unbinds the framebuffer and then generates the mipmaps of each renderbuffer.
        /// </summary>
        public void Disable()
        {
            // unbind this framebuffer (does not guarantee the correct framebuffer is bound)
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            // have to generate mipmaps here
            for (int i = 0; i < Attachments.Length && MipMaps; i++)
            {
                GL.BindTexture(TextureTarget.Texture2D, TextureID[i]);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }
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
