using System;
using System.Collections.Generic;


namespace csharp_rt
{
    class CSharpRayTracer
    {
        static int Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            matrix_tests();
            Console.Out.WriteLine("ENDING APPLICATION");
            return 2989;
        }

        static void matrix_tests()
        {
            matrix mat = new matrix(5, 5);
            Console.Out.WriteLine(mat[3, 90]);
            mat[1, 1] = 0;
            mat[9, 9] = 9;
            mat[1, 2] = 9;
            Console.Out.WriteLine($"mat1[1,2]={mat[1, 2]}");
        }
    }
}
