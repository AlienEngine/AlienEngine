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
    /// Represents a 3x3 matrix of float values.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Matrix3f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3f : IEquatable<Matrix3f>, ILoadFromString
    {
        #region Fields

        /// <summary>
        /// Top row of the matrix.
        /// </summary>
        public Vector3f Row0;

        /// <summary>
        /// Second row of the matrix.
        /// </summary>
        public Vector3f Row1;

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector3f Row2;

        /// <summary>
        /// The identity matrix.
        /// </summary>
        public static readonly Matrix3f Identity = new Matrix3f(Vector3f.UnitX, Vector3f.UnitY, Vector3f.UnitZ);

        /// <summary>
        /// The zero matrix.
        /// </summary>
        public static readonly Matrix3f Zero = new Matrix3f(Vector3f.Zero);

        /// <summary>
        /// The matrix with values populated with 1.
        /// </summary>
        public static readonly Matrix3f One = new Matrix3f(Vector3f.One);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public Matrix3f(float scale)
        {
            this = Identity * scale;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// The matrix is initialised with the <paramref name="rows"/> which represent an array of Vector2f.
        /// </summary>
        /// <param name="rows">The colums of the matrix.</param>
        public Matrix3f(Vector3f[] rows)
        {
            if (rows.Length < 3)
                throw new ArgumentException();

            Row0 = rows[0];
            Row1 = rows[1];
            Row2 = rows[2];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix3f(Vector3f row0, Vector3f row1, Vector3f row2)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="a">The first row, first column value.</param>
        /// <param name="b">The first row, second column value.</param>
        /// <param name="c">The first row, third column value.</param>
        /// <param name="d">The second row, first column value.</param>
        /// <param name="e">The second row, second column value.</param>
        /// <param name="f">The second row, third column value.</param>
        /// <param name="g">The third row, first column value.</param>
        /// <param name="h">The third row, second column value.</param>
        /// <param name="i">The third row, third column value.</param>
        public Matrix3f(float a, float b, float c, float d, float e, float f, float g, float h, float i)
        {
            Row0 = new Vector3f(a, b, c);
            Row1 = new Vector3f(d, e, f);
            Row2 = new Vector3f(g, h, i);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="a">The value used to populate the matrix</param>
        public Matrix3f(Vector3f row)
        {
            Row0 = row;
            Row1 = row;
            Row2 = row;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="a">The value used to populate the matrix</param>
        public Matrix3f(Matrix3f matrix)
        {
            Row0 = matrix.Row0;
            Row1 = matrix.Row1;
            Row2 = matrix.Row2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix3f(float[] values)
        {
            Row0 = new Vector3f(values[0], values[1], values[2]);
            Row1 = new Vector3f(values[3], values[4], values[5]);
            Row2 = new Vector3f(values[6], values[7], values[8]);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Creates a matrix which contains information on how to translate.
        /// </summary>
        /// <param name="translation">Amount to translate by in the x, and y directions.</param>
        /// <returns>A Matrix3f object that contains the translation matrix.</returns>
        public static Matrix3f CreateTranslation(Vector2f translation)
        {
            Matrix3f result = Identity;
            result.Row1.Z = translation.X;
            result.Row2.Z = translation.Y;
            return result;
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix3f object that contains the rotation matrix.</returns>
        public static Matrix3f CreateRotation(float angle)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            return new Matrix3f(
                new Vector3f(cos, sin, 0f),
                new Vector3f(-sin, cos, 0f),
                Vector3f.UnitZ);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to scale.
        /// </summary>
        /// <param name="scale">Amount to scale by in the x and y direction</param>
        /// <returns>A Matrix3f object that contains the scaling matrix</returns>
        public static Matrix3f CreateScale(Vector2f scale)
        {
            return new Matrix3f(
                Vector3f.UnitX * scale.X,
                Vector3f.UnitY * scale.Y,
                Vector3f.UnitZ
            );
        }
        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix3f Transposed
        {
            get { return new Matrix3f(new Vector3f(Row0.X, Row1.X, Row2.X), new Vector3f(Row0.Y, Row1.Y, Row2.Y), new Vector3f(Row0.Z, Row1.Z, Row2.Z)); }
        }

        /// <summary>
        /// Gets the determinant of the matrix.
        /// </summary>
        public float Determinant
        {
            get
            {
                Matrix2f det11 = new Matrix2f(M22, M23, M32, M33);
                Matrix2f det12 = new Matrix2f(M21, M23, M31, M33);
                Matrix2f det13 = new Matrix2f(M21, M22, M31, M32);

                return ((M11 * det11.Determinant) - (M12 * det12.Determinant) + (M13 * det13.Determinant));
            }
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
        public Matrix3f Inversed
        {
            get
            {
                return new Matrix3f(
                    +(Row1.Y * Row2.Z - Row1.Z * Row2.Y) * OneOverDeterminant,
                    -(Row1.X * Row2.Z - Row1.Z * Row2.X) * OneOverDeterminant,
                    +(Row1.X * Row2.Y - Row1.Y * Row2.X) * OneOverDeterminant,
                    -(Row0.Y * Row2.Z - Row0.Z * Row2.Y) * OneOverDeterminant,
                    +(Row0.X * Row2.Z - Row0.Z * Row2.X) * OneOverDeterminant,
                    -(Row0.X * Row2.Y - Row0.Y * Row2.X) * OneOverDeterminant,
                    +(Row0.Y * Row1.Z - Row0.Z * Row1.Y) * OneOverDeterminant,
                    -(Row0.X * Row1.Z - Row0.Z * Row1.X) * OneOverDeterminant,
                    +(Row0.X * Row1.Y - Row0.Y * Row1.X) * OneOverDeterminant
                ).Transposed;
            }
        }

        /// <summary>
        /// Gets the first column of the matrix.
        /// </summary>
        public Vector3f Column0
        {
            get { return new Vector3f(Row0.X, Row1.X, Row2.X); }
            set
            {
                Row0.X = value.X;
                Row1.X = value.Y;
                Row2.X = value.Z;
            }
        }

        /// <summary>
        /// Gets the second column of the matrix.
        /// </summary>
        public Vector3f Column1
        {
            get { return new Vector3f(Row0.Y, Row1.Y, Row2.Y); }
            set
            {
                Row0.Y = value.X;
                Row1.Y = value.Y;
                Row2.Y = value.Z;
            }
        }

        /// <summary>
        /// Gets the third column of the matrix.
        /// </summary>
        public Vector3f Column2
        {
            get { return new Vector3f(Row0.Z, Row1.Z, Row2.Z); }
            set
            {
                Row0.Z = value.X;
                Row1.Z = value.Y;
                Row2.Z = value.Z;
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
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public float M13 { get { return Row0.Z; } set { Row0.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 3 of this instance.
        /// </summary>
        public float M21 { get { return Row1.X; } set { Row1.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 4 of this instance.
        /// </summary>
        public float M22 { get { return Row1.Y; } set { Row1.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public float M23 { get { return Row1.Z; } set { Row1.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 3 of this instance.
        /// </summary>
        public float M31 { get { return Row2.X; } set { Row2.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 4 of this instance.
        /// </summary>
        public float M32 { get { return Row2.Y; } set { Row2.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public float M33 { get { return Row2.Z; } set { Row2.Z = value; } }

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
                if (row == 2) { return Row2; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { Row0 = value; }
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
                if (row == 0) { return Row0[column]; }
                if (row == 1) { return Row1[column]; }
                if (row == 2) { return Row2[column]; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { Row0[column] = value; }
                else if (row == 1) { Row1[column] = value; }
                else if (row == 2) { Row2[column] = value; }
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
        public static Matrix3f Transpose(Matrix3f m)
        {
            return m.Transposed;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="m">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static Matrix3f Inverse(Matrix3f m)
        {
            return m.Inversed;
        }

        #endregion

        #region Operators

        public static Matrix3f operator +(Matrix3f m1, Matrix3f m2)
        {
            return new Matrix3f(m1.Row0 + m2.Row0, m1.Row1 + m2.Row1, m1.Row2 + m2.Row2);
        }

        public static Matrix3f operator -(Matrix3f m1, Matrix3f m2)
        {
            return new Matrix3f(m1.Row0 - m2.Row0, m1.Row1 - m2.Row1, m1.Row2 - m2.Row2);
        }

        public static Matrix3f operator *(Matrix3f m1, Matrix3f m2)
        {
            return new Matrix3f(
                Vector3f.Dot(m1.Row0, m2.Column0), Vector3f.Dot(m1.Row0, m2.Column1), Vector3f.Dot(m1.Row0, m2.Column2),
                Vector3f.Dot(m1.Row1, m2.Column0), Vector3f.Dot(m1.Row1, m2.Column1), Vector3f.Dot(m1.Row1, m2.Column2),
                Vector3f.Dot(m1.Row2, m2.Column0), Vector3f.Dot(m1.Row2, m2.Column1), Vector3f.Dot(m1.Row2, m2.Column2)
            );
        }

        public static Matrix3f operator *(Matrix3f m1, float d)
        {
            return new Matrix3f(m1.Row0 * d, m1.Row1 * d, m1.Row2 * d);
        }

        public static Matrix3f operator /(Matrix3f m1, float d)
        {
            return new Matrix3f(m1.Row0 / d, m1.Row1 / d, m1.Row2 / d);
        }

        public static Vector2f operator *(Matrix3f m1, Vector2f v)
        {
            return new Vector2f(m1[0].X * v.X + m1[0].Y * v.Y, m1[1].X * v.X + m1[1].Y * v.Y);
        }

        public static Vector2f operator *(Vector2f v, Matrix3f m1)
        {
            return new Vector2f(v.X * m1[0].X + v.Y * m1[1].X, v.X * m1[0].Y + v.Y * m1[1].Y);
        }

        public static Vector3f operator *(Matrix3f m1, Vector3f v)
        {
            return new Vector3f(m1[0].X * v.X + m1[0].Y * v.Y + m1[0].Z * v.Z,
                m1[1].X * v.X + m1[1].Y * v.Y + m1[1].Z * v.Z,
                m1[2].X * v.X + m1[2].Y * v.Y + m1[2].Z * v.Z);
        }

        public static Vector3f operator *(Vector3f v, Matrix3f m1)
        {
            return new Vector3f(v.X * m1[0].X + v.Y * m1[1].X + v.Z * m1[2].X,
                v.X * m1[0].Y + v.Y * m1[1].Y + v.Z * m1[2].Y,
                v.X * m1[0].Z + v.Y * m1[1].Z + v.Z * m1[2].Z);
        }

        public static bool operator ==(Matrix3f m1, Matrix3f m2)
        {
            return (m1[0] == m2[0] && m1[1] == m2[1] && m1[2] == m2[2]);
        }

        /// <summary>
        /// Compare two <see cref="Matrix3f"/> for difference.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns></returns>
        public static bool operator !=(Matrix3f m1, Matrix3f m2)
        {
            return (m1[0] != m2[0] || m1[1] != m2[1] || m1[2] != m2[2]);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Ovverrides the Equals() method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Matrix3f) && (Equals((Matrix3f)obj));
        }

        /// <summary>
        /// Compare two matrices and determine if their equal.
        /// </summary>
        /// <param name="other">The matrix to compare with this instance.</param>
        /// <returns></returns>
        public bool Equals(Matrix3f other)
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
            Row0 = Vector3f.Parse(parts[0]);
            Row1 = Vector3f.Parse(parts[1]);
            Row2 = Vector3f.Parse(parts[2]);
        }

        /// <summary>
        /// Returns the matrix as an array of floats, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return new float[] { M11, M12, M13, M21, M22, M23, M31, M32, M33 };
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> representation of the matrix.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]", Row0, Row1, Row2);
        }

        /// <summary>
        /// Returns the <see cref="Matrix2f"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="Matrix2f"/> portion of this matrix.</returns>
        public Matrix2f ToMatrix2f()
        {
            return new Matrix2f(new Vector2f(Row0.X, Row0.Y), new Vector2f(Row1.X, Row1.Y));
        }

        #endregion

        #endregion
    }
}