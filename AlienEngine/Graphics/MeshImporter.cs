﻿using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;
using Assimp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Graphics
{
    public class MeshImporter : IDisposable
    {
        private const uint INDEX_BUFFER = 0;
        private const uint POS_VB = 1;
        private const uint NORMAL_VB = 2;
        private const uint TEXCOORD_VB = 3;
        private const uint WVP_MAT_VB = 4;
        private const uint WORLD_MAT_VB = 5;

        public GameElement GameElement { get { return _gameMesh; } }

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
        private uint[] _buffers;

        public MeshImporter(string file)
        {
            _filename = file;

            AssimpContext importer = new AssimpContext();

            try
            {
                Scene scene = importer.ImportFile(file, PostProcessSteps.Triangulate | PostProcessSteps.SortByPrimitiveType);
                _initFromScene(scene);
                _meshes = new Mesh[_entries.Length];

                _vao = 0;
                _buffers = new uint[6];

                // Create the VAO
                _vao = GL.GenVertexArray();
                GL.BindVertexArray(_vao);

                // Create the buffers for the vertices attributes
                GL.GenBuffers(_buffers.Length, _buffers);

                var posArray = positions.ToArray();
                var uvArray = uvs.ToArray();
                var normArray = normals.ToArray();
                var indArray = indices.ToArray();

                // Generate and populate the buffers with vertex attributes and the indices
                GL.BindBuffer(BufferTarget.ArrayBuffer, _buffers[POS_VB]);
                GL.BufferData(BufferTarget.ArrayBuffer, Marshal.SizeOf(posArray[0]) * posArray.Length, posArray, BufferUsageHint.StaticDraw);
                GL.EnableVertexAttribArray(GL.POSITION_LOCATION);
                GL.VertexAttribPointer(GL.POSITION_LOCATION, 3, VertexAttribPointerType.Float, false, 0, 0);

                GL.BindBuffer(BufferTarget.ArrayBuffer, _buffers[TEXCOORD_VB]);
                GL.BufferData(BufferTarget.ArrayBuffer, Marshal.SizeOf(uvArray[0]) * uvArray.Length, uvArray, BufferUsageHint.StaticDraw);
                GL.EnableVertexAttribArray(GL.UV_LOCATION);
                GL.VertexAttribPointer(GL.UV_LOCATION, 2, VertexAttribPointerType.Float, false, 0, 0);

                GL.BindBuffer(BufferTarget.ArrayBuffer, _buffers[NORMAL_VB]);
                GL.BufferData(BufferTarget.ArrayBuffer, Marshal.SizeOf(normArray[0]) * normArray.Length, normArray, BufferUsageHint.StaticDraw);
                GL.EnableVertexAttribArray(GL.NORMAL_LOCATION);
                GL.VertexAttribPointer(GL.NORMAL_LOCATION, 3, VertexAttribPointerType.Float, false, 0, 0);

                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _buffers[INDEX_BUFFER]);
                GL.BufferData(BufferTarget.ElementArrayBuffer, Marshal.SizeOf(indArray[0]) * indArray.Length, indArray, BufferUsageHint.StaticRead);

                // Make sure the VAO is not changed from the outside
                GL.BindVertexArray(0);

                for (int i = 0; i < _meshes.Length; i++)
                    _meshes[i] = new Mesh(_vao, _entries[i]);

                _gameMesh = _appendGameElement(null, scene.RootNode);

                ResourcesManager.AddOnDisposeEvent(() =>
                {
                    if (_vao != 0)
                        GL.DeleteVertexArrays(1, new uint[] { _vao });

                    if (_buffers != null)
                        GL.DeleteBuffers(_buffers.Length, _buffers);
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
            _tempGameMesh.LocalTransform.Position = meshTrasform.Position;
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
                    Assimp.Vector3D pos = mesh.Vertices[i];
                    Assimp.Vector3D normal = mesh.Normals[i];
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
                    _materials[i].BlendMode = (Material.MaterialBlendMode)material.BlendMode;
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
                    _materials[i].TextureAmbient = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureAmbient));
                }

                if (material.HasTextureDiffuse)
                {
                    _materials[i].HasTextureDiffuse = true;
                    _materials[i].TextureDiffuse = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureDiffuse));
                }

                if (material.HasTextureDisplacement)
                {
                    _materials[i].HasTextureDisplacement = true;
                    _materials[i].TextureDisplacement = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureDisplacement));
                }

                if (material.HasTextureEmissive)
                {
                    _materials[i].HasTextureEmissive = true;
                    _materials[i].TextureEmissive = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureEmissive));
                }

                if (material.HasTextureHeight)
                {
                    _materials[i].HasTextureHeight = true;
                    _materials[i].TextureHeight = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureHeight));
                }

                if (material.HasTextureLightMap)
                {
                    _materials[i].HasTextureLightMap = true;
                    _materials[i].TextureLightMap = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureLightMap));
                }

                if (material.HasTextureNormal)
                {
                    _materials[i].HasTextureNormal = true;
                    _materials[i].TextureNormal = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureNormal));
                }

                if (material.HasTextureOpacity)
                {
                    _materials[i].HasTextureOpacity = true;
                    _materials[i].TextureOpacity = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureOpacity));
                }

                if (material.HasTextureReflection)
                {
                    _materials[i].HasTextureReflection = true;
                    _materials[i].TextureReflection = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureReflection));
                }

                if (material.HasTextureSpecular)
                {
                    _materials[i].HasTextureSpecular = true;
                    _materials[i].TextureSpecular = new Texture(Core.Graphics.OpenGL.TextureTarget.Texture2D, _getTextureFullPath(material.TextureSpecular));
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
                    _materials[i].ShadingMode = (Material.MaterialShadingMode)material.ShadingMode;
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

                _materials[i].Program = new AlienEngine.Shaders.DiffuseShaderProgram();
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
                    positions = null;
                    uvs = null;
                    indices = null;
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