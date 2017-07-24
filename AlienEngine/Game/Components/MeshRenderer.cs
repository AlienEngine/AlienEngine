using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Graphics;
using AlienEngine.Graphics.Shaders;
using AlienEngine.Core.Game;

namespace AlienEngine
{
    public class MeshRenderer : Component, IRenderable
    {
        #region Fields
        private Mesh _mesh;
        private bool _visible = true;
        private Material _material;
        #endregion

        /// <summary>
        /// Gets or sets the current visible state of the mesh.
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        /// <summary>
        /// Create a new MeshRenderer with the given mesh and the
        /// associated shader program.
        /// </summary>
        /// <param name="mesh">The <see cref="Mesh"/> to render.</param>
        internal MeshRenderer(Mesh mesh)
        {
            _mesh = mesh;
        }

        public override void Start()
        {
            _material = GetComponent<Material>();
            Renderer.RegisterRenderable(this);
        }

        public void Render()
        {
            if (Enabled && Visible)
            {
                _material.Use();
                _mesh.Render();
            }
        }
    }
}
