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
            double[] ret = [0.0d,0.0d];
            return ret;
        }
    }
}
