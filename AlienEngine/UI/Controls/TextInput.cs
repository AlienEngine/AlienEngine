using System;

using AlienEngine;

namespace AlienEngine.UI
{
    public class TextInput : UIContainer
    {
        #region Variables
        private Text _text;
        private Text _carret;
        private bool _hasFocus = false;
        private int _carretPosition = 0;
        private float _carretHideTime = 0;
        #endregion

        #region Properties
        /// <summary>
        /// CarriageReturn callback delegate prototype.
        /// </summary>
        /// <param name="entry">The TextEntry that received the carriage return signal.</param>
        /// <param name="text">The text contained in the TextEntry when the carriage return signal was received.</param>
        public delegate void OnTextEvent(TextInput entry, string text);

        /// <summary>
        /// Event is called when the carriage return button (Enter on most keyboards) is pressed.
        /// </summary>
        public OnTextEvent OnCarriageReturn { get; set; }

        /// <summary>
        /// Event is called when any text is entered or deleted.
        /// </summary>
        public OnTextEvent OnTextEntry { get; set; }

        /// <summary>
        /// The contents of the TextEntry.
        /// </summary>
        public string String
        {
            get { return _text.String; }
        }

        public int CarretPosition
        {
            get { return _carretPosition; }
            set
            {
                _carretPosition = MathHelper.Clamp(value, 0, _text.String.Length);
                _carret.Position = new Point2i(_text.Font.GetWidth(String.Substring(0, CarretPosition)) + (2 * _text.Font.GetWidth(' ') / 3), 0);
            }
        }

        public Color3 Color
        {
            get { return _text.Color; }
            set
            {
                _text.Color = value;
            }
        }
        #endregion

        #region Constructor
        public TextInput(IFont font, string s = "")
            : base(new Point2i(0, 0), new Sizei(200, font.Height), "TextEntry" + UserInterface.GetUniqueElementID())
        {
            _carret = new Text(Shaders.FontShader, font, "|");
            _carret.RelativeTo = Corner.BottomLeft;
            _carret.Visible = false;

            _text = new Text(Shaders.FontShader, font, s, Font.Alignement.Left, font.FontSize);
            _text.RelativeTo = Corner.Fill;
            _text.Padding = new Sizei(5, 0);

            this.OnMouseClick = new OnMouse((o, e) => _text.OnMouseClick(o, e));

            _text.OnMouseEnter = new OnMouse((o, e) => Cursor.SetCursor(Cursor.CursorType.Beam));
            _text.OnMouseLeave = new OnMouse((o, e) => Cursor.SetCursor(Cursor.CursorType.Arrow));

            _text.OnMouseClick = new OnMouse((o, e) =>
                {
                    if (_hasFocus) return;
                    _hasFocus = true;
                    _carret.Visible = true;

                    Input.ClearTextInputEvents(true);
                    Input.ClearKeyEvents(true);

                    var _tID = Input.AddTextInputEvent((key) =>
                    {
                        // give 16 pixels of padding on the right
                        if (_text.TextSize.X > Size.X - 16) return;

                        _text.String = _text.String.Insert(CarretPosition, key.ToString());
                        CarretPosition++;

                        if (OnTextEntry != null) OnTextEntry(this, String);
                    });

                    var _kID = Input.AddKeyEvent((key, state, mods) =>
                    {
                        if (state == Input.InputState.Press || state == Input.InputState.Repeat)
                        {
                            switch (key)
                            {
                                case Input.KeyCode.Backspace:
                                    if (string.IsNullOrEmpty(_text.String)) return;
                                    else if (CarretPosition == 0) return;
                                    else
                                    {
                                        _text.String = _text.String.Remove(CarretPosition - 1, 1);
                                        CarretPosition--;
                                    }

                                    if (OnTextEntry != null) OnTextEntry(this, String);
                                    break;

                                case Input.KeyCode.Delete:
                                    if (string.IsNullOrEmpty(_text.String)) return;
                                    else if (CarretPosition == _text.String.Length) return;
                                    else _text.String = _text.String.Remove(CarretPosition, 1);

                                    if (OnTextEntry != null) OnTextEntry(this, String);
                                    break;

                                case Input.KeyCode.Enter:
                                    if (OnCarriageReturn != null) OnCarriageReturn(this, String);
                                    break;

                                case Input.KeyCode.Escape:
                                    _text.OnLoseFocus(null, null);
                                    break;

                                case Input.KeyCode.Right:
                                    if (CarretPosition >= _text.String.Length) return;
                                    CarretPosition++;
                                    break;

                                case Input.KeyCode.Left:
                                    if (CarretPosition == 0) return;
                                    CarretPosition--;
                                    break;

                                case Input.KeyCode.Home:
                                    CarretPosition = 0;
                                    break;

                                case Input.KeyCode.End:
                                    CarretPosition = _text.String.Length;
                                    break;
                            }
                        }
                    });

                    // restore the key bindings when we lose focus
                    _text.OnLoseFocus = new OnFocus((sender, newFocus) =>
                        {
                            if (!_hasFocus) return;
                            _hasFocus = false;
                            _carret.Visible = false;
                            Input.RestoreEvents();
                        });
                });

            this.AddElement(_text);
            this.AddElement(_carret);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_hasFocus)
            {
                _hasFocus = false;
            }
        }

        public void Clear()
        {
            _text.String = String.Empty;
        }
        #endregion
    }
}
