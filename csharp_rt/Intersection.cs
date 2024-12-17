using CSharpRayTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Intersection
    {
        public Shape tnObj;
        //public double[,] t;// intersect;
        // negative t means obj is behind ray
        // positive t means intersected
        public double t;
        public bool nothing = false;


  
        public Intersection(double intersect_in, Shape shape_in)
        {
            this.t=intersect_in;
            this.tnObj = shape_in;
        } 

        public Intersection()
        {
            this.t = Double.MinValue;
            tnObj = null;
            nothing = true;
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
            //updating this
            return "Object: "+tnObj.ToString()+"\tHit value: "+t.ToString();
        }
        /// <summary>
        /// Called like:
        /// Intersection i ....
        /// i.prepare_computations(rayIn);
        /// </summary>
        /// <param name="rayIn"></param>
        /// <returns>new Computations object/datastructore</returns>
        public Computations prepare_computations(Ray rayIn, Intersections xs = null)
        {
            /*double n1 = 0.0d;
            double n2 = 0.0d;*/
            List<Shape> containers = new List<Shape>();
            Computations ret = new Computations(this.t, this.tnObj, rayIn.position(this.t), rayIn.direction);
            if (xs != null )//needed for to make xs optional 
            {
                // || xs.count()>0
                // need to make Intersections IEnumerable to use foreach...
                // I will need to test with at test Project first but will use a normal loop as a workaround.
                for (int i = 0;i<containers.Count;i++)
                {
                    if (!xs[i].nothing)
                    {
                        if(containers.Count==0)
                        {
                            ret.n1 = 1.0d;
                        } //end if
                        else
                        {
                            ret.n1 = containers.Last().Material.refractive_index;
                        } //end else
                    } // end if
                    if (containers.Contains(xs[i].tnObj))
                    {
                        // remove object
                        containers.Remove(xs[i].tnObj);
                    }// end if remove 
                    else
                    {
                        containers.Append(xs[i].tnObj);
                    }// end else add
                    // this next part is a repeat?
                    // with no changes
                    if(!xs[i].nothing)
                    {
                        if (containers.Count == 0)
                        {
                            ret.n2 = 1.0d;
                        } // end if
                        else
                        {
                            ret.n2=containers.Last().Material.refractive_index;
                        }// end else
                        break;
                    }

                }
            }
            
            ret.over_point = ret.point + ret.normalv * 0.00001;
            //ret.reflectv = new Ray(rayIn.direction, ret.normalv);
            ret.reflectv = rayIn.direction.reflect(ret.normalv);
            return ret;
        }
    }
}
