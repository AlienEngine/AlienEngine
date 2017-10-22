﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

using AlienEngine.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Graphics.QuickFont;
using AlienEngine.Core.Graphics.QuickFont.Configuration;
using AlienEngine.Graphics.Shaders;

namespace AlienEngine.UI
{
    /// <summary>
    /// The BMFont class can be used to load both the texture and data files associated with
    /// the free BMFont tool (http://www.angelcode.com/products/bmfont/)
    /// </summary>
    public class BMFont : IFont
    {
        private static Dictionary<string, BMFont> loadedFonts = new Dictionary<string, BMFont>();

        public static BMFont LoadFont(string file)
        {
            if (!loadedFonts.ContainsKey(file) || loadedFonts[file] == null)
            {
                BMFont font = null;

                try
                {
                    font = new BMFont(file);
                }
                catch (Exception)
                {
                    throw new FileNotFoundException(string.Format("Could not load the BMFont file: {0}", file), file);
                }

                loadedFonts.Add(file, font);
            }

            return loadedFonts[file];
        }

        public static void Dispose()
        {
            foreach (var font in loadedFonts)
                font.Value.FontTexture.Dispose();

            loadedFonts.Clear();
        }

        /// <summary>
        /// Stores the ID, height, width and UV information for a single bitmap character
        /// as exported by the BMFont tool.
        /// </summary>
        private struct Character
        {
            public char id;
            public float x1;
            public float y1;
            public float x2;
            public float y2;
            public float width;
            public float height;
            public float xoffset;
            public float yoffset;
            public float xadvance;

            public Character(char _id, float _x1, float _y1, float _x2, float _y2, float _w, float _h, float _xoffset, float _yoffset, float _xadvance)
            {
                id = _id;
                x1 = _x1;
                y1 = _y1;
                x2 = _x2;
                y2 = _y2;
                width = _w;
                height = _h;
                xoffset = _xoffset;
                yoffset = _yoffset;
                xadvance = _xadvance;
            }
        }

        /// <summary>
        /// The font texture associated with this bitmap font.
        /// </summary>
        public Texture FontTexture { get; private set; }

        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        /// <summary>
        /// The height (in pixels) of this bitmap font.
        /// </summary>
        public int Height { get; private set; }

        public float FontSize { get { return 1; } set { } }

        public string Name { get; set; }

        public Dictionary<char, Dictionary<char, int>> kerning = new Dictionary<char, Dictionary<char, int>>();

        /// <summary>
        /// Loads both a font descriptor table and the associated texture as exported by BMFont.
        /// </summary>
        /// <param name="descriptorPath">The path to the font descriptor table.</param>
        public BMFont(string descriptorPath)
        {
            // get the directory name of the font descriptor and texture
            string directory = new FileInfo(descriptorPath).DirectoryName;

            using (StreamReader stream = new StreamReader(descriptorPath))
            {
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    if (line.StartsWith("page"))
                    {
                        // split up the different entries on this line to be parsed
                        string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < split.Length; i++)
                        {
                            if (!split[i].Contains("=")) continue;
                            string code = split[i].Substring(0, split[i].IndexOf('='));
                            string contents = split[i].Substring(split[i].IndexOf('=') + 1);

                            if (code == "id" && contents != "0") throw new Exception("Currently we only support loading one texture at a time.");
                            else if (code == "file") FontTexture = new Texture(directory + "/" + contents.Trim(new char[] { '"' }));
                        }
                    }
                    else if (line.StartsWith("char "))
                    {
                        // split up the different entries on this line to be parsed
                        string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        int id = 0;
                        float x1 = 0, y1 = 0, x2 = 0, y2 = 0, w = 0, h = 0, xo = 0, yo = 0, xa = 0;

                        // parse the contents of the line, looking for key words
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (!split[i].Contains("=")) continue;
                            string code = split[i].Substring(0, split[i].IndexOf('='));
                            int value = int.Parse(split[i].Substring(split[i].IndexOf('=') + 1));

                            if (code == "id") id = value;
                            else if (code == "x") x1 = (float)value / FontTexture.Size.Width;
                            else if (code == "y") y1 = 1 - (float)value / FontTexture.Size.Height;
                            else if (code == "width")
                            {
                                w = (float)value;
                                x2 = x1 + w / FontTexture.Size.Width;
                            }
                            else if (code == "height")
                            {
                                h = (float)value;
                                y2 = y1 - h / FontTexture.Size.Height;
                                this.Height = Math.Max(this.Height, value);
                            }
                            else if (code == "xoffset") xo = (float)value;
                            else if (code == "yoffset") yo = (float)value;
                            else if (code == "xadvance") xa = (float)value;
                        }

                        // store this character into our dictionary (if it doesn't already exist)
                        Character c = new Character((char)id, x1, y1, x2, y2, w, h, xo, yo, xa);
                        if (!characters.ContainsKey(c.id)) characters.Add(c.id, c);
                    }
                    else if (line.StartsWith("kerning"))
                    {
                        // split up the different entries on this line to be parsed
                        string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        char first = ' ', second = ' ';
                        int amount = 0;

                        // parse the contents of the line, looking for key words
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (!split[i].Contains("=")) continue;
                            string code = split[i].Substring(0, split[i].IndexOf('='));
                            int value = int.Parse(split[i].Substring(split[i].IndexOf('=') + 1));

                            if (code == "first") first = (char)value;
                            else if (code == "second") second = (char)value;
                            else if (code == "amount") amount = value;
                        }

