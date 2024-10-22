using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Plane:Shape
    {
        public Plane() : base() { }
        /// <summary>
        /// Local Intersect for Plane
        /// Investigate changing Local Intersect to return Intersections? 
        /// </summary>
        /// <param name="ray_in"></param>
        /// <returns></returns>
        protected override List<Intersection> Local_Intersect(Ray ray_in)
        {
            List<Intersection> result = new List<Intersection>();

            return result;
        }
        protected override csharp_rt.Tuple Local_Normal_At(csharp_rt.Tuple point_in)
        {
            //return csharp_rt.Tuple.vector(point_in.x, point_in.y, point_in.z);
            return csharp_rt.Tuple.vector(0, 1, 0);
        }
        public csharp_rt.Tuple zzzz_Test_Local_Normal_At(csharp_rt.Tuple point_in)
        {
            return Local_Normal_At(point_in);
        }


    }
}
