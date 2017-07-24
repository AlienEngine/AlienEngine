﻿using System;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Resources;

namespace AlienEngine.Graphics
{
    public class VBO<T> : IDisposable
        where T : struct
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
        /// <param name="Data">An array of data of type T (which must be a struct) that will be buffered to the GPU.</param>
        /// <param name="Length">The length of the valid data in the data array.</param>
        /// <param name="Target">Specifies the target buffer object.</param>
        /// <param name="Hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] Data, int Length, BufferTarget Target = BufferTarget.ArrayBuffer, BufferUsageHint Hint = BufferUsageHint.StaticDraw)
        {
            Length = System.Math.Max(0, System.Math.Min(Length, Data.Length));

            ID = GL.CreateVBO<T>(BufferTarget = Target, Data, Hint, Length);

            this.Size = (Data is int[] ? 1 : (Data is Vector2f[] ? 2 : (Data is Vector3f[] ? 3 : (Data is Vector4f[] ? 4 : 0))));
            this.PointerType = (Data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            this.Count = Length;
        }

        /// <summary>
        /// Creates a buffer object of type T with a specified length.
        /// This allows the array T[] to be larger than the actual size necessary to buffer.
        /// Useful for reusing resources and avoiding unnecessary GC action.
        /// </summary>
        /// <param name="Data">An array of data of type T (which must be a struct) that will be buffered to the GPU.</param>
        /// <param name="Position">An offset into the Data array from which to begin buffering.</param>
        /// <param name="Length">The length of the valid data in the data array.</param>
        /// <param name="Target">Specifies the target buffer object.</param>
        /// <param name="Hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] Data, int Position, int Length, BufferTarget Target = BufferTarget.ArrayBuffer, BufferUsageHint Hint = BufferUsageHint.StaticDraw)
        {
            Length = System.Math.Max(0, System.Math.Min(Length, Data.Length));

            ID = GL.CreateVBO<T>(BufferTarget = Target, Data, Hint, Position, Length);

            this.Size = (Data is int[] ? 1 : (Data is Vector2f[] ? 2 : (Data is Vector3f[] ? 3 : (Data is Vector4f[] ? 4 : 0))));
            this.PointerType = (Data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            this.Count = Length;

            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Creates a buffer object of type T.
        /// </summary>
        /// <param name="Data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        /// <param name="Target">Specifies the target buffer object.</param>
        /// <param name="Hint">Specifies the expected usage of the data store.</param>
        public VBO(T[] Data, BufferTarget Target = BufferTarget.ArrayBuffer, BufferUsageHint Hint = BufferUsageHint.StaticDraw)
        {
            ID = GL.CreateVBO<T>(BufferTarget = Target, Data, Hint);

            Size = (Data is int[] ? 1 : (Data is Vector2f[] ? 2 : (Data is Vector3f[] ? 3 : (Data is Vector4f[] ? 4 : 0))));
            PointerType = (Data is int[] ? VertexAttribPointerType.Int : VertexAttribPointerType.Float);
            Count = Data.Length;

            ResourcesManager.AddDisposableResource(this);
        }

        /// <summary>
        /// Creates a static-read array buffer of type T.
        /// </summary>
        /// <param name="Data">Specifies a pointer to data that will be copied into the data store for initialization.</param>
        public VBO(T[] Data)
            : this(Data, BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw)
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
                throw new InvalidOperationException(string.Format("BufferSubData cannot be called with a BufferTarget of type {0}", BufferTarget.ToString()));

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
