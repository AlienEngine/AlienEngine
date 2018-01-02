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
    public struct Rectangled : IEquatable<Rectangled>
    {
        #region Fields

        /// <summary>
        /// The location of the rectangle.
        /// </summary>
        private Point2d _location;

        /// <summary>
        /// The size of the rectangle.
        /// </summary>
        private Sized _size;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Rectangled instance.
        /// </summary>
        /// <param name="location">The top-left corner of the Rectangled.</param>
        /// <param name="size">The width and height of the Rectangled.</param>
        public Rectangled(Point2d location, Sized size) : this()
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Constructs a new Rectangled instance.
        /// </summary>
        /// <param name="x">The x coordinate of the Rectangled.</param>
        /// <param name="y">The y coordinate of the Rectangled.</param>
        /// <param name="width">The width coordinate of the Rectangled.</param>
        /// <param name="height">The height coordinate of the Rectangled.</param>
        public Rectangled(double x, double y, double width, double height) : this(new Point2d(x, y), new Sized(width, height))
        { }

        /// <summary>
        /// Constructs a new Rectangled instance.
        /// </summary>
        /// <param name="a">The left-top corner of the Rectangled.</param>
        /// <param name="b">The right-top corner of the Rectangled.</param>
        /// <param name="c">The left-bottom of the Rectangled.</param>
        /// <param name="d">The right-bottom of the Rectangled.</param>
        public Rectangled(Point2d a, Point2d b, Point2d c, Point2d d) : this()
        {
            Location = a;
            Size = new Sized(d.X - c.X, d.Y - b.Y);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the x coordinate of the Rectangled.
        /// </summary>
        public double X
        {
            get { return Location.X; }
            set { Location = new Point2d(value, Y); }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the Rectangled.
        /// </summary>
        public double Y
        {
            get { return Location.Y; }
            set { Location = new Point2d(X, value); }
        }

        /// <summary>
        /// Gets or sets the width of the Rectangled.
        /// </summary>
        public double Width
        {
            get { return Size.Width; }
            set { Size = new Sized(value, Height); }
        }

        /// <summary>
        /// Gets or sets the height of the Rectangled.
        /// </summary>
        public double Height
        {
            get { return Size.Height; }
            set { Size = new Sized(Width, value); }
        }

        /// <summary>
        /// Gets or sets a <see cref="Point2d"/> representing the x and y coordinates
        /// of the Rectangled.
        /// </summary>
        public Point2d Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="Size"/> representing the width and height
        /// of the Rectangled.
        /// </summary>
        public Sized Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Gets the y coordinate of the top edge of this Rectangle.
        /// </summary>
        public double Top => Y;

        /// <summary>
        /// Gets the x coordinate of the right edge of this Rectangle.
        /// </summary>
        public double Right => X + Width;

        /// <summary>
        /// Gets the y coordinate of the bottom edge of this Rectangle.
        /// </summary>
        public double Bottom => Y + Height;

        /// <summary>
        /// Gets the x coordinate of the left edge of this Rectangle.
        /// </summary>
        public double Left => X;

        /// <summary>
        /// Gets the TopLeft corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2d TopLeft => new Point2d(Left, Top);

        /// <summary>
        /// Gets the TopRight corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2d TopRight => new Point2d(Right, Top);

        /// <summary>
        /// Gets the BottomLeft corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2d BottomLeft => new Point2d(Left, Bottom);

        /// <summary>
        /// Gets the BottomRight corner of this <see cref="Rectangled"/>
        /// </summary>
        public Point2d BottomRight => new Point2d(Right, Bottom);

        /// <summary>
        /// Gets a <see cref="bool"/> that indicates whether this
        /// Rectangled is equal to the empty Rectangled.
        /// </summary>
        public bool IsEmpty()
        {
            return Location == Point2d.Zero && Size.IsZero();
        }

        /// <summary>
        /// Defines the empty Rectangled.
        /// </summary>
        public static readonly Rectangled Zero = new Rectangled();

        /// <summary>
        /// Defines the empty Rectangled.
        /// </summary>
        public static readonly Rectangled Empty = new Rectangled();

        /// <summary>
        /// Constructs a new instance with the specified edges.
        /// </summary>
        /// <param name="left">The left edge of the Rectangled.</param>
        /// <param name="top">The top edge of the Rectangled.</param>
        /// <param name="right">The right edge of the Rectangled.</param>
        /// <param name="bottom">The bottom edge of the Rectangled.</param>
        /// <returns>A new Rectangled instance with the specified edges.</returns>
        public static Rectangled FromLTRB(double left, double top, double right, double bottom)
        {
            return new Rectangled(new Point2d(left, top), new Sized(right - left, bottom - top));
        }

        /// <summary>
        /// Tests whether this instance contains the specified x, y coordinates.
        /// </summary>
        /// <param name="x">The x coordinate to test.</param>
        /// <param name="y">The y coordinate to test.</param>
        /// <returns>True if this instance contains the x, y coordinates; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(double x, double y)
        {
            return x >= Left && x < Right && y >= Top && y < Bottom;
        }

        /// <summary>
        /// Tests whether this instance contains the specified Point2d.
        /// </summary>
        /// <param name="point">The <see cref="Point2d"/> to test.</param>
        /// <returns>True if this instance contains point; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Point2d point)
        {
            return point.X >= Left && point.X < Right && point.Y >= Top && point.Y < Bottom;
        }

        /// <summary>
        /// Tests whether this instance contains the specified Rectangled.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangled"/> to test.</param>
        /// <returns>True if this instance contains rect; false otherwise.</returns>
        /// <remarks>The left and top edges are inclusive. The right and bottom edges
        /// are exclusive.</remarks>
        public bool Contains(Rectangled rect)
        {
            return Contains(rect.Location) && Contains(rect.Location + rect.Size);
        }

        /// <summary>
        /// Tests whether this instance intersects the specified Rectangle.
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle"/> to test.</param>
        /// <returns>True if this instance intersects rect; false otherwise.</returns>
        public bool IntersectsWith(Rectangled rect)
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
        public void Intersect(Rectangled rectangle)
        {
            if (rectangle.Contains(this))
                return;
            
            if (!IntersectsWith(rectangle))
                this = Empty;

            else if (Contains(rectangle))
                this = rectangle;
            
            else
            {
                double top = 0, left = 0, right = 0, bottom = 0;

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
        public static bool operator ==(Rectangled left, Rectangled right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(Rectangled left, Rectangled right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Union the specified a and b.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static Rectangled Union(Rectangled a, Rectangled b)
        {
            var x1 = MathHelper.Min(a.X, b.X);
            var x2 = MathHelper.Max(a.X + a.Width, b.X + b.Width);
            var y1 = MathHelper.Min(a.Y, b.Y);
            var y2 = MathHelper.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectangled(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Indicates whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectangled)
                return Equals((Rectangled)obj);

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

        #region IEquatable<Rectangled> Members

        /// <summary>
        /// Indicates whether this instance is equal to the specified Rectangled.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public bool Equals(Rectangled other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

        #endregion
    }
}
