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
    [TypeConverter(typeof(StructTypeConverter<Vector4ui>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4ui : IEquatable<Vector4ui>, ILoadFromString
    {
        /// <summary>
        /// </summary>
        public uint X;

        /// <summary>
        /// </summary>
        public uint Y;

        /// <summary>
        /// </summary>
        public uint Z;

        /// <summary>
        /// </summary>
        public uint W;

        /// <summary>
        /// Defines a unit-length Vector4ui that points towards the X-axis.
        /// </summary>
        public static readonly Vector4ui UnitX = new Vector4ui(1, 0, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4ui that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4ui UnitY = new Vector4ui(0, 1, 0, 0);

        /// <summary>
        /// Defines a unit-length Vector4ui that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4ui UnitZ = new Vector4ui(0, 0, 1, 0);

        /// <summary>
        /// Defines a unit-length Vector4ui that points towards the W-axis.
        /// </summary>
        public static readonly Vector4ui UnitW = new Vector4ui(0, 0, 0, 1);

        /// <summary>
        /// Defines a zero-length Vector4ui.
        /// </summary>
        public static readonly Vector4ui Zero = new Vector4ui(0, 0, 0, 0);

        /// <summary>
        /// Defines an instance with all components set to 1.
        /// </summary>
        public static readonly Vector4ui One = new Vector4ui(1, 1, 1, 1);

        /// <summary>
        /// Defines the size of the Vector4ui struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(uint) * 4;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4ui(uint value)
        {
            X = Y = Z = W = value;
        }

        /// <summary>
        /// Constructs a new Vector4ui.
        /// </summary>
        /// <param name="x">The x component of the Vector4ui.</param>
        /// <param name="y">The y component of the Vector4ui.</param>
        /// <param name="z">The z component of the Vector4ui.</param>
        /// <param name="w">The w component of the Vector4ui.</param>
        public Vector4ui(uint x, uint y, uint z, uint w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4ui from the given Vector2ui.
        /// </summary>
        /// <param name="v">The Vector2ui to copy components from.</param>
        public Vector4ui(Vector2ui v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4ui from the given Vector3ui.
        /// The w component is initialized to 0.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        /// <remarks><seealso cref="Vector4ui(Vector3ui, uint)"/></remarks>
        public Vector4ui(Vector3ui v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = 0;
        }

        /// <summary>
        /// Constructs a new Vector4ui from the specified Vector3ui and w component.
        /// </summary>
        /// <param name="v">The Vector3ui to copy components from.</param>
        /// <param name="w">The w component of the new Vector4ui.</param>
        public Vector4ui(Vector3ui v, uint w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new Vector4ui from the given Vector4ui.
        /// </summary>
        /// <param name="v">The Vector4ui to copy components from.</param>
        public Vector4ui(Vector4ui v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        public uint this[int index]
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
                throw new IndexOutOfRangeException();
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
                throw new IndexOutOfRangeException();
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
        public uint LengthSquared
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
        public static Vector4ui Sub(Vector4ui a, Vector4ui b)
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
        public static void Sub(ref Vector4ui a, ref Vector4ui b, out Vector4ui result)
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
        public static Vector4ui Mult(Vector4ui a, uint f)
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
        public static void Mult(ref Vector4ui a, uint f, out Vector4ui result)
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
        public static Vector4ui Div(Vector4ui a, uint f)
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
        public static void Div(ref Vector4ui a, uint f, out Vector4ui result)
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
        public static Vector4ui Add(Vector4ui a, Vector4ui b)
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
        public static void Add(ref Vector4ui a, ref Vector4ui b, out Vector4ui result)
        {
            result = new Vector4ui(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        /// <summary>
        /// Subtract one Vector from another
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of subtraction</returns>
        public static Vector4ui Subtract(Vector4ui a, Vector4ui b)
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
        public static void Subtract(ref Vector4ui a, ref Vector4ui b, out Vector4ui result)
        {
            result = new Vector4ui(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4ui Multiply(Vector4ui vector, uint scale)
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
        public static void Multiply(ref Vector4ui vector, uint scale, out Vector4ui result)
        {
            result = new Vector4ui(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);
        }

        /// <summary>
        /// Multiplies a vector by the components a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4ui Multiply(Vector4ui vector, Vector4ui scale)
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
        public static void Multiply(ref Vector4ui vector, ref Vector4ui scale, out Vector4ui result)
        {
            result = new Vector4ui(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z, vector.W * scale.W);
        }

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4ui Divide(Vector4ui vector, uint scale)
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
        public static void Divide(ref Vector4ui vector, uint scale, out Vector4ui result)
        {
            Multiply(ref vector, 1 / scale, out result);
        }

        /// <summary>
        /// Divides a vector by the components of a vector (scale).
        /// </summary>
        /// <param name="vector">Left operand.</param>
        /// <param name="scale">Right operand.</param>
        /// <returns>Result of the operation.</returns>
        public static Vector4ui Divide(Vector4ui vector, Vector4ui scale)
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
        public static void Divide(ref Vector4ui vector, ref Vector4ui scale, out Vector4ui result)
        {
            result = new Vector4ui(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z, vector.W / scale.W);
        }

        /// <summary>
        /// Calculate the component-wise minimum of two vectors
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>The component-wise minimum</returns>
        public static Vector4ui Min(Vector4ui a, Vector4ui b)
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
        public static void Min(ref Vector4ui a, ref Vector4ui b, out Vector4ui result)
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
        public static Vector4ui Max(Vector4ui a, Vector4ui b)
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
        public static void Max(ref Vector4ui a, ref Vector4ui b, out Vector4ui result)
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
        public static Vector4ui Clamp(Vector4ui vec, Vector4ui min, Vector4ui max)
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
        public static void Clamp(ref Vector4ui vec, ref Vector4ui min, ref Vector4ui max, out Vector4ui result)
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
        public static uint Dot(Vector4ui left, Vector4ui right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Calculate the dot product of two vectors
        /// </summary>
        /// <param name="left">First operand</param>
        /// <param name="right">Second operand</param>
        /// <param name="result">The dot product of the two inputs</param>
        public static void Dot(ref Vector4ui left, ref Vector4ui right, out uint result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the X and Y components of this instance.
        /// </summary>
        public Vector2ui XY
        {
            get { return new Vector2ui(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the X and Z components of this instance.
        /// </summary>
        public Vector2ui XZ
        {
            get { return new Vector2ui(X, Z); }
            set
            {
                X = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the X and W components of this instance.
        /// </summary>
        public Vector2ui XW
        {
            get { return new Vector2ui(X, W); }
            set
            {
                X = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the Y and X components of this instance.
        /// </summary>
        
        public Vector2ui YX
        {
            get { return new Vector2ui(Y, X); }
            set
            {
                Y = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the Y and Z components of this instance.
        /// </summary>
        
        public Vector2ui YZ
        {
            get { return new Vector2ui(Y, Z); }
            set
            {
                Y = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the Y and W components of this instance.
        /// </summary>
        
        public Vector2ui YW
        {
            get { return new Vector2ui(Y, W); }
            set
            {
                Y = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the Z and X components of this instance.
        /// </summary>
        
        public Vector2ui ZX
        {
            get { return new Vector2ui(Z, X); }
            set
            {
                Z = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the Z and Y components of this instance.
        /// </summary>
        
        public Vector2ui ZY
        {
            get { return new Vector2ui(Z, Y); }
            set
            {
                Z = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets an Vector2ui with the Z and W components of this instance.
        /// </summary>
        
        public Vector2ui ZW
        {
            get { return new Vector2ui(Z, W); }
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the W and X components of this instance.
        /// </summary>
        
        public Vector2ui WX
        {
            get { return new Vector2ui(W, X); }
            set
            {
                W = value.X;
                X = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the W and Y components of this instance.
        /// </summary>
        
        public Vector2ui WY
        {
            get { return new Vector2ui(W, Y); }
            set
            {
                W = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector2ui with the W and Z components of this instance.
        /// </summary>
        
        public Vector2ui WZ
        {
            get { return new Vector2ui(W, Z); }
            set
            {
                W = value.X;
                Z = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, Y, and Z components of this instance.
        /// </summary>
        
        public Vector3ui XYZ
        {
            get { return new Vector3ui(X, Y, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, Y, and Z components of this instance.
        /// </summary>
        
        public Vector3ui XYW
        {
            get { return new Vector3ui(X, Y, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, Z, and Y components of this instance.
        /// </summary>
        
        public Vector3ui XZY
        {
            get { return new Vector3ui(X, Z, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, Z, and W components of this instance.
        /// </summary>
        
        public Vector3ui XZW
        {
            get { return new Vector3ui(X, Z, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, W, and Y components of this instance.
        /// </summary>
        
        public Vector3ui XWY
        {
            get { return new Vector3ui(X, W, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the X, W, and Z components of this instance.
        /// </summary>
        
        public Vector3ui XWZ
        {
            get { return new Vector3ui(X, W, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Y, X, and Z components of this instance.
        /// </summary>
        
        public Vector3ui YXZ
        {
            get { return new Vector3ui(Y, X, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Y, X, and W components of this instance.
        /// </summary>
        
        public Vector3ui YXW
        {
            get { return new Vector3ui(Y, X, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Y, Z, and X components of this instance.
        /// </summary>
        
        public Vector3ui YZX
        {
            get { return new Vector3ui(Y, Z, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Y, Z, and W components of this instance.
        /// </summary>
        
        public Vector3ui YZW
        {
            get { return new Vector3ui(Y, Z, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Y, W, and X components of this instance.
        /// </summary>
        
        public Vector3ui YWX
        {
            get { return new Vector3ui(Y, W, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets an Vector3ui with the Y, W, and Z components of this instance.
        /// </summary>
        
        public Vector3ui YWZ
        {
            get { return new Vector3ui(Y, W, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, X, and Y components of this instance.
        /// </summary>
        
        public Vector3ui ZXY
        {
            get { return new Vector3ui(Z, X, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, X, and W components of this instance.
        /// </summary>
        
        public Vector3ui ZXW
        {
            get { return new Vector3ui(Z, X, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, Y, and X components of this instance.
        /// </summary>
        
        public Vector3ui ZYX
        {
            get { return new Vector3ui(Z, Y, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, Y, and W components of this instance.
        /// </summary>
        
        public Vector3ui ZYW
        {
            get { return new Vector3ui(Z, Y, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, W, and X components of this instance.
        /// </summary>
        
        public Vector3ui ZWX
        {
            get { return new Vector3ui(Z, W, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the Z, W, and Y components of this instance.
        /// </summary>
        
        public Vector3ui ZWY
        {
            get { return new Vector3ui(Z, W, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, X, and Y components of this instance.
        /// </summary>
        
        public Vector3ui WXY
        {
            get { return new Vector3ui(W, X, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, X, and Z components of this instance.
        /// </summary>
        
        public Vector3ui WXZ
        {
            get { return new Vector3ui(W, X, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, Y, and X components of this instance.
        /// </summary>
        
        public Vector3ui WYX
        {
            get { return new Vector3ui(W, Y, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, Y, and Z components of this instance.
        /// </summary>
        
        public Vector3ui WYZ
        {
            get { return new Vector3ui(W, Y, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, Z, and X components of this instance.
        /// </summary>
        
        public Vector3ui WZX
        {
            get { return new Vector3ui(W, Z, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector3ui with the W, Z, and Y components of this instance.
        /// </summary>
        
        public Vector3ui WZY
        {
            get { return new Vector3ui(W, Z, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the X, Y, W, and Z components of this instance.
        /// </summary>
        
        public Vector4ui XYWZ
        {
            get { return new Vector4ui(X, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the X, Z, Y, and W components of this instance.
        /// </summary>
        
        public Vector4ui XZYW
        {
            get { return new Vector4ui(X, Z, Y, W); }
            set
            {
                X = value.X;
                Z = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the X, Z, W, and Y components of this instance.
        /// </summary>
        
        public Vector4ui XZWY
        {
            get { return new Vector4ui(X, Z, W, Y); }
            set
            {
                X = value.X;
                Z = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the X, W, Y, and Z components of this instance.
        /// </summary>
        
        public Vector4ui XWYZ
        {
            get { return new Vector4ui(X, W, Y, Z); }
            set
            {
                X = value.X;
                W = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the X, W, Z, and Y components of this instance.
        /// </summary>
        
        public Vector4ui XWZY
        {
            get { return new Vector4ui(X, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, X, Z, and W components of this instance.
        /// </summary>
        
        public Vector4ui YXZW
        {
            get { return new Vector4ui(Y, X, Z, W); }
            set
            {
                Y = value.X;
                X = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, X, W, and Z components of this instance.
        /// </summary>
        
        public Vector4ui YXWZ
        {
            get { return new Vector4ui(Y, X, W, Z); }
            set
            {
                Y = value.X;
                X = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4ui with the Y, Y, Z, and W components of this instance.
        /// </summary>
        
        public Vector4ui YYZW
        {
            get { return new Vector4ui(Y, Y, Z, W); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4ui with the Y, Y, W, and Z components of this instance.
        /// </summary>
        
        public Vector4ui YYWZ
        {
            get { return new Vector4ui(Y, Y, W, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, Z, X, and W components of this instance.
        /// </summary>
        
        public Vector4ui YZXW
        {
            get { return new Vector4ui(Y, Z, X, W); }
            set
            {
                Y = value.X;
                Z = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, Z, W, and X components of this instance.
        /// </summary>
        
        public Vector4ui YZWX
        {
            get { return new Vector4ui(Y, Z, W, X); }
            set
            {
                Y = value.X;
                Z = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, W, X, and Z components of this instance.
        /// </summary>
        
        public Vector4ui YWXZ
        {
            get { return new Vector4ui(Y, W, X, Z); }
            set
            {
                Y = value.X;
                W = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Y, W, Z, and X components of this instance.
        /// </summary>
        
        public Vector4ui YWZX
        {
            get { return new Vector4ui(Y, W, Z, X); }
            set
            {
                Y = value.X;
                W = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, X, Y, and Z components of this instance.
        /// </summary>
        
        public Vector4ui ZXYW
        {
            get { return new Vector4ui(Z, X, Y, W); }
            set
            {
                Z = value.X;
                X = value.Y;
                Y = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, X, W, and Y components of this instance.
        /// </summary>
        
        public Vector4ui ZXWY
        {
            get { return new Vector4ui(Z, X, W, Y); }
            set
            {
                Z = value.X;
                X = value.Y;
                W = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, Y, X, and W components of this instance.
        /// </summary>
        
        public Vector4ui ZYXW
        {
            get { return new Vector4ui(Z, Y, X, W); }
            set
            {
                Z = value.X;
                Y = value.Y;
                X = value.Z;
                W = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, Y, W, and X components of this instance.
        /// </summary>
        
        public Vector4ui ZYWX
        {
            get { return new Vector4ui(Z, Y, W, X); }
            set
            {
                Z = value.X;
                Y = value.Y;
                W = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, W, X, and Y components of this instance.
        /// </summary>
        
        public Vector4ui ZWXY
        {
            get { return new Vector4ui(Z, W, X, Y); }
            set
            {
                Z = value.X;
                W = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the Z, W, Y, and X components of this instance.
        /// </summary>
        
        public Vector4ui ZWYX
        {
            get { return new Vector4ui(Z, W, Y, X); }
            set
            {
                Z = value.X;
                W = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4ui with the Z, W, Z, and Y components of this instance.
        /// </summary>
        
        public Vector4ui ZWZY
        {
            get { return new Vector4ui(Z, W, Z, Y); }
            set
            {
                X = value.X;
                W = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, X, Y, and Z components of this instance.
        /// </summary>
        
        public Vector4ui WXYZ
        {
            get { return new Vector4ui(W, X, Y, Z); }
            set
            {
                W = value.X;
                X = value.Y;
                Y = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, X, Z, and Y components of this instance.
        /// </summary>
        
        public Vector4ui WXZY
        {
            get { return new Vector4ui(W, X, Z, Y); }
            set
            {
                W = value.X;
                X = value.Y;
                Z = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, Y, X, and Z components of this instance.
        /// </summary>
        
        public Vector4ui WYXZ
        {
            get { return new Vector4ui(W, Y, X, Z); }
            set
            {
                W = value.X;
                Y = value.Y;
                X = value.Z;
                Z = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, Y, Z, and X components of this instance.
        /// </summary>
        
        public Vector4ui WYZX
        {
            get { return new Vector4ui(W, Y, Z, X); }
            set
            {
                W = value.X;
                Y = value.Y;
                Z = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, Z, X, and Y components of this instance.
        /// </summary>
        
        public Vector4ui WZXY
        {
            get { return new Vector4ui(W, Z, X, Y); }
            set
            {
                W = value.X;
                Z = value.Y;
                X = value.Z;
                Y = value.W;
            }
        }

        /// <summary>
        /// Gets or sets an Vector4ui with the W, Z, Y, and X components of this instance.
        /// </summary>
        
        public Vector4ui WZYX
        {
            get { return new Vector4ui(W, Z, Y, X); }
            set
            {
                W = value.X;
                Z = value.Y;
                Y = value.Z;
                X = value.W;
            }
        }

        /// <summary>
        /// Gets an Vector4ui with the W, Z, Y, and W components of this instance.
        /// </summary>
        public Vector4ui WZYW
        {
            get { return new Vector4ui(W, Z, Y, W); }
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
        public static Vector4ui operator +(Vector4ui left, Vector4ui right)
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
        public static Vector4ui operator -(Vector4ui left, Vector4ui right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="vec">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The result of the calculation.</returns>
        public static Vector4ui operator *(Vector4ui vec, uint scale)
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
        public static Vector4ui operator *(uint scale, Vector4ui vec)
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
        public static Vector4ui operator /(Vector4ui vec, uint scale)
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
        public static bool operator ==(Vector4ui left, Vector4ui right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equa lright; false otherwise.</returns>
        public static bool operator !=(Vector4ui left, Vector4ui right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        unsafe public static explicit operator uint* (Vector4ui v)
        {
            return &v.X;
        }

        /// <summary>
        /// Returns a pointer to the first element of the specified instance.
        /// </summary>
        /// <param name="v">The instance.</param>
        /// <returns>A pointer to the first element of v.</returns>
        public static explicit operator IntPtr(Vector4ui v)
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
            if (!(obj is Vector4ui))
                return false;

            return this.Equals((Vector4ui)obj);
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector4ui other)
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
            uint.TryParse(parts[0].Trim(), out X);
            uint.TryParse(parts[1].Trim(), out Y);
            uint.TryParse(parts[2].Trim(), out Z);
            uint.TryParse(parts[3].Trim(), out W);
        }

        /// <summary>
        /// Returns a System.String that represents the current Vector4ui.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("({0} , {1} , {2} , {3})", X, Y, Z, W);
        }

        /// <summary>
        /// Gets the array representation of the Vector4ui.
        /// </summary>
        public uint[] ToArray()
        {
            return new uint[] { X, Y, Z, W };
        }
    }
}