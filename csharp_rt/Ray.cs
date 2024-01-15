using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_rt
{
    public class Ray
    {
        public Tuple origin;
        public Tuple direction;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin">Point w=0</param>
        /// <param name="vec">Vector w=1</param>
         public Ray(Tuple origin, Tuple vec) 
        {
            this.origin = origin;
            this.direction = vec;
            if(origin.w!=1)
            {
                Console.WriteLine("Warning: Origin Point w != 1");
            }
            if(vec.w!=0)
            {
                Console.WriteLine("Warning Ray Vector w != 0");
            }
        }
    }
}
