using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using AlienEngine.Imaging;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
using AlienEngine.Core.Graphics.Buffers;
using AlienEngine.Core.Rendering;

namespace AlienEngine.Core.Graphics
{
    public class MeshImporter : IDisposable
    {
        public GameElement GameElement => _gameMesh;

        private Material[] _materials;
        private MeshEntry[] _entries;
        private MeshTransformation[] _transforms;
        private Mesh[] _meshes;

        List<Vector3f> positions;
        List<Vector3f> normals;
        List<Vector2f> uvs;
        List<Vector3f> tangents;
        List<Vector3f> bitangents;
        List<int> indices;

        private string _filename;

        private GameElement _gameMesh;

        public MeshImporter(string file)
        {
            _filename = file;

            AssimpContext importer = new AssimpContext();

            try
            {
                Scene scene = importer.ImportFile(file, PostProcessSteps.Triangulate | PostProcessSteps.SortByPrimitiveType | PostProcessSteps.GenerateSmoothNormals | PostProcessSteps.CalculateTangentSpace);
                _initFromScene(scene);
                _meshes = new Mesh[_entries.Length];

                for (int i = 0, l = indices.Count; i < l; i += 3)
                {
                    Vector3f e1 = positions[indices[i + 1]] - positions[indices[i]];
                    Vector3f e2 = positions[indices[i + 2]] - positions[indices[i]];

                    Vector2f u1 = uvs[indices[i + 1]] - uvs[indices[i]];
                    Vector2f u2 = uvs[indices[i + 2]] - uvs[indices[i]];

                    float f = 1.0f / (u1.X * u2.Y - u2.X * u1.Y);

                    var t = new Vector3f()
                    {
                        X = f * (u2.Y * e1.X - u1.Y * e2.X),
                        Y = f * (u2.Y * e1.Y - u1.Y * e2.Y),
                        Z = f * (u2.Y * e1.Z - u1.Y * e2.Z)
                    };

                    tangents.Add(Vector3f.Normalize(t));
                    tangents.Add(Vector3f.Normalize(t));
                    tangents.Add(Vector3f.Normalize(t));

                    var b = new Vector3f()
                    {
                        X = f * (-u2.X * e1.X + u1.X * e2.X),
                        Y = f * (-u2.X * e1.Y + u1.X * e2.Y),
                        Z = f * (-u2.X * e1.Z + u1.X * e2.Z)
                    };

                    bitangents.Add(Vector3f.Normalize(b));
                    bitangents.Add(Vector3f.Normalize(b));
                    bitangents.Add(Vector3f.Normalize(b));
                }

                // Generate and populate the buffers with vertex attributes and the indices
                VBO<Vector3f> vertex = new VBO<Vector3f>(positions.ToArray());
                VBO<Vector2f> texture = new VBO<Vector2f>(uvs.ToArray());
                VBO<Vector3f> normal = new VBO<Vector3f>(normals.ToArray());
                VBO<Vector3f> tangent = new VBO<Vector3f>(tangents.ToArray());
                VBO<Vector3f> bitangent = new VBO<Vector3f>(bitangents.ToArray());
                VBO<int> index = new VBO<int>(indices.ToArray(), BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

                // Create the VAO
                VAO vao = new VAO(vertex, normal, tangent, bitangent, texture, index);

                for (int i = 0; i < _meshes.Length; i++)
                    _meshes[i] = new Mesh(vao, _entries[i]);

                _gameMesh = _appendGameElement(null, scene.RootNode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error parsing {file}: {e.Message}");
            }
        }

        private GameElement _appendGameElement(GameElement element, Node node)
        {
            var _tempGameMesh = new GameElement(node.Name);

            var meshTrasform = new MeshTransformation(node.Transform);
            _tempGameMesh.LocalTransform.Translation = meshTrasform.Position;
            _tempGameMesh.LocalTransform.Rotation = meshTrasform.Rotation;
            _tempGameMesh.LocalTransform.Scale = meshTrasform.Scale;

            if (node.HasMeshes)
            {
                if (node.MeshCount == 1)
                {
                    _tempGameMesh.AttachComponent(_materials[node.MeshIndices[0]]);
                    _tempGameMesh.AttachComponent(new MeshRenderer(_meshes[node.MeshIndices[0]]));
                }
                else
                {
                    for (int i = 0; i < node.MeshCount; i++)
                    {
                        var _subMesh = new GameElement(node.Name);
                        _subMesh.AttachComponent(_materials[node.MeshIndices[i]]);
                        _subMesh.AttachComponent(new MeshRenderer(_meshes[node.MeshIndices[i]]));
                        _tempGameMesh.AddChild(_subMesh);
                    }
                }
            }

            if (node.HasChildren)
                for (int i = 0; i < node.ChildCount; i++)
                    _appendGameElement(_tempGameMesh, node.Children[i]);

            if (element != null)
                element.AddChild(_tempGameMesh);

            return _tempGameMesh;
        }

        private void _initFromScene(Scene scene)
        {
            _entries = new MeshEntry[scene.MeshCount];
            _transforms = new MeshTransformation[scene.MeshCount];
            _materials = new Material[scene.MeshCount];

            positions = new List<Vector3f>();
            normals = new List<Vector3f>();
            tangents = new List<Vector3f>();
            bitangents = new List<Vector3f>();
            uvs = new List<Vector2f>();
            indices = new List<int>();

            int numVertices = 0;
            int numIndices = 0;

            // Count the number of vertices and indices
            for (int i = 0; i < _entries.Length; i++)
            {
                _entries[i].MaterialIndex = scene.Meshes[i].MaterialIndex;
                _entries[i].NumIndices = scene.Meshes[i].FaceCount * 3;
                _entries[i].BaseVertex = numVertices;
                _entries[i].BaseIndex = numIndices;
                _entries[i].Name = scene.Meshes[i].Name;

                numVertices += scene.Meshes[i].VertexCount;
                numIndices += _entries[i].NumIndices;
            }

            // Reserve space in the vectors for the vertex attributes and indices
            positions.Capacity = numVertices;
            normals.Capacity = numVertices;
            tangents.Capacity = numVertices;
            bitangents.Capacity = numVertices;
            uvs.Capacity = numVertices;
            indices.Capacity = numIndices;

            // Initialize the meshes in the scene one by one
            for (int i = 0; i < _entries.Length; i++)
            {
                Assimp.Mesh mesh = scene.Meshes[i];
                _initMesh(mesh);
            }

            _initMaterials(scene);
        }

        private void _initMesh(Assimp.Mesh mesh)
        {
            Assimp.Vector3D Zero3D = new Assimp.Vector3D(0f);

            if (mesh.PrimitiveType == Assimp.PrimitiveType.Triangle)
            {
                // Populate the vertex attribute vectors
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Vector3f pos = (Vector3f)(mesh.HasVertices ? mesh.Vertices[i] : Zero3D);
                    Vector3f normal = (Vector3f)(mesh.HasNormals ? mesh.Normals[i] : Zero3D);
                    Vector3f uv = (Vector3f)(mesh.HasTextureCoords(0) ? mesh.TextureCoordinateChannels[0][i] : Zero3D);
                    //Vector3f tn = (Vector3f)(mesh.HasTangentBasis ? mesh.Tangents[i] : Zero3D);
                    //Vector3f btn = (Vector3f)(mesh.HasTangentBasis ? mesh.BiTangents[i] : Zero3D);

                    positions.Add(pos);
                    normals.Add(normal);
                    uvs.Add(new Vector2f(uv));
                    //tangents.Add(tn);
                    //bitangents.Add(btn);
                }

                // Populate the index buffer
                for (int i = 0; i < mesh.FaceCount; i++)
                {
                    Assimp.Face face = mesh.Faces[i];
                    // TODO: Find a suitable way to draw vertices...
                    // Now only support triangulated faces
                    indices.Add(face.Indices[0]);
                    indices.Add(face.Indices[1]);
                    indices.Add(face.Indices[2]);
                }
            }
        }

        private void _initMaterials(Scene scene)
        {
            // Initialize the matrials
            for (int i = 0; i < scene.MeshCount; i++)
            {
                Assimp.Material material = scene.Materials[scene.Meshes[i].MaterialIndex];

                _materials[i] = new Material();

                if (material.HasBlendMode)
                {
                    _materials[i].HasBlendMode = true;
                    _materials[i].BlendMode = (MaterialBlendMode)material.BlendMode;
                }

                if (material.HasBumpScaling)
                {
                    _materials[i].HasBumpScaling = true;
                    _materials[i].BumpScaling = material.BumpScaling;
                }

                if (material.HasColorAmbient)
                {
                    _materials[i].HasColorAmbient = true;
                    _materials[i].ColorAmbient = new Color4(material.ColorAmbient.R, material.ColorAmbient.G, material.ColorAmbient.B, material.ColorAmbient.A);
                }

                if (material.HasColorDiffuse)
                {
                    _materials[i].HasColorDiffuse = true;
                    _materials[i].ColorDiffuse = new Color4(material.ColorDiffuse.R, material.ColorDiffuse.G, material.ColorDiffuse.B, material.ColorDiffuse.A);
                }

                if (material.HasColorEmissive)
                {
                    _materials[i].HasColorEmissive = true;
                    _materials[i].ColorEmissive = new Color4(material.ColorEmissive.R, material.ColorEmissive.G, material.ColorEmissive.B, material.ColorEmissive.A);
                }

                if (material.HasColorReflective)
                {
                    _materials[i].HasColorReflective = true;
                    _materials[i].ColorReflective = new Color4(material.ColorReflective.R, material.ColorReflective.G, material.ColorReflective.B, material.ColorReflective.A);
                }

                if (material.HasColorSpecular)
                {
                    _materials[i].HasColorSpecular = true;
                    _materials[i].ColorSpecular = new Color4(material.ColorSpecular.R, material.ColorSpecular.G, material.ColorSpecular.B, material.ColorSpecular.A);
                }

                if (material.HasColorTransparent)
                {
                    _materials[i].HasColorTransparent = true;
                    _materials[i].ColorTransparent = new Color4(material.ColorTransparent.R, material.ColorTransparent.G, material.ColorTransparent.B, material.ColorTransparent.A);
                }

                if (material.HasTextureAmbient)
                {
                    _materials[i].HasTextureAmbient = true;
                    _materials[i].TextureAmbient = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureAmbient));
                }

                if (material.HasTextureDiffuse)
                {
                    _materials[i].HasTextureDiffuse= true;
                    _materials[i].TextureDiffuse = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureDiffuse));
                }

