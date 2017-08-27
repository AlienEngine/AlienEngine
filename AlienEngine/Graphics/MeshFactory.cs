using AlienEngine.Core.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Graphics
{
    public static class MeshFactory
    {
        public static Mesh CreatePlane(Vector3f location, Sizef size)
        {
            Vector3f[] vertices = new Vector3f[]
            {
                new Vector3f(location.X, 0, location.Y),
                new Vector3f(location.X + size.Width, 0, location.Y),
                new Vector3f(location.X + size.Width, 0, location.Y + size.Height),
                new Vector3f(location.X, 0, location.Y + size.Height)
            };

            Vector2f[] uvs = new Vector2f[]
            {
                new Vector2f(0, 0),
                new Vector2f(1, 0),
                new Vector2f(1, 1),
                new Vector2f(0, 1)
            };

            int[] indices = new int[] { 2, 1, 0, 0, 3, 2 };

            MeshEntry plane = new MeshEntry();

            plane.BaseIndex = 0;
            plane.BaseVertex = 0;
            plane.NumIndices = indices.Length;
            plane.Name = "Plane";

            // Create the VAO
            uint _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            VBO<Vector3f> vertex = new VBO<Vector3f>(vertices);
            VBO<Vector2f> normal = new VBO<Vector2f>(uvs);
            VBO<int> element = new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

            GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, vertex.Size, vertex.PointerType, true, vertex.Size * 4, 0);

            GL.EnableVertexAttribArray(GL.VERTEX_NORMAL_LOCATION);
            GL.BindBuffer(normal.BufferTarget, normal.ID);
            GL.VertexAttribPointer(GL.VERTEX_NORMAL_LOCATION, normal.Size, normal.PointerType, true, normal.Size * 4, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, element.ID);

            GL.BindVertexArray(0);

            // Add a dispose event to delete the generated VAO
            Resources.ResourcesManager.AddOnDisposeEvent(() => GL.DeleteVertexArrays(1, _vao));

            return new Mesh(_vao, plane);
        }
    }
}
