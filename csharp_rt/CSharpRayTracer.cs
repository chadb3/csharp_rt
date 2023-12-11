using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace csharp_rt
{
    class CSharpRayTracer
    {
        static int Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            matrix_tests();
            Console.Out.WriteLine("ENDING APPLICATION");
            test_mult();
            testSubMat();
            testSubMat2();
            return 2989;
        }

        static void matrix_tests()
        {
            Matrix mat = new Matrix(5, 5);
            Console.Out.WriteLine(mat[3, 90]);
            mat[1, 1] = 0;
            mat[9, 9] = 9;
            mat[1, 2] = 9;
            Console.Out.WriteLine($"mat1[1,2]={mat[1, 2]}");
            
        }

        static void test_mult()
        {
            Matrix A = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
            Matrix B = new Matrix(new double[,] { { -2, 3, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } });
            var c = A * B;
        }
        /// <summary>
        /// my test to examine the submat function
        /// </summary>
        static void testSubMat()
        {
            Matrix A = new Matrix(new double[,] { { -6, 1, 1, 6 }, { -8, 5, 8, 6 }, { -1, 0, 8, 2 }, { -7, 1, -1, 1 } });
            Matrix B = A.subMat(2, 1);
            Console.WriteLine("done");
        }
        /// <summary>
        /// This was to test the oddities I was getting with cofactor.
        /// I found that I had accidently hard coded my minor to get the determinant of submatrix(1,0). I changed it to (row,col) from (1,0) resolving the issue.
        /// This was becuase I only had one unit test to test for minor that was the (1,0) value. 
        /// </summary>
        static void testSubMat2()
        {
            Matrix A = new Matrix(new double[,] { { 3, 5, 0 }, { 2, -1, -7 }, { 6, -1, 5 } });
            Matrix subA = A.subMat(0, 0);
            Console.WriteLine(subA.det());
            Matrix subA2=A.subMat(1, 0);
            Console.WriteLine("cheese");
        }
    }
}
