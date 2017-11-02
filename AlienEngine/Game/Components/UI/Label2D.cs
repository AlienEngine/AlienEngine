using System;
using AlienEngine.Core.Game;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.UI;

namespace AlienEngine
{
    public class Label2D : Component, IPostRenderable
    {
        public Point2f Position;

        public Vector2f Scale;

        public Color4 Color;

        public string Text;

        private IFont _fontEngine;
        private FontType _fontType;
        private FontRendererConfiguration _fontRendererConfiguration;

        public string Fontpath;

        public float FontSize;

        public FontStyle FontStyle;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        public FontType FontType
        {
            get { return _fontType; }
            set { _fontType = value; }
        }

        public Sizef Size;

        public Anchor Anchor;

        public TextOrigin TextOrigin;
        
        public float CharacterSpacing;

        public float LineSpacing;

        private Camera _camera;
        
        public Label2D()
        {
            Position = Point2f.Zero;
            Scale = Vector2f.One;
            Color = Color4.Black;
            Text = string.Empty;
            Fontpath = string.Empty;
            FontSize = 12;
            FontStyle = FontStyle.Regular;
            FontType = FontType.FreeType;
        }

        public override void Start()
        {
            _camera = Game.CurrentScene.PrimaryCamera.GetComponent<Camera>();

            InitFontEngine(FontType);

            InitConfiguration();

            SetProjectionMatrix();

            Renderer.OnViewportChange += (sender, args) =>
            {
                SetProjectionMatrix();
            };

            Renderer.RegisterPostRenderable(this);
        }

        private void InitConfiguration()
        {
            _fontRendererConfiguration = new FontRendererConfiguration
            {
                Color = Color,
                Position = Position,
                Scale = Scale,
                TextAlignement = TextAlignement,
                TextWrapMode = TextWrapMode,
                TextOrigin = TextOrigin,
                Container = Size,
                CharacterSpacing = CharacterSpacing,
                LineSpacing = LineSpacing
            };
        }

        private void SetProjectionMatrix()
        {
            switch (Anchor)
            {
                case Anchor.TopLeft:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(0.0f,
                        _camera.Viewport.Width, -_camera.Viewport.Height, 0.0f, 0.0f, 1.0f);
                    break;

                case Anchor.Top:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(-_camera.Viewport.Width / 2.0f,
                        _camera.Viewport.Width / 2.0f, -_camera.Viewport.Height, 0.0f, 0.0f,
                        1.0f);
                    break;

                case Anchor.TopRight:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(_camera.Viewport.Width,
                        _camera.Viewport.Width * 2.0f, -_camera.Viewport.Height, 0.0f, 0.0f,
                        1.0f);
                    break;

                case Anchor.MiddleLeft:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(0.0f, _camera.Viewport.Width,
                        -_camera.Viewport.Height / 2.0f, _camera.Viewport.Height / 2.0f, 0.0f, 1.0f);
                    break;

                case Anchor.Middle:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographic(_camera.Viewport.Width,
                        _camera.Viewport.Height, 0.0f, 1.0f);
                    break;

                case Anchor.MiddleRight:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(_camera.Viewport.Width,
                        _camera.Viewport.Width * 2.0f,
                        -_camera.Viewport.Height / 2.0f, _camera.Viewport.Height / 2.0f, 0.0f, 1.0f);
                    break;

                case Anchor.BottomLeft:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(0.0f, _camera.Viewport.Width,
                        0.0f, _camera.Viewport.Height, 0.0f, 1.0f);
                    break;

                case Anchor.Bottom:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(-_camera.Viewport.Width / 2.0f,
                        _camera.Viewport.Width / 2.0f, 0.0f, _camera.Viewport.Height, 0.0f, 1.0f);
                    break;

                case Anchor.BottomRight:
                    _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(_camera.Viewport.Width,
                        _camera.Viewport.Width * 2.0f, 0.0f, _camera.Viewport.Height, 0.0f, 1.0f);
                    break;
            }
        }

        private void InitFontEngine(FontType value)
        {
            switch (value)
            {
                case FontType.FreeType:
                    _fontEngine = new FreeTypeFont(Fontpath, FontSize, FontStyle);
                    break;

                case FontType.BMFont:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Render()
        {
            _fontEngine.RenderText(Text, _fontRendererConfiguration);
        }
    }
}