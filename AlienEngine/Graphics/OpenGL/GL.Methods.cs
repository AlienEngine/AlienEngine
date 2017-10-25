using System;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics.Shaders;
using AlienEngine.Imaging;

namespace AlienEngine.Core.Graphics.OpenGL
{
    /// <summary>
    /// Bindings to OpenGL 4.5 methods as well as some helper shortcuts.
    /// </summary>
    partial class GL
    {
        #region Preallocated Memory

        // pre-allocate the float[] for matrix and array data
        private static float[] float1 = new float[1];

        private static float[] matrix4Float = new float[16];
        private static float[] matrix3Float = new float[9];
        private static float[] vector2Float = new float[2];
        private static float[] vector3Float = new float[3];
        private static float[] vector4Float = new float[4];
        private static double[] double1 = new double[1];
        private static uint[] uint1 = new uint[1];
        private static int[] int1 = new int[1];
        private static bool[] bool1 = new bool[1];

        #endregion

        #region Private Fields

        private static int version = 0;
        private static uint currentProgram = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the program ID of the currently active shader program.
        /// </summary>
        [CLSCompliant(false)]
        public static uint CurrentProgram
        {
            get { return currentProgram; }
        }

        #endregion

        #region OpenGL Helpers (Type Safe Equivalents or Shortcuts)

        public static void Color3(Color3 color)
        {
            Color3(color.R, color.G, color.B);
        }

        public static void Color4(Color4 color)
        {
            Color4(color.R, color.G, color.B, color.A);
        }
        
        /// <summary>
        /// Returns the boolean value of a selected parameter.
        /// </summary>
        /// <param name="pname">A parameter that returns a single boolean.</param>
        public static bool GetBoolean(GetPName pname)
        {
            GetBooleanv(pname, bool1);
            return bool1[0];
        }

        public static void ClearColor(Color4 color)
        {
            GL.ClearColor(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Set a scalar texture parameter.
        /// </summary>
        /// <param name="target">Specificies the target for which the texture is bound.</param>
        /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
        /// <param name="param">Specifies the value of pname.</param>
        public static void TexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param)
        {
            TexParameteri(target, pname, (int) param);
        }

        /// <summary>
        /// Set a vector texture parameter.
        /// </summary>
        /// <param name="target">Specificies the target for which the texture is bound.</param>
        /// <param name="pname">Specifies the name of a single-values texture parameter.</param>
        /// <param name="params"></param>
        public static void TexParameteriv(TextureTarget target, TextureParameterName pname, TextureParameter[] @params)
        {
            int[] iparams = new int[@params.Length];
            for (int i = 0; i < iparams.Length; i++) iparams[i] = (int) @params[i];
            TexParameteriv(target, pname, iparams);
        }

        /// <summary>
        /// Gets the program info from a shader program.
        /// </summary>
        /// <param name="program">The ID of the shader program.</param>
        [CLSCompliant(false)]
        public static string GetProgramInfoLog(UInt32 program)
        {
            GL.GetProgramiv(program, GetProgramParameterName.InfoLogLength, int1);
            if (int1[0] == 0) return String.Empty;
            string log = string.Empty;
            GL.GetProgramInfoLog(program, int1[0], out int1[0], out log);
            return log;
        }

        /// <summary>
        /// Gets the program info from a shader program.
        /// </summary>
        /// <param name="shader">The ID of the shader program.</param>
        [CLSCompliant(false)]
        public static string GetShaderInfoLog(UInt32 shader)
        {
            GL.GetShaderiv(shader, ShaderParameter.InfoLogLength, int1);
            if (int1[0] == 0) return String.Empty;
            string log = string.Empty;
            GL.GetShaderInfoLog(shader, int1[0], out int1[0], out log);
            return log;
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// </summary>
        /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
        /// <param name="source">Specifies a string containing the source code to be loaded into the shader.</param>
        [CLSCompliant(false)]
        public static void ShaderSource(UInt32 shader, string source)
        {
            int1[0] = source.Length;
            GL.ShaderSource(shader, 1, new string[] {source}, int1);
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTarget target, Int32 size, [In, Out] T[] data, BufferUsageHint usage)
            where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GL.BufferData(target, size, data_ptr.AddrOfPinnedObject(), usage);
            }
            finally
            {
                data_ptr.Free();
            }
        }

