﻿using System;
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
        public Intersections(Intersection one, Intersection two,Intersection three,Intersection four)
        {
            t = new List<Intersection>();
            t.Add(one);
            t.Add(two);
            t.Add(three);
            t.Add(four);
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
        public  Intersection this[int intIn]
        {
            get { return t[intIn]; }
        }

        public Intersection hit()
        {
            //Place holder so unit tests don't complain and auto complete the wrong thing...
            Intersection ret=this[0];
            List<Intersection> tmp = t;
            tmp=tmp.OrderBy(o=>o.t).ToList();
            this.sort();
            //debug print
            Console.WriteLine("DEBUG PRINT");
            foreach (Intersection item in tmp) { Console.WriteLine(item); }
            //end debug print
            return ret;
        }
        private void sort()
        {
            qsort(0, t.Count - 1);
        }

        private void qsort(int low, int high)
        {
            int a = 0;
            if(low > high)
            {
                a = partition(low, high);
                qsort(low, a - 1);
                qsort(a+1,high);
            }
        }
        private int partition(int low, int high)
        {
            Intersection pivot = this[high];
            for(int i=low; i < high; i++)
            {
                Intersection tmp = this[i];
                //this[i] = this[high];
            }
            return 1;
        }

    }
}
