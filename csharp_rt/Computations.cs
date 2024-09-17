using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public struct Computations
    {
        public double t { get; set; }
        public Sphere obj { get; set; }
        public csharp_rt.Tuple point { get; set; }
        public csharp_rt.Tuple eyev { get; set; }
        public csharp_rt.Tuple normalv { get; set; }
        public bool inside { get; set; }
        public Computations(double t_in, Sphere obj_in , csharp_rt.Tuple point_in, csharp_rt.Tuple eyev_in)
        { 
            this.t = t_in;
            this.obj = obj_in;
            this.point = point_in;
            this.eyev = -eyev_in;
            this.normalv = this.obj.normal_at(this.point);
        }

        
    }
}
