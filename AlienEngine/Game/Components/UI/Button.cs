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
        /// The button's rectangle according to screen units.
        /// </summary>
        private Rectangled _rectangled => Rectangled.FromLTRB(CorrectedPosition.X, CorrectedPosition.Y - Size.Height, CorrectedPosition.X + Size.Width, CorrectedPosition.Y);

        /// <summary>
        /// Defines if the button's state is hover.
        /// </summary>
        private bool _isHover;

        /// <summary>
        /// Define if the button's state is pressed.
        /// </summary>
        private bool _isPressed;

        /// <summary>
        /// The text label of the button.
        /// </summary>
        private Label2D _label;

        #endregion

        #region Public Fields

        /// <summary>
        /// The button's background <see cref="Color4"/> when the mouse is over.
        /// </summary>
        public Color4 HoverColor;

        /// <summary>
        /// The button's background <see cref="Color4"/> when it is pressed.
        /// </summary>
        public Color4 PressColor;

        /// <summary>
        /// The button's background <see cref="Texture"/> when the mouse is over.
        /// </summary>
        public Texture HoverTexture;

        /// <summary>
        /// The button's background <see cref="Texture"/> when it is pressed.
        /// </summary>
        public Texture PressTexture;

        public string Text;

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
            _label = new Label2D();

            OnAttach += () => gameElement.AttachComponent(_label);

            ResourcesManager.AddDisposableResource(this);
        }

        public override void Start()
        {
            InitUI();

            _label.Anchor = UI.Anchor.BottomLeft;
            _label.BackgroundColor = Color4.Transparent;
            _label.CharacterSpacing = CharacterSpacing;
            _label.FontPath = FontPath;
            _label.FontSize = FontSize;
            _label.FontStyle = FontStyle;
            _label.FontType = FontType;
            _label.ForegroundColor = ForegroundColor;
            _label.LineSpacing = LineSpacing;
            _label.Origin = UI.Origin.BottomLeft;
            _label.Position = CorrectedPosition;
            _label.Scale = Scale;
            _label.Size = Size;
            _label.Text = Text;
            _label.TextAlignement = TextAlignement;
            _label.TextWrapMode = TextWrapMode;

            Input.AddMouseMoveEvent((sender, args) =>
            {
                _isHover = Enabled && !Input.MouseIsGrabbed && _rectangled.Contains(args.Location);
            });
        }

        public override void Update()
        {
            _isPressed = _isHover && Input.Holding(MouseButton.Left);

            if (_isHover)
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
        }

        new public void RenderColoredQuad()
        {
            Color4 color = _isPressed ? PressColor : (_isHover ? HoverColor : BackgroundColor);

            if (color == Color4.Transparent) return;

            RenderColoredQuad(color);
        }

        new public void RenderTexturedQuad()
        {
            Texture texture = _isPressed ? PressTexture : (_isHover ? HoverTexture : BackgroundTexture);

            if (texture == null) return;

            RenderTexturedQuad(texture);
        }

        public void Render()
        {
            if (BackgroundTexture != null)
                RenderTexturedQuad();
            else
                RenderColoredQuad();
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