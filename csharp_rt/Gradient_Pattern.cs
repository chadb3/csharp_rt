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
        protected Color A { get; set; }
        protected Color B { get; set; }

        /// <summary>
        /// Default Constructor
        /// currently sets the color A to white, and B to black
        /// </summary>
        public Gradient_Pattern(): base() 
        {
            Pattern_Is_Set = true;
            A = new Color(1, 1, 1);
            B = new Color(0, 0, 0);
        }

        public Gradient_Pattern(Color A, Color B) : base()
        {
            Pattern_Is_Set = true;
            this.A = A;
            this.B = B;
        }

        protected override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            Color distance = B - A;
            double fraction = point_in.x - Math.Floor(point_in.x);
            return A + distance * fraction;
        }
        /// <summary>
        /// Mainly used for unit tests. As the Parent class calls the one without the zzzz, and that one is protected.
        /// I might be able to make it public though. to test later.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Color zzzzTest_Pattern_At(csharp_rt.Tuple pt)
        {
            return Pattern_At(pt);
        }
    }
}
