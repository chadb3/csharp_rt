using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Checker_Pattern:Pattern
    {
        public Color Color_A {  get; set; }
        public Color Color_B { get; set; }

        public Checker_Pattern():base()
        {
            Color_A = new Color(1, 1, 1);
            Color_B = new Color(0, 0, 0);
        }
        public Checker_Pattern(Color Color_A, Color Color_B) : base()
        {
            this.Color_A = Color_A;
            this.Color_B = Color_B;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            
            if((Math.Floor(point_in.x) + Math.Floor(point_in.y) + Math.Floor(point_in.z)) %2==0)
            {
                return Color_A;
            }
            else
            {
                return Color_B;
            }
        }


        /// <summary>
        /// ended up making the Pattern_At public so I could call it from a child class like
        /// Pattern pattern=new Checker_Pattern()...
        /// Color x=pattern.Pattern_At(examplePoint);
        /// as of this point, the zzzz methods can be deleted (following changing unit tests).
        /// </summary>
        /// <param name="point_in"></param>
        /// <returns></returns>
        public Color zzzz_Test_Pattern_At(csharp_rt.Tuple point_in)
        {
            return Pattern_At(point_in);
        }
    }
}
