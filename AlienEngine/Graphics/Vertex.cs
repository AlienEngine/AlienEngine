using ZeroFormatter;

namespace AlienEngine.Core.Graphics
{
    [ZeroFormattable]
    public struct Vertex
    {
        // Position of the vertex
        [Index(0)]
        private Vector3f _pos;

        // Texture coordinates of the vertex
        [Index(1)]
        private Vector2f _tex;

        // Normal vector of the vertex
        [Index(2)]
        private Vector3f _normal;

        /// <summary>
        /// Gets the position of this vertex.
        /// </summary>
        [IgnoreFormat]
        public Vector3f Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        /// <summary>
        /// Gets the UV coordinates of this vertex.
        /// </summary>
        [IgnoreFormat]
        public Vector2f UV
        {
            get { return _tex; }
            set { _tex = value; }
        }

        /// <summary>
        /// Gets the normal (vector) orientation of this vertex.
        /// </summary>
        [IgnoreFormat]
        public Vector3f Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }

        /// <summary>
        /// Create a new vertex.
        /// </summary>
        /// <param name="pos">The position of this vertex.</param>
        /// <param name="uv">The uv coordinates of this vertex.</param>
        /// <param name="normal">The normal orientation of this vertex.</param>
        public Vertex(Vector3f pos, Vector2f uv, Vector3f normal)
        {
            _pos = pos;
            _tex = uv;
            _normal = normal;
        }
    }
}

