﻿using CSharpRayTracer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

            testImageBook_plane();
            //test_checker_pattern_on_transformed_plane();
            //test_solid_pattern();
            ////generate_image_from_code_to_generate();
            //getColorForTest();
            testWhichIntersectionsIsCalled();
            //sphereShapeTest();
            //anotherSphereTest();
            //testingAnotherFailingTest();
            //testingAnotherFailingTest1();
            //testingFailingDefaultWorld();
            testRefractionUnitTestdebug();
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
            image.set_file_name("TestImage");
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
            Camera c = new Camera(500, 500, Math.PI / 3);
            c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            Canvas image = c.render(world);
            image.set_file_name("book_image_2");
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

        static void testingFailingDefaultWorld()
        {
            Light light = Light.point_light(csharp_rt.Tuple.point(-25, 10, -25), new Color(1, 1, 1));
            Sphere s1 = new Sphere();
            s1.Material.color = new Color(0.8, 1.0, 0.6);
            s1.Material.diffuse = 0.7;
            s1.Material.specular = 0.2;
            Sphere s2 = new Sphere();
           
            s2.Set_Transform(Matrix.scaling(0.5, 0.5, 0.5));
            World w = new World();
            w = w.default_world();

            //Assert.AreEqual(w.light, light);
            //Assert.AreEqual(s1, w.shapeList[0]);
            Console.WriteLine(s1 == w.shapeList[0]);
        }

        static void testImageBook_plane()
        {
            Console.WriteLine("starting book example Plane");
            /*Sphere floor = new Sphere();
            floor.Transform = Matrix.scaling(10, 0.01, 10);
            floor.Material.color = new Color(1, 0.9, 0.9);
            floor.Material.specular = 0;*/
            Plane floor = new Plane();
            //floor.Transform = Matrix.scaling(10, 0.01, 10);
            floor.Material.color = new Color(1, 0.9, 0.9);
            floor.Material.specular = 0;
            Gradient_Pattern org_red = new Gradient_Pattern(new Color(0.0d,.09d,0), new Color(1, 0, 0));
            org_red.Set_Transform(Matrix.rotation_x(2));
            floor.Material.pattern = new Striped_Pattern(new Checker_Pattern(new Color(1,1,1),org_red), new Color(1,0,0));
            //floor.Material.pattern = new Checker_Pattern(new Color(1, 0, 0), new Color(0, 0, 0));
            //floor.Material.pattern = new Ring_Pattern(new Color(1, 0, 0), new Color(0, 0, 1));
            floor.Material.pattern.Set_Transform(Matrix.translation(0, 0.00001d, 0));
            floor.Material.reflective = .12;

            Sphere left_wall = new Sphere();
            left_wall.Transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(-Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            left_wall.Material = floor.Material;


            Sphere right_wall = new Sphere();
            right_wall.Transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            right_wall.Material = floor.Material;

            Sphere middle = new Sphere();
            middle.Transform = Matrix.translation(-0.5, 1, 0.5);
            middle.Material = new Material();
            //middle.Material.color = new Color(0.1, 1, 0.5);
            //middle.Material.color = new Color(1, 1, 1); // Color
            middle.Material.color = new Color(.23, .55, .09);
            middle.Material.diffuse = 0.7;
            middle.Material.specular = 0.3;
            //middle.Material.pattern = new Ring_Pattern(new Color(1, 1, 1), new Color(0, 0, 1));//new Ring_Pattern(new Color(0, 0, 1)
            //middle.Material.pattern = new Ring_Pattern(new Color(1, 1, 1), new Checker_Pattern(new Color(0, 0, 1),new Color(1,0,1)));
            Gradient_Pattern aet = new Gradient_Pattern(new Color(0, 0, 1), new Color(0, 1, 0));
            Gradient_Pattern aet2 = new Gradient_Pattern(new Color(0, 0, 0), new Color(1, 0, 1));
            aet.Set_Transform(Matrix.scaling(2, 2, 2) *Matrix.rotation_z(5)*Matrix.rotation_x(Math.PI/2));
            middle.Material.pattern = new Ring_Pattern(new Color(1, 1, 1), new Checker_Pattern(aet, aet2));
            middle.Material.pattern.Transform = Matrix.scaling(.25, .25, .005);

            Sphere glass_sphere = Sphere.Glass_Sphere();
            glass_sphere.Transform= Matrix.translation(-0.5, 2, 0.5);

            Sphere z=new Sphere();
            z.Set_Transform(Matrix.translation(0, 0, 0)*Matrix.scaling(26,26,26)*Matrix.rotation_y(-Math.PI/2)*Matrix.rotation_z(3*Math.PI-.6));
            z.Material = new Material();
            z.Material.color = new Color(.1, 1, 1);
            z.Material.diffuse = 1;
            z.Material.specular = 1;
            z.Material.pattern = new Gradient_Pattern(new Color(254/255d,102/255d,7/255d), new Color(0, 0, .99d));

            Sphere right = new Sphere();
            right.Transform = Matrix.translation(1.5, 0.5, -0.5) * Matrix.scaling(0.5, 0.5, 0.5);
            right.Material = new Material();
            //right.Material.color = new Color(0.5, 1, 0.1);
            right.Material.color = new Color(0, 0, 1);
            right.Material.diffuse = 0.7;
            right.Material.specular = 0.3;
            right.Material.pattern = new Checker_Pattern(new Color(0, 0, 1), new Color(0.01, 0.02, 0.03));
            right.Material.reflective = 0.5;

            Sphere left = new Sphere();
            left.Transform = Matrix.translation(-1.5, 0.33, -0.75) * Matrix.scaling(0.33, 0.33, 0.33);
            left.Material = new Material();
            //left.Material.color = new Color(1, 0.8, 0.1);
            left.Material.color = new Color(1, 0, 0);
            left.Material.diffuse = 0.7;
            left.Material.specular = 0.3;
            left.Material.pattern = new Blended_Pattern();
            left.Material.pattern.Transform = Matrix.scaling(0.125, 0.25, 0.125);

            World world = new World();
            world.light = Light.point_light(csharp_rt.Tuple.point(-10, 10, -10), new Color(1, 1, 1));
            //world.shapeList = [left_wall, left, right_wall, right, middle, floor];
            world.shapeList = [left, right, middle, floor,z, glass_sphere];
            Camera c = new Camera(1024/2, 1024/2, Math.PI / 3);
            // default camera
            // c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            int ic = 2;
            //for(int i=0;i<500;i++)
            //{
                //c.transform = Matrix.view_transform(csharp_rt.Tuple.point((double)i/10, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
                c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0))*Matrix.rotation_y(.20);
                Canvas image = c.render(world);
                //String filename= ("book_image_{0}_plane",(float)i / 10);
                image.set_file_name(ic+"book_image_plane2");
                image.canvas_to_P3_ppm();
                ic++;
            //}
            Console.WriteLine("finished book image pg107");
            // Camera notes to put somewhere
            // c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, 0), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));
            // csharp_rt.Tuple.point(0, 1.5, -5) = (0,0, "zoom")
        }

        static void test_solid_pattern()
        {
            Striped_Pattern pattern = new Striped_Pattern(new Color(1, 1, 1), new Color(0, 0, 0));
            Solid_Pattern comp = new Solid_Pattern(new Color(1, 1, 1));
            Console.WriteLine("Pattern A: {0}\nTest: {1}", pattern.a, comp);
            Console.WriteLine(pattern.a.Equals(comp));
            //Assert.AreEqual(new Solid_Pattern(new Color(1, 1, 1)), pattern.a);
            //Assert.AreEqual(new Solid_Pattern(new Color(0, 0, 0)), pattern.b);

        }

        static void test_checker_pattern_on_transformed_plane()
        {
            World world = new World();
            world.light = Light.point_light(csharp_rt.Tuple.point(-10, 10, -10), new Color(1, 1, 1));
            Plane plane = new Plane();
            plane.Material.specular = 0.0;
            plane.Material.diffuse = 0.0;
            plane.Material.pattern = new Checker_Pattern(new Color(1, 1, 1), new Color(1, 0, 0.02));
            plane.Set_Transform(Matrix.rotation_y((Math.PI / 2.0d))*Matrix.rotation_z(Math.PI/2.0d));

            Plane plane2 = new Plane();
            plane2.Material.specular = 0.5;
            plane2.Material.diffuse = 1.0;
            plane2.Material.pattern = new Ring_Pattern(new Color(1, 0, 0), new Color(0, 0, 1));
            //plane2.Material.pattern.Set_Transform(Matrix.translation(0, 0.00001d, 0));
            //Source: https://forum.raytracerchallenge.com/thread/290/bands-noise

            Camera c = new Camera(320, 320, Math.PI / 3);
            c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0));// * Matrix.rotation_x(-Math.PI / 2.0d);// * Matrix.rotation_y(.20);

            world.shapeList = [plane2];
           Canvas image = c.render(world);
            image.set_file_name("ring_test_Checker_Plane_test");
            image.canvas_to_P3_ppm();
        }

        static void generate_image_from_code_to_generate()
        {
            // cc = Current Capabilities (of the my ray tracer)
            // this will be updated (along with the image) as more features are implemented  
            Console.WriteLine("starting Current Capabilities");
            Plane floor = new Plane();
            floor.Material.color = new Color(1, 0.9, 0.9);
            floor.Material.specular = 0;
            Gradient_Pattern org_red = new Gradient_Pattern(new Color(0.0d, .09d, 0), new Color(1, 0, 0));
            org_red.Set_Transform(Matrix.rotation_x(2));
            floor.Material.pattern = new Striped_Pattern(new Checker_Pattern(new Color(1, 1, 1), org_red), new Color(1, 0, 0));
            floor.Material.pattern.Set_Transform(Matrix.translation(0, 0.00001d, 0));
            floor.Material.reflective = .12;
            Sphere left_wall = new Sphere();
            left_wall.Transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(-Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            left_wall.Material = floor.Material;
            Sphere right_wall = new Sphere();
            right_wall.Transform = Matrix.translation(0, 0, 5) * Matrix.rotation_y(Math.PI / 4) * Matrix.rotation_x(Math.PI / 2) * Matrix.scaling(10, 0.01, 10);
            right_wall.Material = floor.Material;
            Sphere middle = new Sphere();
            middle.Transform = Matrix.translation(-0.5, 1, 0.5);
            middle.Material = new Material();
            middle.Material.color = new Color(.23, .55, .09);
            middle.Material.diffuse = 0.7;
            middle.Material.specular = 0.3;
            Gradient_Pattern aet = new Gradient_Pattern(new Color(0, 0, 1), new Color(0, 1, 0));
            Gradient_Pattern aet2 = new Gradient_Pattern(new Color(0, 0, 0), new Color(1, 0, 1));
            aet.Set_Transform(Matrix.scaling(2, 2, 2) * Matrix.rotation_z(5) * Matrix.rotation_x(Math.PI / 2));
            middle.Material.pattern = new Ring_Pattern(new Color(1, 1, 1), new Checker_Pattern(aet, aet2));
            middle.Material.pattern.Transform = Matrix.scaling(.25, .25, .005);
            Sphere z = new Sphere();
            z.Set_Transform(Matrix.translation(0, 0, 0) * Matrix.scaling(26, 26, 26) * Matrix.rotation_y(-Math.PI / 2) * Matrix.rotation_z(3 * Math.PI - .6));
            z.Material = new Material();
            z.Material.color = new Color(.1, 1, 1);
            z.Material.diffuse = 1;
            z.Material.specular = 1;
            z.Material.pattern = new Gradient_Pattern(new Color(254 / 255d, 102 / 255d, 7 / 255d), new Color(0, 0, .99d));
            Sphere right = new Sphere();
            right.Transform = Matrix.translation(1.5, 0.5, -0.5) * Matrix.scaling(0.5, 0.5, 0.5);
            right.Material = new Material();
            right.Material.color = new Color(0, 0, 1);
            right.Material.diffuse = 0.7;
            right.Material.specular = 0.3;
            right.Material.pattern = new Checker_Pattern(new Color(0, 0, 1), new Color(0.01, 0.02, 0.03));
            right.Material.reflective = 0.5;
            Sphere left = new Sphere();
            left.Transform = Matrix.translation(-1.5, 0.33, -0.75) * Matrix.scaling(0.33, 0.33, 0.33);
            left.Material = new Material();
            left.Material.color = new Color(1, 0, 0);
            left.Material.diffuse = 0.7;
            left.Material.specular = 0.3;
            left.Material.pattern = new Blended_Pattern();
            left.Material.pattern.Transform = Matrix.scaling(0.125, 0.25, 0.125);
            World world = new World();
            world.light = Light.point_light(csharp_rt.Tuple.point(-10, 10, -10), new Color(1, 1, 1));
            world.shapeList = [left, right, middle, floor, z];
            Camera c = new Camera(1024, 1024, Math.PI / 3);
            int ic = 11;
            c.transform = Matrix.view_transform(csharp_rt.Tuple.point(0, 1.5, -5), csharp_rt.Tuple.point(0, 1, 0), csharp_rt.Tuple.vector(0, 1, 0)) * Matrix.rotation_y(.20);
            Canvas image = c.render(world);
            image.set_file_name(ic + "cc");
            image.canvas_to_P3_ppm();
            ic++;
            Console.WriteLine("finished book image - Chapter 11 - Reflection and Refraction");

        }

        static void getColorForTest()
        {
            World w = new World();
            w.light = Light.point_light(csharp_rt.Tuple.point(0, 0, 0), new Color(1, 1, 1));
            Plane upper = new Plane();
            Plane lower = new Plane();
            lower.Material.reflective = 1;
            upper.Material.reflective = 1;
            lower.Set_Transform(Matrix.translation(0, -1, 0));
            upper.Set_Transform(Matrix.translation(0, 1, 0));
            //need to add method to add shapes easier...
            w.shapeList = [upper, lower];
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 1, 0));
            //Console.WriteLine(w.color_at(r));
            //Color c = w.color_at(r);  //this causes a stack overflow at the time of writing - do not uncomment until there is a limit on recursion. 
            //Console.WriteLine(c);

        }

        static void testWhichIntersectionsIsCalled()
        {
            Sphere s = Sphere.Glass_Sphere();
            Intersections xs = new Intersections(new Intersection(1, s));// looks like this one called the params method...
            Intersections xs2 = new Intersections(new Intersection(1, s), new Intersection(2, s));//looks like this one called " public Intersections(Intersection one, Intersection two)"
            Intersections xs3 = new Intersections(new Intersection(1, s), new Intersection(2, s), new Intersection(3, s));//looks like this one called public Intersections(params Intersection[] intersections)
            Intersections xs4 = new Intersections(new Intersection(1, s), new Intersection(2, s), new Intersection(3, s), new Intersection(4, s));//looks like this one called "public Intersections(Intersection one, Intersection two, Intersection three, Intersection four)"
            Intersections xs5 = new Intersections(new Intersection(1, s), new Intersection(2, s), new Intersection(3, s), new Intersection(4, s), new Intersection(5, s)); //this one called "public Intersections(params Intersection[] intersections)"
            /*
             * 1: calls params
             * 2: calls the one (1,2)
             * 3: calls params
             * 4: calls the one (1,2,3,4)
             * 5: calls params.
             *  Maybe I will try to comment out the other methods at some point to use the params one.
             */
        }

        static void testRefractionUnitTestdebug()
        {
            /*
             *   
            public void Aggregating_intersections()        {
            Sphere s = new Sphere();
            Intersection i1 = new Intersection(1, s);
            Intersection i2 = new Intersection(2, s);
             */
            Sphere A = Sphere.Glass_Sphere();
            A.Set_Transform(Matrix.scaling(2, 2, 2));
            A.Material.refractive_index = 1.5;
            Sphere B = Sphere.Glass_Sphere();
            B.Set_Transform(Matrix.translation(0, 0, -0.25));
            B.Material.refractive_index = 2.0;
            Sphere C = Sphere.Glass_Sphere();
            C.Set_Transform(Matrix.translation(0, 0, 0.25));
            C.Material.refractive_index = 2.5;
            Ray r = new Ray(csharp_rt.Tuple.point(0, 0, -4), csharp_rt.Tuple.vector(0, 0, 1));
            //lots of my trouble with this was trying to remember how intersections was called...
            Intersections xs = new Intersections(new Intersection(2, A), new Intersection(2.75, B), new Intersection(3.25, C), new Intersection(4.75, B), new Intersection(5.25, C), new Intersection(6, A));
            //Intersections xs = new Intersections();//new Intersections(2:A,2.75:B,3.25:C,4.75:B,5.25:C,6:A)
            //Computations comps = xs.prepare_computations(...)

            double[] n1 = { 1.0, 1.5, 2.0, 2.5, 2.5, 1.5 };
            double[] n2 = { 1.5, 2.0, 2.5, 2.5, 1.5, 1.0 };
            //from test_looping_assert_areEqual() I know I can do the below.
            for (int i = 0; i < n1.Length; i++)
            {
                Computations comps = xs[i].prepare_computations(r, xs);//need to write xs to be something like xs[i].prepare_computations(r,xs);
                Console.WriteLine($"n1: {comps.n1}\nn2: {comps.n2}\n");
                //Assert.AreEqual(n1[i], comps.n1);//comps.n1
                //Assert.AreEqual(n2[i], comps.n2);//comps.n2
            }
            Console.WriteLine("asdf");
        }
    }
}
