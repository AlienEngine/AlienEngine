using AlienEngine.Core.Assets.Mesh;
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
        public virtual string Source { get; protected set; }

        /// <summary>
        /// The file extension handled by this asset.
        /// </summary>
        [IgnoreFormat]
        public string Extension => "aemesh";

        /// <summary>
        /// The list of childs in this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(1)]
        public virtual List<MeshData> Childs { get; protected set; }

        /// <summary>
        /// The type of data handled by this asset.
        /// </summary>
        [IgnoreFormat]
        public AssetTypes Type => AssetTypes.Mesh;

        /// <summary>
        /// Gets the merged <see cref="MeshData"/>.
        /// </summary>
        [IgnoreFormat]
        public MeshData Merged
        {
            get
            {
                MeshData result = new MeshData(Source);
                foreach (var mesh in Childs)
                {
                    result.Vertices.AddRange(mesh.Vertices);
                    result.Indices.AddRange(mesh.Indices);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="MeshAsset"/> instance.
        /// </summary>
        public MeshAsset()
        {
            Childs = new List<MeshData>();

            Source = string.Empty;
        }

        /// <summary>
        /// Creates a new <see cref="MeshAsset"/> instance.
        /// </summary>
        private MeshAsset(string source): this()
        {
            Source = source;
        }

        /// <summary>
        /// Add a new child in the list.
        /// </summary>
        /// <param name="child">The child to add.</param>
        private void AddChild(MeshData child)
        {
            child.SetParent(this);
            Childs.Add(child);
        }

        private static MeshAsset ComputeAssetChildrens(ref Scene scene, ref MeshAsset element, Node node)
        {
            var _tempAsset = new MeshData(node.Name);

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

                            _tempAsset.Vertices.Add(new Vertex(pos, new Vector2f(uv), normal));
                        }

                        // Populate the index buffer
                        for (int j = 0; j < mesh.FaceCount; j++)
                        {
                            Assimp.Face face = mesh.Faces[j];
                            // TODO: Find a suitable way to draw vertices...
                            // Now only support triangulated faces
                            _tempAsset.Indices.Add(face.Indices[0]);
                            _tempAsset.Indices.Add(face.Indices[1]);
                            _tempAsset.Indices.Add(face.Indices[2]);
                        }
                    }
                }
            }

            if (node.HasChildren)
                for (int i = 0; i < node.ChildCount; i++)
                    if (node.Children[i].HasMeshes) ComputeAssetChildrens(ref scene, ref element, node.Children[i]);

            if (element != null)
                element.AddChild(_tempAsset);

            return element;
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
                Scene scene = importer.ImportFile(meshFile, PostProcessSteps.Triangulate | PostProcessSteps.SortByPrimitiveType | PostProcessSteps.CalculateTangentSpace | PostProcessSteps.Debone);

                MeshAsset asset = new MeshAsset(meshFile);
                asset = ComputeAssetChildrens(ref scene, ref asset, scene.RootNode);

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

            var data = ZeroFormatterSerializer.Serialize(this);

            var test = ZeroFormatterSerializer.Deserialize<MeshAsset>(data);

            if (!File.Exists(filePath) || force)
            {
                File.WriteAllBytes(filePath, data);
            }
            else
            {
                throw new Exception($"The file at \"{filePath}\" already exists");
            }
        }

        //private List<Tuple<int, MeshAsset>> _computeSerializableAsset(int p, int o)
        //{
        //    var result = new List<Tuple<int, MeshAsset>>();

        //    result.Add(new Tuple<int, MeshAsset>(o, this));

        //    for (int i = 0, l = Childs.Count; i < l; i++)
        //    {
        //        var child = Childs[i];

        //        if (child.Childs.Count > 0)
        //            result.AddRange(child._computeSerializableAsset(i, p + 1));
        //        else
        //            result.Add(new Tuple<int, MeshAsset>(p + 1, child));
        //    }

        //    return result;
        //}
    }
}
