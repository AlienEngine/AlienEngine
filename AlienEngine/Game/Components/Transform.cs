using AlienEngine.Core.Game;
using System;

namespace AlienEngine
{
    public class Transform : IEquatable<Transform>
    {
        #region Private Fields

        private Vector3f _position;
        private Vector3f _rotation;
        private Vector3f _scale;

        #endregion

        #region Properties

        private static Camera Camera
        {
            get { return Game.CurrentCamera.GetComponent<Camera>(); }
        }

        /// <summary>
        /// Gets and sets the position.
        /// </summary>
        public Vector3f Position
        {
            get { return _position; }
            set
            {
                Transform _oldT = this;
                Vector3f _old = _position;
                _position = value;
                OnPositionChange?.Invoke(_old, _position);
                OnAllChange?.Invoke(_oldT, this);
            }
        }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        public Vector3f Rotation
        {
            get { return _rotation; }
            set
            {
                Transform _oldT = this;
                Vector3f _old = _rotation;
                _rotation = value;
                OnRotationChange?.Invoke(_old, _rotation);
                OnAllChange?.Invoke(_oldT, this);
            }
        }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        public Vector3f Scale
        {
            get { return _scale; }
            set
            {
                Transform _oldT = this;
                Vector3f _old = _scale;
                _scale = value;
                OnScaleChange?.Invoke(_old, _scale);
                OnAllChange?.Invoke(_oldT, this);
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate used to handle changes on this <see cref="Transform"/>.
        /// </summary>
        /// <param name="_old">The old <see cref="Vector3f"/> state.</param>
        /// <param name="_new">The new <see cref="Vector3f"/> state (the current).</param>
        public delegate void OnChange(Vector3f _old, Vector3f _new);

        /// <summary>
        /// Delegate used to handle changes on this <see cref="Transform"/>.
        /// </summary>
        /// <param name="_old">The old <see cref="Transform"/> state.</param>
        /// <param name="_new">The new <see cref="Transform"/> state (the current).</param>
        public delegate void OnTransformChange(Transform _old, Transform _new);

        #endregion

        #region Events

        /// <summary>
        /// Event triggered when the position of this <see cref="GameElement"/> change.
        /// </summary>
        public event OnChange OnPositionChange;

        /// <summary>
        /// Event triggered when the scale of this <see cref="GameElement"/> change.
        /// </summary>
        public event OnChange OnScaleChange;

        /// <summary>
        /// Event triggered when the rotation of this <see cref="GameElement"/> change.
        /// </summary>
        public event OnChange OnRotationChange;

        /// <summary>
        /// Event triggered when the all the transformation of this <see cref="GameElement"/> change.
        /// </summary>
        public event OnTransformChange OnAllChange;

        /// <summary>
        /// Event triggered when a value (rotation, position, scale) of this <see cref="GameElement"/> change.
        /// </summary>
        public void AddOnChangeEvent(OnChange e)
        {
            OnPositionChange += e;
            OnRotationChange += e;
            OnScaleChange += e;
        }

        #endregion

        #region Constructors

        public Transform()
        {
            SetPosition(new Vector3f(0, 0, 0));
            SetRotation(new Vector3f(0, 0, 0));
            SetScale(new Vector3f(1, 1, 1));
        }

        internal Transform(Graphics.MeshTransformation transform)
        {
            SetPosition(transform.Position);
            SetRotation(transform.Rotation);
            SetScale(transform.Scale);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the transformation matrix of this <see cref="GameElement"/>.
        /// </summary>
        public Matrix4f GetTransformation()
        {
            Matrix4f t = Matrix4f.CreateTranslation(_position);
            Matrix4f r = Matrix4f.CreateRotation(_rotation);
            Matrix4f s = Matrix4f.CreateScale(_scale);

            return s * r * t;
        }

        /// <summary>
        /// Returns the projected transformation matrix of this <see cref="GameElement"/>.
        /// </summary>
        /// <returns></returns>
        public Matrix4f GetProjectedTransformation()
        {
            Matrix4f f = GetTransformation();
            Matrix4f v = Camera.ViewMatrix;
            Matrix4f p = Camera.ProjectionMatrix;
            //Matrix4f r = Matrix4f.Look(Camera.Forward, Camera.Up);
            //Matrix4f t = Matrix4f.CreateTranslation(Camera.Position);

            return f * v * p;//p * r * t * f;
        }

        /// <summary>
        /// Moves this <see cref="GameElement"/> in the given <paramref name="direction"/> with the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="direction">The direction to follow.</param>
        /// <param name="speed">The move speed.</param>
        public void Move(Vector3f direction, float speed)
        {
            Position += direction * speed;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around all axis with the given <paramref name="angles"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angles">The x, y and z angles of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void Rotate(Vector3f angles, float speed)
        {
            Rotation += angles * speed;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around the X axis with the given <paramref name="angle"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angle">The x angle of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void RotateX(float angle, float speed)
        {
            Vector3f rot = Rotation;
            rot.X += angle * speed;
            Rotation = rot;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around the Y axis with the given <paramref name="angle"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angle">The y angle of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void RotateY(float angle, float speed)
        {
            Vector3f rot = Rotation;
            rot.Y += angle * speed;
            Rotation = rot;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around the Z axis with the given <paramref name="angle"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angle">The z angle of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void RotateZ(float angle, float speed)
        {
            Vector3f rot = Rotation;
            rot.Z += angle * speed;
            Rotation = rot;
        }

        /// <summary>
        /// Scales this <see cref="GameElement"/> with additive method.
        /// </summary>
        /// <param name="additive">The amount of additive scale.</param>
        /// <param name="speed">The scaling speed.</param>
        public void Rescale(Vector3f additive, float speed)
        {
            Scale += additive * speed;
        }

        /// <summary>
        /// Scales this <see cref="GameElement"/> with a <paramref name="factor"/> for the X, Y, and Z axis.
        /// </summary>
        /// <param name="factor">The amount scale factor for each axis.</param>
        public void Rescale(Vector3f factor)
        {
            Scale *= factor;
        }

        /// <summary>
        /// Scales this <see cref="GameElement"/> with a <paramref name="factor"/> for all the axis.
        /// </summary>
        /// <param name="factor">The amount scale factor for all axis.</param>
        public void Rescale(float factor)
        {
            Scale *= factor;
        }

        /// <summary>
        /// Returns the <see cref="Quaternion"/> expression of this <see cref="Rotation"/>.
        /// </summary>
        public Quaternion ToQuaternionRotation()
        {
            return Quaternion.FromRotationMatrix(Matrix4f.CreateRotation(Rotation));
        }

        /// <summary>
        /// Sets the position of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="position">The new position.</param>
        public void SetPosition(Vector3f position)
        {
            Position = position;
        }

        /// <summary>
        /// Sets the position of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="x">The new position at the X axis.</param>
        /// <param name="y">The new position at the Y axis.</param>
        /// <param name="z">The new position at the Z axis.</param>
        public void SetPosition(float x, float y, float z)
        {
            SetPosition(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Sets the rotation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="rotation">The new rotation.</param>
        public void SetRotation(Vector3f rotation)
        {
            Rotation = rotation;
        }

        /// <summary>
        /// Sets the rotation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="x">The new rotation angle at the X axis.</param>
        /// <param name="y">The new rotation angle at the Y axis.</param>
        /// <param name="z">The new rotation angle at the Z axis.</param>
        public void SetRotation(float x, float y, float z)
        {
            SetRotation(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="scale">The new scale.</param>
        public void SetScale(Vector3f scale)
        {
            Scale = scale;
        }

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="x">The new scale factor at the X axis.</param>
        /// <param name="y">The new scale factor at the Y axis.</param>
        /// <param name="z">The new scale factor at the Z axis.</param>
        public void SetScale(float x, float y, float z)
        {
            SetScale(new Vector3f(x, y, z));
        }

        #endregion

        #region IEquatable Implementation

        /// <summary>
        /// Compare two <see cref="Transform"/> for equality.
        /// </summary>
        /// <param name="left">The first <see cref="Transform"/>.</param>
        /// <param name="right">The second <see cref="Transform"/>.</param>
        public static bool operator ==(Transform left, Transform right)
        {
            return left.Position == right.Position && left.Rotation == right.Rotation && left.Scale == right.Scale;
        }

        /// <summary>
        /// Compare two <see cref="Transform"/> for inequality.
        /// </summary>
        /// <param name="left">The first <see cref="Transform"/>.</param>
        /// <param name="right">The second <see cref="Transform"/>.</param>
        public static bool operator !=(Transform left, Transform right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compare this <see cref="Transform"/> with another.
        /// </summary>
        /// <param name="other">The other <see cref="Transform"/> to compare with.</param>
        public bool Equals(Transform other)
        {
            return this == other;
        }

        /// <summary>
        /// Compares this object instance to another object for equality. 
        /// </summary>
        /// <param name="other">The other object to be used in the comparison.</param>
        /// <returns>True if both objects are <see cref="Transform"/> of equal value. Otherwise it returns false.</returns>
        public override bool Equals(object other)
        {
            return (other is Transform) && Equals((Transform)other);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            return Position.GetHashCode() * Rotation.GetHashCode() * Scale.GetHashCode();
        }

        #endregion
    }
}
