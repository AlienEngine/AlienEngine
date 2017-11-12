using AlienEngine.Core.Rendering;
using AlienEngine.Imaging;
using System;

namespace AlienEngine
{
    public class Checkbox : UIComponent, IPostRenderable
    {
        #region Private Fields

        /// <summary>
        /// Defines if the checkbox is checked or not.
        /// </summary>
        private bool _isChecked;

        /// <summary>
        /// Define if the cursor is hover the checkbox.
        /// </summary>
        private bool _isHover;

        #endregion

        #region Public Fields

        /// <summary>
        /// The checkbox's <see cref="Color4"/> when it is checked.
        /// </summary>
        public Color4 CheckedColor;

        /// <summary>
        /// The checkbox's <see cref="Texture"/> when it is checked.
        /// </summary>
        public Texture CheckedTexture;

        /// <summary>
        /// Defines if the checkbox is checked or not.
        /// </summary>
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                Checked?.Invoke(value);
            }
        }

        /// <summary>
        /// Define if the cursor is hover the checkbox.
        /// </summary>
        public bool IsHover => _isHover;

        #endregion

        #region Events

        /// <summary>
        /// The event trigerred when the checkbox is checked or unchecked.
        /// </summary>
        public event Action<bool> Checked;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the checkbox.
        /// </summary>
        public override void Start()
        {
            InitUI();

            Input.AddMouseMoveEvent((sender, args) =>
            {
                _isHover = Enabled && !Input.MouseIsGrabbed && Rectangled.Contains(args.Location);
            });
        }

        /// <summary>
        /// Updates the checkbox on each frames.
        /// </summary>
        public override void Update()
        {
            if (_isHover && Input.Released(MouseButton.Left))
                IsChecked = !_isChecked;
        }

        /// <summary>
        /// Render the checkbox.
        /// </summary>
        public void Render()
        {
            if (BackgroundTexture == null)
                RenderColoredQuad(_isChecked ? CheckedColor : BackgroundColor);
            else
                RenderTexturedQuad(_isChecked ? CheckedTexture : BackgroundTexture);
        }

        #endregion
    }
}
