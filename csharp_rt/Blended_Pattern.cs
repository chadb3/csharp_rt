using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Blended_Pattern : Pattern
    {
        public Pattern Pattern_A {  get; set; }
        public Pattern Pattern_B { get; set; }

        /// <summary>
        /// wip
        /// </summary>
        public Blended_Pattern():base()
        {
            Pattern_A = new Striped_Pattern(new Color(1,165/255.0,0),new Color(.1,1,.1));
            Pattern_B = new Ring_Pattern(new Color(1, 0, 0), new Color(.09, .07, .04));
        }
        /// <summary>
        /// wip
        /// </summary>
        /// <param name="Pattern_A"></param>
        /// <param name="Pattern_B"></param>
        public Blended_Pattern(Pattern Pattern_A, Pattern Pattern_B) : base()
        {
            this.Pattern_A = Pattern_A;
            this.Pattern_B = Pattern_B;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            Color ret = Pattern_A.Pattern_At(point_in)+Pattern_B.Pattern_At(point_in);
            return ret;

        }
    }
}
