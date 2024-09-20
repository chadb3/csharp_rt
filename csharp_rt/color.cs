using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// added the below due to system.drawing somehow got added UnitTest1.cs might not be needed anymore. 
using Color = csharp_rt.Color;

namespace csharp_rt
{
    /// <summary>
    /// made this separate to use floats.
    /// probably could use my Touple class.
    /// </summary>
    public class Color
    {
        public float red, green, blue;
        const float EPSILON = 0.0001f;
        public Color()
        {
            red = 0;
            green = 0;
            blue = 0;
        }
        public Color(double red, double green, double blue)
        {
            this.red = (float)red;
            this.green = (float)green;
            this.blue = (float)blue;
        }
        /// <summary>
        /// Trying this so I don't have to do something like
        /// new Color(1,0,0)==Color.red
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public static Color color(double red, double green, double blue)
        {
            return new Color(red, green, blue);
        }


        public static Color operator +(Color left, Color right)
        {
            return new Color(left.red + right.red, left.green + right.green, left.blue + right.blue);
        }

        public static Color operator -(Color left, Color right)
        {
            return new Color(left.red - right.red, left.green - right.green, left.blue - right.blue);
        }

        public static Color operator *(Color left, double right)
        {
            float mult = (float)right;
            return new Color(left.red * mult, left.green * mult, left.blue * mult);
        }

        public static Color operator *(Color left, Color right)
        {
            return new Color(left.red * right.red, left.green * right.green, left.blue * right.blue);
        }


        public static bool operator ==(Color left, Color right)
        {
            bool result = false;
            if (Math.Abs(left.red - right.red) < EPSILON)
            {
                if (Math.Abs(left.green - right.green) < EPSILON)
                {
                    if (Math.Abs(left.blue - right.blue) < EPSILON)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public static bool operator !=(Color left, Color right) => !(left == right);
        public override bool Equals(object obj)
        {
            return this == (Color)obj;
        }
        public override string ToString()
        {
            return $"red: {red} green: {green} blue: {blue}";
        }

        public override int GetHashCode()
        {
            //note the "this" is optional but it just looks better ...
            return this.ToString().GetHashCode();
        }

        public static Color RED()
        {
            return new Color(1, 0, 0);
        }
        public static Color Green()
        {
            return new Color(0, 1, 0);
        }
        public static Color BLUE()
        {
            return new Color(0, 0, 1);
        }

        public static Color BLACK()
        {
            return new Color(0, 0, 0);
        }

        public string get_red_ppm()
        {
            return (Math.Max(Math.Min((int)(255 * red),255),0)).ToString();
        }
        public string get_green_ppm()
        {
            return (Math.Max(Math.Min((int)(255 * green), 255), 0)).ToString();
        }
        public string get_blue_ppm()
        {
            return (Math.Max(Math.Min((int)(255 * blue), 255), 0)).ToString();
        }
    }
}
