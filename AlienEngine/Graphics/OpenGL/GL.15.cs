#region Copyright and License
// Copyright (c) 2013-2014 The Khronos Group Inc.
// Copyright (c) of C# port 2014 by Shinta <shintadono@gooemail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and/or associated documentation files (the
// "Materials"), to deal in the Materials without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Materials, and to
// permit persons to whom the Materials are furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Materials.
//
// THE MATERIALS ARE PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.
#endregion

using System;
using System.Runtime.InteropServices;

namespace AlienEngine.Core.Graphics.OpenGL
{
    using Delegates;

    namespace Delegates
    {
        internal delegate void GenQuery(int one, out uint id);
        internal delegate void GenQueries(int count, uint[] ids);

        /// <summary>
        /// Releases <paramref name="count"/> many query-IDs.
        /// </summary>
        /// <param name="count">Number of query-IDs to be released.</param>
        /// <param name="ids">Array of query-IDs to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteQueries(int count, params uint[] ids);

        /// <summary>
        /// Determines if a name is a query-ID.
        /// </summary>
        /// <param name="id">The maybe query-ID.</param>
        /// <returns><b>true</b> if <paramref name="id"/> is a query-ID.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsQuery(uint id);

        /// <summary>
        /// Delimits the boundary of a query object.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="id">The query-ID to be used.</param>
        [CLSCompliant(false)]
        public delegate void BeginQuery(QueryTarget target, uint id);

        /// <summary>
        /// Delimits the boundary of a query object.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        public delegate void EndQuery(QueryTarget target);

        /// <summary>
        /// Returns the parameters of a query type.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="pname">A <see cref="GetQueryParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetQueryi(QueryTarget target, GetQueryParam pname, out int param);

        /// <summary>
        /// Returns the parameters of a query type.
        /// </summary>
        /// <param name="target">A <see cref="QueryTarget"/> specifying the type of query.</param>
        /// <param name="pname">A <see cref="GetQueryParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetQueryiv(QueryTarget target, GetQueryParam pname, int[] @params);

        internal delegate void GetQueryObjecti(uint id, GetQueryObjectParam pname, out int param);
        internal delegate void GetQueryObjectiv(uint id, GetQueryObjectParam pname, IntPtr @params);

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public delegate void GetQueryObjectui(uint id, GetQueryObjectParam pname, out uint param);

        internal delegate void GetQueryObjectuiv(uint id, GetQueryObjectParam pname, IntPtr @params);

        /// <summary>
        /// Binds a buffer object to a buffer target.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="buffer">The buffer name of the buffer object.</param>
        [CLSCompliant(false)]
        public delegate void BindBuffer(BufferTarget target, uint buffer);

        /// <summary>
        /// Releases <paramref name="count"/> many buffer names.
        /// </summary>
        /// <param name="count">Number of buffer names to be released.</param>
        /// <param name="buffers">Array of buffer names to be released.</param>
        [CLSCompliant(false)]
        public delegate void DeleteBuffers(int count, params uint[] buffers);

        internal delegate void GenBuffer(int one, out uint buffer);
        internal delegate void GenBuffers(int count, uint[] buffers);

        /// <summary>
        /// Determines if a name is a buffer name.
        /// </summary>
        /// <param name="buffer">The maybe buffer name.</param>
        /// <returns><b>true</b> if <paramref name="buffer"/> is a buffer name.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        [CLSCompliant(false)]
        public delegate bool IsBuffer(uint buffer);

        internal delegate void BufferData_32(BufferTarget target, int size, IntPtr data, BufferUsageHint usage);
        internal delegate void BufferData_64(BufferTarget target, long size, IntPtr data, BufferUsageHint usage);
        internal delegate void BufferSubData_32(BufferTarget target, int offset, int size, IntPtr data);
        internal delegate void BufferSubData_64(BufferTarget target, long offset, long size, IntPtr data);
        internal delegate void GetBufferSubData_32(BufferTarget target, int offset, int size, IntPtr data);
        internal delegate void GetBufferSubData_64(BufferTarget target, long offset, long size, IntPtr data);

