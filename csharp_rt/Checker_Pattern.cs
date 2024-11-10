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
            int x = Math.Abs((int)Math.Floor(point_in.x));
            int y = Math.Abs((int)Math.Floor(point_in.y));
            int z = Math.Abs((int)Math.Floor(point_in.z));

            if ((x + y + z) % 2 == 0)
            {
                return Color_A;
            }
            else
            {
                return Color_B;
            }
        }



    }
}
