using System;
using System.Collections.Generic;
using System.Linq;
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
            testInverse();
            testInverseEquality();
            tupleTest2Equality();
            putting_it_together();
            testing_intersections();
            //array_test();
            //hit_test1();
            test_intersection_equality();
            test_intersection_greater_than();
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
        static void testInverse()
        {
            Console.WriteLine("starting testInverse");
            Matrix A = new Matrix(new double[,] { { -5, 2, 6, -8 }, { 1, -5, 1, 8 }, { 7, 7, -6, -7 }, { 1, -3, 7, 4 } });
            Matrix bShould = new Matrix(new double[,] { { 0.21805, 0.45113, 0.24060, -0.04511 }, { -0.80827, -1.45677, -0.44361, 0.52068 }, { -0.07895, -0.22368, -0.05263, 0.19737 }, { -0.52256, -0.81391, -0.30075, 0.30639 } });
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            for (int i=0;i<A.x_size;i++)
            {
                for(int j = 0; j < A.y_size; j++)
                {
                    Console.WriteLine(A.cofactor(i, j));
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            Matrix B = A.inverse();
            Console.WriteLine("Hello");
        }

        static void testInverseEquality()
        {
            Console.WriteLine("starting testInverseEquality");
            Matrix A = new Matrix(new double[,] { { -5, 2, 6, -8 }, { 1, -5, 1, 8 }, { 7, 7, -6, -7 }, { 1, -3, 7, 4 } });
            Matrix B = A.inverse();
            Matrix bShould = new Matrix(new double[,] { { 0.21805, 0.45113, 0.24060, -0.04511 }, { -0.80827, -1.45677, -0.44361, 0.52068 }, { -0.07895, -0.22368, -0.05263, 0.19737 }, { -0.52256, -0.81391, -0.30075, 0.30639 } });
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            for (int i = 0; i < A.x_size; i++)
            {
                for (int j = 0; j < A.y_size; j++)
                {
                    Console.WriteLine($"({B[i, j]} == {bShould[i,j]} ?) -> {compareDobules(B[i, j], bShould[i, j])}");
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        static bool compareDobules(double l, double r)
        {
            bool ret=false;

            return ret;
        }

        static void tupleTest()
        {
            Tuple A = new Tuple(1, 2, 3, 4);
            Tuple B = Tuple.point(1, 2, 3);
        }

        static void tupleTest2Equality()
        {
            Tuple A = new Tuple(1, 2, 3, 4);
            Tuple B = new Tuple(1, 2, 3, 4);
            if(A == B)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
        }

        static void matrixChaining()
        {
            Tuple p = Tuple.point(1, 0, 1);
            Matrix T = Matrix.identity().rotation_x_ns(Math.PI / 2).scaling_ns(5, 5, 5).translation_ns(10, 5, 7);
        }

        static void putting_it_together()
        {
            //for each point
            // compute, multiply the x anx z components by this radius;
            //and then move them to the center of the canvas by adding the cords of the center point.
            // let x be x cords of the pixel and z be the y coordinate. 
            Console.WriteLine("This should print a cirle with dots using Matrix");
            Tuple center = Tuple.point(0, 0, 0);
            Tuple twelve = Tuple.point(0, 0, 1);
            int height = 200;
            int width = 200;
            Matrix r = Matrix.rotation_z(3 * Math.PI / 6);
            Canvas c = new Canvas(height, width);
            Tuple a = r * twelve;
            c.write_pixel(height / 2, width / 2, Color.Green());
            c.write_pixel(twelve.x,twelve.y, Color.RED());
            c.canvas_to_P3_ppm();
        }
        static void testing_intersections()
        {
            Console.WriteLine("Testing Intersectionsdfdfdfdfdfdfdfdfdfdfdfdfdfd:");
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
            Intersections xs = new Intersections(i1, i2);
            Console.WriteLine("Testing Intersectionsdfdfdfdfdfdfdfdfdfdfdfdfdfd:");
            Console.WriteLine(xs.t[0]);
            Console.WriteLine("Count:{0}", xs.count());
            Console.WriteLine("xs[0] using new array notation: {0}",xs[0].t);
            Console.WriteLine("xs[1] using new array notation: {0}", xs[1].t);
            //Console.WriteLine(xs[0]);
        }
        static void array_test()
        {
            int[] a = new int[0];
            a.Append(4);
            a.Append(5);
            Console.WriteLine(a.Length);
            
        }

        static void hit_test1()
        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
            Intersections xs = new Intersections(i1, i2);
            Intersection i = xs.hit();
            
        }
        static void test_intersection_equality()
        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1.01d, s);
            Intersection i2 = new Intersection(1.01d, s);
            //Intersections xs = new Intersections(i1, i2);
            Console.WriteLine(i1 == i2);
        }

        static void test_intersection_greater_than()
        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1.01d, s);
            Intersection i2 = new Intersection(1.02d, s);
            Console.WriteLine(i2>i1);
        }

    }
}
