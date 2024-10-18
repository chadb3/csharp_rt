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
            //imageTest();
            //imageTest2();
            //testImageBook();
            sphereShapeTest();
            anotherSphereTest();
            testingAnotherFailingTest();
            testingAnotherFailingTest1();
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
            floor.Transform = Matrix.scaling(10, 0.01, 10);
            floor.Material.color = new Color(1, 0.9, 0.9);
            floor.Material.specular = 0;

            Sphere left_wall = new Sphere();
            left_wall.Transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(-Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            left_wall.Material = floor.Material;

            Sphere right_wall= new Sphere();
            right_wall.Transform= Matrix.translation(0, 0, 5) * Matrix.rotation_y(Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            right_wall.Material = floor.Material;

            Sphere middle = new Sphere();
            middle.Transform = Matrix.translation(-0.5, 1, 0.5);
            middle.Material = new Material();
            middle.Material.color = new Color(0.1, 1, 0.5);
            middle.Material.diffuse = 0.7;
            middle.Material.specular = 0.3;

            Sphere right=new Sphere();
            right.Transform = Matrix.translation(1.5, 0.5, -0.5) * Matrix.scaling(0.5, 0.5, 0.5);
            right.Material = new Material();
            right.Material.color = new Color(0.5, 1, 0.1);
            right.Material.diffuse = 0.7;
            right.Material.specular = 0.3;

            Sphere left=new Sphere();
            left.Transform = Matrix.translation(-1.5, 0.33, -0.75) * Matrix.scaling(0.33, 0.33, 0.33);
            left.Material = new Material();
            left.Material.color = new Color(1, 0.8, 0.1);
            left.Material.diffuse = 0.7;
            left.Material.specular = 0.3;

            World world = new World();
            world.light = Light.point_light(csharp_rt.Tuple.point(-10, 10, -10), new Color(1, 1, 1));
            world.shapeList = [left_wall, left, right_wall, right, middle, floor];
            Camera c = new Camera(2050, 2050, Math.PI / 3);
            c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            Canvas image = c.render(world);
            image.set_file_name("book_image");
            image.canvas_to_P3_ppm();
            Console.WriteLine("finished book image pg107");
        }

        static void sphereShapeTest()
        {
            Sphere s = new Sphere();
            Intersection i = new Intersection(3.5d, s);
            Console.WriteLine(s == i.tnObj);
        }

        static void anotherSphereTest()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            Intersection i = new Intersection(4.0d, shape);
            Computations comps = i.prepare_computations(r);
            Console.WriteLine("comps.inside:{0}", comps.inside);
        }
        static void testingAnotherFailingTest()
        {
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -5), csharp_rt.Tuple.vector(0, 0, 1));
            Sphere shape = new Sphere();
            Intersection i = new Intersection(4, shape);
            //var = Computations struct
            var comps = i.prepare_computations(r);
            //Assert.AreEqual(i.t, comps.t);
            Console.WriteLine("{0} --- {1}", i.t, comps.t);
            Console.WriteLine("{0} <-> {1}", i.tnObj, comps.shapeObj);
        }

        static void testingAnotherFailingTest1()
        {
            World w = new World();
            w = w.default_world();
            Camera c = new Camera(11, 11, Math.PI / 2);
            csharp_rt.Tuple from = csharp_rt.Tuple.point(0, 0, -5);
            csharp_rt.Tuple to = csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple up = csharp_rt.Tuple.vector(0, 1, 0);
            c.transform = Matrix.view_transform(from, to, up);
            //rest of test
            Canvas image = c.render(w);
            //Assert.AreEqual(Color.color(0.38066, 0.47583, 0.2855), image.pixel_at(5, 5));
        }
    }
}
