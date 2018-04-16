using System;
using AlienEngine.Core.Game;
using AlienEngine.Core.Rendering;
using AlienEngine.Imaging;

namespace AlienEngine
{
    public class Camera : Component
    {
        #region Static members

        public static readonly Camera None =
            new Camera(Vector3f.Zero, Vector3f.Zero, 1.0f, 1.0f, 2.0f) {Viewport = Rectangle.Zero};

        #endregion

        #region Fields

        private ClearScreenTypes _clearScreenType = ClearScreenTypes.Color;
        private ProjectionTypes _projectionType = ProjectionTypes.Perspective;

        private Vector3f _forward;
        private Vector3f _up;

        private float _fov;
        private float _near;
        private float _far;

        private Matrix4f _projectionMatrix;
        private Matrix4f _viewMatrix;
        private Matrix4f _cubemapMatrix;

        private Rectangle _viewport;

        private Cubemap _cubemap;
        private Color4 _clearColor;

        private bool _isPrimary;

        private bool _shouldUpdate = false;

        #endregion

        #region Properties

        /// <summary>
        /// Method used to render clear screen.
        /// </summary>
        public ClearScreenTypes ClearScreenType
        {
            get { return _clearScreenType; }
            set { _clearScreenType = value; }
        }

        /// <summary>
        /// Projection method of the <see cref="Camera"/>.
        /// </summary>
        public ProjectionTypes ProjectionType
        {
            get { return _projectionType; }
            set
            {
                if (value != _projectionType)
                {
                    _projectionType = value;
                    _shouldUpdate = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the forward vector.
        /// </summary>
        public Vector3f Forward
        {
            get { return -_forward; }
            set
            {
                _forward = -value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets or sets the up vector.
        /// </summary>
        public Vector3f Up
        {
            get { return _up; }
            set
            {
                _up = value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets or sets the field of view angle (in degrees).
        /// </summary>
        public float FieldOfView
        {
            get { return MathHelper.Rad2Deg(_fov); }
            set
            {
                _fov = MathHelper.Deg2Rad(value);
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets or sets the near plane distance.
        /// </summary>
        public float Near
        {
            get { return _near; }
            set
            {
                _near = value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets or sets the far plane distance.
        /// </summary>
        public float Far
        {
            get { return _far; }
            set
            {
                _far = value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets or sets the viewport size.
        /// </summary>
        public Rectangle Viewport
        {
            get { return _viewport; }
            set
            {
                _viewport = value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// Gets the projection matrix.
        /// </summary>
        public Matrix4f ProjectionMatrix => _projectionMatrix;

        /// <summary>
        /// Gets the view matrix.
        /// </summary>
        public Matrix4f ViewMatrix => _viewMatrix;

        /// <summary>
        /// Gets the cubemap matrix.
        /// </summary>
        public Matrix4f CubemapMatrix => _cubemapMatrix;

        /// <summary>
        /// Gets the backward vector.
        /// </summary>
        public Vector3f Backward => -Forward;

        /// <summary>
        /// Gets the down vector.
        /// </summary>
        public Vector3f Down => -Up;

        /// <summary>
        /// Gets the left vector.
        /// </summary>
        public Vector3f Left
        {
            get
            {
                Vector3f left = _forward.Cross(_up);
                left.Normalize();
                return left;
            }
        }

        /// <summary>
        /// Gets the right vector.
        /// </summary>
        public Vector3f Right
        {
            get
            {
                Vector3f right = _up.Cross(_forward);
                right.Normalize();
                return right;
            }
        }

        /// <summary>
        /// Gets or sets the angles of rotations (yaw, pitch, and roll) around the X, Y and Z axis.
        /// </summary>
        public Vector3f RollPicthYaw
        {
            get { return gameElement.LocalTransform.Rotation; }
            set
            {
                gameElement.LocalTransform.Rotation = value;
                _shouldUpdate = true;
            }
        }

        /// <summary>
        /// The cubemmap rendered by this <see cref="Camera"/>.
        /// </summary>
        public Cubemap Cubemap
        {
            get { return _cubemap; }
            set
            {
                if (value != _cubemap)
                {
                    _cubemap = value;
                    if (Game.Instance.Running)
                        _cubemap.Load();
                }
            }
        }

        /// <summary>
        /// The clear color.
        /// </summary>
        public Color4 ClearColor
        {
            get { return _clearColor; }
            set { _clearColor = value; }
        }

        /// <summary>
        /// Defines if this <see cref="Camera"/> is the primary camera
        /// used by the <see cref="Game"/>.
        /// </summary>
        public bool IsPrimary
        {
            get { return _isPrimary; }
            set { _isPrimary = value; }
        }

        /// <summary>
        /// Gets the aspect ratio of this <see cref="Camera"/>.
        /// </summary>
        public float AspectRatio => (float) _viewport.Width / _viewport.Height;

        #endregion

        #region Constructors

        public Camera() : this(-Vector3f.UnitZ, Vector3f.UnitY, MathHelper.Deg2Rad(60f), 0.25f, 1000f)
        {
        }

        public Camera(Vector3f forward, Vector3f up, float fov, float near, float far)
        {
            _forward = forward;
            _up = up;
            _fov = fov;
            _near = near;
            _far = far;

            _up.Normalize();
            _forward.Normalize();

            if (gameElement != null)
            {
                gameElement.LocalTransform.OnAllChange += (_old, _new) => { _shouldUpdate = true; };
            }

            RendererManager.OnViewportChange += _onViewportChange;
        }

        private void _onViewportChange(object sender, ViewportChangedEventArgs viewportChangedEventArgs)
        {
            Viewport = viewportChangedEventArgs.New;
        }

        #endregion

        #region Methods

        private void _init()
        {
            Vector3f HTarget = new Vector3f(_forward.X, 0.0f, _forward.Z);
            HTarget.Normalize();

            if (HTarget.Z >= 0.0f)
            {
                if (HTarget.X >= 0.0f)
                    Pitch(MathHelper.Tau - MathHelper.Asin(HTarget.Z));
                else
                    Pitch(MathHelper.Pi + MathHelper.Asin(HTarget.Z));
            }
            else
            {
                if (HTarget.X >= 0.0f)
                    Pitch(MathHelper.Asin(-HTarget.Z));
                else
                    Pitch(MathHelper.Pi - MathHelper.Asin(-HTarget.Z));
            }

            Yaw(-MathHelper.Asin(_forward.Y));
        }

        /// <summary>
        /// Rotates the camera around the Z-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Yaw(float angle)
        {
            gameElement.LocalTransform.RotateZ(angle, 1);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Rotates the camera around the Z-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Yaw(double angle)
        {
            Yaw((float) angle);
        }

        /// <summary>
        /// Set the angle of rotation around the Z-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetYaw(float angle)
        {
            gameElement.LocalTransform.SetRotation(RollPicthYaw.X, RollPicthYaw.Y, angle);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Set the angle of rotation around the Z-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetYaw(double angle)
        {
            SetYaw((float) angle);
        }

        /// <summary>
        /// Rotates the camera around the Y-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Pitch(float angle)
        {
            gameElement.LocalTransform.RotateY(angle, 1);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Rotates the camera around the Y-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Pitch(double angle)
        {
            Pitch((float) angle);
        }

        /// <summary>
        /// Set the angle of rotation around the Y-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetPitch(float angle)
        {
            gameElement.LocalTransform.SetRotation(RollPicthYaw.X, angle, RollPicthYaw.Z);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Set the angle of rotation around the Y-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetPitch(double angle)
        {
            SetPitch((float) angle);
        }

        /// <summary>
        /// Rotates the camera around the X-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Roll(float angle)
        {
            gameElement.LocalTransform.RotateX(angle, 1);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Rotates the camera around the X-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void Roll(double angle)
        {
            Roll((float) angle);
        }

        /// <summary>
        /// Set the angle of rotation around the X-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetRoll(float angle)
        {
            gameElement.LocalTransform.SetRotation(angle, RollPicthYaw.Y, RollPicthYaw.Z);
            _shouldUpdate = true;
        }

        /// <summary>
        /// Set the angle of rotation around the X-axis.
        /// </summary>
        /// <param name="angle">The amount of rotation in radians</param>
        public void SetRoll(double angle)
        {
            SetRoll((float) angle);
        }

        /// <summary>
        /// Gets a ray from a screen position.
        /// </summary>
        /// <param name="position">The position at screen.</param>
        /// <returns>The projected ray.</returns>
        public Ray Ray(Point2f position)
        {
            Point2f normalizedCoords = new Point2f()
            {
                X = (2.0f * position.X) / Viewport.Width - 1.0f,
                Y = 1.0f - (2.0f * position.Y) / Viewport.Height
            };

            float vLength = MathHelper.Tan(MathHelper.Deg2Rad(FieldOfView) / 2) * Near;
            float hLength = vLength * AspectRatio;

            Vector3f v = Up * vLength;
            Vector3f h = Right * hLength;

            Vector3f camPos = gameElement.WorldTransform.Translation;
            Vector3f rayPos = camPos + Forward * Near + h * normalizedCoords.X + v * normalizedCoords.Y;
            Vector3f rayDir = rayPos - camPos;

            return new Ray(rayPos, rayDir);
        }

        public override void Start()
        {
            // _init();

            gameElement.LocalTransform.AddOnChangeEvent((_old, _new) => _shouldUpdate = true);

            Cubemap?.Load();

            _shouldUpdate = true;
        }

        public override void Update()
        {
            if (_shouldUpdate)
            {
                Vector3f Vaxis = Vector3f.UnitY;
                Vector3f View = -Vector3f.UnitZ;

                // Rotate the view vector by the horizontal angle around the vertical axis
                View = Vector3f.Rotate(View, RollPicthYaw.Y, Vaxis);
                View.Normalize();

                // Rotate the view vector by the vertical angle around the horizontal axis
                Vector3f Haxis = Vaxis.Cross(View);
                Haxis.Normalize();
                View.Rotate(RollPicthYaw.X, Haxis);
                View.Normalize();

                _forward = View;
                _forward.Normalize();

                _up = _forward.Cross(Haxis);
                _up.Normalize();

                // Rotate the up vector by the forward angle around the forward axis
                _up.Rotate(RollPicthYaw.Z, -_forward);
                _up.Normalize();

                // Update camera matrices
                _setProjectionMatrix();
                _setViewMatrix();
                _setCubemapMatrix();

                if (IsPrimary)
                {
                    RendererManager.CameraData.DepthDistances = new Vector2f(Near, Far);
                    RendererManager.CameraData.Position = gameElement.WorldTransform.Translation;
                    RendererManager.CameraData.Rotation = RollPicthYaw;

                    RendererManager.MatricesData.Projection = ProjectionMatrix;
                    RendererManager.MatricesData.InversedProjection = ProjectionMatrix.Inversed;
                    RendererManager.MatricesData.View = ViewMatrix;
                    RendererManager.MatricesData.InversedView = ViewMatrix.Inversed;
                    RendererManager.MatricesData.Cubemap = CubemapMatrix;
                }

                _shouldUpdate = false;
            }
        }

        /// <summary>
        /// Sets the viewport size of this <see cref="Camera"/>.
        /// </summary>
        /// <param name="size">The new viewport <see cref="Sizef"/>.</param>
        public void SetViewport(Rectangle size)
        {
            Viewport = size;
        }

        /// <summary>
        /// Sets the viewport width of this <see cref="Camera"/>.
        /// </summary>
        /// <param name="width">The new width.</param>
        public void SetViewportWidth(int width)
        {
            Sizei v = new Sizei(width, _viewport.Height);
            _viewport.Size = v;
        }

        /// <summary>
        /// Sets the viewport height of this <see cref="Camera"/>.
        /// </summary>
        /// <param name="height">The new height.</param>
        public void SetViewportHeight(int height)
        {
            Sizei v = new Sizei(_viewport.Width, height);
            _viewport.Size = v;
        }

        /// <summary>
        /// Makes this <see cref="Camera"/> as the primary
        /// camera renderer of the <see cref="Scene"/>.
        /// </summary>
        public void MakePrimary()
        {
            if (!IsPrimary && gameElement.ParentScene.PrimaryCamera != gameElement)
            {
                IsPrimary = true;
                gameElement.ParentScene.SetPrimaryCamera(gameElement);

                _shouldUpdate = true;
            }
        }

        private void _setProjectionMatrix()
        {
            switch (ProjectionType)
            {
                case ProjectionTypes.Perspective:
                    _projectionMatrix = Matrix4f.CreatePerspectiveFieldOfView(_fov, AspectRatio, _near, _far);
                    break;
                case ProjectionTypes.Orthogonal:
                    _projectionMatrix = Matrix4f.CreateOrthographic(_viewport.Width, _viewport.Height, _near, _far);
                    break;
                default:
                    throw new InvalidOperationException($"The projection type of this camera is invalid: {ProjectionType}");
            }
        }

        private void _setViewMatrix()
        {
            _viewMatrix = Matrix4f.CreateTranslation(-gameElement.WorldTransform.Translation) *
                          Matrix4f.LookAt(_forward, _up);
        }

        private void _setCubemapMatrix()
        {
            _cubemapMatrix = Matrix4f.LookAt(_forward, _up);
        }

        #endregion
    }
}