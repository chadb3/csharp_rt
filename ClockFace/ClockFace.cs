// See https://aka.ms/new-console-template for more information
using csharp_rt;
//Console.WriteLine("Hello, World!");

// For each point
// Compute, multiply the x anx z components by this radius;
// and then move them to the center of the canvas by adding the cords of the center point.
// let x be x cords of the pixel and z be the y coordinate. 
/// <summary>
/// // most of this exercise was trying to remember how canvas worked...
/// 1. Establish a center point (k)
/// 2. Create the twelve O'clock tuple. (book says (0,0,1))
/// 3. establish the rotation matrix as rotation_y(pi/6) each hour will be multiplied by this.
/// 4. establish a radius. book recomends 3/8*width for a square canvas. I moved it around in my example and it worked at multiple values and still looked good.
/// 5. made helper value add to add easier to the center of the canvas.
/// 6. did k=k+add to move k to the center.
/// 7. write k to the canvas in a green color.
/// 8. create a for loop until i==12
///     9. set k to be rotaion*twelve (original 12 at this point).
///     10. set twelve to k
///     11. k=k*radius;
///     12. k=k+add to move it to the center
///     13. then write the pixle to the canvas
///     14. loop to 12 compleating steps 9-13 for each.
/// 15. write canvas to ppm.
/// Note: Book had us align it along the z axis and the 12,3,6,9 appear to be angled. I re reviewed my old code, and this might be wrong as I didn't change colors for the 12,3,6,9 I just had it all green.
/// looking at the book this appears to be intended.
/// I did this example in the past along the y axis and it appeared to work as expected (12 o'clock at the top)
/// to do this you would use rotation_z(pi/6) and use the y for y (instead z for y).
/// </summary>
class ClockFace
{

    public static int Main(string[] args)
    {
        Console.WriteLine("Hello World");
        int height = 100, width = 100;
        Canvas C = new Canvas(width+100, height+100);
        csharp_rt.Tuple k = csharp_rt.Tuple.point(0, 0, 0);
        csharp_rt.Tuple twelve = csharp_rt.Tuple.point(0, 0, 1);
        Matrix rotation = Matrix.rotation_y(Math.PI / 6d);
        // Add is a helper Tuple value to add to the computed value to move it to the center.
        csharp_rt.Tuple add = csharp_rt.Tuple.vector(100, 0, 100);
        double radius = 0.9d * height;
        k = k + add;
        Console.WriteLine(k);
        C.write_pixel(k.x, k.z, csharp_rt.Color.Green());
        for(int i=0;i<12;i++)
        {
            k = rotation * twelve;
            twelve = k;
            k = k * radius;
            k = k + add;
            if (i%3==0/*twelve.x == 1 || twelve.y == 1 || twelve.z == 1 || i == 0*/)
            {
                Console.WriteLine("{0}",i);
                //Console.WriteLine(twelve);
                C.write_pixel(k.x, k.z, Color.Green());
            }
            else
            {
                Console.WriteLine("else: {0}",i);
                //Console.WriteLine(twelve);
                C.write_pixel(k.x, k.z, Color.RED());
            }
        }
        //test
        /*k = rotation * twelve;
        // make 12 be k
        twelve = k;
        k = k * radius;
        k = k + add;
        C.write_pixel(k.x, k.z, Color.RED());
        k = rotation * twelve;
        twelve = k;
        k = k * radius;
        k = k + add;
        C.write_pixel(k.x, k.z, Color.RED());*/
        //end test

        C.canvas_to_P3_ppm();
        testYAxis();
        return 0;
    }
    /// <summary>
    /// This is an experiment to try to get it so that 12,3,6,9 are green.
    /// </summary>
    static void testYAxis()
    {
        int height = 100, width = 100;
        Canvas C = new Canvas(width + 100, height + 100);
        C.set_file_name("y_axis.ppm");
        csharp_rt.Tuple k = csharp_rt.Tuple.point(0, 0, 0);
        csharp_rt.Tuple twelve = csharp_rt.Tuple.point(0, 1, 0);
        Matrix rotation = Matrix.rotation_z(Math.PI / 6d);
        csharp_rt.Tuple add = csharp_rt.Tuple.vector(100, 100,0);
        double radius = 0.9d * height;
        k = k * radius;
        k = k + add;
        //Console.WriteLine(k);
        C.write_pixel(k.x, k.y, csharp_rt.Color.Green());
        //twelve= twelve * radius;
        //twelve = twelve + csharp_rt.Tuple.vector(100, 100, 0);
        //this spawns the pixle at the bottom (6 o'clock). If I remember, everything on canvas is filpped. 
       // C.write_pixel(twelve.x, twelve.y, new Color(.34, .56,.82));
        for (int i = 0; i < 12; i++)
        {
            //Console.WriteLine(twelve);
            k = rotation * twelve;
            //int a = i <= 0 ? 1 : i;
            //Console.WriteLine("a: {0}",a);
           // k=Matrix.rotation_z(a*Math.PI/6)*twelve;
            twelve = k;
            //Console.WriteLine(twelve);
            k = k * radius;
            k = k + add;
            if (i % 3 == 0&&i>0/*twelve.x == 1 || twelve.y == 1 || twelve.z == 1 || i == 0*/)
            {
                Console.WriteLine("{0}", i);
                //Console.WriteLine(twelve);
                C.write_pixel(k.x, 200-k.y, Color.Green());
            }
            else if(i==0)
            {
                C.write_pixel(k.x, 200 - k.y, new Color(164,50,168));
            }
            else
            {
                Console.WriteLine("else: {0}", i);
                //Console.WriteLine(twelve);
                C.write_pixel(k.x, 200-k.y, Color.RED());
            }
        }
        C.canvas_to_P3_ppm();
    }
  

}