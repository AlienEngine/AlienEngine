using System;

namespace AlienEngine.Graphics
{
    public struct Vertex
    {
        public readonly static int SIZE = 3;

        // Position of the vertex
        private Vector3f _pos;

        // Texture of the vertex
        private Vector2f _tex;

        // Normal of the vertex
        private Vector3f _normal;

        /// <summary>
        /// Gets the position of this vertex.
        /// </summary>
        public Vector3f Position
        {
            get { return _pos; }
        }

        /// <summary>
        /// Gets the UV coordinates of this vertex.
        /// </summary>
        public Vector2f UV
        {
            get { return _tex; }
        }

        /// <summary>
        /// Gets the normal (vector) orientation of this vertex.
        /// </summary>
        public Vector3f Normal
        {
            get { return _normal; }
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

        public void SetPosition(Vector3f pos)
        {
            _pos = pos;
        }
    }
}

