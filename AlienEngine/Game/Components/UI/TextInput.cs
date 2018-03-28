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
    // TODO: LTR and RTL
    public class TextInput : UIComponent, IPostRenderable
    {
        private static Cursor _Ibeam;

        private static Cursor _default;

        private Text _content;

        private string _value = string.Empty;

        private bool _isTyping;

        private double _caretBlinkTimer;

        private Point2d _caretPositionInField;

        private Point2d _selectionRangePositionInField;

        private int _caretPositionInText;

        private Range _selectedTextRange;

        private Mesh _caret;

        private Mesh _selection;

        private static ColoredUIShaderProgram _colorShaderProgram;

        public string Value
        {
            get { return _value; }
            set
            {
                TextChange?.Invoke(this, new TextChangeEventArgs(_value, value));

                _value = value;
                _content.Value = value;

                _updateCaretPositionInField();
                _updateTextPosition();
            }
        }

        public int CaretPosition
        {
            get { return _caretPositionInText; }
            set
            {
                _caretPositionInText = value;

                _updateCaretPositionInField();
                _updateTextPosition();
            }
        }

        public Range SelectedTextRange
        {
            get { return _selectedTextRange; }
            set { _selectedTextRange = value; }
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
            _colorShaderProgram = new ColoredUIShaderProgram();
        }

        public TextInput()
        {
            _content = new Text();

            ResourcesManager.AddDisposableResource(this);
        }

        public override void Start()
        {
            base.Start();

            _content.Anchor = Anchor.BottomLeft;
            _content.BackgroundColor = Color4.Transparent;
            _content.HoverColor = Color4.Transparent;
            _content.CharacterSpacing = CharacterSpacing;
            _content.FontPath = FontPath;
            _content.FontSize = FontSize;
            _content.FontStyle = FontStyle;
            _content.FontType = FontType;
            _content.ForegroundColor = ForegroundColor;
            _content.LineSpacing = LineSpacing;
            _content.Origin = Origin.BottomLeft;
            _content.Position = NormalizedPosition;
            _content.Scale = Scale;
            _content.Size = Size;
            _content.Value = Value;
            _content.TextAlignement = TextAlignement;
            _content.TextWrapMode = TextWrapMode;

            _content.Start();

            Input.AddMouseButtonDownEvent(_onMouseDownEvent);
            Input.AddTextInputEvent(_onTextInputEvent);
            Input.AddKeyDownEvent(_onKeyDownEvent);

            _caret = MeshFactory.CreateQuad(Point2f.Zero, new Sizef(CaretWidth, FontSize), Point2f.Zero, Sizef.One);

            _caretPositionInText = 0;

            _updateCaretPositionInField();
        }

        private void _updateCaretPositionInField()
        {
            if (Started)
            {
                var textSize = _content.GetTextSize(_value.Substring(0, _caretPositionInText));
                _caretPositionInField = new Point2d(CorrectedPosition.X + MathHelper.Min(textSize.Width, Size.Width), CorrectedPosition.Y + ((Size.Height - textSize.Height) / 2));
                _caretBlinkTimer = 0;
            }
        }

        private void _updateTextPosition()
        {
            if (Started)
            {
                var textSize = _content.GetTextSize();
                var newPosition = textSize.Width - Size.Width;

                _content.FontEngine.SetPosition(newPosition > 0
                    ? new Point2f(NormalizedPosition.X - newPosition, NormalizedPosition.Y)
                    : NormalizedPosition);
            }
        }

        private void _updateSelectionRangePosition()
        {
            if (Started)
            {
                var textSize = _content.GetTextSize(_value.Substring(0, SelectedTextRange.Start));
                _selectionRangePositionInField = new Point2d(CorrectedPosition.X + MathHelper.Min(textSize.Width, Size.Width), CorrectedPosition.Y + ((Size.Height - textSize.Height) / 2));
            }
        }

        private void _onMouseDownEvent(object sender, MouseButtonEventArgs args)
        {
            _isTyping = IsHover;
            _caretPositionInText = _value.Length;

            _updateCaretPositionInField();
            _updateTextPosition();
        }

        private void _onTextInputEvent(object sender, TextInputEventArgs args)
        {
            if (_isTyping)
            {
                Value = _value.Insert(_caretPositionInText, args.KeyChar.ToString());
                CaretPosition = MathHelper.Min(_value.Length, _caretPositionInText + 1);
            }
        }

        private void _onKeyDownEvent(object sender, KeyboardKeyEventArgs args)
        {
            if (_isTyping && (args.KeyState == InputState.Pressed || args.KeyState == InputState.Repeated))
            {
                switch (args.Key)
                {
                    case KeyCode.Backspace:
                        if (SelectedTextRange.Length > 0)
                        {
                            _value = _value.Remove(SelectedTextRange.Start, SelectedTextRange.Length);
                            _caretPositionInText = SelectedTextRange.Start;
                            _createSelectionRange(0, 0);
                        }
                        else
                        {
                            _value = _value.Length > 0 && _caretPositionInText > 0 ? _value.Remove(_caretPositionInText - 1, 1) : _value;
                            _caretPositionInText = MathHelper.Max(0, _caretPositionInText - 1);
                        }
                        Value = _value;
                        break;
                    case KeyCode.Delete:
                        if (SelectedTextRange.Length > 0)
                        {
                            Value = _value.Remove(SelectedTextRange.Start, SelectedTextRange.Length);
                            _createSelectionRange(0, 0);
                        }
                        else
                        {
                            Value = _value.Length > 0 && _caretPositionInText < _value.Length ? _value.Remove(_caretPositionInText, 1) : _value;
                        }
                        break;
                    case KeyCode.Left:
                        if (args.Shift)
                        {
                            if (SelectedTextRange.Length > 0)
                                if (_caretPositionInText < SelectedTextRange.End)
                                    _createSelectionRange(MathHelper.Max(0, CaretPosition - 1), _caretPositionInText == 0 ? SelectedTextRange.Length : SelectedTextRange.Length + 1);
                                else
                                    _createSelectionRange(SelectedTextRange.Start, _caretPositionInText == 0 ? SelectedTextRange.Length : SelectedTextRange.Length - 1);
                            else if (_caretPositionInText > 0)
                                _createSelectionRange(CaretPosition, -1);
                        }
                        else
                        {
                            _createSelectionRange(0, 0);
                        }
                        CaretPosition = MathHelper.Max(0, _caretPositionInText - 1);
                        break;
                    case KeyCode.Right:
                        if (args.Shift)
                        {
                            if (SelectedTextRange.Length > 0)
                                if (_caretPositionInText >= SelectedTextRange.End)
                                    _createSelectionRange(SelectedTextRange.Start, _caretPositionInText == _value.Length ? SelectedTextRange.Length : SelectedTextRange.Length + 1);
                                else
                                    _createSelectionRange(MathHelper.Max(0, CaretPosition + 1), _caretPositionInText == _value.Length ? SelectedTextRange.Length : SelectedTextRange.Length - 1);
                            else if (_caretPositionInText < _value.Length)
                                _createSelectionRange(CaretPosition, 1);
                        }
                        else
                        {
                            _createSelectionRange(0, 0);
                        }
                        CaretPosition = MathHelper.Min(_value.Length, _caretPositionInText + 1);
                        break;
                    case KeyCode.Home:
                        if (args.Shift)
                        {
                            if (SelectedTextRange.Length > 0)
                                _createSelectionRange(0, _caretPositionInText + SelectedTextRange.Length);
                            else
                                _createSelectionRange(0, _caretPositionInText);
                        }
                        else
                        {
                            _createSelectionRange(0, 0);
                        }
                        CaretPosition = 0;
                        break;
                    case KeyCode.End:
                        if (args.Shift)
                        {
                            if (SelectedTextRange.Length > 0)
                                _createSelectionRange(SelectedTextRange.Start, _value.Length - _caretPositionInText + SelectedTextRange.Length);
                            else
                                _createSelectionRange(_caretPositionInText, _value.Length - _caretPositionInText);
                        }
                        else
                        {
                            _createSelectionRange(0, 0);
                        }
                        CaretPosition = _value.Length;
                        break;
                    case KeyCode.A:
                        if (args.Control)
                        {
                            _createSelectionRange(0, _value.Length);
                            CaretPosition = _value.Length;
                        }
                        break;
                    case KeyCode.C:
                        if (args.Control)
                        {
                            Clipboard.Copy(_value.Substring(SelectedTextRange.Start, SelectedTextRange.Length));
                        }
                        break;
                    case KeyCode.X:
                        if (args.Control)
                        {
                            Clipboard.Copy(_value.Substring(SelectedTextRange.Start, SelectedTextRange.Length));
                            Value = _value.Remove(SelectedTextRange.Start, SelectedTextRange.Length);
                            _createSelectionRange(0, 0);
                        }
                        break;
                    case KeyCode.V:
                        if (args.Control)
                        {
                            var text = Clipboard.Paste();
                            if (SelectedTextRange.Length > 0)
                            {
                                _value = _value.Remove(SelectedTextRange.Start, SelectedTextRange.Length);
                                CaretPosition = SelectedTextRange.Start;
                            }
                            Value = _value.Insert(_caretPositionInText, text);
                            CaretPosition = _caretPositionInText + text.Length;
                            _createSelectionRange(0, 0);
                        }
                        break;
                }
            }
        }

        private void _createSelectionRange(int start, int length)
        {
            SelectedTextRange = length < 0 ? new Range(start + length, start) : new Range(start, start + length);

            var selectedTextSize = _content.GetTextSize(_value.Substring(SelectedTextRange.Start, SelectedTextRange.Length));
            _selection = MeshFactory.CreateQuad(Point2f.Zero, new Sizef(MathHelper.Min(selectedTextSize.Width, Size.Width), FontSize), Point2f.Zero, Sizef.One);

            _updateSelectionRangePosition();
        }

        private void _drawSelectionQuad()
        {
            if (_selectedTextRange.Length > 0)
            {
                RendererManager.BackupState(RendererBackupMode.Blending);
                RendererManager.Blending();

                _colorShaderProgram.Bind();
                _colorShaderProgram.SetPosition(new Vector3f((float) _selectionRangePositionInField.X, (float) _selectionRangePositionInField.Y, 0));
                _colorShaderProgram.SetColor(Color4.LightSkyBlue);
                _colorShaderProgram.SetProjectionMatrix(ProjectionMatrix);
                _selection.Render();
                _colorShaderProgram.Unbind();

                RendererManager.RestoreState(RendererBackupMode.Blending);
            }
        }

        private void _drawCaret()
        {
            if (_isTyping)
            {
                if (_caretBlinkTimer < CaretBlinkInterval)
                {
                    // var caretPosition = CorrectedPosition + _cursorPosition;

                    RendererManager.BackupState(RendererBackupMode.Blending);
                    RendererManager.Blending();

                    _colorShaderProgram.Bind();
                    _colorShaderProgram.SetPosition(new Vector3f((float)_caretPositionInField.X, (float)_caretPositionInField.Y, 0));
                    _colorShaderProgram.SetColor(ForegroundColor);
                    _colorShaderProgram.SetProjectionMatrix(ProjectionMatrix);
                    _caret.Render();
                    _colorShaderProgram.Unbind();

                    RendererManager.RestoreState(RendererBackupMode.Blending);
                }
                else if (_caretBlinkTimer > CaretBlinkInterval * 2.0)
                    _caretBlinkTimer -= CaretBlinkInterval * 2.0;
            }
        }

        public override void Update()
        {
            base.Update();

            if (_isTyping)
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
            if (BackgroundTexture != null)
                RenderTexturedQuad();
            else
                RenderColoredQuad();

            _drawSelectionQuad();

            _content.Render();

            _drawCaret();
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