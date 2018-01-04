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
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Fields

        /// <summary>
        /// The location of the rectangle.
        /// </summary>
        private Point2i _location;

        /// <summary>
        /// The size of the rectangle.
        /// </summary>
        private Sizei _size;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Rectangle instance.
        /// </summary>
        /// <param name="location">The top-left corner of the Rectangle.</param>
        /// <param name="size">The width and height of the Rectangle.</param>
        public Rectangle(Point2i location, Sizei size) : this()
        {
            Location = location;
            Size = size;
        }

        /// <inheritdoc />
        /// <summary>
        /// Constructs a new Rectangle instance.
        /// </summary>
        /// <param name="x">The x coordinate of the Rectangle.</param>
        /// <param name="y">The y coordinate of the Rectangle.</param>
        /// <param name="width">The width coordinate of the Rectangle.</param>
        /// <param name="height">The height coordinate of the Rectangle.</param>
        public Rectangle(int x, int y, int width, int height) : this(new Point2i(x, y), new Sizei(width, height))
        { }

        /// <summary>
        /// Constructs a new Rectangle instance.
        /// </summary>
        /// <param name="a">The left-top corner of the Rectangle.</param>
        /// <param name="b">The right-top corner of the Rectangle.</param>
        /// <param name="c">The left-bottom of the Rectangle.</param>
        /// <param name="d">The right-bottom of the Rectangle.</param>
        public Rectangle(Point2i a, Point2i b, Point2i c, Point2i d) : this()
        {
            Location = a;
            Size = new Sizei(d.X - c.X, d.Y - b.Y);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the x coordinate of the Rectangle.
        /// </summary>
        public int X
        {
            get { return Location.X; }
            set { Location = new Point2i(value, Y); }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the Rectangle.
        /// </summary>
        public int Y
        {
            get { return Location.Y; }
            set { Location = new Point2i(X, value); }
        }

        /// <summary>
        /// Gets or sets the width of the Rectangle.
        /// </summary>
        public int Width
        {
            get { return Size.Width; }
            set { Size = new Sizei(value, Height); }
        }

        /// <summary>
        /// Gets or sets the height of the Rectangle.
        /// </summary>
        public int Height
        {
            get { return Size.Height; }
            set { Size = new Sizei(Width, value); }
        }

        /// <summary>
        /// Gets or sets a <see cref="Point2i"/> representing the x and y coordinates
        /// of the Rectangle.
        /// </summary>
        public Point2i Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="Size"/> representing the width and height
        /// of the Rectangle.
        /// </summary>
        public Sizei Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Gets the y coordinate of the top edge of this Rectangle.
        /// </summary>
        public int Top => Y;

        /// <summary>
        /// Gets the x coordinate of the right edge of this Rectangle.
        /// </summary>
        public int Right => X + Width;

        /// <summary>
        /// Gets the y coordinate of the bottom edge of this Rectangle.
        /// </summary>
        public int Bottom => Y + Height;

        /// <summary>
        /// Gets the x coordinate of the left edge of this Rectangle.
        /// </summary>
        public int Left => X;

        /// <summary>
        /// Gets the TopLeft corner of this <see cref="Rectangle"/>
        /// </summary>
        public Point2i TopLeft => new Point2i(Left, Top);

        /// <summary>
        /// Gets the TopRight corner of this <see cref="Rectangle"/>
        /// </summary>
        public Point2i TopRight => new Point2i(Right, Top);

        /// <summary>
        /// Gets the BottomLeft corner of this <see cref="Rectangle"/>
        /// </summary>
        public Point2i BottomLeft => new Point2i(Left, Bottom);

        /// <summary>
        /// Gets the BottomRight corner of this <see cref="Rectangle"/>
        /// </summary>
        public Point2i BottomRight => new Point2i(Right, Bottom);

        /// <summary>
        /// Gets a <see cref="bool"/> that indicates whether this
        /// Rectangle is equal to the empty Rectangle.
        /// </summary>
        public bool IsEmpty()
        {
            return Location == Point2i.Zero && Size.IsZero();
        }

        /// <summary>
        /// Defines the empty Rectangle.
        /// </summary>
        public static readonly Rectangle Zero = new Rectangle();

        /// <summary>
        /// Defines the empty Rectangle.
        /// </summary>
        public static readonly Rectangle Empty = new Rectangle();

        /// <summary>
        /// Constructs a new instance with the specified edges.
        /// </summary>
        /// <param name="left">The left edge of the Rectangle.</param>
        /// <param name="top">The top edge of the Rectangle.</param>
        /// <param name="right">The right edge of the Rectangle.</param>
        /// <param name="bottom">The bottom edge of the Rectangle.</param>
        /// <returns>A new Rectangle instance with the specified edges.</returns>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom)
        {
            return new Rectangle(new Point2i(left, top), new Sizei(right - left, bottom - top));
        }

        /// <summary>
        /// Tests whether this instance contains the specified x, y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate to test.</param>
        /// <param name="y">The y coordinate to test.</param>
        /// <returns>True if this instance contains the x, y coordinates; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(int x, int y)
        {
            return Contains(new Point2i(x, y));
        }

        /// <summary>
        /// Tests whether this instance contains the specified Point2i.
        /// </summary>
        /// <param name="point">The <see cref="Point2i"/> to test.</param>
        /// <returns>True if this instance contains point; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Point2i point)
        {
            return point.X >= Left && point.X < Right && point.Y >= Top && point.Y < Bottom;
        }

        /// <summary>
        /// Tests whether this instance contains the specified Rectangle.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if this instance contains rect; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Rectangle rect)
        {
            return Contains(rect.Location) && Contains(rect.Location + rect.Size);
        }

        /// <summary>
        /// Tests whether this instance intersects the specified Rectangle.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if this instance intersects rect; false otherwise.</returns>
        public bool IntersectsWith(Rectangle rect)
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
        /// Transforms this <see cref="Rectangle"/> to the intersection
        /// between this one and the other <paramref name="rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The other rectangle used to compute the intersection.</param>
        public void Intersect(Rectangle rectangle)
        {
            if (rectangle.Contains(this))
                return;
            
            if (!IntersectsWith(rectangle))
                this = Empty;

            else if (Contains(rectangle))
                this = rectangle;
            
            else
            {
                int top = 0, left = 0, right = 0, bottom = 0;

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
        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Union the specified a and b.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            var x1 = MathHelper.Min(a.X, b.X);
            var x2 = MathHelper.Max(a.X + a.Width, b.X + b.Width);
            var y1 = MathHelper.Min(a.Y, b.Y);
            var y2 = MathHelper.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Indicates whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
                return Equals((Rectangle)obj);

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

        #region IEquatable<Rectangle> Members

        /// <inheritdoc />
        /// <summary>
        /// Indicates whether this instance is equal to the specified Rectangle.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public bool Equals(Rectangle other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

        #endregion
    }
}
