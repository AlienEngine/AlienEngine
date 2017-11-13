using System;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.UI;

namespace AlienEngine
{
    public class Label2D : UIComponent, IPostRenderable
    {
        public string Text;

        private IFont _fontEngine;
        private FontRendererConfiguration _fontRendererConfiguration;

        public string FontPath;

        public float FontSize;

        public FontStyle FontStyle;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        public FontType FontType;
        
        public float CharacterSpacing;

        public float LineSpacing;

        public Label2D() : base()
        {
            Position = Point2f.Zero;
            Scale = Vector2f.One;
            ForegroundColor = Color4.Black;
            BackgroundColor = Color4.Transparent;
            Text = string.Empty;
            FontPath = string.Empty;
            FontSize = 12;
            FontStyle = FontStyle.Regular;
            FontType = FontType.FreeType;
        }

        public override void Start()
        {
            base.Start();

            BuildConfiguration();

            InitFontEngine();

            SetProjectionMatrix();

            Renderer.OnViewportChange += (sender, args) => SetProjectionMatrix();
        }

        private void BuildConfiguration()
        {
            _fontRendererConfiguration = new FontRendererConfiguration
            {
                Color = ForegroundColor,
                Position = CorrectedPosition,
                Scale = Scale,
                TextAlignement = TextAlignement,
                TextWrapMode = TextWrapMode,
                TextOrigin = Origin,
                Container = Size,
                CharacterSpacing = CharacterSpacing,
                LineSpacing = LineSpacing,
                FontSize = FontSize,
                FontStyle = FontStyle
            };
        }

        private void SetProjectionMatrix()
        {
            _fontEngine.ProjectionMatrix = Matrix4f.CreateOrthographicOffCenter(0.0f, Camera.Viewport.Width,
                0.0f, Camera.Viewport.Height, 0.0f, 1.0f);
        }

        private void InitFontEngine()
        {
            switch (FontType)
            {
                case FontType.FreeType:
                    _fontEngine = new FreeTypeFont(FontPath, _fontRendererConfiguration);
                    break;

                case FontType.Bitmap:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(FontType), FontType, null);
            }
        }

        public void Render()
        {
            RenderColoredQuad();
            _fontEngine.RenderText(Text);
        }
    }
}