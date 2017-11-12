namespace AlienEngine.Core.Rendering.Fonts
{
    public interface IFont
    {
        FontRendererConfiguration Configuration { get; }

        Matrix4f ProjectionMatrix { get; set; }
        
        void RenderText(string text);

        float CalculateWidth(string text);

        Sizef CalculateSize(string text);
    }
}