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
    /// Represent a point.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Point3i>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3i : IEquatable<Point3i>, ILoadFromString
    {
        /// <summary>
        /// The X coordinate of the Point3i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y coordinate of the Point3i.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z coordinate of the Point3i.
        /// </summary>
        public int Z;
        
        /// <summary>
        /// A Point3i at 1-1-1.
        /// </summary>
        public static readonly Point3i One = new Point3i(1);

        /// <summary>
        /// A Point3i at 0-0-0.
        /// </summary>
        public static readonly Point3i Zero = new Point3i(0);

        /// <summary>
        /// A Point3i at 1-0-0
        /// </summary>
        public static readonly Point3i UnitX = new Point3i(1, 0, 0);

        /// <summary>
        /// A Point3i at 0-1-0
        /// </summary>
        public static readonly Point3i UnitY = new Point3i(0, 1, 0);

        /// <summary>
        /// A Point3i at 0-0-1
        /// </summary>
        public static readonly Point3i UnitZ = new Point3i(0, 0, 1);
        
        /// <summary>
        /// Construct a new Point3i.
        /// </summary>
        /// <param name="value">The value used to fill the coordinates of the Point3i</param>
        public Point3i(int value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Construct a new Point3i.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Point3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Construct a new Point3i.
        /// </summary>
        /// <param name="point">A Point3i used to copy</param>
        public Point3i(Point3i point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Construct a new Point3i.
        /// </summary>
        /// <param name="values">The array of values</param>
        public Point3i(int[] values)
        {
            if (values.Length < 3)
                throw new ArgumentException("The length of the array is lower than three.", "values");

            X = values[0];
            Y = values[1];
            Z = values[2];
        }

        /// <summary>
        /// Returns the distance between this Point3i and <see cref="Zero"/>.
        /// </summary>
        public float Distance()
        {
            return Distance(Zero);
        }

        /// <summary>
        /// Returns the distance between this Point3i and an other.
        /// </summary>
        /// <param name="x">The X coordinate of the second Point3i</param>
        /// <param name="y">The Y coordinate of the second Point3i</param>
        /// <param name="z">The Z coordinate of the second Point3i</param>
        public float Distance(int x, int y, int z)
        {
            return MathHelper.Sqrt((X - x) * (X - x) + (Y - y) * (Y - y));
        }

        /// <summary>
        /// Returns the distance between this Point3i and an other.
        /// </summary>
        /// <param name="point">The second Point3i</param>
        /// <returns></returns>
        public float Distance(Point3i point)
        {
            return Distance(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Move this Point3i to another position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="z">The new Y coordinate</param>
        public void MoveTo(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Move this Point3i to another position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveTo(Point3i point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Move this Point3i to another position relatively to the current position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="y">The new Y coordinate</param>
        public void MoveRelative(int x, int y, int z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        /// <summary>
        /// Move this Point3i to another position relatively to the current position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveRelative(Point3i point)
        {
            X += point.X;
            Y += point.Y;
            Z += point.Z;
        }

        /// <summary>
        /// Compare two <see cref="Point3i"/> for equality.
        /// </summary>
        /// <param name="lhs">First Point3i</param>
        /// <param name="rhs">Second Point3i</param>
        public static bool operator ==(Point3i lhs, Point3i rhs)
        {
            bool Result = false;

            if (ReferenceEquals(lhs, rhs))
            {
                Result = true;
            }

            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            {
                Result = true;
            }

            if (!ReferenceEquals(lhs, null) && !ReferenceEquals(rhs, null))
            {
                if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
                {
                    Result = true;
                }
            }

            return Result;
        }

        /// <summary>
        /// Compare two <see cref="Point3i"/> for difference.
        /// </summary>
        /// <param name="lhs">First Point3i</param>
        /// <param name="rhs">Second Point3i</param>
        public static bool operator !=(Point3i lhs, Point3i rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Compare this <see cref="Point3i"/> and an <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        public override bool Equals(object obj)
        {
            bool Result = false;

            // In order to have "equality", we must have same type of objects
            if (GetType() == obj.GetType() && obj is Point3i)
            {
                // Check whether we have same instance
                if (ReferenceEquals(this, obj))
                {
                    Result = true;
                }

                // Check whether both objects are null
                if (ReferenceEquals(this, null) && ReferenceEquals(obj, null))
                {
                    Result = true;
                }

                // Check whether the "contents" are the same
                if (!ReferenceEquals(this, null) && !ReferenceEquals(obj, null))
                {
                    Point3i Point = (Point3i)obj;

                    if (X == Point.X && Y == Point.Y && Z == Point.Z)
                    {
                        Result = true;
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Returns an unique hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Compare two <see cref="Point3i"/> for equality.
        /// </summary>
        /// <param name="other">The other Point3i to compare with this instance</param>
        public bool Equals(Point3i other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Returns the string representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return string.Format("P({0},{1},{2})", X, Y, Z);
        }

        /// <summary>
        /// Returns the array representation of this instance.
        /// </summary>
        public int[] ToArray()
        {
            return new int[] { X, Y, Z };
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.Load(string value)
        {
            var parts = value.Trim('P', '(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(parts[0].Trim(), out X);
            int.TryParse(parts[1].Trim(), out Y);
            int.TryParse(parts[2].Trim(), out Z);
        }
    }
}
