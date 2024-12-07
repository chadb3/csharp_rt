using CSharpRayTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
   
    public class Sphere:Shape
    {
        // original sphere had the following public variables
        // public double radaii; // not sure if this was used. I think I added it because the book mentioned it. I think the book mentioned needing a way to track unique spheres.
        // public Tuple origin; // not sure if this was used. I think I added it because the book mentioned it. I think the book mentioned needing a way to track unique spheres.
        // public Matrix transform; // can be accessed through the base(). needed
        // public Material material; // can be accessed through the base() needed.
        public Sphere():base()
        {
            // empty for now.
            // required
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
            /*csharp_rt.Tuple object_point = Transform.inverse() * point_in;
            csharp_rt.Tuple object_normal = object_point - csharp_rt.Tuple.point(0, 0, 0);
            csharp_rt.Tuple world_normal = Transform.inverse().transpose() * object_normal;
            world_normal.w = 0;
            return world_normal.normalize();*/
            return csharp_rt.Tuple.vector(point_in.x, point_in.y, point_in.z);
        }
        /// <summary>
        /// "helper" to get a glass_sphere
        /// call like Sphere my_glass_Sphere = Sphere.Glass_Sphere();
        /// </summary>
        /// <returns></returns>
        public static Sphere Glass_Sphere()
        {
            Sphere glass_sphere = new Sphere();
            // book has the the transform set to the identity matrix here, but it gets set above when i initialize a new sphere.
            // additionally the identity matrix is set for all "shapes" in the "Shape" parent class.
            glass_sphere.Material.transparency = 1.0d;
            glass_sphere.Material.refractive_index = 1.5d;
            return glass_sphere;
        }
    }
}
