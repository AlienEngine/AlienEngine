using System;
using AlienEngine.Core.Graphics.Buffers;

namespace AlienEngine.Core.Graphics
{
    /// <summary>
    /// Associates a <see cref="VAO"/> to a <see cref="MeshEntry"/>.
    /// </summary>
    public class Mesh : IDisposable
    {
        #region Private Fields

        private VAO _vao;

        private MeshEntry _entry;

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the <see cref="VAO"/> used by this <see cref="Mesh"/>.
        /// </summary>
        public VAO VAO => _vao;

        /// <summary>
        /// Gets the name of this <see cref="Mesh"/>.
        /// </summary>
        public string Name => _entry.Name;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Create a new <see cref="Mesh"/> with the given
        /// <see cref="VAO"/> and <see cref="MeshEntry"/>.
        /// </summary>
        /// <param name="vao">The <see cref="VAO"/> used by this mesh.</param>
        /// <param name="entry">The <see cref="MeshEntry"/> rendered by this mesh.</param>
        public Mesh(VAO vao, MeshEntry entry)
        {
            _vao = vao;
            _entry = entry;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Rnder the <see cref="MeshEntry"/> with the current <see cref="VAO"/>.
        /// </summary>
        public void Render()
        {
            _vao.Draw(_entry);
        }

        /// <summary>
        /// Release all resources used by the <see cref="Mesh"/>.
        /// </summary>
        public void Dispose()
        {
            _vao?.Dispose();
        }

        #endregion
    }
}