                        if (!kerning.ContainsKey(first)) kerning.Add(first, new Dictionary<char, int>());
                        kerning[first][second] = amount;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the width (in pixels) of a single character of text using the loaded font.
        /// </summary>
        /// <param name="c">The character to measure the width of.</param>
        /// <returns>The width (in pixels) of the provided character.</returns>
        public int GetWidth(char c)
        {
            return (int)characters[characters.ContainsKey(c) ? c : ' '].xadvance + 1;
        }

        /// <summary>
        /// Gets the width (in pixels) of a string of text using the current loaded font.
        /// </summary>
        /// <param name="text">The string of text to measure the width of.</param>
        /// <returns>The width (in pixels) of the provided text.</returns>
        public int GetWidth(string text)
        {
            int width = 0;

            for (int i = 0; i < text.Length; i++)
                width += (int)characters[characters.ContainsKey(text[i]) ? text[i] : ' '].xadvance + 1;

            return width;
        }

        private static int maxStringLength = 200;
        private static Vector3f[] vertices = new Vector3f[maxStringLength * 4];
        private static Vector2f[] uvs = new Vector2f[maxStringLength * 4];
        private static int[] indices = new int[maxStringLength * 6];

        private void CreateStringInternal(string text, Color3 color, Font.Alignement justification, float scale)
        {
            int xpos = 0;

            // calculate the initial x position depending on the justification
            if (justification == Font.Alignement.Right) xpos = -GetWidth(text);
            else if (justification == Font.Alignement.Center) xpos = -GetWidth(text) / 2;

            Vector3f scalingFactor = Vector3f.One * scale;

            for (int i = 0; i < text.Length; i++)
            {
                // grab the character, replacing with ' ' if the character isn't loaded
                Character ch = characters[characters.ContainsKey(text[i]) ? text[i] : ' '];

                float offset = this.Height - ch.yoffset;

                // check for kerning
                /*if (i > 0 && kerning.ContainsKey(text[i - 1]) && kerning[text[i - 1]].ContainsKey(text[i]))
                    xpos += kerning[text[i - 1]][text[i]];*/
                xpos += 1;

                vertices[i * 4 + 0] = scalingFactor * new Vector3f(xpos, offset, 0);
                vertices[i * 4 + 1] = scalingFactor * new Vector3f(xpos, offset - ch.height, 0);
                vertices[i * 4 + 2] = scalingFactor * new Vector3f(xpos + ch.width, offset, 0);
                vertices[i * 4 + 3] = scalingFactor * new Vector3f(xpos + ch.width, offset - ch.height, 0);
                xpos += (int)ch.xadvance;
                if (text[i] == '_') xpos += 3;

                uvs[i * 4 + 0] = new Vector2f(ch.x1, ch.y1);
                uvs[i * 4 + 1] = new Vector2f(ch.x1, ch.y2);
                uvs[i * 4 + 2] = new Vector2f(ch.x2, ch.y1);
                uvs[i * 4 + 3] = new Vector2f(ch.x2, ch.y2);

                indices[i * 6 + 0] = i * 4 + 2;
                indices[i * 6 + 1] = i * 4 + 0;
                indices[i * 6 + 2] = i * 4 + 1;
                indices[i * 6 + 3] = i * 4 + 3;
                indices[i * 6 + 4] = i * 4 + 2;
                indices[i * 6 + 5] = i * 4 + 1;
            }
        }

        /// <summary>
        /// Creates a string over top of an old string VAO of the same length.
        /// Does not overwrite the indices, since those should be consistent
        /// across VAOs of the same length when describing text.
        /// </summary>
        /// <param name="vao">The current vao object.</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        public void CreateString(VAO<Vector3f, Vector2f> vao, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f)
        {
            if (vao == null || vao.ID == 0) return;
            if (vao.VertexCount != text.Length * 6) throw new InvalidOperationException("Text length did not match the length of the current vertex array object.");

            CreateStringInternal(text, color, justification, scale);

            // simply update the underlying VBOs (indices shouldn't be modified)
            GL.BufferSubData(vao.vbos[0].ID, BufferTarget.ArrayBuffer, vertices, text.Length * 4);
            GL.BufferSubData(vao.vbos[1].ID, BufferTarget.ArrayBuffer, uvs, text.Length * 4);
        }

        /// <summary>
        /// Creates a new VAO object with a specified string.
        /// </summary>
        /// <param name="program">The shader program to use with this text (FontShader or Font3DShader).</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        /// <returns>The VAO which contains vertex, UV and index information.</returns>
        public VAO<Vector3f, Vector2f> CreateString(ShaderProgram program, string text, Color3 color, Font.Alignement justification = Font.Alignement.Left, float scale = 1f)
        {
            if (text.Length > maxStringLength)
            {
                maxStringLength = (int)Math.Min(int.MaxValue, (text.Length * 1.5));

                vertices = new Vector3f[maxStringLength * 4];
                uvs = new Vector2f[maxStringLength * 4];
                indices = new int[maxStringLength * 6];
            }

            CreateStringInternal(text, color, justification, scale);

            // Create the vertex buffer objects and then create the array object
            return new VAO<Vector3f, Vector2f>(program,
                new VBO<Vector3f>(vertices, text.Length * 4),
                new VBO<Vector2f>(uvs, text.Length * 4),
                new string[] { "in_position", "in_uv" },
                new VBO<int>(indices, text.Length * 6, BufferTarget.ElementArrayBuffer));
        }
    }
}
