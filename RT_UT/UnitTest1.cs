using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using csharp_rt;
using System.Linq;
using CSharpRayTracer;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System.Threading;
// when did System.Drawing get added? it broke all my tests using my Color.
//using System.Drawing;

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
            //3 2 1 = act v1
            //2 1 1 = typed in error. original. I think this was the test I forgot the "test".
            csharp_rt.Tuple v1 = csharp_rt.Tuple.vector(3, 2, 1);
            csharp_rt.Tuple v2 = csharp_rt.Tuple.vector(5, 6, 7);
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(-2, -4, -6);
            Assert.AreEqual(ans, v1-v2);
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
        /// <summary>
        /// 2/23/2024
        /// accidently missed this one.
        /// this is funny in that this is not used again until Page 82. (this was on page 33).
        /// the 2==5 is so the test fails so I know where to start (page 33) if I am still stuck here.
        /// looks to be easy to implement.
        /// </summary>
        [TestMethod]
        public void Transposing_a_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 0, 9, 3, 0 }, { 9, 8, 0, 8 }, { 1, 8, 5, 3 }, { 0, 0, 5, 8 } });
            Matrix A_Transpose = new Matrix(new double[,] { { 0, 9, 1, 0 }, { 9, 8, 8, 0 }, { 3, 0, 5, 5 }, { 0, 8, 3, 8 } });
            Assert.AreEqual(A.transpose(),A_Transpose);
            //Assert.IsTrue(2 == 5);
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
    [TestClass]
    public class RotationTesting()
    {
        [TestMethod]
        public void rotating_a_point_around_the_x_axis()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(0, 1, 0);
            Matrix half_quater = Matrix.rotation_x(Math.PI / 4);
            Matrix full_quater = Matrix.rotation_x(Math.PI / 2);
            Assert.AreEqual(csharp_rt.Tuple.point(0, Math.Sqrt(2) / 2, Math.Sqrt(2) / 2), half_quater * p);
            Assert.AreEqual(csharp_rt.Tuple.point(0,0,1),full_quater * p);
        }

        [TestMethod]
        public void rotating_a_point_around_the_y_axis()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(0, 0, 1);
            Matrix half_quarter= Matrix.rotation_y(Math.PI /4);
            Matrix full_quarter=Matrix.rotation_y(Math.PI /2);
            Assert.AreEqual(csharp_rt.Tuple.point(Math.Sqrt(2)/2,0,Math.Sqrt(2)/2),half_quarter * p);
            Assert.AreEqual(csharp_rt.Tuple.point(1,0,0),full_quarter * p);
        }

        [TestMethod]
        public void rotating_a_point_around_the_z_axis()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(0, 1, 0);
            Matrix half_quarter=Matrix.rotation_z(Math.PI /4);
            Matrix full_quarter = Matrix.rotation_z(Math.PI/2);
            Assert.AreEqual(csharp_rt.Tuple.point(-Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0),half_quarter * p);
            Assert.AreEqual(csharp_rt.Tuple.point(-1, 0, 0), full_quarter * p);
        }
        [TestMethod]
        public void A_shearing_transformation_moves_x_in_proporiton_to_y()
        {
            Matrix transform = Matrix.shearing(1, 0, 0, 0, 0, 0);
            csharp_rt.Tuple p = csharp_rt.Tuple.point(2, 3, 4);
            Assert.AreEqual(csharp_rt.Tuple.point(5, 3, 4), transform * p);
        }
        [TestMethod]
        public void A_shearing_transformation_moves_y_in_proportion_to_x()
        {
            Matrix transform = Matrix.shearing(0, 0, 1, 0, 0, 0);
            csharp_rt.Tuple p = csharp_rt.Tuple.point(2, 3, 4);
            Assert.AreEqual(csharp_rt.Tuple.point(2,5,4), transform * p);
        }
        [TestMethod]
        public void A_shearing_transformation_moves_y_inproportion_to_z()
        {
            Matrix transform = Matrix.shearing(0, 0, 0, 1, 0, 0);
            csharp_rt.Tuple p = csharp_rt.Tuple.point(2, 3, 4);
            Assert.AreEqual(csharp_rt.Tuple.point(2,7,4), transform * p);
        }
        [TestMethod]
        public void A_shearing_transformation_moves_z_in_proportion_to_y()
        {
            Matrix transform = Matrix.shearing(0, 0, 0, 0, 0, 1);
            csharp_rt.Tuple p = csharp_rt.Tuple.point(2, 3, 4);
            Assert.AreEqual(csharp_rt.Tuple.point(2,3,7), transform * p);
        }
        [TestMethod]
      public void individual_transformaions_are_applied_in_sequence()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(1, 0, 1);
            Matrix A = Matrix.rotation_x(Math.PI / 2);
            Matrix B = Matrix.scaling(5, 5, 5);
            
            Matrix C = Matrix.translation(10, 5, 7);
            csharp_rt.Tuple p2 = A * p;
            Assert.AreEqual(csharp_rt.Tuple.point(1, -1, 0), p2);
            csharp_rt.Tuple p3 = B * p2;
            Assert.AreEqual(csharp_rt.Tuple.point(5, -5, 0), p3);
            csharp_rt.Tuple p4 = C * p3; 
            Assert.AreEqual(csharp_rt.Tuple.point(15,0,7), p4); 
        }
        [TestMethod]
        public void Chained_transformations_must_be_applied_in_reverse_order()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(1, 0, 1);
            Matrix A = Matrix.rotation_x(Math.PI/2);
            Matrix B = Matrix.scaling(5, 5, 5);
            Matrix C = Matrix.translation(10, 5, 7);
            Matrix T = C * B * A;
            Assert.AreEqual(csharp_rt.Tuple.point(15, 0, 7), T * p);
        }

        [TestMethod]
        public void Testing_non_static_chaned_transformations()
        {
            csharp_rt.Tuple p = csharp_rt.Tuple.point(1, 0, 1);
            Matrix T = Matrix.identity().rotation_x_ns(Math.PI / 2).scaling_ns(5, 5, 5).translation_ns(10, 5, 7);
            Assert.AreEqual(csharp_rt.Tuple.point(15,0, 7), T * p);
        }
    }
    [TestClass]
    public class testingRay()
    {
        [TestMethod]
        public void Creating_and_quering_a_ray()
        {
            csharp_rt.Tuple origin = csharp_rt.Tuple.point(1, 2, 3);
            csharp_rt.Tuple direction = csharp_rt.Tuple.vector(4, 5, 6);
            Ray r=new Ray(origin, direction);
            Assert.AreEqual(origin, r.origin);
            Assert.AreEqual(direction, r.direction);
        }
        [TestMethod]
        public void Computing_a_point_from_a_distance()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(2, 3, 4), csharp_rt.Tuple.vector(1, 0, 0));
            Assert.AreEqual(csharp_rt.Tuple.point(2, 3, 4), r.position(0));
            Assert.AreEqual(csharp_rt.Tuple.point(3, 3, 4), r.position(1));
            Assert.AreEqual(csharp_rt.Tuple.point(1,3,4), r.position(-1));
            Assert.AreEqual(csharp_rt.Tuple.point(4.5, 3, 4), r.position(2.5));
        }
        [TestMethod]
        public void A_ray_intersects_a_sephere_at_two_points()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //var xs = s.old_intersect(r);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(4.0d, xs[0].t);
            Assert.AreEqual(6.0d, xs[1].t);
        }
        [TestMethod]
        public void a_ray_intersects_a_sphere_at_a_tangent()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 1, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //double[] xs= s.old_intersect(r);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(5.0d, xs[0].t);
            Assert.AreEqual(5.0d, xs[1].t);
        }
        [TestMethod]
        public void a_ray_misses_a_sphere()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 2, 5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //double[] xs= s.old_intersect(r);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(0, xs.count());
        }
        [TestMethod]
        public void A_ray_originates_inside_a_sphere()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //double[] xs= s.old_intersect(r);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(-1.0d, xs[0].t);
            Assert.AreEqual(1.0d, xs[1].t);
        }
        [TestMethod]
        public void new_A_ray_originates_inside_a_sphere()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(-1.0d, xs[0].t);
            Assert.AreEqual(1.0d, xs[1].t);
        }
            [TestMethod]
        public void A_sphere_is_behind_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //double[] xs= s.old_intersect(r);
            Intersections xs= new Intersections(s.Intersect(r));
            //Assert.AreEqual(2, xs.Count());
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(-6.0d, xs[0].t);
            Assert.AreEqual(-4.0d, xs[1].t);
        }
        [TestMethod]
        public void A_sphere_is_behind_a_ray_with_new_intersect()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(-6.0d, xs[0].t);
            Assert.AreEqual(-4.0d, xs[1].t);
        }
        [TestMethod]
        public void An_intersection_encapsulates_t_and_object()
        {
            Sphere s=new Sphere();
            Intersection i = new Intersection(3.5d, s);
            Assert.AreEqual(3.5d, i.t);
            Assert.AreEqual(s, i.tnObj);
        }
        [TestMethod]
        public void Aggregating_intersections()
        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
            Intersections xs=new Intersections(i1, i2);
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(1, xs.t[0].t);
            Assert.AreEqual(2, xs.t[1].t);
        }
        /// <summary>
        /// This one is updated to use xs[x].t. instead of the above annoying looking "xs.t[0].t"...
        /// </summary>
        [TestMethod]
        public void Aggregating_intersections_updated()
        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
            Intersections xs = new Intersections(i1, i2);
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(1, xs[0].t);
            Assert.AreEqual(2, xs[1].t);
        }
        /// <summary>
        /// Note: I accidentally skipped this test when working on the above.
        /// This is important for later test "Intersecting a scaled sphere with a ray"
        /// as it uses the change set in this function that I missed.
        /// I will try to have a new intersect method instead of breaking this one.
        /// </summary>
        public void Intersect_sets_the_object_on_the_intersection()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            // Check this
            Intersections xs = new Intersections(/*s.intersect(r);*/);
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(s, xs[0].tnObj);
            Assert.AreEqual(s, xs[1].tnObj);
        }

        [TestMethod]
        public void The_hit_when_all_intersections_have_positive_t()
        {
            Sphere s=new Sphere();
            Intersection i1=new Intersection(1, s);
            Intersection i2=new Intersection(2, s);
            Intersections xs =new Intersections(i1, i2);
            Intersection i = xs.hit();
            Assert.AreEqual(i1, i);
        }

        [TestMethod]
        public void The_hit_when_some_intersections_have_negative_t()
        {
            Sphere s = new Sphere();
            Intersection i1=new Intersection(-1, s);
            Intersection i2=new Intersection(1, s);
            Intersections xs = new Intersections(i2, i1);
            Intersection i=xs.hit();
            Assert.AreEqual(i2, i);
        }

        [TestMethod]
        public void The_hit_when_all_intersections_have_negative_t()
        {
            Sphere s=new Sphere();
            Intersection i1= new Intersection(-2, s);
            Intersection i2 = new Intersection(-1, s);
            Intersections xs=new Intersections(i2, i1);
            Intersection i = xs.hit();
            //Assert.IsNull(i);
            Assert.IsTrue(i.nothing);
        }

        [TestMethod]
        public void The_hit_is_always_the_lowest_nonnegative_intersection()
        {
            Sphere s = new Sphere();
            Intersection i1= new Intersection(5, s);
            Intersection i2 = new Intersection(7, s);
            Intersection i3 = new Intersection(-3, s);
            Intersection i4 = new Intersection(2, s);
            Intersections xs = new Intersections(i1, i2, i3, i4);
            Intersection i = xs.hit();
            Assert.AreEqual(i4, i);
        }
    }
    [TestClass]
    public class Transforming_Rays_and_Spheres()
    {
        [TestMethod]
        public void Translating_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(1, 2, 3), csharp_rt.Tuple.vector(0, 1, 0));
            Matrix m = Matrix.translation(3, 4, 5);
            Ray r2 = r.transform(m);
            Assert.AreEqual(csharp_rt.Tuple.point(4, 6, 8), r2.origin);
            Assert.AreEqual(csharp_rt.Tuple.vector(0,1,0), r2.direction);
        }
        [TestMethod]
        public void scaling_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(1, 2, 3), csharp_rt.Tuple.vector(0, 1, 0));
            Matrix m = Matrix.scaling(2, 3, 4);
            Ray r2 = r.transform(m);
            Assert.AreEqual(csharp_rt.Tuple.point(2,6,12), r2.origin);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 3, 0), r2.direction);
        }
        [TestMethod]
        public void A_Spheres_default_transformation()
        {
            Sphere s = new Sphere();
            Assert.AreEqual(Matrix.identity(), s.Transform);
        }
        [TestMethod]
        public void Changing_a_spheres_transformation()
        {
            Sphere s = new Sphere();
            Matrix m = Matrix.translation(2, 3, 4);
            s.Set_Transform(m);
            Assert.AreEqual(m, s.Transform);
        }

        [TestMethod]
        public void Intersecting_a_scaled_sphere_with_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere sphere = new Sphere();
            sphere.Set_Transform(Matrix.scaling(2, 2, 2));
            Intersections xs = new Intersections(sphere.Intersect(r));
            Assert.AreEqual(2, xs.count());
            Assert.AreEqual(3, xs[0].t);
            Assert.AreEqual(7, xs[1].t);
        }

        /// <summary>
        /// so this looks like this is failing due to the new way 
        /// I handle a case where it would be zero such that the 
        /// descriminate < 0
        /// </summary>
        [TestMethod]
        public void Intersecting_a_translated_sphere_with_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.point(0, 0, 1));
            Sphere s = new Sphere();
            s.Set_Transform(Matrix.translation(5, 0, 0));
            Intersections xs=new Intersections(s.Intersect(r));
            Assert.AreEqual(0,xs.count());
        }
    }
    [TestClass]
    public class Light_and_Shading()
    {
        [TestMethod]
        public void The_normal_on_a_sphere_at_a_point_on_the_x_axis()
        {
            //starting using place holders to prevent errors
            Sphere s=new Sphere();
            csharp_rt.Tuple n=s.normal_at(csharp_rt.Tuple.point(1,0,0));
            Assert.AreEqual(csharp_rt.Tuple.vector(1,0,0),n);

        }
        [TestMethod]
        public void The_Normal_on_a_sphere_at_a_point_on_the_y_axis()
        {
            Sphere s = new Sphere();
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0,1,0));
            Assert.AreEqual(csharp_rt.Tuple.vector(0,1,0),n);
        }
        [TestMethod]
        public void The_Normal_on_a_sphere_at_a_point_on_the_z_axis()
        {
            Sphere s = new Sphere();
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0,0,1));
            Assert.AreEqual(csharp_rt.Tuple.vector(0,0,1),n);
        }
        [TestMethod]
        public void The_Normal_on_a_sphere_at_a_nonaxial_point()
        {
            Sphere s = new Sphere();
            //int a= Math.Sqrt
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(Math.Sqrt(3)/3,Math.Sqrt(3)/3,Math.Sqrt(3)/3));
            Assert.AreEqual(csharp_rt.Tuple.vector(Math.Sqrt(3)/3,Math.Sqrt(3)/3,Math.Sqrt(3)/3),n);
        }

        [TestMethod]
        public void Compuuting_the_normal_on_a_translated_sphere()
        {
            Sphere s = new Sphere();
            s.Set_Transform(Matrix.translation(0, 1, 0));
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0, 1.70711, -0.70711));
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0.70711, -0.70711),n);
        }
        [TestMethod]
        public void Computing_the_normal_on_a_transformed_sphere()
        {
            Sphere s = new Sphere();
            Matrix m = Matrix.scaling(1, 0.5, 1) * Matrix.rotation_z(Math.PI / 5);
            s.Set_Transform(m);
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2));
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0.97014, -0.24254), n);
        }

        [TestMethod]
        public void Reflecting_a_vector_approaching_at_45_degrees()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(1, -1, 0);
            csharp_rt.Tuple n = csharp_rt.Tuple.vector(0, 1, 0);
            csharp_rt.Tuple r = csharp_rt.Tuple.vector(1, 1, 0);
            Assert.AreEqual(v.reflect(n),r);
        }
        [TestMethod]
        public void Reflecting_a_vector_off_a_slanted_surface()
        {
            csharp_rt.Tuple v = csharp_rt.Tuple.vector(0, -1, 0);
            csharp_rt.Tuple n = csharp_rt.Tuple.vector(Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0);
            csharp_rt.Tuple r = csharp_rt.Tuple.vector(1, 0, 0);
            Assert.AreEqual(v.reflect(n),r);
        }
        [TestMethod]
        public void A_point_of_light_has_a_position_and_intensity()
        {
            Color intensity = new Color(1, 1, 1);
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Light light= csharp_rt.Light.point_light(position,intensity);
            Assert.AreEqual(position,light.position);
            Assert.AreEqual(intensity,light.intensity);
        }
        [TestMethod]
        public void The_default_material()
        {
            Material m = new Material();
            Assert.AreEqual(new Color(1,1,1),m.color);
            Assert.AreEqual(0.1,m.ambient);
            Assert.AreEqual(0.9,m.diffuse);
            Assert.AreEqual(0.9,m.specular);
            Assert.AreEqual(200.0,m.shininess);
        }
        [TestMethod]
        public void A_sphere_has_a_default_material()
        {
            Sphere s = new Sphere();
            Material m = new Material();
            Material ms = s.Material;
            Assert.AreEqual(m,ms);
        }
        [TestMethod]
        public void A_sphere_may_be_assigned_a_material()
        {
            Sphere s = new Sphere();
            Material m = new Material();
            m.ambient=1;
            s.Material=m;
            Assert.AreEqual(m,s.Material);
        }
        [TestMethod]
        public void Lighting_with_the_eye_between_the_light_and_the_surface()
        {
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            //Light <(())> surface
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0, 0, -1);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light = Light.point_light(csharp_rt.Tuple.point(0,0,-10),new Color(1,1,1));
            //Material result=newLighting(light,position,eyev,normalv); mark for delete
            Color result = light.old_lighting_old(m,position,eyev,normalv);
            Assert.AreEqual(new Color(1.9,1.9,1.9),result);
        }
        [TestMethod]
        public void Lighting_with_the_eye_between_light_and_surface_eye_offset_45_degrees()
        {
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            //assume all the tests have the 2 above
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0,Math.Sqrt(2)/2,-Math.Sqrt(2)/2);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light=Light.point_light(csharp_rt.Tuple.point(0,0,-10),new Color(1,1,1));
            Color result = light.old_lighting_old(m, position, eyev, normalv);
            //Material m = lighting(light,position,eyev,normalv); mark for delete
            Assert.AreEqual(new Color(1.0,1.0,1.0),result);
        }
        [TestMethod]
        public void Lighting_with_eye_opposite_surface_light_offset_45_degrees()
        {
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            //assume all the tests have the 2 above
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0, 0, -1);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light=Light.point_light(csharp_rt.Tuple.point(0,10,-10),new Color(1,1,1));
            Color result=light.old_lighting_old(m,position,eyev,normalv);
            Assert.AreEqual(new Color(0.7364,0.7364,0.7364),result);
        }
        [TestMethod]
        public void Lighting_with_eye_in_the_path_of_the_reflection_vector()
        {
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            //assume all the tests have the 2 above
            csharp_rt.Tuple eyev=csharp_rt.Tuple.vector(0,-(Math.Sqrt(2)/2),-(Math.Sqrt(2)/2));
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light=Light.point_light(csharp_rt.Tuple.point(0,10,-10),new Color(1,1,1));
            Color result=light.old_lighting_old(m,position,eyev,normalv);
            Assert.AreEqual(new Color(1.6364,1.6364,1.6364),result);
        }
        [TestMethod]
        public void Lighting_with_the_light_behind_the_surface()
        {
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            //assume all the tests have the 2 above
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0,0,-1);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light=Light.point_light(csharp_rt.Tuple.point(0,0,10),new Color(1,1,1));
            Color result=light.old_lighting_old(m,position,eyev,normalv);
            Assert.AreEqual(new Color(0.1,0.1,0.1),result);
        }
    }
    [TestClass]
    public class Bulding_A_World()
    {
        [TestMethod]
        public void creating_a_world()
        {
            World w = new World();
            Debug.Write("test write");
            Assert.AreEqual(0, w.shapeList.Count);
        }
        [TestMethod]
        public void the_default_world()
        {
            Light light = Light.point_light(csharp_rt.Tuple.point(-10,10,-10),new Color(1,1,1));
            Sphere s1 = new Sphere();
            s1.Material.color = new Color(0.8, 1.0, 0.6);
            s1.Material.diffuse = 0.7;
            s1.Material.specular = 0.2;
            Sphere s2 =new Sphere();
            /* this is here so I can remember how to set scaling...
             * Matrix m = Matrix.scaling(1, 0.5, 1) * Matrix.rotation_z(Math.PI / 5);
            s.set_transform(m);*/
            //not correct
            //s2.set_transform(Matrix.scaling(0.5, 0.5, 0.5));
            //correct way to set scaling... need to investigate to be sure...
            //s2.transform.scaling_ns(0.5, 0.5, 0.5);
            s2.Set_Transform(Matrix.scaling(0.5, 0.5, 0.5));
            World w = new World();
            w=w.default_world();
            //Assert.IsTrue(w.light== light);
            Assert.AreEqual(w.light, light);
            Assert.AreEqual(s1, w.shapeList[0]);
            //seems it doesn't like this one. the only one with a transform set...
            Assert.AreEqual(s2, w.shapeList[1]);
        }
        [TestMethod]
        public void Intersect_a_world_with_a_ray()
        {
            World w = new World();
            w = w.default_world();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5.0), csharp_rt.Tuple.vector(0, 0, 1));
            Intersections xs = new Intersections(w.intersect_world(r));

            /*  
             * Trying to remember how intersections worked for sphere. 
             * Intersections xs = new Intersections(s.intersect(r));
             * Assert.AreEqual(4.0d, xs[0].t);
             * Assert.AreEqual(6.0d, xs[1].t);*/


            // need to figure this out.
            // it seems to be returning an int value.
            // xs[1].t is returning 5 (so is xs[2].t)
            // looks like I need to work on sorting the results.
            //looks like calling hit on intersections sorts the list and the tests pass.
            //xs.hit();
            /* Marked for deletion */

            xs.sort();
            Assert.AreEqual(4, xs.count());
            Assert.AreEqual(4.0d, xs[0].t);
            Assert.AreEqual(4.5d, xs[1].t);
            Assert.AreEqual(5.5d, xs[2].t);
            Assert.AreEqual(6.0d, xs[3].t);
        }

        [TestMethod]
        public void Precomputing_the_state_of_an_intersect()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            Intersection i = new Intersection(4, shape);
            //var = Computations struct
            var comps = i.prepare_computations(r);
            Assert.AreEqual(i.t, comps.t);
            Assert.AreEqual(i.tnObj, comps.shapeObj);
            Assert.AreEqual(csharp_rt.Tuple.point(0, 0, -1), comps.point);
            //eyev is the on currently failing
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0, -1), comps.eyev);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0, -1), comps.normalv);
            //Assert.IsFalse(true == true);

        }

        [TestMethod]
        public void The_hit_when_an_intersection_occurs_on_the_outside()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            Intersection i = new Intersection(4.0d, shape);
            Computations comps = i.prepare_computations(r);
            Assert.IsFalse(comps.inside);
        }

        [TestMethod]
        public void The_hit_when_an_intersection_occurs_on_the_inside()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            Intersection i = new Intersection(1, shape);
            Computations comps = i.prepare_computations(r);
            Assert.AreEqual(csharp_rt.Tuple.point(0, 0, 1), comps.point);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0, -1), comps.eyev);
            Assert.IsTrue(comps.inside);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0, -1), comps.normalv);
        }

        [TestMethod]
        public void Shading_an_intersection()
        {
            World w = new World();
            w=w.default_world();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = (Sphere)w.shapeList[0];
            Intersection i = new Intersection(4, shape);
            Computations comps = i.prepare_computations(r);
            Color c = w.shade_hit(comps);
            Assert.AreEqual(new Color(0.38066, 0.47583, 0.2855),c);
        }

        [TestMethod]
        public void Shading_an_intersection_from_the_inside()
        {
            World w = new World();
            w=w.default_world();
            w.light = Light.point_light(csharp_rt.Tuple.point(0, 0.25, 0), new Color(1, 1, 1));
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = (Sphere)w.shapeList[1];
            Intersection i = new Intersection(0.5d, shape);
            Computations comps = i.prepare_computations(r);
            Color c = w.shade_hit(comps);
            Assert.AreEqual(Color.color(0.90498, 0.90498, 0.90498), c);
        }

        [TestMethod]
        public void The_color_when_a_ray_misses()
        {
            World w=new World();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 1, 0));
            Color c = w.color_at(r);
            Assert.AreEqual(new Color(0,0,0), c);
        }

        [TestMethod]
        public void The_color_when_a_ray_hits()
        {
            World w = new World();
            w = w.default_world();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Color c = w.color_at(r);
            Assert.AreEqual(new Color(0.38066, 0.47583, 0.2855), c);
        }
        
        [TestMethod]
        public void The_color_whith_an_intersection_behind_the_ray()
        {
            World w = new World();
            w=w.default_world();
            Sphere outer = (Sphere)w.shapeList[0];
            outer.Material.ambient = 1;
            //test
            //outer.material.ambient = 12;
            Sphere inner = (Sphere)w.shapeList[1];
            inner.Material.ambient = 1;
            //Assert.AreEqual(inner.material.ambient, 1);
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0.75), csharp_rt.Tuple.vector(0, 0, -1));
            Color c = w.color_at(r);
            //Assert.AreEqual(12.0d, w.sphereList[0].material.ambient);
            //Assert.AreEqual(1.0d, w.sphereList[0].material.ambient);
            //Assert.AreEqual(1.0d, w.sphereList[1].material.ambient);
            Assert.AreEqual(inner.Material.color, c);
            //Assert.AreEqual(w.sphereList[1].material.color, c);
        }
        [TestMethod]
        public void test_ray_way_out_of_bounds()
        {
            World w = new World();
            w=w.default_world();
            Ray r = new Ray(csharp_rt.Tuple.point(5, 5, 11), csharp_rt.Tuple.vector(-24, 567, -53));
            Color c = w.color_at(r);
            Assert.AreEqual(Color.color(0, 0, 0), c);
        }
        [TestMethod]
        public void The_transformation_matrix_for_the_default_orientation()
        {
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, -1);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            Matrix t = Matrix.view_transform(from, to, up);
            Assert.AreEqual(Matrix.identity(), t);
        }
        [TestMethod]
        public void A_view_transformation_matrix_looking_in_positive_z_direction()
        {
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, 1);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            Matrix t = Matrix.view_transform(from, to, up);
            Assert.AreEqual(Matrix.scaling(-1,1,-1), t);
        }
        [TestMethod]
        public void The_view_transformation_moves_the_world()
        {
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, 8);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            Matrix t = Matrix.view_transform(from, to, up);
            Assert.AreEqual(Matrix.translation(0, 0, -8), t);
        }

        [TestMethod]
        public void An_arbitrary_view_transformation()
        {
            csharp_rt.Tuple from = csharp_rt.Tuple.point(1, 3, 2);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(4, -2, 8);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(1, 1, 0);
            Matrix t = Matrix.view_transform(from, to, up);
            Matrix res = new Matrix(new double[,] { { -0.50709, .50709, .67612, -2.36643 }, { 0.76772, 0.60609, .12122, -2.82843 }, { -0.35857, 0.59761, -0.71714, 0 }, { 0, 0, 0, 1 } });
            Assert.AreEqual(res, t);
        }

        [TestMethod]
        public void Construct_a_camera()
        {
            int hsize = 160;
            int vsize = 120;
            double field_of_view = Math.PI / 2;
            Camera c = new Camera(hsize,vsize,field_of_view);
            //var c = 234;
            Assert.AreEqual(c.hsize,160);
            Assert.AreEqual(c.vsize,120);
            Assert.AreEqual(c.fov,Math.PI/2);
            Assert.AreEqual(c.transform, Matrix.identity());
        }

        [TestMethod]
        public void The_pixel_size_for_a_horizontal_canvas()
        {
            Camera c = new Camera(200,125,Math.PI/2);
            //Assert.AreEqual(0.01d,c.pixel_size);
            Assert.IsTrue(Math.Abs(0.01d - c.pixel_size) < 0.00001);
        }

        [TestMethod]
        public void The_pixel_size_for_a_vertical_canvas()
        {
            Camera c = new Camera(125,200, Math.PI/2);
            //Assert.AreEqual(0.01d,c.pixel_size);
            Assert.IsTrue(Math.Abs(0.01d - c.pixel_size) < 0.00001);
        }

        [TestMethod]
        public void Constructing_a_ray_through_the_center_of_the_canvas()
        {
            Camera c = new Camera(201,101,Math.PI/2);
            Ray r = c.ray_for_pixel(100,50);
            Assert.AreEqual(csharp_rt.Tuple.point(0, 0,0),r.origin);
            Assert.AreEqual(csharp_rt.Tuple.vector(0,0,-1), r.direction);
        }
        [TestMethod]
        public void Constructing_a_ray_through_the_corner_of_the_canvas()
        {
            Camera c = new Camera(201, 101, Math.PI / 2);
            Ray r = c.ray_for_pixel(0,0);
            Assert.AreEqual(r.origin,csharp_rt.Tuple.point(0, 0,0));
            Assert.AreEqual(r.direction,csharp_rt.Tuple.vector(0.66519,0.33259,-0.66851));
        }
        [TestMethod]
        public void Constructing_a_ray_when_the_camera_is_transformed()
        {
            Camera c = new Camera(201, 101, Math.PI / 2);
            c.transform = Matrix.rotation_y(Math.PI / 4) * Matrix.translation(0, -2, 5);
            Ray r = c.ray_for_pixel(100,50);
            Assert.AreEqual(r.origin,csharp_rt.Tuple.point(0, 2,-5));
            Assert.AreEqual(r.direction,csharp_rt.Tuple.vector(Math.Sqrt(2) / 2,0,-Math.Sqrt(2) / 2));
        }

        [TestMethod]
        public void Rendering_a_world_with_a_camera()
        {
            World w = new World();
            w = w.default_world();
            Camera c = new Camera(11,11,Math.PI / 2);
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, -5);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            c.transform = Matrix.view_transform(from, to, up);
            //rest of test
            Canvas image = c.render(w);
            Assert.AreEqual(Color.color(0.38066, 0.47583, 0.2855), image.pixel_at(5, 5));
        }

    }

    [TestClass]
    public class chapter_10_shadows
    {
        [TestMethod]
        public void testNewCLass()
        {
            Assert.AreEqual(2, 2);
        }
        [TestMethod]
        public void Lightin_with_the_surface_in_shadow()
        {
            // had to look this up.
            //assume all the tests have the 2 following
            Material m = new Material();
            csharp_rt.Tuple position = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0, 0, -1);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light = Light.point_light(csharp_rt.Tuple.point(0, 0, -10), new Color(1, 1, 1));
            bool in_shadow = true;
            Color result = light.lighting(m,new Sphere(), position, eyev, normalv, in_shadow);
            Assert.AreEqual(Color.color(0.1, 0.1, 0.1), result);
        }

        [TestMethod]
        public void There_is_no_shadow_when_nothing_is_collinear_with_point_and_light()
        {
            World w = new World();
            w = w.default_world();
            csharp_rt.Tuple p = csharp_rt.Tuple.point(0, 10, 0);
            Assert.IsFalse(w.is_shadowed(p));
        }
        [TestMethod]
        public void The_shadow_when_an_object_is_between_the_point_and_the_light()
        {
            World w = new World();
            w = w.default_world();
            csharp_rt.Tuple p = csharp_rt.Tuple.point(10, -10, 10);
            Assert.IsTrue(w.is_shadowed(p));
        }
        [TestMethod]
        public void There_is_no_shadow_when_an_object_is_behind_the_light()
        {
            World w = new World();
            w = w.default_world();
            csharp_rt.Tuple p = csharp_rt.Tuple.point(-20, 20, -20);
            Assert.IsFalse(w.is_shadowed(p));
        }

        [TestMethod]
        public void There_is_no_shadow_when_an_object_is_behind_the_point()
        {
            World w = new World();
            w = w.default_world();
            csharp_rt.Tuple p = csharp_rt.Tuple.point(-2, 2, -2);
            Assert.IsFalse(w.is_shadowed(p));
        }
        [TestMethod]
        public void shade_hit_is_given_an_intersection_in_shadow()
        {
            World w = new World();
            w.light = Light.point_light(csharp_rt.Tuple.point(0, 0, -10), Color.color(1, 1, 1));
            Sphere s1 = new Sphere();
            Sphere s2 = new Sphere();
            s2.Set_Transform(Matrix.translation(0, 0, 10));
            w.shapeList = [s2, s1];
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 5), csharp_rt.Tuple.vector(0, 0, 1));
            Intersection i = new Intersection(4, s2);
            Computations comps = i.prepare_computations(r);
            Color c = w.shade_hit(comps);
            Assert.AreEqual(Color.color(.1, .1, .1), c);
        }

        [TestMethod]
        public void The_hit_should_offset_the_point()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            shape.Set_Transform(Matrix.translation(0, 0, 1));
            Intersection i = new Intersection(5, shape);
            Computations comps = i.prepare_computations(r);
            Assert.IsTrue(comps.over_point.z < -0.00001 / 2);
            Assert.IsTrue(comps.point.z > comps.over_point.z);
        }
    }

    [TestClass]
    public class chapter_9_refactoring
    {
        [TestMethod]
        public void chap_9_intro_test()
        {
            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void The_shapes_default_transform()
        {
            Shape s = new Test_shape();
            Assert.AreEqual(Matrix.identity(), s.Transform);
        }
        [TestMethod]
        public void The_default_material()
        {
            Shape s = new Test_shape();
            Material m = s.Material;
            Assert.AreEqual(m, new Material());
        }
        [TestMethod]
        public void Assiging_a_material()
        {
            Shape s = new Test_shape();
            Material m = new Material();
            m.ambient = 1;
            s.Material = m;
            Assert.AreEqual(m, s.Material);
        }
        [TestMethod]
        public void Intersecting_a_scaled_shape_with_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            //Shape s = new Test_shape();
            Test_shape s = new Test_shape();
            Test_shape ss = new Test_shape();
            s.Transform = Matrix.scaling(2, 2, 2);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(csharp_rt.Tuple.point(0, 0, -2.5), s.saved_ray.origin);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0, .5), s.saved_ray.direction);            
        }

        [TestMethod]
        public void Intersecting_a_translated_shape_with_a_ray()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Test_shape s = new Test_shape();
            s.Transform = Matrix.translation(5, 0, 0);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(csharp_rt.Tuple.point(-5,0,-5), s.saved_ray.origin);
            Assert.AreEqual(csharp_rt.Tuple.vector(0,0,1), s.saved_ray.direction);
        }

        [TestMethod]
        public void Computing_the_normal_on_a_translated_shape()
        {
            Test_shape s = new Test_shape();
            //s.Transform = Matrix.translation(0, 1, 0);
            s.Set_Transform(Matrix.translation(0, 1, 0));
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0, 1.70711, -0.70711));
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0.70711, -0.70711), n);
        }

        [TestMethod]
        public void Computing_the_normal_on_a_transformed_shape()
        {
            Test_shape s = new Test_shape();
            //s.Transform = Matrix.scaling(1, .5, 1) * Matrix.rotation_z(Math.PI / 5);
            s.Set_Transform(Matrix.scaling(1, .5, 1) * Matrix.rotation_z(Math.PI / 5));
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(0, Math.Sqrt(2) / 2, -Math.Sqrt(2)/ 2));
            Assert.AreEqual(csharp_rt.Tuple.vector(0, 0.97014, -0.24254), n);
        }

        [TestMethod]
        public void Testing_New_Sphere_Before_changing_Sphere()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere s = new Sphere();
            //var xs = s.old_intersect(r);
            Intersections xs = new Intersections(s.Intersect(r));
            Assert.AreEqual(4.0d, xs[0].t);
            Assert.AreEqual(6.0d, xs[1].t);
        }
        [TestMethod]
        public void Testing_New_Sphere_normal_at()
        {
            Sphere s = new Sphere();
            csharp_rt.Tuple n = s.normal_at(csharp_rt.Tuple.point(1, 0, 0));
            Assert.AreEqual(csharp_rt.Tuple.vector(1, 0, 0), n);
        }
    }

    [TestClass]
    public class Chapter_9_Plane
    {
        [TestMethod]
        public void The_Normal_of_the_plane_is_constant_everywhere()
        {
            Plane plane = new Plane();
            csharp_rt.Tuple n1 = plane.zzzz_Test_Local_Normal_At(csharp_rt.Tuple.point(0, 0, 0));
            csharp_rt.Tuple n2 = plane.zzzz_Test_Local_Normal_At(csharp_rt.Tuple.point(10, 0, -10));
            csharp_rt.Tuple n3 = plane.zzzz_Test_Local_Normal_At(csharp_rt.Tuple.point(-5, 0, 150));
            csharp_rt.Tuple ans = csharp_rt.Tuple.vector(0, 1, 0);
            Assert.AreEqual(ans, n1);
            Assert.AreEqual(ans, n2);
            Assert.AreEqual(ans, n3);
        }
        [TestMethod]
        public void Intersect_with_a_ray_parallel_to_the_plane()
        {
            Plane p = new Plane();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 10, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Intersections xs = new Intersections(p.Intersect(r));
            Assert.IsTrue(xs.is_empty());
        }

        [TestMethod]
        public void Intersect_with_a_coplanar_ray()
        {
            Plane p = new Plane();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Intersections xs = new Intersections(p.Intersect(r));
            Assert.IsTrue(xs.is_empty());
        }

        [TestMethod]
        public void A_ray_intersecting_a_plane_from_above()
        {
            Plane p = new Plane();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, -1, 0));
            //Intersections xs = new Intersections(p.Intersect(r));
            Intersections xs = new Intersections(p.zzzz_Test_Local_Intersect(r));
            Assert.AreEqual(1, xs.count());
            Assert.AreEqual(xs[0].t, 1);
            Assert.AreEqual(xs[0].tnObj, p);
        }

        [TestMethod]
        public void A_ray_intersecting_a_plane_from_below()
        {
            Plane p = new Plane();
            Ray r = new Ray(csharp_rt.Tuple.point(0, -1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            //Intersections xs = new Intersections(p.Intersect(r));
            Intersections xs = new Intersections(p.zzzz_Test_Local_Intersect(r));
            Assert.AreEqual(1, xs.count());
            Assert.AreEqual(xs[0].t, 1);
            Assert.AreEqual(xs[0].tnObj, p);
            //Assert.IsTrue(1 == 0);
        }

    }

    [TestClass]
    public class Chapter_10_Patterns
    {
        public Color white = new Color(1, 1, 1);
        public Color black = new Color(0, 0, 0);
        [TestMethod]
        public void Creating_a_striped_pattern()
        {
            // background
            // black = color(0,0,0)
            // white = color(1,1,1)
            // pattern seems to be set in material
            Striped_Pattern pattern = new Striped_Pattern(new Color(1,1,1),new Color(0,0,0));
            Assert.AreEqual(new Solid_Pattern(new Color(1, 1, 1)), pattern.a);
            Assert.AreEqual(new Solid_Pattern(new Color(0,0,0)), pattern.b);
        }
        [TestMethod]
        public void A_stripe_pattern_is_constant_in_y()
        {
            //Color white = new Color(1, 1, 1);
            //Color black = new Color(0,0,0);
            Striped_Pattern pattern = new Striped_Pattern(white, black);
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 1, 0)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 2, 0)));
        }

        [TestMethod]
        public void A_Stripe_Pattern_is_constant_in_z()
        {
            Striped_Pattern pattern = new Striped_Pattern(white, black);
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 0, 1)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 0, 2)));
        }
        [TestMethod]
        public void A_Stripe_Pattern_alternates_in_x()
        {
            Striped_Pattern pattern = new Striped_Pattern(white, black);
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(0.9, 0, 0)));
            Assert.AreEqual(black, pattern.Stripe_At(csharp_rt.Tuple.point(1, 0, 0)));
            Assert.AreEqual(black, pattern.Stripe_At(csharp_rt.Tuple.point(-0.1, 0, 0)));
            Assert.AreEqual(black, pattern.Stripe_At(csharp_rt.Tuple.point(-1, 0, 0)));
            Assert.AreEqual(white, pattern.Stripe_At(csharp_rt.Tuple.point(-1.1, 0, 0)));
        }
        [TestMethod]
        public void Lighting_with_a_pattern_applied()
        {
            Material m = new Material();
            m.pattern=new Striped_Pattern(white, black);
            m.ambient = 1;
            m.diffuse = 0;
            m.specular = 0;
            csharp_rt.Tuple eyev = csharp_rt.Tuple.vector(0, 0, -1);
            csharp_rt.Tuple normalv = csharp_rt.Tuple.vector(0, 0, -1);
            Light light = Light.point_light(csharp_rt.Tuple.point(0, 0, -10), Color.color(1, 1, 1));
            Color c1 = light.lighting(m,new Sphere(), csharp_rt.Tuple.point(0.9, 0, 0), eyev, normalv, false);
            Color c2 = light.lighting(m,new Sphere(), csharp_rt.Tuple.point(1.1, 0, 0), eyev, normalv,false);
            Assert.AreEqual(Color.color(1,1,1), c1);
            Assert.AreEqual(Color.color(0,0,0), c2);
        }

        [TestMethod]
        public void Stripes_with_an_object_transformation()
        {
            Sphere sobject = new Sphere();
            sobject.Set_Transform(Matrix.scaling(2, 2, 2));
            Striped_Pattern pattern = Striped_Pattern.default_pattern();
            Color c = pattern.Stripe_at_Object(sobject, csharp_rt.Tuple.point(1.5, 0, 0));
            Assert.AreEqual(white, c);
        }

        [TestMethod]
        public void Stripes_with_a_pattern_transformation()
        {
            Sphere obj = new Sphere();
            Striped_Pattern pattern = Striped_Pattern.default_pattern();
            pattern.Set_Pattern_Transform(Matrix.scaling(2, 2, 2));
            Color c = pattern.Stripe_at_Object(obj, csharp_rt.Tuple.point(1.5, 0, 0));
            Assert.AreEqual(white, c);
        }

        [TestMethod]
        public void Stripes_with_both_an_object_and_a_pattern_transformation()
        {
            Sphere obj = new Sphere();
            obj.Set_Transform(Matrix.scaling(2, 2, 2));
            Striped_Pattern pattern = Striped_Pattern.default_pattern();
            pattern.Set_Pattern_Transform(Matrix.translation(0.5, 0, 0));
            Color c = pattern.Stripe_at_Object(obj, csharp_rt.Tuple.point(2.5, 0, 0));
            Assert.AreEqual(white, c);
            // Test
        }
        [TestMethod]
        public void The_default_pattern_transformation()
        {
            Test_Pattern pattern = new Test_Pattern();
            Assert.AreEqual(Matrix.identity(), pattern.Transform);
        }
        [TestMethod]
        public void Assiging_a_transform()
        {
            Test_Pattern pattern = new Test_Pattern();
            pattern.Set_Transform(Matrix.translation(1, 2, 3));
            Assert.AreEqual(Matrix.translation(1,2,3), pattern.Transform);
        }

        [TestMethod]
        public void A_Pattern_with_an_object_transformation()
        {
            Sphere shape = new Sphere();
            shape.Set_Transform(Matrix.scaling(2, 2, 2));
            Test_Pattern pattern = new Test_Pattern();
            Color c = pattern.Pattern_At_Shape(shape, csharp_rt.Tuple.point(2, 3, 4));
            Assert.AreEqual(new Color(1,1.5,2),c);
        }
        [TestMethod]
        public void A_pattern_with_a_pattern_transformation()
        {
            Sphere shape = new Sphere();
            Test_Pattern pattern = new Test_Pattern();
            pattern.Set_Transform(Matrix.scaling(2, 2, 2));
            Color c = pattern.Pattern_At_Shape(shape, csharp_rt.Tuple.point(2, 3, 4));
            Assert.AreEqual(new Color(1, 1.5, 2), c);
        }
        [TestMethod]
        public void A_pattern_with_both_an_object_and_a_pattern_transformation()
        {
            Sphere shape = new Sphere();
            shape.Set_Transform(Matrix.scaling(2, 2, 2));
            Test_Pattern pattern= new Test_Pattern();
            pattern.Set_Transform(Matrix.translation(0.5, 1, 1.5));
            Color c = pattern.Pattern_At_Shape(shape, csharp_rt.Tuple.point(2.5, 3, 3.5));
            Assert.AreEqual(new Color(0.75, 0.5, 0.25), c);
        }

        [TestMethod]
        public void Testing_New_Shape_Stripped_Pattern()
        {
            Sphere obj = new Sphere();
            obj.Set_Transform(Matrix.scaling(2, 2, 2));
            Striped_Pattern pattern = Striped_Pattern.default_pattern();
            pattern.Set_Transform(Matrix.translation(0.5, 0, 0));
            Color c = pattern.Stripe_at_Object(obj, csharp_rt.Tuple.point(2.5, 0, 0));
            Assert.AreEqual(white, c);
        }

        [TestMethod]
        public void A_gradient_linearly_interpolates_between_colors()
        {
            Gradient_Pattern pattern = new Gradient_Pattern(white,black);
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(new Color(0.75, 0.75, 0.75), pattern.Pattern_At(csharp_rt.Tuple.point(0.25, 0, 0)));
            Assert.AreEqual(new Color(0.5, 0.5, 0.5), pattern.Pattern_At(csharp_rt.Tuple.point(0.5, 0, 0)));
            Assert.AreEqual(new Color(0.25, 0.25, 0.25), pattern.Pattern_At(csharp_rt.Tuple.point(0.75, 0, 0)));
        }

        [TestMethod]
        public void a_ring_shold_extend_in_both_x_and_z()
        {
            Ring_Pattern pattern = new Ring_Pattern(white,black);
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point(1, 0, 0)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 1)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point(0.708, 0, 0.708)));
        }
        [TestMethod]
        public void Checkers_should_repeat_in_x()
        {
            Checker_Pattern pattern = new Checker_Pattern(white,black);
            //csharp_rt.Tuple.point(0, 0, 0)
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0.99, 0, 0)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point(1.01, 0, 0)));
        }
        [TestMethod]
        public void Checkers_should_repeat_in_y()
        {
            Checker_Pattern pattern = new Checker_Pattern(white, black);
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0.99, 0)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point( 0, 1.01, 0)));
        }

        [TestMethod]
        public void Checkers_should_repeat_in_z()
        {
            Checker_Pattern pattern = new Checker_Pattern(white, black);
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0)));
            Assert.AreEqual(white, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 0.99)));
            Assert.AreEqual(black, pattern.Pattern_At(csharp_rt.Tuple.point(0, 0, 1.01)));
        }

        [TestMethod]
        public void testing_solid_pattern()
        {
            Solid_Pattern solid_color1 = new Solid_Pattern(new Color(1, 0, 0));
            //assert color is (red) at all points for a solid patten.
            Assert.AreEqual(new Color(1, 0, 0), solid_color1.Pattern_At(csharp_rt.Tuple.point(1, 0, 0)));
            Assert.AreEqual(new Color(1, 0, 0), solid_color1.Pattern_At(csharp_rt.Tuple.point(1, 1, 0)));
            Assert.AreEqual(new Color(1, 0, 0), solid_color1.Pattern_At(csharp_rt.Tuple.point(5, 1, 0)));
            Assert.AreEqual(new Color(1, 0, 0), solid_color1.Pattern_At(csharp_rt.Tuple.point(1, 5, 0)));
            Assert.AreEqual(new Color(1, 0, 0), solid_color1.Pattern_At(csharp_rt.Tuple.point(11, 5, 0)));
        }
    }

    [TestClass]
    public class Chapter_11_Reflections
    {
        [TestMethod]
        public void Reflectivty_for_the_default_material()
        {
            Material m = new Material();
            Assert.AreEqual(0.0d,m.reflective);
        }
        [TestMethod]
        public void Precompute_the_reflection_vector()
        {
            Plane shape = new Plane();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 1, -1), csharp_rt.Tuple.vector(0, -Math.Sqrt(2) / 2, Math.Sqrt(2) / 2));
            Intersection i = new Intersection(Math.Sqrt(2), shape);
            Computations comps = i.prepare_computations(r);
            Assert.AreEqual(csharp_rt.Tuple.vector(0, Math.Sqrt(2) / 2, Math.Sqrt(2) / 2), comps.reflectv);
        }
        [TestMethod]
        public void The_reflected_color_for_a_nonreflective_matieral()
        {
            World w = new World();
            w=w.default_world();
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = (Sphere)w.shapeList[1];//i know in default world this is a sphere...
            shape.Material.ambient = 1;
            Intersection i = new Intersection(1, shape);
            Computations comps = i.prepare_computations(r);
            Color color = w.reflected_color(comps);
            Assert.AreEqual(new Color(0, 0, 0), color);
        }

        [TestMethod]
        public void The_reflected_color_for_a_reflective_material()
        {
            World w = new World();
            w= w.default_world();
            Plane shape = new Plane();
            shape.Material.reflective = 0.5;
            shape.Set_Transform(Matrix.translation(0, -1, 0));
            w.shapeList.Append(shape);
            Ray r = new Ray(csharp_rt.Tuple.point(0,0,-3),csharp_rt.Tuple.vector(0,-Math.Sqrt(2)/2,Math.Sqrt(2)/2));
            Intersection i = new Intersection(Math.Sqrt(2), shape);
            Computations comps = i.prepare_computations(r);
            Color color = w.reflected_color(comps,7);
            Assert.AreEqual(new Color(0.19032, 0.2379, 0.14274), color);
        }

        [TestMethod]
        public void Shade_hit_with_a_reflective_materal()
        {
            World world = new World();
            world=world.default_world();
            Plane shape = new Plane();
            shape.Material.reflective = 0.5;
            shape.Set_Transform(Matrix.translation(0, -1, 0));
            world.shapeList.Append(shape);
            Ray r = new Ray(csharp_rt.Tuple.point(0,0,-3),csharp_rt.Tuple.vector(0,-Math.Sqrt(2)/2, Math.Sqrt(2)/2));
            Intersection i = new Intersection(Math.Sqrt(2), shape);
            Computations comps =i.prepare_computations(r);
            Color color = world.shade_hit(comps,12);
            Assert.AreEqual(new Color(0.87677, 0.92436, 0.82918), color);
        }
        //starting tests to avoid infinite recursion
        [TestMethod]
        public void color_at_with_mutaually_reflective_surfaces()
        {
            World w = new World();
            w.light = Light.point_light(csharp_rt.Tuple.point(0, 0, 0), new Color(1, 1, 1));
            Plane upper = new Plane();
            Plane lower = new Plane();
            lower.Material.reflective = 1;
            upper.Material.reflective = 1;
            lower.Set_Transform(Matrix.translation(0, -1, 0));
            upper.Set_Transform(Matrix.translation(0, 1, 0));
            //need to add method to add shapes easier...
            w.shapeList = [upper, lower];
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 1, 0));
            w.color_at(r);
            // note above currently doesn't fail. - but it causes issues...   
        }
        [TestMethod]
        public void The_reflected_color_at_the_maximum_recursive_depth()
        {
            World w = new World();
            w = w.default_world();
            Plane shape = new Plane();
            shape.Material.reflective = 0.5;
            shape.Set_Transform(Matrix.translation(0, -1, 0));
            w.shapeList.Append(shape);
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -3), csharp_rt.Tuple.vector(0, -Math.Sqrt(2) / 2, Math.Sqrt(2) / 2));
            Intersection i = new Intersection(Math.Sqrt(2), shape);
            Computations comps = i.prepare_computations(r);
            Color color = w.reflected_color(comps);//needs to look like w.reflected_color(comps,0)//int represents recursion depth remaining.
            Assert.AreEqual(color, new Color(0, 0, 0));
        }

        // Starting tests for refraction.
        [TestMethod]
        public void Transparency_and_Refractive_index_for_the_default_material()
        {
            Material m = new Material();
            Assert.AreEqual(0.0d, m.transparency);
            Assert.AreEqual(1.0d, m.refractive_index);
        }
        [TestMethod]
        public void a_helper_for_producing_a_sphere_with_a_glassy_material()
        {
            Sphere s = Sphere.Glass_Sphere();
            Assert.AreEqual(Matrix.identity(), s.Transform);
            Assert.AreEqual(1.0d, s.Material.transparency);
            Assert.AreEqual(1.5d, s.Material.refractive_index);
        }
        [TestMethod]
        public void test_looping_assert_areEqual()
        {
            int[] ans = { 1, 2, 3 };
            int[] test = { 1, 2, 4 };
            for (int i = 0; i < ans.Length; i++)
            {
                if(i<2)
                {
                    Assert.AreEqual(ans[i], test[i]);
                }
                else
                {
                    Assert.AreNotEqual(ans[i], test[i]);
                }
            }
        }

        [TestMethod]
        public void Finding_n1_and_n2_at_various_intersections()
        {
            /*
             *   
            public void Aggregating_intersections()        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
             */
            // A
            Sphere A = Sphere.Glass_Sphere();
            A.Set_Transform(Matrix.scaling(2, 2, 2));
            A.Material.refractive_index = 1.5;
            // B
            Sphere B = Sphere.Glass_Sphere();
            B.Set_Transform(Matrix.translation(0, 0, -0.25));
            B.Material.refractive_index = 2.0;
            // C
            Sphere C = Sphere.Glass_Sphere();
            C.Set_Transform(Matrix.translation(0, 0, 0.25));
            C.Material.refractive_index = 2.5;

            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -4), csharp_rt.Tuple.vector(0, 0, 1));
            //lots of my trouble with this was trying to remember how intersections was called...
            Intersections xs = new Intersections(new Intersection(2, A), new Intersection(2.75, B), new Intersection(3.25, C),new Intersection(4.75,B),new Intersection(5.25,C),new Intersection(6,A));
            //Intersections xs = new Intersections();//new Intersections(2:A,2.75:B,3.25:C,4.75:B,5.25:C,6:A)
            //Computations comps = xs.prepare_computations(...)

            double[] n1 = { 1.0, 1.5, 2.0, 2.5, 2.5, 1.5 };
            double[] n2 = { 1.5, 2.0, 2.5, 2.5, 1.5, 1.0 };
            //from test_looping_assert_areEqual() I know I can do the below.
            for (int i = 0;i< n1.Length; i++)
            {
                Computations comps = xs[i].prepare_computations(r,xs);//need to write xs to be something like xs[i].prepare_computations(r,xs);
                Assert.AreEqual(n1[i], comps.n1);//comps.n1
                Assert.AreEqual(n2[i], comps.n2);//comps.n2
                
            }

        }
        [TestMethod]
        public void The_refracted_color_with_an_opaque_surface()
        {
            World w = new World();
            w = w.default_world();
            Sphere shape = (Sphere)w.shapeList[0];//I know this is a Sphere
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Intersections xs = new Intersections(new Intersection(4,shape),new Intersection(6,shape));
            for(int i =0;i<2;i++)
            {
                Computations comps = xs[i].prepare_computations(r, xs);
                Color c = w.refracted_color(comps, 5);
                Assert.AreEqual(new Color(0,0,0), c);
            }
        }

        [TestMethod]
        public void The_refracted_color_at_the_maximum_recursive_depth()
        {
            World w = new World();
            w = w.default_world();
            w.shapeList[0].Material.transparency = 1;
            w.shapeList[1].Material.refractive_index = 0;
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Intersection shape4 = new Intersection(4, w.shapeList[0]);
            Intersection shape6 = new Intersection(6, w.shapeList[0]);
            Intersections xs = new Intersections(shape4, shape6);
            Computations comps = xs[0].prepare_computations(r, xs);
            Color c = w.refracted_color(comps, 0);
            Assert.AreEqual(new Color(0,0,0), c);
        }

        [TestMethod]
        public void The_refracted_color_under_total_internal_reflection()
        {
            World w = new World();
            w = w.default_world();
            w.shapeList[0].Material.transparency = 1;
            w.shapeList[1].Material.refractive_index = 1.5;
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, Math.Sqrt(2)/2), csharp_rt.Tuple.vector(0, 1, 0));
            Intersections xs = new Intersections(new Intersection(-Math.Sqrt(2) / 2, w.shapeList[0]), new Intersection(Math.Sqrt(2) / 2, w.shapeList[0]));
            Computations comps = xs[1].prepare_computations(r, xs);
            Assert.AreEqual(new Color(0, 0, 0), w.refracted_color(comps, 5));
        }
    }
}