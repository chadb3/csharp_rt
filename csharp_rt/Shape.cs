﻿using csharp_rt;
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

        /// <summary>
        /// Protected Constructor
        /// Set up in derived classes like "public derived_class():base()"
        /// </summary>
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
