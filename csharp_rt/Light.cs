using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
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
    }
}
