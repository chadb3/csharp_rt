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
            // note below doesn't seem to work, and I still need to set this manually in Material.Pattern.Set_Transform(...below);
            Set_Transform(Matrix.translation(0, 0.000001d, 0));
            //Source: https://forum.raytracerchallenge.com/thread/290/bands-noise
        }
        public Checker_Pattern(Color Color_A, Color Color_B) : base()
        {
            this.Color_A = Color_A;
            this.Color_B = Color_B;
            // note below doesn't seem to work, and I still need to set this manually in Material.Pattern.Set_Transform(...below);
            Set_Transform(Matrix.translation(0, 0.0001d, 0));
            //Source: https://forum.raytracerchallenge.com/thread/290/bands-noise
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            int x = (int)Math.Floor(point_in.x);
            int y = (int)Math.Floor(point_in.y);
            int z = (int)Math.Floor(point_in.z);

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
