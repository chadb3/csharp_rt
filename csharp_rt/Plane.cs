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
            
            if (Math.Abs(ray_in.direction.y)<0.00001d)
            {
                return result;
            }
            double t = (-ray_in.origin.y)/ray_in.direction.y;
            result.Add(new Intersection(t, this));
            //result.Add(new Intersection(0.0d, this));
            return result;
        }
        protected override csharp_rt.Tuple Local_Normal_At(csharp_rt.Tuple point_in)
        {
            //return csharp_rt.Tuple.vector(point_in.x, point_in.y, point_in.z);
            return csharp_rt.Tuple.vector(0, 1.0d, 0);
        }
        /// <summary>
        /// Only used for Unit Testing.
        /// Unit Tests tested local_normal_at.
        /// </summary>
        /// <param name="point_in"></param>
        /// <returns></returns>
        public csharp_rt.Tuple zzzz_Test_Local_Normal_At(csharp_rt.Tuple point_in)
        {
            return Local_Normal_At(point_in);
        }
        /// <summary>
        /// Only used for unit tests which called for local_intersect.
        /// </summary>
        /// <param name="ray_in"></param>
        /// <returns></returns>
        public List<Intersection> zzzz_Test_Local_Intersect(Ray ray_in)
        {
            return Local_Intersect(ray_in);
        }
    }

}
