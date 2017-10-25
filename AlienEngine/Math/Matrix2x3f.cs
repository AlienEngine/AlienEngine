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
    /// 2 row, 3 column matrix.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Matrix2x3f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2x3f : IEquatable<Matrix2x3f>, ILoadFromString
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
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public float M13;

        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public float M21;

        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public float M22;

        /// <summary>
        /// Value at row 2, column 3 of the matrix.
        /// </summary>
        public float M23;

        /// <summary>
        /// The zero matrix.
        /// </summary>
        public static readonly Matrix2x3f Zero = new Matrix2x3f(Vector3f.Zero);

        /// <summary>
        /// The matrix with values populated with 1.
        /// </summary>
        public static readonly Matrix2x3f One = new Matrix2x3f(Vector3f.One);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new 2 row, 2 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
        public Matrix2x3f(float m11, float m12, float m13, float m21, float m22, float m23)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x3f"/> struct.
        /// The matrix is initialised with the <paramref name="rows"/> which represent an array of Vector2f.
        /// </summary>
        /// <param name="rows">The colums of the matrix.</param>
        public Matrix2x3f(Vector3f[] rows)
        {
            if (rows.Length < 2)
                throw new ArgumentException();

            M11 = rows[0].X;
            M12 = rows[0].Y;
            M13 = rows[0].Z;
            M21 = rows[1].X;
            M22 = rows[1].Y;
            M23 = rows[1].Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x3f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix2x3f(Vector3f row0, Vector3f row1)
        {
            M11 = row0.X;
            M12 = row0.Y;
            M13 = row0.Z;
            M21 = row1.X;
            M22 = row1.Y;
            M23 = row1.Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x3f"/> struct.
        /// </summary>
        /// <param name="row">The value used to populate the matrix</param>
        public Matrix2x3f(Vector3f row)
        {
            M11 = row.X;
            M12 = row.Y;
            M13 = row.Z;
            M21 = row.X;
            M22 = row.Y;
            M23 = row.Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x3f"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix used for copy</param>
        public Matrix2x3f(Matrix2x3f matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x3f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix2x3f(float[] values)
        {
            if (values.Length < 6)
                throw new ArgumentOutOfRangeException();

            M11 = values[0];
            M12 = values[1];
            M13 = values[2];
            M21 = values[3];
            M22 = values[4];
            M23 = values[5];
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix3x2f Transposed
        {
            get { return new Matrix3x2f(Column0, Column1, Column2); }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector2f Column0
        {
            get { return new Vector2f(M11, M21); }
            set
            {
                M11 = value.X;
                M21 = value.Y;
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector2f Column1
        {
            get { return new Vector2f(M12, M22); }
            set
            {
                M12 = value.X;
                M22 = value.Y;
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector2f Column2
        {
            get { return new Vector2f(M13, M23); }
            set
            {
                M13 = value.X;
                M23 = value.Y;
            }
        }

        /// <summary>
        /// Top row of the matrix.
        /// </summary>
        public Vector3f Row0
        {
            get { return new Vector3f(M11, M12, M13); }
            set
            {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
            }
        }

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector3f Row1
        {
            get { return new Vector3f(M21, M22, M23); }
            set
            {
                M21 = value.X;
                M22 = value.Y;
                M23 = value.Z;
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the <see cref="Vector3f"/> row at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Vector3f"/> value.
        /// </value>
        /// <param name="row">The row index.</param>
        /// <returns>The row at index <paramref name="row"/>.</returns>
        public Vector3f this[int row]
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
                if (row == 0) return Row0[column];
                if (row == 1) return Row1[column];
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0)
                {
                    if (column == 0) M11 = value;
                    if (column == 1) M12 = value;
                    if (column == 2) M13 = value;
                }
                else if (row == 1)
                {
                    if (column == 0) M21 = value;
                    if (column == 1) M22 = value;
                    if (column == 2) M23 = value;
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
        public static Matrix2x3f Add(Matrix2x3f left, Matrix2x3f right)
        {
            Matrix2x3f res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to add.</param>
        /// <param name="right">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix2x3f left, ref Matrix2x3f right, out Matrix2x3f result)
        {
            float m11 = left.M11 + right.M11;
            float m12 = left.M12 + right.M12;
            float m13 = left.M13 + right.M13;

            float m21 = left.M21 + right.M21;
            float m22 = left.M22 + right.M22;
            float m23 = left.M23 + right.M23;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2x3f Multiply(Matrix2x3f left, Matrix3f right)
        {
            Matrix2x3f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix2x3f left, ref Matrix3f right, out Matrix2x3f result)
        {
            float resultM11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            float resultM12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;
            float resultM13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33;

            float resultM21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            float resultM22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
            float resultM23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2x3f Multiply(Matrix2x3f left, Matrix4f right)
        {
            Matrix2x3f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix2x3f left, ref Matrix4f right, out Matrix2x3f result)
        {
            float resultM11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            float resultM12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;
            float resultM13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33;

            float resultM21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            float resultM22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
            float resultM23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <return>Negated matrix.</returns>
        public static Matrix2x3f Negate(Matrix2x3f matrix)
        {
            Matrix2x3f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref Matrix2x3f matrix, out Matrix2x3f result)
        {
            float m11 = -matrix.M11;
            float m12 = -matrix.M12;
            float m13 = -matrix.M13;

            float m21 = -matrix.M21;
            float m22 = -matrix.M22;
            float m23 = -matrix.M23;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <returns>Difference of the two matrices.</returns>
        public static Matrix2x3f Subtract(Matrix2x3f left, Matrix2x3f right)
        {
            Matrix2x3f res;
            Subtract(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref Matrix2x3f left, ref Matrix2x3f right, out Matrix2x3f result)
        {
            float m11 = left.M11 - right.M11;
            float m12 = left.M12 - right.M12;
            float m13 = left.M13 - right.M13;

            float m21 = left.M21 - right.M21;
            float m22 = left.M22 - right.M22;
            float m23 = left.M23 - right.M23;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <returns>Transposed matrix.</returns>
        public static Matrix3x2f Transpose(Matrix2x3f matrix)
        {
            Matrix3x2f res;
            Transpose(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(ref Matrix2x3f matrix, out Matrix3x2f result)
        {
            result = matrix.Transposed;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Add two <see cref="Matrix2x3f"/>.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix2x3f operator +(Matrix2x3f left, Matrix2x3f right)
        {
            Matrix2x3f res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Substract two <see cref="Matrix2x3f"/>.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix2x3f operator -(Matrix2x3f left, Matrix2x3f right)
        {
            Matrix2x3f res;
            Subtract(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Negate a <see cref="Matrix2x3f"/>.
        /// </summary>
        /// <param name="matrix">The first matrix.</param>
        /// <returns>The sum of matrices</returns>
        public static Matrix2x3f operator -(Matrix2x3f matrix)
        {
            Matrix2x3f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Compare two <see cref="Matrix2x3f"/> for difference.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns></returns>
        public static bool operator !=(Matrix2x3f left, Matrix2x3f right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix2x3f operator *(Matrix2x3f left, Matrix3f right)
        {
            Matrix2x3f result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix2x3f operator *(Matrix2x3f left, Matrix4f right)
        {
            Matrix2x3f result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Compare two <see cref="Matrix2x3f"/> for equality.
        /// </summary>
        /// <param name="left">The left side.</param>
        /// <param name="right">The right side.</param>
        public static bool operator ==(Matrix2x3f left, Matrix2x3f right)
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
            return (obj is Matrix2x3f) && (Equals((Matrix2x3f)obj));
        }

        /// <summary>
        /// Compare two matrices and determine if their equal.
        /// </summary>
        /// <param name="other">The matrix to compare with this instance.</param>
        public bool Equals(Matrix2x3f other)
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
        void ILoadFromString.FromString(string value)
        {
            string[] parts = value.Trim('[', ']').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Row0 = Vector3f.Parse(parts[0]);
            Row1 = Vector3f.Parse(parts[1]);
        }

        /// <summary>
        /// Returns the matrix as an array of floats, column major.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { M11, M12, M13, M21, M22, M23 };
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