﻿// See https://aka.ms/new-console-template for more information
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
        Matrix rotation = Matrix.rotation_y(Math.PI / 6);
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
            if (k.x == 1 || k.y == 1 || k.z == 1 || i == 0)
            {
                C.write_pixel(k.x, k.z, Color.Green());
            }
            else
            {
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
        /*Console.WriteLine("Hello, World!");
        csharp_rt.Tuple center = csharp_rt.Tuple.point(0, 0, 0);
        csharp_rt.Tuple twelve = csharp_rt.Tuple.point(0, 0, 1);
        int height = 100;
        int width = 100;
        Canvas c = new Canvas(height, width);
        // we will add the width back in the move function...
        double midPoint = height / 2;
        //writing 12oclock to the canvas
        csharp_rt.Tuple CurrentPoint = twelve;

        double radius = 1 / 2 * height;
        //twelve = compute(twelve);
        //twelve = move(twelve,height,width);
        //pixle at 0 0 was a test print as I had a hard time finding the ppm file...
        //however i found that it is writing the center pixle correctly!
        //c.write_pixel(0, 0, Color.RED());
        c.write_pixel(50, 50, Color.Green());
        //c.write_pixel((int)twelve.x, (int)twelve.z, Color.RED());
        for(int i = 0;i<12;i++)
        {
            //Console.WriteLine("i:{0}",i);
            CurrentPoint = compute(twelve);
            twelve = CurrentPoint;
            Console.WriteLine("Current point before radius: {0}",CurrentPoint);
            CurrentPoint = CurrentPoint * radius;
            //twelve = twelve+midPoint;
            //Console.WriteLine(twelve);
            CurrentPoint = move(CurrentPoint, height, width);
            Console.WriteLine(CurrentPoint);
            c.write_pixel(Math.Abs((int)CurrentPoint.x), Math.Abs((int)CurrentPoint.z), Color.RED());
        }
        c.canvas_to_P3_ppm();*/
        return 0;
    }
    // this function returns the new pixle location after being rotated.
    public static csharp_rt.Tuple compute(csharp_rt.Tuple tupleIn)
    {
        csharp_rt.Tuple retVal=tupleIn;
        Matrix r = Matrix.rotation_y(3 * Math.PI / 6);
        return r*retVal;
    }

    // this function moves the pixles to the middle of the canvas
    public static csharp_rt.Tuple move(csharp_rt.Tuple tupleIn, int heightIn, int widthIn)
    {
        return tupleIn + csharp_rt.Tuple.point(heightIn/2, 0, widthIn/2) ; 
    }

}