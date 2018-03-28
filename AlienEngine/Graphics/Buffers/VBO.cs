using System;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Graphics.Buffers
{
    public class VBO<T> : IDisposable where T : struct
    {
        #region Properties

        /// <summary>
        /// The ID of the vertex buffer object.
        /// </summary>
        [CLSCompliant(false)]
        public uint ID { get; private set; }

        /// <summary>
        /// The type of the buffer.
        /// </summary>
        public BufferTarget BufferTarget { get; private set; }

        /// <summary>
        /// The size (in floats) of the type of data in the buffer.  Size * 4 to get bytes.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// The type of data that is stored in the buffer (either int or float).
        /// </summary>
        public VertexAttribPointerType PointerType { get; private set; }

        /// <summary>
        /// The length of data that is stored in the buffer.
        /// </summary>
        public int Count { get; private set; }

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Creates a buffer object of type T with a specified length.
        /// This allows the array T[] to be larger than the actual size necessary to buffer.
        /// Useful for reusing resources and avoiding unnecessary GC action.
        /// </summary>
        /// <param name="data">An array of data of type T (which must be a struct) that will be buffered to the GPU.</param>
        /// <param name="length">The length of the valid data in the data array.</param>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] data, int length, BufferTarget target = BufferTarget.ArrayBuffer, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            length = MathHelper.Clamp(length, 0, data.Length);

            ID = GL.CreateVBO<T>(BufferTarget = target, data, hint, length);

            Size = (data is int[] ? 1 : (data is Vector2f[] ? 2 : (data is Vector3f[] ? 3 : (data is Vector4f[] ? 4 : 0))));
            PointerType = (data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            Count = length;

            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Creates a buffer object of type T with a specified length.
        /// This allows the array T[] to be larger than the actual size necessary to buffer.
        /// Useful for reusing resources and avoiding unnecessary GC action.
        /// </summary>
        /// <param name="data">An array of data of type T (which must be a struct) that will be buffered to the GPU.</param>
        /// <param name="position">An offset into the Data array from which to begin buffering.</param>
        /// <param name="length">The length of the valid data in the data array.</param>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] data, int position, int length, BufferTarget target = BufferTarget.ArrayBuffer, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            length = MathHelper.Clamp(length, 0, data.Length);

            ID = GL.CreateVBO<T>(BufferTarget = target, data, hint, position, length);

            Size = (data is int[] ? 1 : (data is Vector2f[] ? 2 : (data is Vector3f[] ? 3 : (data is Vector4f[] ? 4 : 0))));
            PointerType = (data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            Count = length;

            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Creates a buffer object of type T.
        /// </summary>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] data, BufferTarget target = BufferTarget.ArrayBuffer, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            ID = GL.CreateVBO<T>(BufferTarget = target, data, hint);

            Size = (data is int[] ? 1 : (data is Vector2f[] ? 2 : (data is Vector3f[] ? 3 : (data is Vector4f[] ? 4 : 0))));
            PointerType = (data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            Count = data.Length;

            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Creates a static-read array buffer of type T.
        /// </summary>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        public VBO(T[] data)
            : this(data, BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw)
        {
        }

        /// <summary>
        /// Check to ensure that the VBO was disposed of properly.
        /// </summary>
        ~VBO()
        {
            Dispose(false);
        }

        #endregion

        #region BufferSubData

        /// <summary>
        /// Updates a subset of the buffer object's data store.
        /// </summary>
        /// <param name="data">The new data that will be copied to the data store.</param>
        public void BufferSubData(T[] data)
        {
            BufferSubData(data, Marshal.SizeOf(data[0]) * data.Length, 0);
        }

        /// <summary>
        /// Updates a subset of the buffer object's data store.
        /// </summary>
        /// <param name="data">The new data that will be copied to the data store.</param>
        /// <param name="size">The size in bytes of the data store region being replaced.</param>
        public void BufferSubData(T[] data, int size)
        {
            BufferSubData(data, size, 0);
        }

        /// <summary>
        /// Updates a subset of the buffer object's data store.
        /// </summary>
        /// <param name="data">The new data that will be copied to the data store.</param>
        /// <param name="size">The size in bytes of the data store region being replaced.</param>
        /// <param name="offset">The offset in bytes into the buffer object's data store where data replacement will begin.</param>
        public void BufferSubData(T[] data, int size, int offset)
        {
            if (BufferTarget != BufferTarget.ArrayBuffer && BufferTarget != BufferTarget.ElementArrayBuffer &&
                BufferTarget != BufferTarget.PixelPackBuffer && BufferTarget != BufferTarget.PixelUnpackBuffer)
                throw new InvalidOperationException($"BufferSubData cannot be called with a BufferTarget of type {BufferTarget.ToString()}");

            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                GL.BindVBO(this);
                GL.BufferSubData(BufferTarget, offset, size, handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Deletes this buffer from GPU memory.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (ID != 0)
            {
                GL.DeleteBuffer(ID);
                ID = 0;
            }
        }

        #endregion
    }
}