        /// <summary>
        /// Maps a data store into client memory.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="access">A <see cref="BufferAccess"/> specifying the access.</param>
        /// <returns>The pointer to the data. Use result with Marshal.Copy(...); to access data.</returns>
        public delegate IntPtr MapBuffer(BufferTarget target, BufferAccess access);

        /// <summary>
        /// Releases a mapped data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <returns><b>true</b> unless the data store contents have become corrupt during the time the data store was mapped. If <b>false</b> is returned an application must reinitialize the data store.</returns>
        [return: MarshalAs(UnmanagedType.I1)]
        public delegate bool UnmapBuffer(BufferTarget target);

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        public delegate void GetBufferParameteri(BufferTarget target, BufferParameterName pname, out int param);

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="pname">A <see cref="BufferParameterName"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value(s).</param>
        public delegate void GetBufferParameteriv(BufferTarget target, BufferParameterName pname, int[] @params);

        /// <summary>
        /// Returns the pointer to a mapped data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="pname">Must be <see cref="BufferParameterName.BUFFER_MAP_POINTER"/>.</param>
        /// <param name="param">The pointer to the mapped data store.</param>
        public delegate void GetBufferPointerv(BufferTarget target, BufferParameterName pname, out IntPtr param);
    }

    public static partial class GL
    {
        /// <summary>
        /// Indicates if OpenGL version 1.5 is available.
        /// </summary>
        public static bool VERSION_1_5;

        #region Delegates
        private static GenQuery _GenQuery;
        private static GenQueries _GenQueries;

        /// <summary>
        /// Releases multiple query-IDs at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteQueries DeleteQueries;

        /// <summary>
        /// Determines if a name is a query-ID.
        /// </summary>
        [CLSCompliant(false)]
        public static IsQuery IsQuery;

        /// <summary>
        /// Delimits the boundary of a query object.
        /// </summary>
        [CLSCompliant(false)]
        public static BeginQuery BeginQuery;

        /// <summary>
        /// Delimits the boundary of a query object.
        /// </summary>
        public static EndQuery EndQuery;

        /// <summary>
        /// Returns the parameters of a query type.
        /// </summary>
        public static GetQueryi GetQueryi;

        /// <summary>
        /// Returns the parameters of a query type.
        /// </summary>
        public static GetQueryiv GetQueryiv;

        private static GetQueryObjecti _GetQueryObjecti;
        private static GetQueryObjectiv _GetQueryObjectiv;

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        [CLSCompliant(false)]
        public static GetQueryObjectui GetQueryObjectui;

        private static GetQueryObjectuiv _GetQueryObjectuiv;

        /// <summary>
        /// Binds a buffer object to a buffer target.
        /// </summary>
        public static BindBuffer BindBuffer;

        /// <summary>
        /// Releases multiple buffer names at once.
        /// </summary>
        [CLSCompliant(false)]
        public static DeleteBuffers DeleteBuffers;

        private static GenBuffer _GenBuffer;
        private static GenBuffers _GenBuffers;

        /// <summary>
        /// Determines if a name is a buffer name.
        /// </summary>
        [CLSCompliant(false)]
        public static IsBuffer IsBuffer;

        private static BufferData_32 BufferData_32;
        private static BufferData_64 BufferData_64;
        private static BufferSubData_32 BufferSubData_32;
        private static BufferSubData_64 BufferSubData_64;
        private static GetBufferSubData_32 GetBufferSubData_32;
        private static GetBufferSubData_64 GetBufferSubData_64;

        /// <summary>
        /// Maps a data store into client memory.
        /// </summary>
        public static MapBuffer MapBuffer;

        /// <summary>
        /// Releases a mapped data store.
        /// </summary>
        public static UnmapBuffer UnmapBuffer;

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        public static GetBufferParameteri GetBufferParameteri;

        /// <summary>
        /// Returns parameter of a buffer object.
        /// </summary>
        public static GetBufferParameteriv GetBufferParameteriv;

        /// <summary>
        /// Returns the pointer to a mapped data store.
        /// </summary>
        public static GetBufferPointerv GetBufferPointerv;
        #endregion

