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
    [TypeConverter(typeof(StructTypeConverter<Point2f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2f : IEquatable<Point2f>, ILoadFromString
    {
        /// <summary>
        /// The X coordinate of the Point2f.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y coordinate of the Point2f.
        /// </summary>
        public float Y;

        /// <summary>
        /// A Point2f at 1-1.
        /// </summary>
        public static readonly Point2f One = new Point2f(1);

        /// <summary>
        /// A Point2f at 0-0.
        /// </summary>
        public static readonly Point2f Zero = new Point2f(0);

        /// <summary>
        /// A Point2f at 1-0
        /// </summary>
        public static readonly Point2f UnitX = new Point2f(1, 0);

        /// <summary>
        /// A Point2f at 0-1
        /// </summary>
        public static readonly Point2f UnitY = new Point2f(0, 1);

        /// <summary>
        /// Construct a new Point2f.
        /// </summary>
        /// <param name="value">The value used to fill the coordinates of the Point2f</param>
        public Point2f(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Construct a new Point2f.
        /// </summary>
        /// <param name="prmX">The X coordinate</param>
        /// <param name="prmY">The Y coordinate</param>
        public Point2f(float prmX, float prmY)
        {
            X = prmX;
            Y = prmY;
        }

        /// <summary>
        /// Construct a new Point2f.
        /// </summary>
        /// <param name="prmPoint">A Point2f used to copy</param>
        public Point2f(Point2f prmPoint)
        {
            X = prmPoint.X;
            Y = prmPoint.Y;
        }

        /// <summary>
        /// Construct a new Point2f.
        /// </summary>
        /// <param name="values">The array of values</param>
        public Point2f(float[] values)
        {
            if (values.Length < 2)
                throw new ArgumentException("The length of the array is lower than two.", "values");

            X = values[0];
            Y = values[1];
        }

        /// <summary>
        /// Returns the distance between this Point2f and <see cref="Zero"/>.
        /// </summary>
        public float Distance()
        {
            return Distance(Zero);
        }

        /// <summary>
        /// Returns the distance between this Point2f and an other.
        /// </summary>
        /// <param name="prmX">The X coordinate of the second Point2f</param>
        /// <param name="prmY">The Y coordiante of the second Point2f</param>
        public float Distance(float prmX, float prmY)
        {
            return MathHelper.Sqrt((X - prmX) * (X - prmX) + (Y - prmY) * (Y - prmY));
        }

        /// <summary>
        /// Returns the distance between this Point2f and an other.
        /// </summary>
        /// <param name="prmPoint">The second Point2f</param>
        /// <returns></returns>
        public float Distance(Point2f prmPoint)
        {
            return Distance(prmPoint.X, prmPoint.Y);
        }

        /// <summary>
        /// Move this Point2f to another position.
        /// </summary>
        /// <param name="prmX">The new X coordinate</param>
        /// <param name="prmY">The new Y coordinate</param>
        public void MoveTo(float prmX, float prmY)
        {
            X = prmX;
            Y = prmY;
        }

        /// <summary>
        /// Move this Point2f to another position.
        /// </summary>
        /// <param name="prmPoint">The new position</param>
        public void MoveTo(Point2f prmPoint)
        {
            X = prmPoint.X;
            Y = prmPoint.Y;
        }

        /// <summary>
        /// Move this Point2f to another position relatively to the current position.
        /// </summary>
        /// <param name="prmX">The new X coordinate</param>
        /// <param name="prmY">The new Y coordinate</param>
        public void MoveRelative(float prmX, float prmY)
        {
            X += prmX;
            Y += prmY;
        }

        /// <summary>
        /// Move this Point2f to another position relatively to the current position.
        /// </summary>
        /// <param name="prmPoint">The new position</param>
        public void MoveRelative(Point2f prmPoint)
        {
            X += prmPoint.X;
            Y += prmPoint.Y;
        }

        /// <summary>
        /// Translate this Point2f with a <see cref="Vector2f"/>
        /// </summary>
        /// <param name="vector">The <see cref="Vector2f"/> used for translation.</param>
        public void Translate(Vector2f vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        /// <summary>
        /// Returns the distance between the point <paramref name="A"/> and the point <paramref name="B"/>.
        /// </summary>
        /// <param name="A">The first Point2f.</param>
        /// <param name="B">The second Point2f.</param>
        public static float Distance(Point2f A, Point2f B)
        {
            return A.Distance(B);
        }

        /// <summary>
        /// Move the point <paramref name="A"/> to the position of the point <paramref name="B"/>.
        /// </summary>
        /// <param name="A">The first Point2f.</param>
        /// <param name="B">The second Point2f.</param>
        public static void MoveTo(ref Point2f A, Point2f B)
        {
            A.MoveTo(B);
        }

        /// <summary>
        /// Move the point <paramref name="A"/> to the position of the point <paramref name="B"/>
        /// relatively to the current position of the point <paramref name="A"/>.
        /// </summary>
        /// <param name="A">The first Point2f.</param>
        /// <param name="B">The second Point2f.</param>
        public static void MoveRelative(ref Point2f A, Point2f B)
        {
            A.MoveRelative(B);
        }

        /// <summary>
        /// Translate the <paramref name="point"/> with a <paramref name="vector"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2f"/> to translate.</param>
        /// <param name="vector">The <see cref="Vector2f"/> used for translation.</param>
        public static void Translate(ref Point2f point, Vector2f vector)
        {
            point.Translate(vector);
        }


        /// <summary>
        /// Returns a new <see cref="Point2f"/> with minimal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point2f Min(Point2f a, Point2f b)
        {
            return new Point2f((a.X > b.X) ? b.X : a.X, (a.Y > b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Returns a new <see cref="Point2f"/> with maximal values.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Point2f Max(Point2f a, Point2f b)
        {
            return new Point2f((a.X < b.X) ? b.X : a.X, (a.Y < b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Create a <see cref="Vector2i"/> with two <see cref="Point2f"/>.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        public static Vector2f CreateVector(Point2f a, Point2f b)
        {
            return new Vector2f(b.X - a.X, b.Y - a.Y);
        }
        /// <summary>
        /// Add a <see cref="Point2f"/> with a <see cref="Sizef"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2f"/>.</param>
        /// <param name="size">The <see cref="Sizef"/>.</param>
        /// <remarks>This translate the <paramref name="point"/> with the <paramref name="size"/>.</remarks>
        public static Point2f operator +(Point2f point, Sizef size)
        {
            return new Point2f(point.X + size.Width, point.Y + size.Height);
        }

        /// <summary>
        /// Substract a <see cref="Point2f"/> with a <see cref="Sizef"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2f"/>.</param>
        /// <param name="size">The <see cref="Sizef"/>.</param>
        /// <remarks>This translate the <paramref name="point"/> with the negative <paramref name="size"/>.</remarks>
        public static Point2f operator -(Point2f point, Sizef size)
        {
            return new Point2f(point.X - size.Width, point.Y - size.Height);
        }

        /// <summary>
        /// Compare two <see cref="Point2f"/> for equality.
        /// </summary>
        /// <param name="lhs">First Point2f</param>
        /// <param name="rhs">Second Point2f</param>
        public static bool operator ==(Point2f lhs, Point2f rhs)
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
        /// Compare two <see cref="Point2f"/> for difference.
        /// </summary>
        /// <param name="lhs">First Point2f</param>
        /// <param name="rhs">Second Point2f</param>
        public static bool operator !=(Point2f lhs, Point2f rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Compare this <see cref="Point2f"/> and an <see cref="object"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        public override bool Equals(object obj)
        {
            bool Result = false;

            // In order to have "equality", we must have same type of objects
            if (GetType() == obj.GetType() && obj is Point2f)
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
                    Point2f Point = (Point2f)obj;

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
        /// Compare two <see cref="Point2f"/> for equality.
        /// </summary>
        /// <param name="other">The other Point2f to compare with this instance</param>
        public bool Equals(Point2f other)
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
        public float[] ToArray()
        {
            return new float[] { X, Y };
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
        }
    }
}
