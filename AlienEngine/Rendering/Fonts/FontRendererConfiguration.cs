using AlienEngine.UI;

namespace AlienEngine.Core.Rendering.Fonts
{
    /// <summary>
    /// Describe a freetype font configuration.
    /// </summary>
    public struct FontRendererConfiguration
    {
        /// <summary>
        /// The font's color.
        /// </summary>
        public Color4 Color;

        /// <summary>
        /// The font's position.
        /// </summary>
        public Point2f Position;

        /// <summary>
        /// The font's scale.
        /// </summary>
        public Vector2f Scale;

        /// <summary>
        /// The font's text alignment.
        /// </summary>
        public TextAlignement TextAlignement;

        /// <summary>
        /// The font's text wrap mode.
        /// </summary>
        public TextWrapMode TextWrapMode;

        /// <summary>
        /// The text origin position.
        /// </summary>
        public Origin TextOrigin;

        /// <summary>
        /// The text container's size.
        /// </summary>
        public Sizef Container;

        /// <summary>
        /// The font's character spacing.
        /// </summary>
        public float CharacterSpacing;

        /// <summary>
        /// The font's line spacing.
        /// </summary>
        public float LineSpacing;

        /// <summary>
        /// The font's size.
        /// </summary>
        public float FontSize;

        /// <summary>
        /// The font's style.
        /// </summary>
        public FontStyle FontStyle;

        /// <summary>
        /// Default font configuration.
        /// </summary>
        public static FontRendererConfiguration Default = new FontRendererConfiguration
        {
            Color = Color4.Black,
            Position = Point2f.Zero,
            Scale = Vector2f.One,
            TextAlignement = TextAlignement.Left,
            TextWrapMode = TextWrapMode.None,
            TextOrigin = Origin.BottomLeft,
            Container = Sizef.Zero,
            CharacterSpacing = 0,
            LineSpacing = 0,
            FontSize = 12,
            FontStyle = FontStyle.Regular
        };
    }
}