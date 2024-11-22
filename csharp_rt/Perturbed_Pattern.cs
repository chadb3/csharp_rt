using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Perturbed_Pattern : Pattern
    {
        public Pattern Main_Pattern { get; set; }
        // WIP - revisit later
        public Perturbed_Pattern():base()
        {
            Main_Pattern = new Solid_Pattern(new Color(0.02, 0.03, 0.04));
        }
        // WIP - revisit later
        public Perturbed_Pattern(Color color_in):base()
        {
            Main_Pattern=new Solid_Pattern(color_in);
        }
        // WIP - revisit later
        public Perturbed_Pattern(Pattern Pattern_in):base()
        {
            Main_Pattern=Pattern_in;
        }
        // WIP - revisit later
        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            throw new NotImplementedException();
        }
    }
}
