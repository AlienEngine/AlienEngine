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
    /// Represent a two dimensional size (width and height)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Sizei : IEquatable<Sizei>
    {
        /// <summary>
        /// The width.
        /// </summary>
        private int _width;

        /// <summary>
        /// The height.
        /// </summary>
        private int _height;

        /// <summary>
        /// A zero-length size.
        /// </summary>
        public static readonly Sizei Zero = new Sizei(0);

        /// <summary>
        /// A one-length size.
        /// </summary>
        public static readonly Sizei One = new Sizei(1);

        /// <summary>
        /// Constructs a new Sizei.
        /// </summary>
        /// <param name="value">The value used for the width and the height</param>
        public Sizei(int value) : this()
        {
            Width = value;
            Height = value;
        }

        /// <summary>
        /// Constructs a new Sizei.
        /// </summary>
        /// <param name="w">The width</param>
        /// <param name="h">The height</param>
        public Sizei(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        /// <summary>
        /// Gets the width of this Sizei.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _width = value;
            }
        }

        /// <summary>
        /// Gets the height of this Sizei.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _height = value;
            }
        }

        /// <summary>
        /// Gets the width of this Sizei.
        /// </summary>
        public int X
        {
            get { return Width; }
            set { Width = value; }
        }

        /// <summary>
        /// Gets the height of this Sizei.
        /// </summary>
        public int Y
        {
            get { return Height; }
            set { Height = value; }
        }

        /// <summary>
        /// Scale this Sizei.
        /// </summary>
        /// <param name="factor">The scale factor</param>
        public void Scale(int factor)
        {
            Width *= factor;
            Height *= factor;
        }

        /// <summary>
        /// Determines if this instance is <see cref="Zero"/>.
        /// </summary>
        /// <returns>True id this instance is <see cref="Zero"/>, false otherwise</returns>
        public bool IsZero()
        {
            return this == Zero;
        }

        /// <summary>
        /// Returns a new <see cref="Sizei"/> with minimal values.
        /// </summary>
        /// <param name="a">The first size.</param>
        /// <param name="b">The second size.</param>
        public static Sizei Min(Sizei a, Sizei b)
        {
            return new Sizei((a.X > b.X) ? b.X : a.X, (a.Y > b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Returns a new <see cref="Sizei"/> with maximal values.
        /// </summary>
        /// <param name="a">The first size.</param>
        /// <param name="b">The second size.</param>
        public static Sizei Max(Sizei a, Sizei b)
        {
            return new Sizei((a.X < b.X) ? b.X : a.X, (a.Y < b.Y) ? b.Y : a.Y);
        }

        /// <summary>
        /// Adds two <see cref="Sizei"/>.
        /// </summary>
        /// <param name="left">The first size.</param>
        /// <param name="right">The second size.</param>
        public static Sizei operator +(Sizei left, Sizei right)
        {
            return new Sizei(left.Width + right.Width, left.Height + right.Height);
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is equal to right; false otherwise.</returns>
        public static bool operator ==(Sizei left, Sizei right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(Sizei left, Sizei right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Sizei)
                return Equals((Sizei)obj);

            return false;
        }

        /// <summary>
        /// Indicates whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="s">The <see cref="Sizei"/> object instance to compare to.</param>
        /// <returns>True, if both instances are equal; false otherwise.</returns>
        public bool Equals(Sizei s)
        {
            return (X == s.X && Y == s.Y);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A <see cref="int"/> that represents the hash code for this instance./></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="string"/> that describes this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that describes this instance.</returns>
        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", Width, Height);
        }
    }
}
