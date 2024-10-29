﻿using csharp_rt;
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
        /// <summary>
        /// Transform is set here
        /// color will be set in the child class
        /// </summary>
        protected Pattern() 
        {
            Transform = Matrix.identity();
        }
        public Color Pattern_At_Shape(Shape shape_in,csharp_rt.Tuple point_in)
        {
            csharp_rt.Tuple object_point = shape_in.Transform.inverse() * point_in;
            csharp_rt.Tuple pattern_point = Transform.inverse() * object_point;
            return Pattern_At(pattern_point);
        }
        public void Set_Transform(Matrix Transform_in)
        {
            Transform=Transform_in;
        }


        protected abstract Color Pattern_At(csharp_rt.Tuple point_in);
    }
    /// <summary>
    /// Test Pattern used for Unit Tests
    /// </summary>
    public class Test_Pattern:Pattern
    {
        /// <summary>
        /// Blank Construcor
        /// Matrix Transform is set in base class Pattern.
        /// </summary>
        public Test_Pattern():base()
        {

        }

        /// <summary>
        /// Per page 134 this is the test color that it is returned.
        /// Note that the "point_in" should have been transformed in "Pattern_At_Shape"
        /// </summary>
        /// <param name="point_in"></param>
        /// <returns></returns>
        protected override Color Pattern_At(csharp_rt.Tuple point_in)
        {
            return new Color(point_in.x, point_in.y, point_in.z);
        }
    }
}
