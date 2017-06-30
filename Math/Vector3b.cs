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
    /// Represents a three dimensional vector.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Vector3b>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3b : IEquatable<Vector3b>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector3b.
        /// </summary>
        public bool X;

        /// <summary>
        /// The Y component of the Vector3b.
        /// </summary>
        public bool Y;

        /// <summary>
        /// The Z component of the Vector3b.
        /// </summary>
        public bool Z;

        /// <summary>
        /// Defines a unit-length <see cref="Vector3b"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector3b UnitX = new Vector3b(true, false, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector3b"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector3b UnitY = new Vector3b(false, true, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector3b"/> that points towards the Z-axis.
        /// </summary>
        public static readonly Vector3b UnitZ = new Vector3b(false, false, true);

        /// <summary>
        /// Defines a zero-length <see cref="Vector3b"/>.
        /// </summary>
        public static readonly Vector3b Zero = new Vector3b(false);

        /// <summary>
        /// Defines a <see cref="Vector3b"/> populated with true.
        /// </summary>
        public static readonly Vector3b One = new Vector3b(true);

        /// <summary>
        /// Defines the size of the Vector2f struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(bool) * 3;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector3b(bool value)
        {
            X = Y = Z = value;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="x">The x coordinate of the net Vector3b.</param>
        /// <param name="y">The y coordinate of the net Vector3b.</param>
        public Vector3b(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector2b to copy.</param>
        public Vector3b(Vector2b v)
        {
            X = v.X;
            Y = v.Y;
            Z = false;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector2b to copy.</param>
        /// <param name="z">The z axis.</param>
        public Vector3b(Vector2b v, bool z)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = z;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        public Vector3b(Vector3b v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        public Vector3b(Vector4b v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
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
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else if (index == 2) Z = value;
                else throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Compares the specified instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator !=(Vector3b left, Vector3b right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z);
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator ==(Vector3b left, Vector3b right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector3b) && (Equals((Vector3b)obj));
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector3b other)
        {
            return (X == other.X && Y == other.Y && Z == other.Z);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Trim('(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            bool.TryParse(parts[0], out X);
            bool.TryParse(parts[1], out Y);
            bool.TryParse(parts[2], out Z);
        }

        /// <summary>
        /// Gets the array representation of the Vector2f.
        /// </summary>
        public bool[] ToArray()
        {
            return new bool[] { X, Y, Z };
        }

        /// <summary>
        /// Returns a string that represents the current Vector3b.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0} , {1} , {2})", X, Y, Z);
        }
    }
}