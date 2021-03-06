﻿using AlienEngine.Shaders.ASL;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.Core.Shaders.Samples
{
    [Version("330 core")]
    public class ColoredUIVertexShader: VertexShader
    {
        [Uniform] vec3 position;
        [Uniform] mat4 projection_matrix;

        [Layout(Location = GL.VERTEX_POSITION_LOCATION)] [In] vec3 in_position;

        void main()
        {
            gl_Position = projection_matrix * new vec4(position + in_position, 1);
        }
    }
}