// See https://aka.ms/new-console-template for more information
using csharp_rt;
//Console.WriteLine("Hello, World!");

// For each point
// Compute, multiply the x anx z components by this radius;
// and then move them to the center of the canvas by adding the cords of the center point.
// let x be x cords of the pixel and z be the y coordinate. 
class ClockFace
{

    public static int Main(string[] args)
    {
        Console.WriteLine("Hello World");
        int height = 100, width = 100;
        Canvas C = new Canvas(width+100, height+100);
        csharp_rt.Tuple add = csharp_rt.Tuple.vector(100, 0, 100);
        csharp_rt.Tuple k = csharp_rt.Tuple.point(0, 0, 0);
        csharp_rt.Tuple twelve = csharp_rt.Tuple.point(0, 0, 1);
        Matrix rotation = Matrix.rotation_y(Math.PI / 6d);
        double radius = 0.5d * height;
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
                Console.WriteLine(i);
                Console.WriteLine(twelve);
                C.write_pixel(k.x, k.z, Color.Green());
            }
            else
            {
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
       
        return 0;
    }
  

}