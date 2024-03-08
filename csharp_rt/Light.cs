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
        /// <summary>
        /// Making this in lighting as it deals with lighting...
        /// will still keep and maybe even finish the one in materials just in case...
        /// </summary>
        /// <param name="m"></param>
        /// <param name="point"></param>
        /// <param name="eyev"></param>
        /// <param name="normalv"></param>
        /// <returns></returns>
        public Color lighting(Material m, csharp_rt.Tuple point, csharp_rt.Tuple eyev, csharp_rt.Tuple normalv)
        {
            Color ret = Color.BLACK();
            Color effective_color = m.color * intensity;
            csharp_rt.Tuple lightv = (position - point).normalize();
            return ret;
        }
    }
}
