using csharp_rt;
namespace z_ray_cast_sphere
{
    internal class sphereImage
    {
        static void Main(string[] args)
        {
            
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
            //creating the canvas
            Canvas canvas = new Canvas(canvas_pixels, canvas_pixels);
            canvas.set_file_name("circle");
            // adding color red
            Color color = new Color(1, 0, 0);
            // adding sphere shape
            Sphere shape= new Sphere();
            //ray casting loop.
            Console.WriteLine("starting loop");
            for(int y=0;y< canvas_pixels-1;y++)
            {

                //y coordinate
                double world_y = half - pixel_size * y;
                for(int x=0;x< canvas_pixels - 1; x++)
                {
                    Console.WriteLine("{0}:{1}", x, y);
                    //x coord
                    double world_x=-half+pixel_size * x;
                    csharp_rt.Tuple position= csharp_rt.Tuple.point(world_x, world_y, wall_z);
                    Ray r = new Ray(ray_origin, (position-ray_origin).normalize());
                    //try to get the intersect method to return a new intersections. 
                    Intersections xs = new Intersections(shape.intersect(r));
                    Console.WriteLine("if:");
                    if (xs.canHit())
                    {
                        // don't think hit is really used.
                        //Intersection i = xs.hit();
                        canvas.write_pixel(x, y, color);
                        //Console.WriteLine(i);
                        //Console.Write("asdf");
                    }
                }
            }
            canvas.canvas_to_P3_ppm();
        }
    }
}
