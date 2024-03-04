using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Material
    {
        public Color color;
        public double ambient;
        public double diffuse;
        public double specular;
        public double shininess;
        public Material()
        {
            color = new Color(1, 1, 1);
            ambient = 0.1d;
            diffuse = 0.9d;
            specular = 0.9d;
            shininess = 200.0d;
        }
    }
}
