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
        public List<Sphere> sphereList;
        public Light light;
        //Light
        public World() 
        { 
            light= new Light();
            sphereList = new List<Sphere>();
        }

        public World default_world()
        {
            Light light = new Light(csharp_rt.Tuple.point(-10,10,-10),new csharp_rt.Color(1,1,1));
            Sphere s1 = new Sphere();
            s1.material.color = new csharp_rt.Color(0.8, 1.0,0.6);
            s1.material.diffuse = 0.7;
            s1.material.specular = 0.2;
            Sphere s2=new Sphere();
            //Console.WriteLine($"transform before {s2.transform[0, 2]}");
            //s2.transform.scaling_ns(0.5, 0.5, 0.5);
            //s2.set_transform
            s2.set_transform(Matrix.scaling(0.5, 0.5, 0.5));
            //Console.WriteLine($"transform after {s2.transform[0, 2]}");
            //Console.WriteLine(s2.transform);
            sphereList.Add(s1);
            sphereList.Add(s2);
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
            foreach (Sphere i in sphereList)
            {
                //Console.WriteLine(i);
                // test print notifications
                //Console.WriteLine("Test Print - Please remove when done testing - in World.cs");
                foreach (Intersection ix in i.intersect(ray_in))
                {
                    // Test Print                    
                    //Console.WriteLine(ix.t);
                    results.Add(ix);
                }
                //results.Add(i.intersect(ray_in));
            }
            
            return results;
        }

        public Color shade_hit(Computations comps_in)
        {
            Color ret = new Color();
            //Light light_to_call_lighting = new Light();
            ret = light.lighting(comps_in.obj.material, comps_in.point, comps_in.eyev, comps_in.normalv);
            return ret;
        }
        
        public Color color_at(Ray ray_in)
        {
            Color ret = new Color();
            Intersections hits = new Intersections(this.intersect_world(ray_in));
            hits.sort();
            //Console.WriteLine("Hits Count: {0}", hits.count());
            if (hits.count() != 0)
            {
                Computations comp = hits[hits.first_positive_index()].prepare_computations(ray_in);
                //foreach (Intersection ix in hits)
                //{
                // Test Prints
                /*Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[0].prepare_computations(ray_in)), hits[0]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[1].prepare_computations(ray_in)), hits[1]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[2].prepare_computations(ray_in)), hits[2]);
                Console.WriteLine("color: {0}    t:{1}", this.shade_hit(hits[3].prepare_computations(ray_in)), hits[3]);*/
                //}
                ret = this.shade_hit(comp);
            }
            return ret;
        }
    }
}
