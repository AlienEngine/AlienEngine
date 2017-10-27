namespace AlienEngine.Core.Rendering.Fonts
{
    public interface IFont
    {
        Matrix4f ProjectionMatrix { get; set; }
        
        void RenderText(string text, FontRendererConfiguration config);

        float CalculateWidth(string text, Vector2f scale);
    }
}