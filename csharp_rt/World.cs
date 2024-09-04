using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class World
    {
        //Object - not yet implimented 
        //Sphere
        public List<Sphere> sphereList;
        public Light light;
        //Light
        public World() 
        { 
            light= new Light();
            sphereList = new List<Sphere>();
        }

        public World default_world()
        {
            Light light = new Light(csharp_rt.Tuple.point(-10,10,-10),new csharp_rt.Color(1,1,1));
            Sphere s1 = new Sphere();
            s1.material.color = new csharp_rt.Color(0.8, 1.0,0.6);
            s1.material.diffuse = 0.7;
            s1.material.specular = 0.2;
            Sphere s2=new Sphere();
            s2.transform.scaling_ns(0.5, 0.5, 0.5);
            sphereList.Add(s1);
            sphereList.Add(s2);
            this.light = light;
            return this;
        }
    }
}
