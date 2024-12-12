using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    /// <summary>
    /// Aggergate of intersections (stores intersect)
    /// Not sure how this is going to be used with more objects as simple tests were provided.
    /// </summary>
    public class Intersections
    {
        public List<Intersection> t;
        public Intersections()
        {
            t = new List<Intersection>();
        }
        /// <summary>
        /// Setting this up in
        /// Interset sets the object on the intersection
        /// </summary>
        /// <param name="t_in"></param>
        public Intersections(List<Intersection> t_in)
        {
            t = new List<Intersection>();
            t = t_in;

        }
        /// <summary>
        /// For use for unit tests. I am not sure how it is going to be used down the line. 
        /// I hope it is used for something and isn't forgotten.
        /// This time I will try not to get destracted, and not think ahead of what could come.
        /// as in I am thinking I might need an append method or something to handle shapes as rays get to them.
        /// </summary>
        /// <param name="one">the left value in the unit tests</param>
        /// <param name="two">the right value in the unit tests</param>
        public Intersections(Intersection one, Intersection two)
        {
            t = new List<Intersection>();
            t.Add(one);
            t.Add(two);
        }
       /* public Intersections(Intersection one, Intersection two, Intersection three, Intersection four)
        {
            t = new List<Intersection>();
            t.Add(one);
            t.Add(two);
            t.Add(three);
            t.Add(four);
        }*/

        //researching variable amount of parameteres in methods
        //public Intersections(params Intersection[] intersections_in)....
        public Intersections(params Intersection[] intersections)
        {
            int len = intersections.Length;
            t = new List<Intersection>();
            for (int i = 0; i < len; i++)
            {
                t.Add(intersections[i]);
            }
        }

        public int count()
        {
            return t.Count();
        }
        /// <summary>
        /// This allows you to get an individual intersection from t for the index input.
        /// </summary>
        /// <param name="intIn"></param>
        /// <returns></returns>
        public Intersection this[int intIn]
        {
            // need to check why this is getting called when plane returns a negative t
            // "nothing" should be called and this shouldn't even be called.
            get { return t[intIn]; }
        }

        public Intersection hit()
        {
            //Place holder so unit tests don't complain and auto complete the wrong thing...
            //Intersection ret=this[0];
            // mark below for deletion
            //List<Intersection> tmp = t;
            //tmp=tmp.OrderBy(o=>o.t).ToList();
            //this.t=this.t.OrderBy(o => o.t).ToList();
            /*this.sort();
            debug print
            Console.WriteLine("DEBUG PRINT");
            foreach (Intersection item in tmp) { Console.WriteLine(item); }
            Console.WriteLine("DEBUG PRINT 2");
            foreach (Intersection item in this.t) { Console.WriteLine(item); }
            end debug print
            for (int i = 0;i<t.Count;i++)
            {
            commented out for now to prevent unnecessary prints
            Console.WriteLine("i: {0}", i);


            return t[i];

            }*/
            if (first_positive_index() != -1)
            {
                Intersection ret = this[0];
                this.t = this.t.OrderBy(o => o.t).ToList();
                return t[first_positive_index()];
            }
            else
            {
                //return null;
                return new Intersection();
            }
            /*Console.WriteLine("Warning: returning null for HIT");
            return null;*/
        }

        public bool canHit()
        {
            return count() > 0;
        }

        public void sort()
        {
            this.t = this.t.OrderBy(o => o.t).ToList();
        }
        /// <summary>
        /// returns first positive index.
        /// a negative number may occupy lower results in a sorted list.
        /// negative numbers mean not intersected.
        /// </summary>
        /// <returns></returns>
        public int first_positive_index()
        {
            // need to test
            int ret = -1;
            for (int i = 0; i < t.Count(); i++)
            {
                if (t[i].t > 0)
                {
                    return i;
                }
            }
            return ret;
        }

        public bool is_empty() { return t.Count() == 0; } 


    }
}
