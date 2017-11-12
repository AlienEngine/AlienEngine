using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Physics.CollisionShapes.ConvexShapes;
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
        /// <summary>
        /// Calculate the array of vertex normals based on vertex and face information (assuming triangle polygons).
        /// </summary>
        /// <param name="vertexData">The vertex data to find the normals for.</param>
        /// <param name="elementData">The element array describing the order in which vertices are drawn.</param>
        /// <returns></returns>
        public static Vector3f[] CalculateNormals(Vector3f[] vertexData, int[] elementData)
        {
            Vector3f b1, b2, normal;
            Vector3f[] normalData = new Vector3f[vertexData.Length];

            for (int i = 0; i < elementData.Length / 3; i++)
            {
                int cornerA = elementData[i * 3];
                int cornerB = elementData[i * 3 + 1];
                int cornerC = elementData[i * 3 + 2];

                b1 = vertexData[cornerB] - vertexData[cornerA];
                b2 = vertexData[cornerC] - vertexData[cornerA];

                normal = Vector3f.Normalize(Vector3f.Cross(b1, b2));

                normalData[cornerA] += normal;
                normalData[cornerB] += normal;
                normalData[cornerC] += normal;
            }

            for (int i = 0; i < normalData.Length; i++) normalData[i] = Vector3f.Normalize(normalData[i]);

            return normalData;
        }

        public static Mesh CreatePlane(Vector2f location, Sizef size)
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

            Vector3f[] normals = CalculateNormals(vertices, indices);

            MeshEntry plane = new MeshEntry();

            plane.BaseIndex = 0;
            plane.BaseVertex = 0;
            plane.NumIndices = indices.Length;
            plane.Name = "Plane";

            // Create the VAO
            uint _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            VBO<Vector3f> vertex = new VBO<Vector3f>(vertices);
            VBO<Vector2f> texture = new VBO<Vector2f>(uvs);
            VBO<Vector3f> normal = new VBO<Vector3f>(normals);
            VBO<int> element = new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, vertex.Size, vertex.PointerType, false, 0, 0);

            GL.BindBuffer(texture.BufferTarget, texture.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, texture.Size, texture.PointerType, false, 0, 0);

            GL.BindBuffer(normal.BufferTarget, normal.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_NORMAL_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_NORMAL_LOCATION, normal.Size, normal.PointerType, false, 0, 0);

            GL.BindBuffer(element.BufferTarget, element.ID);

            // Make sure this VAO is not modified from the outside
            GL.BindVertexArray(0);

            // Add a dispose event to delete the generated VAO
            Resources.ResourcesManager.AddOnDisposeEvent(() => GL.DeleteVertexArray(_vao));

            return new Mesh(_vao, plane);
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes UV co-ordinates from 0,0 to 1,1.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static Mesh CreateQuad(Point2f location, Sizef size, Point2f uvloc, Sizef uvsize)
        {
            Vector3f[] vertices = new Vector3f[]
            {
                new Vector3f(location.X, location.Y, 0),
                new Vector3f(location.X + size.X, location.Y, 0),
                new Vector3f(location.X + size.X, location.Y + size.Y, 0),
                new Vector3f(location.X, location.Y + size.Y, 0)
            };

            Vector2f[] uvs = new Vector2f[]
            {
                new Vector2f(uvloc.X, uvloc.Y),
                new Vector2f(uvloc.X + uvsize.X, uvloc.Y),
                new Vector2f(uvloc.X + uvsize.X, uvloc.Y + uvsize.Y),
                new Vector2f(uvloc.X, uvloc.Y + uvsize.Y)
            };

            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            MeshEntry quad = new MeshEntry();

            quad.BaseIndex = 0;
            quad.BaseVertex = 0;
            quad.NumIndices = indices.Length;
            quad.Name = "Quad";

            // Create the VAO
            uint _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            VBO<Vector3f> vertex = new VBO<Vector3f>(vertices);
            VBO<Vector2f> texture = new VBO<Vector2f>(uvs);
            VBO<int> element = new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, vertex.Size, vertex.PointerType, false, 0, 0);

            GL.BindBuffer(texture.BufferTarget, texture.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, texture.Size, texture.PointerType, false, 0, 0);

            GL.BindBuffer(element.BufferTarget, element.ID);

            // Make sure this VAO is not modified from the outside
            GL.BindVertexArray(0);

            // Add a dispose event to delete the generated VAO
            Resources.ResourcesManager.AddOnDisposeEvent(() => GL.DeleteVertexArray(_vao));

            return new Mesh(_vao, quad);
        }

        /// <summary>
        /// Create a basic cube with normals and stores it in a VAO.
        /// This cube consists of 12 triangles and 6 faces.
        /// </summary>
        /// <param name="min">The 3 minimum values of the cube (lower left back corner).</param>
        /// <param name="max">The 3 maximum values of the cube (top right front corner).</param>
        /// <returns></returns>
        public static Mesh CreateCube(Vector3f min, Vector3f max)
        {
            Vector3f[] vertices = new Vector3f[] {
                new Vector3f(min.X, min.Y, max.Z),
                new Vector3f(max.X, min.Y, max.Z),
                new Vector3f(min.X, max.Y, max.Z),
                new Vector3f(max.X, max.Y, max.Z),
                new Vector3f(max.X, min.Y, min.Z),
                new Vector3f(max.X, max.Y, min.Z),
                new Vector3f(min.X, max.Y, min.Z),
                new Vector3f(min.X, min.Y, min.Z)
            };

            int[] indices = new int[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            Vector3f[] normals = CalculateNormals(vertices, indices);


            MeshEntry cube = new MeshEntry();

            cube.BaseIndex = 0;
            cube.BaseVertex = 0;
            cube.NumIndices = indices.Length;
            cube.Name = "Cube";

            // Create the VAO
            uint _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            VBO<Vector3f> vertex = new VBO<Vector3f>(vertices);
            VBO<Vector3f> normal = new VBO<Vector3f>(normals);
            VBO<int> element = new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, vertex.Size, vertex.PointerType, false, 0, 0);

            GL.BindBuffer(normal.BufferTarget, normal.ID);
            GL.EnableVertexAttribArray(GL.VERTEX_NORMAL_LOCATION);
            GL.VertexAttribPointer(GL.VERTEX_NORMAL_LOCATION, normal.Size, normal.PointerType, false, 0, 0);

            GL.BindBuffer(element.BufferTarget, element.ID);

            // Make sure this VAO is not modified from the outside
            GL.BindVertexArray(0);

            // Add a dispose event to delete the generated VAO
            Resources.ResourcesManager.AddOnDisposeEvent(() => GL.DeleteVertexArray(_vao));

            return new Mesh(_vao, cube);
        }

        public static Mesh CreateCube(BoxCollider collider)
        {
            BoxShape shape = ((BoxShape)collider.Shape);
            Vector3f size = new Vector3f(shape.HalfWidth + shape.CollisionMargin, shape.HalfHeight + shape.CollisionMargin, shape.HalfLength + shape.CollisionMargin);
            return CreateCube(-size, size);
        }
    }
}
