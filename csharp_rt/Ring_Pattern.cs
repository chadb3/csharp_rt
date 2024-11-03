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
        protected override Color Pattern_At(csharp_rt.Tuple point_in)
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
    }
}
