using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using csharp_rt;

namespace RT_UT
{
    [TestClass]
    public class RT_tuple_TESTS
    {
        [TestMethod]
        public void tupleTest1()
        {
            // looking for ways so I don't need to type csharp_rt. maybe use the namespace?
            csharp_rt.Tuple a = new csharp_rt.Tuple(1, 2, 3, 4);
            Assert.AreEqual(new csharp_rt.Tuple(1, 2, 3, 4), a);
            //tuple b = tuple.pt(1, 2, 3);
        }

        [TestMethod]
        public void TupleWithwis1_0isapoint()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(4.3, -4.2, 3.1, 1.0);
            Assert.AreEqual(4.3, a.x);
            Assert.AreEqual(-4.2, a.y);
            Assert.AreEqual(3.1, a.z);
            Assert.AreEqual(1.0, a.w);
        }

        [TestMethod]
        public void ATupleWithwisZeroIsAVector()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(4.3, -4.2, 3.1, 0.0);
            Assert.AreEqual(4.3, a.x);
            Assert.AreEqual(-4.2, a.y);
            Assert.AreEqual(3.1, a.z);
            Assert.AreEqual(0.0, a.w);
        }

        [TestMethod]
        public void CreatingAPoint()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(4, -4, 3);
            Assert.AreEqual(new csharp_rt.Tuple(4, -4, 3, 1), p);
        }

        [TestMethod]
        public void CreatingAVector()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(4, -4, 3);
            Assert.AreEqual(new csharp_rt.Tuple(4, -4, 3, 0), v);
        }

        [TestMethod]
        public void AddingTwoTuples()
        {
            csharp_rt.Tuple a1 = new csharp_rt.Tuple(3, -2, 5, 1);
            csharp_rt.Tuple a2 = new csharp_rt.Tuple(-2, 3, 1, 0);
            csharp_rt.Tuple ans = new csharp_rt.Tuple(1, 1, 6, 1);
            Assert.AreEqual(ans, a1 + a2);
        }

        [TestMethod]
        public void SubtractingTwoPoints()
        {
            csharp_rt.Tuple p1 = csharp_rt.Tuple.point(3, 2, 1);
            csharp_rt.Tuple p2 = csharp_rt.Tuple.point(5, 6, 7);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(-2, -4, -6);
            Assert.AreEqual(ans, p1 - p2);
        }

        [TestMethod]
        public void SubtractingAVectorFromAPoint()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(3, 2, 1);
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(5, 6, 7);
            csharp_rt.Tuple ans = csharp_rt.Tuple.point(-2, -4, -6);
            Assert.AreEqual(ans, p - v);
        }

        [TestMethod]
        public void SubtractingTwoVectors()
        {
            csharp_rt.Tuple v1 = csharp_rt.Tuple.vector(2, 1, 1);
            csharp_rt.Tuple v2 = csharp_rt.Tuple.vector(5, 6, 7);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(-2, -4, -6);
        }

        [TestMethod]
        public void SubtractingAVectorFromTheZeroVector()
        {
            csharp_rt.Tuple zero = csharp_rt.Tuple.vector(0, 0, 0);
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, -2, 3);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(-1, 2, -3);
            Assert.AreEqual(ans, zero - v);
        }

        [TestMethod]
        public void NegatingATuple()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(1, -2, 3, -4);
            csharp_rt.Tuple ans = new csharp_rt.Tuple(-1, 2, -3, 4);
            Assert.AreEqual(ans, -a);
        }
        [TestMethod]
        public void MultiplyingATupelByAScalar()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(1, -2, 3, -4);
            csharp_rt.Tuple ans = new csharp_rt.Tuple(3.5, -7, 10.5, -14);
            Assert.AreEqual(ans, a * 3.5);
        }

        [TestMethod]
        public void MultiplyingATupleByAFraction()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(1, -2, 3, -4);
            csharp_rt.Tuple ans = new csharp_rt.Tuple(0.5, -1, 1.5, -2);
            Assert.AreEqual(ans, a * 0.5);
        }

        [TestMethod]
        public void DividingATupleByAScalar()
        {
            csharp_rt.Tuple a = new csharp_rt.Tuple(1, -2, 3, -4);
            csharp_rt.Tuple ans = new csharp_rt.Tuple(0.5, -1, 1.5, -2);
            Assert.AreEqual(ans, a / 2);
        }

        [TestMethod]
        public void Computing_The_Magnitude_of_vector_1_0_0()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, 0, 0);
            double ans = 1;
            Assert.AreEqual(ans, v.magnitude());
        }

        [TestMethod]
        public void Computing_The_Magnitude_of_Vector_0_1_0()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(0, 1, 0);
            double ans = 1;
            Assert.AreEqual(ans, v.magnitude());
        }

        [TestMethod]
        public void Computing_The_Magnitude_of_Vector_0_0_1()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(0, 0, 1);
            double ans = 1;
            Assert.AreEqual(ans, v.magnitude());
        }

        [TestMethod]
        public void Computing_THe_Magnitude_of_Vector_1_2_3()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, 2, 3);
            double ans = Math.Sqrt(14);
            Assert.AreEqual(ans, v.magnitude());
        }

        [TestMethod]
        public void Computing_The_Magnitude_Of_Vector_neg1_neg2_neg3()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(-1, -2, -3);
            double ans = Math.Sqrt(14);
            Assert.AreEqual(ans, v.magnitude());
        }

        [TestMethod]
        public void Normalizing_vector_4_0_0_Gives_1_0_0()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(4, 0, 0);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(1, 0, 0);
            Assert.AreEqual(ans, v.normalize());
        }

        [TestMethod]
        public void Normalizing_Vector_1_2_3()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, 2, 3);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(1 / Math.Sqrt(14), 2 / Math.Sqrt(14), 3 / Math.Sqrt(14));
            Assert.AreEqual(ans, v.normalize());
        }

        [TestMethod]
        public void The_Magnitude_Of_A_Normalized_Vector()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, 2, 3);
            double ans = 1;
            Assert.AreEqual(ans, v.normalize().magnitude());
        }

        [TestMethod]
        public void The_Dot_Product_Of_Two_Tuples()
        {
            csharp_rt.Tuple a = csharp_rt.Tuple.vector(1, 2, 3);
            csharp_rt.Tuple b = csharp_rt.Tuple.vector(2, 3, 4);
            double ans = 20;
            Assert.AreEqual(ans, a.dot(b));
        }

        [TestMethod]
        public void TheCrossProductOfTwoVectors()
        {
            csharp_rt.Tuple a = csharp_rt.Tuple.vector(1, 2, 3);
            csharp_rt.Tuple b = csharp_rt.Tuple.vector(2, 3, 4);
            csharp_rt.Tuple ans1 = csharp_rt.Tuple.vector(-1, 2, -1);
            csharp_rt.Tuple ans2 = csharp_rt.Tuple.vector(1, -2, 1);
            Assert.AreEqual(ans1, a.cross(b));
            Assert.AreEqual(ans2, b.cross(a));
        }

        [TestMethod]
        public void rgb_are_tuples()
        {
            Color c = new Color(-0.5f, 0.4f, 1.7f);
            float red = -0.5f;
            float green = 0.4f;
            float blue = 1.7f;
            Assert.AreEqual(red, c.red);
            Assert.AreEqual(green, c.green);
            Assert.AreEqual(blue, c.blue);
        }

        [TestMethod]
        public void Adding_Colors()
        {
            Color c1 = new Color(0.9f, 0.6f, 0.75f);
            Color c2 = new Color(0.7, 0.1, 0.25);
            Color ans = new Color(1.6, 0.7, 1.0);
            Assert.AreEqual(ans, c1 + c2);
        }

        [TestMethod]
        public void Subtracting_Colors()
        {
            Color c1 = new Color(0.9f, 0.6f, 0.75f);
            Color c2 = new Color(0.7, 0.1, 0.25);
            Color ans = new Color(0.2, 0.5, 0.5);
            Assert.AreEqual(ans, c1 - c2);
        }

        [TestMethod]
        public void Multiplying_Colors_By_A_Scalar()
        {
            Color c = new Color(0.2, 0.3, 0.4);
            Color ans = new Color(0.4, 0.6, 0.8);
            Assert.AreEqual(ans, c * 2); ;
        }

        [TestMethod]
        public void Multiplying_Colors()
        {
            Color c1 = new Color(1, 0.2, 0.4);
            Color c2 = new Color(0.9, 1, 0.1);
            Color ans = new Color(0.9, 0.2, 0.04);
            Assert.AreEqual(ans, c1 * c2);
        }
    }
    [TestClass]
    public class testMatrix
    {
        [TestMethod]
        public void Constructing_and_Inspecting_a_4_x_4_Matrix()
        {
            Matrix M = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5.5, 6.5, 7.5, 8.5 }, { 9, 10, 11, 12 }, { 13.5, 14.5, 15.5, 16.5 } });
            Assert.AreEqual(1, M[0, 0]);
            Assert.AreEqual(4, M[0, 3]);
            Assert.AreEqual(5.5, M[1, 0]);
            Assert.AreEqual(7.5, M[1, 2]);
            Assert.AreEqual(11, M[2, 2]);
            Assert.AreEqual(13.5, M[3, 0]);
            Assert.AreEqual(15.5, M[3, 2]);
        }

        [TestMethod]
        public void A_2_x_2_Matrix_Ought_To_Be_Repreentable()
        {
            Matrix M = new Matrix(new double[,] { { -3, 5 }, { 1, -2 } });
            Assert.AreEqual(-3, M[0, 0]);
            Assert.AreEqual(5, M[0, 1]);
            Assert.AreEqual(1, M[1, 0]);
            Assert.AreEqual(-2, M[1, 1]);
        }
        [TestMethod]
        public void A_3x3_Matrix_Representation()
        {
            Matrix M = new Matrix(new double[,] { { -3, 5, 0 }, { 1, -2, -7 }, { 0, 1, 1 } });
            Assert.AreEqual(M[0, 0], -3);
            Assert.AreEqual(M[1, 1], -2);
            Assert.AreEqual(M[2, 2], 1);
        }
        [TestMethod]
        public void Matrix_equality_with_identical_matrices()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            Matrix B = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            //Note: I think I remember "Assert.AreEqual" uses "object.equals" and is not the same as "==" with default behavior. perhaps I can pass it to the .equals method.
            // and I may need to write code for that in matrix.
            //Assert.AreEqual(A, B);
            Assert.IsTrue(A == B);
        }
        [TestMethod]
        public void Matrix_inequality_with_identical_matrices()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            Matrix B = new Matrix(new double[,] { { 2, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            //Note: I think I remember "Assert.AreEqual" uses "object.equals" and is not the same as "==" with default behavior. perhaps I can pass it to the .equals method.
            // and I may need to write code for that in matrix.
            //Assert.AreEqual(A, B);
            Assert.IsFalse(A == B);
        }
        [TestMethod]
        public void Matrix_equality_with_different_matrices()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            Matrix B = new Matrix(new double[,] { { 2, 3, 4, 5 }, { 6, 7, 8, 9 }, { 8, 7, 6, 5 }, { 4, 3, 2, 1 } });
            Assert.IsTrue(A != B);
        }

        [TestMethod]
        public void Multiplying_Two_matrices()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            Matrix B = new Matrix(new double[,] { { -2, 1, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } });
            Matrix answer = new Matrix(new double[,] { { 20, 22, 50, 48 }, { 44, 54, 114, 108 }, { 40, 58, 110, 102 }, { 16, 26, 46, 42 } });
            Assert.IsTrue((A * B) == answer);
        }

        [TestMethod]
        public void test_square_zero_matrix()
        {
            Matrix A = new Matrix(4);
            Assert.AreEqual(A[0, 0], 0);
        }

        [TestMethod]
        public void A_matrix_multiplied_by_a_tuple()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 2, 4, 4, 2 }, { 8, 6, 4, 1 }, { 0, 0, 0, 1 } });
            csharp_rt.Tuple B = new csharp_rt.Tuple(1, 2, 3, 1);
            csharp_rt.Tuple answer = new csharp_rt.Tuple(18, 24, 33, 1);
            Assert.IsTrue(A * B == answer);
        }
        [TestMethod]
        public void multiplying_a_matrix_b_the_identity_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 0, 1, 2, 4 }, { 1, 2, 4, 8 }, { 2, 4, 8, 16 }, { 4, 8, 16, 32 } });
            //note: need to make a static one that I can use as needed I think?
            Matrix identity = new Matrix(new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
            Assert.IsTrue(A * identity == A);
        }
        /// <summary>
        /// Testing new identity matrix static val I can call upon.
        /// still investigating a global way to store a identity matrix so I don't have to do "Matrix.Identity()"
        /// </summary>
        [TestMethod]
        public void multiplying_a_matrix_b_the_identity_matrix2()
        {
            Matrix A = new Matrix(new double[,] { { 0, 1, 2, 4 }, { 1, 2, 4, 8 }, { 2, 4, 8, 16 }, { 4, 8, 16, 32 } });
            //note: need to make a static one that I can use as needed I think?
            Matrix identity = Matrix.identity();
            Assert.IsTrue(A * identity == A);
        }

        [TestMethod]
        public void Calculating_the_determinate_of_a_2_x_2_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 1, 5 }, { -3, 2 } });
            int answer = 17;
            Assert.AreEqual(answer, A.det());
        }
        [TestMethod]
        public void A_Submatrix_of_a_3x3_matrix_is_a_2x2_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 1, 5, 0 }, { -3, 2, 7 }, { 0, 6, -3 } });
            Matrix SUBMAT_A = new Matrix(new double[,] { { -3, 2 }, { 0, 6 } });
            Assert.IsTrue(A.subMat(0, 2) == SUBMAT_A);
        }
        [TestMethod]
        public void A_Submatrix_of_a_4x4_matrix_is_a_3x3_matrix()
        {
            Matrix A = new Matrix(new double[,] { { -6, 1, 1, 6 }, { -8, 5, 8, 6 }, { -1, 0, 8, 2 }, { -7, 1, -1, 1 } });
            Matrix SUBMAT_A = new Matrix(new double[,] { { -6, 1, 6 }, { -8, 8, 6 }, { -7, -1, 1 } });
            Assert.IsTrue(A.subMat(2, 1) == SUBMAT_A);
            Assert.AreEqual(A.subMat(2, 1), SUBMAT_A);
        }
        [TestMethod]
        public void Calculating_a_minor_of_a_3x2_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 3, 5, 0 }, { 2, -1, 7 }, { 6, -1, 5 } });
            Matrix B = A.subMat(1, 0);
            var det_b = B.det();
            var minor_a = A.minor(1, 0);
            Assert.AreEqual(det_b, minor_a);
        }
        [TestMethod]
        public void Calculating_a_cofactor_of_a_3x3_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 3, 5, 0 }, { 2, -1, -7 }, { 6, -1, 5 } });
            var minorA = A.minor(0, 0);
            var cofactorA = A.cofactor(0, 0);

            Assert.AreEqual(-12, minorA);
            Assert.AreEqual(-12, cofactorA);
            Assert.AreEqual(minorA, cofactorA);
            var minorA1 = A.minor(1, 0);
            var cofactorA1 = A.cofactor(1, 0);
            Assert.AreEqual(25, minorA1);
            Assert.AreEqual(-25, cofactorA1);

        }
        [TestMethod]
        public void Calculating_the_determinant_of_a_3x3_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 6 }, { -5, 8, -4 }, { 2, 6, 4 } });
            Assert.AreEqual(56, A.cofactor(0, 0));
            Assert.AreEqual(12, A.cofactor(0, 1));
            Assert.AreEqual(-46, A.cofactor(0, 2));
            Assert.AreEqual(-196, A.det());
        }

        [TestMethod]
        public void Calculating_the_determinant_of_a_4x4_matrix()
        {
            Matrix A = new Matrix(new double[,] { { -2, -8, 3, 5 }, { -3, 1, 7, 3 }, { 1, 2, -9, 6 }, { -6, 7, 7, -9 } });
            Assert.AreEqual(690, A.cofactor(0, 0));
            Assert.AreEqual(447, A.cofactor(0, 1));
            Assert.AreEqual(210, A.cofactor(0, 2));
            Assert.AreEqual(51, A.cofactor(0, 3));
            Assert.AreEqual(-4071, A.det());
        }

        [TestMethod]
        public void Testing_an_invertible_matrix_for_invertibility()
        {
            Matrix A = new Matrix(new double[,] { { 6, 4, 4, 4 }, { 5, 5, 7, 6 }, { 4, -9, 3, -7 }, { 9, 1, 7, -6 } });
            Assert.AreEqual(-2120, A.det());
            Assert.IsTrue(A.isInvertible());
        }
        [TestMethod]
        public void Testing_a_noninvertible_matrix_for_invertibility()
        {
            Matrix A = new Matrix(new double[,] { { -4, 2, -2, 3 }, { 9, 6, 2, 6 }, { 0, 5, 1, -5 }, { 0, 0, 0, 0 } });
            Assert.AreEqual(0, A.det());
            Assert.IsFalse(A.isInvertible());
        }

        [TestMethod]
        public void Calculating_the_inverse_of_a_matrix()
        {
            Matrix A = new Matrix(new double[,] { { -5, 2, 6, -8 }, { 1, -5, 1, 8 }, { 7, 7, -6, -7 }, { 1, -3, 7, 4 } });
            Matrix B = A.inverse();
            Matrix bShould = new Matrix(new double[,] { { 0.21805, 0.45113, 0.24060, -0.04511 }, { -0.80827, -1.45677, -0.44361, 0.52068 }, { -0.07895, -0.22368, -0.05263, 0.19737 }, { -0.52256, -0.81391, -0.30075, 0.30639 } });

            var det_a = A.det();
            Assert.AreEqual(532, det_a);
            var a_cofactor = A.cofactor(2, 3);
            Assert.AreEqual(-160, a_cofactor);
            var a_cofactor2 = A.cofactor(3, 2);
            Assert.AreEqual(105, a_cofactor2);
            Assert.AreEqual(-160 / 532d, B[3, 2]);
            Assert.AreEqual(105 / 532d, B[2, 3]);
            Assert.AreEqual(bShould, B);
        }

        [TestMethod]
        public void calculating_the_inverse_of_another_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 8, -5, 9, 2 }, { 7, 5, 6, 1 }, { -6, 0, 9, 6 }, { -3, 0, -9, -4 } });
            Matrix ret = A.inverse();
            Matrix invA = new Matrix(new double[,] { { -0.15385, -.15385, -.28205, -0.53846 }, { -0.07692, 0.12308, 0.02564, 0.03077 }, { 0.35897, 0.35897, .43590, 0.92308 }, { -0.69231, -0.69231, -0.76923, -1.92308 } });
            Assert.AreEqual(ret, invA);
        }
        [TestMethod]
        public void calculating_thie_inverse_of_a_third_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 9, 3, 0, 9 }, { -5, -2, -6, -3 },  { -4, 9, 6, 4 }, { -7, 6, 6, 2 } });
            Matrix ans = A.inverse();
            // used GNU Octave to help generate the below.
            // most of my failed tests come from mistyping something. 
            Matrix B = new Matrix(new double[,] { { -0.040741, -0.077778, 0.144444, -0.222222 }, { -0.077778, 0.033333, 0.366667, -0.333333 }, { -0.029012, -0.146296, -0.109259, 0.129630 }, { 0.177778, 0.066667, -0.266667, 0.333333 } });
            Assert.AreEqual(ans, B);
        }
        [TestMethod]
        public void Multiplying_a_product_by_its_inverse()
        {
            Matrix A = new Matrix(new double[,] { { 3, -9, 7, 3 }, { 3, -8, 2, -9 },  { -4, 4, 4, 1 }, { 6, 5, -1, 1 } });
            Matrix B = new Matrix(new double[,] { { 8, 2, 2, 2 }, { 3, -1, 7, 0 }, { 7, 0, 5, 4 }, { 6, -2, 0, 5 } });
            Matrix C = A * B;
            Assert.AreEqual(A, C * B.inverse());
        }
    }
    [TestClass]
    public class testMatrixTransformations
    {
        [TestMethod]
        public void Multiplying_by_a_transformaiton_matrix()
        {
            Matrix transform = Matrix.translation(5, -3, 2);
            csharp_rt.Tuple point= csharp_rt.Tuple.point(-3,4,5);
            Assert.AreEqual(csharp_rt.Tuple.point(2, 1, 7), transform * point);
        }

        [TestMethod]
        public void Multiplying_by_the_inverse_of_a_translation_matrix()
        {
            Matrix transform = Matrix.translation(5, -3, 2);
            Matrix inv = transform.inverse();
            csharp_rt.Tuple p = csharp_rt.Tuple.point(-3, 4, 5);
            Assert.AreEqual(csharp_rt.Tuple.point(-8,7,3), inv * p);
        }
    }

    [TestClass]
    public class TestMatrixScaling
    {
        [TestMethod]
        public void a_scaling_matrix_applied_to_a_point()
        {
            Matrix transform = Matrix.scaling(2, 3, 4);
            csharp_rt.Tuple point = csharp_rt.Tuple.point(-4, 6, 8);
            Assert.AreEqual(csharp_rt.Tuple.point(-8, 18, 32), transform * point); 
        }
        [TestMethod]
        public void A_scaling_matrix_appied_to_a_vector()
        {
            Matrix transform = Matrix.scaling(2, 3, 4);
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(-4, 6, 8);
            Assert.AreEqual(csharp_rt.Tuple.vector(-8, 18, 32), transform * v);
        }
        [TestMethod]
        public void Multiplying_by_the_inverse_of_a_scaling_matrix()
        {
            Matrix transform = Matrix.scaling(2, 3, 4);
            Matrix inv = transform.inverse();
            csharp_rt.Tuple v= csharp_rt.Tuple.vector(-4,6, 8);
            Assert.AreEqual(csharp_rt.Tuple.vector(-2,2,2), inv * v);
        
        }

        [TestMethod]
        public void Reflection_is_scaling_by_a_negative_value()
        {
            Matrix transform = Matrix.scaling(-1, 1, 1);
            csharp_rt.Tuple p = csharp_rt.Tuple.point(2, 3, 4);
            Assert.AreEqual(csharp_rt.Tuple.point(-2,3,4), transform * p);
        }

    }
}