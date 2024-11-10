using System;
using csharp_rt;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Striped_Pattern:Pattern
    {
        //Color a
        public Pattern a { get; set; }
        //Color b
        public Pattern b { get; set; }
        //bool if pattern is set
        //public bool Striped_Pattern_is_set {  get; set; }
       // public Matrix Transform { get; set; }
       /// <summary>
       /// takes in 2 solid colors 
       /// and sets them each as solid patterns.
       /// </summary>
       /// <param name="a"></param>
       /// <param name="b"></param>
        public Striped_Pattern(Color a, Color b):base()
        {
            this.a = new Solid_Pattern(a);
            this.b = new Solid_Pattern(b);
        }
        /// <summary>
        /// sets a to any pattern you want, and takes in a solid color for the solid pattern. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Striped_Pattern(Pattern a, Color b) : base()
        {
            this.a = a;
            this.b = new Solid_Pattern(b);
        }
        /// <summary>
        /// sets a color as a solid pattern and can set the other to any pattern you want.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Striped_Pattern(Color a, Pattern b) : base()
        {
            this.a = new Solid_Pattern(a);
            this.b = b;
        }
        /// <summary>
        /// Setting 2 different (non-solid, but still can set as solid if you want) Patterns. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Striped_Pattern(Pattern a, Pattern b) : base()
        {
            this.a = a;
            this.b = b;
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
            a = new Solid_Pattern(new Color(0, 0, 0));
            b = new Solid_Pattern(new Color(0, 0, 0));
            //Striped_Pattern_is_set = false;
            Pattern_Is_Set = true;
            Transform = Matrix.identity();
        }

        //public Color Stripe_At(csharp_rt.Tuple pt)
        public override Color Pattern_At(csharp_rt.Tuple pt)
        {
            if(Math.Floor((double)pt.x)%2==0)
            {
                return a.Pattern_At(pt);
            }
            return b.Pattern_At(pt); ;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape_in"></param>
        /// book calls what i call point_in "world_point"
        /// <param name="point_in"></param>
        /// <returns></returns>
        public Color Stripe_at_Object(Shape shape_in, csharp_rt.Tuple point_in)
        {
            //Color ret = new Color(1, 1, 1);
            csharp_rt.Tuple object_point = shape_in.Transform.inverse() * point_in;
            csharp_rt.Tuple pattern_point = Transform.inverse() * object_point;
            //return Stripe_At(pattern_point);
            return Pattern_At(pattern_point);
        }

        /// <summary>
        /// Kept this temp while I change unit tests
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Color Stripe_At(csharp_rt.Tuple pt)
        {
            if (Math.Floor((double)pt.x) % 2 == 0)
            {
                return a.Pattern_At(pt);
            }
            return b.Pattern_At(pt);
        }
    }
}
