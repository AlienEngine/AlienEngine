﻿using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.UI;
using System;
using AlienEngine.Core.Game;
using AlienEngine.Shaders;
using AlienEngine.Imaging;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine
{
    public abstract class UIComponent : Component
    {
        /// <summary>
        /// The UI element's rectangle according to screen units
        /// and <see cref="Camera.Viewport"/>.
        /// </summary>
        protected Rectangled Rectangled
        {
            get
            {
                Point2f position = CorrectedPosition;

                switch (Origin)
                {
                    case Origin.TopLeft:
                        position.Y -= Size.Height + Camera.Viewport.Location.Y;
                        break;
                    case Origin.Top:
                        position.X -= (Size.Width / 2f) + Camera.Viewport.Location.X;
                        position.Y -= Size.Height + Camera.Viewport.Location.Y;
                        break;
                    case Origin.TopRight:
                        position.X -= Size.Width + Camera.Viewport.Location.X;
                        position.Y -= Size.Height + Camera.Viewport.Location.Y;
                        break;
                    case Origin.MiddleLeft:
                        position.Y -= (Size.Height / 2f) + Camera.Viewport.Location.Y;
                        break;
                    case Origin.Center:
                        position.X -= (Size.Width / 2f) + Camera.Viewport.Location.X;
                        position.Y -= (Size.Height / 2f) + Camera.Viewport.Location.Y;
                        break;
                    case Origin.MiddleRight:
                        position.X -= Size.Width + Camera.Viewport.Location.X;
                        position.Y -= (Size.Height / 2f) + Camera.Viewport.Location.Y;
                        break;
                    case Origin.Bottom:
                        position.X -= (Size.Width / 2f) + Camera.Viewport.Location.X;
                        break;
                    case Origin.BottomRight:
                        position.X -= Size.Width + Camera.Viewport.Location.X;
                        break;
                }

                return Rectangled.FromLTRB(position.X, Camera.Viewport.Height - position.Y - Size.Height,
                    position.X + Size.Width, Camera.Viewport.Height - position.Y);
            }
        }

        /// <summary>
        /// Defines if the button's state is hover.
        /// </summary>
        private bool _isHover;

        private Mesh _quad;

        protected Point2f CorrectedPosition;

        protected Point2f NormalizedPosition;

        protected Camera Camera;

        public Point2f Position;

        public Sizef Size;

        public Vector2f Scale;

        public Color4 ForegroundColor = Color4.Transparent;

        public Color4 BackgroundColor = Color4.Transparent;

        /// <summary>
        /// The background <see cref="Color4"/> when the mouse is over.
        /// </summary>
        public Color4 HoverColor = Color4.Transparent;

        public Texture BackgroundTexture;

        /// <summary>
        /// The button's background <see cref="Texture"/> when the mouse is over.
        /// </summary>
        public Texture HoverTexture;

        public Anchor Anchor;

        public Origin Origin;

        public Rectanglef Rectangle => new Rectanglef(Position, Size);

        public bool IsHover => _isHover;

        public event Action Hover;

        private ColoredUIShaderProgram _coloredUIShader;
        private TexturedUIShaderProgram _texturedUIShader;

        protected Matrix4f ProjectionMatrix;

        protected UIComponent()
        {
            _coloredUIShader = new ColoredUIShaderProgram();
            _texturedUIShader = new TexturedUIShaderProgram();

            ResourcesManager.AddDisposableResource(this);
        }

        public override void Start()
        {
            Init();

            Input.AddMouseMoveEvent((sender, args) =>
            {
                _isHover = Enabled && !Input.MouseIsGrabbed && Rectangled.Contains(args.Location);
            });

            RendererManager.OnViewportChange += (sender, args) => _setUIPosition();

            base.Start();
        }

        public override void Update()
        {
            if (_isHover)
                Hover?.Invoke();
        }

        protected void RenderColoredQuad()
        {
            Color4 color = _isHover ? HoverColor : BackgroundColor;

            if (color == Color4.Transparent) return;

            RenderColoredQuad(color);
        }

        protected void RenderColoredQuad(Color4 color)
        {
            if (_quad == null) _quad = MeshFactory.CreateQuad(Point2f.Zero, Size, Point2f.Zero, Sizef.One);

            RendererManager.BackupState(RendererBackupMode.Blending);
            RendererManager.Blending();

            _coloredUIShader.Bind();
            _coloredUIShader.SetPosition(new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            _coloredUIShader.SetColor(color);
            _coloredUIShader.SetProjectionMatrix(ProjectionMatrix);
            _quad.Render();
            _coloredUIShader.Unbind();

            RendererManager.RestoreState(RendererBackupMode.Blending);
        }

        protected void RenderTexturedQuad()
        {
            Texture texture = IsHover ? HoverTexture : BackgroundTexture;

            if (texture == null) return;

            RenderTexturedQuad(texture);
        }

        protected void RenderTexturedQuad(Texture texture)
        {
            if (_quad == null) _quad = MeshFactory.CreateQuad(Point2f.Zero, Size, Point2f.Zero, Sizef.One);

            RendererManager.BackupState(RendererBackupMode.Blending);
            RendererManager.Blending();
            texture.Bind(GL.DIFFUSE_TEXTURE_UNIT_INDEX);

            _texturedUIShader.Bind();
            _texturedUIShader.SetPosition(new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            _texturedUIShader.SetTexture(GL.DIFFUSE_TEXTURE_UNIT_INDEX);
            _texturedUIShader.SetProjectionMatrix(ProjectionMatrix);
            _quad.Render();
            _texturedUIShader.Unbind();

            RendererManager.RestoreState(RendererBackupMode.Blending);
        }

        protected virtual void Init()
        {
            _setUIPosition();
        }

        protected void UpdateProjectionMatrix(Matrix4f pMatrix)
        {
            ProjectionMatrix = pMatrix;
        }

        private void _setUIPosition()
        {
            CorrectedPosition = Position;

            Camera = SceneManager.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            Matrix4f projection = Matrix4f.CreateOrthographicOffCenter(0.0f, Camera.Viewport.Width, 0.0f,
                Camera.Viewport.Height, 0.0f, 1.0f);

            switch (Anchor)
            {
                case Anchor.TopLeft:
                    CorrectedPosition.Y += Camera.Viewport.Height;
                    break;

                case Anchor.Top:
                    CorrectedPosition.X += Camera.Viewport.Width / 2.0f;
                    CorrectedPosition.Y += Camera.Viewport.Height;
                    break;

                case Anchor.TopRight:
                    CorrectedPosition.X += Camera.Viewport.Width;
                    CorrectedPosition.Y += Camera.Viewport.Height;
                    break;

                case Anchor.MiddleLeft:
                    CorrectedPosition.Y += Camera.Viewport.Height / 2.0f;
                    break;

                case Anchor.Center:
                    CorrectedPosition.X += Camera.Viewport.Width / 2.0f;
                    CorrectedPosition.Y += Camera.Viewport.Height / 2.0f;
                    break;

                case Anchor.MiddleRight:
                    CorrectedPosition.X += Camera.Viewport.Width;
                    CorrectedPosition.Y += Camera.Viewport.Height / 2.0f;
                    break;

                case Anchor.Bottom:
                    CorrectedPosition.X += Camera.Viewport.Width / 2.0f;
                    break;

                case Anchor.BottomRight:
                    CorrectedPosition.X += Camera.Viewport.Width;
                    break;
            }

            switch (Origin)
            {
                case Origin.TopLeft:
                    projection = Matrix4f.CreateTranslation(new Vector3f(0, -Size.Height, 0)) * projection;
                    break;

                case Origin.Top:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, -Size.Height, 0)) *
                                 projection;
                    break;

                case Origin.TopRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, -Size.Height, 0)) * projection;
                    break;

                case Origin.MiddleLeft:
                    projection = Matrix4f.CreateTranslation(new Vector3f(0, -Size.Height / 2f, 0)) * projection;
                    break;

                case Origin.Center:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, -Size.Height / 2f, 0)) *
                                 projection;
                    break;

                case Origin.MiddleRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, -Size.Height / 2f, 0)) *
                                 projection;
                    break;

                case Origin.Bottom:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, 0, 0)) * projection;
                    break;

                case Origin.BottomRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, 0, 0)) * projection;
                    break;
            }

            NormalizedPosition = CorrectedPosition;

            switch (Anchor)
            {
                case Anchor.TopLeft:
                    NormalizedPosition.Y -= Size.Height;
                    break;

                case Anchor.Top:
                    NormalizedPosition.X -= Size.Width / 2.0f;
                    NormalizedPosition.Y -= Size.Height;
                    break;

                case Anchor.TopRight:
                    NormalizedPosition.X -= Size.Width;
                    NormalizedPosition.Y -= Size.Height;
                    break;

                case Anchor.MiddleLeft:
                    NormalizedPosition.Y -= Size.Height / 2.0f;
                    break;

                case Anchor.Center:
                    NormalizedPosition.X -= Size.Width / 2.0f;
                    NormalizedPosition.Y -= Size.Height / 2.0f;
                    break;

                case Anchor.MiddleRight:
                    NormalizedPosition.X -= Size.Width;
                    NormalizedPosition.Y -= Size.Height / 2.0f;
                    break;

                case Anchor.Bottom:
                    NormalizedPosition.X -= Size.Width / 2.0f;
                    break;

                case Anchor.BottomRight:
                    NormalizedPosition.X -= Size.Width;
                    break;
            }

            UpdateProjectionMatrix(projection);
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected new virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                _coloredUIShader?.Dispose();
                _coloredUIShader = null;
                
                _texturedUIShader?.Dispose();
                _texturedUIShader = null;
                
                BackgroundTexture?.Dispose();
                BackgroundTexture = null;
            }

            _disposedValue = true;
        }

        #endregion
    }
}