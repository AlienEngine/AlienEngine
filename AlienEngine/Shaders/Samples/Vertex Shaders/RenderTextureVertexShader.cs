using AlienEngine.ASL;
using AlienEngine.Core.Graphics.OpenGL;
using System;

namespace AlienEngine.Core.Graphics.Shaders
{
    [Version(330)]
    internal class RenderTextureVertexShader : VertexShader
    {
        #region VAO Objects

        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec2 in_position;
        [Layout(Location = GL.VERTEX_TEXTURE_COORD_LOCATION)] [In] vec2 in_uv;

        #endregion

        #region Fragment shader inputs

        [Out] vec2 uv;

        #endregion

        void main()
        {
            uv = in_uv;
            gl_Position = new vec4(in_position.x, in_position.y, 0.0f, 1.0f);
        }
    }
}
