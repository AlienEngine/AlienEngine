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
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZeroFormatter;

namespace AlienEngine
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Vector3f>))]
    [StructLayout(LayoutKind.Sequential)]
    [ZeroFormattable]
    public struct Vector3f : IEquatable<Vector3f>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector3f.
        /// </summary>
        [Index(0)]
        public float X;

        /// <summary>
        /// The Y component of the Vector3f.
        /// </summary>
        [Index(1)]
        public float Y;

        /// <summary>
        /// The Z component of the Vector3f.
        /// </summary>
        [Index(2)]
        public float Z;

        /// <summary>
        /// Defines a unit-length Vector3f that points towards the X-axis.
        /// </summary>
        public static readonly Vector3f UnitX = new Vector3f(1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector3f that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3f UnitY = new Vector3f(0, 1, 0);

        /// <summary>
        /// /// Defines a unit-length Vector3f that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3f UnitZ = new Vector3f(0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector3f.
        /// </summary>
        public static readonly Vector3f Zero = new Vector3f(0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector3f One = new Vector3f(1);

        /// <summary>
        /// Defines the size of the Vector3f struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(float) * 3;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3f(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Constructs a new Vector3f.
        /// </summary>
        /// <param name="x">The x component of the Vector3f.</param>
        /// <param name="y">The y component of the Vector3f.</param>
        /// <param name="z">The z component of the Vector3f.</param>
        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector2ui.
        /// </summary>
        /// <param name="v">The Vector2ui to copy components from.</param>
        public Vector3f(Vector2ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector2i.
        /// </summary>
        /// <param name="v">The Vector2i to copy components from.</param>
        public Vector3f(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector2d.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector3f(Vector2d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = 0f;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector2f.
        /// </summary>
        /// <param name="v">The Vector2f to copy components from.</param>
        public Vector3f(Vector2f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector3ui.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        public Vector3f(Vector3ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector3i.
        /// </summary>
        /// <param name="v">The Vector3i to copy components from.</param>
        public Vector3f(Vector3i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector3d.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector3f(Vector3d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector3f.
        /// </summary>
        /// <param name="v">The Vector3f to copy components from.</param>
        public Vector3f(Vector3f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector4ui.
        /// </summary>
        /// <param name="v">The Vector4ui to copy components from.</param>
        public Vector3f(Vector4ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector4i.
        /// </summary>
        /// <param name="v">The Vector4i to copy components from.</param>
        public Vector3f(Vector4i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector4d.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector3f(Vector4d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
        }

        /// <summary>
        /// Constructs a new Vector3f from the given Vector4f.
        /// </summary>
        /// <param name="v">The Vector4f to copy components from.</param>
        public Vector3f(Vector4f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        public float this[int index]
        {
            get
            {
                if (index == 0)
                    return X;
                else if (index == 1)
                    return Y;
                else if (index == 2)
                    return Z;
                throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
            }
            set
            {
                if (index == 0)
                    X = value;
                else if (index == 1)
                    Y = value;
                else if (index == 2)
                    Z = value;
                throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
            }
        }

        /// <summary>
        /// Gets the length (magnitude) of the vector.
        /// </summary>
        /// <see cref="LengthFast"/>
        /// <seealso cref="LengthSquared"/>
        public float Length
        {
            get { return MathHelper.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Gets an approximation of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property uses an approximation of the square root function to calculate vector magnitude, with
        /// an upper error bound of 0.001.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthSquared"/>
        public float LengthFast
        {
            get { return 1.0f / MathHelper.InverseSqrtFast(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Gets the square of the vector length (magnitude).
        /// </summary>
        /// <remarks>
        /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
        /// for comparisons.
        /// </remarks>
        /// <see cref="Length"/>
        /// <seealso cref="LengthFast"/>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z; }
        }

        /// <summary>
        /// Gets the normalized instance of this <see cref="Vector3f"/>.
        /// </summary>
        public Vector3f Normalized
        {
            get { return Normalize(this); }
        }

        /// <summary>
        /// Scales the Vector3f to unit length.
        /// </summary>
        public void Normalize()
        {
            if (this != Vector3f.Zero)
            {
                float scale = 1.0f / this.Length;
                X *= scale;
                Y *= scale;
                Z *= scale;
            }
        }

        /// <summary>
        /// Scales the Vector3f to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            float scale = MathHelper.InverseSqrtFast(X * X + Y * Y + Z * Z);
            X *= scale;
            Y *= scale;
            Z *= scale;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors
        /// </summary>
        /// <param name="other">The second vector</param>
        /// <returns>The dot product of the two inputs</returns>
        public float Dot(Vector3f other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        /// <summary>
        /// Caclulate the cross (vector) product of two vectors
        /// </summary>
        /// <param name="other">The second vector</param>
        /// <returns>The cross product of the two inputs</returns>
        public Vector3f Cross(Vector3f other)
        {
            return new Vector3f(
                Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X
            );
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        public void Truncate()
        {
            this = Truncate(this);
        }

        /// <summary>
        /// Rotate a vector by an angle.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <param name="axis">The axis used for rotation.</param>
        /// <returns>The result of the operation.</returns>
        public void Rotate(float angle, Vector3f axis)
        {
            this = Rotate(this, angle, axis);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        public static Vector3f Add(Vector3f a, Vector3f b)
        {
            Vector3f res;
            Add(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <param name="result">Result of operation.</param>
        public static void Add(ref Vector3f a, ref Vector3f b, out Vector3f result)
        {
            result = new Vector3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector3f Subtract(Vector3f a, Vector3f b)
        {
            Vector3f res;
            Subtract(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">Result of subtraction</param>
        public static void Subtract(ref Vector3f a, ref Vector3f b, out Vector3f result)
        {
            result = new Vector3f(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector3f Multiply(Vector3f vector, float scale)
        {
            Vector3f res;
            Multiply(ref vector, scale, out res);
            return res;
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector3f vector, float scale, out Vector3f result)
        {
            result = new Vector3f(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector3f Multiply(Vector3f vector, Vector3f scale)
        {
            Vector3f res;
            Multiply(ref vector, ref scale, out res);
            return res;
        }

        /// <summary>
        /// Multiplies a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector3f vector, ref Vector3f scale, out Vector3f result)
        {
            result = new Vector3f(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z);
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector3f Divide(Vector3f vector, float scale)
        {
            Vector3f res;
            Divide(ref vector, scale, out res);
            return res;
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector3f vector, float scale, out Vector3f result)
        {
            Multiply(ref vector, 1 / scale, out result);
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector3f Divide(Vector3f vector, Vector3f scale)
        {
            Vector3f res;
            Divide(ref vector, ref scale, out res);
            return res;
        }

        /// <summary>
        /// Divide a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector3f vector, ref Vector3f scale, out Vector3f result)
        {
            result = new Vector3f(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z);
        }

        /// <summary>
        /// Computes the squared distance between two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Squared distance between the two vectors.</returns>
        public static float DistanceSquared(Vector3f a, Vector3f b)
        {
            float res;
            DistanceSquared(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Computes the squared distance between two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="distanceSquared">Squared distance between the two vectors.</param>
        public static void DistanceSquared(ref Vector3f a, ref Vector3f b, out float distanceSquared)
        {
            float x = a.X - b.X;
            float y = a.Y - b.Y;
            float z = a.Z - b.Z;
            distanceSquared = x * x + y * y + z * z;
        }

        /// <summary>
        /// Computes the distance between two two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Distance between the two vectors.</returns>
        public static float Distance(Vector3f a, Vector3f b)
        {
            float toReturn;
            Distance(ref a, ref b, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Computes the distance between two two vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="distance">Distance between the two vectors.</param>
        public static void Distance(ref Vector3f a, ref Vector3f b, out float distance)
        {
            float x = a.X - b.X;
            float y = a.Y - b.Y;
            float z = a.Z - b.Z;
            distance = MathHelper.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Negates a vector.
        /// </summary>
        /// <param name="v">Vector to negate.</param>
        /// <param name="negated">Negated vector.</param>
        public static Vector3f Negate(Vector3f v)
        {
            Vector3f res;
            Negate(ref v, out res);
            return res;
        }

        /// <summary>
        /// Negates a vector.
        /// </summary>
        /// <param name="v">Vector to negate.</param>
        /// <param name="negated">Negated vector.</param>
        public static void Negate(ref Vector3f v, out Vector3f negated)
        {
            negated.X = -v.X;
            negated.Y = -v.Y;
            negated.Z = -v.Z;
        }

        /// <summary>
        /// Creates a vector from the lesser values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <returns>Vector containing the lesser values of each vector.</returns>
        public static Vector3f ComponentMin(Vector3f a, Vector3f b)
        {
            Vector3f result;
            ComponentMin(ref a, ref b, out result);
            return result;
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise minimum</param>
        public static void ComponentMin(ref Vector3f a, ref Vector3f b, out Vector3f result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
            result.Z = a.Z < b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Creates a vector from the greater values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <returns>Vector containing the greater values of each vector.</returns>
        public static Vector3f ComponentMax(Vector3f a, Vector3f b)
        {
            Vector3f result;
            ComponentMax(ref a, ref b, out result);
            return result;
        }

        /// <summary>
        /// Calculate the component-wise maximum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise maximum</param>
        public static void ComponentMax(ref Vector3f a, ref Vector3f b, out Vector3f result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
        }

        /// <summary>
        /// Returns the Vector3f with the minimum magnitude
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>The minimum Vector3f</returns>
        public static Vector3f Min(Vector3f left, Vector3f right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector3f with the minimum magnitude
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>The minimum Vector3f</returns>
        public static Vector3f Max(Vector3f left, Vector3f right)
        {
            return left.LengthSquared >= right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors
        /// </summary>
        /// <param name="vec">Input vector</param>
        /// <param name="min">Minimum vector</param>
        /// <param name="max">Maximum vector</param>
        /// <returns>The clamped vector</returns>
        public static Vector3f Clamp(Vector3f vec, Vector3f min, Vector3f max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            vec.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors
        /// </summary>
        /// <param name="vec">Input vector</param>
        /// <param name="min">Minimum vector</param>
        /// <param name="max">Maximum vector</param>
        /// <param name="result">The clamped vector</param>
        public static void Clamp(ref Vector3f vec, ref Vector3f min, ref Vector3f max, out Vector3f result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector3f Normalize(Vector3f vec)
        {
            if (vec != Vector3f.Zero)
            {
                float scale = 1.0f / vec.Length;
                vec.X *= scale;
                vec.Y *= scale;
                vec.Z *= scale;
            }

            return vec;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void Normalize(ref Vector3f vec, out Vector3f result)
        {
            float scale = 1.0f / vec.Length;
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector3f NormalizeFast(Vector3f vec)
        {
            float scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void NormalizeFast(ref Vector3f vec, out Vector3f result)
        {
            float scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The dot product of the two inputs</returns>
        public static float Dot(Vector3f left, Vector3f right)
        {
            float res;
            Dot(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The dot product of the two inputs</param>
        public static void Dot(ref Vector3f left, ref Vector3f right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        /// <summary>
        /// Caclulate the cross (vector) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The cross product of the two inputs</returns>
        public static Vector3f Cross(Vector3f left, Vector3f right)
        {
            Vector3f result;
            Cross(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Caclulate the cross (vector) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The cross product of the two inputs</returns>
        /// <param name="result">The cross product of the two inputs</param>
        public static void Cross(ref Vector3f left, ref Vector3f right, out Vector3f result)
        {
            result = new Vector3f(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X
            );
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise</returns>
        public static Vector3f Lerp(Vector3f a, Vector3f b, float blend)
        {
            Vector3f toReturn;
            Lerp(ref a, ref b, blend, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise</param>
        public static void Lerp(ref Vector3f a, ref Vector3f b, float blend, out Vector3f result)
        {
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
            result.Z = blend * (b.Z - a.Z) + a.Z;
        }

        /// <summary>
        /// Computes an intermediate location using hermite interpolation.
        /// </summary>
        /// <param name="value1">First position.</param>
        /// <param name="tangent1">Tangent associated with the first position.</param>
        /// <param name="value2">Second position.</param>
        /// <param name="tangent2">Tangent associated with the second position.</param>
        /// <param name="interpolationAmount">Amount of the second point to use.</param>
        /// <returns>Interpolated intermediate state.</returns>
        public static Vector3f Hermite(Vector3f value1, Vector3f tangent1, Vector3f value2, Vector3f tangent2, float interpolationAmount)
        {
            Vector3f toReturn;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, interpolationAmount, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Computes an intermediate location using hermite interpolation.
        /// </summary>
        /// <param name="value1">First position.</param>
        /// <param name="tangent1">Tangent associated with the first position.</param>
        /// <param name="value2">Second position.</param>
        /// <param name="tangent2">Tangent associated with the second position.</param>
        /// <param name="interpolationAmount">Amount of the second point to use.</param>
        /// <param name="result">Interpolated intermediate state.</param>
        public static void Hermite(ref Vector3f value1, ref Vector3f tangent1, ref Vector3f value2, ref Vector3f tangent2, float interpolationAmount, out Vector3f result)
        {
            float weightSquared = interpolationAmount * interpolationAmount;
            float weightCubed = interpolationAmount * weightSquared;
            float value1Blend = 2 * weightCubed - 3 * weightSquared + 1;
            float tangent1Blend = weightCubed - 2 * weightSquared + interpolationAmount;
            float value2Blend = -2 * weightCubed + 3 * weightSquared;
            float tangent2Blend = weightCubed - weightSquared;
            result.X = value1.X * value1Blend + value2.X * value2Blend + tangent1.X * tangent1Blend + tangent2.X * tangent2Blend;
            result.Y = value1.Y * value1Blend + value2.Y * value2Blend + tangent1.Y * tangent1Blend + tangent2.Y * tangent2Blend;
            result.Z = value1.Z * value1Blend + value2.Z * value2Blend + tangent1.Z * tangent1Blend + tangent2.Z * tangent2Blend;
        }

        /// <summary>
        /// Interpolate 3 Vectors using Barycentric coordinates
        /// </summary>
        /// <param name="a">First input Vector</param>
        /// <param name="b">Second input Vector</param>
        /// <param name="c">Third input Vector</param>
        /// <param name="u">First Barycentric Coordinate</param>
        /// <param name="v">Second Barycentric Coordinate</param>
        /// <returns>a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise</returns>
        public static Vector3f BaryCentric(Vector3f a, Vector3f b, Vector3f c, float u, float v)
        {
            return a + u * (b - a) + v * (c - a);
        }

        /// <summary>Interpolate 3 Vectors using Barycentric coordinates</summary>
        /// <param name="a">First input Vector.</param>
        /// <param name="b">Second input Vector.</param>
        /// <param name="c">Third input Vector.</param>
        /// <param name="u">First Barycentric Coordinate.</param>
        /// <param name="v">Second Barycentric Coordinate.</param>
        /// <param name="result">Output Vector. a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise</param>
        public static void BaryCentric(ref Vector3f a, ref Vector3f b, ref Vector3f c, float u, float v, out Vector3f result)
        {
            result = a; // copy

            Vector3f temp = b; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, u, out temp);
            Add(ref result, ref temp, out result);

            temp = c; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, v, out temp);
            Add(ref result, ref temp, out result);
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a row vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Row vector product of the transformation.</param>
        public static void Transform(ref Vector2f v, ref Matrix2x3f matrix, out Vector3f result)
        {
            result = new Vector3f();
            result.X = v.X * matrix.M11 + v.Y * matrix.M21;
            result.Y = v.X * matrix.M12 + v.Y * matrix.M22;
            result.Z = v.X * matrix.M13 + v.Y * matrix.M23;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a row vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Row vector product of the transformation.</param>
        public static Vector3f Transform(Vector2f v, Matrix2x3f matrix)
        {
            var result = new Vector3f();
            Transform(ref v, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a column vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Column vector product of the transformation.</param>
        public static void Transform(ref Vector2f v, ref Matrix3x2f matrix, out Vector3f result)
        {
            result = new Vector3f();
            result.X = matrix.M11 * v.X + matrix.M12 * v.Y;
            result.Y = matrix.M21 * v.X + matrix.M22 * v.Y;
            result.Z = matrix.M31 * v.X + matrix.M32 * v.Y;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a row vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Row vector product of the transformation.</param>
        public static Vector3f Transform(Vector2f v, Matrix3x2f matrix)
        {
            var result = new Vector3f();
            Transform(ref v, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <returns>Product of the transformation.</returns>
        public static Vector3f Transform(Vector3f v, Matrix3f matrix)
        {
            Vector3f result;
            Transform(ref v, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Product of the transformation.</param>
        public static void Transform(ref Vector3f v, ref Matrix3f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;

            result = new Vector3f();
            result.X = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31;
            result.Y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32;
            result.Z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33;
        }

        /// <summary>
        /// Transforms the vector by the matrix's transpose.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation transpose.</param>
        /// <returns>Product of the transformation.</returns>
        public static Vector3f TransformTranspose(Vector3f v, Matrix3f matrix)
        {
            Vector3f result;
            TransformTranspose(ref v, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms the vector by the matrix's transpose.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation transpose.</param>
        /// <param name="result">Product of the transformation.</param>
        public static void TransformTranspose(ref Vector3f v, ref Matrix3f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;

            result = new Vector3f();
            result.X = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13;
            result.Y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23;
            result.Z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void Transform(ref Vector3f v, ref Matrix4f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;

            result = new Vector3f();
            result.X = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31 + matrix.M41;
            result.Y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32 + matrix.M42;
            result.Z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33 + matrix.M43;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Row vector product of the transformation.</param>
        public static Vector3f Transform(Vector3f v, Matrix4f matrix)
        {
            var result = new Vector3f();
            Transform(ref v, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformTranspose(ref Vector3f v, ref Matrix4f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;
            result.X = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13 + matrix.M14;
            result.Y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23 + matrix.M24;
            result.Z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33 + matrix.M34;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static Vector3f TransformNormal(Vector3f v, Matrix4f matrix)
        {
            Vector3f toReturn;
            TransformNormal(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformNormal(ref Vector3f v, ref Matrix4f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;
            result.X = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31;
            result.Y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32;
            result.Z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static Vector3f TransformNormalTranspose(Vector3f v, Matrix4f matrix)
        {
            Vector3f toReturn;
            TransformNormalTranspose(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformNormalTranspose(ref Vector3f v, ref Matrix4f matrix, out Vector3f result)
        {
            float vX = v.X;
            float vY = v.Y;
            float vZ = v.Z;
            result.X = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13;
            result.Y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23;
            result.Z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33;
        }

        /// <summary>Transform a direction vector by the given Matrix
        /// Assumes the matrix has a bottom row of (0,0,0,1), that is the translation part is ignored.
        /// </summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <returns>The transformed vector</returns>
        public static Vector3f TransformVector(Vector3f vec, Matrix4f mat)
        {
            Vector3f v;
            v.X = Vector3f.Dot(vec, new Vector3f(mat.Column0));
            v.Y = Vector3f.Dot(vec, new Vector3f(mat.Column1));
            v.Z = Vector3f.Dot(vec, new Vector3f(mat.Column2));
            return v;
        }

        /// <summary>Transform a direction vector by the given Matrix
        /// Assumes the matrix has a bottom row of (0,0,0,1), that is the translation part is ignored.
        /// </summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <param name="result">The transformed vector</param>
        public static void TransformVector(ref Vector3f vec, ref Matrix4f mat, out Vector3f result)
        {
            result.X = vec.X * mat.M11 +
                vec.Y * mat.M21 +
                vec.Z * mat.M31;

            result.Y = vec.X * mat.M12 +
                vec.Y * mat.M22 +
                vec.Z * mat.M32;

            result.Z = vec.X * mat.M13 +
                vec.Y * mat.M23 +
                vec.Z * mat.M33;
        }

        /// <summary>Transform a Position by the given Matrix</summary>
        /// <param name="pos">The position to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <returns>The transformed position</returns>
        public static Vector3f TransformPosition(Vector3f pos, Matrix4f mat)
        {
            Vector3f p;
            p.X = Vector3f.Dot(pos, new Vector3f(mat.Column0)) + mat.M41;
            p.Y = Vector3f.Dot(pos, new Vector3f(mat.Column1)) + mat.M42;
            p.Z = Vector3f.Dot(pos, new Vector3f(mat.Column2)) + mat.M43;
            return p;
        }

        /// <summary>Transform a Position by the given Matrix</summary>
        /// <param name="pos">The position to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <param name="result">The transformed position</param>
        public static void TransformPosition(ref Vector3f pos, ref Matrix4f mat, out Vector3f result)
        {
            result.X = pos.X * mat.M11 +
                pos.Y * mat.M21 +
                pos.Z * mat.M31 +
                mat.M41;

            result.Y = pos.X * mat.M12 +
                pos.Y * mat.M22 +
                pos.Z * mat.M32 +
                mat.M42;

            result.Z = pos.X * mat.M13 +
                pos.Y * mat.M23 +
                pos.Z * mat.M33 +
                mat.M43;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        public static Vector3f Transform(Vector3f vec, Quaternion quat)
        {
            Vector3f result;
            Transform(ref vec, ref quat, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector3f vec, ref Quaternion quat, out Vector3f result)
        {
            // Since vec.W == 0, we can optimize quat * vec * quat^-1 as follows:
            // vec + 2.0 * cross(quat.XYZ, cross(quat.XYZ, vec) + quat.w * vec)
            Vector3f XYZ = quat.XYZ, temp, temp2;
            Cross(ref XYZ, ref vec, out temp);
            Multiply(ref vec, quat.W, out temp2);
            Add(ref temp, ref temp2, out temp);
            Cross(ref XYZ, ref temp, out temp);
            Multiply(ref temp, 2, out temp);
            Add(ref vec, ref temp, out result);
            result.Truncate();
            //result = ((quat * vec) * Quaternion.Conjugate(quat)).XYZ;
        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for x,0,0 vectors.
        /// </summary>
        /// <param name="x">X component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformX(float x, ref Quaternion rotation, out Vector3f result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float zz2 = rotation.Z * z2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            //Defer the component setting since they're used in computation.
            float transformedX = x * (1f - yy2 - zz2);
            float transformedY = x * (xy2 + wz2);
            float transformedZ = x * (xz2 - wy2);
            result.X = transformedX;
            result.Y = transformedY;
            result.Z = transformedZ;
        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for 0,y,0 vectors.
        /// </summary>
        /// <param name="y">Y component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformY(float y, ref Quaternion rotation, out Vector3f result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;
            float wx2 = rotation.W * x2;
            float wz2 = rotation.W * z2;
            //Defer the component setting since they're used in computation.
            float transformedX = y * (xy2 - wz2);
            float transformedY = y * (1f - xx2 - zz2);
            float transformedZ = y * (yz2 + wx2);
            result.X = transformedX;
            result.Y = transformedY;
            result.Z = transformedZ;
        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for 0,0,z vectors.
        /// </summary>
        /// <param name="z">Z component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformZ(float z, ref Quaternion rotation, out Vector3f result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;
            float xx2 = rotation.X * x2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            //Defer the component setting since they're used in computation.
            float transformedX = z * (xz2 + wy2);
            float transformedY = z * (yz2 - wx2);
            float transformedZ = z * (1f - xx2 - yy2);
            result.X = transformedX;
            result.Y = transformedY;
            result.Z = transformedZ;
        }

        /// <summary>
        /// Rotate a vector by an angle.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <param name="axis">The axis used for rotation.</param>
        /// <returns>The result of the operation.</returns>
        public static Vector3f Rotate(Vector3f vec, float angle, Vector3f axis)
        {
            Quaternion rotation = Quaternion.FromAxisAngle(axis, angle);
            Vector3f result;
            Transform(ref vec, ref rotation, out result);
            return result;
        }

        /// <summary>Transform a Vector3f by the given Matrix, and project the resulting Vector4f back to a Vector3f</summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <returns>The transformed vector</returns>
        public static Vector3f TransformPerspective(Vector3f vec, Matrix4f mat)
        {
            Vector3f result;
            TransformPerspective(ref vec, ref mat, out result);
            return result;
        }

        /// <summary>Transform a Vector3f by the given Matrix, and project the resulting Vector4f back to a Vector3f</summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <param name="result">The transformed vector</param>
        public static void TransformPerspective(ref Vector3f vec, ref Matrix4f mat, out Vector3f result)
        {
            Vector4f v = new Vector4f(vec, 1);
            Vector4f.Transform(ref v, ref mat, out v);
            result.X = v.X / v.W;
            result.Y = v.Y / v.W;
            result.Z = v.Z / v.W;
        }

        /// <summary>
        /// Returns a <see cref="Vector3f"/> with positive version of its components.
        /// </summary>
        /// <param name="v">The vector.</param>
        public static Vector3f Abs(Vector3f v)
        {
            Vector3f res;
            Abs(ref v, out res);
            return res;
        }

        /// <summary>
        /// Returns a <see cref="Vector3f"/> with positive version of its components.
        /// </summary>
        /// <param name="v">The input vector.</param>
        /// <param name="o">The output vector.</param>
        public static void Abs(ref Vector3f v, out Vector3f o)
        {
            o = new Vector3f(System.Math.Abs(v.X), System.Math.Abs(v.Y), System.Math.Abs(v.Z));
        }

        /// <summary>
        /// Calculates the angle (in radians) between two vectors.
        /// </summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <returns>Angle (in radians) between the vectors.</returns>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public static float CalculateAngle(Vector3f first, Vector3f second)
        {
            return MathHelper.Acos((Dot(first, second)) / (first.Length * second.Length));
        }

        /// <summary>Calculates the angle (in radians) between two vectors.</summary>
        /// <param name="first">The first vector.</param>
        /// <param name="second">The second vector.</param>
        /// <param name="result">Angle (in radians) between the vectors.</param>
        /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
        public static void CalculateAngle(ref Vector3f first, ref Vector3f second, out float result)
        {
            float temp;
            Vector3f.Dot(ref first, ref second, out temp);
            result = MathHelper.Acos(temp / (first.Length * second.Length));
        }

        /// <summary>
        /// Checks to see if any value (x, y, z) are within 0.0001 of 0.
        /// If so this method truncates that value to zero.
        /// </summary>
        /// <returns>A truncated Vector3f</returns>
        public static Vector3f Truncate(Vector3f vec)
        {
            float _x = (System.Math.Abs(vec.X) - 0.0001 < 0) ? 0 : vec.X;
            float _y = (System.Math.Abs(vec.Y) - 0.0001 < 0) ? 0 : vec.Y;
            float _z = (System.Math.Abs(vec.Z) - 0.0001 < 0) ? 0 : vec.Z;
            return new Vector3f(_x, _y, _z);
        }

        #region FromYawPitch

        /// <summary>
        /// Get Direction vector from Yaw and Pitch (in radians).
        /// </summary>
        /// <param name="Yaw">Yaw in radians.</param>
        /// <param name="Pitch">Pitch in radians.</param>
        /// <returns>Direction vector</returns>
        public static Vector3f FromYawPitch(float Yaw, float Pitch)
        {
            float CosPitch = MathHelper.Cos(Pitch); //Optimization
            Vector3f result = new Vector3f(CosPitch * MathHelper.Sin(Yaw), MathHelper.Sin(Pitch), CosPitch * MathHelper.Cos(Yaw));
            //Result.Normalize();
            return result;
        }
        
        #endregion
        
        /// <summary>
        /// Gets or sets an Vector2f with the X and Y components of this instance.
        /// </summary>
        public Vector2f XY
        {
            get { return new Vector2f(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the X and Z components of this instance.
        /// </summary>
        public Vector2f XZ
        {
            get { return new Vector2f(X, Z); }
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the Y and X components of this instance.
        /// </summary>
        public Vector2f YX
        {
            get { return new Vector2f(Y, X); }
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the Y and Z components of this instance.
        /// </summary>
        public Vector2f YZ
        {
            get { return new Vector2f(Y, Z); }
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the Z and X components of this instance.
        /// </summary>
        public Vector2f ZX
        {
            get { return new Vector2f(Z, X); }
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the Z and Y components of this instance.
        /// </summary>
        public Vector2f ZY
        {
            get { return new Vector2f(Z, Y); }
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, Z, and Y components of this instance.
        /// </summary>
        public Vector3f XZY
        {
            get { return new Vector3f(X, Z, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Y, X, and Z components of this instance.
        /// </summary>
        public Vector3f YXZ
        {
            get { return new Vector3f(Y, X, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Y, Z, and X components of this instance.
        /// </summary>
        public Vector3f YZX
        {
            get { return new Vector3f(Y, Z, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Z, X, and Y components of this instance.
        /// </summary>
        public Vector3f ZXY
        {
            get { return new Vector3f(Z, X, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Z, Y, and X components of this instance.
        /// </summary>
        public Vector3f ZYX
        {
            get { return new Vector3f(Z, Y, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator +(Vector3f left, Vector3f right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
            return left;
        }

        /// <summary>
        /// Subtracts two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator -(Vector3f left, Vector3f right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            return left;
        }

        /// <summary>
        /// Negates an instance.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator -(Vector3f vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator *(Vector3f vec, Vector3f scale)
        {
            return Multiply(vec, scale);
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator *(Vector3f vec, float scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator *(float scale, Vector3f vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector3f operator /(Vector3f vec, float scale)
        {
            float mult = 1.0f / scale;
            vec.X *= mult;
            vec.Y *= mult;
            vec.Z *= mult;
            return vec;
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Vector3f left, Vector3f right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equa lright; false otherwise.</returns>
        public static bool operator !=(Vector3f left, Vector3f right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        [CLSCompliant(false)]
        unsafe public static explicit operator float* (Vector3f v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        public static explicit operator IntPtr(Vector3f v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Explicitly cast this <see cref="Vector3f"/> into a <see cref="Assimp.Vector3D"/>.
        /// </summary>
        /// <param name="vec">The vector to cast.</param>
        [CLSCompliant(false)]
        public static explicit operator Assimp.Vector3D(Vector3f vec)
        {
            return new Assimp.Vector3D(vec.X, vec.Y, vec.Z);
        }

        /// <summary>
        /// Explicitly cast this <see cref="Vector3f"/> into a <see cref="Assimp.Vector3D"/>.
        /// </summary>
        /// <param name="vec">The vector to cast.</param>
        [CLSCompliant(false)]
        public static explicit operator Vector3f(Assimp.Vector3D vec)
        {
            return new Vector3f(vec.X, vec.Y, vec.Z);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3f))
                return false;

            return this.Equals((Vector3f)obj);
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector3f other)
        {
            return
                X == other.X &&
                Y == other.Y &&
                Z == other.Z;
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.FromString(string value)
        {
            var parts = value.Trim('(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            float.TryParse(parts[0].Trim(), out X);
            float.TryParse(parts[1].Trim(), out Y);
            float.TryParse(parts[2].Trim(), out Z);
        }

        /// <summary>
        /// Convert a <see cref="string"/> to a <see cref="Vector3f"/>.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to convert.</param>
        /// <returns>The <see cref="Vector3f"/> result of the conversion.</returns>
        public static Vector3f Parse(string s)
        {
            var result = Zero as ILoadFromString;
            result.FromString(s);
            return (Vector3f)result;
        }

        /// <summary>
        /// Returns a string that represents this <see cref="Vector3f"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({X} , {Y} , {Z})";
        }

        /// <summary>
        /// Gets the array representation of this <see cref="Vector3f"/>.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }
    }
}