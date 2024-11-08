using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Ring_Pattern : Pattern
    {
        public Color color_a;
        public Color color_b;
        public Ring_Pattern():base()
        { 
            color_a=new Color(1,1,1);
            color_b=new Color(1,1,1);
        }

        public Ring_Pattern(Color color_a, Color color_b):base()
        {
            this.color_a = color_a;
            this.color_b = color_b;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            if(Math.Floor(Math.Sqrt(Math.Pow(point_in.x,2)+Math.Pow(point_in.z,2)))%2==0)
            {
                return color_a;
            }
            else
            {
                return color_b;
            }
        }
        /// <summary>
        /// Mark for deletion 
        /// Mark for deletion 
        /// Mark for deletion 
        /// </summary>
        /// <param name="point_in"></param>
        /// <returns></returns>
        public Color zzzz_Test_Pattern_At(csharp_rt.Tuple point_in)
        {
            return Pattern_At(point_in);
        }
    }
}
