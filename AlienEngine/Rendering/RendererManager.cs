﻿using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Shaders;
using AlienEngine.Shaders;
using System;
using System.Collections.Generic;
using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics.Buffers;
using AlienEngine.Core.Graphics.Buffers.Data;
using System.Diagnostics;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering.Shadows;

namespace AlienEngine.Core.Rendering
{
    // TODO: Use stacks for backups
    // TODO: Comment code!
    public static class RendererManager
    {
        private static List<IRenderable> _renderables;
        private static List<IPostRenderable> _postRenderables;
        private static bool _faceCullingEnabled;
        private static bool _depthTestEnabled;
        private static bool _depthMaskEnabled;
        private static bool _blendingEnabled;
        private static bool _multisampleEnabled;
        private static bool _gammaCorrectionEnabled;
        private static bool _renderBufferEnabled;
        private static bool _shadowMapDepthPass;
        private static uint _screenVAO;
        private static uint _screenVBO;
        private static ShaderProgram _screenShaderProgram;
        private static Rectangle _viewport;

        private static UBO _matricesUBO;
        private static UBO _cameraUBO;

        private static FBO _renderFBO;
        private static FBO _screenFBO;

        // Renderers
        private static ShadowsRenderer _shadowsRenderer;
        
        // Depth test
        private static DepthFunction _depthTestFunction;

        // Face culling
        private static CullFaceMode _faceCullingMode;
        private static FrontFaceDirection _faceCullingFrontFaceDirection;

        // Blending
        private static BlendingFactorSrc _blendingFactorSrc;
        private static BlendingFactorDest _blendingFactorDest;

        // Backup
        private static Stack<Tuple<bool, CullFaceMode, FrontFaceDirection>> _faceCullingBackup;

        private static Stack<Tuple<bool, DepthFunction>> _depthTestBackup;

        private static Stack<Tuple<bool>> _depthMaskBackup;

        private static Stack<Tuple<bool>> _gammaCorrectionBackup;

        private static Stack<Tuple<bool, BlendingFactorSrc, BlendingFactorDest>> _blendingBackup;

        public static Rectangle Viewport => _viewport;

        public static bool IsFaceCullingEnabled => _faceCullingEnabled;

        public static bool IsDepthTestEnabled => _depthTestEnabled;

        public static bool IsDepthMaskEnabled => _depthMaskEnabled;

        public static bool IsBlendingEnabled => _blendingEnabled;

        public static bool IsMultisampleEnabled => _multisampleEnabled;

        public static bool IsGammaCorrectionEnabled => _gammaCorrectionEnabled;

        public static bool IsRenderBufferEnabled => _renderBufferEnabled;

        public static bool IsShadowMapDepthPass => _shadowMapDepthPass;

        internal static readonly MatricesBufferData MatricesData;
        internal static readonly CameraBufferData CameraData;

        public static UBO MatricesUBO => _matricesUBO;

        internal static ShaderProgram DepthShaderProgram => _shadowsRenderer.DepthShaderProgram;

        internal static IShadowMap CurrentShadowMap => _shadowsRenderer.CurrentShadowMap;

        internal static float[] CascadedShadowMapSplits => _shadowsRenderer.CascadedShadowMapSplits;

        internal static int ShadowMapTextureSize => _shadowsRenderer.ShadowMapTextureSize;

        public delegate void ViewportChanged(object sender, ViewportChangedEventArgs e);

        public static event ViewportChanged OnViewportChange;

        static RendererManager()
        {
            // Renderers
            _shadowsRenderer = new ShadowsRenderer();
            
            // Renderables
            _renderables = new List<IRenderable>();
            _postRenderables = new List<IPostRenderable>();

            // States
            _depthTestEnabled = false;
            _depthMaskEnabled = true;
            _blendingEnabled = false;
            _faceCullingEnabled = false;
            _multisampleEnabled = false;
            _gammaCorrectionEnabled = false;
            _renderBufferEnabled = false;
            _shadowMapDepthPass = false;

            // Backups
            _faceCullingBackup = new Stack<Tuple<bool, CullFaceMode, FrontFaceDirection>>();
            _depthTestBackup = new Stack<Tuple<bool, DepthFunction>>();
            _depthMaskBackup = new Stack<Tuple<bool>>();
            _blendingBackup = new Stack<Tuple<bool, BlendingFactorSrc, BlendingFactorDest>>();
            _gammaCorrectionBackup = new Stack<Tuple<bool>>();

            // Viewport
            _viewport = Rectangle.Empty;

            // UBOs data
            MatricesData = new MatricesBufferData();
            CameraData = new CameraBufferData();

            // Screen
            _screenVAO = 0;
            _screenVBO = 0;
        }

