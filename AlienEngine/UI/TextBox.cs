using System;
using System.Collections.Generic;
using System.Drawing;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering.Fonts;

namespace AlienEngine.UI
{
	public class TextBox : Control
	{
        public string Text { get { return text; } set { if (value != text) { text = value; Invalidate(); } } }
        public bool Enabled { get { return enabled; } set { enabled = value; Invalidate(); } }
        public Skin.TextBoxSkin SkinEnabled { get { return skinEnabled; } set { skinEnabled = value; Invalidate(); } }
        public Skin.TextBoxSkin SkinActive { get { return skinActive; } set { skinActive = value; Invalidate(); } }
        public Skin.TextBoxSkin SkinHover { get { return skinHover; } set { skinHover = value; Invalidate(); } }
        public Skin.TextBoxSkin SkinDisabled { get { return skinDisabled; } set { skinDisabled = value; Invalidate(); } }

        public bool WordWrap = false;
        public bool Multiline = false;

        public event EventHandler Changed;

		private string text = "";
        private FontText textProcessed = new FontText();
		private Sizef textSize;
        private FontTextPosition cursorPosition = new FontTextPosition();
		private Skin.TextBoxSkin skinEnabled, skinActive, skinHover, skinDisabled;
		private Skin.TextBoxSkin skin;
		private bool enabled = true;
		private bool over = false;
		private Rectangle background;
        private FontTextPosition selectionStart;
        private Stack<string> history = new Stack<string>();
        private Stack<string> future = new Stack<string>();

		public TextBox(Gui gui) : base(gui)
		{
			Render += OnRender;
			MouseDown += OnMouseDown;
			MouseUp += OnMouseUp;
			MouseEnter += OnMouseEnter;
			MouseLeave += OnMouseLeave;
            MouseMove += OnMouseMove;
			Focus += OnFocus;
			FocusLost += OnFocusLost;
			KeyDown += OnKeyDown;
			KeyPress += OnKeyPress;

			skinEnabled = Gui.Skin.TextBoxEnabled;
			skinActive = Gui.Skin.TextBoxActive;
			skinHover = Gui.Skin.TextBoxHover;
			skinDisabled = Gui.Skin.TextBoxDisabled;

			outer = new Rectangle(0, 0, 100, 0);

			ContextMenu = new ContextMenu(gui);
            ContextMenu.Add(new ContextMenuEntry(gui) { Text = "Copy" }).Click += (s, e) => { if (selectionStart.Index != cursorPosition.Index) CopySelection(); };
			ContextMenu.Add(new ContextMenuEntry(gui) { Text = "Paste" }).Click += (s, e) => { if(Clipboard.ContainsText()) Insert(Clipboard.GetText()); };
		}

        protected override void UpdateLayout()
		{
			skin = Enabled ? (HasFocus ? skinActive : (over ? skinHover : skinEnabled)) : skinDisabled;

			outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);

            textSize = skin.Font.ProcessText(textProcessed, text,
				new Sizef(
                    WordWrap ? 
                        (AutoSize ? float.MaxValue : outer.Width - skin.Border.Horizontal - skin.Padding.Horizontal)
                        : SizeMax.Width - skin.Border.Horizontal - skin.Padding.Horizontal,
                    Multiline ? 
                        (AutoSize ? float.MaxValue : outer.Height - skin.Border.Vertical - skin.Padding.Vertical)
                        : skin.Font.LineSpacing),
                skin.TextAlign);
			int minHeight = Math.Max(sizeMin.Height, (int)textSize.Height + skin.Border.Vertical + skin.Padding.Vertical);

			if (AutoSize)
			{
				outer.Width = (int)textSize.Width + skin.Border.Horizontal + skin.Padding.Horizontal;
                outer.Height = minHeight;
				outer.Width = Math.Min(Math.Max(outer.Width, sizeMin.Width), sizeMax.Width);
			}

			outer.Height = Math.Min(Math.Max(Multiline ? outer.Height : (int)skin.Font.LineSpacing + skin.Border.Vertical + skin.Padding.Vertical, sizeMin.Height), sizeMax.Height);

			background = new Rectangle(
				skin.Border.Left, skin.Border.Top,
				outer.Width - skin.Border.Horizontal, outer.Height - skin.Border.Vertical);
			Inner = new Rectangle(
				background.Left + skin.Padding.Left, background.Top + skin.Padding.Top,
				background.Width - skin.Padding.Horizontal, background.Height - skin.Padding.Vertical);

            cursorPosition.Position = new Vector2f(float.MaxValue, float.MaxValue);
            cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
            selectionStart.Position = new Vector2f(float.MaxValue, float.MaxValue);
            selectionStart = skin.Font.GetTextPosition(textProcessed, selectionStart);
		}

