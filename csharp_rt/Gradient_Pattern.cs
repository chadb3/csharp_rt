using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Gradient_Pattern : Pattern
    {
        public Color A { get; set; }
        public Color B { get; set; }
        public Pattern Pattern_A { get; set; }
        public Pattern Pattern_B { get; set; }

        /// <summary>
        /// Default Constructor
        /// currently sets the color A to white, and B to black
        /// </summary>
        public Gradient_Pattern(): base() 
        {
            //Pattern_Is_Set = true;
            A = new Color(1, 1, 1);
            B = new Color(0, 0, 0);
            Pattern_A = new Solid_Pattern(new Color(1, 1, 1));
            Pattern_B = new Solid_Pattern(new Color(0, 0, 0));
        }

        public Gradient_Pattern(Color A, Color B) : base()
        {
            //Pattern_Is_Set = true;
            this.A = A;
            this.B = B;
            Pattern_A = new Solid_Pattern(A);
            Pattern_B = new Solid_Pattern(B);
        }

        public Gradient_Pattern(Pattern Pattern_A,Color B):base()
        {
            this.Pattern_A = Pattern_A;
            Pattern_B=new Solid_Pattern(B); 
        }

        public Gradient_Pattern(Color A, Pattern Pattern_B):base()
        {
            Pattern_A=new Solid_Pattern(A);
            this.Pattern_B=Pattern_B;
        }

        public Gradient_Pattern(Pattern Pattern_A, Pattern Pattern_B) : base()
        {
            this.Pattern_A=Pattern_A;
            this.Pattern_B=Pattern_B;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            //returns a Color Tuplle
            //Color distance = B - A;
            Color distance = Pattern_B.Pattern_At(point_in) - Pattern_A.Pattern_At(point_in);
            double fraction = point_in.x - Math.Floor(point_in.x);
            return A + distance * fraction;
        }

    }
}
