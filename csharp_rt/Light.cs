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
            Color ambient = effective_color * m.ambient;
            double light_dot_normal=lightv.dot(normalv);
            csharp_rt.Color color_specular = new Color();
            csharp_rt.Color color_diffuse = new Color();
            double factor = 0.0d;
            if (light_dot_normal<0)
            {
                //csharp_rt.Color color_diffuse = Color.BLACK();
                //csharp_rt.Color color_specular = Color.BLACK();
                color_diffuse = Color.BLACK();
                color_specular = Color.BLACK();
            }
            else 
            {
                //csharp_rt.Color color_diffuse = effective_color * m.diffuse * light_dot_normal;
                color_diffuse = effective_color * m.diffuse * light_dot_normal;
                //csharp_rt.Tuple reflectV = -normalv.reflect(eyev);
                csharp_rt.Tuple reflectV = -lightv.reflect(normalv);
                double reflect_dot_eye=reflectV.dot(eyev);
                if (reflect_dot_eye <= 0)
                {
                    //csharp_rt.Color color_specular = Color.BLACK();
                    color_specular = Color.BLACK();
                }
                else
                {
                    factor = Math.Pow(reflect_dot_eye, m.shininess);
                    color_specular = intensity * m.specular * factor;
                }
            }

            //return ret;
            return ambient + color_diffuse + color_specular;
        }
    }
}
