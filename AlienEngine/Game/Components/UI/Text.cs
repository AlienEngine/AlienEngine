﻿using System;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.UI;

namespace AlienEngine
{
    public class Text : UIComponent, IPostRenderable
    {
        public string Value;

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

        internal IFont FontEngine => _fontEngine;

        public Text()
        {
            Position = Point2f.Zero;
            Scale = Vector2f.One;
            ForegroundColor = Color4.Black;
            BackgroundColor = Color4.Transparent;
            Value = string.Empty;
            FontPath = string.Empty;
            FontSize = 12;
            FontStyle = FontStyle.Regular;
            FontType = FontType.FreeType;
        }

        protected override void Init()
        {
            base.Init();

            BuildConfiguration();

            InitFontEngine();

            SetProjectionMatrix();
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
            if (BackgroundTexture != null)
                RenderTexturedQuad();
            else
                RenderColoredQuad();

            _fontEngine.RenderText(Value);
        }

        internal Sizef GetTextSize()
        {
            return _fontEngine.CalculateSize(Value);
        }

        internal Sizef GetTextSize(string value)
        {
            return _fontEngine.CalculateSize(value);
        }

        private bool _disposedValue;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposedValue) return;

            if (disposing)
            {
                _fontEngine?.Dispose();
                _fontEngine = null;
            }

            _disposedValue = true;
        }
    }
}