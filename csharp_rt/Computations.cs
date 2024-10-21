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
        public csharp_rt.Tuple point { get; set; }
        public csharp_rt.Tuple eyev { get; set; }
        public csharp_rt.Tuple normalv { get; set; }
        public bool inside { get; set; }
        public csharp_rt.Tuple over_point { get; set; }

        public Shape shapeObj { get; set; }


        public Computations(double t_in, Shape obj_in, csharp_rt.Tuple point_in, csharp_rt.Tuple eyev_in)
        {
            this.t = t_in;
            this.shapeObj = obj_in;
            this.point = point_in;
            this.eyev = -eyev_in;
            this.normalv = this.shapeObj.normal_at(this.point);
            if (this.normalv.dot(this.eyev) < 0)
            {
                this.inside = true;
                this.normalv = -this.normalv;
            }
            else
            {
                this.inside = false;
            }
        }

    }
}
