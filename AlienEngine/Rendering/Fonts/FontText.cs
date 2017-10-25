namespace AlienEngine.Core.Rendering.Fonts
{
    /// <summary>
    /// Class to hide GLFontTextNodeList and related classes from 
    /// user whilst allowing a textNodeList to be passed around.
    /// </summary>
	public class FontText
    {
        internal FontTextNodeList textNodeList;
        internal Sizef maxSize;
        internal FontAlignment alignment;
		public FontVertexBuffer[] VertexBuffers;
    }
}
