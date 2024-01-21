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
        public Sphere()
        {
            this.radaii = 1;
            this.origin = Tuple.point(0, 0, 0);
        }

        public double[] intersect(Ray rayIn)
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
    }
}
