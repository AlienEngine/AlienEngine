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
            get { return _isChecked; }
            set
            {
                _isChecked = value;

                Click?.Invoke(value);

                if (value)
                    Checked?.Invoke();
                else
                    Unchecked?.Invoke();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The event trigerred when the checkbox is checked or unchecked.
        /// </summary>
        public event Action<bool> Click;

        /// <summary>
        /// The event trigerred when the checkbox is checked.
        /// </summary>
        public event Action Checked;

        /// <summary>
        /// The event trigerred when the checkbox is unchecked.
        /// </summary>
        public event Action Unchecked;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the checkbox.
        /// </summary>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Updates the checkbox on each frames.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (IsHover && Input.Released(MouseButton.Left))
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

        #region Dispose pattern

        private bool _disposedValue;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposedValue) return;

            if (disposing)
            {
                CheckedTexture?.Dispose();
                CheckedTexture = null;
            }

            _disposedValue = true;
        }

        #endregion
    }
}