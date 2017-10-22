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
    /// 3 row, 2 column matrix.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Matrix3x2f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x2f : IEquatable<Matrix3x2f>, ILoadFromString
    {
        #region Fields

        /// <summary>
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public float M11;

        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public float M12;

        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public float M21;

        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public float M22;

        /// <summary>
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public float M31;

        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public float M32;

        /// <summary>
        /// The zero matrix.
        /// </summary>
        public static readonly Matrix3x2f Zero = new Matrix3x2f(Vector2f.Zero);

        /// <summary>
        /// The matrix with values populated with 1.
        /// </summary>
        public static readonly Matrix3x2f One = new Matrix3x2f(Vector2f.One);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new 3 row, 2 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        /// <param name="m31">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m32">Value at row 2, column 2 of the matrix.</param>
        public Matrix3x2f(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
            M31 = m31;
            M32 = m32;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x2f"/> struct.
        /// The matrix is initialised with the <paramref name="rows"/> which represent an array of Vector2f.
        /// </summary>
        /// <param name="rows">The colums of the matrix.</param>
        public Matrix3x2f(Vector2f[] rows)
        {
            if (rows.Length < 3)
                throw new ArgumentException();

            M11 = rows[0].X;
            M12 = rows[0].Y;
            M21 = rows[1].X;
            M22 = rows[1].Y;
            M31 = rows[2].X;
            M32 = rows[2].Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x2f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix3x2f(Vector2f row0, Vector2f row1, Vector2f row2)
        {
            M11 = row0.X;
            M12 = row0.Y;
            M21 = row1.X;
            M22 = row1.Y;
            M31 = row2.X;
            M32 = row2.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x2f"/> struct.
        /// </summary>
        /// <param name="row">The value used to populate the matrix</param>
        public Matrix3x2f(Vector2f row)
        {
            M11 = row.X;
            M12 = row.Y;
            M21 = row.X;
            M22 = row.Y;
            M31 = row.X;
            M32 = row.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x2f"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix used for copy</param>
        public Matrix3x2f(Matrix3x2f matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M31 = matrix.M31;
            M32 = matrix.M32;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x2f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix3x2f(float[] values)
        {
            if (values.Length < 6)
                throw new ArgumentOutOfRangeException();

            M11 = values[0];
            M12 = values[1];
            M21 = values[2];
            M22 = values[3];
            M31 = values[4];
            M32 = values[5];
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix2x3f Transposed
        {
            get { return new Matrix2x3f(Column0, Column1); }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector3f Column0
        {
            get { return new Vector3f(M11, M21, M31); }
            set
            {
                M11 = value.X;
                M21 = value.Y;
                M31 = value.Z;
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector3f Column1
        {
            get { return new Vector3f(M12, M22, M32); }
            set
            {
                M12 = value.X;
                M22 = value.Y;
                M32 = value.Z;
            }
        }

        /// <summary>
        /// Top row of the matrix.
        /// </summary>
        public Vector2f Row0
        {
            get { return new Vector2f(M11, M12); }
            set
            {
                M11 = value.X;
                M12 = value.Y;
            }
        }

        /// <summary>
        /// Middle row of the matrix.
        /// </summary>
        public Vector2f Row1
        {
            get { return new Vector2f(M21, M22); }
            set
            {
                M21 = value.X;
                M22 = value.Y;
            }
        }

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector2f Row2
        {
            get { return new Vector2f(M31, M32); }
            set
            {
                M31 = value.X;
                M32 = value.Y;
            }
        }

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
                if (row == 2) { return Row2; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if      (row == 0) { Row0 = value; }
                else if (row == 1) { Row1 = value; }
                else if (row == 2) { Row2 = value; }
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
                if (row == 0) return Row0[column];
                if (row == 1) return Row1[column];
                if (row == 2) return Row2[column];
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0)
                {
                    if (column == 0) M11 = value;
                    if (column == 1) M12 = value;
                }
                else if (row == 1)
                {
                    if (column == 0) M21 = value;
                    if (column == 1) M22 = value;
                }
                else if (row == 2)
                {
                    if (column == 0) M31 = value;
                    if (column == 1) M32 = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Static

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to add.</param>
        /// <param name="right">Second matrix to add.</param>
        /// <returns>Sum of the two matrices.</returns>
        public static Matrix3x2f Add(Matrix3x2f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to add.</param>
        /// <param name="right">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix3x2f left, ref Matrix3x2f right, out Matrix3x2f result)
        {
            float m11 = left.M11 + right.M11;
            float m12 = left.M12 + right.M12;

            float m21 = left.M21 + right.M21;
            float m22 = left.M22 + right.M22;

            float m31 = left.M31 + right.M31;
            float m32 = left.M32 + right.M32;

            result.M11 = m11;
            result.M12 = m12;

            result.M21 = m21;
            result.M22 = m22;

            result.M31 = m31;
            result.M32 = m32;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3x2f Multiply(Matrix3f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix3f left, ref Matrix3x2f right, out Matrix3x2f result)
        {
            float resultM11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            float resultM12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;

            float resultM21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            float resultM22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;

            float resultM31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31;
            float resultM32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32;

            result.M11 = resultM11;
            result.M12 = resultM12;

            result.M21 = resultM21;
            result.M22 = resultM22;

            result.M31 = resultM31;
            result.M32 = resultM32;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3x2f Multiply(Matrix4f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix4f a, ref Matrix3x2f b, out Matrix3x2f result)
        {
            float resultM11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31;
            float resultM12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32;

            float resultM21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31;
            float resultM22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32;

            float resultM31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31;
            float resultM32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32;

            result.M11 = resultM11;
            result.M12 = resultM12;

            result.M21 = resultM21;
            result.M22 = resultM22;

            result.M31 = resultM31;
            result.M32 = resultM32;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <return>Negated matrix.</returns>
        public static Matrix3x2f Negate(Matrix3x2f matrix)
        {
            Matrix3x2f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref Matrix3x2f matrix, out Matrix3x2f result)
        {
            float m11 = -matrix.M11;
            float m12 = -matrix.M12;

            float m21 = -matrix.M21;
            float m22 = -matrix.M22;

            float m31 = -matrix.M31;
            float m32 = -matrix.M32;

            result.M11 = m11;
            result.M12 = m12;

            result.M21 = m21;
            result.M22 = m22;

            result.M31 = m31;
            result.M32 = m32;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <returns>Difference of the two matrices.</returns>
        public static Matrix3x2f Subtract(Matrix3x2f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Subtract(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref Matrix3x2f left, ref Matrix3x2f right, out Matrix3x2f result)
        {
            float m11 = left.M11 - right.M11;
            float m12 = left.M12 - right.M12;

            float m21 = left.M21 - right.M21;
            float m22 = left.M22 - right.M22;

            float m31 = left.M31 - right.M31;
            float m32 = left.M32 - right.M32;

            result.M11 = m11;
            result.M12 = m12;

            result.M21 = m21;
            result.M22 = m22;

            result.M31 = m31;
            result.M32 = m32;
        }
        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <returns>Transposed matrix.</returns>
        public static Matrix2x3f Transpose(Matrix3x2f matrix)
        {
            Matrix2x3f res;
            Transpose(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(ref Matrix3x2f matrix, out Matrix2x3f result)
        {
            result = matrix.Transposed;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Add two <see cref="Matrix3x2f"/>.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix3x2f operator +(Matrix3x2f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Substract two <see cref="Matrix3x2f"/>.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix3x2f operator -(Matrix3x2f left, Matrix3x2f right)
        {
            Matrix3x2f res;
            Subtract(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Negate a <see cref="Matrix3x2f"/>.
        /// </summary>
        /// <param name="matrix">The first matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix3x2f operator -(Matrix3x2f matrix)
        {
            Matrix3x2f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Compare two <see cref="Matrix3x2f"/> for difference.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns></returns>
        public static bool operator !=(Matrix3x2f left, Matrix3x2f right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix3x2f operator *(Matrix3f left, Matrix3x2f right)
        {
            Matrix3x2f result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix3x2f operator *(Matrix4f left, Matrix3x2f right)
        {
            Matrix3x2f result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Compare two <see cref="Matrix3x2f"/> for equality.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        public static bool operator ==(Matrix3x2f left, Matrix3x2f right)
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
            return (obj is Matrix3x2f) && (Equals((Matrix3x2f)obj));
        }

        /// <summary>
        /// Compare two matrices and determine if their equal.
        /// </summary>
        /// <param name="other">The matrix to compare with this instance.</param>
        public bool Equals(Matrix3x2f other)
        {
            return (Row0 == other.Row0 && Row1 == other.Row1 && Row2 == other.Row2);
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
        void ILoadFromString.FromString(string value)
        {
            string[] parts = value.Trim('[', ']').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Row0 = Vector2f.Parse(parts[0]);
            Row1 = Vector2f.Parse(parts[1]);
            Row2 = Vector2f.Parse(parts[2]);
        }

        /// <summary>
        /// Returns the matrix as an array of floats, column major.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { M11, M12, M21, M22, M31, M32 };
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> representation of the matrix.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]", Row0, Row1, Row2);
        }

        #endregion

        #endregion
    }
}