        internal static void SetViewportWithAspectRatio(int width, int height)
        {
            int wr = width,
                hr = width * GameSettings.GameWindowAspectRatio[1] / GameSettings.GameWindowAspectRatio[0],
                offset = (height - hr) / 2;

            SetViewport(0, offset, wr, hr);
        }

        public static void SetViewportWithAspectRatio(Sizei size)
        {
            SetViewportWithAspectRatio(size.Width, size.Height);
        }

        public static void Initialize()
        {
            // UBOs
            _matricesUBO = new UBO("Matrices", UniformBufferObjectIndex.Matrices, MatricesBufferData.Size);
            _cameraUBO = new UBO("Camera", UniformBufferObjectIndex.Camera, CameraBufferData.Size);

            MatricesData.RegisterUBO(_matricesUBO);
            CameraData.RegisterUBO(_cameraUBO);

            // Framebuffers
            _renderFBO = new FBO(Viewport, multisampled: GameSettings.MultisampleEnabled);
            _screenFBO = new FBO(_renderFBO.Viewport);

            // Shadow mapping
            _shadowsRenderer.Initialize();
        }

        public static void BackupState(RendererBackupMode mode)
        {
            switch (mode)
            {
                case RendererBackupMode.DepthTest:
                    _depthTestBackup.Push(new Tuple<bool, DepthFunction>(_depthTestEnabled, _depthTestFunction));
                    break;
                case RendererBackupMode.DepthMask:
                    _depthMaskBackup.Push(new Tuple<bool>(_depthMaskEnabled));
                    break;
                case RendererBackupMode.Blending:
                    _blendingBackup.Push(new Tuple<bool, BlendingFactorSrc, BlendingFactorDest>(_blendingEnabled,
                        _blendingFactorSrc, _blendingFactorDest));
                    break;
                case RendererBackupMode.FaceCulling:
                    _faceCullingBackup.Push(new Tuple<bool, CullFaceMode, FrontFaceDirection>(_faceCullingEnabled,
                        _faceCullingMode, _faceCullingFrontFaceDirection));
                    break;
                case RendererBackupMode.GammaCorrection:
                    _gammaCorrectionBackup.Push(new Tuple<bool>(_gammaCorrectionEnabled));
                    break;
            }
        }

        public static void RestoreState(RendererBackupMode mode)
        {
            switch (mode)
            {
                case RendererBackupMode.DepthTest:
                    if (_depthTestBackup != null)
                    {
                        var bcp = _depthTestBackup.Pop();
                        DepthTest(bcp.Item1, bcp.Item2);
                    }
                    break;
                case RendererBackupMode.DepthMask:
                    if (_depthMaskBackup != null)
                    {
                        var bcp = _depthMaskBackup.Pop();
                        DepthMask(bcp.Item1);
                    }
                    break;
                case RendererBackupMode.Blending:
                    if (_blendingBackup != null)
                    {
                        var bcp = _blendingBackup.Pop();
                        Blending(bcp.Item1, bcp.Item2, bcp.Item3);
                    }
                    break;
                case RendererBackupMode.FaceCulling:
                    if (_faceCullingBackup != null)
                    {
                        var bcp = _faceCullingBackup.Pop();
                        FaceCulling(bcp.Item1, bcp.Item2, bcp.Item3);
                    }
                    break;
                case RendererBackupMode.GammaCorrection:
                    if (_gammaCorrectionBackup != null)
                    {
                        var bcp = _gammaCorrectionBackup.Pop();
                        GammaCorrection(bcp.Item1);
                    }
                    break;
            }
        }

        public static void RegisterRenderable(IRenderable _object)
        {
            if (!HasRenderable(_object))
                _renderables.Add(_object);
        }

        public static void UnregisterRenderable(IRenderable _object)
        {
            if (HasRenderable(_object))
                _renderables.Remove(_object);
        }

