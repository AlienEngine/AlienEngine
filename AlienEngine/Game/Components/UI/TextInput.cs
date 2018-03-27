using System;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.Imaging;
using AlienEngine.UI;
using AlienEngine.Core.Shaders;
using AlienEngine.Shaders;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Game;
using AlienEngine.Core.Resources;

namespace AlienEngine
{
    public class TextInput : UIComponent, IRenderable, IDisposable
    {
        private static Cursor _Ibeam;

        private static Cursor _default;
        
        private Text _content;

        private string _value = string.Empty;

        private bool _isTyping;

        private double _caretBlinkTimer;

        private Point2d _cursorPosition;

        private Mesh _caret;

        private static ColoredUIShaderProgram _caretShaderProgram;
        
        public string Value
        {
            get { return _value; }
            set
            {
                TextChange?.Invoke(this, new TextChangeEventArgs(_value, value));
                _value = value;
                _content.Value = value;
            }
        }

        public bool IsFocused => _isTyping;

        public Color4 FocusColor;

        public Texture FocusTexture;

        public float CharacterSpacing;

        public string FontPath;

        public float FontSize;

        public FontStyle FontStyle;

        public FontType FontType;

        public float LineSpacing;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        public double CaretBlinkInterval;

        public float CaretWidth;

        #region Delegates

        public delegate void TextChangeEvent(object sender, TextChangeEventArgs args);

        #endregion

        #region Events

        public event TextChangeEvent TextChange;

        #endregion

        static TextInput()
        {
            _Ibeam = new Cursor(Cursor.CursorType.Beam);
            _caretShaderProgram = new ColoredUIShaderProgram();
        }
        
        public TextInput()
        {
            _content = new Text();
            
            ResourcesManager.AddDisposableResource(this);
        }

        public override void Start()
        {
            base.Start();

            _content.Anchor = Anchor;
            _content.BackgroundColor = Color4.Transparent;
            _content.CharacterSpacing = CharacterSpacing;
            _content.FontPath = FontPath;
            _content.FontSize = FontSize;
            _content.FontStyle = FontStyle;
            _content.FontType = FontType;
            _content.ForegroundColor = ForegroundColor;
            _content.LineSpacing = LineSpacing;
            _content.Origin = Origin;
            _content.Position = Position;
            _content.Scale = Scale;
            _content.Size = Size;
            _content.Value = Value;
            _content.TextAlignement = TextAlignement;
            _content.TextWrapMode = TextWrapMode;
            
            _content.Start();

            Input.AddMouseButtonDownEvent(_onMouseDown);
            Input.AddTextInputEvent(_onTextInputEvent);
            Input.AddKeyDownEvent(_onKeyDownEvent);

            _caret = MeshFactory.CreateQuad(new Point2f(), new Sizef(CaretWidth, FontSize), Point2f.Zero, Sizef.One);

            _updateCaretPosition();
        }

        private void _updateCaretPosition()
        {
            var textSize = _content.GetTextSize();
            _cursorPosition = new Point2d(CorrectedPosition.X + MathHelper.Min(textSize.Width, Size.Width), CorrectedPosition.Y + ((Size.Height - textSize.Height) / 2));
            _caretBlinkTimer = 0;
        }

        private void _onMouseDown(object sender, MouseButtonEventArgs args)
        {
            _isTyping = IsHover;
        }

        private void _onTextInputEvent(object sender, TextInputEventArgs args)
        {
            if (_isTyping)
            {
                Value += args.KeyChar;
                _updateCaretPosition();
            }
        }

        private void _onKeyDownEvent(object sender, KeyboardKeyEventArgs args)
        {
            if (_isTyping && (args.KeyState == InputState.Pressed || args.KeyState == InputState.Repeated))
            {
                switch (args.Key)
                {
                    case KeyCode.Backspace:
                        if (Value.Length > 1)
                            Value = Value.Remove(Value.Length - 2, 1);
                        else
                            Value = "";
                        _updateCaretPosition();
                        break;
                }
            }
        }

        public override void Update()
        {
            base.Update();

            _caretBlinkTimer += Time.DeltaTime;

            if (IsHover && _default == null)
            {
                _default = Game.Instance.Window.Cursor;
                Game.Instance.Window.SetCursor(_Ibeam);
            }
            else if (!IsHover && _default != null)
            {
                Game.Instance.Window.SetCursor(_default);
                _default = null;
            }

            _content.Update();
        }

        public void Render()
        {
            if (_isTyping)
            {
                if (_caretBlinkTimer < CaretBlinkInterval)
                {
                    // var caretPosition = CorrectedPosition + _cursorPosition;

                    RendererManager.BackupState(RendererBackupMode.Blending);
                    RendererManager.Blending();

                    _caretShaderProgram.Bind();
                    _caretShaderProgram.SetPosition(new Vector3f((float)_cursorPosition.X, (float)_cursorPosition.Y, 0));
                    _caretShaderProgram.SetColor(ForegroundColor);
                    _caretShaderProgram.SetProjectionMatrix(ProjectionMatrix);

                    _caret.Render();

                    RendererManager.RestoreState(RendererBackupMode.Blending);
                }
                else if (_caretBlinkTimer > CaretBlinkInterval * 2.0)
                    _caretBlinkTimer -= CaretBlinkInterval * 2.0;
            }

            if (BackgroundTexture != null)
                RenderTexturedQuad();
            else
                RenderColoredQuad();

            _content.Render();
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (HoverTexture != null)
                HoverTexture.Dispose();

            if (FocusTexture != null)
                FocusTexture.Dispose();
        }

    }
}