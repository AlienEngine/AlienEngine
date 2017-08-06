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
    /// Represents a 4x4 matrix.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StructTypeConverter<Matrix4f>))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4f : IEquatable<Matrix4f>, ILoadFromString
    {
        #region Fields

        /// <summary>
        /// Top row of the matrix.
        /// </summary>
        public Vector4f Row0;

        /// <summary>
        /// Second row of the matrix.
        /// </summary>
        public Vector4f Row1;

        /// <summary>
        /// Thirth row of the matrix.
        /// </summary>
        public Vector4f Row2;

        /// <summary>
        /// Bottom row of the matrix.
        /// </summary>
        public Vector4f Row3;

        /// <summary>
        /// The identity matrix.
        /// </summary>
        public static readonly Matrix4f Identity = new Matrix4f(Vector4f.UnitX, Vector4f.UnitY, Vector4f.UnitZ, Vector4f.UnitW);

        /// <summary>
        /// The zero matrix.
        /// </summary>
        public static readonly Matrix4f Zero = new Matrix4f(Vector4f.Zero);

        /// <summary>
        /// The matrix which have his values populated with 1.
        /// </summary>
        public static readonly Matrix4f One = new Matrix4f(Vector4f.One);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public Matrix4f(float scale)
        {
            this = Identity * scale;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// The matrix is initialised with the <paramref name="rows"/> which represent an array of Vector2f.
        /// </summary>
        /// <param name="rows">The colums of the matrix.</param>
        public Matrix4f(Vector4f[] rows)
        {
            if (rows.Length < 4)
                throw new ArgumentException();

            Row0 = rows[0];
            Row1 = rows[1];
            Row2 = rows[2];
            Row3 = rows[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// </summary>
        /// <param name="row0">The first row of the matrix.</param>
        /// <param name="row1">The second row of the matrix.</param>
        public Matrix4f(Vector4f row0, Vector4f row1, Vector4f row2, Vector4f row3)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// </summary>
        /// <param name="a">The first row, first column value.</param>
        /// <param name="b">The first row, second column value.</param>
        /// <param name="c">The first row, third column value.</param>
        /// <param name="d">The first row, fourth column value.</param>
        /// <param name="e">The second row, first column value.</param>
        /// <param name="f">The second row, second column value.</param>
        /// <param name="g">The second row, third column value.</param>
        /// <param name="h">The second row, fourth column value.</param>
        /// <param name="i">The third row, first column value.</param>
        /// <param name="j">The third row, second column value.</param>
        /// <param name="k">The third row, third column value.</param>
        /// <param name="l">The third row, fourth column value.</param>
        /// <param name="m">The fourth row, first column value.</param>
        /// <param name="n">The fourth row, second column value.</param>
        /// <param name="o">The fourth row, third column value.</param>
        /// <param name="p">The fourth row, fourth column value.</param>
        public Matrix4f(
            float a, float b, float c, float d,
            float e, float f, float g, float h,
            float i, float j, float k, float l,
            float m, float n, float o, float p)
        {
            Row0 = new Vector4f(a, b, c, d);
            Row1 = new Vector4f(e, f, g, h);
            Row2 = new Vector4f(i, j, k, l);
            Row3 = new Vector4f(m, n, o, p);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// </summary>
        /// <param name="row">The value used to populate the matrix</param>
        public Matrix4f(Vector4f row)
        {
            Row0 = row;
            Row1 = row;
            Row2 = row;
            Row3 = row;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// </summary>
        /// <param name="a">The value used to populate the matrix</param>
        public Matrix4f(Matrix4f matrix)
        {
            Row0 = matrix.Row0;
            Row1 = matrix.Row1;
            Row2 = matrix.Row2;
            Row3 = matrix.Row3;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4f"/> struct.
        /// </summary>
        /// <param name="values">An array of values used to populate the matrix.</param>
        public Matrix4f(float[] values)
        {
            Row0 = new Vector4f(values[0],  values[1],  values[2],  values[3]);
            Row1 = new Vector4f(values[4],  values[5],  values[6],  values[7]);
            Row2 = new Vector4f(values[8],  values[9],  values[10], values[11]);
            Row3 = new Vector4f(values[12], values[13], values[14], values[15]);
        }

        #endregion

        #region Public Members

        #region Properties

        /// <summary>
        /// Gets the transposed matrix of this instance.
        /// </summary>
        public Matrix4f Transposed
        {
            get
            {
                return new Matrix4f(
                    new Vector4f(Row0.X, Row1.X, Row2.X, Row3.X),
                    new Vector4f(Row0.Y, Row1.Y, Row2.Y, Row3.Y),
                    new Vector4f(Row0.Z, Row1.Z, Row2.Z, Row3.Z),
                    new Vector4f(Row0.W, Row1.W, Row2.W, Row3.W)
                );
            }
        }

        /// <summary>
        /// Gets the determinant of this matrix.
        /// </summary>
        public float Determinant
        {
            get
            {
                Matrix3f det11 = new Matrix3f(M22, M23, M24, M32, M33, M34, M42, M43, M44);
                Matrix3f det12 = new Matrix3f(M21, M23, M24, M31, M33, M34, M41, M43, M44);
                Matrix3f det13 = new Matrix3f(M21, M22, M24, M31, M32, M34, M41, M42, M44);
                Matrix3f det14 = new Matrix3f(M21, M22, M23, M31, M32, M33, M41, M42, M43);

                return ((M11 * det11.Determinant) - (M12 * det12.Determinant) + (M13 * det13.Determinant) - (M14 * det14.Determinant));
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
        public Matrix4f Inversed
        {
            get
            {
                var _oneOverDeterminant = OneOverDeterminant;

                Matrix3f det11 = new Matrix3f(M22, M23, M24, M32, M33, M34, M42, M43, M44);
                Matrix3f det12 = new Matrix3f(M21, M23, M24, M31, M33, M34, M41, M43, M44);
                Matrix3f det13 = new Matrix3f(M21, M22, M24, M31, M32, M34, M41, M42, M44);
                Matrix3f det14 = new Matrix3f(M21, M22, M23, M31, M32, M33, M41, M42, M43);
                Matrix3f det21 = new Matrix3f(M12, M13, M14, M32, M33, M34, M42, M43, M44);
                Matrix3f det22 = new Matrix3f(M11, M13, M14, M31, M33, M34, M41, M43, M44);
                Matrix3f det23 = new Matrix3f(M11, M12, M14, M31, M32, M34, M41, M42, M44);
                Matrix3f det24 = new Matrix3f(M11, M12, M13, M31, M32, M33, M41, M42, M43);
                Matrix3f det31 = new Matrix3f(M12, M13, M14, M22, M23, M24, M42, M43, M44);
                Matrix3f det32 = new Matrix3f(M11, M13, M14, M21, M23, M24, M41, M43, M44);
                Matrix3f det33 = new Matrix3f(M11, M12, M14, M21, M22, M24, M41, M42, M44);
                Matrix3f det34 = new Matrix3f(M11, M12, M13, M21, M22, M23, M41, M42, M43);
                Matrix3f det41 = new Matrix3f(M12, M13, M14, M22, M23, M24, M32, M33, M34);
                Matrix3f det42 = new Matrix3f(M11, M13, M14, M21, M23, M24, M31, M33, M34);
                Matrix3f det43 = new Matrix3f(M11, M12, M14, M21, M22, M24, M31, M32, M34);
                Matrix3f det44 = new Matrix3f(M11, M12, M13, M21, M22, M23, M31, M32, M33);

                return new Matrix4f(
                    +det11.Determinant * _oneOverDeterminant,
                    -det12.Determinant * _oneOverDeterminant,
                    +det13.Determinant * _oneOverDeterminant,
                    -det14.Determinant * _oneOverDeterminant,
                    -det21.Determinant * _oneOverDeterminant,
                    +det22.Determinant * _oneOverDeterminant,
                    -det23.Determinant * _oneOverDeterminant,
                    +det24.Determinant * _oneOverDeterminant,
                    +det31.Determinant * _oneOverDeterminant,
                    -det32.Determinant * _oneOverDeterminant,
                    +det33.Determinant * _oneOverDeterminant,
                    -det34.Determinant * _oneOverDeterminant,
                    -det41.Determinant * _oneOverDeterminant,
                    +det42.Determinant * _oneOverDeterminant,
                    -det43.Determinant * _oneOverDeterminant,
                    +det44.Determinant * _oneOverDeterminant
                ).Transposed;
            }
        }

        /// <summary>
        /// Gets the first column of this matrix.
        /// </summary>
        public Vector4f Column0
        {
            get { return new Vector4f(Row0.X, Row1.X, Row2.X, Row3.X); }
            set
            {
                Row0.X = value.X;
                Row1.X = value.Y;
                Row2.X = value.Z;
                Row3.X = value.W;
            }
        }

        /// <summary>
        /// Gets the second column of this matrix.
        /// </summary>
        public Vector4f Column1
        {
            get { return new Vector4f(Row0.Y, Row1.Y, Row2.Y, Row3.Y); }
            set
            {
                Row0.Y = value.X;
                Row1.Y = value.Y;
                Row2.Y = value.Z;
                Row3.Y = value.W;
            }
        }

        /// <summary>
        /// Gets the third column of this matrix.
        /// </summary>
        public Vector4f Column2
        {
            get { return new Vector4f(Row0.Z, Row1.Z, Row2.Z, Row3.Z); }
            set
            {
                Row0.Z = value.X;
                Row1.Z = value.Y;
                Row2.Z = value.Z;
                Row3.Z = value.W;
            }
        }

        /// <summary>
        /// Gets the fourth column of this matrix.
        /// </summary>
        public Vector4f Column3
        {
            get { return new Vector4f(Row0.W, Row1.W, Row2.W, Row3.W); }
            set
            {
                Row0.W = value.X;
                Row1.W = value.Y;
                Row2.W = value.Z;
                Row3.W = value.W;
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
        public float M13 { get { return Row0.Z; } set { Row0.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 4 of this instance.
        /// </summary>
        public float M14 { get { return Row0.W; } set { Row0.W = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 1 of this instance.
        /// </summary>
        public float M21 { get { return Row1.X; } set { Row1.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 2 of this instance.
        /// </summary>
        public float M22 { get { return Row1.Y; } set { Row1.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 3 of this instance.
        /// </summary>
        public float M23 { get { return Row1.Z; } set { Row1.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 4 of this instance.
        /// </summary>
        public float M24 { get { return Row1.W; } set { Row1.W = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 1 of this instance.
        /// </summary>
        public float M31 { get { return Row2.X; } set { Row2.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 2 of this instance.
        /// </summary>
        public float M32 { get { return Row2.Y; } set { Row2.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 3 of this instance.
        /// </summary>
        public float M33 { get { return Row2.Z; } set { Row2.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 4 of this instance.
        /// </summary>
        public float M34 { get { return Row2.W; } set { Row2.W = value; } }

        /// <summary>
        /// Gets or sets the value at row 4, column 1 of this instance.
        /// </summary>
        public float M41 { get { return Row3.X; } set { Row3.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 4, column 2 of this instance.
        /// </summary>
        public float M42 { get { return Row3.Y; } set { Row3.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 4, column 3 of this instance.
        /// </summary>
        public float M43 { get { return Row3.Z; } set { Row3.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 4, column 4 of this instance.
        /// </summary>
        public float M44 { get { return Row3.W; } set { Row3.W = value; } }

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
        public Vector4f this[int row]
        {
            get
            {
                if (row == 0) { return Row0; }
                if (row == 1) { return Row1; }
                if (row == 2) { return Row2; }
                if (row == 3) { return Row3; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { Row0 = value; }
                else if (row == 1) { Row1 = value; }
                else if (row == 2) { Row2 = value; }
                else if (row == 3) { Row3 = value; }
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
                if (row == 3) { return Row3[column]; }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (row == 0) { Row0[column] = value; }
                else if (row == 1) { Row1[column] = value; }
                else if (row == 2) { Row2[column] = value; }
                else if (row == 3) { Row3[column] = value; }
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

        #region GetTranslate

        /// <summary>
        /// Gets translate factor in the specified.
        /// </summary>
        public Vector3f GetTranslate()
        {
            return new Vector3f(Row3.X, Row3.Y, Row3.Z);
        }

        #endregion

        #region GetScale

        /// <summary>
        /// Gets scale factor in the specified.
        /// </summary>
        public Vector3f GetScale()
        {
            return new Vector3f(Row0.Length, Row1.Length, Row2.Length);
        }

        #endregion

        #region GetRotation

        public Matrix4f GetRotationMatrix()
        {
            var ret = Identity;

            ret.Row0 = new Vector4f(Row0.XYZ, 0) / Row0.Length;
            ret.Row1 = new Vector4f(Row1.XYZ, 0) / Row1.Length;
            ret.Row2 = new Vector4f(Row2.XYZ, 0) / Row2.Length;

            return ret;
        }

        public Vector3f GetEulerAngles()
        {
            return GetRotationMatrix().ToEulerAngles();
        }

        #endregion

        #region Translate

        /// <summary>
        /// Applies a translation transformation this matrix by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="v">The vector to translate by.</param>
        public void Translate(Vector3f v)
        {
            this = CreateTranslation(v) * this;
        }

        /// <summary>
        /// Applies a translation transformation to this matrix.
        /// </summary>
        /// <param name="x">X axis.</param>
        /// <param name="y">Y axis.</param>
        /// <param name="z">Z axis.</param>
        public void Translate(float x, float y, float z)
        {
            Translate(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Applies a translation transformation to this matrix.
        /// </summary>
        /// <param name="factor">Single factor for X, Y, and Z axis.</param>
        public void Translate(float factor)
        {
            Translate(new Vector3f(factor));
        }

        #endregion

        #region Rotate

        /// <summary>
        /// Applies a rotation transformation to this matrix by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="angle">The angle in radians to use for rotation</param>
        /// <param name="v">The vector to rotate by.</param>
        public void Rotate(Vector3f v, float angle)
        {
            this = CreateFromAxisAngle(v, angle) * this;
        }

        /// <summary>
        /// Applies a rotation transformation to this matrix.
        /// </summary>
        /// <param name="angle">The angle in radians to use for rotation</param>
        /// <param name="x">X axis.</param>
        /// <param name="y">Y axis.</param>
        /// <param name="z">Z axis.</param>
        public void Rotate(float x, float y, float z, float angle)
        {
            Rotate(new Vector3f(x, y, z), angle);
        }

        /// <summary>
        /// Applies a rotation transformation to this matrix by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="angleX">X rotation.</param>
        /// <param name="angleY">Y rotation.</param>
        /// <param name="angleZ">Z rotation.</param>
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            this = CreateRotation(angleX, angleY, angleZ) * this;
        }

        #endregion

        #region Scale

        /// <summary>
        /// Applies a scale transformation to this matrix by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="v">The vector to scale by.</param>
        public void Scale(Vector3f v)
        {
            this = CreateScale(v) * this;
        }
            
        /// <summary>
        /// Applies a scale transformation to this matrix.
        /// </summary>
        /// <param name="x">X scale.</param>
        /// <param name="y">Y scale.</param>
        /// <param name="z">Z scale.</param>
        public void Scale(float x, float y, float z)
        {
            this = CreateScale(x, y, z) * this;
        }

        /// <summary>
        /// Applies a scale transformation to this matrix.
        /// </summary>
        /// <param name="scale">Scale factor for X, Y, and Z axis.</param>
        public void Scale(float scale)
        {
            this = CreateScale(scale) * this;
        }

        #endregion

        #region Static

        #region CreateFromAxisAngle

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        public static Matrix4f CreateFromAxisAngle(Vector3f axis, float angle)
        {
            Matrix4f result;
            CreateFromAxisAngle(axis, angle, out result);
            return result;
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        /// <param name="result">A <see cref="Matrix4f"/> instance.</param>
        public static void CreateFromAxisAngle(Vector3f axis, float angle, out Matrix4f result)
        {
            // normalize and create a local copy of the vector.
            axis.Normalize();
            float axisX = axis.X, axisY = axis.Y, axisZ = axis.Z;

            // calculate angles
            float cos = MathHelper.Cos(-angle);
            float sin = MathHelper.Sin(-angle);
            float t = 1.0f - cos;

            // do the conversion math once
            float tXX = t * axisX * axisX,
                  tXY = t * axisX * axisY,
                  tXZ = t * axisX * axisZ,
                  tYY = t * axisY * axisY,
                  tYZ = t * axisY * axisZ,
                  tZZ = t * axisZ * axisZ;

            float sinX = sin * axisX,
                  sinY = sin * axisY,
                  sinZ = sin * axisZ;

            result.Row0.X = tXX + cos;
            result.Row0.Y = tXY - sinZ;
            result.Row0.Z = tXZ + sinY;
            result.Row0.W = 0;

            result.Row1.X = tXY + sinZ;
            result.Row1.Y = tYY + cos;
            result.Row1.Z = tYZ - sinX;
            result.Row1.W = 0;

            result.Row2.X = tXZ - sinY;
            result.Row2.Y = tYZ + sinX;
            result.Row2.Z = tZZ + cos;
            result.Row2.W = 0;

            result.Row3 = Vector4f.UnitW;
        }

        #endregion

        #region CreateFromQuaternion

        /// <summary>
        /// Builds a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to rotate by.</param>
        /// <param name="result">A matrix instance.</param>
        public static void CreateFromQuaternion(ref Quaternion q, out Matrix4f result)
        {
            Vector3f axis;
            float angle;
            q.ToAxisAngle(out axis, out angle);
            CreateFromAxisAngle(axis, angle, out result);
        }

        /// <summary>
        /// Builds a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to rotate by.</param>
        /// <returns>A matrix instance.</returns>
        public static Matrix4f CreateFromQuaternion(Quaternion q)
        {
            Matrix4f result;
            CreateFromQuaternion(ref q, out result);
            return result;
        }

        #endregion

        #region CreateRotation[XYZ]

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="angleX">X rotation.</param>
        /// <param name="angleY">Y rotation.</param>
        /// <param name="angleZ">Z rotation.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotation(float angleX, float angleY, float angleZ, out Matrix4f result)
        {
            result = CreateRotation(angleX, angleY, angleZ);
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="vector">A vetor of counter-clockwise angles in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static Matrix4f CreateRotation(Vector3f vector)
        {
            return CreateRotation(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation.
        /// </summary>
        /// <param name="angleX">X rotation.</param>
        /// <param name="angleY">Y rotation.</param>
        /// <param name="angleZ">Z rotation.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateRotation(float angleX, float angleY, float angleZ)
        {
            Matrix4f rXY = CreateRotationZ(angleZ);
            Matrix4f rXZ = CreateRotationY(angleY);
            Matrix4f rYZ = CreateRotationX(angleX);

            return (rYZ * rXZ) * rXY;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationX(float angle, out Matrix4f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.Row1.Y = +cos;
            result.Row1.Z = +sin;
            result.Row2.Y = -sin;
            result.Row2.Z = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateRotationX(float angle)
        {
            Matrix4f result;
            CreateRotationX(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationY(float angle, out Matrix4f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.Row0.X = +cos;
            result.Row0.Z = -sin;
            result.Row2.X = +sin;
            result.Row2.Z = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateRotationY(float angle)
        {
            Matrix4f result;
            CreateRotationY(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateRotationZ(float angle, out Matrix4f result)
        {
            float cos = MathHelper.Cos(angle);
            float sin = MathHelper.Sin(angle);

            result = Identity;
            result.Row0.X = +cos;
            result.Row0.Y = +sin;
            result.Row1.X = -sin;
            result.Row1.Y = +cos;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateRotationZ(float angle)
        {
            Matrix4f result;
            CreateRotationZ(angle, out result);
            return result;
        }

        #endregion

        #region CreateTranslation

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="x">X translation.</param>
        /// <param name="y">Y translation.</param>
        /// <param name="z">Z translation.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateTranslation(float x, float y, float z, out Matrix4f result)
        {
            result = Identity;
            result.Row3 = new Vector4f(x, y, z, 1.0f);
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="vector">The translation vector.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateTranslation(ref Vector3f vector, out Matrix4f result)
        {
            CreateTranslation(vector.X, vector.Y, vector.Z, out result);
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="x">X translation.</param>
        /// <param name="y">Y translation.</param>
        /// <param name="z">Z translation.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateTranslation(float x, float y, float z)
        {
            Matrix4f result;
            CreateTranslation(x, y, z, out result);
            return result;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="vector">The translation vector.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateTranslation(Vector3f vector)
        {
            Matrix4f result;
            CreateTranslation(ref vector, out result);
            return result;
        }

        #endregion

        #region CreateScale

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
        /// <returns>A scale matrix.</returns>
        public static Matrix4f CreateScale(float scale)
        {
            Matrix4f result;
            CreateScale(scale, out result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Scale factors for the x, y, and z axes.</param>
        /// <returns>A scale matrix.</returns>
        public static Matrix4f CreateScale(Vector3f scale)
        {
            Matrix4f result;
            CreateScale(ref scale, out result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="x">Scale factor for the x axis.</param>
        /// <param name="y">Scale factor for the y axis.</param>
        /// <param name="z">Scale factor for the z axis.</param>
        /// <returns>A scale matrix.</returns>
        public static Matrix4f CreateScale(float x, float y, float z)
        {
            Matrix4f result;
            CreateScale(x, y, z, out result);
            return result;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(float scale, out Matrix4f result)
        {
            result = Identity;
            result.Row0.X = scale;
            result.Row1.Y = scale;
            result.Row2.Z = scale;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="scale">Scale factors for the x, y, and z axes.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(ref Vector3f scale, out Matrix4f result)
        {
            result = Identity;
            result.Row0.X = scale.X;
            result.Row1.Y = scale.Y;
            result.Row2.Z = scale.Z;
        }

        /// <summary>
        /// Creates a scale matrix.
        /// </summary>
        /// <param name="x">Scale factor for the x axis.</param>
        /// <param name="y">Scale factor for the y axis.</param>
        /// <param name="z">Scale factor for the z axis.</param>
        /// <param name="result">A scale matrix.</param>
        public static void CreateScale(float x, float y, float z, out Matrix4f result)
        {
            result = Identity;
            result.Row0.X = x;
            result.Row1.Y = y;
            result.Row2.Z = z;
        }

        #endregion

        #region CreateOrthographic

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="width">The width of the projection volume.</param>
        /// <param name="height">The height of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateOrthographic(float width, float height, float zNear, float zFar, out Matrix4f result)
        {
            CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, zNear, zFar, out result);
        }

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="width">The width of the projection volume.</param>
        /// <param name="height">The height of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        /// <rereturns>The resulting Matrix4f instance.</rereturns>
        public static Matrix4f CreateOrthographic(float width, float height, float zNear, float zFar)
        {
            Matrix4f result;
            CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, zNear, zFar, out result);
            return result;
        }

        #endregion

        #region CreateOrthographicOffCenter

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="left">The left edge of the projection volume.</param>
        /// <param name="right">The right edge of the projection volume.</param>
        /// <param name="bottom">The bottom edge of the projection volume.</param>
        /// <param name="top">The top edge of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        /// <param name="result">The resulting Matrix4f instance.</param>
        public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4f result)
        {
            result = Identity;

            float invRL = 1.0f / (right - left);
            float invTB = 1.0f / (top - bottom);
            float invFN = 1.0f / (zFar - zNear);

            result.Row0.X = 2 * invRL;
            result.Row1.Y = 2 * invTB;
            result.Row2.Z = -2 * invFN;

            result.Row3.X = -(right + left) * invRL;
            result.Row3.Y = -(top + bottom) * invTB;
            result.Row3.Z = -(zFar + zNear) * invFN;
        }

        /// <summary>
        /// Creates an orthographic projection matrix.
        /// </summary>
        /// <param name="left">The left edge of the projection volume.</param>
        /// <param name="right">The right edge of the projection volume.</param>
        /// <param name="bottom">The bottom edge of the projection volume.</param>
        /// <param name="top">The top edge of the projection volume.</param>
        /// <param name="zNear">The near edge of the projection volume.</param>
        /// <param name="zFar">The far edge of the projection volume.</param>
        /// <returns>The resulting Matrix4f instance.</returns>
        public static Matrix4f CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            Matrix4f result;
            CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar, out result);
            return result;
        }

        #endregion

        #region CreatePerspectiveFieldOfView

        /// <summary>
        /// Creates a perspective projection matrix.
        /// </summary>
        /// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
        /// <param name="aspect">Aspect ratio of the view (width / height)</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <param name="result">A projection matrix that transforms camera space to raster space</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>fovy is zero, less than zero or larger than <see cref="MathHelper.Pi"/> </item>
        /// <item>aspect is negative or zero</item>
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
        /// </list>
        /// </exception>
        public static void CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar, out Matrix4f result)
        {
            if (fovy <= 0 || fovy > MathHelper.Pi)
                throw new ArgumentOutOfRangeException("fovy");

            if (aspect <= 0)
                throw new ArgumentOutOfRangeException("aspect");

            if (zNear <= 0)
                throw new ArgumentOutOfRangeException("zNear");

            if (zFar <= 0)
                throw new ArgumentOutOfRangeException("zFar");

            float yMax = zNear * MathHelper.Tan(0.5f * fovy);
            float yMin = -yMax;
            float xMin = yMin * aspect;
            float xMax = yMax * aspect;

            CreatePerspectiveOffCenter(xMin, xMax, yMin, yMax, zNear, zFar, out result);
        }

        /// <summary>
        /// Creates a perspective projection matrix.
        /// </summary>
        /// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
        /// <param name="aspect">Aspect ratio of the view (width / height)</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <returns>A projection matrix that transforms camera space to raster space</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>fovy is zero, less than zero or larger than <see cref="MathHelper.Pi"/></item>
        /// <item>aspect is negative or zero</item>
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
        /// </list>
        /// </exception>
        public static Matrix4f CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar)
        {
            Matrix4f result;
            CreatePerspectiveFieldOfView(fovy, aspect, zNear, zFar, out result);
            return result;
        }

        #endregion

        #region CreatePerspectiveOffCenter

        /// <summary>
        /// Creates an perspective projection matrix.
        /// </summary>
        /// <param name="left">Left edge of the view frustum</param>
        /// <param name="right">Right edge of the view frustum</param>
        /// <param name="bottom">Bottom edge of the view frustum</param>
        /// <param name="top">Top edge of the view frustum</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <param name="result">A projection matrix that transforms camera space to raster space</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
        /// </list>
        /// </exception>
        public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4f result)
        {
            if (zNear <= 0)
                throw new ArgumentOutOfRangeException("zNear");

            if (zFar <= 0)
                throw new ArgumentOutOfRangeException("zFar");

            if (zNear >= zFar)
                throw new ArgumentOutOfRangeException("zNear");

            float x = (2.0f * zNear) / (right - left);
            float y = (2.0f * zNear) / (top - bottom);
            float a = (right + left) / (right - left);
            float b = (top + bottom) / (top - bottom);
            float c = -(zFar + zNear) / (zFar - zNear);
            float d = -(2.0f * zFar * zNear) / (zFar - zNear);

            result = Identity;
            result.Row0 = new Vector4f(x,  0,  0,  0);
            result.Row1 = new Vector4f(0,  y,  0,  0);
            result.Row2 = new Vector4f(a,  b,  c, -1);
            result.Row3 = new Vector4f(0,  0,  d,  0);
        }

        /// <summary>
        /// Creates an perspective projection matrix.
        /// </summary>
        /// <param name="left">Left edge of the view frustum</param>
        /// <param name="right">Right edge of the view frustum</param>
        /// <param name="bottom">Bottom edge of the view frustum</param>
        /// <param name="top">Top edge of the view frustum</param>
        /// <param name="zNear">Distance to the near clip plane</param>
        /// <param name="zFar">Distance to the far clip plane</param>
        /// <returns>A projection matrix that transforms camera space to raster space</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown under the following conditions:
        /// <list type="bullet">
        /// <item>zNear is negative or zero</item>
        /// <item>zFar is negative or zero</item>
        /// <item>zNear is larger than zFar</item>
        /// </list>
        /// </exception>
        public static Matrix4f CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            Matrix4f result;
            CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar, out result);
            return result;
        }

        #endregion

        #region Frustum

        /// <summary>
        /// Creates a frustum projection matrix.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="nearVal">The near val.</param>
        /// <param name="farVal">The far val.</param>
        /// <returns></returns>
        public static void Frustum(float left, float right, float bottom, float top, float nearVal, float farVal, out Matrix4f result)
        {
            result = Identity;

            result.M11 = (2.0f * nearVal) / (right - left);
            result.M13 = (right + left) / (right - left);
            result.M22 = (2.0f * nearVal) / (top - bottom);
            result.M23 = (top + bottom) / (top - bottom);
            result.M33 = -(farVal + nearVal) / (farVal - nearVal);
            result.M34 = -(2.0f * farVal * nearVal) / (farVal - nearVal);
            result.M43 = -1.0f;
            result.M44 = 0.0f;
        }

        /// <summary>
        /// Creates a frustum projection matrix.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="nearVal">The near val.</param>
        /// <param name="farVal">The far val.</param>
        /// <returns></returns>
        public static Matrix4f Frustum(float left, float right, float bottom, float top, float nearVal, float farVal)
        {
            var result = Identity;
            Frustum(left, right, bottom, top, nearVal, farVal, out result);
            return result;
        }

        #endregion

        #region InfinitePerspective

        /// <summary>
        /// Creates a matrix for a symmetric perspective-view frustum with far plane at infinite.
        /// </summary>
        /// <param name="fovy">The fovy.</param>
        /// <param name="aspect">The aspect.</param>
        /// <param name="zNear">The z near.</param>
        /// <returns></returns>
        public static void InfinitePerspective(float fovy, float aspect, float zNear, out Matrix4f result)
        {
            float range = MathHelper.Tan(fovy / (2f)) * zNear;

            float left = -range * aspect;
            float right = range * aspect;
            float bottom = -range;
            float top = range;

            result = Zero;
            result.M11 = ((2f) * zNear) / (right - left);
            result.M22 = ((2f) * zNear) / (top - bottom);
            result.M33 = -(1f);
            result.M34 = -(2f) * zNear;
            result.M43 = -(1f);
        }

        /// <summary>
        /// Creates a matrix for a symmetric perspective-view frustum with far plane at infinite.
        /// </summary>
        /// <param name="fovy">The fovy.</param>
        /// <param name="aspect">The aspect.</param>
        /// <param name="zNear">The z near.</param>
        /// <returns></returns>
        public static Matrix4f InfinitePerspective(float fovy, float aspect, float zNear)
        {
            var result = Zero;
            InfinitePerspective(fovy, aspect, zNear, out result);
            return result;
        }

        #endregion

        #region PickMatrix

        /// <summary>
        /// Define a picking region.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static Matrix4f PickMatrix(Vector2f center, Vector2f delta, Vector4f viewport)
        {
            if (delta.X <= 0 || delta.Y <= 0)
                throw new ArgumentOutOfRangeException();

            var result = new Matrix4f(1.0f);

            if (!(delta.X > (0f) && delta.Y > (0f)))
                return result; // Error

            Vector3f temp = new Vector3f(
                ((viewport[2]) - (2f) * (center.X - (viewport[0]))) / delta.X,
                ((viewport[3]) - (2f) * (center.Y - (viewport[1]))) / delta.Y,
                (0f));

            // Translate and scale the picked region to the entire window
            result.Translate(temp);
            result.Scale(new Vector3f((viewport[2]) / delta.X, (viewport[3]) / delta.Y, (1)));

            return result;
        }

        #endregion

        #region Camera Helper Functions

        /// <summary>
        /// Build a world space to camera space matrix
        /// </summary>
        /// <param name="eye">Eye (camera) position in world space</param>
        /// <param name="target">Target position in world space</param>
        /// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <returns>A Matrix4f that transforms world space to camera space</returns>
        public static Matrix4f LookAt(Point3f eye, Point3f target, Vector3f up)
        {
            Vector3f z = Vector3f.Normalize(Point3f.CreateVector(target, eye));
            Vector3f x = Vector3f.Normalize(Vector3f.Cross(up, z));
            Vector3f y = Vector3f.Normalize(Vector3f.Cross(z, x));

            Matrix4f result = Zero;

            result.Row0.X = x.X;
            result.Row0.Y = y.X;
            result.Row0.Z = z.X;
            result.Row0.W = 0;
            result.Row1.X = x.Y;
            result.Row1.Y = y.Y;
            result.Row1.Z = z.Y;
            result.Row1.W = 0;
            result.Row2.X = x.Z;
            result.Row2.Y = y.Z;
            result.Row2.Z = z.Z;
            result.Row2.W = 0;
            result.Row3.X = -((x.X * eye.X) + (x.Y * eye.Y) + (x.Z * eye.Z));
            result.Row3.Y = -((y.X * eye.X) + (y.Y * eye.Y) + (y.Z * eye.Z));
            result.Row3.Z = -((z.X * eye.X) + (z.Y * eye.Y) + (z.Z * eye.Z));
            result.Row3.W = 1;

            return result;
        }

        /// <summary>
        /// Build a world space to camera space matrix
        /// </summary>
        /// <param name="eyeX">Eye (camera) position in world space</param>
        /// <param name="eyeY">Eye (camera) position in world space</param>
        /// <param name="eyeZ">Eye (camera) position in world space</param>
        /// <param name="targetX">Target position in world space</param>
        /// <param name="targetY">Target position in world space</param>
        /// <param name="targetZ">Target position in world space</param>
        /// <param name="upX">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <param name="upY">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <param name="upZ">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <returns>A Matrix4f that transforms world space to camera space</returns>
        public static Matrix4f LookAt(float eyeX, float eyeY, float eyeZ, float targetX, float targetY, float targetZ, float upX, float upY, float upZ)
        {
            return LookAt(new Point3f(eyeX, eyeY, eyeZ), new Point3f(targetX, targetY, targetZ), new Vector3f(upX, upY, upZ));
        }

        /// <summary>
        /// Build a world space to camera space matrix
        /// </summary>
        /// <param name="forward">Eye (camera) forward vector in world space</param>
        /// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <returns>A Matrix4f that transforms world space to camera space</returns>
        public static Matrix4f LookAt(Vector3f forward, Vector3f up)
        {
            Matrix4f result = Identity;

            Vector3f f = forward;
            f.Normalize();

            Vector3f r = up;
            r = Vector3f.Cross(r, f);
            r.Normalize();

            Vector3f u = Vector3f.Cross(f, r);

            result.Column0 = new Vector4f(r, 0.0f);
            result.Column1 = new Vector4f(u, 0.0f);
            result.Column2 = new Vector4f(f, 0.0f);
            result.Column3 = Vector4f.UnitW;

            return result;
        }

        /// <summary>
        /// Build a world space to camera space matrix
        /// </summary>
        /// <param name="eyeX">Eye (camera) position in world space</param>
        /// <param name="eyeY">Eye (camera) position in world space</param>
        /// <param name="eyeZ">Eye (camera) position in world space</param>
        /// <param name="upX">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <param name="upY">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <param name="upZ">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
        /// <returns>A Matrix4f that transforms world space to camera space</returns>
        public static Matrix4f LookAt(float eyeX, float eyeY, float eyeZ, float upX, float upY, float upZ)
        {
            return LookAt(new Vector3f(eyeX, eyeY, eyeZ), new Vector3f(upX, upY, upZ));
        }

        #endregion

        #region Multiply Functions

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <returns>A new instance that is the result of the multiplication.</returns>
        public static Matrix4f Multiply(Matrix4f left, Matrix4f right)
        {
            Matrix4f result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <param name="result">A new instance that is the result of the multiplication.</param>
        public static void Multiply(ref Matrix4f left, ref Matrix4f right, out Matrix4f result)
        {
            result.Row0.X = Vector4f.Dot(left.Row0, right.Column0);
            result.Row0.Y = Vector4f.Dot(left.Row0, right.Column1);
            result.Row0.Z = Vector4f.Dot(left.Row0, right.Column2);
            result.Row0.W = Vector4f.Dot(left.Row0, right.Column3);

            result.Row1.X = Vector4f.Dot(left.Row1, right.Column0);
            result.Row1.Y = Vector4f.Dot(left.Row1, right.Column1);
            result.Row1.Z = Vector4f.Dot(left.Row1, right.Column2);
            result.Row1.W = Vector4f.Dot(left.Row1, right.Column3);

            result.Row2.X = Vector4f.Dot(left.Row2, right.Column0);
            result.Row2.Y = Vector4f.Dot(left.Row2, right.Column1);
            result.Row2.Z = Vector4f.Dot(left.Row2, right.Column2);
            result.Row2.W = Vector4f.Dot(left.Row2, right.Column3);

            result.Row3.X = Vector4f.Dot(left.Row3, right.Column0);
            result.Row3.Y = Vector4f.Dot(left.Row3, right.Column1);
            result.Row3.Z = Vector4f.Dot(left.Row3, right.Column2);
            result.Row3.W = Vector4f.Dot(left.Row3, right.Column3);
        }

        /// <summary>
        /// Multiply the specified left and right where left is a Vector4f should only be used for debuging
        /// and seeing if the point you are tryng to draw is in screen space
        /// </summary>
        /// <param name='left'>Left.</param>
        /// <param name='right'>Right.</param>
        public static Vector4f Multiply(Vector4f left, Matrix4f right)
        {
            return new Vector4f(left.X * right.M11 + left.Y * right.M21 + left.Z * right.M31 + left.W * right.M41,
                                left.X * right.M12 + left.Y * right.M22 + left.Z * right.M32 + left.W * right.M42,
                                left.X * right.M13 + left.Y * right.M23 + left.Z * right.M33 + left.W * right.M43,
                                left.X * right.M14 + left.Y * right.M24 + left.Z * right.M34 + left.W * right.M44);
        }

        public static Vector4f operator *(Vector4f left, Matrix4f right)
        {
            return Multiply(left, right);
        }

        /// <summary>
        /// Multiply a <see cref="Matrix4f"/> with a <see cref="float"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Matrix4f operator *(Matrix4f matrix, float scale)
        {
            return new Matrix4f(matrix[0] * scale, matrix[1] * scale, matrix[2] * scale, matrix[3] * scale);
        }

        #endregion

        #region Transpose

        /// <summary>
        /// Gets the transposed matrix.
        /// </summary>
        /// <param name="m">The matrix to transpose.</param>
        /// <returns>The transposed matrix.</returns>
        public static Matrix4f Transpose(Matrix4f m)
        {
            return m.Transposed;
        }

        #endregion

        #region Inverse

        /// <summary>
        /// Gets the inversed matrix.
        /// </summary>
        /// <param name="m">The matrix to inverse.</param>
        /// <returns>The inversed matrix.</returns>
        public static Matrix4f Inverse(Matrix4f m)
        {
            return m.Inversed;
        }

        #endregion

        #endregion

        #region Operators

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix4f which holds the result of the multiplication</returns>
        public static Matrix4f operator *(Matrix4f left, Matrix4f right)
        {
            return Matrix4f.Multiply(left, right);
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Matrix4f left, Matrix4f right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        public static bool operator !=(Matrix4f left, Matrix4f right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Compare this instance with a <see cref="System.Object"/> for equality.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>true if equals and false otherwise</returns>
        public override bool Equals(object obj)
        {
            return (obj is Matrix4f) && (this.Equals((Matrix4f)obj));
        }

        /// <summary>
        /// Compare this instance with another <see cref="Matrix4f"/> for equality.
        /// </summary>
        /// <param name="other">the <see cref="Matrix4f"/> to compare with this instance.</param>
        /// <returns>true if equals and false otherwise</returns>
        public bool Equals(Matrix4f other)
        {
            return
                Row0 == other.Row0 &&
                Row1 == other.Row1 &&
                Row2 == other.Row2 &&
                Row3 == other.Row3;
        }

        /// <summary>
        /// Returns the hashcode for this instance.
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
            Row0 = Vector4f.Parse(parts[0]);
            Row1 = Vector4f.Parse(parts[1]);
            Row2 = Vector4f.Parse(parts[2]);
            Row3 = Vector4f.Parse(parts[3]);
        }

        /// <summary>
        /// Returns the <see cref="Matrix3f"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="Matrix3f"/> portion of this matrix.</returns>
        public Matrix3f ToMatrix3f()
        {
            return new Matrix3f(new Vector3f(Row0), new Vector3f(Row1), new Vector3f(Row2));
        }

        /// <summary>
        /// Gets Euler angles from this <see cref="Matrix4f"/> (supposed to be a rotation matrix).
        /// </summary>
        public Vector3f ToEulerAngles()
        {
            Vector3f ret = Vector3f.Zero;

            // If cos(angle_y) is null
            if (M11 == 0 && M12 == 0 && M23 == 0 && M33 == 0)
            {
                ret.Z = 0;
                ret.Y = MathHelper.PiOver2;
                ret.X = MathHelper.Atan(M21, M22);
            }
            else
            {
                ret.Z = MathHelper.Atan(M12, M11);
                ret.Y = MathHelper.Atan(-M13, MathHelper.Sqrt(M11 * M11 + M12 * M12));
                ret.X = MathHelper.Atan(M23, M33);
            }

            return ret;
        }

        /// <summary>
        /// Transform this matrix to a <see cref="Quaternion"/>.
        /// </summary>
        /// <returns></returns>
        public Quaternion ToQuaternion()
        {
            float x = 0, y = 0, z = 0, w = 0;

            // detect biggest in w, x, y, z.
            float fourWSquaredMinus1 = +M11 + M22 + M33;
            float fourXSquaredMinus1 = +M11 - M22 - M33;
            float fourYSquaredMinus1 = -M11 + M22 - M33;
            float fourZSquaredMinus1 = -M11 - M22 + M33;

            int biggestIndex = 0;

            float biggest = fourWSquaredMinus1;

            if (fourXSquaredMinus1 > biggest)
            {
                biggest = fourXSquaredMinus1;
                biggestIndex = 1;
            }
            if (fourYSquaredMinus1 > biggest)
            {
                biggest = fourYSquaredMinus1;
                biggestIndex = 2;
            }
            if (fourZSquaredMinus1 > biggest)
            {
                biggest = fourZSquaredMinus1;
                biggestIndex = 3;
            }

            // sqrt and division
            float biggestVal = MathHelper.Sqrt(biggest + 1) * 0.5f;
            float mult = 0.25f / biggestVal;

            // get output
            switch (biggestIndex)
            {
                case 0:
                    w = biggestVal;
                    x = (M23 - M32) * mult;
                    y = (M31 - M13) * mult;
                    z = (M12 - M21) * mult;
                    break;

                case 1:
                    x = biggestVal;
                    w = (M23 - M32) * mult;
                    y = (M12 + M21) * mult;
                    z = (M31 + M13) * mult;
                    break;

                case 2:
                    y = biggestVal;
                    w = (M31 - M13) * mult;
                    x = (M12 + M21) * mult;
                    z = (M23 + M32) * mult;
                    break;

                case 3:
                    z = biggestVal;
                    w = (M12 - M21) * mult;
                    x = (M31 + M13) * mult;
                    y = (M23 + M32) * mult;
                    break;

                default:
                    break;
            }

            if (x == 0.0f && y == 0.0f && z == 0.0f)
                return new Quaternion(1, 1, 1, 1);
            else
                return new Quaternion(w, -x, -y, -z);
        }

        /// <summary>
        /// Returns the matrix as an array of floats, column major.
        /// </summary>
        public float[] ToArray()
        {
            return new float[] { M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44 };
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3}]", Row0, Row1, Row2, Row3);
        }

        #endregion

        #endregion
    }
}