        public static bool HasRenderable(IRenderable _object)
        {
            return _renderables.Contains(_object);
        }

        public static void RegisterPostRenderable(IPostRenderable _object)
        {
            if (!HasPostRenderable(_object))
                _postRenderables.Add(_object);
        }

        public static void UnregisterPostRenderable(IPostRenderable _object)
        {
            if (HasPostRenderable(_object))
                _postRenderables.Remove(_object);
        }

        public static bool HasPostRenderable(IPostRenderable _object)
        {
            return _postRenderables.Contains(_object);
        }

        public static void SetViewport(int x, int y, int width, int height)
        {
            Rectangle old = _viewport;
            GL.Viewport(x, y, width, height);
            _viewport = new Rectangle(x, y, width, height);
            OnViewportChange?.Invoke(null, new ViewportChangedEventArgs(old, _viewport));
        }

        public static void SetViewport(Rectangle viewport)
        {
            SetViewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
        }

        public static void SetViewport(Point2i location, Sizei size)
        {
            SetViewport(location.X, location.Y, size.Width, size.Height);
        }

        public static void ClearScreen(
            ClearBufferMask mask = ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit)
        {
            GL.Clear(mask);
        }

        public static void DepthTest(bool enable = true, DepthFunction depthFunction = DepthFunction.Less)
        {
            if (enable)
            {
                if (!_depthTestEnabled) GL.Enable(EnableCap.DepthTest);
                GL.DepthFunc(depthFunction);

                _depthTestFunction = depthFunction;
            }
            else if (_depthTestEnabled) GL.Disable(EnableCap.DepthTest);

            _depthTestEnabled = enable;
        }

        public static void DepthMask(bool enable = true)
        {
            GL.DepthMask(enable);
            _depthMaskEnabled = enable;
        }

        public static void Blending(bool enable = true, BlendingFactorSrc srcFactor = BlendingFactorSrc.SrcAlpha,
            BlendingFactorDest dstFactor = BlendingFactorDest.OneMinusSrcAlpha)
        {
            if (enable)
            {
                if (!_blendingEnabled) GL.Enable(EnableCap.Blend);
                GL.BlendFunc(srcFactor, dstFactor);

                _blendingFactorSrc = srcFactor;
                _blendingFactorDest = dstFactor;
            }
            else if (_blendingEnabled) GL.Disable(EnableCap.Blend);

            _blendingEnabled = enable;
        }

        public static void FaceCulling(bool enable = true, CullFaceMode cullFaceMode = CullFaceMode.Back,
            FrontFaceDirection frontFace = FrontFaceDirection.Ccw)
        {
            if (enable)
            {
                if (!_faceCullingEnabled) GL.Enable(EnableCap.CullFace);
                GL.CullFace(cullFaceMode);
                GL.FrontFace(frontFace);

                _faceCullingMode = cullFaceMode;
                _faceCullingFrontFaceDirection = frontFace;
            }
            else if (_faceCullingEnabled) GL.Disable(EnableCap.CullFace);

            _faceCullingEnabled = enable;
        }

        public static void MultiSample(bool enable = true)
        {
            if (enable)
            {
                if (!_multisampleEnabled) GL.Enable(EnableCap.Multisample);
            }
            else if (_multisampleEnabled) GL.Disable(EnableCap.Multisample);

            _multisampleEnabled = enable;
        }

        public static void GammaCorrection(bool enable = true)
        {
            if (enable)
            {
                GL.Enable(EnableCap.FramebufferSrgb);
            }
            else if (_gammaCorrectionEnabled) GL.Disable(EnableCap.FramebufferSrgb);

            _gammaCorrectionEnabled = enable;
        }

        private static Mesh _screen;

