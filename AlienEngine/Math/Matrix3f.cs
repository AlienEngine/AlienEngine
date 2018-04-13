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
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public float M11;

        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public float M12;

        /// <summary>
        /// Value at row 1, column 3 of the matrix.
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
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public float M31;

        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public float M32;

        /// <summary>
        /// Value at row 3, column 3 of the matrix.
        /// </summary>
        public float M33;

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

            M11 = rows[0].X;
            M12 = rows[0].Y;
            M13 = rows[0].Z;
            M21 = rows[1].X;
            M22 = rows[1].Y;
            M23 = rows[1].Z;
            M31 = rows[2].X;
            M32 = rows[2].Y;
            M33 = rows[2].Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix3f(Vector3f row0, Vector3f row1, Vector3f row2)
        {
            M11 = row0.X;
            M12 = row0.Y;
            M13 = row0.Z;
            M21 = row1.X;
            M22 = row1.Y;
            M23 = row1.Z;
            M31 = row2.X;
            M32 = row2.Y;
            M33 = row2.Z;
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
            M11 = a;
            M12 = b;
            M13 = c;
            M21 = d;
            M22 = e;
            M23 = f;
            M31 = g;
            M32 = h;
            M33 = i;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="row">The <see cref="Vector3f"/> to use for all rows.</param>
        public Matrix3f(Vector3f row)
        {
            M11 = row.X;
            M12 = row.Y;
            M13 = row.Z;
            M21 = row.X;
            M22 = row.Y;
            M23 = row.Z;
            M31 = row.X;
            M32 = row.Y;
            M33 = row.Z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="matrix">The <see cref="Matrix4f"/> to copy.</param>
        public Matrix3f(Matrix4f matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="matrix">The <see cref="Matrix3f"/> to copy.</param>
        public Matrix3f(Matrix3f matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix3f(float[] values)
        {
            if (values.Length < 9)
                throw new ArgumentOutOfRangeException();

            M11 = values[0];
            M12 = values[1];
            M13 = values[2];
            M21 = values[3];
            M22 = values[4];
            M23 = values[5];
            M31 = values[6];
            M32 = values[7];
            M33 = values[8];
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
            result.M23 = translation.X;
            result.M33 = translation.Y;
            return result;
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix3f object that contains the rotation matrix.</returns>
        public static Matrix3f CreateRotation2D(float angle)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            return new Matrix3f(
                new Vector3f(cos, sin, 0f),
                new Vector3f(-sin, cos, 0f),
                Vector3f.UnitZ);
        }

        /// <summary>
        /// Creates a matrix which contains information on how to rotate.
        /// </summary>
        /// <param name="angle">Amount to rotate in radians (counter-clockwise).</param>
        /// <returns>A Matrix3f object that contains the rotation matrix.</returns>
        public static Matrix3f CreateRotation3D(float angle)
        {
            return CreateRotation(angle, angle, angle);
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="angleX">Angle on X axis in radians.</param>
        /// <param name="angleY">Angle on Y axis in radians.</param>
        /// <param name="angleZ">Angle on Z axis in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotation(float angleX, float angleY, float angleZ, out Matrix3f result)
        {
            result = CreateRotation(angleX, angleY, angleZ);
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="vector">A vetor of counter-clockwise angles in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static Matrix3f CreateRotation(Vector3f vector)
        {
            return CreateRotation(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="angleX">X rotation in radians.</param>
        /// <param name="angleY">Y rotation in radians.</param>
        /// <param name="angleZ">Z rotation in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix3f CreateRotation(float angleX, float angleY, float angleZ)
        {
            Matrix3f rXY = CreateRotationZ(angleZ);
            Matrix3f rXZ = CreateRotationY(angleY);
            Matrix3f rYZ = CreateRotationX(angleX);

            return (rYZ * rXZ) * rXY;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationX(float angle, out Matrix3f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.M22 = +cos;
            result.M23 = +sin;
            result.M32 = -sin;
            result.M33 = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix3f CreateRotationX(float angle)
        {
            Matrix3f result;
            CreateRotationX(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationY(float angle, out Matrix3f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.M11 = +cos;
            result.M13 = -sin;
            result.M31 = +sin;
            result.M33 = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix3f CreateRotationY(float angle)
        {
            Matrix3f result;
            CreateRotationY(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationZ(float angle, out Matrix3f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.M11 = +cos;
            result.M12 = +sin;
            result.M21 = -sin;
            result.M22 = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix3f CreateRotationZ(float angle)
        {
            Matrix3f result;
            CreateRotationZ(angle, out result);
            return result;
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

        /// <summary>
        /// Calculates the determinant of largest nonsingular submatrix, excluding 2x2's that involve M13 or M31, and excluding all 1x1's that involve nondiagonal elements.
        /// </summary>
        /// <param name="subMatrixCode">Represents the submatrix that was used to compute the determinant.
        /// 0 is the full 3x3.  1 is the upper left 2x2.  2 is the lower right 2x2.  3 is the four corners.
        /// 4 is M11.  5 is M22.  6 is M33.</param>
        /// <returns>The matrix's determinant.</returns>
        internal float AdaptiveDeterminant(out int subMatrixCode)
        {
            //Try the full matrix first.
            float determinant = M11 * M22 * M33 + M12 * M23 * M31 + M13 * M21 * M32 -
                                M31 * M22 * M13 - M32 * M23 * M11 - M33 * M21 * M12;
            if (determinant != 0) //This could be a little numerically flimsy.  Fortunately, the way this method is used, that doesn't matter!
            {
                subMatrixCode = 0;
                return determinant;
            }
            //Try m11, m12, m21, m22.
            determinant = M11 * M22 - M12 * M21;
            if (determinant != 0)
            {
                subMatrixCode = 1;
                return determinant;
            }
            //Try m22, m23, m32, m33.
            determinant = M22 * M33 - M23 * M32;
            if (determinant != 0)
            {
                subMatrixCode = 2;
                return determinant;
            }
            //Try m11, m13, m31, m33.
            determinant = M11 * M33 - M13 * M12;
            if (determinant != 0)
            {
                subMatrixCode = 3;
                return determinant;
            }
            //Try m11.
            if (M11 != 0)
            {
                subMatrixCode = 4;
                return M11;
            }
            //Try m22.
            if (M22 != 0)
            {
                subMatrixCode = 5;
                return M22;
            }
            //Try m33.
            if (M33 != 0)
            {
                subMatrixCode = 6;
                return M33;
            }
            //It's completely singular!
            subMatrixCode = -1;
            return 0;
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets if this matrix is an identity matrix.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                float epsilon = MathHelper.BigEpsilon;

                return (M12 <= epsilon && M12 >= -epsilon &&
                        M13 <= epsilon && M13 >= -epsilon &&
                        M21 <= epsilon && M21 >= -epsilon &&
                        M23 <= epsilon && M23 >= -epsilon &&
                        M31 <= epsilon && M31 >= -epsilon &&
                        M32 <= epsilon && M32 >= -epsilon &&
                        M11 <= 1.0f + epsilon && M11 >= 1.0f - epsilon &&
                        M22 <= 1.0f + epsilon && M22 >= 1.0f - epsilon &&
                        M33 <= 1.0f + epsilon && M33 >= 1.0f - epsilon);
            }
        }

        /// <summary>
        /// Gets or sets the backward vector of the matrix.
        /// </summary>
        public Vector3f Backward
        {
            get { return -Column2; }
            set { Column2 = -value; }
        }

        /// <summary>
        /// Gets or sets the down vector of the matrix.
        /// </summary>
        public Vector3f Down
        {
            get { return -Column1; }
            set { Column1 = -value; }
        }

        /// <summary>
        /// Gets or sets the forward vector of the matrix.
        /// </summary>
        public Vector3f Forward
        {
            get { return Column2; }
            set { Column2 = value; }
        }

        /// <summary>
        /// Gets or sets the left vector of the matrix.
        /// </summary>
        public Vector3f Left
        {
            get { return -Column0; }
            set { Column0 = -value; }
        }

        /// <summary>
        /// Gets or sets the right vector of the matrix.
        /// </summary>
        public Vector3f Right
        {
            get { return Column0; }
            set { Column0 = value; }
        }

        /// <summary>
        /// Gets or sets the up vector of the matrix.
        /// </summary>
        public Vector3f Up
        {
            get { return Column1; }
            set { Column1 = value; }
        }

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix3f Transposed
        {
            get { return new Matrix3f(new Vector3f(M11, M21, M31), new Vector3f(M12, M22, M32), new Vector3f(M13, M23, M33)); }
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
                float oneOverDeterminant = OneOverDeterminant;
                return new Matrix3f(
                    +(M22 * M33 - M23 * M32) * oneOverDeterminant,
                    -(M21 * M33 - M23 * M31) * oneOverDeterminant,
                    +(M21 * M32 - M22 * M31) * oneOverDeterminant,
                    -(M12 * M33 - M13 * M32) * oneOverDeterminant,
                    +(M11 * M33 - M13 * M31) * oneOverDeterminant,
                    -(M11 * M32 - M12 * M31) * oneOverDeterminant,
                    +(M12 * M23 - M13 * M22) * oneOverDeterminant,
                    -(M11 * M23 - M13 * M21) * oneOverDeterminant,
                    +(M11 * M22 - M12 * M21) * oneOverDeterminant
                ).Transposed;
            }
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
        /// Gets the second column of the matrix.
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
        /// Gets the third column of the matrix.
        /// </summary>
        public Vector3f Column2
        {
            get { return new Vector3f(M13, M23, M33); }
            set
            {
                M13 = value.X;
                M23 = value.Y;
                M33 = value.Z;
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
        /// Second row of the matrix.
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

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector3f Row2
        {
            get { return new Vector3f(M31, M32, M33); }
            set
            {
                M31 = value.X;
                M32 = value.Y;
                M33 = value.Z;
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
                if (row == 0)
                {
                    return Row0;
                }
                if (row == 1)
                {
                    return Row1;
                }
                if (row == 2)
                {
                    return Row2;
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0)
                {
                    Row0 = value;
                }
                else if (row == 1)
                {
                    Row1 = value;
                }
                else if (row == 2)
                {
                    Row2 = value;
                }
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
                if (row == 0)
                {
                    return Row0[column];
                }
                if (row == 1)
                {
                    return Row1[column];
                }
                if (row == 2)
                {
                    return Row2[column];
                }
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
                else if (row == 2)
                {
                    if (column == 0) M31 = value;
                    if (column == 1) M32 = value;
                    if (column == 2) M33 = value;
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
        public static Matrix3f Transpose(Matrix3f matrix)
        {
            Matrix3f res;
            Transpose(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Gets the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <param name="transpose">The transposed matrix.</param>
        public static void Transpose(ref Matrix3f matrix, out Matrix3f transpose)
        {
            transpose = matrix.Transposed;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static Matrix3f Invert(Matrix3f matrix)
        {
            Matrix3f res;
            Invert(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to inverse.</param>
        /// <param name="inverse">The inversed matrix.</param>
        public static void Invert(ref Matrix3f matrix, out Matrix3f inverse)
        {
            inverse = matrix.Inversed;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to add.</param>
        /// <param name="right">Second matrix to add.</param>
        /// <returns>Sum of the two matrices.</returns>
        public static Matrix3f Add(Matrix3f left, Matrix3f right)
        {
            Matrix3f res;
            Add(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="left">First matrix to add.</param>
        /// <param name="right">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix3f left, ref Matrix3f right, out Matrix3f result)
        {
            float m11 = left.M11 + right.M11;
            float m12 = left.M12 + right.M12;
            float m13 = left.M13 + right.M13;

            float m21 = left.M21 + right.M21;
            float m22 = left.M22 + right.M22;
            float m23 = left.M23 + right.M23;

            float m31 = left.M31 + right.M31;
            float m32 = left.M32 + right.M32;
            float m33 = left.M33 + right.M33;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <returns>Sum of the two matrices.</returns>
        public static Matrix3f Add(Matrix4f a, Matrix3f b)
        {
            Matrix3f res;
            Add(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix4f a, ref Matrix3f b, out Matrix3f result)
        {
            float m11 = a.M11 + b.M11;
            float m12 = a.M12 + b.M12;
            float m13 = a.M13 + b.M13;

            float m21 = a.M21 + b.M21;
            float m22 = a.M22 + b.M22;
            float m23 = a.M23 + b.M23;

            float m31 = a.M31 + b.M31;
            float m32 = a.M32 + b.M32;
            float m33 = a.M33 + b.M33;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <returns>Sum of the two matrices.</returns>
        public static Matrix3f Add(Matrix3f a, Matrix4f b)
        {
            Matrix3f res;
            Add(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix3f a, ref Matrix4f b, out Matrix3f result)
        {
            Add(ref b, ref a, out result);
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <returns>Sum of the two matrices.</returns>
        public static Matrix3f Add(Matrix4f a, Matrix4f b)
        {
            Matrix3f res;
            Add(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref Matrix4f a, ref Matrix4f b, out Matrix3f result)
        {
            float m11 = a.M11 + b.M11;
            float m12 = a.M12 + b.M12;
            float m13 = a.M13 + b.M13;

            float m21 = a.M21 + b.M21;
            float m22 = a.M22 + b.M22;
            float m23 = a.M23 + b.M23;

            float m31 = a.M31 + b.M31;
            float m32 = a.M32 + b.M32;
            float m33 = a.M33 + b.M33;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// Creates a skew symmetric matrix M from vector A such that M * B for some other vector B is equivalent to the cross product of A and B.
        /// </summary>
        /// <param name="v">Vector to base the matrix on.</param>
        /// <returns>Skew-symmetric matrix result.</returns>
        public static Matrix3f CreateCrossProduct(Vector3f v)
        {
            Matrix3f res;
            CreateCrossProduct(ref v, out res);
            return res;
        }

        /// <summary>
        /// Creates a skew symmetric matrix M from vector A such that M * B for some other vector B is equivalent to the cross product of A and B.
        /// </summary>
        /// <param name="v">Vector to base the matrix on.</param>
        /// <param name="result">Skew-symmetric matrix result.</param>
        public static void CreateCrossProduct(ref Vector3f v, out Matrix3f result)
        {
            result.M11 = 0;
            result.M12 = -v.Z;
            result.M13 = v.Y;
            result.M21 = v.Z;
            result.M22 = 0;
            result.M23 = -v.X;
            result.M31 = -v.Y;
            result.M32 = v.X;
            result.M33 = 0;
        }

        /// <summary>
        /// Creates a 3x3 matrix from an XNA 4x4 matrix.
        /// </summary>
        /// <param name="matrix4">Matrix to extract a 3x3 matrix from.</param>
        /// <returns>Upper 3x3 matrix extracted from the XNA matrix.</returns>
        public static Matrix3f FromMatrix4f(Matrix4f matrix4)
        {
            Matrix3f matrix3;
            FromMatrix4f(ref matrix4, out matrix3);
            return matrix3;
        }

        /// <summary>
        /// Creates a 3x3 matrix from an XNA 4x4 matrix.
        /// </summary>
        /// <param name="matrix4">Matrix to extract a 3x3 matrix from.</param>
        /// <param name="matrix3">Upper 3x3 matrix extracted from the XNA matrix.</param>
        public static void FromMatrix4f(ref Matrix4f matrix4, out Matrix3f matrix3)
        {
            matrix3.M11 = matrix4.M11;
            matrix3.M12 = matrix4.M12;
            matrix3.M13 = matrix4.M13;

            matrix3.M21 = matrix4.M21;
            matrix3.M22 = matrix4.M22;
            matrix3.M23 = matrix4.M23;

            matrix3.M31 = matrix4.M31;
            matrix3.M32 = matrix4.M32;
            matrix3.M33 = matrix4.M33;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <returns>Scaling matrix.</returns>
        public static Matrix3f CreateScale2D(float scale)
        {
            Matrix3f matrix;
            CreateScale2D(scale, out matrix);
            return matrix;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <returns>Scaling matrix.</returns>
        public static Matrix3f CreateScale3D(float scale)
        {
            Matrix3f matrix;
            CreateScale3D(scale, out matrix);
            return matrix;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale2D(float scale, out Matrix3f matrix)
        {
            matrix = new Matrix3f {M11 = scale, M22 = scale, M33 = 1.0f};
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale3D(float scale, out Matrix3f matrix)
        {
            matrix = new Matrix3f {M11 = scale, M22 = scale, M33 = scale};
        }
        
        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <returns>Scaling matrix.</returns>
        public static Matrix3f CreateScale(Vector3f scale)
        {
            Matrix3f matrix;
            CreateScale(ref scale, out matrix);
            return matrix;
        }

        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Values defining the axis scales.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(ref Vector3f scale, out Matrix3f matrix)
        {
            matrix = new Matrix3f {M11 = scale.X, M22 = scale.Y, M33 = scale.Z};
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="x">The scale at the X axis.</param>
        /// <param name="y">The scale at the Y axis.</param>
        /// <param name="z">The scale at the Z axis.</param>
        /// <returns>Scaling matrix.</returns>
        public static Matrix3f CreateScale(float x, float y, float z)
        {
            Matrix3f matrix;
            CreateScale(x, y, z, out matrix);
            return matrix;
        }

        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="x">Scaling along the x axis.</param>
        /// <param name="y">Scaling along the y axis.</param>
        /// <param name="z">Scaling along the z axis.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(float x, float y, float z, out Matrix3f matrix)
        {
            matrix = new Matrix3f {M11 = x, M22 = y, M33 = z};
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f Multiply(Matrix3f left, Matrix3f right)
        {
            Matrix3f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix3f left, ref Matrix3f right, out Matrix3f result)
        {
            result = new Matrix3f(
                Vector3f.Dot(left.Row0, right.Column0), Vector3f.Dot(left.Row0, right.Column1), Vector3f.Dot(left.Row0, right.Column2),
                Vector3f.Dot(left.Row1, right.Column0), Vector3f.Dot(left.Row1, right.Column1), Vector3f.Dot(left.Row1, right.Column2),
                Vector3f.Dot(left.Row2, right.Column0), Vector3f.Dot(left.Row2, right.Column1), Vector3f.Dot(left.Row2, right.Column2)
            );
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f Multiply(Matrix3f left, Matrix4f right)
        {
            Matrix3f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix3f a, ref Matrix4f b, out Matrix3f result)
        {
            float resultM11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31;
            float resultM12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32;
            float resultM13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33;

            float resultM21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31;
            float resultM22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32;
            float resultM23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33;

            float resultM31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31;
            float resultM32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32;
            float resultM33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;

            result.M31 = resultM31;
            result.M32 = resultM32;
            result.M33 = resultM33;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="left">First matrix to multiply.</param>
        /// <param name="right">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f Multiply(Matrix4f left, Matrix3f right)
        {
            Matrix3f res;
            Multiply(ref left, ref right, out res);
            return res;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref Matrix4f a, ref Matrix3f b, out Matrix3f result)
        {
            float resultM11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31;
            float resultM12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32;
            float resultM13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33;

            float resultM21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31;
            float resultM22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32;
            float resultM23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33;

            float resultM31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31;
            float resultM32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32;
            float resultM33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;

            result.M31 = resultM31;
            result.M32 = resultM32;
            result.M33 = resultM33;
        }

        /// <summary>
        /// Multiplies a transposed matrix with another matrix.
        /// </summary>
        /// <param name="transpose">First matrix to multiply.</param>
        /// <param name="matrix">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f MultiplyTransposed(Matrix3f transpose, Matrix3f matrix)
        {
            Matrix3f res;
            MultiplyTransposed(ref transpose, ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Multiplies a transposed matrix with another matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be multiplied.</param>
        /// <param name="transpose">Matrix to be transposed and multiplied.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void MultiplyTransposed(ref Matrix3f transpose, ref Matrix3f matrix, out Matrix3f result)
        {
            float resultM11 = transpose.M11 * matrix.M11 + transpose.M21 * matrix.M21 + transpose.M31 * matrix.M31;
            float resultM12 = transpose.M11 * matrix.M12 + transpose.M21 * matrix.M22 + transpose.M31 * matrix.M32;
            float resultM13 = transpose.M11 * matrix.M13 + transpose.M21 * matrix.M23 + transpose.M31 * matrix.M33;

            float resultM21 = transpose.M12 * matrix.M11 + transpose.M22 * matrix.M21 + transpose.M32 * matrix.M31;
            float resultM22 = transpose.M12 * matrix.M12 + transpose.M22 * matrix.M22 + transpose.M32 * matrix.M32;
            float resultM23 = transpose.M12 * matrix.M13 + transpose.M22 * matrix.M23 + transpose.M32 * matrix.M33;

            float resultM31 = transpose.M13 * matrix.M11 + transpose.M23 * matrix.M21 + transpose.M33 * matrix.M31;
            float resultM32 = transpose.M13 * matrix.M12 + transpose.M23 * matrix.M22 + transpose.M33 * matrix.M32;
            float resultM33 = transpose.M13 * matrix.M13 + transpose.M23 * matrix.M23 + transpose.M33 * matrix.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;

            result.M31 = resultM31;
            result.M32 = resultM32;
            result.M33 = resultM33;
        }

        /// <summary>
        /// Multiplies a transposed matrix with another matrix.
        /// </summary>
        /// <param name="matrix">Second matrix to multiply.</param>
        /// <param name="transpose">First matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f MultiplyByTransposed(Matrix3f matrix, Matrix3f transpose)
        {
            Matrix3f res;
            MultiplyByTransposed(ref matrix, ref transpose, out res);
            return res;
        }

        /// <summary>
        /// Multiplies a matrix with a transposed matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be multiplied.</param>
        /// <param name="transpose">Matrix to be transposed and multiplied.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void MultiplyByTransposed(ref Matrix3f matrix, ref Matrix3f transpose, out Matrix3f result)
        {
            float resultM11 = matrix.M11 * transpose.M11 + matrix.M12 * transpose.M12 + matrix.M13 * transpose.M13;
            float resultM12 = matrix.M11 * transpose.M21 + matrix.M12 * transpose.M22 + matrix.M13 * transpose.M23;
            float resultM13 = matrix.M11 * transpose.M31 + matrix.M12 * transpose.M32 + matrix.M13 * transpose.M33;

            float resultM21 = matrix.M21 * transpose.M11 + matrix.M22 * transpose.M12 + matrix.M23 * transpose.M13;
            float resultM22 = matrix.M21 * transpose.M21 + matrix.M22 * transpose.M22 + matrix.M23 * transpose.M23;
            float resultM23 = matrix.M21 * transpose.M31 + matrix.M22 * transpose.M32 + matrix.M23 * transpose.M33;

            float resultM31 = matrix.M31 * transpose.M11 + matrix.M32 * transpose.M12 + matrix.M33 * transpose.M13;
            float resultM32 = matrix.M31 * transpose.M21 + matrix.M32 * transpose.M22 + matrix.M33 * transpose.M23;
            float resultM33 = matrix.M31 * transpose.M31 + matrix.M32 * transpose.M32 + matrix.M33 * transpose.M33;

            result.M11 = resultM11;
            result.M12 = resultM12;
            result.M13 = resultM13;

            result.M21 = resultM21;
            result.M22 = resultM22;
            result.M23 = resultM23;

            result.M31 = resultM31;
            result.M32 = resultM32;
            result.M33 = resultM33;
        }

        /// <summary>
        /// Multiplies a transposed matrix with another matrix.
        /// </summary>
        /// <param name="matrix">Second matrix to multiply.</param>
        /// <param name="scale">Amount to scale.</param>
        /// <returns>Product of the multiplication.</returns>
        public static Matrix3f Multiply(Matrix3f matrix, float scale)
        {
            Matrix3f res;
            Multiply(ref matrix, scale, out res);
            return res;
        }

        /// <summary>
        /// Scales all components of the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to scale.</param>
        /// <param name="scale">Amount to scale.</param>
        /// <param name="result">Scaled matrix.</param>
        public static void Multiply(ref Matrix3f matrix, float scale, out Matrix3f result)
        {
            result.M11 = matrix.M11 * scale;
            result.M12 = matrix.M12 * scale;
            result.M13 = matrix.M13 * scale;

            result.M21 = matrix.M21 * scale;
            result.M22 = matrix.M22 * scale;
            result.M23 = matrix.M23 * scale;

            result.M31 = matrix.M31 * scale;
            result.M32 = matrix.M32 * scale;
            result.M33 = matrix.M33 * scale;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <returns>Negated matrix.</returns>
        public static Matrix3f Negate(Matrix3f matrix)
        {
            Matrix3f res;
            Negate(ref matrix, out res);
            return res;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref Matrix3f matrix, out Matrix3f result)
        {
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M13;

            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;

            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to subtract.</param>
        /// <param name="b">Second matrix to subtract.</param>
        /// <returns>Difference of the two matrices.</returns>
        public static Matrix3f Subtract(Matrix3f a, Matrix3f b)
        {
            Matrix3f res;
            Subtract(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to subtract.</param>
        /// <param name="b">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref Matrix3f a, ref Matrix3f b, out Matrix3f result)
        {
            float m11 = a.M11 - b.M11;
            float m12 = a.M12 - b.M12;
            float m13 = a.M13 - b.M13;

            float m21 = a.M21 - b.M21;
            float m22 = a.M22 - b.M22;
            float m23 = a.M23 - b.M23;

            float m31 = a.M31 - b.M31;
            float m32 = a.M32 - b.M32;
            float m33 = a.M33 - b.M33;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// Creates a 4x4 matrix from a 3x3 matrix.
        /// </summary>
        /// <param name="a">3x3 matrix.</param>
        /// <returns>Created 4x4 matrix.</returns>
        public static Matrix4f ToMatrix4f(Matrix3f a)
        {
            Matrix4f res;
            ToMatrix4f(ref a, out res);
            return res;
        }

        /// <summary>
        /// Creates a 4x4 matrix from a 3x3 matrix.
        /// </summary>
        /// <param name="a">3x3 matrix.</param>
        /// <param name="b">Created 4x4 matrix.</param>
        public static void ToMatrix4f(ref Matrix3f a, out Matrix4f b)
        {
            b = Matrix4f.Zero;

            b.M11 = a.M11;
            b.M12 = a.M12;
            b.M13 = a.M13;

            b.M21 = a.M21;
            b.M22 = a.M22;
            b.M23 = a.M23;

            b.M31 = a.M31;
            b.M32 = a.M32;
            b.M33 = a.M33;

            b.M44 = 1.0f;
            b.M14 = 0.0f;
            b.M24 = 0.0f;
            b.M34 = 0.0f;
            b.M41 = 0.0f;
            b.M42 = 0.0f;
            b.M43 = 0.0f;
        }

        /// <summary>
        /// Inverts the largest nonsingular submatrix in the matrix, excluding 2x2's that involve M13 or M31, and excluding 1x1's that include nondiagonal elements.
        /// </summary>
        /// <param name="matrix">Matrix to be inverted.</param>
        /// <param name="result">Inverted matrix.</param>
        public static void AdaptiveInvert(ref Matrix3f matrix, out Matrix3f result)
        {
            int submatrix;
            float determinantInverse = 1 / matrix.AdaptiveDeterminant(out submatrix);
            float m11, m12, m13, m21, m22, m23, m31, m32, m33;
            switch (submatrix)
            {
                case 0: //Full matrix.
                    m11 = (matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32) * determinantInverse;
                    m12 = (matrix.M13 * matrix.M32 - matrix.M33 * matrix.M12) * determinantInverse;
                    m13 = (matrix.M12 * matrix.M23 - matrix.M22 * matrix.M13) * determinantInverse;

                    m21 = (matrix.M23 * matrix.M31 - matrix.M21 * matrix.M33) * determinantInverse;
                    m22 = (matrix.M11 * matrix.M33 - matrix.M13 * matrix.M31) * determinantInverse;
                    m23 = (matrix.M13 * matrix.M21 - matrix.M11 * matrix.M23) * determinantInverse;

                    m31 = (matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31) * determinantInverse;
                    m32 = (matrix.M12 * matrix.M31 - matrix.M11 * matrix.M32) * determinantInverse;
                    m33 = (matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21) * determinantInverse;
                    break;
                case 1: //Upper left matrix, m11, m12, m21, m22.
                    m11 = matrix.M22 * determinantInverse;
                    m12 = -matrix.M12 * determinantInverse;
                    m13 = 0;

                    m21 = -matrix.M21 * determinantInverse;
                    m22 = matrix.M11 * determinantInverse;
                    m23 = 0;

                    m31 = 0;
                    m32 = 0;
                    m33 = 0;
                    break;
                case 2: //Lower right matrix, m22, m23, m32, m33.
                    m11 = 0;
                    m12 = 0;
                    m13 = 0;

                    m21 = 0;
                    m22 = matrix.M33 * determinantInverse;
                    m23 = -matrix.M23 * determinantInverse;

                    m31 = 0;
                    m32 = -matrix.M32 * determinantInverse;
                    m33 = matrix.M22 * determinantInverse;
                    break;
                case 3: //Corners, m11, m31, m13, m33.
                    m11 = matrix.M33 * determinantInverse;
                    m12 = 0;
                    m13 = -matrix.M13 * determinantInverse;

                    m21 = 0;
                    m22 = 0;
                    m23 = 0;

                    m31 = -matrix.M31 * determinantInverse;
                    m32 = 0;
                    m33 = matrix.M11 * determinantInverse;
                    break;
                case 4: //M11
                    m11 = 1 / matrix.M11;
                    m12 = 0;
                    m13 = 0;

                    m21 = 0;
                    m22 = 0;
                    m23 = 0;

                    m31 = 0;
                    m32 = 0;
                    m33 = 0;
                    break;
                case 5: //M22
                    m11 = 0;
                    m12 = 0;
                    m13 = 0;

                    m21 = 0;
                    m22 = 1 / matrix.M22;
                    m23 = 0;

                    m31 = 0;
                    m32 = 0;
                    m33 = 0;
                    break;
                case 6: //M33
                    m11 = 0;
                    m12 = 0;
                    m13 = 0;

                    m21 = 0;
                    m22 = 0;
                    m23 = 0;

                    m31 = 0;
                    m32 = 0;
                    m33 = 1 / matrix.M33;
                    break;
                default: //Completely singular.
                    m11 = 0;
                    m12 = 0;
                    m13 = 0;
                    m21 = 0;
                    m22 = 0;
                    m23 = 0;
                    m31 = 0;
                    m32 = 0;
                    m33 = 0;
                    break;
            }

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// <para>Computes the adjugate transpose of a matrix.</para>
        /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
        /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
        /// </summary>
        /// <param name="matrix">Matrix to compute the adjugate transpose of.</param>
        /// <param name="result">Adjugate transpose of the input matrix.</param>
        public static void AdjugateTranspose(ref Matrix3f matrix, out Matrix3f result)
        {
            //Despite the relative obscurity of the operation, this is a fairly straightforward operation which is actually faster than a true invert (by virtue of cancellation).
            //Conceptually, this is implemented as transpose(det(M) * invert(M)), but that's perfectly acceptable:
            //1) transpose(invert(M)) == invert(transpose(M)), and
            //2) det(M) == det(transpose(M))
            //This organization makes it clearer that the invert's usual division by determinant drops out.

            float m11 = (matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32);
            float m12 = (matrix.M13 * matrix.M32 - matrix.M33 * matrix.M12);
            float m13 = (matrix.M12 * matrix.M23 - matrix.M22 * matrix.M13);

            float m21 = (matrix.M23 * matrix.M31 - matrix.M21 * matrix.M33);
            float m22 = (matrix.M11 * matrix.M33 - matrix.M13 * matrix.M31);
            float m23 = (matrix.M13 * matrix.M21 - matrix.M11 * matrix.M23);

            float m31 = (matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31);
            float m32 = (matrix.M12 * matrix.M31 - matrix.M11 * matrix.M32);
            float m33 = (matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21);

            //Note transposition.
            result.M11 = m11;
            result.M12 = m21;
            result.M13 = m31;

            result.M21 = m12;
            result.M22 = m22;
            result.M23 = m32;

            result.M31 = m13;
            result.M32 = m23;
            result.M33 = m33;
        }

        /// <summary>
        /// <para>Computes the adjugate transpose of a matrix.</para>
        /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
        /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
        /// </summary>
        /// <param name="matrix">Matrix to compute the adjugate transpose of.</param>
        /// <returns>Adjugate transpose of the input matrix.</returns>
        public static Matrix3f AdjugateTranspose(Matrix3f matrix)
        {
            Matrix3f toReturn;
            AdjugateTranspose(ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to use to create a matrix.</param>
        /// <returns>Matrix representing the quaternion's orientation.</returns>
        public static Matrix3f FromQuaternion(Quaternion quaternion)
        {
            Matrix3f result;
            FromQuaternion(ref quaternion, out result);
            return result;
        }

        /// <summary>
        /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to use to create a matrix.</param>
        /// <param name="result">Matrix representing the quaternion's orientation.</param>
        public static void FromQuaternion(ref Quaternion quaternion, out Matrix3f result)
        {
            float qX2 = quaternion.X + quaternion.X;
            float qY2 = quaternion.Y + quaternion.Y;
            float qZ2 = quaternion.Z + quaternion.Z;
            float XX = qX2 * quaternion.X;
            float YY = qY2 * quaternion.Y;
            float ZZ = qZ2 * quaternion.Z;
            float XY = qX2 * quaternion.Y;
            float XZ = qX2 * quaternion.Z;
            float XW = qX2 * quaternion.W;
            float YZ = qY2 * quaternion.Z;
            float YW = qY2 * quaternion.W;
            float ZW = qZ2 * quaternion.W;

            result.M11 = 1 - YY - ZZ;
            result.M21 = XY - ZW;
            result.M31 = XZ + YW;

            result.M12 = XY + ZW;
            result.M22 = 1 - XX - ZZ;
            result.M32 = YZ - XW;

            result.M13 = XZ - YW;
            result.M23 = YZ + XW;
            result.M33 = 1 - XX - YY;
        }

        /// <summary>
        /// Computes the outer product of the given vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>Outer product result.</returns>
        public static Matrix3f CreateOuterProduct(Vector3f a, Vector3f b)
        {
            Matrix3f res;
            CreateOuterProduct(ref a, ref b, out res);
            return res;
        }

        /// <summary>
        /// Computes the outer product of the given vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="result">Outer product result.</param>
        public static void CreateOuterProduct(ref Vector3f a, ref Vector3f b, out Matrix3f result)
        {
            result.M11 = a.X * b.X;
            result.M12 = a.X * b.Y;
            result.M13 = a.X * b.Z;

            result.M21 = a.Y * b.X;
            result.M22 = a.Y * b.Y;
            result.M23 = a.Y * b.Z;

            result.M31 = a.Z * b.X;
            result.M32 = a.Z * b.Y;
            result.M33 = a.Z * b.Z;
        }

        /// <summary>
        /// Creates a matrix representing a rotation of a given angle around a given axis.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Amount to rotate.</param>
        /// <returns>Matrix representing the rotation.</returns>
        public static Matrix3f CreateFromAxisAngle(Vector3f axis, float angle)
        {
            Matrix3f toReturn;
            CreateFromAxisAngle(ref axis, angle, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates a matrix representing a rotation of a given angle around a given axis.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Amount to rotate.</param>
        /// <param name="result">Matrix representing the rotation.</param>
        public static void CreateFromAxisAngle(ref Vector3f axis, float angle, out Matrix3f result)
        {
            float xx = axis.X * axis.X;
            float yy = axis.Y * axis.Y;
            float zz = axis.Z * axis.Z;
            float xy = axis.X * axis.Y;
            float xz = axis.X * axis.Z;
            float yz = axis.Y * axis.Z;

            float sinAngle = (float) System.Math.Sin(angle);
            float oneMinusCosAngle = 1 - (float) System.Math.Cos(angle);

            result.M11 = 1 + oneMinusCosAngle * (xx - 1);
            result.M21 = -axis.Z * sinAngle + oneMinusCosAngle * xy;
            result.M31 = axis.Y * sinAngle + oneMinusCosAngle * xz;

            result.M12 = axis.Z * sinAngle + oneMinusCosAngle * xy;
            result.M22 = 1 + oneMinusCosAngle * (yy - 1);
            result.M32 = -axis.X * sinAngle + oneMinusCosAngle * yz;

            result.M13 = -axis.Y * sinAngle + oneMinusCosAngle * xz;
            result.M23 = axis.X * sinAngle + oneMinusCosAngle * yz;
            result.M33 = 1 + oneMinusCosAngle * (zz - 1);
        }

        #endregion

        #region CreateFromToMatrix

        /// <summary>
        /// Creates a rotation matrix that rotates a vector called "from" into another
        /// vector called "to". Based on an algorithm by Tomas Moller and John Hudges:
        /// <para>
        /// "Efficiently Building a Matrix to Rotate One Vector to Another"
        /// Journal of Graphics Tools, 4(4):1-4, 1999
        /// </para>
        /// </summary>
        /// <param name="from">Starting vector</param>
        /// <param name="to">Ending vector</param>
        /// <returns>Rotation matrix to rotate from the start to end.</returns>
        public static Matrix3f CreateFromToMatrix(Vector3f from, Vector3f to)
        {
            float e = Vector3f.Dot(from, to);
            float f = (e < 0) ? -e : e;

            Matrix3f m = Identity;

            //"from" and "to" vectors almost parallel
            if (f > 1.0f - 0.00001f)
            {
                Vector3f u, v; //Temp variables
                Vector3f x; //Vector almost orthogonal to "from"

                x.X = (from.X > 0.0f) ? from.X : -from.X;
                x.Y = (from.Y > 0.0f) ? from.Y : -from.Y;
                x.Z = (from.Z > 0.0f) ? from.Z : -from.Z;

                if (x.X < x.Y)
                {
                    if (x.X < x.Z)
                    {
                        x.X = 1.0f;
                        x.Y = 0.0f;
                        x.Z = 0.0f;
                    }
                    else
                    {
                        x.X = 0.0f;
                        x.Y = 0.0f;
                        x.Z = 1.0f;
                    }
                }
                else
                {
                    if (x.Y < x.Z)
                    {
                        x.X = 0.0f;
                        x.Y = 1.0f;
                        x.Z = 0.0f;
                    }
                    else
                    {
                        x.X = 0.0f;
                        x.Y = 0.0f;
                        x.Z = 1.0f;
                    }
                }

                u.X = x.X - from.X;
                u.Y = x.Y - from.Y;
                u.Z = x.Z - from.Z;

                v.X = x.X - to.X;
                v.Y = x.Y - to.Y;
                v.Z = x.Z - to.Z;

                float c1 = 2.0f / Vector3f.Dot(u, u);
                float c2 = 2.0f / Vector3f.Dot(v, v);
                float c3 = c1 * c2 * Vector3f.Dot(u, v);

                for (int i = 1; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        //This is somewhat unreadable, but the indices for u, v vectors are "zero-based" while
                        //matrix indices are "one-based" always subtract by one to index those
                        m[i, j] = -c1 * u[i - 1] * u[j - 1] - c2 * v[i - 1] * v[j - 1] + c3 * v[i - 1] * u[j - 1];
                    }
                    m[i, i] += 1.0f;
                }
            }
            else
            {
                //Most common case, unless "from" = "to" or "from" =- "to"
                Vector3f v = Vector3f.Cross(from, to);

                //Hand optimized version (9 mults less) by Gottfried Chen
                float h = 1.0f / (1.0f + e);
                float hvx = h * v.X;
                float hvz = h * v.Z;
                float hvxy = hvx * v.Y;
                float hvxz = hvx * v.Z;
                float hvyz = hvz * v.Y;

                m.M11 = e + hvx * v.X;
                m.M12 = hvxy - v.Z;
                m.M13 = hvxz + v.Y;

                m.M21 = hvxy + v.Z;
                m.M22 = e + h * v.Y * v.Y;
                m.M23 = hvyz - v.X;

                m.M31 = hvxz - v.Y;
                m.M32 = hvyz + v.X;
                m.M33 = e + hvz * v.Z;
            }

            return m;
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
            Matrix3f res;
            Multiply(ref m1, ref m2, out res);
            return res;
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
            return (obj is Matrix3f) && (Equals((Matrix3f) obj));
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
            string[] parts = value.Trim('[', ']').Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
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
            return new float[] {M11, M12, M13, M21, M22, M23, M31, M32, M33};
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
            return new Matrix2f(new Vector2f(M11, M12), new Vector2f(M21, M22));
        }

        #endregion

        #endregion
    }
}