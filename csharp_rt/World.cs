﻿using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class World
    {
        //Object - not yet implimented 
        //Sphere
        public List<Shape> shapeList;// = new List<Shape>();
        public List<Sphere> oldSphereList;
        //Light
        public Light light;
        // Recursion Depth;
        //int maxDepth;
        public World() 
        { 
            light= new Light();
            oldSphereList = new List<Sphere>();
            shapeList= new List<Shape>();
            //maxDepth = 6;
        }

        public World default_world()
        {
            Light light = new Light(csharp_rt.Tuple.point(-10,10,-10),new csharp_rt.Color(1,1,1));
            Sphere s1 = new Sphere();
            s1.Material.color = new csharp_rt.Color(0.8, 1.0,0.6);
            s1.Material.diffuse = 0.7;
            s1.Material.specular = 0.2;
            Sphere s2=new Sphere();
            //Console.WriteLine($"transform before {s2.transform[0, 2]}");
            //s2.transform.scaling_ns(0.5, 0.5, 0.5);
            //s2.set_transform
            s2.Set_Transform(Matrix.scaling(0.5, 0.5, 0.5));
            //Console.WriteLine($"transform after {s2.transform[0, 2]}");
            //Console.WriteLine(s2.transform);
            shapeList.Add(s1);
            shapeList.Add(s2);
            this.light = light;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray_in"></param>
        /// <returns>a list of Intersection: results</returns>
        public List<Intersection> intersect_world(Ray ray_in)
        {
            List<Intersection> results = new List<Intersection>();
            //test
            foreach (Shape i in shapeList)
            {
                //Console.WriteLine(i);
                // test print notifications
                //Console.WriteLine("Test Print - Please remove when done testing - in World.cs");
                foreach (Intersection ix in i.Intersect(ray_in))
                {
                    // Test Print                    
                    //Console.WriteLine(ix.t);
                    results.Add(ix);
                }
                //results.Add(i.intersect(ray_in));
            }
            
            return results;
        }
        /// <summary>
        /// computes shade
        /// </summary>
        /// <param name="comps_in"></param>
        /// <param name="remaining"></param>
        /// <returns>color</returns>
        public Color shade_hit(Computations comps_in, int remaining = 0)
        {
            //Color surface = new Color();
            //Light light_to_call_lighting = new Light();
            //ret = light.old_lighting_old(comps_in.obj.material, comps_in.point, comps_in.eyev, comps_in.normalv);
            //ret = light.lighting(comps_in.old_obj.Material, comps_in.point, comps_in.eyev, comps_in.normalv,is_shadowed(comps_in.over_point)); <-------- Original
            //https://forum.raytracerchallenge.com/thread/204/avoid-noise-checkers-pattern-planes
            // pass in over_point instead of point. now I don't need epsilon but the image changed slightly
            // Note: there was some acne that was appearing again in my checker floor. I changed it back to point and it works without issues now go figure :/
            Color surface = light.lighting(comps_in.shapeObj.Material,comps_in.shapeObj, comps_in.point, comps_in.eyev, comps_in.normalv, is_shadowed(comps_in.over_point));
            Color reflected = reflected_color(comps_in, remaining);
            return surface+reflected;
        }
        /// <summary>
        /// returns color at ray
        /// takes in a ray and an int remaining (for recursion) that is default is still 0 so you can still run it like world.color_at(ray_in)
        /// </summary>
        /// <param name="ray_in"></param>
        /// <param name="remaining"></param>
        /// <returns></returns>
        public Color color_at(Ray ray_in, int remaining = 0)
        {
            Color ret = new Color();
            Intersections hits = new Intersections(this.intersect_world(ray_in));
            hits.sort();
            // added hits.first_positive_index()!=-1
            // because first_positive_index() returns -1 if it there is no positive indexes.
            //if (hits.count() != 0 && hits.first_positive_index()!=-1)
            if (hits.count() != 0 && hits.first_positive_index()>=0)
            {
                Computations comp = hits[hits.first_positive_index()].prepare_computations(ray_in,hits);
                //foreach (Intersection ix in hits)
                //{
                // Test Prints
                /*Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[0].prepare_computations(ray_in)), hits[0]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[1].prepare_computations(ray_in)), hits[1]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[2].prepare_computations(ray_in)), hits[2]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[3].prepare_computations(ray_in)), hits[3]);*/
                //}
                ret = this.shade_hit(comp,remaining);
            }
            return ret;
        }

        public bool is_shadowed(csharp_rt.Tuple point_in)
        {
            csharp_rt.Tuple v = light.position-point_in;
            double distance = v.magnitude();
            csharp_rt.Tuple direction = v.normalize();
            Ray r = new Ray(point_in, direction);
            Intersections intersections = new Intersections(intersect_world(r));
            Intersection h = intersections.hit();
            if (h.nothing==false &&h.t<distance)
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }
        /// <summary>
        /// calculates the reflected color
        /// </summary>
        /// <param name="comps_in">Takes in a computation</param>
        /// <param name="remaining">Takes in an int. default value of 0 to not break past tests.</param>
        /// <returns></returns>
        public Color reflected_color(Computations comps_in, int remaining=0)
        {
            Ray reflect_ray;// = new Ray(csharp_rt.Tuple.point(0,0,0),csharp_rt.Tuple.vector()
            Color ret_color = new Color(0, 0, 0);
            if(comps_in.shapeObj.Material.reflective==0)
            {
                return ret_color;
            }
            else
            {
                if( remaining<=0)
                {
                    return new Color(0, 0, 0);
                }
                reflect_ray = new Ray(comps_in.over_point, comps_in.reflectv);
                ret_color = this.color_at(reflect_ray, remaining-1);
            }
            return ret_color * comps_in.shapeObj.Material.reflective;
        }

        public Color refracted_color(Computations comps_in, int remaining=0)
        {
            var n_ratio=comps_in.n1+comps_in.n2;
            var cos_i = comps_in.eyev.dot(comps_in.normalv);
            var sin2_testc = Math.Pow(n_ratio,2)*(1-Math.Pow(cos_i,2));
            //Color ret_color = new Color(1, 1, 1);
            if (comps_in.shapeObj.Material.transparency == 0|| sin2_testc > 1||remaining==0)
            {
                return new Color(0, 0, 0);
            }
           // else if(sin2_testc>1)
            //{
                //return new Color(0, 0, 0);
           // }
            //new Color(1, 1, 1); is a temp value. 
            return new Color(1, 1, 1);
        }

        
    }
}
