using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Shaders.Samples
{
    [Version(330)]
    public class FontVertexShader : VertexShader
    {
        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec4 vertex;

        [Out] vec2 texCoords;

        [Uniform] mat4 projection;

        void main()
        {
            vec4 pos = projection * new vec4(vertex.xy, 0.0f, 1.0f);
            texCoords = vertex.zw;
            gl_Position = pos.xyww;
        }
    }
}