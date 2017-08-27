using System;
using System.Collections.Generic;
using System.IO;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Graphics.OpenGL;
using System.Threading;
using System.Globalization;
using AlienEngine.Core.Graphics;

namespace AlienEngine.Core.Graphics
{
    /// <summary>
    /// Helper class that performs simple math on some types of Geometry as
    /// well as helps generate some simple objects such as cubes and quads.
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        /// Calculate the array of vertex normals based on vertex and face information (assuming triangle polygons).
        /// </summary>
        /// <param name="vertexData">The vertex data to find the normals for.</param>
        /// <param name="elementData">The element array describing the order in which vertices are drawn.</param>
        /// <returns></returns>
        public static Vector3f[] CalculateNormals(Vector3f[] vertexData, int[] elementData)
        {
            Vector3f b1, b2, normal;
            Vector3f[] normalData = new Vector3f[vertexData.Length];

            for (int i = 0; i < elementData.Length / 3; i++)
            {
                int cornerA = elementData[i * 3];
                int cornerB = elementData[i * 3 + 1];
                int cornerC = elementData[i * 3 + 2];

                b1 = vertexData[cornerB] - vertexData[cornerA];
                b2 = vertexData[cornerC] - vertexData[cornerA];

                normal = Vector3f.Normalize(Vector3f.Cross(b1, b2));

                normalData[cornerA] += normal;
                normalData[cornerB] += normal;
                normalData[cornerC] += normal;
            }

            for (int i = 0; i < normalData.Length; i++) normalData[i] = Vector3f.Normalize(normalData[i]);

            return normalData;
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes UV co-ordinates from 0,0 to 1,1.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuad(ShaderProgram program, Vector2f location, Vector2f size)
        {
            Vector3f[] vertices = new Vector3f[] { new Vector3f(location.X, location.Y, 0), new Vector3f(location.X + size.X, location.Y, 0),
                new Vector3f(location.X + size.X, location.Y + size.Y, 0), new Vector3f(location.X, location.Y + size.Y, 0) };
            Vector2f[] uvs = new Vector2f[] { new Vector2f(0, 0), new Vector2f(1, 0), new Vector2f(1, 1), new Vector2f(0, 1) };
            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3f>(vertices), new VBO<Vector2f>(uvs), new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes UV co-ordinates from uvloc to uvloc+uvsize.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <param name="uvloc">The origin of the UV co-ordinates.</param>
        /// <param name="uvsize">The size of the UV co-ordinates.</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuad(ShaderProgram program, Vector2f location, Vector2f size, Vector2f uvloc, Vector2f uvsize)
        {
            Vector3f[] vertices = new Vector3f[] { new Vector3f(location.X, location.Y, 0), new Vector3f(location.X + size.X, location.Y, 0),
                new Vector3f(location.X + size.X, location.Y + size.Y, 0), new Vector3f(location.X, location.Y + size.Y, 0) };
            Vector2f[] uvs = new Vector2f[] { uvloc, new Vector2f(uvloc.X + uvsize.X, uvloc.Y), new Vector2f(uvloc.X + uvsize.X, uvloc.Y + uvsize.Y), new Vector2f(uvloc.X, uvloc.Y + uvsize.Y) };
            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            return new VAO(program, new VBO<Vector3f>(vertices), new VBO<Vector2f>(uvs), new VBO<int>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic quad by storing two triangles into a VAO.
        /// This quad includes normals, and does not include UV co-ordinates.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this quad.</param>
        /// <param name="location">The location of the VAO (assigned to the vertices).</param>
        /// <param name="size">The size of the VAO (assigned to the vertices).</param>
        /// <returns>The VAO object representing this quad.</returns>
        public static VAO CreateQuadWithNormals(ShaderProgram program, Vector2f location, Vector2f size)
        {
            Vector3f[] vertex = new Vector3f[] { new Vector3f(location.X, location.Y, 0), new Vector3f(location.X + size.X, location.Y, 0),
                new Vector3f(location.X + size.X, location.Y + size.Y, 0), new Vector3f(location.X, location.Y + size.Y, 0) };
            int[] element = new int[] { 0, 1, 2, 2, 3, 0 };
            Vector3f[] normal = CalculateNormals(vertex, element);

            return new VAO(program, new VBO<Vector3f>(vertex), new VBO<Vector3f>(normal), new VBO<int>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic cube and store into a VAO.
        /// This cube consists of 12 triangles and 6 faces.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this cube.</param>
        /// <param name="min">The 3 minimum values of the cube (lower left back corner).</param>
        /// <param name="max">The 3 maximum values of the cube (top right front corner).</param>
        /// <returns></returns>
        public static VAO CreateCube(ShaderProgram program, Vector3f min, Vector3f max)
        {
            Vector3f[] vertex = new Vector3f[] {
                new Vector3f(min.X, min.Y, max.Z),
                new Vector3f(max.X, min.Y, max.Z),
                new Vector3f(min.X, max.Y, max.Z),
                new Vector3f(max.X, max.Y, max.Z),
                new Vector3f(max.X, min.Y, min.Z),
                new Vector3f(max.X, max.Y, min.Z),
                new Vector3f(min.X, max.Y, min.Z),
                new Vector3f(min.X, min.Y, min.Z)
            };

            int[] element = new int[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            return new VAO(program, new VBO<Vector3f>(vertex), new VBO<int>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        /// <summary>
        /// Create a basic cube with normals and stores it in a VAO.
        /// This cube consists of 12 triangles and 6 faces.
        /// </summary>
        /// <param name="program">The ShaderProgram assigned to this cube.</param>
        /// <param name="min">The 3 minimum values of the cube (lower left back corner).</param>
        /// <param name="max">The 3 maximum values of the cube (top right front corner).</param>
        /// <returns></returns>
        public static VAO CreateCubeWithNormals(ShaderProgram program, Vector3f min, Vector3f max)
        {
            Vector3f[] vertex = new Vector3f[] {
                new Vector3f(min.X, min.Y, max.Z),
                new Vector3f(max.X, min.Y, max.Z),
                new Vector3f(min.X, max.Y, max.Z),
                new Vector3f(max.X, max.Y, max.Z),
                new Vector3f(max.X, min.Y, min.Z),
                new Vector3f(max.X, max.Y, min.Z),
                new Vector3f(min.X, max.Y, min.Z),
                new Vector3f(min.X, min.Y, min.Z)
            };

            int[] element = new int[] {
                0, 1, 2, 1, 3, 2,
                1, 4, 3, 4, 5, 3,
                4, 7, 5, 7, 6, 5,
                7, 0, 6, 0, 2, 6,
                7, 4, 0, 4, 1, 0,
                2, 3, 6, 3, 5, 6
            };

            Vector3f[] normal = CalculateNormals(vertex, element);

            return new VAO(program, new VBO<Vector3f>(vertex), new VBO<Vector3f>(normal), new VBO<int>(element, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }

        //public static Mesh LoadOBJ(StreamReader objFile)
        //{
        //    string line = string.Empty;

        //    List<Vertex> vertices = new List<Vertex>();
        //    List<int> indices = new List<int>();
        //    List<Vector2f> textures = new List<Vector2f>();
        //    List<Vector3f> normals = new List<Vector3f>();

        //    float[] normalsArray;
        //    float[] texturesArray;

        //    try
        //    {
        //        while (!objFile.EndOfStream)
        //        {
        //            line = objFile.ReadLine();
        //            if (line.Trim().Length == 0) continue;

        //            string[] currentLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //            if (line.StartsWith("#"))
        //                continue;
        //            else if (line.StartsWith("v "))
        //            {
        //                Vertex vertex = new Vertex(new Vector3f(float.Parse(currentLine[1]), float.Parse(currentLine[2]), float.Parse(currentLine[3])));
        //                vertices.Add(vertex);
        //            }
        //            else if (line.StartsWith("vt "))
        //            {
        //                Vector2f texture = new Vector2f(float.Parse(currentLine[1]), float.Parse(currentLine[2]));
        //                textures.Add(texture);
        //            }
        //            else if (line.StartsWith("vn "))
        //            {
        //                Vector3f normal = new Vector3f(float.Parse(currentLine[1]), float.Parse(currentLine[2]), float.Parse(currentLine[3]));
        //                normals.Add(normal);
        //            }
        //            else if (line.StartsWith("f "))
        //            {
        //                texturesArray = new float[vertices.Count * 2];
        //                normalsArray = new float[vertices.Count * 3];

        //                string[] vertex1 = currentLine[1].Split('/');
        //                string[] vertex2 = currentLine[2].Split('/');
        //                string[] vertex3 = currentLine[3].Split('/');

        //                _processVertex(ref vertex1, ref indices, ref textures, ref normals, ref texturesArray, ref normalsArray);
        //                _processVertex(ref vertex2, ref indices, ref textures, ref normals, ref texturesArray, ref normalsArray);
        //                _processVertex(ref vertex3, ref indices, ref textures, ref normals, ref texturesArray, ref normalsArray);
        //            }
        //        }

        //        objFile.Close();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    return new Mesh(vertices, indices, normals, textures);
        //}

        //public static Mesh LoadOBJ(string file)
        //{
        //    using (var sr = new StreamReader(file))
        //    {
        //        return LoadOBJ(sr);
        //    }
        //}

        //private static void _processVertex(ref string[] vertexData, ref List<int> indices, ref List<Vector2f> textures, ref List<Vector3f> normals, ref float[] textureArray, ref float[] normalsArray)
        //{
        //    int currentVertexPointer = int.Parse(vertexData[0]) - 1;
        //    indices.Add(currentVertexPointer);

        //    if (textures.Count > 0)
        //    {
        //        Vector2f currentTexture = textures[int.Parse(vertexData[1]) - 1];
        //        textureArray[currentVertexPointer * 2] = currentTexture.X;
        //        textureArray[currentVertexPointer * 2 + 1] = currentTexture.Y;
        //    }

        //    if (normals.Count > 0)
        //    {
        //        Vector3f currentNormal = normals[int.Parse(vertexData[2]) - 1];
        //        normalsArray[currentVertexPointer * 3] = currentNormal.X;
        //        normalsArray[currentVertexPointer * 3 + 1] = currentNormal.Y;
        //        normalsArray[currentVertexPointer * 3 + 2] = currentNormal.Z;
        //    }
        //}

        //public class ObjLoader : IDisposable
        //{
        //    private List<ObjObject> objects = new List<ObjObject>();
        //    private Dictionary<string, ObjMaterial> materials = new Dictionary<string, ObjMaterial>();

        //    public ShaderProgram defaultProgram;

        //    public ObjLoader(string filename, ShaderProgram program)
        //    {
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //        this.defaultProgram = program;

        //        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        //        ObjMaterial defaultMaterial = new ObjMaterial(program);

        //        using (StreamReader stream = new StreamReader(filename))
        //        {
        //            List<string> lines = new List<string>();
        //            List<string> objLines = new List<string>();
        //            int vertexOffset = 1, vertexCount = 0;
        //            int uvOffset = 1, uvCount = 0;

        //            // read the entire file
        //            while (!stream.EndOfStream)
        //            {
        //                string line = stream.ReadLine();
        //                if (line.Trim().Length == 0) continue;

        //                if ((line[0] == 'o' && lines.Count != 0) || (line[0] == 'g' && objLines.Count != 0))
        //                {
        //                    List<string> combinedLines = new List<string>(objLines);
        //                    combinedLines.AddRange(lines);

        //                    ObjObject newObject = new ObjObject(combinedLines, materials, vertexOffset, uvOffset);
        //                    if (newObject.VertexCount != 0) objects.Add(newObject);

        //                    if (newObject.Material == null) newObject.Material = defaultMaterial;

        //                    lines.Clear();
        //                    if (line[0] == 'o')
        //                    {
        //                        objLines.Clear();
        //                        vertexOffset += vertexCount;
        //                        uvOffset += uvCount;
        //                        vertexCount = 0;
        //                        uvCount = 0;
        //                    }
        //                }

        //                if (line[0] == 'v')
        //                {
        //                    if (line[1] == ' ') vertexCount++;
        //                    else uvCount++;

        //                    objLines.Add(line);
        //                }
        //                else if (line[0] != '#') lines.Add(line);

        //                // check if a material file is being used
        //                if (line[0] == 'm' && line[1] == 't') LoadMaterials(CreateFixedPath(filename, line.Split(' ')[1]));
        //            }

        //            // make sure we grab any remaining objects that occured before the EOF
        //            if (lines != null)
        //            {
        //                List<string> combinedLines = new List<string>(objLines);
        //                combinedLines.AddRange(lines);

        //                ObjObject newObject = new ObjObject(combinedLines, materials, vertexOffset, uvOffset);
        //                objects.Add(newObject);
        //            }
        //        }

        //        watch.StopSound();
        //        Console.WriteLine("Took {0}ms", watch.ElapsedMilliseconds);
        //    }

        //    private void LoadMaterials(string filename)
        //    {
        //        using (StreamReader stream = new StreamReader(filename))
        //        {
        //            List<string> lines = new List<string>();

        //            while (!stream.EndOfStream)
        //            {
        //                string line = stream.ReadLine();
        //                if (line.Trim().Length == 0) continue;

        //                if (line[0] == 'n' && lines.Count != 0)
        //                {
        //                    // if this is a new material ('newmtl name') then load it
        //                    ObjMaterial material = new ObjMaterial(lines, defaultProgram);
        //                    if (!materials.ContainsKey(material.Name)) materials.Add(material.Name, material);
        //                    lines.Clear();
        //                }

        //                if (line[0] == 'm')
        //                {
        //                    // try to fix up filenames of texture maps
        //                    string[] split = line.Split(' ');
        //                    lines.Add(string.Format("{0} {1}", split[0], CreateFixedPath(filename, split[1])));
        //                }
        //                else if (line[0] != '#') lines.Add(line);    // ignore comments
        //            }

        //            // If the obj has just one material would not execute the ObjMaterial function up, so I added (if the there are lines still not processed, process them)
        //            if (lines.Count != 0)
        //            {
        //                ObjMaterial materialEnd = new ObjMaterial(lines, defaultProgram);
        //                if (!materials.ContainsKey(materialEnd.Name)) materials.Add(materialEnd.Name, materialEnd);
        //                lines.Clear();
        //            }
        //        }
        //    }

        //    private string CreateFixedPath(string objectPath, string filename)
        //    {
        //        if (File.Exists(filename)) return filename;

        //        DirectoryInfo directory = new FileInfo(objectPath).Directory;

        //        var parts = filename.Split(new char[] { '\\', '/' });
        //        filename = directory.FullName + Path.DirectorySeparatorChar + parts[parts.Length - 1];

        //        return filename;
        //    }

        //    public void Draw()
        //    {
        //        List<ObjObject> transparentObjects = new List<ObjObject>();

        //        for (int i = 0; i < objects.Count; i++)
        //        {
        //            if (objects[i].Material.Transparency != 1f) transparentObjects.Add(objects[i]);
        //            else objects[i].Draw();
        //        }

        //        for (int i = 0; i < transparentObjects.Count; i++)
        //        {
        //            transparentObjects[i].Draw();
        //        }
        //    }

        //    public void Dispose()
        //    {
        //        for (int i = 0; i < objects.Count; i++) objects[i].Dispose();
        //    }
        //}

        //public class ObjMaterial : IDisposable
        //{
        //    public string Name { get; private set; }
        //    public Vector3f Ambient { get; private set; }
        //    public Vector3f Diffuse { get; private set; }
        //    public Vector3f Specular { get; private set; }
        //    public float SpecularCoefficient { get; private set; }
        //    public float Transparency { get; private set; }
        //    public IlluminationMode Illumination { get; private set; }

        //    public Texture DiffuseMap { get; private set; }
        //    public ShaderProgram Program { get; private set; }

        //    public enum IlluminationMode
        //    {
        //        ColorOnAmbientOff = 0,
        //        ColorOnAmbientOn = 1,
        //        HighlightOn = 2,
        //        ReflectionOnRaytraceOn = 3,
        //        TransparencyGlassOnReflectionRayTraceOn = 4,
        //        ReflectionFresnelOnRayTranceOn = 5,
        //        TransparencyRefractionOnReflectionFresnelOffRayTraceOn = 6,
        //        TransparencyRefractionOnReflectionFresnelOnRayTranceOn = 7,
        //        ReflectionOnRayTraceOff = 8,
        //        TransparencyGlassOnReflectionRayTraceOff = 9,
        //        CastsShadowsOntoInvisibleSurfaces = 10
        //    }

        //    public ObjMaterial(ShaderProgram program)
        //    {
        //        this.Name = "opengl-default-project";
        //        this.Transparency = 1f;
        //        this.Ambient = Vector3f.One;
        //        this.Diffuse = Vector3f.One;
        //        this.Program = program;
        //    }

        //    public ObjMaterial(List<string> lines, ShaderProgram program)
        //    {
        //        if (!lines[0].StartsWith("newmtl")) return;

        //        this.Name = lines[0].Substring(7);
        //        this.Transparency = 1f;

        //        for (int i = 1; i < lines.Count; i++)
        //        {
        //            string[] split = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //            // Some object exporters export the material with a tab character in front, so I am removing it
        //            if (split[0].Contains("\t"))
        //            {
        //                split[0] = split[0].Replace("\t", string.Empty);
        //            }

        //            switch (split[0])
        //            {
        //                case "Ns":
        //                    this.SpecularCoefficient = float.Parse(split[1]);
        //                    break;
        //                case "Ka":
        //                    this.Ambient = new Vector3f(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        //                    break;
        //                case "Kd":
        //                    this.Diffuse = new Vector3f(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        //                    break;
        //                case "Ks":
        //                    this.Specular = new Vector3f(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        //                    break;
        //                case "d":
        //                    this.Transparency = float.Parse(split[1]);
        //                    break;
        //                case "illum":
        //                    this.Illumination = (IlluminationMode)int.Parse(split[1]);
        //                    break;
        //                case "map_Kd":
        //                    if (File.Exists(lines[i].Split(new char[] { ' ' }, 2)[1])) this.DiffuseMap = new Texture(lines[i].Split(new char[] { ' ' }, 2)[1]);
        //                    break;
        //            }
        //        }

        //        this.Program = program;
        //    }

        //    public void Use()
        //    {
        //        if (DiffuseMap != null)
        //        {
        //            GL.ActiveTexture(0);
        //            GL.BindTexture(this.DiffuseMap);
        //            this.Program.SetUniform("useTexture", true);
        //        }
        //        else this.Program.SetUniform("useTexture", false);

        //        this.Program.Bind();

        //        this.Program.SetUniform("diffuse", this.Diffuse);
        //        this.Program.SetUniform("texture", 0);
        //        this.Program.SetUniform("transparency", this.Transparency);
        //    }

        //    public void Dispose()
        //    {
        //        if (DiffuseMap != null) DiffuseMap.Dispose();
        //        if (Program != null)
        //        {
        //            Program.Dispose();
        //        }
        //    }
        //}

        //public class ObjObject : IDisposable
        //{
        //    private VBO<Vector3f> vertices;
        //    private VBO<Vector3f> normals;
        //    private VBO<Vector2f> uvs;
        //    private VBO<int> triangles;

        //    public string Name { get; private set; }

        //    public ObjMaterial Material { get; set; }

        //    public int VertexCount
        //    {
        //        get { return triangles.Count * 3; }
        //    }

        //    public ObjObject(List<string> lines, Dictionary<string, ObjMaterial> materials, int vertexOffset, int uvOffset)
        //    {
        //        // we need at least 1 line to be a valid file
        //        if (lines.Count == 0) return;

        //        List<Vector3f> vertexList = new List<Vector3f>();
        //        List<Vector2f> uvList = new List<Vector2f>();
        //        List<int> triangleList = new List<int>();
        //        List<Vector2f> unpackedUvs = new List<Vector2f>();
        //        List<int> normalsList = new List<int>();

        //        // now we read the lines
        //        for (int i = 0; i < lines.Count; i++)
        //        {
        //            string[] split = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //            switch (split[0])
        //            {
        //                case "o":
        //                case "g":
        //                    this.Name = lines[i].Substring(2);
        //                    break;
        //                case "v":
        //                    vertexList.Add(new Vector3f(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3])));
        //                    break;
        //                case "vt":
        //                    uvList.Add(new Vector2f(float.Parse(split[1]), float.Parse(split[2])));
        //                    break;
        //                case "f":
        //                    if (split.Length == 5)  // this is a quad, so split it up
        //                    {
        //                        string[] split1 = new string[] { split[0], split[1], split[2], split[3] };
        //                        UnpackFace(split1, vertexOffset, uvOffset, vertexList, uvList, triangleList, unpackedUvs, normalsList);

        //                        string[] split2 = new string[] { split[0], split[1], split[3], split[4] };
        //                        UnpackFace(split2, vertexOffset, uvOffset, vertexList, uvList, triangleList, unpackedUvs, normalsList);
        //                    }
        //                    else UnpackFace(split, vertexOffset, uvOffset, vertexList, uvList, triangleList, unpackedUvs, normalsList);
        //                    break;
        //                case "usemtl":
        //                    if (materials.ContainsKey(split[1])) Material = materials[split[1]];
        //                    break;
        //            }
        //        }

        //        // calculate the normals (if they didn't exist)
        //        Vector3f[] vertexData = vertexList.ToArray();
        //        int[] elementData = triangleList.ToArray();
        //        Vector3f[] normalData = CalculateNormals(vertexData, elementData);

        //        // now convert the lists over to vertex buffer objects to be rendered by OpenGL
        //        this.vertices = new VBO<Vector3f>(vertexData);
        //        this.normals = new VBO<Vector3f>(normalData);
        //        if (unpackedUvs.Count != 0) this.uvs = new VBO<Vector2f>(unpackedUvs.ToArray());
        //        this.triangles = new VBO<int>(elementData, BufferTarget.ElementArrayBuffer);
        //    }

        //    private void UnpackFace(string[] split, int vertexOffset, int uvOffset, List<Vector3f> vertexList, List<Vector2f> uvList, List<int> triangleList, List<Vector2f> unpackedUvs, List<int> normalsList)
        //    {
        //        string[] indices = new string[] { split[1], split[2], split[3] };

        //        if (split[1].Contains("/"))
        //        {
        //            indices[0] = split[1].Substring(0, split[1].IndexOf("/"));
        //            indices[1] = split[2].Substring(0, split[2].IndexOf("/"));
        //            indices[2] = split[3].Substring(0, split[3].IndexOf("/"));

        //            string[] uvs = new string[3];
        //            uvs[0] = split[1].Substring(split[1].IndexOf("/") + 1);
        //            uvs[1] = split[2].Substring(split[2].IndexOf("/") + 1);
        //            uvs[2] = split[3].Substring(split[3].IndexOf("/") + 1);

        //            int[] triangle = new int[] { int.Parse(indices[0]) - vertexOffset, int.Parse(indices[1]) - vertexOffset, int.Parse(indices[2]) - vertexOffset };
        //            if (unpackedUvs.Count == 0) for (int j = 0; j < vertexList.Count; j++) unpackedUvs.Add(Vector2f.Zero);

        //            if (uvs[0].Contains("/"))
        //            {
        //                for (int i = 0; i < uvs.Length; i++) uvs[i] = uvs[i].Substring(0, uvs[i].IndexOf("/"));
        //            }
        //            else
        //            {
        //                normalsList.Add(triangle[0]);
        //                normalsList.Add(triangle[1]);
        //                normalsList.Add(triangle[2]);
        //            }

        //            if (uvs[0] != string.Empty && uvs[1] != string.Empty && uvs[2] != string.Empty)
        //            {
        //                if (unpackedUvs[triangle[0]] == Vector2f.Zero) unpackedUvs[triangle[0]] = uvList[int.Parse(uvs[0]) - uvOffset];
        //                else
        //                {
        //                    unpackedUvs.Add(uvList[int.Parse(uvs[0]) - uvOffset]);
        //                    vertexList.Add(vertexList[triangle[0]]);
        //                    triangle[0] = unpackedUvs.Count - 1;
        //                }

        //                if (unpackedUvs[triangle[1]] == Vector2f.Zero) unpackedUvs[triangle[1]] = uvList[int.Parse(uvs[1]) - uvOffset];
        //                else
        //                {
        //                    unpackedUvs.Add(uvList[int.Parse(uvs[1]) - uvOffset]);
        //                    vertexList.Add(vertexList[triangle[1]]);
        //                    triangle[1] = unpackedUvs.Count - 1;
        //                }

        //                if (unpackedUvs[triangle[2]] == Vector2f.Zero) unpackedUvs[triangle[2]] = uvList[int.Parse(uvs[2]) - uvOffset];
        //                else
        //                {
        //                    unpackedUvs.Add(uvList[int.Parse(uvs[2]) - uvOffset]);
        //                    vertexList.Add(vertexList[triangle[2]]);
        //                    triangle[2] = unpackedUvs.Count - 1;
        //                }
        //            }

        //            triangleList.Add(triangle[0]);
        //            triangleList.Add(triangle[1]);
        //            triangleList.Add(triangle[2]);
        //        }
        //        else
        //        {
        //            triangleList.Add(int.Parse(indices[0]) - vertexOffset);
        //            triangleList.Add(int.Parse(indices[1]) - vertexOffset);
        //            triangleList.Add(int.Parse(indices[2]) - vertexOffset);
        //        }
        //    }

        //    public static Vector3f[] CalculateNormals(Vector3f[] vertexData, int[] elementData)
        //    {
        //        Vector3f b1, b2, normal;
        //        Vector3f[] normalData = new Vector3f[vertexData.Length];

        //        for (int i = 0; i < elementData.Length / 3; i++)
        //        {
        //            int cornerA = elementData[i * 3];
        //            int cornerB = elementData[i * 3 + 1];
        //            int cornerC = elementData[i * 3 + 2];

        //            b1 = vertexData[cornerB] - vertexData[cornerA];
        //            b2 = vertexData[cornerC] - vertexData[cornerA];

        //            normal = Vector3f.Normalize(Vector3f.Cross(b1, b2));

        //            normalData[cornerA] += normal;
        //            normalData[cornerB] += normal;
        //            normalData[cornerC] += normal;
        //        }

        //        for (int i = 0; i < normalData.Length; i++) normalData[i] = Vector3f.Normalize(normalData[i]);

        //        return normalData;
        //    }

        //    public void Draw()
        //    {
        //        if (vertices == null || triangles == null) return;
        //        //if (Material == null) return;

        //        GL.Disable(EnableCap.CullFace);
        //        if (Material != null) Material.Use();

        //        GL.BindBufferToShaderAttribute(vertices, Material.Program, "in_position");
        //        GL.BindBufferToShaderAttribute(normals, Material.Program, "in_normal");
        //        if (uvs != null) GL.BindBufferToShaderAttribute(uvs, Material.Program, "in_uv");
        //        GL.BindBuffer(triangles);

        //        GL.DrawElements(BeginMode.Triangles, triangles.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        //    }

        //    public void Dispose()
        //    {
        //        if (vertices != null) vertices.Dispose();
        //        if (normals != null) normals.Dispose();
        //        if (triangles != null) triangles.Dispose();
        //    }
        //}
    }
}
