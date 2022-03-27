
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_rt
{
    public class tuple
    {
        
        public double x, y, z, w;
        public tuple(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public static tuple point(double x, double y, double z)
        {
            return new tuple(x, y, z, 1);
        }

        public static tuple vector(double x, double y, double z)
        {
            return new tuple(x, y, z, 0);
        }

        public static tuple operator+(tuple left, tuple right)
        {
            return new tuple(left.x+right.x,left.y+right.y,left.z+right.z,left.w+right.w);
        }

        public static tuple operator-(tuple left, tuple right)
        {
            return new tuple(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        public static tuple operator-(tuple left)
        {
            return new tuple((-1)*left.x, (-1) * left.y, (-1) * left.z, (-1) * left.w);
        }

        public static tuple operator *(tuple left, double right)
        {
            return new tuple(left.x*right,left.y*right,left.z*right,left.w*right);
        }

        public static tuple operator /(tuple left, double right)
        {
            return new tuple(left.x / right, left.y / right, left.z / right, left.w / right);
        }

        public double magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2) + Math.Pow(w, 2));
        }

        public tuple normalize()
        {
            return new tuple(x / magnitude(), y / magnitude(), z / magnitude(), w / magnitude());
        }

        public double dot(tuple right)
        {
            return x * right.x + y * right.y + z * right.z + w * right.w;
        }

        public tuple cross(tuple right)
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

        public static bool operator ==(tuple left, tuple right)
        {
            bool result = false;
            if(left.x==right.x)
            {
                if(left.y==right.y)
                {
                    if(left.z==right.z)
                    {
                        if (left.w == right.w)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
        public static bool operator !=(tuple left, tuple right) => !(left == right);

        public override bool Equals(object obj)
        {
            return this == (tuple)obj;
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

