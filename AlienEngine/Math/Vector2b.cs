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
    [TypeConverter(typeof(StructTypeConverter<Vector2b>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2b : IEquatable<Vector2b>, ILoadFromString
    {
        /// <summary>
        /// The X component of the Vector2b.
        /// </summary>
        public bool X;

        /// <summary>
        /// The Y component of the Vector2b.
        /// </summary>
        public bool Y;


        /// <summary>
        /// Defines a unit-length <see cref="Vector2b"/> that points towards the X-axis.
        /// </summary>
        public static readonly Vector2b UnitX = new Vector2b(true, false);

        /// <summary>
        /// Defines a unit-length <see cref="Vector2b"/> that points towards the Y-axis.
        /// </summary>
        public static readonly Vector2b UnitY = new Vector2b(false, true);

        /// <summary>
        /// Defines a zero-length <see cref="Vector2b"/>.
        /// </summary>
        public static readonly Vector2b Zero = new Vector2b(false);

        /// <summary>
        /// Defines a <see cref="Vector2b"/> populated with true.
        /// </summary>
        public static readonly Vector2b One = new Vector2b(true);

        /// <summary>
        /// Defines the size of the Vector2f struct in bytes.
        /// </summary>
        public const int SizeInBytes = sizeof(bool) * 2;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="value">The value that will initialize this instance.</param>
        public Vector2b(bool value)
        {
            X = Y = value;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="x">The x coordinate of the net Vector2b.</param>
        /// <param name="y">The y coordinate of the net Vector2b.</param>
        public Vector2b(bool x, bool y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector2b to copy.</param>
        public Vector2b(Vector2b v)
        {
            X = v.X;
            Y = v.Y;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        public Vector2b(Vector3b v)
        {
            X = v.X;
            Y = v.Y;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="v">The Vector3b to copy.</param>
        public Vector2b(Vector4b v)
        {
            X = v.X;
            Y = v.Y;
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
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Compares the specified instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator !=(Vector2b left, Vector2b right)
        {
            return (left.X != right.X || left.Y != right.Y);
        }

        /// <summary>
        /// Compares the specified instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if both instances are not equal; false otherwise.</returns>
        public static bool operator ==(Vector2b left, Vector2b right)
        {
            return (left.X == right.X && left.Y == right.Y);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector2b) && (Equals((Vector2b)obj));
        }

        /// <summary>Indicates whether the current vector is equal to another vector.</summary>
        /// <param name="other">A vector to compare with this vector.</param>
        /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
        public bool Equals(Vector2b other)
        {
            return (X == other.X && Y == other.Y);
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
            bool.TryParse(parts[1], out X);
        }

        /// <summary>
        /// Gets the array representation of the Vector2f.
        /// </summary>
        public bool[] ToArray()
        {
            return new bool[] { X, Y };
        }

        /// <summary>
        /// Returns a string that represents the current Vector2b.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0} , {1})", X, Y);
        }
    }
}