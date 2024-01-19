using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Intersection
    {
        public Sphere shape;
        public double[,] intersect;
        public Intersection(double[,] intersect_in,Sphere shape_in ) 
        { 
            this.shape = shape_in; 
            this.intersect = intersect_in;
        }
    }
}
