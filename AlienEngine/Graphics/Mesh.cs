using AlienEngine.Core.Graphics.OpenGL;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace AlienEngine.Graphics
{
    internal class Mesh
    {
        private uint _vao;

        private MeshEntry _entry;

        public uint VAO
        {
            get { return _vao; }
        }

        public string Name
        {
            get { return _entry.Name; }
        }

        #region Constructors and Destructors

        public Mesh(uint vao, MeshEntry entry)
        {
            _vao = vao;
            _entry = entry;
        }

        #endregion

        #region Methods

        public void Render()
        {
            // Use the VAO
            GL.BindVertexArray(_vao);

            // Draw the mesh
            GL.DrawElementsBaseVertex(BeginMode.Triangles, _entry.NumIndices, DrawElementsType.UnsignedInt, Marshal.SizeOf(typeof(int)) * _entry.BaseIndex, _entry.BaseVertex);

            // Make sure the VAO is not changed from the outside
            GL.BindVertexArray(0);
        }

        #endregion
    }
}
