using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Core.Rendering;
using AlienEngine.Core.Resources;
using AlienEngine.Core.Shaders;

namespace AlienEngine.Core.Graphics.Buffers
{
    public class UBO : IDisposable
    {
        #region Fields

        /// <summary>
        /// Stores the uniform buffer object's id.
        /// </summary>
        private uint _ubo;

        /// <summary>
        /// Stores the uniform buffer object's index.
        /// </summary>
        private uint _index;

        /// <summary>
        /// Stores the name of this uniform buffer object.
        /// </summary>
        private string _name;

        #endregion

        #region Preperties

        /// <summary>
        /// The name of this uniform buffer object.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The index of this uniform buffer object.
        /// </summary>
        public uint Index => _index;

        #endregion

        #region Constructors

        public UBO(string name, UniformBufferObjectIndex index, int size) : this(name, (uint) index, size)
        {
        }

        public UBO(string name, uint index, int size)
        {
            _name = name;
            _index = index;

            // Generate uniform buffer object
            GL.GenBuffer(out _ubo);

            // Bind buffer
            GL.BindBuffer(BufferTarget.UniformBuffer, _ubo);

            // Set buffer data
            GL.BufferData(BufferTarget.UniformBuffer, size, IntPtr.Zero, BufferUsageHint.StaticDraw);

            // Ensure that the buffer is not modified from the outside
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            // Bind this ubo at the provided index
            GL.BindBufferBase(BufferTarget.UniformBuffer, _index, _ubo);

            // Add this resource as a disposable resource.
            ResourcesManager.AddDisposableResource(this);
        }

        #endregion

        #region Public members

        /// <summary>
        /// Sets a part of the uniform buffer object's data.
        /// </summary>
        /// <param name="offset">The offset on which we start to write data.</param>
        /// <param name="data">The data to write.</param>
        public void SetBufferSubData(int offset, ref Matrix4f data)
        {
            // Bind buffer
            GL.BindBuffer(BufferTarget.UniformBuffer, _ubo);

            // Set buffer data
            GL.BufferSubData(BufferTarget.UniformBuffer, offset, BlittableValueType<Matrix4f>.Stride, ref data);

            // Ensure that the buffer is not modified from the outside
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }

        /// <summary>
        /// Sets the entire uniform buffer object's data.
        /// </summary>
        /// <param name="data">The data to set in the ubo.</param>
        /// <typeparam name="T">
        /// A struct with <see cref="LayoutKind.Sequential"/> layout and with fields ordered
        /// in the same order than the shader's interface block.
        /// </typeparam>
        public void SetBufferData<T>(ref T data) where T : struct
        {
            // Bind buffer
            GL.BindBuffer(BufferTarget.UniformBuffer, _ubo);

            // Set buffer data
            GL.BufferData(BufferTarget.UniformBuffer, BlittableValueType<T>.Stride, ref data, BufferUsageHint.StaticDraw);

            // Ensure that the buffer is not modified from the outside
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }

        /// <summary>
        /// Binds a shader's uniform block to this buffer object.
        /// </summary>
        /// <param name="shader">The <see cref="ShaderProgram"/> to bind.</param>
        public void Bind(ShaderProgram shader)
        {
            var uboIndex = GL.GetUniformBlockIndex(shader.ID, _name);
            GL.UniformBlockBinding(shader.ID, uboIndex, _index);
        }

        #endregion

        #region Dispose pattern
        
        private void ReleaseUnmanagedResources()
        {
            if (_ubo != 0)
            {
                GL.DeleteBuffer(_ubo);
            }
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~UBO()
        {
            ReleaseUnmanagedResources();
        }
        
        #endregion
    }
}