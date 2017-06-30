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
    /// Represents a 2x2 matrix of float values.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Matrix2f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2f : IEquatable<Matrix2f>, ILoadFromString
    {
        #region Fields

        /// <summary>
        /// Top row of the matrix.
        /// </summary>
        public Vector2f Row0;

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector2f Row1;

        /// <summary>
        /// THe identity matrix.
        /// </summary>
        public static readonly Matrix2f Identity = new Matrix2f(Vector2f.UnitX, Vector2f.UnitY);

        /// <summary>
        /// The zero matrix.
        /// </summary>
        public static readonly Matrix2f Zero = new Matrix2f(Vector2f.Zero);

        /// <summary>
        /// The matrix with values populated with 1.
        /// </summary>
        public static readonly Matrix2f One = new Matrix2f(Vector2f.One);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public Matrix2f(float scale)
        {
            this = Identity * scale;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// The matrix is initialised with the <paramref name="rows"/> which represent an array of Vector2f.
        /// </summary>
        /// <param name="rows">The colums of the matrix.</param>
        public Matrix2f(Vector2f[] rows)
        {
            if (rows.Length < 2)
                throw new ArgumentException();

            Row0 = rows[0];
            Row1 = rows[1];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix2f(Vector2f row0, Vector2f row1)
        {
            Row0 = row0;
            Row1 = row1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="a">The first row, first column value.</param>
        /// <param name="b">The first row, second column value.</param>
        /// <param name="c">The second row, first column value.</param>
        /// <param name="d">The second row, second column value.</param>
        public Matrix2f(float a, float b, float c, float d)
        {
            Row0 = new Vector2f(a, b);
            Row1 = new Vector2f(c, d);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="row">The value used to populate the matrix</param>
        public Matrix2f(Vector2f row)
        {
            Row0 = row;
            Row1 = row;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix used for copy</param>
        public Matrix2f(Matrix2f matrix)
        {
            Row0 = matrix.Row0;
            Row1 = matrix.Row1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix2f(float[] values)
        {
            Row0 = new Vector2f(values[0], values[1]);
            Row1 = new Vector2f(values[2], values[3]);
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix2f Transposed
        {
            get { return new Matrix2f(new Vector2f(Row0.X, Row1.X), new Vector2f(Row0.Y, Row1.Y)); }
        }

        /// <summary>
        /// Gets the determinant of the matrix.
        /// </summary>
        public float Determinant
        {
            get { return Row0.X * Row1.Y - Row1.X * Row0.Y; }
        }

        /// <summary>
        /// Gets the inverse of the determinant.
        /// </summary>
        public float OneOverDeterminant
        {
            get { return 1.0f / Determinant; }
        }

        /// <summary>
        /// Determine if this instance is inversible or not.
        /// </summary>
        public bool IsInversible
        {
            get { return System.Math.Abs(Determinant) >= Single.Epsilon; }
        }

        /// <summary>
        /// Gets the inversed matrix of this instance.
        /// </summary>
        public Matrix2f Inversed
        {
            get
            {
                return new Matrix2f(
                    new Vector2f(M22, -M12) * OneOverDeterminant,
                    new Vector2f(-M21, M11) * OneOverDeterminant
                );
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector2f Column0
        {
            get { return new Vector2f(Row0.X, Row1.X); }
            set
            {
                Row0.X = value.X;
                Row1.X = value.Y;
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector2f Column1
        {
            get { return new Vector2f(Row0.Y, Row1.Y); }
            set
            {
                Row0.Y = value.X;
                Row1.Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the value at row 1, column 1 of this instance.
        /// </summary>
        public float M11 { get { return Row0.X; } set { Row0.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public float M12 { get { return Row0.Y; } set { Row0.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 3 of this instance.
        /// </summary>
        public float M21 { get { return Row1.X; } set { Row1.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 4 of this instance.
        /// </summary>
        public float M22 { get { return Row1.Y; } set { Row1.Y = value; } }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the <see cref="Vector2f"/> row at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Vector2f"/> value.
        /// </value>
        /// <param name="row">The row index.</param>
        /// <returns>The row at index <paramref name="row"/>.</returns>
        public Vector2f this[int row]
        {
            get
            {
                if (row == 0) { return Row0; }
                if (row == 1) { return Row1; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { Row0 = value; }
                else if (row == 1) { Row1 = value; }
                else throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets or sets the element at <paramref name="row"/> and <paramref name="column"/>.
        /// </summary>
        /// <value>
        /// The element at <paramref name="row"/> and <paramref name="column"/>.
        /// </value>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>
        /// The element at <paramref name="row"/> and <paramref name="column"/>.
        /// </returns>
        public float this[int row, int column]
        {
            get
            {
                if (row == 0) { return Row0[column]; }
                if (row == 1) { return Row1[column]; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { this.Row0[column] = value; }
                else if (row == 1) { this.Row1[column] = value; }
                else throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Transform

        public void Transpose()
        {
            this = Transpose(this);
        }

        public void Inverse()
        {
            this = Inverse(this);
        }

        #endregion

        #region Static

        /// <summary>
        /// Gets the transposed matrix.
        /// </summary>
        /// <param name="m">The matrix to transpose.</param>
        /// <returns>The transposed matrix.</returns>
        public static Matrix2f Transpose(Matrix2f m)
        {
            return m.Transposed;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="m">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static Matrix2f Inverse(Matrix2f m)
        {
            return m.Inversed;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compare two <see cref="Matrix2f"/> for difference.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns></returns>
        public static bool operator !=(Matrix2f left, Matrix2f right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> matrix by the <paramref name="vector"/> vector.
        /// </summary>
        /// <param name="matrix">The LHS matrix.</param>
        /// <param name="vector">The RHS vector.</param>
        /// <returns>The product of <paramref name="matrix"/> and <paramref name="vector"/>.</returns>
        public static Vector2f operator *(Matrix2f matrix, Vector2f vector)
        {
            return new Vector2f(
                matrix.M11 * vector.X + matrix.M12 * vector.Y,
                matrix.M21 * vector.X + matrix.M22 * vector.Y
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix2f operator *(Matrix2f left, Matrix2f right)
        {
            Matrix2f result = new Matrix2f(
                Vector2f.Dot(left.Row0, right.Column0),
                Vector2f.Dot(left.Row0, right.Column1),
                Vector2f.Dot(left.Row1, right.Column0),
                Vector2f.Dot(left.Row1, right.Column1)
            );

            return result;
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> by a <paramref name="scale"/>.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scale">The scale</param>
        /// <returns>The result.</returns>
        public static Matrix2f operator *(Matrix2f matrix, float scale)
        {
            return new Matrix2f(matrix.Row0 * scale, matrix.Row1 * scale);
        }

        /// <summary>
        /// Compare tho <see cref="Matrix2f"/> for equality.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        public static bool operator ==(Matrix2f left, Matrix2f right)
        {
            return left.Equals(right);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overrides the Equals() method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Matrix2f) && (Equals((Matrix2f)obj));
        }

        /// <summary>
        /// Compare two matrices and determine if their equal.
        /// </summary>
        /// <param name="other">The matrix to compare with this instance.</param>
        public bool Equals(Matrix2f other)
        {
            return (Row0 == other.Row0 && Row1 == other.Row1);
        }

        /// <summary>
        /// Gets the hashcode of this instance.
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Load this instance from the <see cref="System.String"/> representation.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> value to convert.</param>
        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Trim('[', ']').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Row0 = Vector2f.Parse(parts[0]);
            Row1 = Vector2f.Parse(parts[1]);
        }

        /// <summary>
        /// Returns the matrix as an array of floats, column major.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { M11, M12, M21, M22 };
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> representation of the matrix.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0},{1}]", Row0, Row1);
        }

        #endregion

        #endregion
    }
}