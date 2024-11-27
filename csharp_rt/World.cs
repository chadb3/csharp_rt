using csharp_rt;
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
        public Light light;
        //Light
        public World() 
        { 
            light= new Light();
            oldSphereList = new List<Sphere>();
            shapeList= new List<Shape>();
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

        public Color shade_hit(Computations comps_in)
        {
            Color ret = new Color();
            //Light light_to_call_lighting = new Light();
            //ret = light.old_lighting_old(comps_in.obj.material, comps_in.point, comps_in.eyev, comps_in.normalv);
            //ret = light.lighting(comps_in.old_obj.Material, comps_in.point, comps_in.eyev, comps_in.normalv,is_shadowed(comps_in.over_point)); <-------- Original
            //https://forum.raytracerchallenge.com/thread/204/avoid-noise-checkers-pattern-planes
            // pass in over_point instead of point. now I don't need epsilon but the image changed slightly
            // Note: there was some acne that was appearing again in my checker floor. I changed it back to point and it works without issues now go figure :/
            ret = light.lighting(comps_in.shapeObj.Material,comps_in.shapeObj, comps_in.point, comps_in.eyev, comps_in.normalv, is_shadowed(comps_in.over_point));
            return ret;
        }
        
        public Color color_at(Ray ray_in)
        {
            Color ret = new Color();
            Intersections hits = new Intersections(this.intersect_world(ray_in));
            hits.sort();
            // added hits.first_positive_index()!=-1
            // because first_positive_index() returns -1 if it there is no positive indexes.
            //if (hits.count() != 0 && hits.first_positive_index()!=-1)
            if (hits.count() != 0 && hits.first_positive_index()>=0)
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

        public Color reflected_color(Computations comps_in)
        {
            Color ret_color = new Color(0.5,0.75,1);
            return ret_color;
        }
    }
}
