using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public abstract class Shape
    {
        // public csharp_rt.Tuple Origin {  get; set; }
        public Matrix Transform { get; set; }
        public Material Material { get; set; }

        /// <summary>
        /// Set Transform function.
        /// might be redundant due to Transform's get/set. 
        /// added for consistency with book.
        /// </summary>
        /// <param name="m"></param>
        public void Set_Transform(Matrix m)
        {
            Transform = m;
        }

        public csharp_rt.Tuple normal_at(csharp_rt.Tuple point_in)
        {
            csharp_rt.Tuple local_point = Transform.inverse() * point_in;
            csharp_rt.Tuple local_normal = Local_Normal_At(local_point);
            csharp_rt.Tuple world_normal = Transform.inverse().transpose() * local_normal;
            world_normal.w = 0;
            return world_normal.normalize();
        }

        protected abstract csharp_rt.Tuple Local_Normal_At(csharp_rt.Tuple point_in);

        public List<Intersection> Intersect(Ray RayIn)
        {
            Ray ray2 = RayIn.transform(this.Transform.inverse());
            //List<Intersection> ret = new List<Intersection>();
            List<Intersection> ret = Local_Intersect(ray2);

            return ret;
        }

        /// <summary>
        /// abstract method.
        /// called by Intersect.
        /// should call specific shape's local_intersect.
        /// </summary>
        /// <param name="local_ray"></param>
        /// <returns></returns>
        protected abstract List<Intersection> Local_Intersect(Ray local_ray);

        /// <summary>
        /// Protected Constructor
        /// Set up in derived classes like "public derived_class():base()"
        /// </summary>
        protected Shape()
        {
            Material = new Material();
            Transform = Matrix.identity();
        }

        public static bool operator ==(Shape l, Shape r)
        {
            if(l.GetType()==r.GetType()&&l.Transform==r.Transform&&l.Material==r.Material)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Shape l, Shape r)
        {
            return !(l == r);
        }
        /// <summary>
        /// This is needed to get "Assert.AreEqual" tests to pass.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public override bool Equals(object r)
        { 
            return this==(Shape)r; 
        }

    }

    public class Test_shape : Shape
    {
        public Ray saved_ray;
        public int testx;
        public Test_shape() : base()
        {
            saved_ray = new Ray(csharp_rt.Tuple.point(0, 0, 0), csharp_rt.Tuple.vector(0, 0, 0));
            testx = 5;
        }
        protected override List<Intersection> Local_Intersect(Ray ray_in)
        {
            List<Intersection> temp_for_error_removal = new List<Intersection>();
            saved_ray = ray_in;
            return temp_for_error_removal;
        }

        protected override csharp_rt.Tuple Local_Normal_At(csharp_rt.Tuple point_in)
        {
            return csharp_rt.Tuple.vector(point_in.x,point_in.y,point_in.z);
        }
    }
}
