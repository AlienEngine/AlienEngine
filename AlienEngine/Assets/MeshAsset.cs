using AlienEngine.Core.Graphics;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;

namespace AlienEngine.Core.Assets
{
    /// <summary>
    /// An asset representing a 3D mesh.
    /// </summary>
    [ZeroFormattable]
    public class MeshAsset : IAsset
    {
        /// <summary>
        /// The source file of this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(0)]
        private string _sourceMesh;

        /// <summary>
        /// The file extension handled by this asset.
        /// </summary>
        [Index(1)]
        private string _extension = "aemesh";

        /// <summary>
        /// Gets the parent <see cref="MeshAsset"/> of this one.
        /// </summary>
        /// <remarks>
        /// If this <see cref="MeshAsset"/> is the root node, <see cref="Parent"/> = <see cref="null"/>.
        /// </remarks>
        [Index(2)]
        private MeshAsset _parent;

        /// <summary>
        /// The list of childs in this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(3)]
        private List<MeshAsset> _childs;

        /// <summary>
        /// The list of mesh vertices in this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(4)]
        private List<Vertex> _vertices;

        /// <summary>
        /// The list of mesh indices in this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(5)]
        private List<int> _indices;

        /// <summary>
        /// The type of data handled by this asset.
        /// </summary>
        [IgnoreFormat]
        public AssetTypes Type => AssetTypes.Mesh;

        /// <summary>
        /// The source file of this <see cref="MeshAsset"/>.
        /// </summary>
        public string Source => _sourceMesh;

        /// <summary>
        /// The file extension handled by this asset.
        /// </summary>
        public string Extension => _extension;

        /// <summary>
        /// Gets the parent <see cref="MeshAsset"/> of this one.
        /// </summary>
        /// <remarks>
        /// If this <see cref="MeshAsset"/> is the root node, <see cref="Parent"/> = <see cref="null"/>.
        /// </remarks>
        public MeshAsset Parent => _parent;

        /// <summary>
        /// The list of childs in this <see cref="MeshAsset"/>.
        /// </summary>
        public MeshAsset[] Childs => _childs.ToArray();

        /// <summary>
        /// Gets the merged <see cref="MeshAsset"/> data.
        /// </summary>
        public MeshAsset Merged
        {
            get
            {
                MeshAsset result = new MeshAsset(Source);
                foreach (var mesh in _childs)
                {
                    result._vertices.AddRange(mesh.Vertices);
                    result._indices.AddRange(mesh.Indices);
                }

                return result;
            }
        }

        /// <summary>
        /// The list of vertices.
        /// </summary>
        public Vertex[] Vertices => _vertices.ToArray();

        /// <summary>
        /// The list of indices.
        /// </summary>
        public int[] Indices => _indices.ToArray();

        /// <summary>
        /// Gets a list of vertices positions in this <see cref="MeshAsset"/>.
        /// </summary>
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
        /// Gets a list of vertices normals in this <see cref="MeshAsset"/>.
        /// </summary>
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
        /// Gets a list of vertices texture coordinates in this <see cref="MeshAsset"/>.
        /// </summary>
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
        /// Creates a new <see cref="MeshAsset"/> instance.
        /// </summary>
        private MeshAsset(string source)
        {
            _vertices = new List<Vertex>();
            _indices = new List<int>();

            _sourceMesh = source;
            _childs = new List<MeshAsset>();
            _parent = null;
        }

        /// <summary>
        /// Add a new child in the list.
        /// </summary>
        /// <param name="child">The child to add.</param>
        private void AddChild(MeshAsset child)
        {
            _childs.Add(child);
        }

        private static MeshAsset ComputeAssetChildrens(ref Scene scene, MeshAsset element, Node node)
        {
            var _tempAsset = new MeshAsset(node.Name);

            if (node.HasMeshes)
            {
                for (int i = 0; i < node.MeshCount; i++)
                {
                    // Initialize assets
                    Assimp.Mesh mesh = scene.Meshes[node.MeshIndices[i]];

                    Assimp.Vector3D Zero3D = new Assimp.Vector3D(0f);

                    if (mesh.PrimitiveType == Assimp.PrimitiveType.Triangle)
                    {
                        // Populate the vertex attribute vectors
                        for (int j = 0; j < mesh.VertexCount; j++)
                        {
                            Vector3f pos = (Vector3f)mesh.Vertices[j];
                            Vector3f normal = (Vector3f)mesh.Normals[j];
                            Vector3f uv = (Vector3f)(mesh.HasTextureCoords(0) ? mesh.TextureCoordinateChannels[0][j] : Zero3D);
                            Vector3f tn = (Vector3f)(mesh.HasTangentBasis ? mesh.Tangents[j] : Zero3D);
                            Vector3f btn = (Vector3f)(mesh.HasTangentBasis ? mesh.BiTangents[j] : Zero3D);

                            _tempAsset._vertices.Add(new Vertex(pos, new Vector2f(uv), normal));
                        }

                        // Populate the index buffer
                        for (int j = 0; j < mesh.FaceCount; j++)
                        {
                            Assimp.Face face = mesh.Faces[j];
                            // TODO: Find a suitable way to draw vertices...
                            // Now only support triangulated faces
                            _tempAsset._indices.Add(face.Indices[0]);
                            _tempAsset._indices.Add(face.Indices[1]);
                            _tempAsset._indices.Add(face.Indices[2]);
                        }
                    }
                }
            }

            if (node.HasChildren)
                for (int i = 0; i < node.ChildCount; i++)
                    ComputeAssetChildrens(ref scene, _tempAsset, node.Children[i]);

            if (element != null)
                element.AddChild(_tempAsset);

            return _tempAsset;
        }

        /// <summary>
        /// Checks if a file is a serialized <see cref="MeshAsset"/>.
        /// </summary>
        /// <param name="meshFile">The file to check.</param>
        public static bool IsAsset(string meshFile)
        {
            // TODO: Use Zeroformatter to retrieve and compare the union type
            return false;
        }

        /// <summary>
        /// Create a <see cref="MeshAsset"/> instance from a file.
        /// </summary>
        /// <param name="meshFile">
        /// The mesh file. Can be an AlienEngine Mesh Asset file (.aemesh)
        /// or all other 3D mesh file (.fbx, .obj, .dae, etc...)
        /// </param>
        public static MeshAsset From(string meshFile)
        {
            if (IsAsset(meshFile))
            {
                // Extract data from mesh file
                return new MeshAsset(meshFile);
            }

            AssimpContext importer = new AssimpContext();

            try
            {
                Scene scene = importer.ImportFile(meshFile, PostProcessSteps.Triangulate | PostProcessSteps.SortByPrimitiveType);

                MeshAsset asset = ComputeAssetChildrens(ref scene, null, scene.RootNode);
                asset._sourceMesh = meshFile;

                return asset;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error parsing {0}: {1}", meshFile, e.Message));
                throw;
            }
        }

        public void Serialize(string filePath, bool force = false)
        {
            if (!filePath.EndsWith($".{Extension}"))
                filePath = filePath + $".{Extension}";

            StringBuilder file = new StringBuilder();
            var data = ZeroFormatterSerializer.Serialize<IAsset>(this);
            
            if (!File.Exists(filePath) || force)
            {
                File.WriteAllBytes(filePath, data);
            }
            else
            {
                throw new Exception($"The file at \"{filePath}\" already exists");
            }
        }
    }
}
