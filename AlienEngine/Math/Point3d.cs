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
    [TypeConverter(typeof(StructTypeConverter<Point3d>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3d : IEquatable<Point3d>, ILoadFromString
    {
        /// <summary>
        /// The X coordinate of the Point3d.
        /// </summary>
        public double X;

        /// <summary>
        /// The Y coordinate of the Point3d.
        /// </summary>
        public double Y;

        /// <summary>
        /// The Z coordinate of the Point3d.
        /// </summary>
        public double Z;

        /// <summary>
        /// A Point3d at 1-1-1.
        /// </summary>
        public static readonly Point3d One = new Point3d(1);

        /// <summary>
        /// A Point3d at 0-0-0.
        /// </summary>
        public static readonly Point3d Zero = new Point3d(0);

        /// <summary>
        /// A Point3d at 1-0-0
        /// </summary>
        public static readonly Point3d UnitX = new Point3d(1, 0, 0);

        /// <summary>
        /// A Point3d at 0-1-0
        /// </summary>
        public static readonly Point3d UnitY = new Point3d(0, 1, 0);

        /// <summary>
        /// A Point3d at 0-0-1
        /// </summary>
        public static readonly Point3d UnitZ = new Point3d(0, 0, 1);

        /// <summary>
        /// Construct a new Point3d.
        /// </summary>
        /// <param name="value">The value used to fill the coordinates of the Point3d</param>
        public Point3d(double value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Construct a new Point3d.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Construct a new Point3d.
        /// </summary>
        /// <param name="point">A Point3d used to copy</param>
        public Point3d(Point3d point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Construct a new Point3d.
        /// </summary>
        /// <param name="values">The array of values</param>
        public Point3d(double[] values)
        {
            if (values.Length < 3)
                throw new ArgumentException("The length of the array is lower than three.", "values");

            X = values[0];
            Y = values[1];
            Z = values[2];
        }

        /// <summary>
        /// Returns the distance between this Point3d and <see cref="Zero"/>.
        /// </summary>
        public double Distance()
        {
            return Distance(Zero);
        }

        /// <summary>
        /// Returns the distance between this Point3d and an other.
        /// </summary>
        /// <param name="x">The X coordinate of the second Point3d</param>
        /// <param name="y">The Y coordinate of the second Point3d</param>
        /// <param name="z">The Z coordinate of the second Point3d</param>
        public double Distance(double x, double y, double z)
        {
            return System.Math.Sqrt((X - x) * (X - x) + (Y - y) * (Y - y));
        }

        /// <summary>
        /// Returns the distance between this Point3d and an other.
        /// </summary>
        /// <param name="point">The second Point3d</param>
        /// <returns></returns>
        public double Distance(Point3d point)
        {
            return Distance(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Move this Point3d to another position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="z">The new Y coordinate</param>
        public void MoveTo(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Move this Point3d to another position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveTo(Point3d point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        /// <summary>
        /// Move this Point3d to another position relatively to the current position.
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="y">The new Y coordinate</param>
        public void MoveRelative(double x, double y, double z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        /// <summary>
        /// Move this Point3d to another position relatively to the current position.
        /// </summary>
        /// <param name="point">The new position</param>
        public void MoveRelative(Point3d point)
        {
            X += point.X;
            Y += point.Y;
            Z += point.Z;
        }

        /// <summary>
        /// Compare two <see cref="Point3d"/> for equality.
        /// </summary>
        /// <param name="lhs">First Point3d</param>
        /// <param name="rhs">Second Point3d</param>
        public static bool operator ==(Point3d lhs, Point3d rhs)
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
        /// Compare two <see cref="Point3d"/> for difference.
        /// </summary>
        /// <param name="lhs">First Point3d</param>
        /// <param name="rhs">Second Point3d</param>
        public static bool operator !=(Point3d lhs, Point3d rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Compare this <see cref="Point3d"/> and an <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        public override bool Equals(object obj)
        {
            bool Result = false;

            // In order to have "equality", we must have same type of objects
            if (GetType() == obj.GetType() && obj is Point3d)
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
                    Point3d Point = (Point3d)obj;

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
        /// Compare two <see cref="Point3d"/> for equality.
        /// </summary>
        /// <param name="other">The other Point3d to compare with this instance</param>
        public bool Equals(Point3d other)
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
        public double[] ToArray()
        {
            return new double[] { X, Y, Z };
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.Load(string value)
        {
            var parts = value.Trim('P', '(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            double.TryParse(parts[0].Trim(), out X);
            double.TryParse(parts[1].Trim(), out Y);
            double.TryParse(parts[2].Trim(), out Z);
        }
    }
}
