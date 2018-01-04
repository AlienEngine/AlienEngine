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
    /// Represent a rectangle.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectanglef : IEquatable<Rectanglef>
    {
        #region Fields

        /// <summary>
        /// The location of the rectangle.
        /// </summary>
        Point2f location;

        /// <summary>
        /// The size of the rectangle.
        /// </summary>
        Sizef size;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Rectanglef instance.
        /// </summary>
        /// <param name="location">The top-left corner of the Rectanglef.</param>
        /// <param name="size">The width and height of the Rectanglef.</param>
        public Rectanglef(Point2f location, Sizef size) : this()
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Constructs a new Rectanglef instance.
        /// </summary>
        /// <param name="x">The x coordinate of the Rectanglef.</param>
        /// <param name="y">The y coordinate of the Rectanglef.</param>
        /// <param name="width">The width coordinate of the Rectanglef.</param>
        /// <param name="height">The height coordinate of the Rectanglef.</param>
        public Rectanglef(float x, float y, float width, float height) : this(new Point2f(x, y), new Sizef(width, height))
        { }

        /// <summary>
        /// Constructs a new Rectanglef instance.
        /// </summary>
        /// <param name="a">The left-top corner of the Rectanglef.</param>
        /// <param name="b">The right-top corner of the Rectanglef.</param>
        /// <param name="c">The left-bottom of the Rectanglef.</param>
        /// <param name="d">The right-bottom of the Rectanglef.</param>
        public Rectanglef(Point2f a, Point2f b, Point2f c, Point2f d) : this()
        {
            Location = a;
            Size = new Sizef(d.X - c.X, d.Y - b.Y);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the x coordinate of the Rectanglef.
        /// </summary>
        public float X
        {
            get { return Location.X; }
            set { Location = new Point2f(value, Y); }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the Rectanglef.
        /// </summary>
        public float Y
        {
            get { return Location.Y; }
            set { Location = new Point2f(X, value); }
        }

        /// <summary>
        /// Gets or sets the width of the Rectanglef.
        /// </summary>
        public float Width
        {
            get { return Size.Width; }
            set { Size = new Sizef(value, Height); }
        }

        /// <summary>
        /// Gets or sets the height of the Rectanglef.
        /// </summary>
        public float Height
        {
            get { return Size.Height; }
            set { Size = new Sizef(Width, value); }
        }

        /// <summary>
        /// Gets or sets a <see cref="Point2f"/> representing the x and y coordinates
        /// of the Rectanglef.
        /// </summary>
        public Point2f Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="Size"/> representing the width and height
        /// of the Rectanglef.
        /// </summary>
        public Sizef Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Gets the y coordinate of the top edge of this Rectanglef.
        /// </summary>
        public float Top { get { return Y; } }

        /// <summary>
        /// Gets the x coordinate of the right edge of this Rectanglef.
        /// </summary>
        public float Right { get { return X + Width; } }

        /// <summary>
        /// Gets the y coordinate of the bottom edge of this Rectanglef.
        /// </summary>
        public float Bottom { get { return Y + Height; } }

        /// <summary>
        /// Gets the x coordinate of the left edge of this Rectanglef.
        /// </summary>
        public float Left { get { return X; } }

        /// <summary>
        /// Gets the TopLeft corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2f TopLeft => new Point2f(Left, Top);

        /// <summary>
        /// Gets the TopRight corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2f TopRight => new Point2f(Right, Top);

        /// <summary>
        /// Gets the BottomLeft corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2f BottomLeft => new Point2f(Left, Bottom);

        /// <summary>
        /// Gets the BottomRight corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2f BottomRight => new Point2f(Right, Bottom);

        /// <summary>
        /// Gets a <see cref="bool"/> that indicates whether this
        /// Rectanglef is equal to the empty Rectanglef.
        /// </summary>
        public bool IsEmpty()
        {
            return Location == Point2f.Zero && Size.IsZero();
        }

        /// <summary>
        /// Defines the empty Rectanglef.
        /// </summary>
        public static readonly Rectanglef Zero = new Rectanglef();

        /// <summary>
        /// Defines the empty Rectanglef.
        /// </summary>
        public static readonly Rectanglef Empty = new Rectanglef();

        /// <summary>
        /// Constructs a new instance with the specified edges.
        /// </summary>
        /// <param name="left">The left edge of the Rectanglef.</param>
        /// <param name="top">The top edge of the Rectanglef.</param>
        /// <param name="right">The right edge of the Rectanglef.</param>
        /// <param name="bottom">The bottom edge of the Rectanglef.</param>
        /// <returns>A new Rectanglef instance with the specified edges.</returns>
        public static Rectanglef FromLTRB(float left, float top, float right, float bottom)
        {
            return new Rectanglef(new Point2f(left, top), new Sizef(right - left, bottom - top));
        }

        /// <summary>
        /// Tests whether this instance contains the specified x, y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate to test.</param>
        /// <param name="y">The y coordinate to test.</param>
        /// <returns>True if this instance contains the x, y coordinates; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(float x, float y)
        {
            return x >= Left && x < Right && y >= Top && y < Bottom;
        }

        /// <summary>
        /// Tests whether this instance contains the specified Point2f.
        /// </summary>
        /// <param name="point">The <see cref="Point2f"/> to test.</param>
        /// <returns>True if this instance contains point; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Point2f point)
        {
            return point.X >= Left && point.X < Right && point.Y >= Top && point.Y < Bottom;
        }

        /// <summary>
        /// Tests whether this instance contains the specified Rectanglef.
        /// </summary>
        /// <param name="rect">The <see cref="Rectanglef"/> to test.</param>
        /// <returns>True if this instance contains rect; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Rectanglef rect)
        {
            return Contains(rect.Location) && Contains(rect.Location + rect.Size);
        }

        /// <summary>
        /// Tests whether this instance intersects the specified Rectangle.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if this instance intersects rect; false otherwise.</returns>
        public bool IntersectsWith(Rectanglef rect)
        {
            if (Contains(rect))
                return true;

            if (Contains(rect.TopLeft) || Contains(rect.TopRight) || Contains(rect.BottomLeft) || Contains(rect.BottomRight))
                return true;

            if (Bottom > rect.Bottom && Bottom < rect.Top)
                return true;

            if (Bottom < rect.Bottom && Top > rect.Bottom)
                return true;

            if (Left > rect.Left && Left < rect.Right)
                return true;

            if (Left < rect.Left && Right > rect.Left)
                return true;

            return false;
        }
        
        /// <summary>
        /// Transforms this <see cref="Rectangled"/> to the intersection
        /// between this one and the other <paramref name="rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The other rectangle used to compute the intersection.</param>
        public void Intersect(Rectanglef rectangle)
        {
            if (rectangle.Contains(this))
                return;
            
            if (!IntersectsWith(rectangle))
                this = Empty;

            else if (Contains(rectangle))
                this = rectangle;
            
            else
            {
                float top = 0, left = 0, right = 0, bottom = 0;

                if (Bottom > rectangle.Bottom)
                {
                    bottom = Bottom;
                    top = Top > rectangle.Top ? rectangle.Top : Top;
                    left = Left > rectangle.Left ? Left : rectangle.Left;
                    right = Right < rectangle.Right ? Right : rectangle.Right;
                }

                else
                {
                    bottom = rectangle.Bottom;
                    top = Top > rectangle.Top ? rectangle.Top : Top;
                    left = Left > rectangle.Left ? Left : rectangle.Left;
                    right = Right < rectangle.Right ? Right : rectangle.Right;
                }

                this = FromLTRB(left, top, right, bottom);

            }
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is equal to right; false otherwise.</returns>
        public static bool operator ==(Rectanglef left, Rectanglef right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(Rectanglef left, Rectanglef right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Union the specified a and b.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static Rectanglef Union(Rectanglef a, Rectanglef b)
        {
            float x1 = System.Math.Min(a.X, b.X);
            float x2 = System.Math.Max(a.X + a.Width, b.X + b.Width);
            float y1 = System.Math.Min(a.Y, b.Y);
            float y2 = System.Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectanglef(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Indicates whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectanglef)
                return Equals((Rectanglef)obj);

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A <see cref="System.Int32"/> that represents the hash code for this instance./></returns>
        public override int GetHashCode()
        {
            return Location.GetHashCode() & Size.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that describes this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that describes this instance.</returns>
        public override string ToString()
        {
            return $"{{{Location}-{Location + Size}}}";
        }

        #endregion

        #region IEquatable<Rectanglef> Members

        /// <summary>
        /// Indicates whether this instance is equal to the specified Rectanglef.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public bool Equals(Rectanglef other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

        #endregion
    }
}
