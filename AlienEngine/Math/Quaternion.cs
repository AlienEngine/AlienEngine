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
        /// W component of the quaternion.
        /// </summary>
        public float W;

        /// <summary>
        /// X component of the quaternion.
        /// </summary>
        public float X;

        /// <summary>
        /// Y component of the quaternion.
        /// </summary>
        public float Y;

        /// <summary>
        /// Z component of the quaternion.
        /// </summary>
        public float Z;

        /// <summary>
        /// The axis of the quaternion.
        /// </summary>
        public Vector3f XYZ
        {
            get { return new Vector3f(X, Y, Z); }
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        /// <summary>
        /// Defines the identity quaternion.
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(1, 0, 0, 0);

        /// <summary>
        /// Defines the zero quaternion.
        /// </summary>
        public static readonly Quaternion Zero = new Quaternion(0, 0, 0, 0);

        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Quaternion(float w, float x, float y, float z)
        {
            W = w;
            X = x; Y = y; Z = z;
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
            W = MathHelper.Cos(halfRadian);
            float sin = MathHelper.Sin(halfRadian);
            X = sin * normalized.X;
            Y = sin * normalized.Y;
            Z = sin * normalized.Z;
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
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
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

            float den = MathHelper.Sqrt(1.0 - q.W * q.W);
            if (den > 0.0001f)
            {
                result.XYZ = q.XYZ / den;
                result.W = 2.0f * MathHelper.Acos(q.W); // angle
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                result.XYZ = Vector3f.UnitY;
                result.W = 0;
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
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// Convert this quaternion to its conjugate
        /// </summary>
        public void Conjugate()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        /// <summary>
        /// Computes the axis angle representation of a normalized quaternion.
        /// </summary>
        /// <param name="q">Quaternion to be converted.</param>
        /// <param name="axis">Axis represented by the quaternion.</param>
        /// <param name="angle">Angle around the axis represented by the quaternion.</param>
        public static void ToAxisAngle(ref Quaternion q, out Vector3f axis, out float angle)
        {
            q.ToAxisAngle(out axis, out angle);
        }

        /// <summary>
        /// Add two quaternions
        /// </summary>
        /// <param name="left">The first operand</param>
        /// <param name="right">The second operand</param>
        /// <returns>The result of the addition</returns>
        public static Quaternion Add(Quaternion left, Quaternion right)
        {
            Quaternion res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Add two quaternions
        /// </summary>
        /// <param name="left">The first operand</param>
        /// <param name="right">The second operand</param>
        /// <param name="result">The result of the addition</param>
        public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
            result.Z = left.Z + right.Z;
            result.W = left.W + right.W;
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
            float x = left.X;
            float y = left.Y;
            float z = left.Z;
            float w = left.W;
            float bX = right.X;
            float bY = right.Y;
            float bZ = right.Z;
            float bW = right.W;
            result.X = x * bW + bX * w + y * bZ - z * bY;
            result.Y = y * bW + bY * w + z * bX - x * bZ;
            result.Z = z * bW + bZ * w + x * bY - y * bX;
            result.W = w * bW - x * bX - y * bY - z * bZ;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <param name="result">A new instance containing the result of the calculation.</param>
        public static void Multiply(ref Quaternion quaternion, float scale, out Quaternion result)
        {
            result.X = quaternion.X * scale;
            result.Y = quaternion.Y * scale;
            result.Z = quaternion.Z * scale;
            result.W = quaternion.W * scale;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        public static Quaternion Multiply(Quaternion quaternion, float scale)
        {
            Quaternion result;
            Multiply(ref quaternion, scale, out result);
            return result;
        }

        /// <summary>
        /// Multiplies two quaternions together in opposite order.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Concatenate(ref Quaternion a, ref Quaternion b, out Quaternion result)
        {
            float aX = a.X;
            float aY = a.Y;
            float aZ = a.Z;
            float aW = a.W;
            float bX = b.X;
            float bY = b.Y;
            float bZ = b.Z;
            float bW = b.W;

            result.X = aW * bX + aX * bW + aZ * bY - aY * bZ;
            result.Y = aW * bY + aY * bW + aX * bZ - aZ * bX;
            result.Z = aW * bZ + aZ * bW + aY * bX - aX * bY;
            result.W = aW * bW - aX * bX - aY * bY - aZ * bZ;


        }

        /// <summary>
        /// Multiplies two quaternions together in opposite order.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Quaternion Concatenate(Quaternion a, Quaternion b)
        {
            Quaternion result;
            Concatenate(ref a, ref b, out result);
            return result;
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
            float _x = quaternion.W * vector.X + quaternion.Y * vector.Z - quaternion.Z * vector.Y;
            float _y = quaternion.W * vector.Y + quaternion.Z * vector.X - quaternion.X * vector.Z;
            float _z = quaternion.W * vector.Z + quaternion.X * vector.Y - quaternion.Y * vector.X;

            return new Quaternion(_w, _x, _y, _z);
        }

        /// <summary>
        /// Get the conjugate of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion</param>
        /// <returns>The conjugate of the given quaternion</returns>
        public static Quaternion Conjugate(Quaternion q)
        {
            Quaternion toReturn;
            Conjugate(ref q, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Get the conjugate of the given quaternion
        /// </summary>
        /// <param name="q">The quaternion</param>
        /// <param name="result">The conjugate of the given quaternion</param>
        public static void Conjugate(ref Quaternion q, out Quaternion result)
        {
            result = new Quaternion(q.W, -q.X, -q.Y, -q.Z);
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
        /// Creates a quaternion from an axis and angle.
        /// </summary>
        /// <param name="axis">Axis of rotation.</param>
        /// <param name="angle">Angle to rotate around the axis.</param>
        /// <param name="q">Quaternion representing the axis and angle rotation.</param>
        public static void FromAxisAngle(ref Vector3f axis, float angle, out Quaternion q)
        {
            if (axis.LengthSquared == 0.0f)
            {
                q = Identity;
                return;
            }

            Quaternion result = Identity;

            angle *= 0.5f;
            axis.Normalize();
            result.X = axis.X * MathHelper.Sin(angle);
            result.Y = axis.Y * MathHelper.Sin(angle);
            result.Z = axis.Z * MathHelper.Sin(angle);
            result.W = MathHelper.Cos(angle);

            q = Normalize(result);
        }

        /// <summary>
        /// Creates an orientation Quaternion given the 3 axis.
        /// </summary>
        /// <param name="Axis">An array of 3 axis.</param>
        public static Quaternion FromAxis(Vector3f xvec, Vector3f yvec, Vector3f zvec)
        {
            Matrix4f Rotation = new Matrix4f();

            Rotation.Right = xvec;
            Rotation.Up = yvec;
            Rotation.Backward = zvec;

            return FromRotationMatrix(Rotation);
        }

        /// <summary>
        /// Create a new <see cref="Quaternion"/> from euler angles.
        /// </summary>
        /// <param name="roll">The rotation angle on th X axis.</param>
        /// <param name="pitch">The rotation angle on th Y axis.</param>
        /// <param name="yaw">The rotation angle on th Z axis.</param>
        public static Quaternion FromEulerAngles(float yaw, float pitch, float roll)
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
        /// Creates a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="rotation">Rotation matrix used to create a new quaternion.</param>
        /// <returns>Quaternion representing the same rotation as the matrix.</returns>
        public static Quaternion FromRotationMatrix(Matrix3f rotation)
        {
            Quaternion toReturn;
            FromRotationMatrix(ref rotation, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Constructs a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="rotation">Rotation matrix to create the quaternion from.</param>
        /// <param name="quaternion">Quaternion based on the rotation matrix.</param>
        public static void FromRotationMatrix(ref Matrix4f rotation, out Quaternion quaternion)
        {
            Matrix3f downsizedMatrix;
            Matrix3f.FromMatrix4f(ref rotation, out downsizedMatrix);
            FromRotationMatrix(ref downsizedMatrix, out quaternion);
        }

        /// <summary>
        /// Constructs a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="rotation">Rotation matrix to create the quaternion from.</param>
        /// <param name="quaternion">Quaternion based on the rotation matrix.</param>
        public static void FromRotationMatrix(ref Matrix3f rotation, out Quaternion quaternion)
        {
            // Algorithm from Ken Shoemake's article in 1987 SIGGRAPH course notes
            // "Quaternion Calculus and Fast Animation"

            float t_trace = rotation[0].X + rotation[1].Y + rotation[2].Z;
            float t_root = 0.0f;
            Quaternion t_return = Zero;

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

            quaternion = Conjugate(t_return);
        }

        /// <summary>
        /// Creates an orientation Quaternion from a target Matrix4 rotational matrix.
        /// </summary>
        public static Quaternion FromRotationMatrix(Matrix4f rotation)
        {
            Quaternion toReturn;
            FromRotationMatrix(ref rotation, out toReturn);
            return toReturn;
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
            Quaternion res;
            Slerp(ref q1, ref q2, blend, out res);
            return res;
        }

        /// <summary>
        /// Do Spherical linear interpolation between two quaternions 
        /// </summary>
        /// <param name="q1">The first quaternion</param>
        /// <param name="q2">The second quaternion</param>
        /// <param name="blend">The blend factor</param>
        /// <returns>A smooth blend between the given quaternions</returns>
        public static void Slerp(ref Quaternion q1, ref Quaternion q2, float blend, out Quaternion result)
        {
            // if either input is zero, return the other.
            if (q1.LengthSquared == 0.0f)
            {
                if (q2.LengthSquared == 0.0f)
                {
                    result = Identity;
                    return;
                }
                result = q2;
                return;
            }

            if (q2.LengthSquared == 0.0f)
            {
                result = q1;
                return;
            }


            float cosHalfAngle = q1.W * q2.W + Vector3f.Dot(q1.XYZ, q2.XYZ);

            if (cosHalfAngle >= 1.0f || cosHalfAngle <= -1.0f)
            {
                // angle = 0.0f, so just return one input.
                result = q1;
                return;
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

            result = new Quaternion(blendA * q1.W + blendB * q2.W, blendA * q1.X + blendB * q2.X, blendA * q1.Y + blendB * q2.Y, blendA * q1.Z + blendB * q2.Z);
            if (result.LengthSquared > 0.0f)
                result.Normalize();
            else
                result = Identity;
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
        /// Negates the components of a quaternion.
        /// </summary>
        /// <param name="a">Quaternion to negate.</param>
        /// <param name="b">Negated result.</param>
        public static void Negate(ref Quaternion a, out Quaternion b)
        {
            b.X = -a.X;
            b.Y = -a.Y;
            b.Z = -a.Z;
            b.W = -a.W;
        }

        /// <summary>
        /// Negates the components of a quaternion.
        /// </summary>
        /// <param name="q">Quaternion to negate.</param>
        /// <returns>Negated result.</returns>
        public static Quaternion Negate(Quaternion q)
        {
            Quaternion result;
            Negate(ref q, out result);
            return result;
        }

        /// <summary>
        /// Computes the angle change represented by a normalized quaternion.
        /// </summary>
        /// <param name="q">Quaternion to be converted.</param>
        /// <returns>Angle around the axis represented by the quaternion.</returns>
        public static float GetAngleFromQuaternion(ref Quaternion q)
        {
            float qw = Math.Abs(q.W);
            if (qw > 1)
                return 0;
            return 2 * MathHelper.Acos(qw);
        }

        /// <summary>
        /// Computes the quaternion rotation between two normalized vectors.
        /// </summary>
        /// <param name="v1">First unit-length vector.</param>
        /// <param name="v2">Second unit-length vector.</param>
        /// <param name="q">Quaternion representing the rotation from v1 to v2.</param>
        public static void GetQuaternionBetweenNormalizedVectors(ref Vector3f v1, ref Vector3f v2, out Quaternion q)
        {
            float dot;
            Vector3f.Dot(ref v1, ref v2, out dot);
            //For non-normal vectors, the multiplying the axes length squared would be necessary:
            //float w = dot + (float)Math.Sqrt(v1.LengthSquared() * v2.LengthSquared());
            if (dot < -0.9999f) //parallel, opposing direction
            {
                //If this occurs, the rotation required is ~180 degrees.
                //The problem is that we could choose any perpendicular axis for the rotation. It's not uniquely defined.
                //The solution is to pick an arbitrary perpendicular axis.
                //Project onto the plane which has the lowest component magnitude.
                //On that 2d plane, perform a 90 degree rotation.
                float absX = Math.Abs(v1.X);
                float absY = Math.Abs(v1.Y);
                float absZ = Math.Abs(v1.Z);
                if (absX < absY && absX < absZ)
                    q = new Quaternion(0, 0, -v1.Z, v1.Y);
                else if (absY < absZ)
                    q = new Quaternion(0, -v1.Z, 0, v1.X);
                else
                    q = new Quaternion(0, -v1.Y, v1.X, 0);
            }
            else
            {
                Vector3f axis;
                Vector3f.Cross(ref v1, ref v2, out axis);
                q = new Quaternion(dot + 1, axis.X, axis.Y, axis.Z);
            }
            q.Normalize();
        }

        /// <summary>
        /// Computes the rotation from the start orientation to the end orientation such that end = Quaternion.Concatenate(start, relative).
        /// </summary>
        /// <param name="start">Starting orientation.</param>
        /// <param name="end">Ending orientation.</param>
        /// <param name="relative">Relative rotation from the start to the end orientation.</param>
        public static void GetRelativeRotation(ref Quaternion start, ref Quaternion end, out Quaternion relative)
        {
            Quaternion startInverse;
            Conjugate(ref start, out startInverse);
            Concatenate(ref startInverse, ref end, out relative);
        }

        /// <summary>
        /// Transforms the rotation into the local space of the target basis such that rotation = Quaternion.Concatenate(localRotation, targetBasis)
        /// </summary>
        /// <param name="rotation">Rotation in the original frame of reference.</param>
        /// <param name="targetBasis">Basis in the original frame of reference to transform the rotation into.</param>
        /// <param name="localRotation">Rotation in the local space of the target basis.</param>
        public static void GetLocalRotation(ref Quaternion rotation, ref Quaternion targetBasis, out Quaternion localRotation)
        {
            Quaternion basisInverse;
            Conjugate(ref targetBasis, out basisInverse);
            Concatenate(ref rotation, ref basisInverse, out localRotation);
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