using System;
using AlienEngine.Core.Shaders;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Graphics.Buffers
{
	/// <summary>
	/// Represents a Vertex Array Object, used to
	/// draw meshes.
	/// </summary>
    public class VAO : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The <see cref="VBO{T}"/> of vertices associated to
        /// this <see cref="VAO"/>.
        /// </summary>
        private VBO<Vector3f> _vertex;

        /// <summary>
        /// The <see cref="VBO{T}"/> of normals associated to
        /// this <see cref="VAO"/>.
        /// </summary>
        private VBO<Vector3f> _normal;

        /// <summary>
        /// The <see cref="VBO{T}"/> of tangents associated to
        /// this <see cref="VAO"/>.
        /// </summary>
        private VBO<Vector3f> _tangent;

        /// <summary>
        /// The <see cref="VBO{T}"/> of bitangents associated to
        /// this <see cref="VAO"/>.
        /// </summary>
        private VBO<Vector3f> _bitangent;

        /// <summary>
        /// The <see cref="VBO{T}"/> of texture coordinates
        /// associated to this <see cref="VAO"/>.
        /// </summary>
        private VBO<Vector2f> _uv;

        /// <summary>
        /// The <see cref="VBO{T}"/> of vertices indices associated to
        /// this <see cref="VAO"/>.
        /// </summary>
        private VBO<int> _element;

        /// <summary>
        /// Defines if the <see cref="VAO"/> is disposed or not.
        /// </summary>
        private bool _disposeChildren;

        #endregion

        #region Properties

        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// Specifies if the VAO should dispose of the child VBOs when Dispose() is called.
        /// </summary>
        public bool DisposeChildren
        {
            get { return _disposeChildren; }
            set
            {
                _disposeChildren = value;
                DisposeElementArray = value;
            }
        }

        /// <summary>
        /// Specifies if the VAO should dispose of the element array when Dispose() is called.
        /// </summary>
        public bool DisposeElementArray { get; set; }

        /// <summary>
        /// The drawing mode to use when drawing the arrays.
        /// </summary>
        public BeginMode DrawMode { get; set; }

        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [CLSCompliant(false)]
        public uint ID { get; private set; }

        #endregion

        #region Constructors and Destructor

        public VAO(VBO<Vector3f> vertex, VBO<int> element)
            : this(vertex, null, null, null, null, element)
        {
        }

        public VAO(VBO<Vector3f> vertex, VBO<Vector2f> uv, VBO<int> element)
            : this(vertex, null, null, null, uv, element)
        {
        }

        public VAO(VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<int> element)
            : this(vertex, normal, null, null, null, element)
        {
        }

        public VAO(VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<Vector2f> uv, VBO<int> element)
            : this(vertex, normal, null, null, uv, element)
        {
        }

        public VAO(VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<Vector3f> tangent, VBO<Vector3f> bitangent, VBO<Vector2f> uv, VBO<int> element)
        {
            VertexCount = element.Count;
            DrawMode = BeginMode.Triangles;

            _vertex = vertex;
            _normal = normal;
            _tangent = tangent;
            _bitangent = bitangent;
            _uv = uv;
            _element = element;

            // Generate a new VAO
            ID = GL.GenVertexArray();

            Bind();

            if (_vertex != null)
            {
                GL.BindBuffer(_vertex.BufferTarget, _vertex.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, _vertex.Size, _vertex.PointerType, false, 0, 0);
            }

            if (_normal != null)
            {
                GL.BindBuffer(_normal.BufferTarget, _normal.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_NORMAL_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_NORMAL_LOCATION, _normal.Size, _normal.PointerType, false, 0, 0);
            }

            if (_tangent != null)
            {
                GL.BindBuffer(_tangent.BufferTarget, _tangent.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_TANGENT_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_TANGENT_LOCATION, _tangent.Size, _tangent.PointerType, false, 0, 0);
            }

            if (_bitangent != null)
            {
                GL.BindBuffer(_bitangent.BufferTarget, _bitangent.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_BITANGENT_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_BITANGENT_LOCATION, _bitangent.Size, _bitangent.PointerType, false, 0, 0);
            }

            if (_uv != null)
            {
                GL.BindBuffer(_uv.BufferTarget, _uv.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, _uv.Size, _uv.PointerType, false, 0, 0);
            }

            GL.BindBuffer(_element.BufferTarget, _element.ID);

            // Make sure this VAO is not modified from the outside
            Unbind();

            ResourcesManager.AddDisposableResource(this);
        }

        ~VAO()
        {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        public void Bind()
        {
            GL.BindVertexArray(ID);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        public void Draw(MeshEntry mesh)
        {
            // Use the VAO
            Bind();

            // Draw the mesh
            GL.DrawElementsBaseVertex(BeginMode.Triangles, mesh.NumIndices, DrawElementsType.UnsignedInt, BlittableValueType.StrideOf(default(int)) * mesh.BaseIndex, mesh.BaseVertex);

            // Make sure the VAO is not changed from the outside
            Unbind();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // first try to dispose of the vertex array
            if (ID != 0)
            {
                GL.DeleteVertexArrays(1, new uint[] {ID});
                ID = 0;
            }

            // children must be disposed of separately since OpenGL 2.1 will not have a vertex array
            if (DisposeChildren)
            {
                _vertex?.Dispose();
                _normal?.Dispose();
                _tangent?.Dispose();
                _uv?.Dispose();
                if (_element != null && DisposeElementArray) _element.Dispose();

                _vertex = null;
                _normal = null;
                _tangent = null;
                _uv = null;
                _element = null;
            }
        }

        #endregion
    }
}