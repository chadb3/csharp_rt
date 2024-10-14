using CSharpRayTracer;
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
            imageTest();
            imageTest2();
            testImageBook();
           
            return 2989;
        }


        static void imageTest()
        {
            Console.WriteLine("starting imageTest()");
            World world = new World();
            world = world.default_world();
            //Camera c = new Camera(512, 512, Math.PI / 2);
            Camera c = new Camera(125, 125, Math.PI / 2);
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, -5);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            c.transform = Matrix.view_transform(from, to, up);
            //rest of test
            Canvas image = c.render(world);
            image.canvas_to_P3_ppm();
            Console.WriteLine("ending imageTest()");
        }
        static void imageTest2()
        {
            Console.WriteLine("starting imageTest2()");
            World world = new World();
            world = world.default_world();
            //Camera c = new Camera(333, 333, Math.PI / 2);
            Camera c = new Camera(222, 222, 1.211);//1.211
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0,0,-1);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 1, 0);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            c.transform = Matrix.view_transform(from, to, up);
            //rest of test
            Canvas image = c.render(world);
            image.set_file_name("camera_move_test");
            image.canvas_to_P3_ppm();
            Console.WriteLine("ending imageTes2t()");
        }

        static void testImageBook()
        {
            Console.WriteLine("starting book example");
            Sphere floor = new Sphere();
            floor.transform = Matrix.scaling(10, 0.01, 10);
            floor.material.color = new Color(1, 0.9, 0.9);
            floor.material.specular = 0;

            Sphere left_wall = new Sphere();
            left_wall.transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(-Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            left_wall.material = floor.material;

            Sphere right_wall= new Sphere();
            right_wall.transform= Matrix.translation(0, 0, 5) * Matrix.rotation_y(Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            right_wall.material = floor.material;

            Sphere middle = new Sphere();
            middle.transform = Matrix.translation(-0.5, 1, 0.5);
            middle.material = new Material();
            middle.material.color = new Color(0.1, 1, 0.5);
            middle.material.diffuse = 0.7;
            middle.material.specular = 0.3;

            Sphere right=new Sphere();
            right.transform = Matrix.translation(1.5, 0.5, -0.5) * Matrix.scaling(0.5, 0.5, 0.5);
            right.material = new Material();
            right.material.color = new Color(0.5, 1, 0.1);
            right.material.diffuse = 0.7;
            right.material.specular = 0.3;

            Sphere left=new Sphere();
            left.transform = Matrix.translation(-1.5, 0.33, -0.75) * Matrix.scaling(0.33, 0.33, 0.33);
            left.material = new Material();
            left.material.color = new Color(1, 0.8, 0.1);
            left.material.diffuse = 0.7;
            left.material.specular = 0.3;

            World world = new World();
            world.light = Light.point_light(csharp_rt.Tuple.point(-10, 10, -10), new Color(1, 1, 1));
            world.sphereList = [left_wall, left, right_wall, right, middle, floor];
            Camera c = new Camera(2050, 2050, Math.PI / 3);
            c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            Canvas image = c.render(world);
            image.set_file_name("book_image");
            image.canvas_to_P3_ppm();
            Console.WriteLine("finished book image pg107");
        }


    }
}