        private double caretBlinkTimer = 0.0;
        private const double caretBlinkInterval = 0.7;
        private void OnRender(object sender, double timeDelta)
		{
            caretBlinkTimer += timeDelta;

			Draw.Fill(ref skin.BorderColor);
			Draw.FillRect(ref background, ref skin.BackgroundColor);

            if (selectionStart.Index != cursorPosition.Index)
            {
                var start = selectionStart.Index < cursorPosition.Index ? selectionStart : cursorPosition;
                var end = selectionStart.Index < cursorPosition.Index ? cursorPosition : selectionStart;
                if (Math.Abs(selectionStart.Position.Y - cursorPosition.Position.Y) < 0.0001f)
                {
                    Draw.FillRect(
                        new Rectangle(
                            Inner.X + (int)start.Position.X,
                            Inner.Y + (int)start.Position.Y,
                            (int)(end.Position.X - start.Position.X),
                            (int)skin.Font.LineSpacing),
                        ref skin.SelectionColor);
                }
                else
                {
                    int y = Inner.Y + (int)start.Position.Y;
                    int ymax = Inner.Y + (int)end.Position.Y;
                    Draw.FillRect(new Rectangle(Inner.X + (int)start.Position.X, y, Inner.Width - (int)start.Position.X, (int)skin.Font.LineSpacing), ref skin.SelectionColor);
                    y += (int)skin.Font.LineSpacing;
                    Draw.FillRect(new Rectangle(Inner.X, y, InnerWidth, ymax - y), ref skin.SelectionColor);
                    Draw.FillRect(new Rectangle(Inner.X, ymax, (int)end.Position.X, (int)skin.Font.LineSpacing), ref skin.SelectionColor);
                }
            }

            Draw.Text(textProcessed, Inner, ref skin.Color);

			if (enabled)
			{
				if (HasFocus && caretBlinkTimer < caretBlinkInterval)
                    Draw.FillRect(
                        new Rectangle(
                            Inner.X + (int)cursorPosition.Position.X,
						    Inner.Y + (int)cursorPosition.Position.Y,
                            1, (int)skin.Font.LineSpacing), ref skin.Color);
				else if (caretBlinkTimer > caretBlinkInterval * 2.0)
						caretBlinkTimer -= caretBlinkInterval * 2.0;
			}
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (enabled && e.Button == MouseButton.Left)
			{
				isDragged = true;
                cursorPosition.Index = int.MaxValue;
				cursorPosition.Position = new Vector2f((float)e.X - Inner.X, (float)e.Y - Inner.Y);
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                selectionStart = cursorPosition;
			}
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (enabled && e.Button == MouseButton.Left)
			{
				if (isDragged)
				{
					isDragged = false;
				}
			}
		}

		private void OnMouseEnter(object sender, EventArgs e)
		{
			over = true;
			Gui.Cursor = Cursor.Beam;
            Invalidate();
		}

		private void OnMouseLeave(object sender, EventArgs e)
		{
			over = false;
			Gui.Cursor = Cursor.Default;
            Invalidate();
		}

