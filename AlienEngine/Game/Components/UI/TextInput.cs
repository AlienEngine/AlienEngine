using System;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.Imaging;
using AlienEngine.UI;

namespace AlienEngine
{
    public class TextInput : UIComponent
    {
        private static Cursor _Ibeam;
        
        private Text _content;

        private string _value;

        private bool _isTyping;
        
        public string Value
        {
            get { return _value; }
            set
            {
                TextChange?.Invoke(this, new InputFieldTextChangeEventArgs(_value, value));
                _value = value;
                _content.Value = value;
            }
        }

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

        public event Action<object, InputFieldTextChangeEventArgs> TextChange;

        static TextInput()
        {
            _Ibeam = new Cursor(Cursor.CursorType.Beam);
        }
        
        public TextInput()
        {
            _content = new Text();
        }

        public override void Start()
        {
            base.Start();

            _content.CharacterSpacing = CharacterSpacing;
            _content.FontPath = FontPath;
            _content.FontSize = FontSize;
            _content.FontStyle = FontStyle;
            _content.FontType = FontType;
            _content.LineSpacing = LineSpacing;
            _content.TextAlignement = TextAlignement;
            _content.TextWrapMode = TextWrapMode;
            _content.Value = Value;
            _content.Anchor = Anchor;
            _content.BackgroundColor = Color4.Transparent;
            _content.ForegroundColor = ForegroundColor;
            _content.HoverColor = Color4.Transparent;
            _content.Origin = Origin;
            _content.Position = Position;
            _content.Scale = Scale;
            _content.Size = Size;
            
            _content.Start();

            Input.AddMouseButtonDownEvent((sender, args) =>
            {
                _isTyping = IsHover;
            });
        }
    }
}