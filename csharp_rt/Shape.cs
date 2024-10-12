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
            //List<Intersection> ret = new List<Intersection>();
           List<Intersection> ret=Local_Intersect(ray2);
            // Below marked for deletion 
            //Intersection one;
            //Intersection two;
            //double[] ins;
            //csharp_rt.Tuple sphere_to_ray = ray2.origin - csharp_rt.Tuple.point(0, 0, 0);
            //double a = csharp_rt.Tuple.dot(ray2.direction, ray2.direction);
            //double b = 2 * csharp_rt.Tuple.dot(ray2.direction, sphere_to_ray);
            //double c = sphere_to_ray.dot(sphere_to_ray) - 1;
            //double descriminate = Math.Pow(b, 2) - 4 * a * c;

            //if (descriminate >= 0)
            //{
                //double t1 = (-b - Math.Sqrt(descriminate)) / (2 * a);
                //double t2 = (-b + Math.Sqrt(descriminate)) / (2 * a);
                //comment out for now.
                //ret.Add(new Intersection(/*ins[0]*/t1, this));
                //ret.Add(new Intersection(/*ins[1]*/t2, this));
            //}
            return ret;
        }
        /// <summary>
        /// abstract method.
        /// called by Intersect.
        /// should call specific shape's local_intersect.
        /// </summary>
        /// <param name="local_ray"></param>
        /// <returns></returns>
        protected abstract List<Intersection> Local_Intersect(Ray local_ray);

        protected Shape()
        {
            Material = new Material();
            Transform = Matrix.identity();
        }

    }

    public class Test_shape:Shape
    {
        // marked (below) for deletion
        //use abstract for shape.
        public Ray saved_ray;
        public int testx;
        public Test_shape():base()
        {
            // marked commened out for deletion.
            // left over values are used for testing/unit tests
            // Material = new Material();
            // Transform = Matrix.identity();
            saved_ray = new Ray(csharp_rt.Tuple.point(0,0,0),csharp_rt.Tuple.vector(0,0,0));
            testx = 5;
        }
        protected override List<Intersection> Local_Intersect(Ray ray_in)
        {
            List<Intersection> temp_for_error_removal = new List<Intersection>();
            saved_ray = ray_in;
            return temp_for_error_removal;
        }
    }
}