        /// <summary>
        /// Creates and initializes a buffer object's data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="position">Offset into the data from which to start copying to the buffer.</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTarget target, Int32 position, Int32 size, [In, Out] T[] data,
            BufferUsageHint usage)
            where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GL.BufferData(target, size, (IntPtr) ((int) data_ptr.AddrOfPinnedObject() + position), usage);
            }
            finally
            {
                data_ptr.Free();
            }
        }

        /// <summary>
        /// Creates a standard VBO of type T.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint)
            where T : struct
        {
            uint vboHandle = GL.GenBuffer();
            if (vboHandle == 0) return 0;

            int size = data.Length * Marshal.SizeOf(typeof(T));

            GL.BindBuffer(target, vboHandle);
            GL.BufferData<T>(target, size, data, hint);
            GL.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint, int length)
            where T : struct
        {
            uint vboHandle = GL.GenBuffer();
            if (vboHandle == 0) return 0;

            int size = length * Marshal.SizeOf(typeof(T));

            GL.BindBuffer(target, vboHandle);
            GL.BufferData<T>(target, size, data, hint);
            GL.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates a standard VBO of type T where the length of the VBO is less than or equal to the length of the data.
        /// </summary>
        /// <typeparam name="T">The type of the data being stored in the VBO (make sure it's byte aligned).</typeparam>
        /// <param name="target">The VBO BufferTarget (usually ArrayBuffer or ElementArrayBuffer).</param>
        /// <param name="data">The data to store in the VBO.</param>
        /// <param name="hint">The buffer usage hint (usually StaticDraw).</param>
        /// <param name="position">Starting element of the data that will be copied into the VBO.</param>
        /// <param name="length">The length of the VBO (will take the first 'length' elements from data).</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateVBO<T>(BufferTarget target, [In, Out] T[] data, BufferUsageHint hint, int position,
            int length)
            where T : struct
        {
            uint vboHandle = GL.GenBuffer();
            if (vboHandle == 0) return 0;

            int offset = position * Marshal.SizeOf(typeof(T));
            int size = length * Marshal.SizeOf(typeof(T));

            GL.BindBuffer(target, vboHandle);
            GL.BufferData<T>(target, offset, size, data, hint);
            GL.BindBuffer(target, 0);
            return vboHandle;
        }

        /// <summary>
        /// Creates an interleaved VBO that contains both Vector3f and Vector3f data (typically position and normal data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3f data (usually position).</param>
        /// <param name="data2">The second array of Vector3f data (usually normal).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3f[] data1, Vector3f[] data2,
            BufferUsageHint hint)
        {
            if (data2.Length != data1.Length)
                throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 6];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3f, Vector3f and Vector2f data (typically position, normal and UV data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3f data (usually position).</param>
        /// <param name="data2">The second array of Vector3f data (usually normal).</param>
        /// <param name="data3">The Vector2f data (usually UV).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3f[] data1, Vector3f[] data2,
            Vector2f[] data3, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length)
                throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 8];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3f, Vector3f and Vector3f data (typically position, normal and tangent data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3f data (usually position).</param>
        /// <param name="data2">The second array of Vector3f data (usually normal).</param>
        /// <param name="data3">The third array of Vector3f data (usually tangent).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3f[] data1, Vector3f[] data2,
            Vector3f[] data3, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length)
                throw new Exception("Data lengths must be identical to construct an interleaved VBO.");

            float[] interleaved = new float[data1.Length * 9];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
                interleaved[j++] = data3[i].Z;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates an interleaved VBO that contains Vector3f, Vector3f, Vector3f and Vector2f data (typically position, normal, tangent and UV data).
        /// </summary>
        /// <param name="target">The VBO buffer target.</param>
        /// <param name="data1">The first array of Vector3f data (usually position).</param>
        /// <param name="data2">The second array of Vector3f data (usually normal).</param>
        /// <param name="data3">The third array of Vector3f data (usually tangent).</param>
        /// <param name="data4">The Vector2f data (usually UV).</param>
        /// <param name="hint">Specifies expected usage pattern of the data store.</param>
        /// <returns>The buffer ID of the VBO on success, 0 on failure.</returns>
        [CLSCompliant(false)]
        public static uint CreateInterleavedVBO(BufferTarget target, Vector3f[] data1, Vector3f[] data2,
            Vector3f[] data3, Vector2f[] data4, BufferUsageHint hint)
        {
            if (data2.Length != data1.Length || data3.Length != data1.Length || data4.Length != data1.Length)
            {
                throw new Exception("Data lengths must be identical to construct an interleaved VBO.");
            }

            float[] interleaved = new float[data1.Length * 11];

            for (int i = 0, j = 0; i < data1.Length; i++)
            {
                interleaved[j++] = data1[i].X;
                interleaved[j++] = data1[i].Y;
                interleaved[j++] = data1[i].Z;

                interleaved[j++] = data2[i].X;
                interleaved[j++] = data2[i].Y;
                interleaved[j++] = data2[i].Z;

                interleaved[j++] = data3[i].X;
                interleaved[j++] = data3[i].Y;
                interleaved[j++] = data3[i].Z;

                interleaved[j++] = data4[i].X;
                interleaved[j++] = data4[i].Y;
            }

            return CreateVBO<float>(target, interleaved, hint);
        }

        /// <summary>
        /// Creates a vertex array object based on a series of attribute arrays and and attribute names.
        /// </summary>
        /// <param name="program">The shader program that contains the attributes to be bound to.</param>
        /// <param name="vbo">The VBO containing all of the attribute data.</param>
        /// <param name="sizes">An array of sizes which correspond to the size of each attribute.</param>
        /// <param name="types">An array of the attribute pointer types.</param>
        /// <param name="targets">An array of the buffer targets.</param>
        /// <param name="names">An array of the attribute names.</param>
        /// <param name="stride">The stride of the VBO.</param>
        /// <param name="eboHandle">The element buffer handle.</param>
        /// <returns>The vertex array object (VAO) ID.</returns>
        [CLSCompliant(false)]
        public static uint CreateVAO(ShaderProgram program, uint vbo, int[] sizes, VertexAttribPointerType[] types,
            BufferTarget[] targets, string[] names, int stride, uint eboHandle)
        {
            uint vaoHandle = GL.GenVertexArray();
            GL.BindVertexArray(vaoHandle);

            int offset = 0;

            for (uint i = 0; i < names.Length; i++)
            {
                GL.EnableVertexAttribArray(i);
                GL.BindBuffer(targets[i], vbo);
                GL.VertexAttribPointer(i, sizes[i], types[i], true, stride, offset);
                GL.BindAttribLocation(program.ID, i, names[i]);
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboHandle);
            GL.BindVertexArray(0);

            return vaoHandle;
        }

        /// <summary>
        /// Gets the current OpenGL version (returns a cached result on subsequent calls).
        /// </summary>
        /// <returns>The current OpenGL version, or 0 on an error.</returns>
        public static int Version()
        {
            if (version != 0) return version; // cache the version information

            try
            {
                string versionString = GL.GetString(StringName.Version);

                version = int.Parse(versionString.Substring(0, versionString.IndexOf('.')));
                return GL.version;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while retrieving the AlienEngine.Core.Graphics.OpenGL version.");
                return 0;
            }
        }

        /// <summary>
        /// Installs a program object as part of current rendering state.
        /// </summary>
        /// <param name="Program">Specifies the handle of the program object whose executables are to be used as part of current rendering state.</param>
        public static void UseShaderProgram(ShaderProgram Program)
        {
            GL.UseProgram(Program.ID);
        }

        /// <summary>
        /// Bind a named texture to a texturing target
        /// </summary>
        /// <param name="Texture">Specifies the texture.</param>
        public static void BindTexture(Texture Texture)
        {
            GL.BindTexture(Texture.TextureTarget, Texture.TextureID);
        }

        /// <summary>
        /// Get the index of a uniform block in the provided shader program.
        /// Note:  This method will use the provided shader program, so make sure to
        /// store which program is currently active and reload it if required.
        /// </summary>
        /// <param name="program">The shader program that contains the uniform block.</param>
        /// <param name="uniformBlockName">The uniform block name.</param>
        /// <returns>The index of the uniform block.</returns>
        [CLSCompliant(false)]
        public static uint GetShaderProgramUniformBlockIndex(ShaderProgram program, string uniformBlockName)
        {
            return GL.GetUniformBlockIndex(program.ID, uniformBlockName);
        }

        /// <summary>
        /// Binds a VBO based on the buffer target.
        /// </summary>
        /// <param name="buffer">The VBO to bind.</param>
        public static void BindVBO<T>(VBO<T> buffer)
            where T : struct
        {
            GL.BindBuffer(buffer.BufferTarget, buffer.ID);
        }

        /// <summary>
        /// Binds a VBO to a shader attribute.
        /// </summary>
        /// <param name="buffer">The VBO to bind to the shader attribute.</param>
        /// <param name="program">The shader program whose attribute will be bound to.</param>
        /// <param name="attributeName">The name of the shader attribute to be bound to.</param>
        public static void BindBufferToShaderAttribute<T>(VBO<T> buffer, ShaderProgram program, string attributeName)
            where T : struct
        {
            uint location = (uint) GL.GetAttribLocation(program.ID, attributeName);

            GL.EnableVertexAttribArray(location);
            GL.BindVBO(buffer);
            GL.VertexAttribPointer(location, buffer.Size, buffer.PointerType, true, Marshal.SizeOf(typeof(T)), 0);
        }

        /// <summary>
        /// Delete a single OpenGL buffer.
        /// </summary>
        /// <param name="buffer">The OpenGL buffer to delete.</param>
        [CLSCompliant(false)]
        public static void DeleteBuffer(uint buffer)
        {
            uint1[0] = buffer;
            DeleteBuffers(1, uint1);
            uint1[0] = 0;
        }

        /// <summary>
        /// Set a uniform vec2 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform2(int location, Vector2f data)
        {
            vector2Float[0] = data.X;
            vector2Float[1] = data.Y;
            GL.Uniform2fv(location, 1, vector2Float);
        }

        /// <summary>
        /// Set a uniform vec3 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform3(int location, Vector3f data)
        {
            vector3Float[0] = data.X;
            vector3Float[1] = data.Y;
            vector3Float[2] = data.Z;
            GL.Uniform3fv(location, 1, vector3Float);
        }

        /// <summary>
        /// Set a uniform vec3 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform3(int location, Color3 data)
        {
            vector3Float[0] = data.R;
            vector3Float[1] = data.G;
            vector3Float[2] = data.B;
            GL.Uniform3fv(location, 1, vector3Float);
        }

        /// <summary>
        /// Set a uniform vec4 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform4(int location, Vector4f data)
        {
            vector4Float[0] = data.X;
            vector4Float[1] = data.Y;
            vector4Float[2] = data.Z;
            vector4Float[3] = data.W;
            GL.Uniform4fv(location, 1, vector4Float);
        }

        /// <summary>
        /// Set a uniform vec4 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform4(int location, Color4 data)
        {
            vector4Float[0] = data.R;
            vector4Float[1] = data.G;
            vector4Float[2] = data.B;
            vector4Float[3] = data.A;
            GL.Uniform4fv(location, 1, vector4Float);
        }

        /// <summary>
        /// Set a uniform vec4 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Vector2f to load into the shader uniform.</param>
        public static void Uniform4(int location, Quaternion data)
        {
            vector4Float[0] = data.X;
            vector4Float[1] = data.Y;
            vector4Float[2] = data.Z;
            vector4Float[3] = data.W;
            GL.Uniform4fv(location, 1, vector4Float);
        }

        /// <summary>
        /// Set a uniform mat4 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Matrix4f to load into the shader uniform.</param>
        public static void UniformMatrix4(int location, Matrix4f param)
        {
            // use the statically allocated float[] for setting the uniform
            matrix4Float[0] = param[0].X;
            matrix4Float[1] = param[0].Y;
            matrix4Float[2] = param[0].Z;
            matrix4Float[3] = param[0].W;
            matrix4Float[4] = param[1].X;
            matrix4Float[5] = param[1].Y;
            matrix4Float[6] = param[1].Z;
            matrix4Float[7] = param[1].W;
            matrix4Float[8] = param[2].X;
            matrix4Float[9] = param[2].Y;
            matrix4Float[10] = param[2].Z;
            matrix4Float[11] = param[2].W;
            matrix4Float[12] = param[3].X;
            matrix4Float[13] = param[3].Y;
            matrix4Float[14] = param[3].Z;
            matrix4Float[15] = param[3].W;

            GL.UniformMatrix4fv(location, 1, false, matrix4Float);
        }

        /// <summary>
        /// Set a uniform mat3 in the shader.
        /// Uses a cached float[] to reduce memory usage.
        /// </summary>
        /// <param name="location">The location of the uniform in the shader.</param>
        /// <param name="param">The Matrix3f to load into the shader uniform.</param>
        public static void UniformMatrix3(int location, Matrix3f param)
        {
            // use the statically allocated float[] for setting the uniform
            matrix3Float[0] = param[0].X;
            matrix3Float[1] = param[0].Y;
            matrix3Float[2] = param[0].Z;
            matrix3Float[3] = param[1].X;
            matrix3Float[4] = param[1].Y;
            matrix3Float[5] = param[1].Z;
            matrix3Float[6] = param[2].X;
            matrix3Float[7] = param[2].Y;
            matrix3Float[8] = param[2].Z;

            GL.UniformMatrix3fv(location, 1, false, matrix3Float);
        }

        /// <summary>
        /// Updates a subset of the buffer object's data store.
        /// </summary>
        /// <typeparam name="T">The type of data in the data array.</typeparam>
        /// <param name="vboID">The VBO whose buffer will be updated.</param>
        /// <param name="target">Specifies the target buffer object.  Must be ArrayBuffer, ElementArrayBuffer, PixelPackBuffer or PixelUnpackBuffer.</param>
        /// <param name="data">The new data that will be copied to the data store.</param>
        /// <param name="length">The size in bytes of the data store region being replaced.</param>
        [CLSCompliant(false)]
        public static void BufferSubData<T>(uint vboID, BufferTarget target, T[] data, int length)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                GL.BindBuffer(target, vboID);
                GL.BufferSubData(target, 0, Marshal.SizeOf(data[0]) * length, handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }

        [CLSCompliant(false)]
        public static void DeleteTexture(uint texture)
        {
            GL.DeleteTextures(1, new uint[] {texture});
        }

        public static void DeleteVertexArray(uint vao)
        {
            GL.DeleteVertexArrays(1, new uint[] {vao});
        }

        //public static void VertexPointer(int size, VertexPointerType type, int stride, int pointer)
        //{
        //    GL.VertexPointer(size, type, stride, pointer);
        //}

        //public static void VertexPointer<T>(int size, VertexPointerType type, int stride, [InAttribute, OutAttribute] T[] pointer)
        //{
        //    GCHandle handle = GCHandle.Alloc(pointer, GCHandleType.Pinned);

        //    try
        //    {
        //        GL.VertexPointer(size, type, stride, handle.AddrOfPinnedObject());
        //    }
        //    finally
        //    {
        //        handle.Free();
        //    }
        //}

        //public static void TexCoordPointer(int size, TexCoordPointerType type, int stride, int pointer)
        //{
        //    GL.TexCoordPointer(size, type, stride, (IntPtr)pointer);
        //}

        //public static void TexCoordPointer<T>(int size, TexCoordPointerType type, int stride, [InAttribute, OutAttribute] T[] pointer)
        //{
        //    GCHandle handle = GCHandle.Alloc(pointer, GCHandleType.Pinned);

        //    try
        //    {
        //        GL.TexCoordPointer(size, type, stride, handle.AddrOfPinnedObject());
        //    }
        //    finally
        //    {
        //        handle.Free();
        //    }
        //}

        #endregion
    }
}