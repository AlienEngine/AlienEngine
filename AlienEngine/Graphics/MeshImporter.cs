using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using AlienEngine.Imaging;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<int> indices;

        private string _filename;

        private GameElement _gameMesh;

        private uint _vao;

        private Dictionary<string, Texture> _loadedTextures;

        public MeshImporter(string file)
        {
            _loadedTextures = new Dictionary<string, Texture>();

            _filename = file;

            AssimpContext importer = new AssimpContext();

            try
            {
                Scene scene = importer.ImportFile(file, PostProcessSteps.Triangulate | PostProcessSteps.SortByPrimitiveType | PostProcessSteps.GenerateSmoothNormals);
                _initFromScene(scene);
                _meshes = new Mesh[_entries.Length];

                _vao = 0;

                // Create the VAO
                _vao = GL.GenVertexArray();
                GL.BindVertexArray(_vao);

                // Generate and populate the buffers with vertex attributes and the indices
                VBO<Vector3f> vertex = new VBO<Vector3f>(positions.ToArray());
                VBO<Vector2f> texture = new VBO<Vector2f>(uvs.ToArray());
                VBO<Vector3f> normal = new VBO<Vector3f>(normals.ToArray());
                VBO<int> index = new VBO<int>(indices.ToArray(), BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead);

                GL.BindBuffer(vertex.BufferTarget, vertex.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_POSITION_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_POSITION_LOCATION, vertex.Size, vertex.PointerType, false, 0, 0);

                GL.BindBuffer(texture.BufferTarget, texture.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_TEXTURE_COORD_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_TEXTURE_COORD_LOCATION, texture.Size, texture.PointerType, false, 0, 0);

                GL.BindBuffer(normal.BufferTarget, normal.ID);
                GL.EnableVertexAttribArray(GL.VERTEX_NORMAL_LOCATION);
                GL.VertexAttribPointer(GL.VERTEX_NORMAL_LOCATION, normal.Size, normal.PointerType, false, 0, 0);

                GL.BindBuffer(index.BufferTarget, index.ID);

                // Make sure the VAO is not changed from the outside
                GL.BindVertexArray(0);

                for (int i = 0; i < _meshes.Length; i++)
                    _meshes[i] = new Mesh(_vao, _entries[i]);

                _gameMesh = _appendGameElement(null, scene.RootNode);

                ResourcesManager.AddOnDisposeEvent(() =>
                {
                    if (_vao != 0)
                        GL.DeleteVertexArray(_vao);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error parsing {0}: {1}", file, e.Message));
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
                    Assimp.Vector3D pos = mesh.HasVertices ? mesh.Vertices[i] : Zero3D;
                    Assimp.Vector3D normal = mesh.HasNormals ? mesh.Normals[i] : Zero3D;
                    Assimp.Vector3D uv = mesh.HasTextureCoords(0) ? mesh.TextureCoordinateChannels[0][i] : Zero3D;

                    positions.Add(new Vector3f(pos.X, pos.Y, pos.Z));
                    normals.Add(new Vector3f(normal.X, normal.Y, normal.Z));
                    uvs.Add(new Vector2f(uv.X, uv.Y));
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
                    if (!_loadedTextures.ContainsKey(material.TextureAmbient.FilePath))
                    {
                        _materials[i].TextureAmbient = new Texture(_getTextureFullPath(material.TextureAmbient), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureAmbient.FilePath, _materials[i].TextureAmbient);
                    }
                    else
                    {
                        _materials[i].TextureAmbient = _loadedTextures[material.TextureAmbient.FilePath];
                    }
                }

                if (material.HasTextureDiffuse)
                {
                    _materials[i].HasTextureDiffuse= true;
                    if (!_loadedTextures.ContainsKey(material.TextureDiffuse.FilePath))
                    {
                        _materials[i].TextureAmbient = new Texture(_getTextureFullPath(material.TextureDiffuse), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureDiffuse.FilePath, _materials[i].TextureDiffuse);
                    }
                    else
                    {
                        _materials[i].TextureDiffuse = _loadedTextures[material.TextureDiffuse.FilePath];
                    }
                }

                if (material.HasTextureDisplacement)
                {
                    _materials[i].HasTextureDisplacement = true;
                    if (!_loadedTextures.ContainsKey(material.TextureDisplacement.FilePath))
                    {
                        _materials[i].TextureDisplacement = new Texture(_getTextureFullPath(material.TextureDisplacement), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureDisplacement.FilePath, _materials[i].TextureDisplacement);
                    }
                    else
                    {
                        _materials[i].TextureDisplacement = _loadedTextures[material.TextureDisplacement.FilePath];
                    }
                }

                if (material.HasTextureEmissive)
                {
                    _materials[i].HasTextureEmissive = true;
                    if (!_loadedTextures.ContainsKey(material.TextureEmissive.FilePath))
                    {
                        _materials[i].TextureEmissive = new Texture(_getTextureFullPath(material.TextureEmissive), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureEmissive.FilePath, _materials[i].TextureEmissive);
                    }
                    else
                    {
                        _materials[i].TextureEmissive = _loadedTextures[material.TextureEmissive.FilePath];
                    }
                }

                if (material.HasTextureHeight)
                {
                    _materials[i].HasTextureHeight = true;
                    if (!_loadedTextures.ContainsKey(material.TextureHeight.FilePath))
                    {
                        _materials[i].TextureHeight = new Texture(_getTextureFullPath(material.TextureHeight), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureHeight.FilePath, _materials[i].TextureHeight);
                    }
                    else
                    {
                        _materials[i].TextureHeight = _loadedTextures[material.TextureHeight.FilePath];
                    }
                }

                if (material.HasTextureLightMap)
                {
                    _materials[i].HasTextureLightMap = true;
                    if (!_loadedTextures.ContainsKey(material.TextureLightMap.FilePath))
                    {
                        _materials[i].TextureLightMap = new Texture(_getTextureFullPath(material.TextureLightMap), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureLightMap.FilePath, _materials[i].TextureLightMap);
                    }
                    else
                    {
                        _materials[i].TextureLightMap = _loadedTextures[material.TextureLightMap.FilePath];
                    }
                }

                if (material.HasTextureNormal)
                {
                    _materials[i].HasTextureNormal = true;
                    if (!_loadedTextures.ContainsKey(material.TextureNormal.FilePath))
                    {
                        _materials[i].TextureNormal = new Texture(_getTextureFullPath(material.TextureNormal), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureNormal.FilePath, _materials[i].TextureNormal);
                    }
                    else
                    {
                        _materials[i].TextureNormal = _loadedTextures[material.TextureNormal.FilePath];
                    }
                }

                if (material.HasTextureOpacity)
                {
                    _materials[i].HasTextureOpacity = true;
                    if (!_loadedTextures.ContainsKey(material.TextureOpacity.FilePath))
                    {
                        _materials[i].TextureOpacity = new Texture(_getTextureFullPath(material.TextureOpacity), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureOpacity.FilePath, _materials[i].TextureOpacity);
                    }
                    else
                    {
                        _materials[i].TextureOpacity = _loadedTextures[material.TextureOpacity.FilePath];
                    }
                }

                if (material.HasTextureReflection)
                {
                    _materials[i].HasTextureReflection = true;
                    if (!_loadedTextures.ContainsKey(material.TextureReflection.FilePath))
                    {
                        _materials[i].TextureReflection = new Texture(_getTextureFullPath(material.TextureReflection), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureReflection.FilePath, _materials[i].TextureReflection);
                    }
                    else
                    {
                        _materials[i].TextureReflection = _loadedTextures[material.TextureReflection.FilePath];
                    }
                }

                if (material.HasTextureSpecular)
                {
                    _materials[i].HasTextureSpecular = true;
                    if (!_loadedTextures.ContainsKey(material.TextureSpecular.FilePath))
                    {
                        _materials[i].TextureSpecular = new Texture(_getTextureFullPath(material.TextureSpecular), Core.Graphics.OpenGL.TextureTarget.Texture2D);
                        _loadedTextures.Add(material.TextureSpecular.FilePath, _materials[i].TextureSpecular);
                    }
                    else
                    {
                        _materials[i].TextureSpecular = _loadedTextures[material.TextureSpecular.FilePath];
                    }
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
                    positions.Clear();
                    positions = null;

                    uvs.Clear();
                    uvs = null;

                    indices.Clear();
                    indices = null;

                    normals.Clear();
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
