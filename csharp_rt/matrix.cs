using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
