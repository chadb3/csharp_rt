using csharp_rt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRayTracer
{
    public class Camera
    {
        // The horizontal size (pixles) of the canvas that the picture will be rendered to.
        public int hsize;
        // Canvas's vertical size in pixles.
        public int vsize;
        // is an angle that describes how much the camera can see. When the field of view is small, the view will be zoomed in, magnifying a smaller area of the scene
        public double fov;
        // half view
        public double half_view;
        // aspect
        public double aspect;
        // half width
        public double half_width;
        // half height
        public double half_height;
        //transform
        public Matrix transform;
        //pixel size
        public double pixel_size;
        public Camera(int hsize, int vsize, double fov)
        {
            this.hsize = hsize;
            this.vsize = vsize;
            this.fov = fov;
            this.transform = Matrix.identity();
            this.computeCamera();
        }

        private void computeCamera()
        {
            if (hsize > 0 && vsize > 0)
            {
                half_view = Math.Tan(fov / 2);
                aspect = hsize / vsize;
                if (aspect >= 1)
                {
                    half_width = half_view;
                    half_height = half_view / aspect;
                }
                else
                {
                    half_width = half_view * aspect;
                    half_height = half_view;
                }
            }
            // if hsize and vsize are less than equal to 0
            else
            {
                Console.WriteLine("hsize <= 0 or vsize <= 0\nInspect: This was hit to prevent a divide by zero\ncheck: Camera.cs - computeCamera()\ncheck: Check camera inputs");
                half_view = double.MaxValue;
                aspect = double.MaxValue;
                half_width = half_view;
                half_height = half_view / aspect;
            }
            pixel_size = (half_width * 2) / hsize;
        }
    }
}
