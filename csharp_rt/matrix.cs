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
                else { Console.Out.WriteLine("NO :^): matrix \"get set\" OOB"); }
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

        public matrix(double[,] matrix_in)
        {
            _matrix = matrix_in;
            x_size = _matrix.GetLength(1);
            y_size = _matrix.GetLength(0);
        }

    }
}
