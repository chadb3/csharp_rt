﻿using CSharpRayTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Sphere
    {
        public double radaii;
        public Tuple origin;
        public Matrix transform;
        public Material material;
        public Sphere()
        {
            this.radaii = 1;
            this.origin = Tuple.point(0, 0, 0);
            transform = Matrix.identity();
            this.material = new Material();
        }
        /// <summary>
        /// Old intersect.
        /// book had us do the old switcheroo on an established function
		/// instead of following the book. I just kept the old function while I worked on the new one.
        /// </summary>
        /// <param name="rayIn"></param>
        /// <returns></returns>
        public double[] old_intersect(Ray rayIn)
        {
            Tuple sphere_to_ray = rayIn.origin - Tuple.point(0, 0, 0);
            double a = Tuple.dot(rayIn.direction, rayIn.direction);
            double b = 2 * Tuple.dot(rayIn.direction, sphere_to_ray);
            double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            double descriminate = Math.Pow(b,2) - 4 * a * c;
            if (descriminate < 0)
            {
                return [];
            }
            else
            {
                double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                return [t1, t2];
            }
        }

        public List<Intersection> intersect(Ray rayIn)
        {
            Ray ray2 = rayIn.transform(this.transform.inverse());
            List<Intersection> ret = new List<Intersection>();
            //Intersection one;
            //Intersection two;
            //double[] ins;
            Tuple sphere_to_ray = ray2.origin - Tuple.point(0, 0, 0);
            double a = Tuple.dot(ray2.direction, ray2.direction);
            double b = 2 * Tuple.dot(ray2.direction, sphere_to_ray);
            double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            double descriminate = Math.Pow(b, 2) - 4 * a * c;
            //if (descriminate < 0)
            //{
            //ins= [];
            //ret.Add(new Intersection(double.NaN, this));
            //}
            //else
            //{
            //double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
            //double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
            //ins= [t1, t2];
            //one = 
            //ret.Add(new Intersection(/*ins[0]*/t1, this));
            //ret.Add(new Intersection(/*ins[1]*/t2, this));
            //}
            if (descriminate >= 0)
            {
                double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                ret.Add(new Intersection(/*ins[0]*/t1, this));
                ret.Add(new Intersection(/*ins[1]*/t2, this));
            }
            return ret;
        }
        public void set_transform(Matrix transform)
        {
            this.transform = transform;
        }

        public csharp_rt.Tuple normal_at(csharp_rt.Tuple world_point)
        {
            csharp_rt.Tuple object_point = this.transform.inverse()*world_point;
            csharp_rt.Tuple object_normal = object_point - csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple world_normal = this.transform.inverse().transpose() * object_normal;
            world_normal.w = 0;
            return world_normal.normalize();
            //looks like I skipped transpose in the matrix section on page 33 by accident.
            // and luck would have it that it was only mentioned once and not used again until now... ..
            //csharp_rt.Tuple world_normal = this.transform.inverse()
            //return (pointIn - csharp_rt.Tuple.point(0, 0, 0).normalize());
            //return (world_point - csharp_rt.Tuple.point(0, 0, 0).normalize());
        }
        public static bool operator ==(Sphere l, Sphere r)
        {
            bool result = false;
            if(l.radaii==r.radaii)
            {   
                //radaii are equal
                if(l.origin==r.origin)
                {
                    //result = true;
                    //need to get this one to pass
                    if (r.transform == l.transform)
                    {
                        //result = true;
                        if(l.material==r.material)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
        public static bool operator !=(Sphere l, Sphere r)
        {
            return !(l == r);
        }

        public override bool Equals(object r)
        {
            return this==(Sphere)r;
        }
        /// <summary>
        /// to do.
        /// added to clear warnings. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    // Temp new Sphere class to build this while not breaking my old tests.
    // I will swap them out when eventually. and make the current Sphere Old_Sphere and New_Sphere Sphere.
    public class New_Sphere:Shape
    {
        // original sphere had the following public variables
        // public double radaii; // not sure if this was used. I think I added it because the book mentioned it. I think the book mentioned needing a way to track unique spheres.
        // public Tuple origin; // not sure if this was used. I think I added it because the book mentioned it. I think the book mentioned needing a way to track unique spheres.
        // public Matrix transform; // can be accessed through the base(). needed
        // public Material material; // can be accessed through the base() needed.
        public New_Sphere():base()
        {

        }

        protected override List<Intersection> Local_Intersect(Ray ray_in)
        {
            // ray_in is already transformed, and inversed
            List<Intersection> result = new List<Intersection>();
            Tuple sphere_to_ray = ray_in.origin - Tuple.point(0, 0, 0);
            double a = Tuple.dot(ray_in.direction, ray_in.direction);
            double b = 2 * Tuple.dot(ray_in.direction, sphere_to_ray);
            double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            double descriminate = Math.Pow(b, 2) - 4 * a * c;
            if (descriminate >= 0)
            {
                double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                result.Add(new Intersection(/*ins[0]*/t1, this));
                //need to fix Intsection lol
                result.Add(new Intersection(/*ins[1]*/t2, this));
            }
            return result;
        }

        protected override csharp_rt.Tuple Local_Normal_At(csharp_rt.Tuple point_in)
        {
            csharp_rt.Tuple object_point = Transform.inverse() * point_in;
            csharp_rt.Tuple object_normal = object_point - csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple world_normal = Transform.inverse().transpose() * object_normal;
            world_normal.w = 0;
            return world_normal.normalize();
        }
    }
}
