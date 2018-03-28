using AlienEngine.Core.Rendering;
using AlienEngine.Core.Rendering.Fonts;
using AlienEngine.Imaging;
using System;
using System.Collections.Generic;
using AlienEngine.UI;

namespace AlienEngine
{
    public class ListBox : UIComponent, IPostRenderable
    {
        private Text _selectedLabel;

        private List<Text> _lines;

        private Button _button;

        private int _selectedIndex;

        private string[] _items;

        private bool _isChoosing;

        public string[] Items
        {
            get { return _items; }
            set
            {
                _items = value;
                for (int i = 0, l = _items.Length; i < l; i++)
                {
                    if (_lines.Count <= i)
                        _lines.Add(new Text());

                    _lines[i].Value = _items[i];
                }
            }
        }

        public Color4 ItemBackgroundColor;

        public Color4 ItemHoverColor;

        public Texture ItemBackgroundTexture;

        public Texture ItemHoverTexture;

        public Color4 ButtonBackgroundColor;

        public Color4 ButtonHoverColor;

        public Color4 ButtonPressedColor;

        public Texture ButtonBackgroundTexture;

        public Texture ButtonHoverTexture;

        public Texture ButtonPressedTexture;

        public Sizef ButtonSize;

        public string Selected => _items[_selectedIndex];

        public float CharacterSpacing;

        public string FontPath;

        public float FontSize;

        public FontStyle FontStyle;

        public FontType FontType;

        public float LineSpacing;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        public float ItemsPadding;

        public event Action<object, ListBoxChangeEventArgs> Change;

        public ListBox()
        {
            _selectedLabel = new Text();

            _lines = new List<Text>();

            _button = new Button();
        }

        public override void Start()
        {
            base.Start();

            Sizef itemSize = new Sizef(Size.Width, FontSize + ItemsPadding * 2);

            Point2f position = Position;
            position.Y -= Size.Height;

            for (int i = 0, l = _items.Length; i < l; i++)
            {
                _lines[i].Anchor = Anchor;
                _lines[i].BackgroundColor = ItemBackgroundColor;
                _lines[i].HoverColor = ItemHoverColor;
                _lines[i].CharacterSpacing = CharacterSpacing;
                _lines[i].FontPath = FontPath;
                _lines[i].FontSize = FontSize;
                _lines[i].FontStyle = FontStyle;
                _lines[i].FontType = FontType;
                _lines[i].ForegroundColor = ForegroundColor;
                _lines[i].LineSpacing = LineSpacing;
                _lines[i].Origin = Origin;
                _lines[i].Position = position;
                _lines[i].Scale = Scale;
                _lines[i].Size = itemSize;
                _lines[i].Value = _items[i];
                _lines[i].TextAlignement = TextAlignement;
                _lines[i].TextWrapMode = TextWrapMode;

                _lines[i].Start();

                position.Y -= itemSize.Height;
            }

            _button.BackgroundColor = ButtonBackgroundColor;
            _button.HoverColor = ButtonHoverColor;
            _button.PressColor = ButtonPressedColor;
            _button.BackgroundTexture = ButtonBackgroundTexture;
            _button.HoverTexture = ButtonHoverTexture;
            _button.PressTexture = ButtonPressedTexture;
            _button.Position = new Point2f(Size.Width, Position.X);
            _button.Anchor = Anchor;
            _button.Origin = Origin;
            _button.Size = ButtonSize;
            _button.FontPath = FontPath;
            _button.FontSize = FontSize;
            _button.Text = "";
            _button.LeftClick += () => { _isChoosing = true; };

            _button.Start();

            _selectedLabel.Anchor = Anchor;
            _selectedLabel.BackgroundColor = BackgroundColor;
            _selectedLabel.HoverColor = HoverColor;
            _selectedLabel.CharacterSpacing = CharacterSpacing;
            _selectedLabel.FontPath = FontPath;
            _selectedLabel.FontSize = FontSize;
            _selectedLabel.FontStyle = FontStyle;
            _selectedLabel.FontType = FontType;
            _selectedLabel.ForegroundColor = ForegroundColor;
            _selectedLabel.LineSpacing = LineSpacing;
            _selectedLabel.Origin = Origin;
            _selectedLabel.Position = Position;
            _selectedLabel.Scale = Scale;
            _selectedLabel.Size = Size;
            _selectedLabel.TextAlignement = TextAlignement;
            _selectedLabel.TextWrapMode = TextWrapMode;

            _selectedLabel.Start();

            Input.AddMouseButtonDownEvent((sender, args) =>
            {
                for (int i = 0, l = _lines.Count; i < l; i++)
                {
                    if (_lines[i].IsHover && _isChoosing)
                    {
                        var old = Selected;
                        _selectedIndex = i;
                        Change?.Invoke(this, new ListBoxChangeEventArgs(old, Selected));
                    }
                }

                if (!_button.IsHover)
                    _isChoosing = false;
            });
        }

        public override void Update()
        {
            base.Update();

            _selectedLabel.Value = Selected;

            _selectedLabel.Update();

            _button.Update();

            for (int i = 0, l = _lines.Count; i < l; i++)
                _lines[i].Update();
        }

        public void Render()
        {
            _selectedLabel.Render();

            _button.Render();

            if (_isChoosing)
                for (int i = 0, l = _lines.Count; i < l; i++)
                    _lines[i].Render();
        }

        private bool _disposedValue;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposedValue) return;

            if (disposing)
            {
                _selectedLabel?.Dispose();
                _selectedLabel = null;

                _lines.Clear();
                _lines = null;

                _button?.Dispose();
                _button = null;

                ItemBackgroundTexture?.Dispose();
                ItemBackgroundTexture = null;

                ItemHoverTexture?.Dispose();
                ItemHoverTexture = null;

                ButtonBackgroundTexture?.Dispose();
                ButtonBackgroundTexture = null;

                ButtonHoverTexture?.Dispose();
                ButtonHoverTexture = null;

                ButtonPressedTexture?.Dispose();
                ButtonPressedTexture = null;
            }

            _disposedValue = true;
        }
    }
}