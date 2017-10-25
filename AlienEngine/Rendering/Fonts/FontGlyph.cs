using System.Drawing;

namespace AlienEngine.Core.Rendering.Fonts
{
    public class FontGlyph
    {
        /// <summary>
        /// Which texture page the glyph is on
        /// </summary>
        public int Page; 
        
        /// <summary>
        /// The rectangle defining the glyphs position on the page
        /// </summary>
        public Rectangle Rect;
        
        /// <summary>
        /// How far the glyph would need to be vertically offset to be vertically in line with the tallest glyph in the set of all glyphs
        /// </summary>
        public int YOffset;

        /// <summary>
        /// Which character this glyph represents
        /// </summary>
        public char Character;

        public PointF TextureMin, TextureMax;

        public FontGlyph(int page, Rectangle rect, int yOffset, char character)
        {
            Page = page;
            Rect = rect;
            YOffset = yOffset;
            Character = character;
        }
    }
}
