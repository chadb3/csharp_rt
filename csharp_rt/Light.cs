using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Light
    {
        public csharp_rt.Tuple position;
        public Color intensity;
        public Light()
        {
            this.position = csharp_rt.Tuple.point(0, 0, 0);
            this.intensity = new Color(0, 0, 0);
        }
        public Light(csharp_rt.Tuple position, Color intensity)
        {
            this.position = position;
            this.intensity = intensity;
        }

        public static Light point_light(csharp_rt.Tuple position, Color intensity)
        {
            Light pl=new Light();
            pl.intensity = intensity;
            pl.position = position;
            return pl;
        }
    }
}
