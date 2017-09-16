#region License
// Copyright (C) 2017 AlienGames
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
// USA
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AlienEngine
{
    /// <summary>
    /// Quaternion
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        /// <summary>
        ///
        /// </summary>
        private float _w;

        /// <summary>
        ///
        /// </summary>
        private float _x;

        /// <summary>
        ///
        /// </summary>
        private float _y;

        /// <summary>
        ///
        /// </summary>
        private float _z;

        /// <summary>
        /// The axis of the quaternion.
        /// </summary>
        public Vector3f XYZ
        {
            get { return new Vector3f(X, Y, Z); }
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        /// <summary>
        /// Gets or sets the X component of this instance.
        /// </summary>
        public float X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Gets or sets the Y component of this instance.
        /// </summary>
        public float Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Gets or sets the Z component of this instance.
        /// </summary>
        public float Z { get { return _z; } set { _z = value; } }

        /// <summary>
        /// Gets or sets the W component of this instance.
        /// </summary>
        public float W { get { return _w; } set { _w = value; } }

        /// <summary>
        /// Defines the identity quaternion.
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(1, 0, 0, 0);


        /// <summary>
        /// Defines the identity quaternion.
        /// </summary>
        public static readonly Quaternion Zero = new Quaternion(0, 0, 0, 0);

        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        internal Quaternion(float w, float x, float y, float z)
        {
            _w = w;
            _x = x; _y = y; _z = z;
        }

        /// <summary>
        /// Quaternion from a rotation angle and axis.
        /// </summary>
        /// <param name="angle">The angle in degrees</param>
        /// <param name="axis">The axis</param>
        public Quaternion(float angle, Vector3f axis)
        {
            Vector3f normalized = Vector3f.Normalize(axis);
            float halfRadian = angle * 0.5f;
            _w = MathHelper.Cos(halfRadian);
            float sin = MathHelper.Sin(halfRadian);
            _x = sin * normalized.X;
            _y = sin * normalized.Y;
            _z = sin * normalized.Z;
        }

        /// <summary>
        /// Alias for <see cref="Quaternion(float, Vector3f)"/>.
        /// </summary>
        /// <param name="angle">The angle in degrees</param>
        /// <param name="axis">The axis</param>
        public Quaternion(Vector3f axis, float angle) : this(angle, axis)
        { }

        /// <summary>
        /// Quaternion from a <see cref="Vector4f"/>.
        /// </summary>
        /// <remarks>This will just copy all the components in the <see cref="Vector4f"/> in the new <see cref="Quaternion"/></remarks>
        /// <param name="vec">The vector to copy</param>
        public Quaternion(Vector4f vec)
        {
            _x = vec.X;
            _y = vec.Y;
            _z = vec.Z;
            _w = vec.W;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Quaternion.
        /// </summary>
        public float this[int a]
        {
            get
            {
                return (a == 0) ? X : (a == 1) ? Y : (a == 3) ? Z : W;
            }
            set
            {
                if (a == 0) X = value;
                else if (a == 1) Y = value;
                else if (a == 2) Z = value;
                else W = value;
            }
        }

        /// <summary>
        /// Transform this quaternion to equivalent matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix3f ToRotationMatrix()
        {
            float ww = W * W;
            float xx = X * X;
            float yy = Y * Y;
            float zz = Z * Z;
            float wx = W * X;
            float wy = W * Y;
            float wz = W * Z;
            float xy = X * Y;
            float xz = X * Z;
            float yz = Y * Z;

            Matrix3f result = Matrix3f.Zero;

            result.Column0 = new Vector3f(
                2 * (xx + ww) - 1,
                2 * (xy + wz),
                2 * (xz - wy));
            result.Column1 = new Vector3f(
                2 * (xy - wz),
                2 * (yy + ww) - 1,
                2 * (yz + wx));
            result.Column2 = new Vector3f(
                2 * (xz + wy),
                2 * (yz - wx),
                2 * (zz + ww) - 1);

            return result;
        }

        /// <summary>
        /// Convert the current <see cref="Quaternion"/> to euler angles.
        /// </summary>
        public Vector3f ToEulerAngles()
        {
            float xsqr = X * X;
            float ysqr = Y * Y;
            float zsqr = Z * Z;

            float s = X * Y + Z * W;

            float x, y, z;

            float x1 = 2.0f * (W * X + Y * Z);
            float x2 = 1.0f - 2.0f * (xsqr + ysqr);
            x = MathHelper.Atan(x1, x2);

            float t = 2.0f * (W * Y - Z * X);
            t = ((t > 1.0f) ? 1.0f : t);
            t = ((t < -1.0f) ? -1.0f : t);
            y = MathHelper.Asin(t);

            float z1 = 2.0f * (W * Z + X * Y);
            float z2 = 1.0f - 2.0f * (ysqr + zsqr);
            z = MathHelper.Atan(z1, z2);

            return new Vector3f(x, y, z);
        }

        /// <summary>
        /// Convert the current <see cref="Quaternion"/> to euler angles.
        /// </summary>
        public void ToEulerAngles(out Vector3f angles)
        {
            angles = ToEulerAngles();
        }

        /// <summary>
        /// Convert the current quaternion to axis angle representation
        /// </summary>
        /// <param name="axis">The resultant axis</param>
        /// <param name="angle">The resultant angle</param>
        public void ToAxisAngle(out Vector3f axis, out float angle)
        {
            Vector4f result = ToAxisAngle();
            axis = result.XYZ;
            angle = result.W;
        }

        /// <summary>
        /// Convert this instance to an axis-angle representation.
        /// </summary>
        /// <returns>A Vector4f that is the axis-angle representation of this quaternion.</returns>
        public Vector4f ToAxisAngle()
        {
            Quaternion q = this;
            if (System.Math.Abs(q.W) > 1.0f)
                q.Normalize();

            Vector4f result = new Vector4f();

            result.W = 2.0f * MathHelper.Acos(q.W); // angle
            float den = MathHelper.Sqrt(1.0 - q.W * q.W);
            if (den > 0.0001f)
            {
                result.XYZ = q.XYZ / den;
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                result.XYZ = Vector3f.UnitX;
            }

            return result;
        }


        /// <summary>
        /// Gets the <see cref="Matrix4f"/> representation of this Quaternion.
        /// </summary>
        /// <value>The matrix4.</value>
        public Matrix4f Matrix4f
        {
            get
            {
                return new Matrix4f(
                    new Vector4f(1.0f - 2.0f * (Y * Y + Z * Z), 2.0f * (X * Y - W * Z), 2.0f * (X * Z + W * Y), 0.0f),
                    new Vector4f(2.0f * (X * Y + W * Z), 1.0f - 2.0f * (X * X + Z * Z), 2.0f * (Y * Z - W * X), 0.0f),
                    new Vector4f(2.0f * (X * Z - W * Y), 2.0f * (Y * Z + W * X), 1.0f - 2.0f * (X * X + Y * Y), 0.0f),
                    new Vector4f(0.0f, 0.0f, 0.0f, 1.0f));
            }
        }

        /// <summary>
        /// Gets the length (magnitude) of the quaternion.
        /// </summary>
        /// <seealso cref="LengthSquared"/>
        public float Length
        {
            get
            {
                return MathHelper.Sqrt(W * W + XYZ.LengthSquared);
            }
        }

        /// <summary>
        /// Gets the square of the quaternion length (magnitude).
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return W * W + XYZ.LengthSquared;
            }
        }

        /// <summary>
        /// Scales the Quaternion to unit length.
        /// </summary>
        public void Normalize()
        {
            float scale = 1.0f / this.Length;
            XYZ *= scale;
            W *= scale;
        }

        /// <summary>
        /// Convert this quaternion to its conjugate
        /// </summary>
        public void Conjugate()
        {
            XYZ = -XYZ;
        }

        /// <summary>
        /// Add two quaternions
        /// </summary>
        /// <param name="left">The first operand</param>
        /// <param name="right">The second operand</param>
        /// <returns>The result of the addition</returns>
        public static Quaternion Add(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.W + right.W, left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        /// <summary>
        /// Add two quaternions
        /// </summary>
        /// <param name="left">The first operand</param>
        /// <param name="right">The second operand</param>
        /// <param name="result">The result of the addition</param>
        public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result = Add(left, right);
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>The result of the operation.</returns>
        public static Quaternion Substract(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.W - right.W, left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Substract(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result = Substract(left, right);
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion Multiply(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <param name="result">A new instance containing the result of the calculation.</param>
        public static void Multiply(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result = new Quaternion(
                Vector4f.Dot(new Vector4f(left.W, -left.X, -left.Y, -left.Z), new Vector4f(right.W, right.X, right.Y, right.Z)),
                Vector4f.Dot(new Vector4f(left.X,  left.W,  left.Y, -left.Z), new Vector4f(right.W, right.X, right.Z, right.Y)),
                Vector4f.Dot(new Vector4f(left.Y,  left.W,  left.Z, -left.X), new Vector4f(right.W, right.Y, right.X, right.Z)),
                Vector4f.Dot(new Vector4f(left.Z,  left.W,  left.X, -left.Y), new Vector4f(right.W, right.Z, right.Y, right.X))
            );
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <param name="result">A new instance containing the result of the calculation.</param>
        public static void Multiply(ref Quaternion quaternion, float scale, out Quaternion result)
        {
            result = Multiply(quaternion, scale);
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion Multiply(Quaternion quaternion, float scale)
        {
            return new Quaternion(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
        }

        /// <summary>
        /// Multiplies an instance by a <see cref="Vector3f"/>.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="vector">The <see cref="Vector3f"/>.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion Multiply(Quaternion quaternion, Vector3f vector)
        {
            float _w = -quaternion.X * vector.X - quaternion.Y * vector.Y - quaternion.Z * vector.Z;
            float _x =  quaternion.W * vector.X + quaternion.Y * vector.Z - quaternion.Z * vector.Y;
            float _y =  quaternion.W * vector.Y + quaternion.Z * vector.X - quaternion.X * vector.Z;
            float _z =  quaternion.W * vector.Z + quaternion.X * vector.Y - quaternion.Y * vector.X;

            return new Quaternion(_w, _x, _y, _z);
        }

        /// <summary>
        /// Get the conjugate of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion</param>
        /// <returns>The conjugate of the given quaternion</returns>
        public static Quaternion Conjugate(Quaternion q)
        {
            return new Quaternion(q.W, -q.X, -q.Y, -q.Z);
        }

        /// <summary>
        /// Get the conjugate of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion</param>
        /// <param name="result">The conjugate of the given quaternion</param>
        public static void Conjugate(ref Quaternion q, out Quaternion result)
        {
            result = Conjugate(q);
        }

        /// <summary>
        /// Get the inverse of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion to invert</param>
        /// <returns>The inverse of the given quaternion</returns>
        public static Quaternion Invert(Quaternion q)
        {
            Quaternion result;
            Invert(ref q, out result);
            return result;
        }

        /// <summary>
        /// Get the inverse of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion to invert</param>
        /// <param name="result">The inverse of the given quaternion</param>
        public static void Invert(ref Quaternion q, out Quaternion result)
        {
            float lengthSq = q.LengthSquared;
            if (lengthSq != 0.0)
            {
                float i = 1.0f / lengthSq;
                result = new Quaternion(q.W * i, q.X * -i, q.Y * -i, q.Z * -i);
            }
            else
            {
                result = q;
            }
        }

        /// <summary>
        /// Scale the given quaternion to unit length
        /// </summary>
        /// <param name="q">The quaternion to normalize</param>
        /// <returns>The normalized quaternion</returns>
        public static Quaternion Normalize(Quaternion q)
        {
            Quaternion result;
            Normalize(ref q, out result);
            return result;
        }

        /// <summary>
        /// Scale the given quaternion to unit length
        /// </summary>
        /// <param name="q">The quaternion to normalize</param>
        /// <param name="result">The normalized quaternion</param>
        public static void Normalize(ref Quaternion q, out Quaternion result)
        {
            float scale = 1.0f / q.Length;
            result = new Quaternion(q.W * scale, q.X * scale, q.Y * scale, q.Z * scale);
        }

        /// <summary>
        /// Build a quaternion from the given axis and angle
        /// </summary>
        /// <param name="axis">The axis to rotate about</param>
        /// <param name="angle">The rotation angle in radians</param>
        /// <returns></returns>
        public static Quaternion FromAxisAngle(Vector3f axis, float angle)
        {
            if (axis.LengthSquared == 0.0f)
                return Identity;

            Quaternion result = Identity;

            angle *= 0.5f;
            axis.Normalize();
            result.XYZ = axis * MathHelper.Sin(angle);
            result.W = MathHelper.Cos(angle);

            return Normalize(result);
        }

        /// <summary>
        /// Build a quaternion from the given axis and angle
        /// </summary>
        /// <param name="axis">The axis to rotate about</param>
        /// <param name="angle">The rotation angle in radians</param>
        /// <returns></returns>
        public static Quaternion FromAxisAngle(float angle, Vector3f axis)
        {
            return FromAxisAngle(axis, angle);
        }

        /// <summary>
        /// Creates an orientation Quaternion given the 3 axis.
        /// </summary>
        /// <param name="Axis">An array of 3 axis.</param>
        public static Quaternion FromAxis(Vector3f xvec, Vector3f yvec, Vector3f zvec)
        {
            Matrix4f Rotation = new Matrix4f();

            Rotation.Column0 = new Vector4f(xvec, 0);
            Rotation.Column1 = new Vector4f(yvec, 0);
            Rotation.Column2 = new Vector4f(zvec, 0);
            Rotation.Column3 = Vector4f.UnitW;

            return FromRotationMatrix(Rotation);
        }

        /// <summary>
        /// Create a new <see cref="Quaternion"/> from euler angles.
        /// </summary>
        /// <param name="roll">The rotation angle on th X axis.</param>
        /// <param name="pitch">The rotation angle on th Y axis.</param>
        /// <param name="yaw">The rotation angle on th Z axis.</param>
        public static Quaternion FromEulerAngles(float roll, float pitch, float yaw)
        {
            Quaternion q = new Quaternion();

            float t0 = MathHelper.Cos(yaw * 0.5f);
            float t1 = MathHelper.Sin(yaw * 0.5f);
            float t2 = MathHelper.Cos(roll * 0.5f);
            float t3 = MathHelper.Sin(roll * 0.5f);
            float t4 = MathHelper.Cos(pitch * 0.5f);
            float t5 = MathHelper.Sin(pitch * 0.5f);

            q.W = t0 * t2 * t4 + t1 * t3 * t5;
            q.X = t0 * t3 * t4 - t1 * t2 * t5;
            q.Y = t0 * t2 * t5 + t1 * t3 * t4;
            q.Z = t1 * t2 * t4 - t0 * t3 * t5;

            return q;
        }

        /// <summary>
        /// Create a new <see cref="Quaternion"/> from euler angles.
        /// </summary>
        /// <param name="yawPitchRoll">The rotaion angles on all axis.</param>
        public static Quaternion FromEulerAngles(Vector3f yawPitchRoll)
        {
            return FromEulerAngles(yawPitchRoll.X, yawPitchRoll.Y, yawPitchRoll.Z);
        }

        /// <summary>
        /// Create a new <see cref="Quaternion"/> from euler angles.
        /// </summary>
        /// <param name="yaw">The rotation angle on th X axis.</param>
        /// <param name="pitch">The rotation angle on th Y axis.</param>
        /// <param name="roll">The rotation angle on th Z axis.</param>
        public static void FromEulerAngles(float yaw, float pitch, float roll, out Quaternion q)
        {
            q = FromEulerAngles(yaw, pitch, roll);
        }

        /// <summary>
        /// Create a new <see cref="Quaternion"/> from euler angles.
        /// </summary>
        /// <param name="yawPitchRoll">The rotaion angles on all axis.</param>
        public static void FromEulerAngles(Vector3f yawPitchRoll, out Quaternion q)
        {
            q = FromEulerAngles(yawPitchRoll);
        }

        private static readonly int[] _rotationLookup = new int[] { 1, 2, 0 };

        /// <summary>
        /// Creates an orientation Quaternion from a target Matrix4 rotational matrix.
        /// </summary>
        public static Quaternion FromRotationMatrix(Matrix4f rotation)
        {
            // Algorithm from Ken Shoemake's article in 1987 SIGGRAPH course notes
            // "Quaternion Calculus and Fast Animation"

            float t_trace = rotation[0].X + rotation[1].Y + rotation[2].Z;
            float t_root = 0.0f;
            Quaternion t_return = Quaternion.Zero;

            if (t_trace > 0.0)
            {   // |w| > 1/2
                t_root = MathHelper.Sqrt(t_trace + 1.0);
                t_return.W = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.X = (rotation[2].Y - rotation[1].Z) * t_root;
                t_return.Y = (rotation[0].Z - rotation[2].X) * t_root;
                t_return.Z = (rotation[1].X - rotation[0].Y) * t_root;
            }
            else
            {   // |w| <= 1/2

                int i = 0;
                if (rotation[1].Y > rotation[0].X) i = 1;
                if (rotation[2].Z > rotation[i][i]) i = 2;
                int j = _rotationLookup[i];
                int k = _rotationLookup[j];

                t_root = MathHelper.Sqrt(rotation[i][i] - rotation[j][j] - rotation[k][k] + 1.0f);
                t_return[i] = 0.5f * t_root;
                t_root = 0.5f / t_root;
                t_return.W = (rotation[k][j] - rotation[j][k]) * t_root;
                t_return[j] = (rotation[j][i] + rotation[i][j]) * t_root;
                t_return[k] = (rotation[k][i] + rotation[i][k]) * t_root;
            }

            if (t_return.X == 0 && t_return.Y == 0 && t_return.Z == 0)
                return new Quaternion(Vector4f.One);

            return Quaternion.Conjugate(t_return);
        }

        /// <summary>
        /// Do Spherical linear interpolation between two quaternions 
        /// </summary>
        /// <param name="q1">The first quaternion</param>
        /// <param name="q2">The second quaternion</param>
        /// <param name="blend">The blend factor</param>
        /// <returns>A smooth blend between the given quaternions</returns>
        public static Quaternion Slerp(Quaternion q1, Quaternion q2, float blend)
        {
            // if either input is zero, return the other.
            if (q1.LengthSquared == 0.0f)
            {
                if (q2.LengthSquared == 0.0f)
                {
                    return Identity;
                }
                return q2;
            }
            else if (q2.LengthSquared == 0.0f)
            {
                return q1;
            }


            float cosHalfAngle = q1.W * q2.W + Vector3f.Dot(q1.XYZ, q2.XYZ);

            if (cosHalfAngle >= 1.0f || cosHalfAngle <= -1.0f)
            {
                // angle = 0.0f, so just return one input.
                return q1;
            }
            else if (cosHalfAngle < 0.0f)
            {
                q2.XYZ = -q2.XYZ;
                q2.W = -q2.W;
                cosHalfAngle = -cosHalfAngle;
            }

            float blendA;
            float blendB;
            if (cosHalfAngle < 0.99f)
            {
                // do proper slerp for big angles
                float halfAngle = MathHelper.Acos(cosHalfAngle);
                float sinHalfAngle = MathHelper.Sin(halfAngle);
                float oneOverSinHalfAngle = 1.0f / sinHalfAngle;
                blendA = MathHelper.Sin(halfAngle * (1.0f - blend)) * oneOverSinHalfAngle;
                blendB = MathHelper.Sin(halfAngle * blend) * oneOverSinHalfAngle;
            }
            else
            {
                // do lerp if angle is really small.
                blendA = 1.0f - blend;
                blendB = blend;
            }

            Quaternion result = new Quaternion(blendA * q1.W + blendB * q2.W, blendA * q1.XYZ + blendB * q2.XYZ);
            if (result.LengthSquared > 0.0f)
                return Normalize(result);
            else
                return Identity;
        }

        /// <summary>
        /// Converts the given <see cref="Quaternion"/> to euler angles.
        /// </summary>
        /// <param name="quat">The <see cref="Quaternion"/> to convert</param>
        public static Vector3f ToEulerAngles(Quaternion quat)
        {
            return quat.ToEulerAngles();
        }

        /// <summary>
        /// Converts the given <see cref="Quaternion"/> to euler angles.
        /// </summary>
        /// <param name="quat">The <see cref="Quaternion"/> to convert</param>
        public static void ToEulerAngles(Quaternion quat, out Vector3f angles)
        {
            quat.ToEulerAngles(out angles);
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
            left.W += right.W;
            return left;
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion operator *(Quaternion quaternion, float scale)
        {
            return Multiply(quaternion, scale);
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion operator *(float scale, Quaternion quaternion)
        {
            return Multiply(quaternion, scale);
        }

        /// <summary>
        /// Multiplies an instance by a <see cref="Vector3f"/>.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="vector">The <see cref="Vector3f"/>.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion operator *(Quaternion quaternion, Vector3f vector)
        {
            return Multiply(quaternion, vector);
        }

        /// <summary>
        /// Multiplies an instance by a <see cref="Vector3f"/>.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="vector">The <see cref="Vector3f"/>.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion operator *(Vector3f vector, Quaternion quaternion)
        {
            return Multiply(quaternion, vector);
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Compares this object instance to another object for equality. 
        /// </summary>
        /// <param name="other">The other object to be used in the comparison.</param>
        /// <returns>True if both objects are Quaternions of equal value. Otherwise it returns false.</returns>
        public override bool Equals(object other)
        {
            return (other is Quaternion) && Equals((Quaternion)other);
        }

        /// <summary>
        /// Provides the hash code for this object. 
        /// </summary>
        /// <returns>A hash code formed from the bitwise XOR of this objects members.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Compares this Quaternion instance to another Quaternion for equality. 
        /// </summary>
        /// <param name="other">The other Quaternion to be used in the comparison.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        public bool Equals(Quaternion other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        /// <summary>
        /// Creates a quaternion from the vector should mostly be used for debuging
        /// purposes
        /// </summary>
        /// <param name='vector'>Vector.</param>
        /// <returns>The vector.</returns>
        public static Quaternion FromVector(Vector3f vector)
        {
            //not a constructor as it would be unclear what the vector would
            //be converted to ie a one or a zero in the last position 
            return new Quaternion(0.0f, vector);
        }

        /// <summary>
        /// Returns the <see cref="string"/> representation of this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}°, <{1}, {2}, {3}>", MathHelper.Acos(W) * 2 * 180.0f / MathHelper.Pi, X, Y, Z);
        }
    }
}