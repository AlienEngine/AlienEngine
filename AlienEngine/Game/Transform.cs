using AlienEngine.Core.Game;
using System;

namespace AlienEngine
{
    public class Transform : IEquatable<Transform>
    {
        #region Private Fields

        private Vector3f _translation;
        private Vector3f _rotation;
        private Vector3f _scale;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the translation.
        /// </summary>
        public Point3f Position
        {
            get { return (Point3f)_translation; }
            set
            {
                Translation = Point3f.CreateVector(Point3f.Zero, value);
            }
        }

        /// <summary>
        /// Gets and sets the translation.
        /// </summary>
        public Vector3f Translation
        {
            get { return _translation; }
            set
            {
                Transform _oldT = this;
                Vector3f _old = _translation;
                _translation = value;
                OnPositionChange?.Invoke(_old, _translation);
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

        /// <summary>
        /// Get/set the forward vector of <see cref="GameElement"/>.
        /// </summary>
        public Vector3f ForwardVector
        {
            get
            {
                Vector3f forwardVector;
                Matrix4f transformation = GetTransformation();

                forwardVector.X = transformation[0, 2];
                forwardVector.Y = transformation[1, 2];
                forwardVector.Z = transformation[2, 2];

                return ((-forwardVector).Normalized);
            }
            set
            {
                Vector3f targetPosition = Translation + value.Normalized;
                LookAt(targetPosition);
            }
        }

        /// <summary>
        /// Get the right vector of this <see cref="GameElement"/>.
        /// </summary>
        public Vector3f RightVector
        {
            get
            {
                Vector3f rightVector;
                Matrix4f transformation = GetTransformation();

                rightVector.X = transformation[0, 0];
                rightVector.Y = transformation[1, 0];
                rightVector.Z = transformation[2, 0];

                return (rightVector.Normalized);
            }
        }

        /// <summary>
        /// Get/set the up vector of this <see cref="GameElement"/>.
        /// </summary>
        public Vector3f UpVector
        {
            get
            {
                Vector3f upVector;
                Matrix4f transformation = GetTransformation();

                upVector.X = transformation[0, 1];
                upVector.Y = transformation[1, 1];
                upVector.Z = transformation[2, 1];

                return (upVector.Normalized);
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
        /// Event triggered when the translation of this <see cref="GameElement"/> change.
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
        /// Event triggered when a value (rotation, translation, scale) of this <see cref="GameElement"/> change.
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
            SetTranslation(new Vector3f(0, 0, 0));
            SetRotation(new Vector3f(0, 0, 0));
            SetScale(new Vector3f(1, 1, 1));
        }

        internal Transform(Graphics.MeshTransformation transform)
        {
            SetTranslation(transform.Position);
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
            Matrix4f t = Matrix4f.CreateTranslation(_translation);
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
            Camera _camera = Game.CurrentScene.PrimaryCamera.GetComponent<Camera>();
            Matrix4f f = GetTransformation();
            Matrix4f v = _camera.ViewMatrix;
            Matrix4f p = _camera.ProjectionMatrix;
            //Matrix4f r = Matrix4f.Look(Camera.Forward, Camera.Up);
            //Matrix4f t = Matrix4f.CreateTranslation(Camera.Position);

            return f * v * p;//p * r * t * f;
        }

        /// <summary>
        /// Moves this <see cref="GameElement"/> in the given <paramref name="direction"/> with the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="direction">The direction to follow.</param>
        /// <param name="speed">The move speed.</param>
        public void Move(Vector3f direction, float speed = 1)
        {
            Translation += direction * speed;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around all axis with the given <paramref name="angles"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angles">The x, y and z angles of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void Rotate(Vector3f angles, float speed = 1)
        {
            Rotation += angles * speed;
        }

        /// <summary>
        /// Rotates this <see cref="GameElement"/> around the X axis with the given <paramref name="angle"/> and the given <paramref name="speed"/>.
        /// </summary>
        /// <param name="angle">The x angle of rotation.</param>
        /// <param name="speed">The rotation speed.</param>
        public void RotateX(float angle, float speed = 1)
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
        public void RotateY(float angle, float speed = 1)
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
        public void RotateZ(float angle, float speed = 1)
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
        public void Rescale(Vector3f additive, float speed = 1)
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
        /// Scales this <see cref="GameElement"/> with a <paramref name="factor"/> for all axis.
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
        /// Sets the translation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="translation">The new translation.</param>
        public void SetTranslation(Vector3f translation)
        {
            Translation = translation;
        }

        /// <summary>
        /// Sets the translation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="x">The new translation at the X axis.</param>
        /// <param name="y">The new translation at the Y axis.</param>
        /// <param name="z">The new translation at the Z axis.</param>
        public void SetTranslation(float x, float y, float z)
        {
            SetTranslation(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Sets the translation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="position">The new translation for all axis.</param>
        public void SetTranslation(float translation)
        {
            SetTranslation(new Vector3f(translation));
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
        /// Sets the rotation of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="angle">The new rotation angle for all axis.</param>
        public void SetRotation(float angle)
        {
            SetRotation(new Vector3f(angle));
        }

        /// <summary>
        /// Sets the rotation of this <see cref="GameElement"/> at the X axis.
        /// </summary>
        /// <param name="angle">The new rotation angle for the X axis.</param>
        public void SetRotationX(float angle)
        {
            SetRotation(new Vector3f(angle, Rotation.Y, Rotation.Z));
        }

        /// <summary>
        /// Sets the rotation of this <see cref="GameElement"/> at the Y axis.
        /// </summary>
        /// <param name="angle">The new rotation angle for the Y axis.</param>
        public void SetRotationY(float angle)
        {
            SetRotation(new Vector3f(Rotation.X, angle, Rotation.Z));
        }

        /// <summary>
        /// Sets the rotation of this <see cref="GameElement"/> at the Z axis.
        /// </summary>
        /// <param name="angle">The new rotation angle for the Z axis.</param>
        public void SetRotationZ(float angle)
        {
            SetRotation(new Vector3f(Rotation.X, Rotation.Y, angle));
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

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/>.
        /// </summary>
        /// <param name="scale">The new scale factor for all axis.</param>
        public void SetScale(float scale)
        {
            SetScale(new Vector3f(scale));
        }

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/> at the X axis.
        /// </summary>
        /// <param name="scale">The new scale factor for the X axis.</param>
        public void SetScaleX(float scale)
        {
            SetScale(new Vector3f(scale, Scale.Y, Scale.Z));
        }

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/> at the Y axis.
        /// </summary>
        /// <param name="scale">The new scale factor for the Y axis.</param>
        public void SetScaleY(float scale)
        {
            SetScale(new Vector3f(Scale.X, scale, Scale.Z));
        }

        /// <summary>
        /// Sets the scale of this <see cref="GameElement"/> at the Z axis.
        /// </summary>
        /// <param name="scale">The new scale factor for the Z axis.</param>
        public void SetScaleZ(float scale)
        {
            SetScale(new Vector3f(Scale.X, Scale.Y, scale));
        }

        /// <summary>
        /// Makes this <see cref="GameElement"/> look at the given <paramref name="targetPosition"/>.
        /// </summary>
        /// <param name="targetPosition">The target translation to look at.</param>
        public void LookAt(Point3f targetPosition)
        {
            Matrix4f lookAtMatrix = Matrix4f.LookAt(Position, targetPosition, UpVector);
            Matrix4f transformation = Matrix4f.CreateTranslation(Translation);
            Matrix4f ret = (lookAtMatrix * transformation);

            Rotation = ret.GetEulerAngles();
            //LookAt(Point3f.CreateVector(Position, targetPosition));
        }

        /// <summary>
        /// Makes this <see cref="GameElement"/> look at the given <paramref name="direction"/>.
        /// </summary>
        /// <param name="direction">The direction to look at.</param>
        public void LookAt(Vector3f direction)
        {
            Matrix4f lookAtMatrix = Matrix4f.LookAt(-direction, UpVector);
            Matrix4f transformation = Matrix4f.CreateTranslation(-Translation);
            Matrix4f ret = (lookAtMatrix * transformation);

            Rotation = ret.GetEulerAngles();
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
            return left.Translation == right.Translation && left.Rotation == right.Rotation && left.Scale == right.Scale;
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
            return Translation.GetHashCode() * Rotation.GetHashCode() * Scale.GetHashCode();
        }

        #endregion
    }
}
