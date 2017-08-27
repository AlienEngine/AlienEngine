﻿using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Shaders;
using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Rendering
{
    public enum RendererBackupMode
    {
        DepthTest,
        Blending,
        FaceCulling
    }

    public static class Renderer
    {
        private static List<IRenderable> _renderables;
        private static bool _depthTestEnabled;
        private static bool _blendingEnabled;
        private static bool _multisampleEnabled;
        private static uint screenVAO;
        private static uint screenVBO;
        private static ShaderProgram screenShaderProgram;

        // Depth test
        private static DepthFunction _depthTestFunction;

        // Face culling
        private static bool _faceCullingEnabled;
        private static CullFaceMode _faceCullingMode;
        private static FrontFaceDirection _faceCullingFrontFaceDirection;

        // Backup
        private static Tuple<bool, CullFaceMode, FrontFaceDirection> _faceCullingBackup;
        private static Tuple<bool, DepthFunction> _depthTestBackup;

        public static bool IsFaceCullingEnabled
        {
            get { return _faceCullingEnabled; }
        }

        static Renderer()
        {
            // Renderables
            _renderables = new List<IRenderable>();

            // States
            _depthTestEnabled = false;
            _blendingEnabled = false;
            _faceCullingEnabled = false;

            // Backups
            _faceCullingBackup = null;
            _depthTestBackup = null;

            // Screen
            screenVAO = 0;
            screenVBO = 0;
        }

        public static void BackupState(RendererBackupMode mode)
        {
            switch (mode)
            {
                case RendererBackupMode.DepthTest:
                    _depthTestBackup = new Tuple<bool, DepthFunction>(_depthTestEnabled, _depthTestFunction);
                    break;
                case RendererBackupMode.Blending:
                    break;
                case RendererBackupMode.FaceCulling:
                    _faceCullingBackup = new Tuple<bool, CullFaceMode, FrontFaceDirection>(_faceCullingEnabled, _faceCullingMode, _faceCullingFrontFaceDirection);
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
                        DepthTest(_depthTestBackup.Item1, _depthTestBackup.Item2);
                        _depthTestBackup = null;
                    }
                    break;
                case RendererBackupMode.Blending:
                    break;
                case RendererBackupMode.FaceCulling:
                    if (_faceCullingBackup != null)
                    {
                        FaceCulling(_faceCullingBackup.Item1, _faceCullingBackup.Item2, _faceCullingBackup.Item3);
                        _faceCullingBackup = null;
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

        public static void Viewport(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }

        public static void Viewport(Rectangle viewport)
        {
            Viewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
        }

        public static void ClearScreen(ClearBufferMask mask = ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit)
        {
            GL.Clear(mask);
        }

        public static void DepthTest(bool enable = true, DepthFunction depthFunction = DepthFunction.Less)
        {
            if (enable)
            {
                if (!_depthTestEnabled) GL.Enable(EnableCap.DepthTest);
                GL.DepthFunc(depthFunction);
            }
            else if (_depthTestEnabled) GL.Disable(EnableCap.DepthTest);

            _depthTestEnabled = enable;
        }

        public static void Blending(bool enable = true, BlendingFactorSrc srcFactor = BlendingFactorSrc.SrcAlpha, BlendingFactorDest dstFactor = BlendingFactorDest.OneMinusSrcAlpha)
        {
            if (enable)
            {
                if (!_blendingEnabled) GL.Enable(EnableCap.Blend);
                GL.BlendFunc(srcFactor, dstFactor);
            }
            else if (_blendingEnabled) GL.Disable(EnableCap.Blend);

            _blendingEnabled = enable;
        }

        public static void FaceCulling(bool enable = true, CullFaceMode cullFaceMode = CullFaceMode.Back, FrontFaceDirection frontFace = FrontFaceDirection.Ccw)
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

        public static void RenderScreen(FBO fbo)
        {
            // Create the screen if it's not exist
            if (screenVAO == 0)
            {
                float[] indArray = new float[] {
                    -1.0f,  1.0f,  0.0f, 1.0f,
                     1.0f,  1.0f,  1.0f, 1.0f,
                     1.0f, -1.0f,  1.0f, 0.0f,

                     1.0f, -1.0f,  1.0f, 0.0f,
                    -1.0f, -1.0f,  0.0f, 0.0f,
                    -1.0f,  1.0f,  0.0f, 1.0f
                };

                screenVAO = GL.GenVertexArray();
                screenVBO = GL.GenBuffer();

                GL.BindVertexArray(screenVAO);
                GL.BindBuffer(BufferTarget.ArrayBuffer, screenVBO);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * indArray.Length, indArray, BufferUsageHint.StaticDraw);
                GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);
                GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 2 * sizeof(float));

                screenShaderProgram = new RenderTextureShaderProgram()
                {
                    PostEffectMode = PostEffectMode.None,
                    Width = fbo.Size.Width,
                    Height = fbo.Size.Height
                };
            }

            // Bind the shader
            screenShaderProgram.Bind();

            // Bind the vertex array
            GL.BindVertexArray(screenVAO);

            // Depth test settings
            BackupState(RendererBackupMode.DepthTest);
            BackupState(RendererBackupMode.FaceCulling);
            DepthTest(false);
            FaceCulling(false);

            // Bind the texture
            GL.ActiveTexture(GL.COLOR_TEXTURE_UNIT_INDEX);
            GL.BindTexture(TextureTarget.Texture2D, fbo.GetTextureID(FramebufferAttachment.ColorAttachment0));

            // Draw the screen
            GL.DrawArrays(BeginMode.Triangles, 0, 6);

            // Make sure this VAO don't change from the outside
            GL.BindVertexArray(0);

            // Restore states
            RestoreState(RendererBackupMode.DepthTest);
            RestoreState(RendererBackupMode.FaceCulling);
        }

        public static void RenderAll()
        {
            // Render all renderable objects
            foreach (IRenderable _object in _renderables)
                _object.Render();

            // Render the skybox
            BackupState(RendererBackupMode.DepthTest);
            DepthTest(true, DepthFunction.Lequal);

            Camera _camera = Game.Game.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            switch (_camera.ClearScreenType)
            {
                case Camera.ClearScreenTypes.Color:
                    GL.ClearColor(_camera.ClearColor);
                    break;
                case Camera.ClearScreenTypes.Cubemap:
                    if (_camera.Cubemap != null)
                        _camera.Cubemap.Render();
                    break;
            }

            RestoreState(RendererBackupMode.DepthTest);
        }
    }
}