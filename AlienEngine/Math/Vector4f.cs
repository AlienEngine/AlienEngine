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
    /// Represents a four dimensional vector.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Vector4f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4f : IEquatable<Vector4f>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector4f.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y component of the Vector4f.
        /// </summary>
        public float Y;

        /// <summary>
        /// The Z component of the Vector4f.
        /// </summary>
        public float Z;

        /// <summary>
        /// The W component of the Vector4f.
        /// </summary>
        public float W;

        /// <summary>
        /// Defines a unit-length Vector4f that points towards the X-axis.
        /// </summary>
        public static readonly Vector4f UnitX = new Vector4f(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4f that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4f UnitY = new Vector4f(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4f that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4f UnitZ = new Vector4f(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector4f that points towards the W-axis.
        /// </summary>
        public static readonly Vector4f UnitW = new Vector4f(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector4f.
        /// </summary>
        public static readonly Vector4f Zero = new Vector4f(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4f One = new Vector4f(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector4f struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(float) * 4;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4f(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Constructs a new Vector4f.
        /// </summary>
        /// <param name="x">The x component of the Vector4f.</param>
        /// <param name="y">The y component of the Vector4f.</param>
        /// <param name="z">The z component of the Vector4f.</param>
        /// <param name="w">The w component of the Vector4f.</param>
        public Vector4f(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector2ui.
        /// </summary>
        /// <param name="v">The Vector2ui to copy components from.</param>
        public Vector4f(Vector2ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector2i.
        /// </summary>
        /// <param name="v">The Vector2i to copy components from.</param>
        public Vector4f(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector2d.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector4f(Vector2d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = 0f;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector2f.
        /// </summary>
        /// <param name="v">The Vector2f to copy components from.</param>
        public Vector4f(Vector2f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0f;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3ui.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        public Vector4f(Vector3ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3ui.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        public Vector4f(Vector3ui vec, float w)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3i.
        /// </summary>
        /// <param name="v">The Vector3i to copy components from.</param>
        public Vector4f(Vector3i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3i.
        /// </summary>
        /// <param name="v">The Vector3i to copy components from.</param>
        public Vector4f(Vector3i vec, float w)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector3d.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector4f(Vector3d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector3d.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector4f(Vector3d vec, float w)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3f.
        /// </summary>
        /// <param name="v">The Vector3f to copy components from.</param>
        public Vector4f(Vector3f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = 0f;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector3f.
        /// </summary>
        /// <param name="v">The Vector3f to copy components from.</param>
        public Vector4f(Vector3f vec, float w)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector4ui.
        /// </summary>
        /// <param name="v">The Vector4ui to copy components from.</param>
        public Vector4f(Vector4ui vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector4i.
        /// </summary>
        /// <param name="v">The Vector4i to copy components from.</param>
        public Vector4f(Vector4i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector4d.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector4f(Vector4d vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = (float)vec.W;
        }

        /// <summary>
        /// Constructs a new Vector4f from the given Vector4f.
        /// </summary>
        /// <param name="v">The Vector4f to copy components from.</param>
        public Vector4f(Vector4f vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
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
                else if (index == 3)
                    return W;
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
                else if (index == 3)
                    W = value;
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
            get { return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
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
            get { return 1.0f / MathHelper.InverseSqrtFast(X * X + Y * Y + Z * Z + W * W); }
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
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        /// <summary>
        /// Scales the Vector4f to unit length.
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
        /// Scales the Vector4f to approximately unit length.
        /// </summary>
        public void NormalizeFast()
        {
            float scale = MathHelper.InverseSqrtFast(X * X + Y * Y + Z * Z + W * W);
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector4f Sub(Vector4f a, Vector4f b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            a.Z -= b.Z;
            a.W -= b.W;
            return a;
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">Result of subtraction</param>
        public static void Sub(ref Vector4f a, ref Vector4f b, out Vector4f result)
        {
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
            result.Z = a.Z - b.Z;
            result.W = a.W - b.W;
        }

        /// <summary>
        /// Multiply a vector and a scalar
        /// </summary>
        /// <param name="a">Vector operand</param>
        /// <param name="f">Scalar operand</param>
        /// <returns>Result of the multiplication</returns>
        public static Vector4f Mult(Vector4f a, float f)
        {
            a.X *= f;
            a.Y *= f;
            a.Z *= f;
            a.W *= f;
            return a;
        }

        /// <summary>
        /// Multiply a vector and a scalar
        /// </summary>
        /// <param name="a">Vector operand</param>
        /// <param name="f">Scalar operand</param>
        /// <param name="result">Result of the multiplication</param>
        public static void Mult(ref Vector4f a, float f, out Vector4f result)
        {
            result.X = a.X * f;
            result.Y = a.Y * f;
            result.Z = a.Z * f;
            result.W = a.W * f;
        }

        /// <summary>
        /// Divide a vector by a scalar
        /// </summary>
        /// <param name="a">Vector operand</param>
        /// <param name="f">Scalar operand</param>
        /// <returns>Result of the division</returns>
        public static Vector4f Div(Vector4f a, float f)
        {
            float mult = 1.0f / f;
            a.X *= mult;
            a.Y *= mult;
            a.Z *= mult;
            a.W *= mult;
            return a;
        }

        /// <summary>
        /// Divide a vector by a scalar
        /// </summary>
        /// <param name="a">Vector operand</param>
        /// <param name="f">Scalar operand</param>
        /// <param name="result">Result of the division</param>
        public static void Div(ref Vector4f a, float f, out Vector4f result)
        {
            float mult = 1.0f / f;
            result.X = a.X * mult;
            result.Y = a.Y * mult;
            result.Z = a.Z * mult;
            result.W = a.W * mult;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        public static Vector4f Add(Vector4f a, Vector4f b)
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
        public static void Add(ref Vector4f a, ref Vector4f b, out Vector4f result)
        {
            result = new Vector4f(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector4f Subtract(Vector4f a, Vector4f b)
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
        public static void Subtract(ref Vector4f a, ref Vector4f b, out Vector4f result)
        {
            result = new Vector4f(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4f Multiply(Vector4f vector, float scale)
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
        public static void Multiply(ref Vector4f vector, float scale, out Vector4f result)
        {
            result = new Vector4f(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4f Multiply(Vector4f vector, Vector4f scale)
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
        public static void Multiply(ref Vector4f vector, ref Vector4f scale, out Vector4f result)
        {
            result = new Vector4f(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z, vector.W * scale.W);
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4f Divide(Vector4f vector, float scale)
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
        public static void Divide(ref Vector4f vector, float scale, out Vector4f result)
        {
            Multiply(ref vector, 1 / scale, out result);
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4f Divide(Vector4f vector, Vector4f scale)
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
        public static void Divide(ref Vector4f vector, ref Vector4f scale, out Vector4f result)
        {
            result = new Vector4f(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z, vector.W / scale.W);
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise minimum</returns>
        public static Vector4f Min(Vector4f a, Vector4f b)
        {
            a.X = a.X < b.X ? a.X : b.X;
            a.Y = a.Y < b.Y ? a.Y : b.Y;
            a.Z = a.Z < b.Z ? a.Z : b.Z;
            a.W = a.W < b.W ? a.W : b.W;
            return a;
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise minimum</param>
        public static void Min(ref Vector4f a, ref Vector4f b, out Vector4f result)
        {
            result.X = a.X < b.X ? a.X : b.X;
            result.Y = a.Y < b.Y ? a.Y : b.Y;
            result.Z = a.Z < b.Z ? a.Z : b.Z;
            result.W = a.W < b.W ? a.W : b.W;
        }

        /// <summary>
        /// Calculate the component-wise maximum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise maximum</returns>
        public static Vector4f Max(Vector4f a, Vector4f b)
        {
            a.X = a.X > b.X ? a.X : b.X;
            a.Y = a.Y > b.Y ? a.Y : b.Y;
            a.Z = a.Z > b.Z ? a.Z : b.Z;
            a.W = a.W > b.W ? a.W : b.W;
            return a;
        }

        /// <summary>
        /// Calculate the component-wise maximum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="result">The component-wise maximum</param>
        public static void Max(ref Vector4f a, ref Vector4f b, out Vector4f result)
        {
            result.X = a.X > b.X ? a.X : b.X;
            result.Y = a.Y > b.Y ? a.Y : b.Y;
            result.Z = a.Z > b.Z ? a.Z : b.Z;
            result.W = a.W > b.W ? a.W : b.W;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors
        /// </summary>
        /// <param name="vec">Input vector</param>
        /// <param name="min">Minimum vector</param>
        /// <param name="max">Maximum vector</param>
        /// <returns>The clamped vector</returns>
        public static Vector4f Clamp(Vector4f vec, Vector4f min, Vector4f max)
        {
            vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            vec.Z = vec.X < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            vec.W = vec.Y < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
            return vec;
        }

        /// <summary>
        /// Clamp a vector to the given minimum and maximum vectors
        /// </summary>
        /// <param name="vec">Input vector</param>
        /// <param name="min">Minimum vector</param>
        /// <param name="max">Maximum vector</param>
        /// <param name="result">The clamped vector</param>
        public static void Clamp(ref Vector4f vec, ref Vector4f min, ref Vector4f max, out Vector4f result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.X < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.Y < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector4f Normalize(Vector4f vec)
        {
            float scale = 1.0f / vec.Length;
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void Normalize(ref Vector4f vec, out Vector4f result)
        {
            float scale = 1.0f / vec.Length;
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
            result.W = vec.W * scale;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector4f NormalizeFast(Vector4f vec)
        {
            float scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Scale a vector to approximately unit length
        /// </summary>
        /// <param name="vec">The input vector</param>
        /// <param name="result">The normalized vector</param>
        public static void NormalizeFast(ref Vector4f vec, out Vector4f result)
        {
            float scale = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
            result.X = vec.X * scale;
            result.Y = vec.Y * scale;
            result.Z = vec.Z * scale;
            result.W = vec.W * scale;
        }

        /// <summary>
        /// Calculate the dot product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The dot product of the two inputs</returns>
        public static float Dot(Vector4f left, Vector4f right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Calculate the dot product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The dot product of the two inputs</param>
        public static void Dot(ref Vector4f left, ref Vector4f right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise</returns>
        public static Vector4f Lerp(Vector4f a, Vector4f b, float blend)
        {
            a.X = blend * (b.X - a.X) + a.X;
            a.Y = blend * (b.Y - a.Y) + a.Y;
            a.Z = blend * (b.Z - a.Z) + a.Z;
            a.W = blend * (b.W - a.W) + a.W;
            return a;
        }

        /// <summary>
        /// Returns a new Vector that is the linear blend of the 2 given Vectors
        /// </summary>
        /// <param name="a">First input vector</param>
        /// <param name="b">Second input vector</param>
        /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
        /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise</param>
        public static void Lerp(ref Vector4f a, ref Vector4f b, float blend, out Vector4f result)
        {
            result.X = blend * (b.X - a.X) + a.X;
            result.Y = blend * (b.Y - a.Y) + a.Y;
            result.Z = blend * (b.Z - a.Z) + a.Z;
            result.W = blend * (b.W - a.W) + a.W;
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
        public static Vector4f BaryCentric(Vector4f a, Vector4f b, Vector4f c, float u, float v)
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
        public static void BaryCentric(ref Vector4f a, ref Vector4f b, ref Vector4f c, float u, float v, out Vector4f result)
        {
            result = a; // copy

            Vector4f temp = b; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, u, out temp);
            Add(ref result, ref temp, out result);

            temp = c; // copy
            Subtract(ref temp, ref a, out temp);
            Multiply(ref temp, v, out temp);
            Add(ref result, ref temp, out result);
        }

        /// <summary>Transform a Vector by the given Matrix</summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <returns>The transformed vector</returns>
        public static Vector4f Transform(Vector4f vec, Matrix4f mat)
        {
            Vector4f result;
            Transform(ref vec, ref mat, out result);
            return result;
        }

        /// <summary>Transform a Vector by the given Matrix</summary>
        /// <param name="vec">The vector to transform</param>
        /// <param name="mat">The desired transformation</param>
        /// <param name="result">The transformed vector</param>
        public static void Transform(ref Vector4f vec, ref Matrix4f mat, out Vector4f result)
        {
            result = new Vector4f(
                vec.X * mat.Row0.X + vec.Y * mat.Row1.X + vec.Z * mat.Row2.X + vec.W * mat.Row3.X,
                vec.X * mat.Row0.Y + vec.Y * mat.Row1.Y + vec.Z * mat.Row2.Y + vec.W * mat.Row3.Y,
                vec.X * mat.Row0.Z + vec.Y * mat.Row1.Z + vec.Z * mat.Row2.Z + vec.W * mat.Row3.Z,
                vec.X * mat.Row0.W + vec.Y * mat.Row1.W + vec.Z * mat.Row2.W + vec.W * mat.Row3.W);
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <returns>The result of the operation.</returns>
        public static Vector4f Transform(Vector4f vec, Quaternion quat)
        {
            Vector4f result;
            Transform(ref vec, ref quat, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by a quaternion rotation.
        /// </summary>
        /// <param name="vec">The vector to transform.</param>
        /// <param name="quat">The quaternion to rotate the vector by.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Transform(ref Vector4f vec, ref Quaternion quat, out Vector4f result)
        {
            Quaternion v = new Quaternion(vec.X, vec.Y, vec.Z, vec.W), i, t;
            Quaternion.Invert(ref quat, out i);
            Quaternion.Multiply(ref quat, ref v, out t);
            Quaternion.Multiply(ref t, ref i, out v);

            result = new Vector4f(v.X, v.Y, v.Z, v.W);
        }

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
        /// Gets or sets an Vector2f with the X and W components of this instance.
        /// </summary>

        public Vector2f XW
        {
            get { return new Vector2f(X, W); }
            set
            {
                X = value.X;
                W = value.Y;
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
        /// Gets or sets an Vector2f with the Y and W components of this instance.
        /// </summary>

        public Vector2f YW
        {
            get { return new Vector2f(Y, W); }
            set
            {
                Y = value.X;
                W = value.Y;
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

        public Vector2f Zy
        {
            get { return new Vector2f(Z, Y); }
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets an Vector2f with the Z and W components of this instance.
        /// </summary>

        public Vector2f ZW
        {
            get { return new Vector2f(Z, W); }
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the W and X components of this instance.
        /// </summary>

        public Vector2f WX
        {
            get { return new Vector2f(W, X); }
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the W and Y components of this instance.
        /// </summary>

        public Vector2f WY
        {
            get { return new Vector2f(W, Y); }
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2f with the W and Z components of this instance.
        /// </summary>
        public Vector2f WZ
        {
            get { return new Vector2f(W, Z); }
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, Y, and Z components of this instance.
        /// </summary>
        public Vector3f XYZ
        {
            get { return new Vector3f(X, Y, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, Y, and Z components of this instance.
        /// </summary>
        public Vector3f XYW
        {
            get { return new Vector3f(X, Y, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, Z, and Y components of this instance.
        /// </summary>
        public Vector3f XZy
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
        /// Gets or sets an Vector3f with the X, Z, and W components of this instance.
        /// </summary>
        public Vector3f XZW
        {
            get { return new Vector3f(X, Z, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, W, and Y components of this instance.
        /// </summary>
        public Vector3f XWY
        {
            get { return new Vector3f(X, W, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the X, W, and Z components of this instance.
        /// </summary>
        public Vector3f XWZ
        {
            get { return new Vector3f(X, W, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets an Vector3f with the Y, X, and W components of this instance.
        /// </summary>

        public Vector3f YXW
        {
            get { return new Vector3f(Y, X, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
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
        /// Gets or sets an Vector3f with the Y, Z, and W components of this instance.
        /// </summary>

        public Vector3f YZW
        {
            get { return new Vector3f(Y, Z, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Y, W, and X components of this instance.
        /// </summary>

        public Vector3f YWX
        {
            get { return new Vector3f(Y, W, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets an Vector3f with the Y, W, and Z components of this instance.
        /// </summary>

        public Vector3f YWZ
        {
            get { return new Vector3f(Y, W, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
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
        /// Gets or sets an Vector3f with the Z, X, and W components of this instance.
        /// </summary>

        public Vector3f ZXW
        {
            get { return new Vector3f(Z, X, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
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
        /// Gets or sets an Vector3f with the Z, Y, and W components of this instance.
        /// </summary>

        public Vector3f ZYW
        {
            get { return new Vector3f(Z, Y, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Z, W, and X components of this instance.
        /// </summary>

        public Vector3f ZWX
        {
            get { return new Vector3f(Z, W, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the Z, W, and Y components of this instance.
        /// </summary>

        public Vector3f ZWY
        {
            get { return new Vector3f(Z, W, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, X, and Y components of this instance.
        /// </summary>

        public Vector3f WXY
        {
            get { return new Vector3f(W, X, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, X, and Z components of this instance.
        /// </summary>

        public Vector3f WXZ
        {
            get { return new Vector3f(W, X, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, Y, and X components of this instance.
        /// </summary>

        public Vector3f WYX
        {
            get { return new Vector3f(W, Y, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, Y, and Z components of this instance.
        /// </summary>

        public Vector3f WYZ
        {
            get { return new Vector3f(W, Y, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, Z, and X components of this instance.
        /// </summary>

        public Vector3f WZX
        {
            get { return new Vector3f(W, Z, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3f with the W, Z, and Y components of this instance.
        /// </summary>

        public Vector3f WZy
        {
            get { return new Vector3f(W, Z, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the X, Y, W, and Z components of this instance.
        /// </summary>

        public Vector4f XYWZ
        {
            get { return new Vector4f(X, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the X, Z, Y, and W components of this instance.
        /// </summary>

        public Vector4f XZYW
        {
            get { return new Vector4f(X, Z, Y, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the X, Z, W, and Y components of this instance.
        /// </summary>

        public Vector4f XZWY
        {
            get { return new Vector4f(X, Z, W, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the X, W, Y, and Z components of this instance.
        /// </summary>

        public Vector4f XWYZ
        {
            get { return new Vector4f(X, W, Y, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the X, W, Z, and Y components of this instance.
        /// </summary>

        public Vector4f XWZy
        {
            get { return new Vector4f(X, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, X, Z, and W components of this instance.
        /// </summary>

        public Vector4f YXZW
        {
            get { return new Vector4f(Y, X, Z, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, X, W, and Z components of this instance.
        /// </summary>

        public Vector4f YXWZ
        {
            get { return new Vector4f(Y, X, W, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4f with the Y, Y, Z, and W components of this instance.
        /// </summary>

        public Vector4f YYZW
        {
            get { return new Vector4f(Y, Y, Z, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4f with the Y, Y, W, and Z components of this instance.
        /// </summary>

        public Vector4f YYWZ
        {
            get { return new Vector4f(Y, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, Z, X, and W components of this instance.
        /// </summary>

        public Vector4f YZXW
        {
            get { return new Vector4f(Y, Z, X, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, Z, W, and X components of this instance.
        /// </summary>

        public Vector4f YZWX
        {
            get { return new Vector4f(Y, Z, W, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, W, X, and Z components of this instance.
        /// </summary>

        public Vector4f YWXZ
        {
            get { return new Vector4f(Y, W, X, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Y, W, Z, and X components of this instance.
        /// </summary>

        public Vector4f YWZX
        {
            get { return new Vector4f(Y, W, Z, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, X, Y, and Z components of this instance.
        /// </summary>

        public Vector4f ZXYW
        {
            get { return new Vector4f(Z, X, Y, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, X, W, and Y components of this instance.
        /// </summary>

        public Vector4f ZXWY
        {
            get { return new Vector4f(Z, X, W, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, Y, X, and W components of this instance.
        /// </summary>

        public Vector4f ZYXW
        {
            get { return new Vector4f(Z, Y, X, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, Y, W, and X components of this instance.
        /// </summary>

        public Vector4f ZYWX
        {
            get { return new Vector4f(Z, Y, W, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, W, X, and Y components of this instance.
        /// </summary>

        public Vector4f ZWXY
        {
            get { return new Vector4f(Z, W, X, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the Z, W, Y, and X components of this instance.
        /// </summary>

        public Vector4f ZWYX
        {
            get { return new Vector4f(Z, W, Y, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4f with the Z, W, Z, and Y components of this instance.
        /// </summary>

        public Vector4f ZWZy
        {
            get { return new Vector4f(Z, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, X, Y, and Z components of this instance.
        /// </summary>

        public Vector4f WXYZ
        {
            get { return new Vector4f(W, X, Y, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, X, Z, and Y components of this instance.
        /// </summary>

        public Vector4f WXZy
        {
            get { return new Vector4f(W, X, Z, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, Y, X, and Z components of this instance.
        /// </summary>

        public Vector4f WYXZ
        {
            get { return new Vector4f(W, Y, X, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, Y, Z, and X components of this instance.
        /// </summary>

        public Vector4f WYZX
        {
            get { return new Vector4f(W, Y, Z, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, Z, X, and Y components of this instance.
        /// </summary>

        public Vector4f WZXY
        {
            get { return new Vector4f(W, Z, X, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4f with the W, Z, Y, and X components of this instance.
        /// </summary>

        public Vector4f WZYX
        {
            get { return new Vector4f(W, Z, Y, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4f with the W, Z, Y, and W components of this instance.
        /// </summary>

        public Vector4f WZYW
        {
            get { return new Vector4f(W, Z, Y, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4f operator +(Vector4f left, Vector4f right)
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
        public static Vector4f operator -(Vector4f left, Vector4f right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        /// Negates an instance.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4f operator -(Vector4f vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            vec.W = -vec.W;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4f operator *(Vector4f vec, float scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The instance.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4f operator *(float scale, Vector4f vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            vec.W *= scale;
            return vec;
        }

        /// <summary>
        /// Divides an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4f operator /(Vector4f vec, float scale)
        {
            float mult = 1.0f / scale;
            vec.X *= mult;
            vec.Y *= mult;
            vec.Z *= mult;
            vec.W *= mult;
            return vec;
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Vector4f left, Vector4f right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equa lright; false otherwise.</returns>
        public static bool operator !=(Vector4f left, Vector4f right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        unsafe public static explicit operator float* (Vector4f v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        public static explicit operator IntPtr(Vector4f v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
        }

        /// <summary>
        /// Explicitly cast this <see cref="Vector4f"/> into a <see cref="BEPUutilities.Vector4"/>.
        /// </summary>
        /// <param name="vec">The vector to cast.</param>
        public static explicit operator BEPUutilities.Vector4(Vector4f vec)
        {
            return new BEPUutilities.Vector4(vec.X, vec.Y, vec.Z, vec.W);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4f))
                return false;

            return this.Equals((Vector4f)obj);
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector4f other)
        {
            return
                X == other.X &&
                Y == other.Y &&
                Z == other.Z &&
                W == other.W;
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
            float.TryParse(parts[3].Trim(), out W);
        }

        /// <summary>
        /// Convert a <see cref="string"/> to a <see cref="Vector4f"/>.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to convert.</param>
        /// <returns>The <see cref="Vector4f"/> result of the conversion.</returns>
        public static Vector4f Parse(string s)
        {
            var result = Zero as ILoadFromString;
            result.FromString(s);
            return (Vector4f)result;
        }

        /// <summary>
        /// Returns a string that represents the current Vector4f.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0} , {1} , {2} , {3})", X, Y, Z, W);
        }

        /// <summary>
        /// Gets the array representation of the Vector4f.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { X, Y, Z, W };
        }
    }
}