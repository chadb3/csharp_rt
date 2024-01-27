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
            if(Math.Abs(left.t - right.t)<0.0001)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Intersection left, Intersection right) { return !left.Equals(right); }
        //todo
        public static bool operator >(Intersection left, Intersection right) 
        { 
            return left.Equals(right); 
        }
        //todo
        public static bool operator <(Intersection left, Intersection right) 
        { 
            return left.Equals(right);
        }
        public static bool operator>=(Intersection left, Intersection right) 
        { 
            return left.t>=right.t; 
        }
        public static bool operator <=(Intersection left, Intersection right) 
        { 
            return left.t<=right.t; 
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

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Object: "+obj.ToString()+"Hit value: "+t.ToString();
        }
    }
}
