namespace AlienEngine.Core.Rendering.Fonts
{
    public struct FontRendererConfiguration
    {
        public Color4 Color;

        public Point2f Position;

        public Vector2f Scale;

        public TextAlignement TextAlignement;

        public TextWrapMode TextWrapMode;

        public TextOrigin TextOrigin;

        public Sizef Container;

        public float CharacterSpacing;

        public float LineSpacing;

        public static FontRendererConfiguration Default = new FontRendererConfiguration
        {
            Color = Color4.Black,
            Position = Point2f.Zero,
            Scale = Vector2f.One,
            TextAlignement = TextAlignement.Left,
            TextWrapMode = TextWrapMode.None,
            TextOrigin = TextOrigin.BottomLeft,
            Container = Sizef.Zero,
            CharacterSpacing = 0,
            LineSpacing = 0
        };
    }
}