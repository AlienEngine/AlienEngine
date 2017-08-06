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
    [TypeConverter(typeof(StructTypeConverter<Point3f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3f : IEquatable<Point3f>, ILoadFromString
    {
        /// <summary>
        /// The X coordinate of the Point3f.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y coordinate of the Point3f.
        /// </summary>
        public float Y;

        /// <summary>
        /// The Z coordinate of the Point3f.
        /// </summary>
        public float Z;

        /// <summary>
        /// A Point3f at 1-1-1.
        /// </summary>
        public static readonly Point3f One = new Point3f(1);

        /// <summary>
        /// A Point3f at 0-0-0.
        /// </summary>
        public static readonly Point3f Zero = new Point3f(0);

        /// <summary>
        /// A Point3f at 1-0-0
        /// </summary>
        public static readonly Point3f UnitX = new Point3f(1, 0, 0);

        /// <summary>
        /// A Point3f at 0-1-0
        /// </summary>
        public static readonly Point3f UnitY = new Point3f(0, 1, 0);

        /// <summary>
        /// A Point3f at 0-0-1
        /// </summary>
        public static readonly Point3f UnitZ = new Point3f(0, 0, 1);

        /// <summary>
        /// Construct a new Point3f.
        /// </summary>
        /// <param name="value">The value used to fill the coordinates of the Point3f</param>
        public Point3f(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Construct a new Point3f.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Point3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Construct a new Point3f.
        /// </summary>
        /// <param name="point">A Point3f used to copy</param>
        public Point3f(Point3f point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Construct a new Point3f.
        /// </summary>
        /// <param name="values">The array of values</param>
        public Point3f(float[] values)
        {
            if (values.Length < 3)
                throw new ArgumentException("The length of the array is lower than three.", "values");

            X = values[0];
            Y = values[1];
            Z = values[2];
        }

        /// <summary>
        /// Returns the distance between this Point3f and <see cref="Zero"/>.
        /// </summary>
        public float Distance()
        {
            return Distance(Zero);
        }

        /// <summary>
        /// Returns the distance between this Point3f and an other.
        /// </summary>
        /// <param name="x">The X coordinate of the second Point3f</param>
        /// <param name="y">The Y coordinate of the second Point3f</param>
        /// <param name="z">The Z coordinate of the second Point3f</param>
        public float Distance(float x, float y, float z)
        {
            return MathHelper.Sqrt((X - x) * (X - x) + (Y - y) * (Y - y));
        }

        /// <summary>
        /// Returns the distance between this Point3f and an other.
        /// </summary>
        /// <param name="point">The second Point3f</param>
        /// <returns></returns>
        public float Distance(Point3f point)
        {
            return Distance(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Move this Point3f to another position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="z">The new Y coordinate</param>
        public void MoveTo(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Move this Point3f to another position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveTo(Point3f point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Move this Point3f to another position relatively to the current position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="y">The new Y coordinate</param>
        public void MoveRelative(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        /// <summary>
        /// Move this Point3f to another position relatively to the current position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveRelative(Point3f point)
        {
            X += point.X;
            Y += point.Y;
            Z += point.Z;
        }

        /// <summary>
        /// Returns a new <see cref="Point3f"/> with minimal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point3f Min(Point3f a, Point3f b)
        {
            return new Point3f((a.X > b.X) ? b.X : a.X, (a.Y > b.Y) ? b.Y : a.Y, (a.Z > b.Z) ? b.Z : a.Z);
        }

        /// <summary>
        /// Returns a new <see cref="Point3f"/> with maximal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point3f Max(Point3f a, Point3f b)
        {
            return new Point3f((a.X < b.X) ? b.X : a.X, (a.Y < b.Y) ? b.Y : a.Y, (a.Z > b.Z) ? b.Z : a.Z);
        }

        /// <summary>
        /// Create a <see cref="Vector3f"/> with two <see cref="Point3f"/>.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Vector3f CreateVector(Point3f a, Point3f b)
        {
            return new Vector3f(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
        }

        /// <summary>
        /// Compare two <see cref="Point3f"/> for equality.
        /// </summary>
        /// <param name="lhs">First Point3f</param>
        /// <param name="rhs">Second Point3f</param>
        public static bool operator ==(Point3f lhs, Point3f rhs)
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
        /// Compare two <see cref="Point3f"/> for difference.
        /// </summary>
        /// <param name="lhs">First Point3f</param>
        /// <param name="rhs">Second Point3f</param>
        public static bool operator !=(Point3f lhs, Point3f rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Converts a <see cref="Vector3f"/> in a <see cref="Point3f"/>.
        /// </summary>
        /// <param name="vector"></param>
        public static explicit operator Point3f(Vector3f vector)
        {
            return new Point3f(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Compare this <see cref="Point3f"/> and an <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        public override bool Equals(object obj)
        {
            bool Result = false;

            // In order to have "equality", we must have same type of objects
            if (GetType() == obj.GetType() && obj is Point3f)
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
                    Point3f Point = (Point3f)obj;

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
        /// Compare two <see cref="Point3f"/> for equality.
        /// </summary>
        /// <param name="other">The other Point3f to compare with this instance</param>
        public bool Equals(Point3f other)
        {
            return (X == other.X && Y == other.Y && Z == other.Z);
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
        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.Load(string value)
        {
            var parts = value.Trim('P', '(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            float.TryParse(parts[0].Trim(), out X);
            float.TryParse(parts[1].Trim(), out Y);
            float.TryParse(parts[2].Trim(), out Z);
        }
    }
}
