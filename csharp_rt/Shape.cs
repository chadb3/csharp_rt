using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public abstract class Shape
    {
       // public csharp_rt.Tuple Origin {  get; set; }
        public Matrix Transform { get; set; }
        public Material Material { get; set; }
        public List<Intersection> Intersect(Ray RayIn)
        {
            Ray ray2 = RayIn.transform(this.Transform.inverse());
            List<Intersection> ret = new List<Intersection>();
            //Intersection one;
            //Intersection two;
            //double[] ins;
            csharp_rt.Tuple sphere_to_ray = ray2.origin - csharp_rt.Tuple.point(0, 0, 0);
            double a = csharp_rt.Tuple.dot(ray2.direction, ray2.direction);
            double b = 2 * csharp_rt.Tuple.dot(ray2.direction, sphere_to_ray);
            double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            double descriminate = Math.Pow(b, 2) - 4 * a * c;

            if (descriminate >= 0)
            {
                double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                //comment out for now.
                //ret.Add(new Intersection(/*ins[0]*/t1, this));
                //ret.Add(new Intersection(/*ins[1]*/t2, this));
            }
            return ret;
        }

    }

    public class Test_shape:Shape
    {
        //use abstract for shape.
        public Test_shape()
        {
            Material = new Material();
            Transform = Matrix.identity();
        }
    }
}
