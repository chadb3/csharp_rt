using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class matrix
    {
        public int x_size, y_size;
        public double[,] _matrix;
        public double this[int x, int y]
        {
            get
            {
                if (x >= 0 && y >= 0 && x < x_size && y < y_size)
                {
                    return _matrix[x, y];
                }
                else
                {
                    return double.MinValue;
                }
            }
            set
            {
                if (x >= 0 && y >= 0 && x < x_size && y < y_size)
                {
                    _matrix[x, y] = value;
                }
                else { Console.Out.WriteLine($"Out Of Bounds! X: {x} Xmax: {x_size}\tY: {y} Ymax: {y_size}"); }
            }
        }
        public matrix(int x_size, int y_size)
        {
            this.x_size = x_size;
            this.y_size = y_size;
            if (x_size > 0 && y_size > 0)
            {
                _matrix = new double[y_size, x_size];
                for (int i = 0; i < y_size; i++)
                {
                    for (int j = 0; j < x_size; j++)
                    {
                        _matrix[i, j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// I think this is so I can make a "square matrix"
        /// so if a user inputs 2. it will make a matrix like
        /// [0,0]
        /// [0,0]
        /// currently has 0 references. and I may delete later. 
        /// I think I made this as a "helper" to generate an easy blank square matrix.
        /// </summary>
        /// <param name="square_size"></param>
        public matrix(int square_size)
        {
            x_size = square_size;
            y_size = square_size;
            if(square_size>0)
            {
                _matrix = new double[square_size, square_size];
                for (int i = 0; i < y_size; i++)
                {
                    for (int j = 0; j < x_size; j++)
                    {
                        _matrix[i, j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// this allows the setting of the _matrix, size_x,size_y values. 
        /// </summary>
        /// <param name="matrix_in"></param>
        public matrix(double[,] matrix_in)
        {
            _matrix = matrix_in;
            x_size = _matrix.GetLength(1);
            y_size = _matrix.GetLength(0);
        }

        /// <summary>
        /// ==
        /// note: different than "object.equals" which c# is strongly suggesting I address...
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator ==(matrix l, matrix r)
        {
            //todo:
            //if matrices not same size return false.
            //else iterate and find out if equal...
            // need to work on this. working on getting git setup in vs.
            bool returnValue = false;
            if (l.x_size == r.x_size && l.y_size == r.y_size)
            {
                for(int i = 0; i < l.x_size; i++)
                {
                    for (int j = 0; j < l.y_size; j++)
                    {
                        if (l[i,j] != r[i,j])
                        {
                            return returnValue;
                        }
                    }
                }
                returnValue = true;
            }
                return returnValue;
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator !=(matrix l, matrix r) => !(l == r);

        /// <summary>
        /// matrix multiplication
        /// note: only 4x4 matrices (for now?) 
        /// </summary>
        /// <param name="l">the left matrix</param>
        /// <param name="r">the right matrix</param>
        /// <returns>if 4x4 matrix the multiplied matrix.</returns>
        public static matrix operator *(matrix l, matrix r)
        {
            matrix ret=new matrix(4);
            if (l.x_size == r.x_size && r.y_size == l.y_size &&l.x_size==4)
            {
                for(int i = 0; i < 4; i++)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        ret[i, j] = l[i,0] * r[0,j] + l[i, 1] * r[1, j] + l[i, 2] * r[2, j] + l[i, 3] * r[3, j];
                    }
                }
            }
            return ret;
        }
        public static tuple operator *(matrix l, tuple r)
        {
            // note to self find way to use loops to make this easier to read
            // may need to make tuples iterable to do that though...
            tuple ret = new tuple(0, 0, 0, 0);
            if(l.x_size==4&&l.y_size==4)
            {
                ret = new tuple(l[0, 0] * r.x + l[0, 1] * r.y + l[0, 2] * r.z + l[0, 3] * r.w, l[1, 0] * r.x + l[1, 1] * r.y + l[1, 2] * r.z + l[1, 3] * r.w, l[2, 0] * r.x + l[2, 1] * r.y + l[2, 2] * r.z + l[2, 3] * r.w, l[3, 0] * r.x + l[3, 1] * r.y + l[3, 2] * r.z + l[3, 3] * r.w);
                
            }
            return ret;
        }

    }
}
