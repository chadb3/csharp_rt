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
        //public Color color_a;
        //public Color color_b;
        public Pattern pattern_a { get; set; } 
        public Pattern pattern_b { get; set; }
        public Ring_Pattern():base()
        { 
            //color_a=new Color(1,1,1);
           // color_b=new Color(1,1,1);

            double frac = 1 / 2.0d;
            pattern_a = new Solid_Pattern(new Color(1, 1, 1));
            pattern_b = new Solid_Pattern(new Color(frac, frac, frac));
        }

        public Ring_Pattern(Color color_a, Color color_b):base()
        {
           //this.color_a = color_a;
            //this.color_b = color_b;
            pattern_a = new Solid_Pattern(color_a);
            pattern_b = new Solid_Pattern(color_b);
        }

        public Ring_Pattern(Pattern pattern_a,Color color_b):base()
        {
            this.pattern_a= pattern_a;
            this.pattern_b=new Solid_Pattern(color_b);
        }

        public Ring_Pattern(Color color_a,Pattern pattern_b):base()
        {
            pattern_a=new Solid_Pattern(color_a);
            this.pattern_b = pattern_b;
        }

        public Ring_Pattern(Pattern pattern_a,Pattern pattern_b):base()
        {
            this.pattern_a = pattern_a;
            this.pattern_b=pattern_b;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            if(Math.Floor(Math.Sqrt(Math.Pow(point_in.x,2)+Math.Pow(point_in.z,2)))%2==0)
            {
                //return color_a;
                return pattern_a.Pattern_At(point_in);
            }
            else
            {
                //return color_b;
                return pattern_b.Pattern_At(point_in);
            }
        }

    }
}
