using System;
using System.Collections.Generic;
using System.IO;

using AlienEngine.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Graphics.Shaders;

namespace AlienEngine.UI
{
    public interface IFont
    {
        int Height { get; }

        float FontSize { get; set; }

        int GetWidth(string text);

        int GetWidth(char character);

        void CreateString(VAO<Vector3f, Vector2f> vao, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f);

        VAO<Vector3f, Vector2f> CreateString(ShaderProgram program, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f);
    }
}
