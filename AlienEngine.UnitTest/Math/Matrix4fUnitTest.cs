using System;
using NUnit.Framework;

namespace AlienEngine.UnitTest.Math
{
    [TestFixture]
    public class Matrix4fUnitTest
    {
        [Test]
        public void ConstructMatrix4fFromScaleTest()
        {
            Matrix4f scaleMatrixResult1 = new Matrix4f(4);
            Matrix4f scaleMatrixResult2 = new Matrix4f { M11 = 4, M22 = 4, M33 = 4, M44 = 4};

            Assert.AreEqual(scaleMatrixResult1, scaleMatrixResult2);
        }

        [Test]
        public void ConstructMatrix4fFromRowsTest()
        {
            // Rows
            Vector4f row1 = new Vector4f { X = 1, Y = 1, Z = 1, W = 1 };
            Vector4f row2 = new Vector4f { X = 2, Y = 2, Z = 2, W = 2 };
            Vector4f row3 = new Vector4f { X = 3, Y = 3, Z = 3, W = 3 };
            Vector4f row4 = new Vector4f { X = 4, Y = 4, Z = 4, W = 4 };

            Matrix4f matrixResult1 = new Matrix4f(row1, row2, row3, row4);
            Matrix4f matrixResult2 = new Matrix4f
            {
                M11 = row1.X, M12 = row1.Y, M13 = row1.Z, M14 = row1.W,
                M21 = row2.X, M22 = row2.Y, M23 = row2.Z, M24 = row2.W,
                M31 = row3.X, M32 = row3.Y, M33 = row3.Z, M34 = row3.W,
                M41 = row4.X, M42 = row4.Y, M43 = row4.Z, M44 = row4.W,
            };

            Assert.AreEqual(matrixResult1, matrixResult2);
        }

        [Test]
        public void ConstructMatrix4fFromArrayOfRowsTest()
        {
            // Row
            Vector4f row = new Vector4f { X = 1, Y = 1, Z = 1, W = 1 };

            for (int i = 1; i < 5; i++)
            {
                Vector4f[] rows = new Vector4f[i];
                for (int j = 0; j < i; j++)
                    rows[j] = row;

                if (rows.Length < 4)
                    Assert.Throws<ArgumentException>(() => new Matrix4f(rows));
                else
                    Assert.AreEqual(Matrix4f.One, new Matrix4f(rows));
            }
        }

