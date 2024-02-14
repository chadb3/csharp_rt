using csharp_rt;
namespace z_ray_cast_sphere
{
    internal class sphereImage
    {
        static void Main(string[] args)
        {
            Canvas c;
            Console.WriteLine("Hello, World!");
            // origin of the ray
            csharp_rt.Tuple ray_origin = csharp_rt.Tuple.point(0, 0, -5);
            // wall location
            int wall_z = 10;
            // according to the math wall size can be 6 min
            // we set it to 7 here. 
            double wall_size = 7.0d;
            //size of the image 100x100
            int canvas_pixels = 100;
            // our pixle size based off of the size of the wall and
            double pixel_size = wall_size / canvas_pixels;
            //half the wall size. this assumes you are looking at the center of the circle. 
            double half = wall_size / 2;
        }
    }
}
