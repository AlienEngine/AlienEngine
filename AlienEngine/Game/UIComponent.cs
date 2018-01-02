using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.UI;
using System;
using AlienEngine.Shaders;
using AlienEngine.Imaging;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine
{
    public abstract class UIComponent : Component, IDisposable
    {

        /// <summary>
        /// The UI element's rectangle according to screen units.
        /// </summary>
        protected Rectangled Rectangled
        {
            get
            {
                Point2f position = CorrectedPosition;

                switch (Origin)
                {
                    case Origin.TopLeft:
                        position.Y -= Size.Height;
                        break;
                    case Origin.Top:
                        position.X -= Size.Width / 2f;
                        position.Y -= Size.Height;
                        break;
                    case Origin.TopRight:
                        position.X -= Size.Width;
                        position.Y -= Size.Height;
                        break;
                    case Origin.MiddleLeft:
                        position.Y -= Size.Height / 2f;
                        break;
                    case Origin.Middle:
                        position.X -= Size.Width / 2f;
                        position.Y -= Size.Height / 2f;
                        break;
                    case Origin.MiddleRight:
                        position.X -= Size.Width;
                        position.Y -= Size.Height / 2f;
                        break;
                    case Origin.Bottom:
                        position.X -= Size.Width / 2f;
                        break;
                    case Origin.BottomRight:
                        position.X -= Size.Width;
                        break;
                }

                return Rectangled.FromLTRB(position.X, Camera.Viewport.Height - position.Y - Size.Height, position.X + Size.Width, Camera.Viewport.Height - position.Y);
            }
        }

        private Mesh _quad;

        protected Point2f CorrectedPosition;

        protected Camera Camera;

        public Point2f Position;

        public Sizef Size;

        public Vector2f Scale;

        public Color4 ForegroundColor;

        public Color4 BackgroundColor;

        public Texture BackgroundTexture;

        public Anchor Anchor;

        public Origin Origin;

        public Rectanglef Rectangle => new Rectanglef(Position, Size);

        private ColoredUIShaderProgram _coloredUIShader;
        private TexturedUIShaderProgram _texturedUIShader;

        private Matrix4f _projectionMatrix;

        protected UIComponent()
        {
            _coloredUIShader = new ColoredUIShaderProgram();
            _texturedUIShader = new TexturedUIShaderProgram();

            ResourcesManager.AddDisposableResource(this);
        }

        public void RenderColoredQuad()
        {
            if (BackgroundColor == Color4.Transparent) return;

            RenderColoredQuad(BackgroundColor);
        }

        public void RenderColoredQuad(Color4 color)
        {
            if (_quad == null) _quad = MeshFactory.CreateQuad(Point2f.Zero, Size, Point2f.Zero, Sizef.One);

            RendererManager.BackupState(RendererBackupMode.Blending);
            RendererManager.Blending();

            _coloredUIShader.Bind();
            _coloredUIShader.SetPosition(new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            _coloredUIShader.SetColor(color);
            _coloredUIShader.SetProjectionMatrix(_projectionMatrix);

            _quad.Render();

            RendererManager.RestoreState(RendererBackupMode.Blending);
        }

        public void RenderTexturedQuad()
        {
            if (BackgroundTexture == null) return;

            RenderTexturedQuad(BackgroundTexture);
        }

        public void RenderTexturedQuad(Texture texture)
        {
            if (_quad == null) _quad = MeshFactory.CreateQuad(Point2f.Zero, Size, Point2f.Zero, Sizef.One);

            RendererManager.BackupState(RendererBackupMode.Blending);
            RendererManager.Blending();
            texture.Bind(GL.DIFFUSE_TEXTURE_UNIT_INDEX);

            _texturedUIShader.Bind();
            _texturedUIShader.SetPosition(new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            _texturedUIShader.SetTexture(GL.DIFFUSE_TEXTURE_UNIT_INDEX);
            _texturedUIShader.SetProjectionMatrix(_projectionMatrix);

            _quad.Render();

            RendererManager.RestoreState(RendererBackupMode.Blending);
        }

        protected void InitUI()
        {
            CorrectedPosition = Position;

            Camera = Core.Game.Game.Instance.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            Matrix4f projection = Matrix4f.CreateOrthographicOffCenter(0.0f, Camera.Viewport.Width, 0.0f, Camera.Viewport.Height, 0.0f, 1.0f);

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

                case Anchor.Middle:
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
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, -Size.Height, 0)) * projection;
                    break;

                case Origin.TopRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, -Size.Height, 0)) * projection;
                    break;

                case Origin.MiddleLeft:
                    projection = Matrix4f.CreateTranslation(new Vector3f(0, -Size.Height / 2f, 0)) * projection;
                    break;

                case Origin.Middle:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, -Size.Height / 2f, 0)) * projection;
                    break;

                case Origin.MiddleRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, -Size.Height / 2f, 0)) * projection;
                    break;

                case Origin.Bottom:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width / 2f, 0, 0)) * projection;
                    break;

                case Origin.BottomRight:
                    projection = Matrix4f.CreateTranslation(new Vector3f(-Size.Width, 0, 0)) * projection;
                    break;
            }

            UpdateProjectionMatrix(projection);
        }

        protected void UpdateProjectionMatrix(Matrix4f pMatrix)
        {
            _projectionMatrix = pMatrix;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_coloredUIShader != null)
                        _coloredUIShader.Dispose();

                    if (_texturedUIShader != null)
                        _texturedUIShader.Dispose();

                    if (BackgroundTexture != null)
                        BackgroundTexture.Dispose();
                }

                _disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~UIComponent() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}