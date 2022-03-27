using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csharp_rt
{
    public class canvas
    {
        public int Y_AXIS_SIZE, X_AXIS_SIZE;
        public color[,] _IMG;
        //counts out of bounds write attempts
        private int OOB_count;
        //counts out of bounds get attempts. 
        private int OOB2_count;
        private string filename;
        public canvas(int X_AXIS_SIZE_IN,int Y_AXIS_SIZE_IN)
        {
            if(X_AXIS_SIZE_IN<0||Y_AXIS_SIZE_IN<0)
            {
                Console.Out.WriteLine("No Funny Business...");
            }
            Y_AXIS_SIZE = Math.Abs(Y_AXIS_SIZE_IN);
            X_AXIS_SIZE = Math.Abs(X_AXIS_SIZE_IN);
            _IMG = new color[Y_AXIS_SIZE, X_AXIS_SIZE];
            for(int i=0;i<Y_AXIS_SIZE;i++)
            {
                for(int j =0;j<X_AXIS_SIZE;j++)
                {
                    _IMG[i, j] = color.BLACK();
                }
                
            }
            OOB_count = 0;
            OOB2_count = 0;
            filename = "untitled.ppm";
        }
        public void set_file_name(string filename_in)
        {
            filename = filename_in + ".ppm";
        }

        public void write_pixel(int x_in, int y_in, color color_in)
        {
            
            if(x_in<X_AXIS_SIZE&&y_in<Y_AXIS_SIZE && x_in >= 0 && y_in >= 0)
            {
                //Console.Out.WriteLine("WRITE PIXEL HIT");
                _IMG[y_in, x_in] = color_in;
            }
            else
            {
                //Console.Out.WriteLine($"OOB: {x_in} {y_in}");
                OOB_count++;
            }

        }

        public void write_pixel(double x,double y, color color_in)
        {
            if ((int)x >= 0 && (int)y >= 0 && (int)x < X_AXIS_SIZE && (int)y < Y_AXIS_SIZE)
            {
                write_pixel((int)x, (int)y, color_in);
            }
            else { OOB_count++; }
        }

        public color pixel_at(int x_in, int y_in)
        {
            if (x_in < X_AXIS_SIZE && y_in < Y_AXIS_SIZE && x_in >= 0 && y_in >= 0)
            {
               return _IMG[y_in, x_in];
            }
            else
            {
                OOB2_count++;
                return color.BLACK();
            }
        }

        public void canvas_to_P3_ppm()
        {
            //Console.Out.WriteLine("AASDF");
            StreamWriter F = new StreamWriter(filename);
            int char_count = 0;
            string header = $"P3\n{X_AXIS_SIZE} {Y_AXIS_SIZE}\n255\n";
            F.Write(header);
            //Console.Out.WriteLine(header);
            for(int i =0;i<Y_AXIS_SIZE;i++)
            {
                for(int j = 0;j<X_AXIS_SIZE;j++)
                {
                    if(char_count+2<70)
                    {
                        F.Write($"{_IMG[i, j].get_red_ppm()} ");
                        //Console.Out.Write($"{_IMG[i, j].get_red_ppm()} ");
                        char_count += 2;
                    }
                    else
                    {
                        F.Write($"{_IMG[i, j].get_red_ppm()}\n");
                        //Console.Out.Write($"{_IMG[i, j].get_red_ppm()}\n");
                        char_count = 0;
                    }
                    if (char_count + 2 < 70)
                    {
                        F.Write($"{_IMG[i, j].get_green_ppm()} ");
                        //Console.Out.Write($"{_IMG[i, j].get_green_ppm()} ");
                        char_count += 2;
                    }
                    else
                    {
                        F.Write($"{_IMG[i, j].get_green_ppm()}\n");
                        //Console.Out.Write($"{_IMG[i, j].get_green_ppm()}\n");
                        char_count = 0;
                    }
                    if (char_count + 2 < 70)
                    {
                        F.Write($"{_IMG[i, j].get_blue_ppm()} ");
                        //Console.Out.Write($"{_IMG[i, j].get_blue_ppm()} ");
                        char_count += 2;
                    }
                    else
                    {
                        F.Write($"{_IMG[i, j].get_blue_ppm()}\n");
                        //Console.Out.Write($"{_IMG[i, j].get_blue_ppm()}\n");
                        char_count = 0;
                    }
                }
            }
            F.Close();
        }
    }
}
