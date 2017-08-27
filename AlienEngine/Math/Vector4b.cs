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
    [TypeConverter(typeof(StructTypeConverter<Vector4b>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4b : IEquatable<Vector4b>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector4b.
        /// </summary>
        public bool X;

        /// <summary>
        /// The Y component of the Vector4b.
        /// </summary>
        public bool Y;

        /// <summary>
        /// The Z component of the Vector4b.
        /// </summary>
        public bool Z;

        /// <summary>
        /// The W component of the Vector4b.
        /// </summary>
        public bool W;

        /// <summary>
        /// Defines a unit-length <see cref="Vector4b"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector4b UnitX = new Vector4b(true, false, false, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4b"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector4b UnitY = new Vector4b(false, true, false, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4b"/> that points towards the Z-axis.
        /// </summary>
        public static readonly Vector4b UnitZ = new Vector4b(false, false, true, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector4b"/> that points towards the W-axis.
        /// </summary>
        public static readonly Vector4b UnitW = new Vector4b(false, false, false, true);

        /// <summary>
        /// Defines a zero-length <see cref="Vector4b"/>.
        /// </summary>
        public static readonly Vector4b Zero = new Vector4b(false);

        /// <summary>
        /// Defines a <see cref="Vector4b"/> populated with true.
        /// </summary>
        public static readonly Vector4b One = new Vector4b(true);

        /// <summary>
        /// Defines the size of the Vector2f struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(bool) * 4;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector4b(bool value)
        {
            X = Y = Z = W = value;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="x">The x coordinate of the net Vector4b.</param>
        /// <param name="y">The y coordinate of the net Vector4b.</param>
        /// <param name="z">The z coordinate of the net Vector4b.</param>
        /// <param name="w">The w coordinate of the net Vector4b.</param>
        public Vector4b(bool x, bool y, bool z, bool w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        public Vector4b(Vector3b v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = false;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        /// <param name="w">The w coordinate.</param>
        public Vector4b(Vector3b v, bool w)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = w;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector4b to copy.</param>
        public Vector4b(Vector4b v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        /// <summary>
        /// Gets or sets the value at the index of the Vector.
        /// </summary>
        public bool this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else if (index == 2) return Z;
                else if (index == 3) return W;
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else if (index == 2) Z = value;
                else if (index == 3) W = value;
                else throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Compares the specified instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator !=(Vector4b left, Vector4b right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W);
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator ==(Vector4b left, Vector4b right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector4b) && (Equals((Vector4b)obj));
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector4b other)
        {
            return (X == other.X && Y == other.Y && Z == other.Z && W == other.W);
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
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.FromString(string value)
        {
            string[] parts = value.Trim('(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            bool.TryParse(parts[0], out X);
            bool.TryParse(parts[1], out Y);
            bool.TryParse(parts[2], out Z);
            bool.TryParse(parts[3], out W);
        }

        /// <summary>
        /// Gets the array representation of the Vector2f.
        /// </summary>
        public bool[] ToArray()
        {
            return new bool[] { X, Y, Z, W };
        }

        /// <summary>
        /// Returns a string that represents the current Vector4b.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0} , {1} , {2} , {3})", X, Y, Z, W);
        }
    }
}