        private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            if (isDragged)
            {
                cursorPosition.Index = int.MaxValue;
                cursorPosition.Position = new Vector2f((float)e.X - Inner.X, (float)e.Y - Inner.Y);
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
            }
        }

		private void OnFocus(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void OnFocusLost(object sender, EventArgs e)
		{
            Invalidate();
		}

		private bool OnKeyPress(object sender, TextInputEventArgs e)
		{
			if (!enabled)
				return false;
			if (!char.IsControl(e.KeyChar))
			{
				Insert(e.KeyChar.ToString());
				return true;
			}
			return false;
		}

		private bool OnKeyDown(object sender, KeyboardKeyEventArgs e)
		{
			if (!enabled)
				return false;
			if (e.Key == KeyCode.Delete)
			{
                if (selectionStart.Index != cursorPosition.Index)
                {
                    future.Clear();
                    history.Push(text);
                    RemoveSelection();
                }
                else if (cursorPosition.Index < text.Length)
                {
                    future.Clear();
                    history.Push(text);
                    text = text.Remove(cursorPosition.Index, 1);
                }
                else
                    return true;
                Invalidate();
                if (Changed != null) Changed(this, e);
				return true;
			}
			if (e.Key == KeyCode.Backspace)
			{
                if (selectionStart.Index != cursorPosition.Index)
                {
                    future.Clear();
                    history.Push(text);
                    RemoveSelection();
                }
                else if (cursorPosition.Index > 0)
                {
                    future.Clear();
                    history.Push(text);
                    text = text.Remove(--cursorPosition.Index, 1);
                    selectionStart = cursorPosition;
                }
                else
                    return true;
				Invalidate();
				if (Changed != null) Changed(this, e);
				return true;
			}
			if (e.Key == KeyCode.Enter && Multiline)
			{
				Insert("\n");
				return true;
			}
            if (e.Key == KeyCode.Left && cursorPosition.Index > 0)
			{
                cursorPosition.Index--;
                cursorPosition.Position = new Vector2f(float.MaxValue, float.MaxValue);
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
				return true;
			}
            if (e.Key == KeyCode.Right && cursorPosition.Index < text.Length)
			{
                cursorPosition.Index++;
                cursorPosition.Position = new Vector2f(float.MaxValue, float.MaxValue);
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
				return true;
			}
            if (e.Key == KeyCode.Up && cursorPosition.Position.Y > 0.0f)
            {
                cursorPosition.Index = int.MaxValue;
                cursorPosition.Position.Y -= skin.Font.LineSpacing;
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
				return true;
            }
            if (e.Key == KeyCode.Down)
            {
                cursorPosition.Index = int.MaxValue;
                cursorPosition.Position.Y += skin.Font.LineSpacing;
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
				return true;
            }
            if (e.Control && e.Key == KeyCode.A)
            {
                selectionStart.Index = 0;
                selectionStart.Position = new Vector2f(float.MaxValue, float.MaxValue);
                selectionStart = skin.Font.GetTextPosition(textProcessed, selectionStart);
                cursorPosition.Index = text.Length;
                cursorPosition.Position = new Vector2f(float.MaxValue, float.MaxValue);
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                return true;
            }
            if (e.Control && e.Key == KeyCode.X)
            {
                if (selectionStart.Index != cursorPosition.Index)
                {
                    future.Clear();
                    history.Push(text);
                    CopySelection();
                    RemoveSelection();
                    Invalidate();
                    if (Changed != null) Changed(this, e);
                }
                return true;
            }
			if (e.Control && e.Key == KeyCode.C)
			{
                if (selectionStart.Index != cursorPosition.Index)
                    CopySelection();
				return true;
			}
			if (e.Control && e.Key == KeyCode.V)
            {
                if (Clipboard.ContainsText())
					Insert(Clipboard.GetText());
				return true;
            }
            if (e.Control && e.Key == KeyCode.Z)
            {
                if (!e.Shift)
                {
                    if (history.Count > 0)
                    {
                        future.Push(text);
                        text = history.Pop();
                        Invalidate();
                    }
                }
                else if (future.Count > 0)
                {
                    history.Push(text);
                    text = future.Pop();
                    Invalidate();
                }
                return true;
            }
            if (e.Key == KeyCode.Tab)
            {
                if (selectionStart.Index != cursorPosition.Index)
                    Indent(e.Shift);
                else
                    Insert("\t");
                return true;
            }
            if (e.Key == KeyCode.Home)
            {
                cursorPosition.Index = int.MaxValue;
                cursorPosition.Position.X = 0;
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
                return true;
            }
            if (e.Key == KeyCode.End)
            {
                cursorPosition.Index = int.MaxValue;
                cursorPosition.Position.X = float.MaxValue;
                cursorPosition = skin.Font.GetTextPosition(textProcessed, cursorPosition);
                if (!e.Shift)
                    selectionStart = cursorPosition;
                return true;
            }
			return false;
		}

        private void CopySelection()
        {
            int first = Math.Min(selectionStart.Index, cursorPosition.Index);
            int length = Math.Max(selectionStart.Index, cursorPosition.Index) - first;
            Clipboard.SetText(text.Substring(first, length));
        }

        private void RemoveSelection()
        {
            int first = Math.Min(selectionStart.Index, cursorPosition.Index);
            int length = Math.Max(selectionStart.Index, cursorPosition.Index) - first;
            text = text.Remove(first, length);
            cursorPosition.Index = first;
            selectionStart = cursorPosition;
        }

		private void Insert(string str)
		{
            future.Clear();
            history.Push(text);

            if (selectionStart.Index != cursorPosition.Index)
                RemoveSelection();

			text = text.Insert(cursorPosition.Index, str);
			cursorPosition.Index += str.Length;
            selectionStart = cursorPosition;
			Invalidate();
			if (Changed != null)
                Changed(this, EventArgs.Empty);
		}

        private void Indent(bool unindent)
        {
            future.Clear();
            history.Push(text);
            int first = Math.Min(selectionStart.Index, cursorPosition.Index);
            int last = Math.Max(selectionStart.Index, cursorPosition.Index);
            for (int i = first - 1; i < last; i++)
            {
                if (i == first - 1 || text[i] == '\n')
                {
                    if (!unindent)
                    {
                        // indent
                        text = text.Insert(i + 1, "\t");
                        last++;
                    }
                    else if (text.Length > i + 1)
                    {
                        // unindent
                        if (text[i + 1] == '\t')
                        {
                            text = text.Remove(i + 1, 1);
                            last--;
                        }
                        else
                        {
                            for (int j = 0; j < 4 && text.Length > i + 1; j++)
                            {
                                if (text[i + 1] == ' ')
                                {
                                    text = text.Remove(i + 1, 1);
                                    last--;
                                }
                            }
                        }
                    }
                }
            }
            if (last != cursorPosition.Index && last != selectionStart.Index)
            {
                // fix selection bounds
                if (cursorPosition.Index == first)
                    selectionStart.Index = last;
                else
                    cursorPosition.Index = last;

                Invalidate();
                if (Changed != null)
                    Changed(this, EventArgs.Empty);
            }
            else
                history.Pop();
        }
	}
}

