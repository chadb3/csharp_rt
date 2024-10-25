using CSharpRayTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Material
    {
        public Striped_Pattern pattern;
        public Color color;
        public double ambient;
        public double diffuse;
        public double specular;
        public double shininess;
        public Material()
        {
            pattern = new Striped_Pattern();
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
        /// <summary>
        /// not clear if this should go to light or material.
        /// I went with material as the material gets the lighting and it was the first var used in the book
        /// so it made since to me to use it like material.lighting
        /// Note: book uses a bool "in_shadow"
        /// Note: I found that the one witn "in_shadow" is in lighting.
        /// I will review this function for removal
        /// </summary>
        /// <param name="light"></param>
        /// <param name="point"></param>
        /// <param name="eyev"></param>
        /// <param name="normalv"></param>
        public Color lighting(Light light,csharp_rt.Tuple point,csharp_rt.Tuple eyev,csharp_rt.Tuple normalv)
        {
            Color ret = Color.RED();
            Color effective_color = this.color * light.intensity;
            csharp_rt.Tuple lightv = (light.position - point).normalize();
            Color ambient = effective_color * this.ambient;
            double light_dot_normal = lightv.dot(normalv);
            if(light_dot_normal < 0 )
            {
                csharp_rt.Color color_diffuse = Color.BLACK();
                csharp_rt.Color color_specular=Color.BLACK(); 
            }
            else
            {
                //csharp_rt.Color color_diffuse=effective_color
            }

            return ret;
        }

        /// <summary>
        /// to do. 
        /// added to clear warnings.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            Console.WriteLine("Material.GetHashCode() Called! \"not implemented!\"");
            return base.GetHashCode();
        }
    }
}
