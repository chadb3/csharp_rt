using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Intersection
    {
        public Sphere obj;// shape;
        //public double[,] t;// intersect;
        public double t;
       /* public Intersection(double[,] intersect_in,Sphere shape_in ) 
        { 
            this.obj = shape_in; 
            this.t = intersect_in;
        }*/
        public Intersection(double intersect_in, Sphere shape_in)
        {
            this.obj = shape_in;
            this.t = intersect_in;
        }
    }
}
