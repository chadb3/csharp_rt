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
        public static bool operator ==(Material lhs, Material rhs)
        {
            if(lhs.color== rhs.color )
            {
                if (lhs.ambient== rhs.ambient )
                {
                    if( lhs.diffuse== rhs.diffuse)
                    {
                        if(lhs.specular== rhs.specular )
                        {
                            if(lhs.shininess== rhs.shininess )
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool operator !=(Material lhs, Material rhs) {  return !(lhs == rhs); }
        public override bool Equals(Object obj)
        {
            return this == (Material)obj;
        }
    }
}
