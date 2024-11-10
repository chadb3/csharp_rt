using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Solid_Pattern : Pattern
    {

        public Color Color { get; set; }
        public Solid_Pattern() : base() 
        { 
            Color=new Color(0,0,0);
        }

        public Solid_Pattern(Color Color):base()
        {
            this.Color = Color;
        }

        public override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            return Color;
        }

        public override string ToString()
        {
            return Color.ToString();
        }
        /// <summary>
        /// Hope this doesn't break
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Solid_Pattern right = obj as Solid_Pattern;
            return this.Color == right.Color;
        }
    }
}