        #region Overloads
        #region GenQuery&GenQueries
        /// <summary>
        /// Generates one query-ID and returns it.
        /// </summary>
        /// <returns>The new query-ID.</returns>
        [CLSCompliant(false)]
        public static uint GenQuery()
        {
            uint ret;
            _GenQuery(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one query-ID and returns it.
        /// </summary>
        /// <param name="id">The new query-ID.</param>
        [CLSCompliant(false)]
        public static void GenQuery(out uint id)
        {
            _GenQuery(1, out id);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many query-IDs and returns them as array.
        /// </summary>
        /// <param name="count">The number of query-IDs to be generated.</param>
        /// <returns>The new query-IDs as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenQueries(int count)
        {
            uint[] ret = new uint[count];
            _GenQueries(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many query-IDs.
        /// </summary>
        /// <param name="count">The number of query-IDs to be generated.</param>
        /// <param name="ids">The array that will receive the new query-IDs.</param>
        [CLSCompliant(false)]
        public static void GenQueries(int count, uint[] ids)
        {
            _GenQueries(count, ids);
        }
        #endregion

        #region GenBuffer(s)
        /// <summary>
        /// Generates one buffer name and returns it.
        /// </summary>
        /// <returns>The new buffer name.</returns>
        public static uint GenBuffer()
        {
            uint ret;
            _GenBuffer(1, out ret);
            return ret;
        }

        /// <summary>
        /// Generates one buffer name and returns it.
        /// </summary>
        /// <param name="buffer">The new buffer name.</param>
        [CLSCompliant(false)]
        public static void GenBuffer(out uint buffer)
        {
            _GenBuffer(1, out buffer);
        }

        /// <summary>
        /// Generates <paramref name="count"/> many buffer names and returns them as array.
        /// </summary>
        /// <param name="count">The number of buffer names to be generated.</param>
        /// <returns>The new buffer names as array.</returns>
        [CLSCompliant(false)]
        public static uint[] GenBuffers(int count)
        {
            uint[] ret = new uint[count];
            _GenBuffers(count, ret);
            return ret;
        }

        /// <summary>
        /// Generates <paramref name="count"/> many buffer names.
        /// </summary>
        /// <param name="count">The number of buffer names to be generated.</param>
        /// <param name="buffers">The array that will receive the new buffer names.</param>
        [CLSCompliant(false)]
        public static void GenBuffers(int count, uint[] buffers)
        {
            _GenBuffers(count, buffers);
        }
        #endregion

        #region GetQueryObjecti
        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjecti(uint id, GetQueryObjectParam pname, out int param)
        {
            GetQueryObjecti(id, pname, out param);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjecti(uint id, GetQueryObjectParam pname, out bool param)
        {
            int value;
            GetQueryObjecti(id, pname, out value);
            param = value != GL.FALSE;
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">Must be <see cref="GetQueryObjectParam.QUERY_TARGET"/> specifying the parameter.</param>
        /// <param name="param">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjecti(uint id, GetQueryObjectParam pname, out QueryTarget param)
        {
            int value;
            GetQueryObjecti(id, pname, out value);
            param = (QueryTarget)value;
        }
        #endregion

        #region GetQueryObjectiv
        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectiv(uint id, GetQueryObjectParam pname, IntPtr @params)
        {
            _GetQueryObjectiv(id, pname, @params);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.QueryBuffer"/>.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectiv(uint id, GetQueryObjectParam pname, int offset)
        {
            _GetQueryObjectiv(id, pname, (IntPtr)offset);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.QueryBuffer"/>.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectiv(uint id, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetQueryObjectiv(id, pname, (IntPtr)offset);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectiv(uint id, GetQueryObjectParam pname, int[] @params)
        {
            GCHandle hParams = GCHandle.Alloc(@params, GCHandleType.Pinned);
            try
            {
                _GetQueryObjectiv(id, pname, hParams.AddrOfPinnedObject());
            }
            finally
            {
                hParams.Free();
            }
        }
        #endregion

        #region GetQueryObjectuiv
        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectuiv(uint id, GetQueryObjectParam pname, IntPtr @params)
        {
            _GetQueryObjectuiv(id, pname, @params);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.QUERY_BUFFER"/>.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectuiv(uint id, GetQueryObjectParam pname, int offset)
        {
            _GetQueryObjectuiv(id, pname, (IntPtr)offset);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="offset">The offset into the array bound to <see cref="BufferTarget.QUERY_BUFFER"/>.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectuiv(uint id, GetQueryObjectParam pname, long offset)
        {
            if (IntPtr.Size == 4 && ((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
            _GetQueryObjectuiv(id, pname, (IntPtr)offset);
        }

        /// <summary>
        /// Returns the parameters of a query.
        /// </summary>
        /// <param name="id">The query-ID.</param>
        /// <param name="pname">A <see cref="GetQueryObjectParam"/> specifying the parameter.</param>
        /// <param name="params">Returns the requested value.</param>
        [CLSCompliant(false)]
        public static void GetQueryObjectuiv(uint id, GetQueryObjectParam pname, uint[] @params)
        {
            GCHandle hParams = GCHandle.Alloc(@params, GCHandleType.Pinned);
            try
            {
                _GetQueryObjectuiv(id, pname, hParams.AddrOfPinnedObject());
            }
            finally
            {
                hParams.Free();
            }
        }
        #endregion

        #region BufferData
        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>IntPtr.Zero</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData<T>(BufferTarget target, int size, ref T data, BufferUsageHint usage) where T : struct
        {
            IntPtr _data = Marshal.AllocHGlobal(BlittableValueType<T>.Stride);
            Marshal.StructureToPtr(data, _data, false);
            if (IntPtr.Size == 4) BufferData_32(target, size, _data, usage);
            else BufferData_64(target, size, _data, usage);
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>IntPtr.Zero</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, IntPtr data, BufferUsageHint usage)
        {
            if (IntPtr.Size == 4) BufferData_32(target, size, data, usage);
            else BufferData_64(target, size, data, usage);
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>IntPtr.Zero</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, IntPtr data, BufferUsageHint usage)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                BufferData_32(target, (int)size, data, usage);
            }
            else BufferData_64(target, size, data, usage);
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, byte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, byte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, int size, sbyte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, long size, sbyte[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, short[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, short[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, int size, ushort[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, long size, ushort[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, int[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, int[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, int size, uint[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, long size, uint[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, long[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, long[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, int size, ulong[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        [CLSCompliant(false)]
        public static void BufferData(BufferTarget target, long size, ulong[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, float[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, float[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, int size, double[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Creates a data store (and loads data into it).
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="size">The size of the data store in bytes.</param>
        /// <param name="data">The data that will be loaded, or <b>null</b> if nothing is to be loaded.</param>
        /// <param name="usage">A <see cref="BufferUsageHint"/> specifying the usage of the data store.</param>
        public static void BufferData(BufferTarget target, long size, double[] data, BufferUsageHint usage)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferData(target, size, h.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h.Free();
            }
        }
        #endregion

        #region BufferSubData
        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, IntPtr data)
        {
            if (IntPtr.Size == 4) BufferSubData_32(target, offset, size, data);
            else BufferSubData_64(target, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                BufferSubData_32(target, (int)offset, (int)size, data);
            }
            else BufferSubData_64(target, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, int offset, int size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, long offset, long size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, int offset, int size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, long offset, long size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, int offset, int size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, long offset, long size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, int offset, int size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        [CLSCompliant(false)]
        public static void BufferSubData(BufferTarget target, long offset, long size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, int offset, int size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Updates a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The data that will be loaded.</param>
        public static void BufferSubData(BufferTarget target, long offset, long size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                BufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }
        #endregion

        #region GetBufferSubData
        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, IntPtr data)
        {
            if (IntPtr.Size == 4) GetBufferSubData_32(target, offset, size, data);
            else GetBufferSubData_64(target, offset, size, data);
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, IntPtr data)
        {
            if (IntPtr.Size == 4)
            {
                if (((long)offset >> 32) != 0) throw new ArgumentOutOfRangeException("offset", PlatformErrorString);
                if (((long)size >> 32) != 0) throw new ArgumentOutOfRangeException("size", PlatformErrorString);
                GetBufferSubData_32(target, (int)offset, (int)size, data);
            }
            else GetBufferSubData_64(target, offset, size, data);
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, byte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, int offset, int size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, long offset, long size, sbyte[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, short[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, int offset, int size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, long offset, long size, ushort[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, int[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, int offset, int size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, long offset, long size, uint[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, long[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, int offset, int size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        [CLSCompliant(false)]
        public static void GetBufferSubData(BufferTarget target, long offset, long size, ulong[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, float[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, int offset, int size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }

        /// <summary>
        /// Returns a subset of a data store.
        /// </summary>
        /// <param name="target">A <see cref="BufferTarget"/> specifying the target.</param>
        /// <param name="offset">The offset in bytes into the data store.</param>
        /// <param name="size">The size of the data store region in bytes.</param>
        /// <param name="data">The requested data.</param>
        public static void GetBufferSubData(BufferTarget target, long offset, long size, double[] data)
        {
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                GetBufferSubData(target, offset, size, h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }
        #endregion
        #endregion

        private static void Load_VERSION_1_5()
        {
            _GenQuery = GetAddress<GenQuery>("glGenQueries");
            _GenQueries = GetAddress<GenQueries>("glGenQueries");
            DeleteQueries = GetAddress<DeleteQueries>("glDeleteQueries");
            IsQuery = GetAddress<IsQuery>("glIsQuery");
            BeginQuery = GetAddress<BeginQuery>("glBeginQuery");
            EndQuery = GetAddress<EndQuery>("glEndQuery");
            GetQueryi = GetAddress<GetQueryi>("glGetQueryiv");
            GetQueryiv = GetAddress<GetQueryiv>("glGetQueryiv");
            _GetQueryObjecti = GetAddress<GetQueryObjecti>("glGetQueryObjectiv");
            _GetQueryObjectiv = GetAddress<GetQueryObjectiv>("glGetQueryObjectiv");
            GetQueryObjectui = GetAddress<GetQueryObjectui>("glGetQueryObjectuiv");
            _GetQueryObjectuiv = GetAddress<GetQueryObjectuiv>("glGetQueryObjectuiv");
            BindBuffer = GetAddress<BindBuffer>("glBindBuffer");
            DeleteBuffers = GetAddress<DeleteBuffers>("glDeleteBuffers");
            _GenBuffer = GetAddress<GenBuffer>("glGenBuffers");
            _GenBuffers = GetAddress<GenBuffers>("glGenBuffers");
            IsBuffer = GetAddress<IsBuffer>("glIsBuffer");
            MapBuffer = GetAddress<MapBuffer>("glMapBuffer");
            UnmapBuffer = GetAddress<UnmapBuffer>("glUnmapBuffer");
            GetBufferParameteri = GetAddress<GetBufferParameteri>("glGetBufferParameteriv");
            GetBufferParameteriv = GetAddress<GetBufferParameteriv>("glGetBufferParameteriv");
            GetBufferPointerv = GetAddress<GetBufferPointerv>("glGetBufferPointerv");

            bool platformDependend;
            if (IntPtr.Size == 4)
            {
                BufferData_32 = GetAddress<BufferData_32>("glBufferData");
                BufferSubData_32 = GetAddress<BufferSubData_32>("glBufferSubData");
                GetBufferSubData_32 = GetAddress<GetBufferSubData_32>("glGetBufferSubData");

                platformDependend = BufferData_32 != null && BufferSubData_32 != null && GetBufferSubData_32 != null;
            }
            else
            {
                BufferData_64 = GetAddress<BufferData_64>("glBufferData");
                BufferSubData_64 = GetAddress<BufferSubData_64>("glBufferSubData");
                GetBufferSubData_64 = GetAddress<GetBufferSubData_64>("glGetBufferSubData");

                platformDependend = BufferData_64 != null && BufferSubData_64 != null && GetBufferSubData_64 != null;
            }

            VERSION_1_5 = VERSION_1_4 && _GenQueries != null && DeleteQueries != null && IsQuery != null &&
                BeginQuery != null && EndQuery != null && GetQueryiv != null &&
                _GetQueryObjectiv != null && _GetQueryObjectuiv != null && BindBuffer != null &&
                DeleteBuffers != null && _GenBuffers != null && IsBuffer != null &&
                MapBuffer != null && UnmapBuffer != null && GetBufferParameteriv != null &&
                GetBufferPointerv != null && platformDependend;
        }
    }
}