        [Test]
        public void ConstructMatrix4fFromValuesTest()
        {
            Matrix4f matrixResult1 = new Matrix4f(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            Matrix4f matrixResult2 = new Matrix4f
            {
                M11 = 0,
                M12 = 1,
                M13 = 2,
                M14 = 3,
                M21 = 4,
                M22 = 5,
                M23 = 6,
                M24 = 7,
                M31 = 8,
                M32 = 9,
                M33 = 10,
                M34 = 11,
                M41 = 12,
                M42 = 13,
                M43 = 14,
                M44 = 15
            };

            Assert.AreEqual(matrixResult1, matrixResult2);
        }

        [Test]
        public void ConstructMatrix4fFromRowTest()
        {
            Vector4f row = new Vector4f { X = 1, Y = 1, Z = 1, W = 1 };

            Matrix4f matrixResult1 = new Matrix4f(row);
            Matrix4f matrixResult2 = new Matrix4f
            {
                M11 = 1,
                M12 = 1,
                M13 = 1,
                M14 = 1,
                M21 = 1,
                M22 = 1,
                M23 = 1,
                M24 = 1,
                M31 = 1,
                M32 = 1,
                M33 = 1,
                M34 = 1,
                M41 = 1,
                M42 = 1,
                M43 = 1,
                M44 = 1
            };

            Assert.AreEqual(matrixResult1, matrixResult2);
        }

        [Test]
        public void ConstructMatrix4fFromMatrix4fTest()
        {
            Matrix4f matrixResult1 = new Matrix4f
            {
                M11 = 0,
                M12 = 1,
                M13 = 2,
                M14 = 3,
                M21 = 4,
                M22 = 5,
                M23 = 6,
                M24 = 7,
                M31 = 8,
                M32 = 9,
                M33 = 10,
                M34 = 11,
                M41 = 12,
                M42 = 13,
                M43 = 14,
                M44 = 15
            };
            Matrix4f matrixResult2 = new Matrix4f(matrixResult1);

            Assert.AreEqual(matrixResult1, matrixResult2);
        }

        [Test]
        public void ConstructMatrix4fFromArrayOfValuesTest()
        {
            // Value
            float value = 1;

            for (int i = 1; i < 17; i++)
            {
                float[] values = new float[i];
                for (int j = 0; j < i; j++)
                    values[j] = value;

                if (values.Length < 16)
                    Assert.Throws<ArgumentException>(() => new Matrix4f(values));
                else
                    Assert.AreEqual(Matrix4f.One, new Matrix4f(values));
            }
        }

        [Test]
        public void IdentityMatrix4fTest()
        {
            Matrix4f identity = new Matrix4f { M11 = 1, M22 = 1, M33 = 1, M44 = 1 };

            Assert.AreEqual(identity, Matrix4f.Identity);
        }

        [Test]
        public void BackwardPropertyTest()
        {
            Vector3f backward = new Vector3f { X = 0, Y = 0, Z = 1 };
            Assert.AreEqual(Matrix4f.Identity.Backward, backward);

            Matrix4f matrix = new Matrix4f();
            matrix.Backward = backward;
            Assert.AreEqual(backward, matrix.Backward);
        }

        [Test]
        public void DownPropertyTest()
        {
            Vector3f down = new Vector3f { X = 0, Y = -1, Z = 0 };
            Assert.AreEqual(down, Matrix4f.Identity.Down);

            Matrix4f matrix = new Matrix4f();
            matrix.Down = down;
            Assert.AreEqual(down, matrix.Down);
        }

        [Test]
        public void ForwardPropertyTest()
        {
            Vector3f forward = new Vector3f { X = 0, Y = 0, Z = -1 };
            Assert.AreEqual(forward, Matrix4f.Identity.Forward);

            Matrix4f matrix = new Matrix4f();
            matrix.Forward = forward;
            Assert.AreEqual(forward, matrix.Forward);
        }

        [Test]
        public void LeftPropertyTest()
        {
            Vector3f left = new Vector3f { X = -1, Y = 0, Z = 0 };
            Assert.AreEqual(left, Matrix4f.Identity.Left);

            Matrix4f matrix = new Matrix4f();
            matrix.Left = left;
            Assert.AreEqual(left, matrix.Left);
        }

        [Test]
        public void RightPropertyTest()
        {
            Vector3f right = new Vector3f { X = 1, Y = 0, Z = 0 };
            Assert.AreEqual(right, Matrix4f.Identity.Right);

            Matrix4f matrix = new Matrix4f();
            matrix.Right = right;
            Assert.AreEqual(right, matrix.Right);
        }

        [Test]
        public void UpPropertyTest()
        {
            Vector3f up = new Vector3f { X = 0, Y = 1, Z = 0 };
            Assert.AreEqual(up, Matrix4f.Identity.Up);

            Matrix4f matrix = new Matrix4f();
            matrix.Up = up;
            Assert.AreEqual(up, matrix.Up);
        }

        [Test]
        public void TransposedPropertyTest()
        {
            Matrix4f matrix = new Matrix4f
            {
                M11 = 1,
                M12 = 1,
                M13 = 1,
                M14 = 1,
                M21 = 2,
                M22 = 2,
                M23 = 2,
                M24 = 2,
                M31 = 3,
                M32 = 3,
                M33 = 3,
                M34 = 3,
                M41 = 4,
                M42 = 4,
                M43 = 4,
                M44 = 4
            };

            Matrix4f transpose = new Matrix4f
            {
                M11 = 1,
                M21 = 1,
                M31 = 1,
                M41 = 1,
                M12 = 2,
                M22 = 2,
                M32 = 2,
                M42 = 2,
                M13 = 3,
                M23 = 3,
                M33 = 3,
                M43 = 3,
                M14 = 4,
                M24 = 4,
                M34 = 4,
                M44 = 4
            };

            Assert.AreEqual(transpose, matrix.Transposed);
            Assert.AreEqual(matrix, transpose.Transposed);
        }

        [Test]
        public void DeterminantPropertyTest()
        {
            Assert.AreEqual(1.0f, Matrix4f.Identity.Determinant);
        }

        [Test]
        public void OneOverDeterminantPropertyTest()
        {
            Assert.AreEqual(1.0f, Matrix4f.Identity.OneOverDeterminant);
        }

        [Test]
        public void IsInversiblePropertyTest()
        {
            Assert.IsTrue(Matrix4f.Identity.IsInversible);
            Assert.IsFalse(Matrix4f.Zero.IsInversible);
        }

        [Test]
        public void InversedPropertyTest()
        {
            Assert.AreEqual(Matrix4f.Identity, Matrix4f.Identity.Inversed);

            Matrix4f invertible = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Matrix4f inversed = new Matrix4f(-60f/103f, -66f/103f, 177f/412f, 259f/412f, 71f/103f, 109f/103f, -97f/206f, -185f/206f, -4f/103f, -25f/103f, 53f/412f, 31f/412f, 3f/103f, -7f/103f, -7f/206f, 27f/206f);

            Matrix4f computed = invertible.Inversed;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Compare with low tolerance value
                    Assert.IsTrue(System.Math.Abs(inversed[i, j] - computed[i, j]) < MathHelper.Epsilon);
                }
            }

