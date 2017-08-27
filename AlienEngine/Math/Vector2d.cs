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

namespace AlienEngine
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Vector2d>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2d : IEquatable<Vector2d>, ILoadFromString
    {
        /// <summary>
        /// The x coordinate of the vector
        /// </summary>
        public double X;

        /// <summary>
        /// The y coordinate of the vector
        /// </summary>
        public double Y;

        /// <summary>
        /// Defines a unit-length <see cref="Vector2d"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector2d UnitX = new Vector2d(1, 0);

        /// <summary>
        /// Defines a unit-length <see cref="Vector2d"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector2d UnitY = new Vector2d(0, 1);

        /// <summary>
        /// Defines a zero-length <see cref="Vector2d"/>.
        /// </summary>
        public static readonly Vector2d Zero = new Vector2d(0);

        /// <summary>
        /// Defines a <see cref="Vector2d"/> populated with one.
        /// </summary>
        public static readonly Vector2d One = new Vector2d(1);

        /// <summary>
        /// Defines the size of the Vector2d struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(double) * 2;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2d(double value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Constructs a new Vector2d.
        /// </summary>
        /// <param name="x">The x coordinate of the net Vector2d.</param>
        /// <param name="y">The y coordinate of the net Vector2d.</param>
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector2ui.
        /// </summary>
        /// <param name="v">The Vector2ui to copy components from.</param>
        public Vector2d(Vector2ui vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector2i.
        /// </summary>
        /// <param name="v">The Vector2i to copy components from.</param>
        public Vector2d(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector2d.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector2d(Vector2d vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector2f.
        /// </summary>
        /// <param name="v">The Vector2f to copy components from.</param>
        public Vector2d(Vector2f vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector3ui.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        public Vector2d(Vector3ui vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector3i.
        /// </summary>
        /// <param name="v">The Vector3i to copy components from.</param>
        public Vector2d(Vector3i vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector3d.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector2d(Vector3d vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector3f.
        /// </summary>
        /// <param name="v">The Vector3f to copy components from.</param>
        public Vector2d(Vector3f vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector4ui.
        /// </summary>
        /// <param name="v">The Vector4ui to copy components from.</param>
        public Vector2d(Vector4ui vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector4i.
        /// </summary>
        /// <param name="v">The Vector4i to copy components from.</param>
        public Vector2d(Vector4i vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector4d.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector2d(Vector4d vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Constructs a new Vector2d from the given Vector4f.
        /// </summary>
        /// <param name="v">The Vector4f to copy components from.</param>
        public Vector2d(Vector4f vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return X;
                else if (index == 1)
                    return Y;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0)
                    X = value;
                else if (index == 1)
                    Y = value;
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the length (magnitude) of the vector.
        /// </summary>
        /// <see cref="LengthFast"/>
        /// <seealso cref="LengthSquared"/>
        public double Length
        {
            get { return (double)System.Math.Sqrt(X * X + Y * Y); }
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
        public double LengthFast
        {
            get { return 1.0f / MathHelper.InverseSqrtFast(X * X + Y * Y); }
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
        public double LengthSquared
        {
            get { return X * X + Y * Y; }
        }

        /// <summary>
        /// Gets the perpendicular vector on the right side of this vector.
        /// </summary>
        public Vector2d PerpendicularRight
        {
            get { return new Vector2d(Y, -X); }
        }

        /// <summary>
        /// Gets the perpendicular vector on the left side of this vector.
        /// </summary>
        public Vector2d PerpendicularLeft
        {
            get { return new Vector2d(-Y, X); }
        }

        /// <summary>
        /// Scales the Vector2d to unit length.
        /// </summary>
        public void Normalize()
        {
            double scale = 1.0f / this.Length;
            X *= scale;
            Y *= scale;
        }

        /// <summary>
        /// Scales the Vector2d to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            double scale = MathHelper.InverseSqrtFast(X * X + Y * Y);
            X *= scale;
            Y *= scale;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        public static Vector2d Add(Vector2d a, Vector2d b)
        {
            Add(ref a, ref b, out a);
            return a;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <param name="result">Result of operation.</param>
        public static void Add(ref Vector2d a, ref Vector2d b, out Vector2d result)
        {
            result = new Vector2d(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector2d Subtract(Vector2d a, Vector2d b)
        {
            Subtract(ref a, ref b, out a);
            return a;
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">Result of subtraction</param>
        public static void Subtract(ref Vector2d a, ref Vector2d b, out Vector2d result)
        {
            result = new Vector2d(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2d Multiply(Vector2d vector, double scale)
        {
            Multiply(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector2d vector, double scale, out Vector2d result)
        {
            result = new Vector2d(vector.X * scale, vector.Y * scale);
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2d Multiply(Vector2d vector, Vector2d scale)
        {
            Multiply(ref vector, ref scale, out vector);
            return vector;
        }

        /// <summary>
        /// Multiplies a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Multiply(ref Vector2d vector, ref Vector2d scale, out Vector2d result)
        {
            result = new Vector2d(vector.X * scale.X, vector.Y * scale.Y);
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2d Divide(Vector2d vector, double scale)
        {
            Divide(ref vector, scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector2d vector, double scale, out Vector2d result)
        {
            Multiply(ref vector, 1 / scale, out result);
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2d Divide(Vector2d vector, Vector2d scale)
        {
            Divide(ref vector, ref scale, out vector);
            return vector;
        }

        /// <summary>
        /// Divide a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <param name="result">Result of the operation.</param>
        public static void Divide(ref Vector2d vector, ref Vector2d scale, out Vector2d result)
        {
            result = new Vector2d(vector.X / scale.X, vector.Y / scale.Y);
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise minimum</returns>
        public static Vector2d ComponentMin(Vector2d a, Vector2d b)
        {
            a.X = a.X < b.X ? a.X : b.X;
            a.Y = a.Y < b.Y ? a.Y : b.Y;
            return a;
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise minimum</param>
        public static void ComponentMin(ref Vector2d a, ref Vector2d b, out Vector2d result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
        }

        /// <summary>
        /// Calculate the component-wise maximum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise maximum</returns>
        public static Vector2d ComponentMax(Vector2d a, Vector2d b)
        {
            a.X = a.X > b.X ? a.X : b.X;
            a.Y = a.Y > b.Y ? a.Y : b.Y;
            return a;
        }

        /// <summary>
        /// Calculate the component-wise maximum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise maximum</param>
        public static void ComponentMax(ref Vector2d a, ref Vector2d b, out Vector2d result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
        }

        /// <summary>
        /// Returns the Vector2d with the minimum magnitude
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>The minimum Vector2d</returns>
        public static Vector2d Min(Vector2d left, Vector2d right)
        {
            return left.LengthSquared < right.LengthSquared ? left : right;
        }

        /// <summary>
        /// Returns the Vector2d with the minimum magnitude
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>The minimum Vector2d</returns>
        public static Vector2d Max(Vector2d left, Vector2d right)
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
        public static Vector2d Clamp(Vector2d vec, Vector2d min, Vector2d max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors
        /// </summary>
        /// <param name="vec">Input vector</param>
        /// <param name="min">Minimum vector</param>
        /// <param name="max">Maximum vector</param>
        /// <param name="result">The clamped vector</param>
        public static void Clamp(ref Vector2d vec, ref Vector2d min, ref Vector2d max, out Vector2d result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector2d Normalize(Vector2d vec)
        {
            double scale = 1.0f / vec.Length;
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void Normalize(ref Vector2d vec, out Vector2d result)
        {
            double scale = 1.0f / vec.Length;
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector2d NormalizeFast(Vector2d vec)
        {
            double scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void NormalizeFast(ref Vector2d vec, out Vector2d result)
        {
            double scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The dot product of the two inputs</returns>
        public static double Dot(Vector2d left, Vector2d right)
        {
            return left.X * right.X + left.Y * right.Y;
        }

        /// <summary>
        /// Calculate the dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The dot product of the two inputs</param>
        public static void Dot(ref Vector2d left, ref Vector2d right, out double result)
        {
            result = left.X * right.X + left.Y * right.Y;
        }

        /// <summary>
        /// Calculate the perpendicular dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The perpendicular dot product of the two inputs</returns>
        public static double PerpDot(Vector2d left, Vector2d right)
        {
            return left.X * right.Y - left.Y * right.X;
        }

        /// <summary>
        /// Calculate the perpendicular dot (scalar) product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The perpendicular dot product of the two inputs</param>
        public static void PerpDot(ref Vector2d left, ref Vector2d right, out double result)
        {
            result = left.X * right.Y - left.Y * right.X;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise</returns>
        public static Vector2d Lerp(Vector2d a, Vector2d b, double blend)
        {
            a.X = blend * (b.X - a.X) + a.X;
            a.Y = blend * (b.Y - a.Y) + a.Y;
            return a;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise</param>
        public static void Lerp(ref Vector2d a, ref Vector2d b, double blend, out Vector2d result)
        {
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
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
        public static Vector2d BaryCentric(Vector2d a, Vector2d b, Vector2d c, double u, double v)
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
        public static void BaryCentric(ref Vector2d a, ref Vector2d b, ref Vector2d c, double u, double v, out Vector2d result)
        {
            result = a; // copy

            Vector2d temp = b; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, u, out temp);
            Add(ref result, ref temp, out result);

            temp = c; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, v, out temp);
            Add(ref result, ref temp, out result);
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        public static Vector2d Transform(Vector2d vec, Quaternion quat)
        {
            Vector2d result;
            Transform(ref vec, ref quat, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector2d vec, ref Quaternion quat, out Vector2d result)
        {
            Quaternion v = new Quaternion((float)vec.X, (float)vec.Y, 0, 0), i, t;
            Quaternion.Invert(ref quat, out i);
            Quaternion.Multiply(ref quat, ref v, out t);
            Quaternion.Multiply(ref t, ref i, out v);

            result = new Vector2d(v.X, v.Y);
        }

        /// <summary>
        /// Gets or sets an Vector2d with the Y and X components of this instance.
        /// </summary>
        public Vector2d YX
        {
            get { return new Vector2d(Y, X); }
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Adds the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of addition.</returns>
        public static Vector2d operator +(Vector2d left, Vector2d right)
        {
            left.X += right.X;
            left.Y += right.Y;
            return left;
        }

        /// <summary>
        /// Subtracts the specified instances.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of subtraction.</returns>
        public static Vector2d operator -(Vector2d left, Vector2d right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            return left;
        }

        /// <summary>
        /// Negates the specified instance.
        /// </summary>
        /// <param name="vec">Operand.</param>
        /// <returns>Result of negation.</returns>
        public static Vector2d operator -(Vector2d vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            return vec;
        }

        /// <summary>
        /// Multiplies the specified instance by a scalar.
        /// </summary>
        /// <param name="vec">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        public static Vector2d operator *(Vector2d vec, double scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies the specified instance by a scalar.
        /// </summary>
        /// <param name="scale">Left operand.</param>
        /// <param name="vec">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        public static Vector2d operator *(double scale, Vector2d vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        /// <summary>
        /// Divides the specified instance by a scalar.
        /// </summary>
        /// <param name="vec">Left operand</param>
        /// <param name="scale">Right operand</param>
        /// <returns>Result of the division.</returns>
        public static Vector2d operator /(Vector2d vec, double scale)
        {
            double mult = 1.0f / scale;
            vec.X *= mult;
            vec.Y *= mult;
            return vec;
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are equal; false otherwise.</returns>
        public static bool operator ==(Vector2d left, Vector2d right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares the specified instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator !=(Vector2d left, Vector2d right)
        {
            return !left.Equals(right);
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
            if (!(obj is Vector2d))
                return false;

            return this.Equals((Vector2d)obj);
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector2d other)
        {
            return
                X == other.X &&
                Y == other.Y;
        }

        /// <summary>
        /// Gets the array representation of the Vector2d.
        /// </summary>
        public double[] ToArray()
        {
            return new double[] { X, Y };
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.FromString(string value)
        {
            var parts = value.Trim('(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            double.TryParse(parts[0].Trim(), out X);
            double.TryParse(parts[1].Trim(), out Y);
        }

        /// <summary>
        /// Returns a string that represents the current Vector2d.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("({0} , {1})", X, Y);
        }
    }
}