        public static void RenderScreen()
        {
            var fbo = GameSettings.MultisampleEnabled ? _screenFBO : _renderFBO;

            // Create the screen if it's not exist
            if (_screenVAO == 0)
            {
                // TODO: Calculate aspect ratio (w/h) and compute the new width according to h
                _screen = MeshFactory.CreateQuad(-Point2f.One, Sizef.One * 2, Point2f.Zero, Sizef.One);

                float[] indArray = new float[]
                {
                    -1.0f, 1.0f, 0.0f, 1.0f,
                    1.0f, 1.0f, 1.0f, 1.0f,
                    1.0f, -1.0f, 1.0f, 0.0f,

                    1.0f, -1.0f, 1.0f, 0.0f,
                    -1.0f, -1.0f, 0.0f, 0.0f,
                    -1.0f, 1.0f, 0.0f, 1.0f
                };

                _screenVAO = GL.GenVertexArray();
                _screenVBO = GL.GenBuffer();

                GL.BindVertexArray(_screenVAO);
                GL.BindBuffer(BufferTarget.ArrayBuffer, _screenVBO);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * indArray.Length, indArray,
                    BufferUsageHint.StaticDraw);
                GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, 2, VertexAttribPointerType.Float, false,
                    4 * sizeof(float), 0);
                GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, 2, VertexAttribPointerType.Float, false,
                    4 * sizeof(float), 2 * sizeof(float));

                _screenShaderProgram = new RenderTextureShaderProgram()
                {
                    PostEffectMode = PostEffectMode.None,
                    Width = fbo.Viewport.Width,
                    Height = fbo.Viewport.Height
                };
            }

            // Save states
            BackupState(RendererBackupMode.GammaCorrection);
            BackupState(RendererBackupMode.DepthTest);
            BackupState(RendererBackupMode.FaceCulling);

            DepthTest(false);
            FaceCulling(false);
            GammaCorrection(GameSettings.GammaCorrectionEnabled);

            // Bind the shader
            _screenShaderProgram.Bind();

            // Bind the vertex array
            // GL.BindVertexArray(_screenVAO);

            // Bind the texture
            GL.ActiveTexture(GL.DIFFUSE_TEXTURE_UNIT_INDEX);
            GL.BindTexture(TextureTarget.Texture2D, fbo.GetTextureID(FramebufferAttachment.ColorAttachment0));

            SetViewport(Viewport);

            // Draw the screen
            // GL.DrawArrays(BeginMode.Triangles, 0, 6);
            _screen.Render();

            // Make sure this texture don't change from the outside
            GL.BindTexture(TextureTarget.Texture2D, 0);

            // Make sure this VAO don't change from the outside
            //GL.BindVertexArray(0);

            // Restore states
            RestoreState(RendererBackupMode.GammaCorrection);
            RestoreState(RendererBackupMode.DepthTest);
            RestoreState(RendererBackupMode.FaceCulling);
        }

        public static void RenderAll()
        {
            // Render all renderable objects
            foreach (IRenderable _object in _renderables)
                _object.Render();

            BackupState(RendererBackupMode.DepthTest);
            DepthTest(true, DepthFunction.Lequal);

            // Render the skybox
            Camera camera = SceneManager.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            switch (camera.ClearScreenType)
            {
                case ClearScreenTypes.Color:
                    GL.ClearColor(camera.ClearColor);
                    break;
                case ClearScreenTypes.Cubemap:
                    camera.Cubemap?.Render();
                    break;
            }

            DepthTest(true, DepthFunction.Always);

            // Render all post-state renderable objects 
            foreach (IPostRenderable _object in _postRenderables)
                _object.Render();

            RestoreState(RendererBackupMode.DepthTest);
        }

        public static void EnableRenderBuffer()
        {
            if (!_renderBufferEnabled)
            {
                // Enable Framebuffer
                _renderFBO.Enable();
                _renderBufferEnabled = true;
            }
        }

        public static void DisableRenderBuffer()
        {
            if (_renderBufferEnabled)
            {
                // Disable Framebuffer
                _renderFBO.Disable(ref _screenFBO);
                _renderBufferEnabled = false;
            }
        }

        public static void ShadowMapDepthPass(bool enable = true)
        {
            _shadowMapDepthPass = enable;
        }
        
        public static void Process()
        {
            // Render shadows
            _shadowsRenderer.Process();

            // Enable shadow map
            EnableRenderBuffer();

            // Render the scene.
            RenderScene();

            // Disable shadow map
            DisableRenderBuffer();

            // Render the screen (output of the frame buffer)
            RenderScreen();
        }

        internal static void BindShadowMapTexture(ShaderProgram program)
        {
            _shadowsRenderer.BindTexture(ref program);
        }

        internal static void RenderScene()
        {
            Game.Game.Instance.Render();
        }
    }
}