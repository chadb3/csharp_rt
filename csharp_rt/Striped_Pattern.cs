using System;
using csharp_rt;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public struct Striped_Pattern
    {
        //Color a
        public Color a { get; set; }
        //Color b
        public Color b { get; set; }
        //bool if pattern is set
        public bool Striped_Pattern_is_set {  get; set; }
        public Matrix Transform { get; set; }
        public Striped_Pattern(Color a, Color b)
        {
            this.a = a;
            this.b = b;
            Striped_Pattern_is_set = true;
            Transform = Matrix.identity();
        }
        /// <summary>
        /// Empty Constructor
        /// Striped_Pattern(Black,Black);
        /// This means that the pattern is not set
        /// but sets the pattern color of the pattern to a=black, and b=black if it is seen.
        /// so if you are getting any issues where something is all black then check here.
        /// Note: calling this sets "Striped_Pattern_is_set = false;" and will be treated as a solid color.
        /// </summary>
        public Striped_Pattern()
        {
            a = new Color(0, 0, 0);
            b = new Color(0, 0, 0);
            Striped_Pattern_is_set = false;
            Transform = Matrix.identity();
        }

        public Color Stripe_At(csharp_rt.Tuple pt)
        {
            if(Math.Floor((double)pt.x)%2==0)
            {
                return a;
            }
            return b;
        }
        /// <summary>
        /// Striped_Pattern(White,Black)
        /// </summary>
        /// <returns></returns>
        public static Striped_Pattern default_pattern()
        {
            return new Striped_Pattern(new Color(1,1,1), new Color(0,0,0));
        }
        public void Set_Pattern_Transform(Matrix transformIn)
        {
            Transform = transformIn;
        }

        public Color Stripe_at_Object(Shape s, csharp_rt.Tuple point_in)
        {
            Color ret = new Color(1, 1, 1);

            return ret;
        }
    }
}
