using AlienEngine.ASL;

namespace AlienEngine.Shaders.Samples
{
    [Version(330)]
    public class FontVertexShader : VertexShader
    {
        [Layout(Location = 0)] [In] vec4 vertex;

        [Out] vec2 texCoords;

        [Uniform] mat4 projection;

        void main()
        {
            gl_Position = projection * new vec4(vertex.xy, 0.0f, 1.0f);
            texCoords = vertex.zw;
        }
    }
}