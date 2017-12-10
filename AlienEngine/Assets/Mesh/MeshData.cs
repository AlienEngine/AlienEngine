using AlienEngine.Core.Graphics;
using System.Collections.Generic;
using ZeroFormatter;

namespace AlienEngine.Core.Assets.Mesh
{
    [ZeroFormattable]
    public class MeshData
    {
        /// <summary>
        /// The name of this <see cref="MeshData"/>.
        /// </summary>
        [Index(0)]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets the parent <see cref="MeshData"/> of this one.
        /// </summary>
        /// <remarks>
        /// If this <see cref="MeshData"/> is the root node, then <see cref="Parent"/> = <see cref="null"/>.
        /// </remarks>
        [Index(1)]
        public virtual MeshAsset Parent { get; protected set; }

        /// <summary>
        /// The list of mesh vertices in this <see cref="MeshData"/>.
        /// </summary>
        [Index(2)]
        public virtual List<Vertex> Vertices { get; protected set; }

        /// <summary>
        /// The list of mesh indices in this <see cref="MeshData"/>.
        /// </summary>
        [Index(3)]
        public virtual List<int> Indices { get; protected set; }

        /// <summary>
        /// Gets a list of vertices positions in this <see cref="MeshData"/>.
        /// </summary>
        [IgnoreFormat]
        public Vector3f[] VerticesPositions
        {
            get
            {
                List<Vector3f> collection = new List<Vector3f>();
                foreach (var vertice in Vertices)
                {
                    collection.Add(vertice.Position);
                }

                return collection.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of vertices normals in this <see cref="MeshData"/>.
        /// </summary>
        [IgnoreFormat]
        public Vector3f[] VerticesNormals
        {
            get
            {
                List<Vector3f> collection = new List<Vector3f>();
                foreach (var vertice in Vertices)
                {
                    collection.Add(vertice.Normal);
                }

                return collection.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of vertices texture coordinates in this <see cref="MeshData"/>.
        /// </summary>
        [IgnoreFormat]
        public Vector2f[] VerticesUvs
        {
            get
            {
                List<Vector2f> collection = new List<Vector2f>();
                foreach (var vertice in Vertices)
                {
                    collection.Add(vertice.UV);
                }

                return collection.ToArray();
            }
        }

        /// <summary>
        /// Constructs a new mesh data.
        /// </summary>
        public MeshData()
        {
            Name = string.Empty;
            Parent = null;

            Vertices = new List<Vertex>();
            Indices = new List<int>();
        }

        /// <summary>
        /// Constructs a new mesh data.
        /// </summary>
        /// <param name="name">The name of the mesh.</param>
        public MeshData(string name): this()
        {
            Name = name;
        }

        /// <summary>
        /// Sets the parent <see cref="MeshAsset"/> of this <see cref="MeshData"/>.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(MeshAsset parent)
        {
            Parent = parent;
        }
    }
}
