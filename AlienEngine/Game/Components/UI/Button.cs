using System;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Inputs;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.Imaging;
using AlienEngine.Core.Resources;

namespace AlienEngine
{
    public class Button : UIComponent, IPostRenderable
    {
        #region Private Fields

        /// <summary>
        /// Define if the button's state is pressed.
        /// </summary>
        private bool _isPressed;

        /// <summary>
        /// The text label of the button.
        /// </summary>
        private Text _label;

        /// <summary>
        /// The text of the button.
        /// </summary>
        private string _text;

        #endregion

        #region Public Fields

        /// <summary>
        /// The button's background <see cref="Color4"/> when it is pressed.
        /// </summary>
        public Color4 PressColor;

        /// <summary>
        /// The button's background <see cref="Texture"/> when it is pressed.
        /// </summary>
        public Texture PressTexture;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                _label.Value = _text;
            }
        }

        public float CharacterSpacing;

        public string FontPath;

        public float FontSize;

        public FontStyle FontStyle;

        public FontType FontType;

        public float LineSpacing;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        #endregion

        #region Events

        public event Action<MouseButton> Click;

        public event Action LeftClick;

        public event Action RightClick;

        public event Action MiddleClick;

        #endregion

        public Button()
        {
            _label = new Text();

            ResourcesManager.AddDisposableResource(this);
        }

        public override void Start()
        {
            base.Start();

            _label.Anchor = Anchor;
            _label.BackgroundColor = Color4.Transparent;
            _label.CharacterSpacing = CharacterSpacing;
            _label.FontPath = FontPath;
            _label.FontSize = FontSize;
            _label.FontStyle = FontStyle;
            _label.FontType = FontType;
            _label.ForegroundColor = ForegroundColor;
            _label.LineSpacing = LineSpacing;
            _label.Origin = Origin;
            _label.Position = Position;
            _label.Scale = Scale;
            _label.Size = Size;
            _label.Value = Text;
            _label.TextAlignement = TextAlignement;
            _label.TextWrapMode = TextWrapMode;

            _label.Start();
        }

        public override void Update()
        {
            base.Update();

            _isPressed = IsHover && Input.Holding(MouseButton.Left);

            if (IsHover)
            {
                if (Input.Released(MouseButton.Left))
                {
                    Click?.Invoke(MouseButton.Left);
                    LeftClick?.Invoke();
                }

                if (Input.Released(MouseButton.Right))
                {
                    Click?.Invoke(MouseButton.Right);
                    RightClick?.Invoke();
                }

                if (Input.Released(MouseButton.Middle))
                {
                    Click?.Invoke(MouseButton.Middle);
                    MiddleClick?.Invoke();
                }
            }

            _label.Update();
        }

        new public void RenderColoredQuad()
        {
            Color4 color = _isPressed ? PressColor : (IsHover ? HoverColor : BackgroundColor);

            if (color == Color4.Transparent) return;

            RenderColoredQuad(color);
        }

        new public void RenderTexturedQuad()
        {
            Texture texture = _isPressed ? PressTexture : (IsHover ? HoverTexture : BackgroundTexture);

            if (texture == null) return;

            RenderTexturedQuad(texture);
        }

        public void Render()
        {
            if (BackgroundTexture != null)
                RenderTexturedQuad();
            else
                RenderColoredQuad();

            _label.Render();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (HoverTexture != null)
                HoverTexture.Dispose();

            if (PressTexture != null)
                PressTexture.Dispose();
        }
    }
}