            Matrix4f identity = computed * invertible;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Compare with high tolerance value
                    Assert.IsTrue(System.Math.Abs(Matrix4f.Identity[i, j] - identity[i, j]) < MathHelper.BigEpsilon);
                }
            }
        }

        [Test]
        public void Column0PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f { X = 3, Y= 5, Z = 8, W = 4 }, matrix.Column0);

            matrix.Column0 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0};
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Column0);

            Assert.AreEqual(matrix.Column0.X, matrix[0, 0]);
            Assert.AreEqual(matrix.Column0.Y, matrix[1, 0]);
            Assert.AreEqual(matrix.Column0.Z, matrix[2, 0]);
            Assert.AreEqual(matrix.Column0.W, matrix[3, 0]);
        }

        [Test]
        public void Column1PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(4, 4, 7, 3), matrix.Column1);

            matrix.Column1 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Column1);

            Assert.AreEqual(matrix.Column1.X, matrix[0, 1]);
            Assert.AreEqual(matrix.Column1.Y, matrix[1, 1]);
            Assert.AreEqual(matrix.Column1.Z, matrix[2, 1]);
            Assert.AreEqual(matrix.Column1.W, matrix[3, 1]);
        }

        [Test]
        public void Column2PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(7, -1, 8, 0), matrix.Column2);

            matrix.Column2 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Column2);

            Assert.AreEqual(matrix.Column2.X, matrix[0, 2]);
            Assert.AreEqual(matrix.Column2.Y, matrix[1, 2]);
            Assert.AreEqual(matrix.Column2.Z, matrix[2, 2]);
            Assert.AreEqual(matrix.Column2.W, matrix[3, 2]);
        }

        [Test]
        public void Column3PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(9, 4, 5, 9), matrix.Column3);

            matrix.Column3 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Column3);

            Assert.AreEqual(matrix.Column3.X, matrix[0, 3]);
            Assert.AreEqual(matrix.Column3.Y, matrix[1, 3]);
            Assert.AreEqual(matrix.Column3.Z, matrix[2, 3]);
            Assert.AreEqual(matrix.Column3.W, matrix[3, 3]);
        }

        [Test]
        public void Row0PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(3, 4, 7, 9), matrix.Row0);

            matrix.Row0 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Row0);

            Assert.AreEqual(matrix.Row0.X, matrix[0, 0]);
            Assert.AreEqual(matrix.Row0.Y, matrix[0, 1]);
            Assert.AreEqual(matrix.Row0.Z, matrix[0, 2]);
            Assert.AreEqual(matrix.Row0.W, matrix[0, 3]);
        }

        [Test]
        public void Row1PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(5, 4, -1, 4), matrix.Row1);

            matrix.Row1 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Row1);

            Assert.AreEqual(matrix.Row1.X, matrix[1, 0]);
            Assert.AreEqual(matrix.Row1.Y, matrix[1, 1]);
            Assert.AreEqual(matrix.Row1.Z, matrix[1, 2]);
            Assert.AreEqual(matrix.Row1.W, matrix[1, 3]);
        }

        [Test]
        public void Row2PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f(8, 7, 8, 5), matrix.Row2);

            matrix.Row2 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Row2);

            Assert.AreEqual(matrix.Row2.X, matrix[2, 0]);
            Assert.AreEqual(matrix.Row2.Y, matrix[2, 1]);
            Assert.AreEqual(matrix.Row2.Z, matrix[2, 2]);
            Assert.AreEqual(matrix.Row2.W, matrix[2, 3]);
        }

        [Test]
        public void Row3PropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector4f { X = 4, Y= 3, Z = 0, W = 9 }, matrix.Row3);

            matrix.Row3 = new Vector4f { X = 0, Y = 0, Z = 0, W = 0 };
            Assert.AreEqual(new Vector4f { X = 0, Y = 0, Z = 0, W = 0 }, matrix.Row3);

            Assert.AreEqual(matrix.Row3.X, matrix[3, 0]);
            Assert.AreEqual(matrix.Row3.Y, matrix[3, 1]);
            Assert.AreEqual(matrix.Row3.Z, matrix[3, 2]);
            Assert.AreEqual(matrix.Row3.W, matrix[3, 3]);
        }

        [Test]
        public void TranslationPropertyTest()
        {
            Matrix4f matrix = new Matrix4f(3, 4, 7, 9, 5, 4, -1, 4, 8, 7, 8, 5, 4, 3, 0, 9);
            Assert.AreEqual(new Vector3f { X = 4, Y = 3, Z = 0 }, matrix.Translation);

            matrix.Translation = new Vector3f { X = 0, Y = 0, Z = 0};
            Assert.AreEqual(new Vector3f { X = 0, Y = 0, Z = 0 }, matrix.Translation);

            Assert.AreEqual(matrix.Translation.X, matrix[3, 0]);
            Assert.AreEqual(matrix.Translation.Y, matrix[3, 1]);
            Assert.AreEqual(matrix.Translation.Z, matrix[3, 2]);
        }

        [Test]
        public void TestIndexer()
        {
            float[] values = new float[] { 1.0f, 2.0f, 3.0f, 5.0f, 0.0f, -5.0f, .5f, 100.25f, .3f, .35f, .025f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f };

            Matrix4f m = Matrix4f.Identity;
            Vector4f v = Vector4f.One;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 4)
                    {
                        Assert.Throws<IndexOutOfRangeException>(() => m[i] = new Vector4f());
                        Assert.Throws<IndexOutOfRangeException>(() =>
                        {
                            var f = m[i];
                        });
                    }

                    if (i == 4 || j == 4)
                    {
                        Assert.Throws<IndexOutOfRangeException>(() => m[i, j] = 0);
                        Assert.Throws<IndexOutOfRangeException>(() =>
                        {
                            var f = m[i, j];
                        });
                    }
                    else
                    {
                        float value = values[(i * 4) + j];
                        m[i, j] = value;
                        Assert.AreEqual(value, m[i, j]);

                        m[i] = v;
                        Assert.AreEqual(v, m[i]);
                    }
                }
            }
        }

    }
}
