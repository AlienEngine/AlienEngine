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
    [TypeConverter(typeof(StructTypeConverter<Point2i>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2i : IEquatable<Point2i>, ILoadFromString
    {
        /// <summary>
        /// The X coordinate of the Point2i.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y coordinate of the Point2i.
        /// </summary>
        public int Y;

        /// <summary>
        /// A Point2i at 1-1.
        /// </summary>
        public static readonly Point2i One = new Point2i(1);

        /// <summary>
        /// A Point2i at 0-0.
        /// </summary>
        public static readonly Point2i Zero = new Point2i(0);

        /// <summary>
        /// A Point2i at 1-0
        /// </summary>
        public static readonly Point2i UnitX = new Point2i(1, 0);

        /// <summary>
        /// A Point2i at 0-1
        /// </summary>
        public static readonly Point2i UnitY = new Point2i(0, 1);

        /// <summary>
        /// Construct a new Point2i.
        /// </summary>
        /// <param name="value">The value used to fill the coordinates of the Point2i</param>
        public Point2i(int value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Construct a new Point2i.
        /// </summary>
        /// <param name="prmX">The X coordinate</param>
        /// <param name="prmY">The Y coordinate</param>
        public Point2i(int prmX, int prmY)
        {
            X = prmX;
            Y = prmY;
        }

        /// <summary>
        /// Construct a new Point2i.
        /// </summary>
        /// <param name="prmPoint">A Point2i used to copy</param>
        public Point2i(Point2i prmPoint)
        {
            X = prmPoint.X;
            Y = prmPoint.Y;
        }

        /// <summary>
        /// Construct a new Point2i.
        /// </summary>
        /// <param name="values">The array of values</param>
        public Point2i(int[] values)
        {
            if (values.Length < 2)
                throw new ArgumentException("The length of the array is lower than two.", "values");

            X = values[0];
            Y = values[1];
        }

        /// <summary>
        /// Returns the distance between this Point2i and <see cref="Zero"/>.
        /// </summary>
        public float Distance()
        {
            return Distance(Zero);
        }

        /// <summary>
        /// Returns the distance between this Point2i and an other.
        /// </summary>
        /// <param name="prmX">The X coordinate of the second Point2i</param>
        /// <param name="prmY">The Y coordiante of the second Point2i</param>
        public float Distance(int prmX, int prmY)
        {
            return MathHelper.Sqrt((X - prmX) * (X - prmX) + (Y - prmY) * (Y - prmY));
        }

        /// <summary>
        /// Returns the distance between this Point2i and an other.
        /// </summary>
        /// <param name="prmPoint">The second Point2i</param>
        public float Distance(Point2i prmPoint)
        {
            return Distance(prmPoint.X, prmPoint.Y);
        }

        /// <summary>
        /// Move this Point2i to another position.
        /// </summary>
        /// <param name="prmX">The new X coordinate</param>
        /// <param name="prmY">The new Y coordinate</param>
        public void MoveTo(int prmX, int prmY)
        {
            X = prmX;
            Y = prmY;
        }

        /// <summary>
        /// Move this Point2i to another position.
        /// </summary>
        /// <param name="prmPoint">The new position</param>
        public void MoveTo(Point2i prmPoint)
        {
            X = prmPoint.X;
            Y = prmPoint.Y;
        }

        /// <summary>
        /// Move this Point2i to another position relatively to the current position.
        /// </summary>
        /// <param name="prmX">The new X coordinate</param>
        /// <param name="prmY">The new Y coordinate</param>
        public void MoveRelative(int prmX, int prmY)
        {
            X += prmX;
            Y += prmY;
        }

        /// <summary>
        /// Move this Point2i to another position relatively to the current position.
        /// </summary>
        /// <param name="prmPoint">The new position</param>
        public void MoveRelative(Point2i prmPoint)
        {
            X += prmPoint.X;
            Y += prmPoint.Y;
        }

        /// <summary>
        /// Translate this Point2i with a <see cref="Vector2i"/>
        /// </summary>
        /// <param name="vector">The <see cref="Vector2i"/> used for translation.</param>
        public void Translate(Vector2i vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        /// <summary>
        /// Returns the distance between the point <paramref name="A"/> and the point <paramref name="B"/>.
        /// </summary>
        /// <param name="A">The first Point2i.</param>
        /// <param name="B">The second Point2i.</param>
        public static float Distance(Point2i A, Point2i B)
        {
            return A.Distance(B);
        }

        /// <summary>
        /// Move the point <paramref name="A"/> to the position of the point <paramref name="B"/>.
        /// </summary>
        /// <param name="A">The first Point2i.</param>
        /// <param name="B">The second Point2i.</param>
        public static void MoveTo(ref Point2i A, Point2i B)
        {
            A.MoveTo(B);
        }

        /// <summary>
        /// Move the point <paramref name="A"/> to the position of the point <paramref name="B"/>
        /// relatively to the current position of the point <paramref name="A"/>.
        /// </summary>
        /// <param name="A">The first Point2i.</param>
        /// <param name="B">The second Point2i.</param>
        public static void MoveRelative(ref Point2i A, Point2i B)
        {
            A.MoveRelative(B);
        }

        /// <summary>
        /// Translate the <paramref name="point"/> with a <paramref name="vector"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2i"/> to translate.</param>
        /// <param name="vector">The <see cref="Vector2i"/> used for translation.</param>
        public static void Translate(ref Point2i point, Vector2i vector)
        {
            point.Translate(vector);
        }

        /// <summary>
        /// Returns a new <see cref="Point2i"/> with minimal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point2i Min(Point2i a, Point2i b)
        {
            return new Point2i((a.X > b.X) ? b.X : a.X, (a.Y > b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Returns a new <see cref="Point2i"/> with maximal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point2i Max(Point2i a, Point2i b)
        {
            return new Point2i((a.X < b.X) ? b.X : a.X, (a.Y < b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Create a <see cref="Vector2i"/> with two <see cref="Point2i"/>.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Vector2i CreateVector(Point2i a, Point2i b)
        {
            return new Vector2i(b.X - a.X, b.Y - a.Y);
        }

        /// <summary>
        /// Add two <see cref="Point2i"/>.
        /// </summary>
        /// <param name="a">The <see cref="Point2i"/>.</param>
        /// <param name="b">The <see cref="Point2i"/>.</param>
        public static Point2i operator +(Point2i a, Point2i b)
        {
            return new Point2i(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Add a <see cref="Point2i"/> with a <see cref="Sizef"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2i"/>.</param>
        /// <param name="size">The <see cref="Sizef"/>.</param>
        /// <remarks>This translate the <paramref name="point"/> with the <paramref name="size"/>.</remarks>
        public static Point2i operator +(Point2i point, Sizei size)
        {
            return new Point2i(point.X + size.Width, point.Y + size.Height);
        }

        /// <summary>
        /// Substract a <see cref="Point2i"/> with a <see cref="Sizef"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2i"/>.</param>
        /// <param name="size">The <see cref="Sizef"/>.</param>
        /// <remarks>This translate the <paramref name="point"/> with the negative <paramref name="size"/>.</remarks>
        public static Point2i operator -(Point2i point, Sizei size)
        {
            return new Point2i(point.X - size.Width, point.Y - size.Height);
        }

        /// <summary>
        /// Substract a <see cref="Point2i"/> by another.
        /// </summary>
        /// <param name="a">The <see cref="Point2i"/>.</param>
        /// <param name="b">The <see cref="Point2i"/>.</param>
        public static Point2i operator -(Point2i a, Point2i b)
        {
            return new Point2i(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Compare two <see cref="Point2i"/> for equality.
        /// </summary>
        /// <param name="lhs">First Point2i</param>
        /// <param name="rhs">Second Point2i</param>
        public static bool operator ==(Point2i lhs, Point2i rhs)
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
                if (lhs.X == rhs.X && lhs.Y == rhs.Y)
                {
                    Result = true;
                }
            }

            return Result;
        }

        /// <summary>
        /// Compare two <see cref="Point2i"/> for difference.
        /// </summary>
        /// <param name="lhs">First Point2i</param>
        /// <param name="rhs">Second Point2i</param>
        public static bool operator !=(Point2i lhs, Point2i rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Compare this <see cref="Point2i"/> and an <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        public override bool Equals(object obj)
        {
            bool Result = false;

            // In order to have "equality", we must have same type of objects
            if (GetType() == obj.GetType() && obj is Point2i)
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
                    Point2i Point = (Point2i)obj;

                    if (X == Point.X && Y == Point.Y)
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
        /// Compare two <see cref="Point2i"/> for equality.
        /// </summary>
        /// <param name="other">The other Point2i to compare with this instance</param>
        public bool Equals(Point2i other)
        {
            return (X == other.X && Y == other.Y);
        }

        /// <summary>
        /// Returns the string representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return string.Format("P({0},{1})", X, Y);
        }

        /// <summary>
        /// Returns the array representation of this instance.
        /// </summary>
        public int[] ToArray()
        {
            return new int[] { X, Y };
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.FromString(string value)
        {
            var parts = value.Trim('P', '(', ')').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(parts[0].Trim(), out X);
            int.TryParse(parts[1].Trim(), out Y);
        }
    }
}
