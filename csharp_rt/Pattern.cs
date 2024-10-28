using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public abstract class Pattern
    {
        public Matrix Transform { get; set; }
        protected Pattern() 
        {
            Transform = Matrix.identity();
        }
        public Color Pattern_At_Shape(Shape shape_in,csharp_rt.Tuple point_in)
        {
            Color color = new Color();

            return color;
        }
        public void Set_Transform(Matrix Transform_in)
        {
            Transform=Transform_in;
        }

        protected abstract Color Local_Pattern_At_Shape();
    }

    public class Test_Pattern:Pattern
    {
        public Test_Pattern():base()
        {

        }
        protected override Color Local_Pattern_At_Shape()
        {
            throw new NotImplementedException();
        }
    }
}
