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

            M11 = rows[0].X;
            M12 = rows[0].Y;
            M21 = rows[1].X;
            M22 = rows[1].Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix2f(Vector2f row0, Vector2f row1)
        {
            M11 = row0.X;
            M12 = row0.Y;
            M21 = row1.X;
            M22 = row1.Y;
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
            M11 = a;
            M12 = b;
            M21 = c;
            M22 = d;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="row">The value used to populate the matrix</param>
        public Matrix2f(Vector2f row)
        {
            M11 = row.X;
            M12 = row.Y;
            M21 = row.X;
            M22 = row.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="matrix">The matrix used for copy</param>
        public Matrix2f(Matrix2f matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M21 = matrix.M21;
            M22 = matrix.M22;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix2f(float[] values)
        {
            if (values.Length < 4)
                throw new ArgumentOutOfRangeException();

            M11 = values[0];
            M12 = values[1];
            M21 = values[2];
            M22 = values[3];
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix2f Transposed
        {
            get { return new Matrix2f(Column0, Column1); }
        }

        /// <summary>
        /// Gets the determinant of the matrix.
        /// </summary>
        public float Determinant
        {
            get { return M11 * M22 - M21 * M12; }
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
                float oneOverDeterminant = OneOverDeterminant;
                return new Matrix2f(
                    new Vector2f(M22, -M12) * oneOverDeterminant,
                    new Vector2f(-M21, M11) * oneOverDeterminant
                );
            }
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
        /// Bottom row of the matrix.
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
                }
                else if (row == 1)
                {
                    if (column == 0) M21 = value;
                    if (column == 1) M22 = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Transform

        /// <summary>
        /// Transpose this instance.
        /// </summary>
        public void Transpose()
        {
            this = Transpose(this);
        }

        /// <summary>
        /// Inverse this instance.
        /// </summary>
        public void Inverse()
        {
            this = Invert(this);
        }

        #endregion

        #region Static

        /// <summary>
        /// Gets the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <returns>The transposed matrix.</returns>
        public static Matrix2f Transpose(Matrix2f matrix)
        {
            Matrix2f res;
            Transpose(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Gets the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <param name="transpose">The transposed matrix.</param>
        public static void Transpose(ref Matrix2f matrix, out Matrix2f transpose)
        {
            transpose = matrix.Transposed;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static Matrix2f Invert(Matrix2f matrix)
        {
            Matrix2f res;
            Invert(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static void Invert(ref Matrix2f matrix, out Matrix2f inverse)
        {
            inverse = matrix.Inversed;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <returns>Scaling matrix.</returns>
        public static Matrix2f CreateScale(float scale)
        {
            Matrix2f res;
            CreateScale(scale, out res);
            return res;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(float scale, out Matrix2f matrix)
        {
            matrix.M11 = scale;
            matrix.M22 = scale;

            matrix.M12 = 0;
            matrix.M21 = 0;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2f Multiply(Matrix2f left, Matrix2f right)
        {
            Matrix2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix2f left, ref Matrix2f right, out Matrix2f result)
        {
            result.M11 = Vector2f.Dot(left.Row0, right.Column0);
            result.M12 = Vector2f.Dot(left.Row0, right.Column1);

            result.M21 = Vector2f.Dot(left.Row1, right.Column0);
            result.M22 = Vector2f.Dot(left.Row1, right.Column1);
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2f Multiply(Matrix2f left, Matrix4f right)
        {
            Matrix2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix2f left, ref Matrix4f right, out Matrix2f result)
        {
            float resultM11 = left.M11 * right.M11 + left.M12 * right.M21;
            float resultM12 = left.M11 * right.M12 + left.M12 * right.M22;

            float resultM21 = left.M21 * right.M11 + left.M22 * right.M21;
            float resultM22 = left.M21 * right.M12 + left.M22 * right.M22;

            result.M11 = resultM11;
            result.M12 = resultM12;

            result.M21 = resultM21;
            result.M22 = resultM22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2f Multiply(Matrix4f left, Matrix2f right)
        {
            Matrix2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix4f left, ref Matrix2f right, out Matrix2f result)
        {
            float resultM11 = left.M11 * right.M11 + left.M12 * right.M21;
            float resultM12 = left.M11 * right.M12 + left.M12 * right.M22;

            float resultM21 = left.M21 * right.M11 + left.M22 * right.M21;
            float resultM22 = left.M21 * right.M12 + left.M22 * right.M22;

            result.M11 = resultM11;
            result.M12 = resultM12;

            result.M21 = resultM21;
            result.M22 = resultM22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix2f Multiply(Matrix2x3f left, Matrix3x2f right)
        {
            Matrix2f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix2x3f left, ref Matrix3x2f right, out Matrix2f result)
        {
            result.M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            result.M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;

            result.M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            result.M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> matrix by the <paramref name="vector"/> vector.
        /// </summary>
        /// <param name="matrix">The LHS matrix.</param>
        /// <param name="vector">The RHS vector.</param>
        /// <returns>The product of <paramref name="matrix"/> and <paramref name="vector"/>.</returns>
        public static Vector2f Multiply(Matrix2f matrix, Vector2f vector)
        {
            Vector2f res;
            Multiply(ref matrix, ref vector, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> matrix by the <paramref name="vector"/> vector.
        /// </summary>
        /// <param name="matrix">The LHS matrix.</param>
        /// <param name="vector">The RHS vector.</param>
        /// <param name="result">The product of <paramref name="matrix"/> and <paramref name="vector"/>.</param>
        public static void Multiply(ref Matrix2f matrix, ref Vector2f vector, out Vector2f result)
        {
            result = new Vector2f(
                matrix.M11 * vector.X + matrix.M12 * vector.Y,
                matrix.M21 * vector.X + matrix.M22 * vector.Y
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> by a <paramref name="scale"/>.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scale">The scale</param>
        /// <returns>The result.</returns>
        public static Matrix2f Multiply(Matrix2f matrix, float scale)
        {
            Matrix2f res;
            Multiply(ref matrix, scale, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the <paramref name="matrix"/> by a <paramref name="scale"/>.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scale">The scale</param>
        /// <param name="result">The result.</param>
        public static void Multiply(ref Matrix2f matrix, float scale, out Matrix2f result)
        {
            result = new Matrix2f(matrix.Row0 * scale, matrix.Row1 * scale);
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <returns>Negated matrix.</returns>
        public static Matrix2f Negate(Matrix2f matrix)
        {
            Matrix2f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref Matrix2f matrix, out Matrix2f result)
        {
            float m11 = -matrix.M11;
            float m12 = -matrix.M12;

            float m21 = -matrix.M21;
            float m22 = -matrix.M22;


            result.M11 = m11;
            result.M12 = m12;

            result.M21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <returns>Difference of the two matrices.</returns>
        public static Matrix2f Subtract(Matrix2f left, Matrix2f right)
        {
            Matrix2f res;
            Subtract(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to subtract.</param>
        /// <param name="right">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref Matrix2f left, ref Matrix2f right, out Matrix2f result)
        {
            float m11 = left.M11 - right.M11;
            float m12 = left.M12 - right.M12;

            float m21 = left.M21 - right.M21;
            float m22 = left.M22 - right.M22;

            result.M11 = m11;
            result.M12 = m12;

            result.M21 = m21;
            result.M22 = m22;
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
            Vector2f res;
            Multiply(ref matrix, ref vector, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the <paramref name="left"/> matrix by the <paramref name="right"/> matrix.
        /// </summary>
        /// <param name="left">The LHS matrix.</param>
        /// <param name="right">The RHS matrix.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Matrix2f operator *(Matrix2f left, Matrix2f right)
        {
            Matrix2f result;
            Multiply(ref left, ref right, out result);
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
            Matrix2f result;
            Multiply(ref matrix, scale, out result);
            return result;
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
        void ILoadFromString.FromString(string value)
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