using System;
using System.Collections.Generic;


namespace csharp_rt
{
    class Z_MAIN
    {
        static int Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            //tests_01();
            //canvas_tests();
            matrix_tests();
            Console.Out.WriteLine("ENDING APPLICATION");
            return 2989;
        }
        static void tests_01()
        {
            tuple a = tuple.point(1, 2, 3);
            tuple b = tuple.vector(4, 5, 6);
            float ang2 = 5.5f;
            String ang = $"{ang2}";
            Console.Out.Write(ang);
            double a34 = Math.Sqrt(2);
            color one = new color(1, 0, 0);
            color two = new color(0, 1, 0);
            color three = new color(0, 0, 1);
            Console.Out.WriteLine("\n\n" + one.GetHashCode() + "\n" + two.GetHashCode() + "\n" + three.GetHashCode());
            color four = new color(.9, .01, .12);
            Console.Out.WriteLine(four.get_red_ppm());
            List<string> test_list = new List<string>();

            test_list.Add("asdf");
            for (int i = 0; i < 40; i++)
            {
                test_list.Add(a.ToString());
                test_list.Add(b.ToString());
            }
            a = tuple.point(5, 5, 5);
            foreach (string s in test_list)
            {
                Console.Out.WriteLine(s);
            }
            canvas c = new canvas(10, 20);
            c.write_pixel(2, 3, color.RED());
            Console.WriteLine(c.pixel_at(2, 300));
            c.canvas_to_P3_ppm();
        }

        static void canvas_tests()
        {
            canvas c = new canvas(10, 10);
            c.write_pixel(100, 100, color.Green());
            c.write_pixel(0, 0, color.Green());
            Console.Out.WriteLine($"Ke: {c.pixel_at(99, 99)}");
        }

        static void matrix_tests()
        {
            matrix mat = new matrix(5, 5);
            Console.Out.WriteLine(mat[3, 90]);
            mat[9, 9] = 5.56;
        }
    }
}
