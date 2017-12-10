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
    [TypeConverter(typeof(StructTypeConverter<Vector4i>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4i : IEquatable<Vector4i>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector4i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y component of the Vector4i.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z component of the Vector4i.
        /// </summary>
        public int Z;

        /// <summary>
        /// The W component of the Vector4i.
        /// </summary>
        public int W;

        /// <summary>
        /// Defines a unit-length Vector4i that points towards the X-axis.
        /// </summary>
        public static readonly Vector4i UnitX = new Vector4i(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4i that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4i UnitY = new Vector4i(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4i that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4i UnitZ = new Vector4i(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector4i that points towards the W-axis.
        /// </summary>
        public static readonly Vector4i UnitW = new Vector4i(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector4i.
        /// </summary>
        public static readonly Vector4i Zero = new Vector4i(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4i One = new Vector4i(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector4i struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(int) * 4;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4i(int value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Constructs a new Vector4i.
        /// </summary>
        /// <param name="x">The x component of the Vector4i.</param>
        /// <param name="y">The y component of the Vector4i.</param>
        /// <param name="z">The z component of the Vector4i.</param>
        /// <param name="w">The w component of the Vector4i.</param>
        public Vector4i(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector2ui.
        /// </summary>
        /// <param name="v">The Vector2ui to copy components from.</param>
        public Vector4i(Vector2ui vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector2i.
        /// </summary>
        /// <param name="v">The Vector2i to copy components from.</param>
        public Vector4i(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector2d.
        /// </summary>
        /// <param name="v">The Vector2d to copy components from.</param>
        public Vector4i(Vector2d vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector2f.
        /// </summary>
        /// <param name="v">The Vector2f to copy components from.</param>
        public Vector4i(Vector2f vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector3ui.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        public Vector4i(Vector3ui vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector3i.
        /// </summary>
        /// <param name="v">The Vector3i to copy components from.</param>
        public Vector4i(Vector3i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector2f from the given Vector3d.
        /// </summary>
        /// <param name="v">The Vector3d to copy components from.</param>
        public Vector4i(Vector3d vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector3f.
        /// </summary>
        /// <param name="v">The Vector3f to copy components from.</param>
        public Vector4i(Vector3f vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector4ui.
        /// </summary>
        /// <param name="v">The Vector4ui to copy components from.</param>
        public Vector4i(Vector4ui vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = (int)vec.W;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector4i.
        /// </summary>
        /// <param name="v">The Vector4i to copy components from.</param>
        public Vector4i(Vector4i vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector4d.
        /// </summary>
        /// <param name="v">The Vector4d to copy components from.</param>
        public Vector4i(Vector4d vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = (int)vec.W;
        }

        /// <summary>
        /// Constructs a new Vector4i from the given Vector4f.
        /// </summary>
        /// <param name="v">The Vector4f to copy components from.</param>
        public Vector4i(Vector4f vec)
        {
            X = (int)vec.X;
            Y = (int)vec.Y;
            Z = (int)vec.Z;
            W = (int)vec.W;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        public int this[int index]
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
        public int LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector4i Sub(Vector4i a, Vector4i b)
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
        public static void Sub(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Mult(Vector4i a, int f)
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
        public static void Mult(ref Vector4i a, int f, out Vector4i result)
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
        public static Vector4i Div(Vector4i a, int f)
        {
            a.X /= f;
            a.Y /= f;
            a.Z /= f;
            a.W /= f;
            return a;
        }

        /// <summary>
        /// Divide a vector by a scalar
        /// </summary>
        /// <param name="a">Vector operand</param>
        /// <param name="f">Scalar operand</param>
        /// <param name="result">Result of the division</param>
        public static void Div(ref Vector4i a, int f, out Vector4i result)
        {
            result.X = a.X / f;
            result.Y = a.Y / f;
            result.Z = a.Z / f;
            result.W = a.W / f;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">Left operand.</param>
        /// <param name="b">Right operand.</param>
        /// <returns>Result of operation.</returns>
        public static Vector4i Add(Vector4i a, Vector4i b)
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
        public static void Add(ref Vector4i a, ref Vector4i b, out Vector4i result)
        {
            result = new Vector4i(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector4i Subtract(Vector4i a, Vector4i b)
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
        public static void Subtract(ref Vector4i a, ref Vector4i b, out Vector4i result)
        {
            result = new Vector4i(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4i Multiply(Vector4i vector, int scale)
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
        public static void Multiply(ref Vector4i vector, int scale, out Vector4i result)
        {
            result = new Vector4i(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4i Multiply(Vector4i vector, Vector4i scale)
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
        public static void Multiply(ref Vector4i vector, ref Vector4i scale, out Vector4i result)
        {
            result = new Vector4i(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z, vector.W * scale.W);
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4i Divide(Vector4i vector, int scale)
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
        public static void Divide(ref Vector4i vector, int scale, out Vector4i result)
        {
            Multiply(ref vector, 1 / scale, out result);
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4i Divide(Vector4i vector, Vector4i scale)
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
        public static void Divide(ref Vector4i vector, ref Vector4i scale, out Vector4i result)
        {
            result = new Vector4i(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z, vector.W / scale.W);
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise minimum</returns>
        public static Vector4i Min(Vector4i a, Vector4i b)
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
        public static void Min(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Max(Vector4i a, Vector4i b)
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
        public static void Max(ref Vector4i a, ref Vector4i b, out Vector4i result)
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
        public static Vector4i Clamp(Vector4i vec, Vector4i min, Vector4i max)
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
        public static void Clamp(ref Vector4i vec, ref Vector4i min, ref Vector4i max, out Vector4i result)
        {
            result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
            result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
            result.Z = vec.X < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
            result.W = vec.Y < min.W ? min.W : vec.W > max.W ? max.W : vec.W;
        }

        /// <summary>
        /// Calculate the dot product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <returns>The dot product of the two inputs</returns>
        public static int Dot(Vector4i left, Vector4i right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Calculate the dot product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The dot product of the two inputs</param>
        public static void Dot(ref Vector4i left, ref Vector4i right, out int result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Gets or sets an Vector2i with the X and Y components of this instance.
        /// </summary>

        public Vector2i XY
        {
            get { return new Vector2i(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the X and Z components of this instance.
        /// </summary>

        public Vector2i XZ
        {
            get { return new Vector2i(X, Z); }
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the X and W components of this instance.
        /// </summary>

        public Vector2i XW
        {
            get { return new Vector2i(X, W); }
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the Y and X components of this instance.
        /// </summary>

        public Vector2i YX
        {
            get { return new Vector2i(Y, X); }
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the Y and Z components of this instance.
        /// </summary>

        public Vector2i YZ
        {
            get { return new Vector2i(Y, Z); }
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the Y and W components of this instance.
        /// </summary>

        public Vector2i YW
        {
            get { return new Vector2i(Y, W); }
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the Z and X components of this instance.
        /// </summary>

        public Vector2i ZX
        {
            get { return new Vector2i(Z, X); }
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the Z and Y components of this instance.
        /// </summary>

        public Vector2i ZY
        {
            get { return new Vector2i(Z, Y); }
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets an Vector2i with the Z and W components of this instance.
        /// </summary>
        public Vector2i ZW
        {
            get { return new Vector2i(Z, W); }
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the W and X components of this instance.
        /// </summary>
        public Vector2i WX
        {
            get { return new Vector2i(W, X); }
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the W and Y components of this instance.
        /// </summary>
        public Vector2i WY
        {
            get { return new Vector2i(W, Y); }
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2i with the W and Z components of this instance.
        /// </summary>
        public Vector2i WZ
        {
            get { return new Vector2i(W, Z); }
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, Y, and Z components of this instance.
        /// </summary>
        public Vector3i XYZ
        {
            get { return new Vector3i(X, Y, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, Y, and Z components of this instance.
        /// </summary>

        public Vector3i XYW
        {
            get { return new Vector3i(X, Y, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, Z, and Y components of this instance.
        /// </summary>

        public Vector3i XZY
        {
            get { return new Vector3i(X, Z, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, Z, and W components of this instance.
        /// </summary>

        public Vector3i XZW
        {
            get { return new Vector3i(X, Z, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, W, and Y components of this instance.
        /// </summary>

        public Vector3i XWY
        {
            get { return new Vector3i(X, W, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the X, W, and Z components of this instance.
        /// </summary>

        public Vector3i XWZ
        {
            get { return new Vector3i(X, W, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Y, X, and Z components of this instance.
        /// </summary>

        public Vector3i YXZ
        {
            get { return new Vector3i(Y, X, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Y, X, and W components of this instance.
        /// </summary>

        public Vector3i YXW
        {
            get { return new Vector3i(Y, X, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Y, Z, and X components of this instance.
        /// </summary>

        public Vector3i YZX
        {
            get { return new Vector3i(Y, Z, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Y, Z, and W components of this instance.
        /// </summary>

        public Vector3i YZW
        {
            get { return new Vector3i(Y, Z, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Y, W, and X components of this instance.
        /// </summary>

        public Vector3i YWX
        {
            get { return new Vector3i(Y, W, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets an Vector3i with the Y, W, and Z components of this instance.
        /// </summary>

        public Vector3i YWZ
        {
            get { return new Vector3i(Y, W, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, X, and Y components of this instance.
        /// </summary>

        public Vector3i ZXY
        {
            get { return new Vector3i(Z, X, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, X, and W components of this instance.
        /// </summary>

        public Vector3i ZXW
        {
            get { return new Vector3i(Z, X, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, Y, and X components of this instance.
        /// </summary>

        public Vector3i ZYX
        {
            get { return new Vector3i(Z, Y, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, Y, and W components of this instance.
        /// </summary>

        public Vector3i ZYW
        {
            get { return new Vector3i(Z, Y, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, W, and X components of this instance.
        /// </summary>

        public Vector3i ZWX
        {
            get { return new Vector3i(Z, W, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the Z, W, and Y components of this instance.
        /// </summary>

        public Vector3i ZWY
        {
            get { return new Vector3i(Z, W, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, X, and Y components of this instance.
        /// </summary>

        public Vector3i WXY
        {
            get { return new Vector3i(W, X, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, X, and Z components of this instance.
        /// </summary>

        public Vector3i WXZ
        {
            get { return new Vector3i(W, X, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, Y, and X components of this instance.
        /// </summary>

        public Vector3i WYX
        {
            get { return new Vector3i(W, Y, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, Y, and Z components of this instance.
        /// </summary>

        public Vector3i WYZ
        {
            get { return new Vector3i(W, Y, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, Z, and X components of this instance.
        /// </summary>

        public Vector3i WZX
        {
            get { return new Vector3i(W, Z, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3i with the W, Z, and Y components of this instance.
        /// </summary>

        public Vector3i WZY
        {
            get { return new Vector3i(W, Z, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the X, Y, W, and Z components of this instance.
        /// </summary>

        public Vector4i XYWZ
        {
            get { return new Vector4i(X, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the X, Z, Y, and W components of this instance.
        /// </summary>

        public Vector4i XZYW
        {
            get { return new Vector4i(X, Z, Y, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the X, Z, W, and Y components of this instance.
        /// </summary>

        public Vector4i XZWY
        {
            get { return new Vector4i(X, Z, W, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the X, W, Y, and Z components of this instance.
        /// </summary>

        public Vector4i XWYZ
        {
            get { return new Vector4i(X, W, Y, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the X, W, Z, and Y components of this instance.
        /// </summary>

        public Vector4i XWZY
        {
            get { return new Vector4i(X, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, X, Z, and W components of this instance.
        /// </summary>

        public Vector4i YXZW
        {
            get { return new Vector4i(Y, X, Z, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, X, W, and Z components of this instance.
        /// </summary>

        public Vector4i YXWZ
        {
            get { return new Vector4i(Y, X, W, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4i with the Y, Y, Z, and W components of this instance.
        /// </summary>

        public Vector4i YYZW
        {
            get { return new Vector4i(Y, Y, Z, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4i with the Y, Y, W, and Z components of this instance.
        /// </summary>

        public Vector4i YYWZ
        {
            get { return new Vector4i(Y, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, Z, X, and W components of this instance.
        /// </summary>

        public Vector4i YZXW
        {
            get { return new Vector4i(Y, Z, X, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, Z, W, and X components of this instance.
        /// </summary>

        public Vector4i YZWX
        {
            get { return new Vector4i(Y, Z, W, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, W, X, and Z components of this instance.
        /// </summary>

        public Vector4i YWXZ
        {
            get { return new Vector4i(Y, W, X, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Y, W, Z, and X components of this instance.
        /// </summary>

        public Vector4i YWZX
        {
            get { return new Vector4i(Y, W, Z, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, X, Y, and Z components of this instance.
        /// </summary>

        public Vector4i ZXYW
        {
            get { return new Vector4i(Z, X, Y, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, X, W, and Y components of this instance.
        /// </summary>

        public Vector4i ZXWY
        {
            get { return new Vector4i(Z, X, W, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, Y, X, and W components of this instance.
        /// </summary>

        public Vector4i ZYXW
        {
            get { return new Vector4i(Z, Y, X, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, Y, W, and X components of this instance.
        /// </summary>

        public Vector4i ZYWX
        {
            get { return new Vector4i(Z, Y, W, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, W, X, and Y components of this instance.
        /// </summary>

        public Vector4i ZWXY
        {
            get { return new Vector4i(Z, W, X, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the Z, W, Y, and X components of this instance.
        /// </summary>

        public Vector4i ZWYX
        {
            get { return new Vector4i(Z, W, Y, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4i with the Z, W, Z, and Y components of this instance.
        /// </summary>

        public Vector4i ZWZY
        {
            get { return new Vector4i(Z, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, X, Y, and Z components of this instance.
        /// </summary>

        public Vector4i WXYZ
        {
            get { return new Vector4i(W, X, Y, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, X, Z, and Y components of this instance.
        /// </summary>

        public Vector4i WXZY
        {
            get { return new Vector4i(W, X, Z, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, Y, X, and Z components of this instance.
        /// </summary>

        public Vector4i WYXZ
        {
            get { return new Vector4i(W, Y, X, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, Y, Z, and X components of this instance.
        /// </summary>

        public Vector4i WYZX
        {
            get { return new Vector4i(W, Y, Z, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, Z, X, and Y components of this instance.
        /// </summary>

        public Vector4i WZXY
        {
            get { return new Vector4i(W, Z, X, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4i with the W, Z, Y, and X components of this instance.
        /// </summary>

        public Vector4i WZYX
        {
            get { return new Vector4i(W, Z, Y, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4i with the W, Z, Y, and W components of this instance.
        /// </summary>
        public Vector4i WZYW
        {
            get { return new Vector4i(W, Z, Y, W); }
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
        public static Vector4i operator +(Vector4i left, Vector4i right)
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
        public static Vector4i operator -(Vector4i left, Vector4i right)
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
        public static Vector4i operator -(Vector4i vec)
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
        public static Vector4i operator *(Vector4i vec, int scale)
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
        public static Vector4i operator *(int scale, Vector4i vec)
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
        public static Vector4i operator /(Vector4i vec, int scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            vec.Z /= scale;
            vec.W /= scale;
            return vec;
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Vector4i left, Vector4i right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equa lright; false otherwise.</returns>
        public static bool operator !=(Vector4i left, Vector4i right)
        {
            return !left.Equals(right);
        }

#pragma warning disable CS3002 // Le type de retour de 'Vector4i.explicit operator int*(Vector4i)' n'est pas conforme CLS
        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        unsafe public static explicit operator int* (Vector4i v)
#pragma warning restore CS3002 // Le type de retour de 'Vector4i.explicit operator int*(Vector4i)' n'est pas conforme CLS
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        public static explicit operator IntPtr(Vector4i v)
        {
            unsafe
            {
                return (IntPtr)(&v.X);
            }
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
            if (!(obj is Vector4i))
                return false;

            return this.Equals((Vector4i)obj);
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector4i other)
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
            int.TryParse(parts[0].Trim(), out X);
            int.TryParse(parts[1].Trim(), out Y);
            int.TryParse(parts[2].Trim(), out Z);
            int.TryParse(parts[3].Trim(), out W);
        }


        /// <summary>
        /// Returns a string that represents the current Vector4i.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0} , {1} , {2} , {3})", X, Y, Z, W);
        }

        /// <summary>
        /// Gets the array representation of the Vector4i.
        /// </summary>
        public int[] ToArray()
        {
            return new int[] { X, Y, Z, W };
        }
    }
}