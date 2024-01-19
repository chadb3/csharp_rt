
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_rt
{
    public class Tuple
    {
        
        public double x, y, z, w;
        public Tuple(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public static Tuple point(double x, double y, double z)
        {
            return new Tuple(x, y, z, 1);
        }

        public static Tuple vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0);
        }

        public static Tuple operator+(Tuple left, Tuple right)
        {
            return new Tuple(left.x+right.x,left.y+right.y,left.z+right.z,left.w+right.w);
        }

        public static Tuple operator-(Tuple left, Tuple right)
        {
            return new Tuple(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        public static Tuple operator-(Tuple left)
        {
            return new Tuple((-1)*left.x, (-1) * left.y, (-1) * left.z, (-1) * left.w);
        }

        public static Tuple operator *(Tuple left, double right)
        {
            return new Tuple(left.x*right,left.y*right,left.z*right,left.w*right);
        }

        public static Tuple operator /(Tuple left, double right)
        {
            return new Tuple(left.x / right, left.y / right, left.z / right, left.w / right);
        }

        public double magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2) + Math.Pow(w, 2));
        }

        public Tuple normalize()
        {
            return new Tuple(x / magnitude(), y / magnitude(), z / magnitude(), w / magnitude());
        }

        public double dot(Tuple right)
        {
            return x * right.x + y * right.y + z * right.z + w * right.w;
        }

        //static dot for use in Sphere
        public static double dot(Tuple left, Tuple right)
        {
            return left.x * right.x + left.y * right.y + left.z * right.z + left.w * right.w;
        }

        public Tuple cross(Tuple right)
        {
            return vector(y * right.z - z * right.y, z * right.x - x * right.z, x * right.y - y * right.x);
        }

        //todo
        //public matrix tuple_as_a_matrix()
        //{
        //...
        //}

        //todo
        //public static tuple matrix_to_tuple(matrix tup_mat)
        //{
        //...
        //}

        public static bool operator ==(Tuple left, Tuple right)
        {
            bool result = false;
            //Math.abs(l-r)>0.00001
            //left.x==right.x
            if (Math.Abs(left.x-right.x)<0.00001)
            {
                //left.y==right.y
                if (Math.Abs(left.y - right.y) < 0.00001)
                {
                    if(Math.Abs(left.z - right.z) < 0.00001)
                    {
                        //left.w == right.w
                        if (Math.Abs(left.w-right.w)<0.00001)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
        public static bool operator !=(Tuple left, Tuple right) => !(left == right);

        public override bool Equals(object obj)
        {
            return this == (Tuple)obj;
        }

        public override string ToString()
        {
            return ($"X:{x} Y:{y} Z:{z} W:{w}");
        }
        public override int GetHashCode()
        {
            //see color() for explanation.
            return this.ToString().GetHashCode();
        }

    }
    
}

