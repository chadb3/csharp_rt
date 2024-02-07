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
        public Sphere()
        {
            this.radaii = 1;
            this.origin = Tuple.point(0, 0, 0);
            transform = Matrix.identity();
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
            //Ray ray2=
            List <Intersection> ret=new List<Intersection>();
            //Intersection one;
            //Intersection two;
            double[] ins;
            Tuple sphere_to_ray = rayIn.origin - Tuple.point(0, 0, 0);
            double a = Tuple.dot(rayIn.direction, rayIn.direction);
            double b = 2 * Tuple.dot(rayIn.direction, sphere_to_ray);
            double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            double descriminate = Math.Pow(b, 2) - 4 * a * c;
            if (descriminate < 0)
            {
                ins= [];
                ret.Add(new Intersection(ins[0], this));
            }
            else
            {
                double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                //ins= [t1, t2];
                //one = 
                ret.Add(new Intersection(/*ins[0]*/t1, this));
                ret.Add(new Intersection(/*ins[1]*/t2, this));
            }
            return ret;
        }
        public void set_transform(Matrix transform)
        {
            this.transform = transform;
        }
    }
}
