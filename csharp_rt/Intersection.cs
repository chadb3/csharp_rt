using CSharpRayTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Intersection
    {
        public Sphere obj;// shape;
        //public double[,] t;// intersect;
        // negative t means obj is behind ray
        // positive t means intersected
        public double t;
       /* public Intersection(double[,] intersect_in,Sphere shape_in ) 
        { 
            this.obj = shape_in; 
            this.t = intersect_in;
        }*/
        public Intersection(double intersect_in, Sphere shape_in)
        {
            this.obj = shape_in;
            this.t = intersect_in;
        }

 
        //need these to sort....
        //not sure if I need to compare values.
        //but I know I can compare t values...
        public static bool operator ==(Intersection left, Intersection right) 
        {

            if (Math.Abs(left.t - right.t) < 0.0001)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Intersection left, Intersection right) 
        { 
            return !left.Equals(right); 
        }
        //todo
        public static bool operator >(Intersection left, Intersection right) 
        { 
            if(left.t!=right.t&&left.t> right.t)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return left.Equals(right); 
        }
        //todo
        public static bool operator <(Intersection left, Intersection right) 
        { 
            if(left.t!=right.t&&left.t<right.t)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return left.Equals(right);
        }
        public static bool operator>=(Intersection left, Intersection right) 
        {
            if (left.t > right.t || left.t == right.t)
            {
                return true;
            }
            else
            { 
                return false; 
            }
            //return left.t>=right.t; 
        }
        public static bool operator <=(Intersection left, Intersection right) 
        { 
            if(left.t<right.t||left.t==right.t)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return left.t<=right.t; 
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
        /// <summary>
        /// added to clear warnings/errors
        /// "intersection" overrides Object.equals(object o) but does not override Object.GetHashCode();
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Object: "+obj.ToString()+"\tHit value: "+t.ToString();
        }
        /// <summary>
        /// Called like:
        /// Intersection i ....
        /// i.prepare_computations(rayIn);
        /// </summary>
        /// <param name="rayIn"></param>
        /// <returns>new Computations object/datastructore</returns>
        public Computations prepare_computations(Ray rayIn)
        {
            Computations ret = new Computations(this.t, this.obj, rayIn.position(this.t), rayIn.direction);
            return ret;
        }
    }
}
