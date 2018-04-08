using AlienEngine.Core.Assets.Mesh;
using AlienEngine.Core.Assets.Material;
using AlienEngine.Core.Graphics;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AlienEngine.ASL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.Core.Shaders.Samples;
using ZeroFormatter;

namespace AlienEngine.Core.Assets
{
    /// <summary>
    /// An asset representing a 3D mesh.
    /// </summary>
    [ZeroFormattable]
    public class MeshAsset : IAsset
    {
        private const string Ext = "aemesh";
        
        private static List<string> _loadedTextures;

        /// <summary>
        /// The source file of this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(0)]
        public virtual string Source { get; protected set; }

        /// <summary>
        /// The file extension handled by this asset.
        /// </summary>
        [IgnoreFormat]
        public string Extension => Ext;

        /// <summary>
        /// The list of childs in this <see cref="MeshAsset"/>.
        /// </summary>
        [Index(1)]
        public virtual List<MeshAssetData> Childs { get; protected set; }

        /// <summary>
        /// The type of data handled by this asset.
        /// </summary>
        [IgnoreFormat]
        public AssetTypes Type => AssetTypes.Mesh;

        /// <summary>
        /// Gets the merged <see cref="MeshAssetData"/>.
        /// </summary>
        [IgnoreFormat]
        public MeshAssetData Merged
        {
            get
            {
                MeshAssetData result = new MeshAssetData(Source);
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
            _loadedTextures = new List<string>();

            Childs = new List<MeshAssetData>();

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
        private void AddChild(MeshAssetData child)
        {
            child.SetParent(this);
            Childs.Add(child);
        }

        private static MeshAsset ComputeAssetChildrens(ref Scene scene, ref MeshAsset element, Node node)
        {
            var tempAsset = new MeshAssetData(node.Name);

            if (node.HasMeshes)
            {
                for (int i = 0; i < node.MeshCount; i++)
                {
                    // Initialize assets
                    Assimp.Mesh mesh = scene.Meshes[node.MeshIndices[i]];
                    Assimp.Material material = scene.Materials[mesh.MaterialIndex];

                    Assimp.Vector3D Zero3D = new Assimp.Vector3D(0f);

                    if (mesh.PrimitiveType == Assimp.PrimitiveType.Triangle)
                    {
                        // Populate the vertex attribute vectors
                        for (int j = 0; j < mesh.VertexCount; j++)
                        {
                            Vector3f pos = (Vector3f)(mesh.HasVertices ? mesh.Vertices[j] : Zero3D);
                            Vector3f normal = (Vector3f)(mesh.HasNormals ? mesh.Normals[j] : Zero3D);
                            Vector3f uv = (Vector3f)(mesh.HasTextureCoords(0) ? mesh.TextureCoordinateChannels[0][j] : Zero3D);
                            Vector3f tn = (Vector3f)(mesh.HasTangentBasis ? mesh.Tangents[j] : Zero3D);
                            Vector3f btn = (Vector3f)(mesh.HasTangentBasis ? mesh.BiTangents[j] : Zero3D);

                            tempAsset.Vertices.Add(new Vertex(pos, new Vector2f(uv), normal, tn, btn));
                        }

                        // Populate the index buffer
                        for (int j = 0; j < mesh.FaceCount; j++)
                        {
                            Assimp.Face face = mesh.Faces[j];
                            // TODO: Find a suitable way to draw vertices...
                            // Now only support triangulated faces
                            tempAsset.Indices.Add(face.Indices[0]);
                            tempAsset.Indices.Add(face.Indices[1]);
                            tempAsset.Indices.Add(face.Indices[2]);
                        }
                        
                        _initMaterials(material);
                    }
                }
            }

            if (node.HasChildren)
                for (int i = 0; i < node.ChildCount; i++)
                    if (node.Children[i].HasMeshes) ComputeAssetChildrens(ref scene, ref element, node.Children[i]);

            element?.AddChild(tempAsset);

            return element;
        }

        private static void _initMaterials(Assimp.Material material)
        {
            var materialData = new MaterialAssetData();

            if (material.HasBlendMode)
            {
                materialData.HasBlendMode = true;
                materialData.BlendMode = (MaterialBlendMode)material.BlendMode;
            }

            if (material.HasBumpScaling)
            {
                materialData.HasBumpScaling = true;
                materialData.BumpScaling = material.BumpScaling;
            }

            if (material.HasColorAmbient)
            {
                materialData.HasColorAmbient = true;
                materialData.ColorAmbient = new Color4(material.ColorAmbient.R, material.ColorAmbient.G, material.ColorAmbient.B, material.ColorAmbient.A);
            }

            if (material.HasColorDiffuse)
            {
                materialData.HasColorDiffuse = true;
                materialData.ColorDiffuse = new Color4(material.ColorDiffuse.R, material.ColorDiffuse.G, material.ColorDiffuse.B, material.ColorDiffuse.A);
            }

            if (material.HasColorEmissive)
            {
                materialData.HasColorEmissive = true;
                materialData.ColorEmissive = new Color4(material.ColorEmissive.R, material.ColorEmissive.G, material.ColorEmissive.B, material.ColorEmissive.A);
            }

            if (material.HasColorReflective)
            {
                materialData.HasColorReflective = true;
                materialData.ColorReflective = new Color4(material.ColorReflective.R, material.ColorReflective.G, material.ColorReflective.B, material.ColorReflective.A);
            }

            if (material.HasColorSpecular)
            {
                materialData.HasColorSpecular = true;
                materialData.ColorSpecular = new Color4(material.ColorSpecular.R, material.ColorSpecular.G, material.ColorSpecular.B, material.ColorSpecular.A);
            }

            if (material.HasColorTransparent)
            {
                materialData.HasColorTransparent = true;
                materialData.ColorTransparent = new Color4(material.ColorTransparent.R, material.ColorTransparent.G, material.ColorTransparent.B, material.ColorTransparent.A);
            }

            if (material.HasTextureAmbient)
            {
                materialData.HasTextureAmbient = true;
                if (!_loadedTextures.Contains(material.TextureAmbient.FilePath))
                {
                    TextureAsset.From(material.TextureAmbient.FilePath).Serialize(material.TextureAmbient.FilePath, false);
                    materialData.TextureAmbient = material.TextureAmbient.FilePath;
                    _loadedTextures.Add(material.TextureAmbient.FilePath);
                }
                else
                {
                    materialData.TextureAmbient = material.TextureAmbient.FilePath;
                }
            }

            if (material.HasTextureDiffuse)
            {
                materialData.HasTextureDiffuse = true;
                if (!_loadedTextures.Contains(material.TextureDiffuse.FilePath))
                {
                    TextureAsset.From(material.TextureDiffuse.FilePath).Serialize(material.TextureDiffuse.FilePath, false);
                    materialData.TextureDiffuse = material.TextureDiffuse.FilePath;
                    _loadedTextures.Add(material.TextureDiffuse.FilePath);
                }
                else
                {
                    materialData.TextureDiffuse = material.TextureDiffuse.FilePath;
                }
            }

            if (material.HasTextureDisplacement)
            {
                materialData.HasTextureDisplacement = true;
                if (!_loadedTextures.Contains(material.TextureDisplacement.FilePath))
                {
                    TextureAsset.From(material.TextureDisplacement.FilePath).Serialize(material.TextureDisplacement.FilePath, false);
                    materialData.TextureDisplacement = material.TextureDisplacement.FilePath;
                    _loadedTextures.Add(material.TextureDisplacement.FilePath);
                }
                else
                {
                    materialData.TextureDisplacement = material.TextureDisplacement.FilePath;
                }
            }

            if (material.HasTextureEmissive)
            {
                materialData.HasTextureEmissive = true;
                if (!_loadedTextures.Contains(material.TextureEmissive.FilePath))
                {
                    TextureAsset.From(material.TextureEmissive.FilePath).Serialize(material.TextureEmissive.FilePath, false);
                    materialData.TextureEmissive = material.TextureEmissive.FilePath;
                    _loadedTextures.Add(material.TextureEmissive.FilePath);
                }
                else
                {
                    materialData.TextureEmissive = material.TextureEmissive.FilePath;
                }
            }

            if (material.HasTextureHeight)
            {
                materialData.HasTextureHeight = true;
                if (!_loadedTextures.Contains(material.TextureHeight.FilePath))
                {
                    TextureAsset.From(material.TextureHeight.FilePath).Serialize(material.TextureHeight.FilePath, false);
                    materialData.TextureEmissive = material.TextureHeight.FilePath;
                    _loadedTextures.Add(material.TextureHeight.FilePath);
                }
                else
                {
                    materialData.TextureHeight = material.TextureHeight.FilePath;
                }
            }

            if (material.HasTextureLightMap)
            {
                materialData.HasTextureLightMap = true;
                if (!_loadedTextures.Contains(material.TextureLightMap.FilePath))
                {
                    TextureAsset.From(material.TextureLightMap.FilePath).Serialize(material.TextureLightMap.FilePath, false);
                    materialData.TextureLightMap = material.TextureLightMap.FilePath;
                    _loadedTextures.Add(material.TextureLightMap.FilePath);
                }
                else
                {
                    materialData.TextureLightMap = material.TextureLightMap.FilePath;
                }
            }

            if (material.HasTextureNormal)
            {
                materialData.HasTextureNormal = true;
                if (!_loadedTextures.Contains(material.TextureNormal.FilePath))
                {
                    TextureAsset.From(material.TextureNormal.FilePath).Serialize(material.TextureNormal.FilePath, false);
                    materialData.TextureNormal = material.TextureNormal.FilePath;
                    _loadedTextures.Add(material.TextureNormal.FilePath);
                }
                else
                {
                    materialData.TextureNormal = material.TextureNormal.FilePath;
                }
            }

            if (material.HasTextureOpacity)
            {
                materialData.HasTextureOpacity = true;
                if (!_loadedTextures.Contains(material.TextureOpacity.FilePath))
                {
                    TextureAsset.From(material.TextureOpacity.FilePath).Serialize(material.TextureOpacity.FilePath, false);
                    materialData.TextureOpacity = material.TextureOpacity.FilePath;
                    _loadedTextures.Add(material.TextureOpacity.FilePath);
                }
                else
                {
                    materialData.TextureOpacity = material.TextureOpacity.FilePath;
                }
            }

            if (material.HasTextureReflection)
            {
                materialData.HasTextureReflection = true;
                if (!_loadedTextures.Contains(material.TextureReflection.FilePath))
                {
                    TextureAsset.From(material.TextureReflection.FilePath).Serialize(material.TextureReflection.FilePath, false);
                    materialData.TextureReflection = material.TextureReflection.FilePath;
                    _loadedTextures.Add(material.TextureReflection.FilePath);
                }
                else
                {
                    materialData.TextureReflection = material.TextureReflection.FilePath;
                }
            }

            if (material.HasTextureSpecular)
            {
                materialData.HasTextureSpecular = true;
                if (!_loadedTextures.Contains(material.TextureSpecular.FilePath))
                {
                    TextureAsset.From(material.TextureSpecular.FilePath).Serialize(material.TextureSpecular.FilePath, false);
                    materialData.TextureSpecular = material.TextureSpecular.FilePath;
                    _loadedTextures.Add(material.TextureSpecular.FilePath);
                }
                else
                {
                    materialData.TextureSpecular = material.TextureSpecular.FilePath;
                }
            }

            if (material.HasName)
            {
                materialData.HasName = true;
                materialData.Name = material.Name;
            }

            if (material.HasOpacity)
            {
                materialData.HasOpacity = true;
                materialData.Opacity = material.Opacity;
            }

            if (material.HasReflectivity)
            {
                materialData.HasReflectivity = true;
                materialData.Reflectivity = material.Reflectivity;
            }

            if (material.HasShadingMode)
            {
                materialData.HasShadingMode = true;
                materialData.ShadingMode = (MaterialShadingMode)material.ShadingMode;
            }

            if (material.HasShininess)
            {
                materialData.HasShininess = true;
                materialData.Shininess = material.Shininess;
            }

            if (material.HasShininessStrength)
            {
                materialData.HasShininessStrength = true;
                materialData.ShininessStrength = material.ShininessStrength;
            }

            if (material.HasTwoSided)
            {
                materialData.HasTwoSided = true;
                materialData.IsTwoSided = material.IsTwoSided;
            }

            if (material.HasWireFrame)
            {
                materialData.HasWireFrame = true;
                materialData.IsWireFrameEnabled = material.IsWireFrameEnabled;
            }

            materialData.PropertyCount = material.PropertyCount;

            materialData.ShaderAssetData = new ShaderAssetData()
            {
                VertexShader = new ASLShaderCompiler(new DiffuseVertexShader()).Shader,
                FragmentShader = new ASLShaderCompiler(new DiffuseFragmentShader()).Shader
            };
        }

        /// <summary>
        /// Checks if a file is a serialized <see cref="MeshAsset"/>.
        /// </summary>
        /// <param name="meshFile">The file to check.</param>
        /// <param name="asset">The result of the deserialization.</param>
        public static bool IsAsset(string meshFile, out IAsset asset)
        {
            asset = ZeroFormatterSerializer.Deserialize<IAsset>(File.ReadAllBytes(meshFile));
            return asset.Type == AssetTypes.Mesh;
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
            if (meshFile.EndsWith($".{Ext}") && IsAsset(meshFile, out IAsset file))
                return file as MeshAsset;

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
                Console.WriteLine($"Error parsing {meshFile}: {e.Message}");
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
                throw new Exception($"The file at \"{filePath}\" already exists.");
            }
        }

        public IResource ToResource()
        {
            throw new NotImplementedException();
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
