namespace AlienEngine.Core.Rendering.Fonts
{
    /// <summary>
    /// What settings to use when building the font
    /// </summary>
    public class FontBuilderConfiguration
    {
        public FontKerningConfiguration KerningConfig = new FontKerningConfiguration();

        /// <summary>
        /// Whether to use super sampling when building font texture pages
        /// 
        /// 
        /// </summary>
        public int SuperSampleLevels = 1;

        /// <summary>
        /// The standard width of texture pages (the page will
        /// automatically be cropped if there is extra space)
        /// </summary>
        public int PageWidth = 512;

        /// <summary>
        /// The standard height of texture pages (the page will
        /// automatically be cropped if there is extra space)
        /// </summary>
        public int PageHeight = 512;

        /// <summary>
        /// Whether to force texture pages to use a power of two.
        /// </summary>
        public bool ForcePowerOfTwo = true;

        /// <summary>
        /// The margin (on all sides) around glyphs when rendered to
        /// their texture page
        /// </summary>
        public int GlyphMargin = 2;
       
        /// <summary>
        /// Set of characters to support
        /// </summary>
        public string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.:,;'\"(!?)+-*/=_{}[]@~#\\<>|^%$£&";

        /// <summary>
        /// Which render hint to use when rendering the ttf character set to create the GLFont texture
        /// </summary>
        public FontRenderHint TextGenerationRenderHint = FontRenderHint.SizeDependent;
    }
}