                if (material.HasTextureDisplacement)
                {
                    _materials[i].HasTextureDisplacement = true;
                    _materials[i].TextureDisplacement = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureDisplacement));
                }

                if (material.HasTextureEmissive)
                {
                    _materials[i].HasTextureEmissive = true;
                    _materials[i].TextureEmissive = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureEmissive));
                }

                if (material.HasTextureHeight)
                {
                    _materials[i].HasTextureHeight = true;
                    _materials[i].TextureHeight = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureHeight));
                }

                if (material.HasTextureLightMap)
                {
                    _materials[i].HasTextureLightMap = true;
                    _materials[i].TextureLightMap = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureLightMap));
                }

                if (material.HasTextureNormal)
                {
                    _materials[i].HasTextureNormal = true;
                    _materials[i].TextureNormal = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureNormal));
                }

                if (material.HasTextureOpacity)
                {
                    _materials[i].HasTextureOpacity = true;
                    _materials[i].TextureOpacity = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureOpacity));
                }

                if (material.HasTextureReflection)
                {
                    _materials[i].HasTextureReflection = true;
                    _materials[i].TextureReflection = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureReflection));
                }

                if (material.HasTextureSpecular)
                {
                    _materials[i].HasTextureSpecular = true;
                    _materials[i].TextureSpecular = ResourcesManager.LoadResource<Texture>(ResourceType.Texture, _getTextureFullPath(material.TextureSpecular));
                }

                if (material.HasName)
                {
                    _materials[i].HasName = true;
                    _materials[i].Name = material.Name;
                }

                if (material.HasOpacity)
                {
                    _materials[i].HasOpacity = true;
                    _materials[i].Opacity = material.Opacity;
                }

                if (material.HasReflectivity)
                {
                    _materials[i].HasReflectivity = true;
                    _materials[i].Reflectivity = material.Reflectivity;
                }

                if (material.HasShadingMode)
                {
                    _materials[i].HasShadingMode = true;
                    _materials[i].ShadingMode = (MaterialShadingMode)material.ShadingMode;
                }

                if (material.HasShininess)
                {
                    _materials[i].HasShininess = true;
                    _materials[i].Shininess = material.Shininess;
                }

                if (material.HasShininessStrength)
                {
                    _materials[i].HasShininessStrength = true;
                    _materials[i].ShininessStrength = material.ShininessStrength;
                }

                if (material.HasTwoSided)
                {
                    _materials[i].HasTwoSided = true;
                    _materials[i].IsTwoSided = material.IsTwoSided;
                }

                if (material.HasWireFrame)
                {
                    _materials[i].HasWireFrame = true;
                    _materials[i].IsWireFrameEnabled = material.IsWireFrameEnabled;
                }

                _materials[i].PropertyCount = material.PropertyCount;

                _materials[i].ShaderProgram = new AlienEngine.Shaders.DiffuseShaderProgram();
            }
        }
    
        private string _getTextureFullPath(Assimp.TextureSlot texture)
        {
            string dir = Directory.GetParent(_filename).FullName;

            string p = texture.FilePath;
            if (p.Substring(0, 2) == ".\\")
            {
                p = p.Substring(2, p.Length - 2);
            }

            return dir + "/" + p;
        }

        #region Static Members
        public static GameElement Import(string filename)
        {
            var _importer = new MeshImporter(filename);
            GameElement _mesh = _importer.GameElement;
            _importer.Dispose();
            return _mesh;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    positions?.Clear();
                    positions = null;

                    uvs?.Clear();
                    uvs = null;

                    indices?.Clear();
                    indices = null;

                    normals?.Clear();
                    normals = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
