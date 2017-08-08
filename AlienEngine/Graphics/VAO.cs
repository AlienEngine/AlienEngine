using System;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Graphics
{
    public class VAO<T1> : GenericVAO
        where T1 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, string attribName, VBO<int> elementArray)
            : base(program)
        {
            GenericVAO.GenericVBO[] vbos = new GenericVBO[2];
            vbos[0] = new GenericVBO(vbo1.ID, attribName, vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }

        public VAO(ShaderProgram program, VBO<T1> vbo1, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 1) throw new Exception(string.Format("Expected an array of 1 name, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[2];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2> : GenericVAO
        where T1 : struct
        where T2 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 2) throw new Exception(string.Format("Expected an array of 2 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[3];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 3) throw new Exception(string.Format("Expected an array of 3 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[4];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 4) throw new Exception(string.Format("Expected an array of 4 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[5];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.ID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 5) throw new Exception(string.Format("Expected an array of 5 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[6];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.ID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.ID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 6) throw new Exception(string.Format("Expected an array of 6 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[7];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.ID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.ID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.ID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6, T7> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 7) throw new Exception(string.Format("Expected an array of 7 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[8];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.ID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.ID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.ID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(vbo7.ID, attribNames[6], vbo7.Count, vbo7.Size, vbo7.PointerType, vbo7.BufferTarget);
            vbos[7] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class VAO<T1, T2, T3, T4, T5, T6, T7, T8> : GenericVAO
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
    {
        public VAO(ShaderProgram program, VBO<T1> vbo1, VBO<T2> vbo2, VBO<T3> vbo3, VBO<T4> vbo4, VBO<T5> vbo5, VBO<T6> vbo6, VBO<T7> vbo7, VBO<T8> vbo8, string[] attribNames, VBO<int> elementArray)
            : base(program)
        {
            if (attribNames.Length != 8) throw new Exception(string.Format("Expected an array of 8 names, but instead got {0}.", attribNames.Length));

            GenericVAO.GenericVBO[] vbos = new GenericVBO[8];
            vbos[0] = new GenericVBO(vbo1.ID, attribNames[0], vbo1.Count, vbo1.Size, vbo1.PointerType, vbo1.BufferTarget);
            vbos[1] = new GenericVBO(vbo2.ID, attribNames[1], vbo2.Count, vbo2.Size, vbo2.PointerType, vbo2.BufferTarget);
            vbos[2] = new GenericVBO(vbo3.ID, attribNames[2], vbo3.Count, vbo3.Size, vbo3.PointerType, vbo3.BufferTarget);
            vbos[3] = new GenericVBO(vbo4.ID, attribNames[3], vbo4.Count, vbo4.Size, vbo4.PointerType, vbo4.BufferTarget);
            vbos[4] = new GenericVBO(vbo5.ID, attribNames[4], vbo5.Count, vbo5.Size, vbo5.PointerType, vbo5.BufferTarget);
            vbos[5] = new GenericVBO(vbo6.ID, attribNames[5], vbo6.Count, vbo6.Size, vbo6.PointerType, vbo6.BufferTarget);
            vbos[6] = new GenericVBO(vbo7.ID, attribNames[6], vbo7.Count, vbo7.Size, vbo7.PointerType, vbo7.BufferTarget);
            vbos[7] = new GenericVBO(vbo8.ID, attribNames[7], vbo8.Count, vbo8.Size, vbo8.PointerType, vbo8.BufferTarget);
            vbos[8] = new GenericVBO(elementArray.ID, "", elementArray.Count, elementArray.Size, elementArray.PointerType, elementArray.BufferTarget);

            Init(vbos);
        }
    }

    public class GenericVAO : IDisposable
    {
        #region Generic VBO
        public GenericVBO[] vbos;

        public struct GenericVBO
        {
            public string Name;
            public VertexAttribPointerType PointerType;
            public int Length;
            public BufferTarget BufferTarget;
            [CLSCompliant(false)]
            public uint ID;
            public int Size;

            [CLSCompliant(false)]
            public GenericVBO(uint id, string name, int length, int size, VertexAttribPointerType pointerType, BufferTarget bufferTarget)
            {
                ID = id;
                Name = name;
                Length = length;
                Size = size;
                PointerType = pointerType;
                BufferTarget = bufferTarget;
            }
        }
        #endregion

        #region Constructor and Destructor
        public GenericVAO(ShaderProgram program)
        {
            Program = program;
            DrawMode = BeginMode.Triangles;
        }

        public void Init(GenericVBO[] vbos)
        {
            this.vbos = vbos;

            if (GL.Version() >= 3)
            {
                ID = GL.GenVertexArray();
                if (ID != 0)
                {
                    GL.BindVertexArray(ID);
                    BindAttributes(Program);
                }
                GL.BindVertexArray(0);

                Draw = DrawOGL3;
            }
            else
            {
                Draw = DrawOGL2;
            }
        }

        ~GenericVAO()
        {
            Dispose(false);
        }
        #endregion

        #region Properties
        private bool disposeChildren = false;

        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// Specifies if the VAO should dispose of the child VBOs when Dispose() is called.
        /// </summary>
        public bool DisposeChildren
        {
            get { return disposeChildren; }
            set
            {
                disposeChildren = value;
                DisposeElementArray = value;
            }
        }

        /// <summary>
        /// Specifies if the VAO should dispose of the element array when Dispose() is called.
        /// </summary>
        public bool DisposeElementArray { get; set; }

        /// <summary>
        /// The ShaderProgram associated with this VAO.
        /// </summary>
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// The drawing mode to use when drawing the arrays.
        /// </summary>
        public BeginMode DrawMode { get; set; }

#pragma warning disable IDE1006
        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [Obsolete("Use ID instead.")]
        [CLSCompliant(false)]
        public uint vaoID
        {
             get { return ID; }
            private set { ID = value; }
        }
#pragma warning restore

        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [CLSCompliant(false)]
        public uint ID { get; private set; }
        #endregion

        #region Draw Methods (OGL2 and OGL3)
        private int SizeOfType(VertexAttribPointerType type)
        {
            switch (type)
            {
                case VertexAttribPointerType.Byte: 
                case VertexAttribPointerType.UnsignedByte: return 1;
                case VertexAttribPointerType.Short:
                case VertexAttribPointerType.UnsignedShort: 
                case VertexAttribPointerType.HalfFloat: return 2;
                case VertexAttribPointerType.Int:
                case VertexAttribPointerType.Float: return 4;
                case VertexAttribPointerType.Double: return 8;
            }
            return 1;
        }

        public void BindAttributes(ShaderProgram program)
        {
            GenericVBO elementArray = new GenericVBO(0, "", 0, 0, VertexAttribPointerType.Byte, BufferTarget.ArrayBuffer);

            for (int i = 0; i < vbos.Length; i++)
            {
                if (vbos[i].BufferTarget == BufferTarget.ElementArrayBuffer)
                {
                    elementArray = vbos[i];
                    continue;
                }

                int loc = GL.GetAttribLocation(program.ID, vbos[i].Name);
                if (loc == -1) throw new Exception(string.Format("Shader did not contain '{0}'.", vbos[i].Name));

                GL.EnableVertexAttribArray((uint)loc);
                GL.BindBuffer(vbos[i].BufferTarget, vbos[i].ID);
                GL.VertexAttribPointer((uint)loc, vbos[i].Size, vbos[i].PointerType, true, vbos[i].Size * SizeOfType(vbos[i].PointerType), 0);
            }

            if (elementArray.ID != 0)
            {
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementArray.ID);
                VertexCount = elementArray.Length;
            }
        }

        public delegate void DrawFunc();

        public DrawFunc Draw;

        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawOGL3()
        {
            if (ID == 0 || VertexCount == 0) return;
            GL.BindVertexArray(ID);
            GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }

        /// <summary>
        /// OGL2 does not support VAOs, and instead must bind the VBOs to their attributes manually.
        /// </summary>
        private void DrawOGL2()
        {
            if (VertexCount == 0) return;
            BindAttributes(Program);
            GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, 0);
        }

        /// <summary>
        /// Performs the draw routine with a custom shader program.
        /// </summary>
        /// <param name="program"></param>
        public void DrawProgram(ShaderProgram program)
        {
            BindAttributes(program);
            GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, 0);
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // first try to dispose of the vertex array
            if (ID != 0)
            {
                GL.DeleteVertexArrays(1, new uint[] { ID });

                ID = 0;
            }

            // children must be disposed of separately since OpenGL 2.1 will not have a vertex array
            if (DisposeChildren)
            {
                for (int i = 0; i < vbos.Length; i++)
                {
                    if (vbos[i].BufferTarget == BufferTarget.ElementArrayBuffer && !DisposeElementArray) continue;
                    GL.DeleteBuffer(vbos[i].ID);
                }
            }
        }
        #endregion
    }

    public class VAO : IDisposable
    {
        #region Variables
        private VBO<Vector3f> vertex, normal, tangent;

        private VBO<Vector2f> uv;

        private VBO<int> element;

        private bool disposeChildren = false;
        #endregion

        #region Properties
        /// <summary>
        /// The offset into the element array buffer that this VAO begins.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The number of vertices that make up this VAO.
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// Specifies if the VAO should dispose of the child VBOs when Dispose() is called.
        /// </summary>
        public bool DisposeChildren
        {
            get { return disposeChildren; }
            set
            {
                disposeChildren = value;
                DisposeElementArray = value;
            }
        }

        /// <summary>
        /// Specifies if the VAO should dispose of the element array when Dispose() is called.
        /// </summary>
        public bool DisposeElementArray { get; set; }

        /// <summary>
        /// The ShaderProgram associated with this VAO.
        /// </summary>
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// The drawing mode to use when drawing the arrays.
        /// </summary>
        public BeginMode DrawMode { get; set; }

#pragma warning disable IDE1006
        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [Obsolete("Use ID instead.")]
        [CLSCompliant(false)]
        public uint vaoID
        {
            get { return ID; }
            private set { ID = value; }
        }
#pragma warning restore

        /// <summary>
        /// The ID of this Vertex Array Object for use in calls to OpenGL.
        /// </summary>
        [CLSCompliant(false)]
        public uint ID { get; private set; }
        #endregion

        #region Constructors and Destructor
        public VAO(ShaderProgram program, VBO<Vector3f> vertex, VBO<int> element)
            : this(program, vertex, null, null, null, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3f> vertex, VBO<Vector2f> uv, VBO<int> element)
            : this(program, vertex, null, null, uv, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<int> element)
            : this(program, vertex, normal, null, null, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<Vector2f> uv, VBO<int> element)
            : this(program, vertex, normal, null, uv, element)
        {
        }

        public VAO(ShaderProgram program, VBO<Vector3f> vertex, VBO<Vector3f> normal, VBO<Vector3f> tangent, VBO<Vector2f> uv, VBO<int> element)
        {
            Program = program;
            VertexCount = element.Count;
            DrawMode = BeginMode.Triangles;

            this.vertex = vertex;
            this.normal = normal;
            this.tangent = tangent;
            this.uv = uv;
            this.element = element;

            if (GL.Version() >= 3)
            {
                ID = GL.GenVertexArray();
                if (ID != 0)
                {
                    if (Program.Compiled)
                    {
                        GL.BindVertexArray(ID);
                        BindAttributes(Program);
                    }
                    else
                    {
                        Program.OnCompile += () =>
                        {
                            GL.BindVertexArray(ID);
                            BindAttributes(Program);
                        };
                    }
                }
                GL.BindVertexArray(0);

                Draw = DrawOGL3;
            }
            else
            {
                Draw = DrawOGL2;
            }

            ResourcesManager.AddDisposableResource(this);
        }

        ~VAO()
        {
            Dispose(false);
        }
        #endregion

        #region Draw Methods (OGL2 and OGL3)
        public void BindCachedAttributes(ShaderProgram program, int vertexAttributeLocation, int normalAttributeLocation = -1, int uvAttributeLocation = -1, int tangentAttributeLocation = -1)
        {
            if (normalAttributeLocation != -1 && normal.ID != 0)
            {
                GL.EnableVertexAttribArray((uint)normalAttributeLocation);
                GL.BindBuffer(normal.BufferTarget, normal.ID);
                GL.VertexAttribPointer((uint)normalAttributeLocation, normal.Size, normal.PointerType, true, 12, 0);
            }

            if (uvAttributeLocation != -1 && uv.ID != 0)
            {
                GL.EnableVertexAttribArray((uint)uvAttributeLocation);
                GL.BindBuffer(uv.BufferTarget, uv.ID);
                GL.VertexAttribPointer((uint)uvAttributeLocation, uv.Size, uv.PointerType, true, 8, 0);
            }

            if (tangentAttributeLocation != -1 && tangent.ID != 0)
            {
                GL.EnableVertexAttribArray((uint)tangentAttributeLocation);
                GL.BindBuffer(tangent.BufferTarget, tangent.ID);
                GL.VertexAttribPointer((uint)tangentAttributeLocation, tangent.Size, tangent.PointerType, true, 12, 0);
            }

            BindCachedAttributes(vertexAttributeLocation, program);
        }

        public void BindCachedAttributes(int vertexAttributeLocation, ShaderProgram program)
        {
            if (vertex == null || vertex.ID == 0) throw new Exception("Error binding attributes.  No vertices were supplied.");
            if (element == null || element.ID == 0) throw new Exception("Error binding attributes.  No element array was supplied.");

            GL.EnableVertexAttribArray((uint)vertexAttributeLocation);
            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.VertexAttribPointer((uint)vertexAttributeLocation, vertex.Size, vertex.PointerType, true, 12, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, element.ID);
        }

        /// <summary>
        /// Generic method for binding the VBOs to their respective attribute locations.
        /// OpenGL.dll assumes the common naming conventions below:
        ///     vertices: vec3 in_position
        ///     normals: vec3 in_normal
        ///     uv: vec2 in_uv
        ///     tangent: vec3 in_tangent
        /// </summary>
        public void BindAttributes(ShaderProgram program)
        {
            if (vertex == null || vertex.ID == 0) throw new Exception("Error binding attributes.  No vertices were supplied.");
            if (element == null || element.ID == 0) throw new Exception("Error binding attributes.  No element array was supplied.");

            // Note:  Since the shader is already compiled, we cannot set the attribute locations.
            //  Instead we must query the shader for the locations that the linker chose and use them.
            int loc = GL.GetAttribLocation(program.ID, "in_position");
            if (loc == -1) throw new Exception("Shader did not contain 'in_position'.");

            GL.EnableVertexAttribArray((uint)loc);
            GL.BindBuffer(vertex.BufferTarget, vertex.ID);
            GL.VertexAttribPointer((uint)loc, vertex.Size, vertex.PointerType, true, vertex.Size * 4, 0);

            if (normal != null && normal.ID != 0)
            {
                loc = GL.GetAttribLocation(program.ID, "in_normal");
                if (loc != -1)
                {
                    GL.EnableVertexAttribArray((uint)loc);
                    GL.BindBuffer(normal.BufferTarget, normal.ID);
                    GL.VertexAttribPointer((uint)loc, normal.Size, normal.PointerType, true, normal.Size * 4, 0);
                }
            }

            if (uv != null && uv.ID != 0)
            {
                loc = GL.GetAttribLocation(program.ID, "in_uv");
                if (loc != -1)
                {
                    GL.EnableVertexAttribArray((uint)loc);
                    GL.BindBuffer(uv.BufferTarget, uv.ID);
                    GL.VertexAttribPointer((uint)loc, uv.Size, uv.PointerType, true, uv.Size * 4, 0);
                }
            }

            if (tangent != null && tangent.ID != 0)
            {
                loc = GL.GetAttribLocation(program.ID, "in_tangent");
                if (loc != -1)
                {
                    GL.EnableVertexAttribArray((uint)loc);
                    GL.BindBuffer(tangent.BufferTarget, tangent.ID);
                    GL.VertexAttribPointer((uint)loc, tangent.Size, tangent.PointerType, true, tangent.Size * 4, 0);
                }
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, element.ID);
        }

        public delegate void DrawFunc();

        public DrawFunc Draw;

        /// <summary>
        /// OGL3 method uses a vertex array object for quickly binding the VBOs to their attributes.
        /// </summary>
        private void DrawOGL3()
        {
            if (ID == 0) return;
            GL.BindVertexArray(ID);

            GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, Offset * 4);

            GL.BindVertexArray(0);
        }

        /// <summary>
        /// OGL2 does not support VAOs, and instead must bind the VBOs to their attributes manually.
        /// </summary>
        private void DrawOGL2()
        {
            BindAttributes(Program);

            IntPtr offset = (IntPtr)(Offset * 4);
            GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, Offset * 4);
        }

        /// <summary>
        /// Performs the draw routine with a custom shader program.
        /// </summary>
        /// <param name="program"></param>
        public void DrawProgram(ShaderProgram program)
        {
            BindAttributes(program);
            if (Offset == 0) GL.DrawElements(DrawMode, VertexCount, DrawElementsType.UnsignedInt, 0);
            else GL.DrawElementsBaseVertex(DrawMode, VertexCount, DrawElementsType.UnsignedInt, 0, Offset);
        }

        public void DrawOffset(int offset)
        {

        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Deletes the vertex array from the GPU and will also dispose of any child VBOs if (DisposeChildren == true).
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // first try to dispose of the vertex array
            if (ID != 0)
            {
                GL.DeleteVertexArrays(1, new uint[] { ID });
                ID = 0;
            }

            // children must be disposed of separately since OpenGL 2.1 will not have a vertex array
            if (DisposeChildren)
            {
                if (vertex != null) vertex.Dispose();
                if (normal != null) normal.Dispose();
                if (tangent != null) tangent.Dispose();
                if (uv != null) uv.Dispose();
                if (element != null && DisposeElementArray) element.Dispose();

                vertex = null;
                normal = null;
                tangent = null;
                uv = null;
                element = null;
            }
        }
        #endregion
    }
}
