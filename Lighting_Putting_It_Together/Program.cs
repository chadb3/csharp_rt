using csharp_rt;
using System.Runtime.InteropServices;
namespace Z_Lighting_Putting_It_Together
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Project says to reuse code from the ray cast sphere
            // origin of the ray
            csharp_rt.Tuple ray_origin = csharp_rt.Tuple.point(0, 0, -5);
            // wall location
            int wall_z = 10;
            // according to the math wall size can be 6 min
            // we set it to 7 here. 
            double wall_size = 7.0d;
            //size of the image 100x100
            int canvas_pixels = 3000;
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
            Sphere shape = new Sphere();
            shape.material.color = new Color(1, 0.2, 1);
            csharp_rt.Tuple light_position = csharp_rt.Tuple.point(-10, 10, -10);
            csharp_rt.Color light_color = new csharp_rt.Color(1, 1, 1);
            Light light =new Light(light_position, light_color);

            //ray loop.
            Console.WriteLine("starting loop");
            for (int y = 0; y < canvas_pixels - 1; y++)
            {

                //y coordinate
                double world_y = half - pixel_size * y;
                for (int x = 0; x < canvas_pixels - 1; x++)
                {
                    //Console.WriteLine("{0}:{1}", x, y);
                    //x coord
                    double world_x = -half + pixel_size * x;
                    csharp_rt.Tuple position = csharp_rt.Tuple.point(world_x, world_y, wall_z);
                    Ray r = new Ray(ray_origin, (position - ray_origin).normalize());
                    
                    //try to get the intersect method to return a new intersections. 
                    Intersections xs = new Intersections(shape.intersect(r));
                    //Console.WriteLine("if:");
                    if (xs.canHit())
                    {
                        //Console.WriteLine("{0}:{1}", x, y);
                        //New for chap 6 project
                        csharp_rt.Tuple point = r.position(xs.hit().t);
                        csharp_rt.Tuple normal = xs.hit().obj.normal_at(point);
                        csharp_rt.Tuple eye = -r.direction;
                        color = light.old_lighting_old(xs.hit().obj.material, point, eye, normal);
                        //New for chap 6 project

                        //reused from earlier chapter. no changes
                        canvas.write_pixel(x, y, color);

                    }
                }
                Console.WriteLine("y: {0}", y);
            }
            Console.WriteLine("END! Check out the FILE!");
            canvas.canvas_to_P3_ppm();
        }
    }
}
