using AlienEngine.Core.Game;
using AlienEngine.Core.Graphics;
using AlienEngine.Core.Rendering;

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
        
        public Mesh Mesh
        {
            get { return _mesh; }
            set { _mesh = value; }
        }

        /// <summary>
        /// Create a new MeshRenderer with the given mesh.
        /// </summary>
        /// <param name="mesh">The <see cref="Mesh"/> to render.</param>
        public MeshRenderer(Mesh mesh)
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
