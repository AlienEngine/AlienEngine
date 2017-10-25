namespace AlienEngine.Core.Rendering.Fonts
{
    class FontTextNode
    {
        public FontTextNodeType Type;
        public string Text;
		public float Length; // pixel length (without tweaks)
		public float LengthTweak; // length tweak for justification

        public float ModifiedLength
        {
            get { return Length + LengthTweak; }
        }

		public FontTextNode(FontTextNodeType type, string text)
        {
			Type = type;
			Text = text;
        }

        public FontTextNode Next;
        public FontTextNode Previous;
    }
}
