using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_rt
{
    public class Ray
    {
        Tuple origin;
        Tuple vec;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin">Point w=0</param>
        /// <param name="vec">Vector w=1</param>
         public Ray(Tuple origin, Tuple vec) 
        {
            this.origin = origin;
            this.vec = vec;
            if(origin.w!=0)
            {
                Console.WriteLine("Warning: Origin Point w != 0");
            }
            if(vec.w!=1)
            {
                Console.WriteLine("Warning Ray Vector w != 0");
            }
        }
    }
}
