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
        Console.WriteLine("Hello, World!");
        csharp_rt.Tuple center = csharp_rt.Tuple.point(0, 0, 0);
        Canvas c = new Canvas(100, 100);
        return 0;
    }

    public static csharp_rt.Tuple compute(csharp_rt.Tuple tupleIn)
    {
        csharp_rt.Tuple retVal=tupleIn;
        Matrix r = Matrix.rotation_y(3 * Math.PI / 6);
        return retVal;
    }

    public static csharp_rt.Tuple move(csharp_rt.Tuple tupleIn)
    { 
        return tupleIn; 
    }

}