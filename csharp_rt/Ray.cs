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
        /// How to initilize a new Ray
        /// Ray r = new Ray(csharp_rt.Tuple.point(x, y, z), csharp_rt.Tuple.vector(x, y, z))
        /// original text in origin and vec
        /// Point w=0
        /// Vector w=1
        /// </summary>
        /// <param name="origin">csharp_rt.Tuple.point(x,y,z)</param>
        /// <param name="vec">csharp_rt.Tuple.vector(x,y,z)</param>
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
        public Tuple position(double t)
        {
            return this.origin + (this.direction * t);
        }

        public Ray transform(Matrix m)
        {
            Ray result;// = new Ray(origin, direction);
            Tuple newOrigin = m * origin;
            Tuple newDirection= m * direction;
            return result= new Ray(newOrigin, newDirection);
        }

      
    }
}
