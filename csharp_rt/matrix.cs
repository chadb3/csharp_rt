﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rt
{
    public class Matrix
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
        public Matrix(int x_size, int y_size)
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
        public Matrix(int square_size)
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
        public Matrix(double[,] matrix_in)
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
        public static bool operator ==(Matrix l, Matrix r)
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
                        // old if
                        //if (l[i,j] != r[i,j])
                        // note: while this is in more in line with floats ( I might convert it to floats later (I don't know why I picked doubles))
                        // I used this level of precision as the calculated value is more precise than the values I test for in unit tests (which expect float level of precision)
                        // if this is hit then false is returned (are not equal)
                        if (Math.Abs(l[i,j] - r[i,j])>0.00001)
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
        public static bool operator !=(Matrix l, Matrix r) => !(l == r);

        /// <summary>
        /// matrix multiplication
        /// note: only 4x4 matrices (for now?) 
        /// </summary>
        /// <param name="l">the left matrix</param>
        /// <param name="r">the right matrix</param>
        /// <returns>if 4x4 matrix the multiplied matrix.</returns>
        public static Matrix operator *(Matrix l, Matrix r)
        {
            Matrix ret=new Matrix(4);
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
        public static Tuple operator *(Matrix l, Tuple r)
        {
            // note to self find way to use loops to make this easier to read
            // may need to make tuples iterable to do that though...
            Tuple ret = new Tuple(0, 0, 0, 0);
            if(l.x_size==4&&l.y_size==4)
            {
                ret = new Tuple(l[0, 0] * r.x + l[0, 1] * r.y + l[0, 2] * r.z + l[0, 3] * r.w, l[1, 0] * r.x + l[1, 1] * r.y + l[1, 2] * r.z + l[1, 3] * r.w, l[2, 0] * r.x + l[2, 1] * r.y + l[2, 2] * r.z + l[2, 3] * r.w, l[3, 0] * r.x + l[3, 1] * r.y + l[3, 2] * r.z + l[3, 3] * r.w);
                
            }
            return ret;
        }
        /// <summary>
        /// .equals should work now.
        /// This will allow AreEqual to work in unit testing
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this==(Matrix)obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Matrix identity()
        {
            return new Matrix(new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
        }
        /// <summary>
        /// determinate
        /// made it det to save space. 
        /// </summary>
        /// <returns>[0,0]*[1,1]-[0,1]*[1,0]</returns>
        public double det()
        {
            double ans = 0.0d;
            if (this.x_size == 2 && this.y_size == 2)
            {
                ans = this._matrix[0, 0] * this._matrix[1, 1] - this._matrix[0, 1] * this._matrix[1, 0];
            }
            else
            {
                for(int i=0;i<this.x_size;i++)
                {
                    ans += this._matrix[0, i] * cofactor(0, i);
                }
            }
            return ans;
        }
        /// <summary>
        /// Submatrix
        /// </summary>
        /// <param name="row">Row to ignore in new matrix</param>
        /// <param name="col">Col to ignore in new matrix</param>
        /// <returns></returns>
        public Matrix subMat(int row, int col)
        {
            var new_x = this.x_size - 1;
            var new_y = this.y_size - 1;
            var new_i = 0;
            var new_j=0;
            Matrix ret = new Matrix(new double[new_x,new_y]) ;
            /*Debug Prints*/
            //Console.WriteLine(this.x_size);
            //Console.WriteLine(ret.x_size);
            for (int i = 0;i<this.x_size;i++)
            {
                for (int j = 0; j < this.y_size; j++)
                {
                    if (i != row && j != col)
                    {
                        // Debug print: note for permanent removal 
                        //Console.WriteLine($"i:{i} j:{j}\n");
                        ret[new_i, new_j] = this._matrix[i, j];
                        new_j++; 
                        
                    }
                }
                if(i!=row)
                {
                    new_i++;
                }
                new_j = 0;
            }
            return ret;
        }

        public double minor(int row,int col)
        {
            double ret = 0.0d;
            ret = this.subMat(row,col).det();
            return ret;
        }

        public double cofactor(int row,int col)
        {
            double ret = 0.0d;
            //string debug="init";
            // PEMDAS
            if ((row + col) % 2 == 0)
            {
                ret = minor(row, col);
                //debug = "even";
            }
            else
            {
                ret = -minor(row, col);
                //debug = "odd";
            }
            /* Debug Print */
            //Console.WriteLine($"cofactor{row}-{col}: {debug } ~~ {minor(row,col)}");
            return ret;
        }
        /// <summary>
        /// Not sure if this is used outside of the unit tests
        /// returns true if det !=0
        /// if true then the matrix is invertible
        /// </summary>
        /// <returns></returns>
        public bool isInvertible()
        {
            bool ret = false;
            if(det()!=0)
            {
                ret = true;
            }
            return ret;
        }

        public Matrix inverse()
        {
            Matrix ret = new Matrix(this.x_size);
            if (isInvertible())
            {
                //var c = 0.0d;
                for(int row = 0; row < this.x_size; row++)
                {
                    for(int col = 0; col < this.y_size; col++)
                    {
                        var c = this.cofactor(row, col);
                        ret[col,row] = c/this.det();
                    }
                }
            }

            return ret;
        }

        public static Matrix translation(double x, double y, double z)
        {
            Matrix returnMat = Matrix.identity();
            returnMat[0, 3] = x;
            returnMat[1, 3] = y;
            returnMat[2,3] = z; 
            //x,y,z are stacked in the last col from 0-2
            // with 3 3 being 1 from the identity matrix.
            return returnMat;
            // non-static: translation_ns
            // non-static is for chaining as it is not possible with static.
        }
        public Matrix translation_ns(double x, double y, double z)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 3] = x;
            retVal[1, 3] = y;
            retVal[2, 3] = z;
            return retVal * this;
        }
        public static Matrix scaling(double x, double y, double z)
        {
            Matrix returnMat = Matrix.identity();
            returnMat[0, 0] = x;
            returnMat[1, 1] = y;
            returnMat[2,2] = z;
            return returnMat;
            // non-static: scaling_ns
            // non-static is for chaining as it is not possible with static.
        }
        /// <summary>
        /// Non-Static Matrix scaling Method.
        /// This is mainly used for chaining functions together. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Matrix scaling_ns(double x, double y, double z)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 0] = x;
            retVal[1, 1] = y;
            retVal[2, 2] = z;
            return retVal * this;
        }

        public static Matrix rotation_x(double valIn)
        {
            Matrix retVal=Matrix.identity();
            retVal[1, 1] = Math.Cos(valIn);
            retVal[1, 2] = -Math.Sin(valIn);
            retVal[2, 1] = Math.Sin(valIn);
            retVal[2, 2] = Math.Cos(valIn);
            return retVal;
            // non-static: rotation_x_ns
            // non-static is for chaining as it is not possible with static.
        }
        public Matrix rotation_x_ns(double valIn)
        {
            Matrix retVal=Matrix.identity();
            retVal[1, 1] = Math.Cos(valIn);
            retVal[1, 2] = -Math.Sin(valIn);
            retVal[2, 1] = Math.Sin(valIn);
            retVal[2, 2] = Math.Cos(valIn);
            return retVal*this;
        }
        public static Matrix rotation_y(double valIn)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 0] = Math.Cos(valIn);
            retVal[0, 2] = Math.Sin(valIn);
            retVal[2, 0] = -Math.Sin(valIn);
            retVal[2, 2] = Math.Cos(valIn);
            return retVal;
            // non-static:rotation_y_ns
            // non-static is for chaining as it is not possible with static.
        }
        public Matrix rotation_y_ns(double valIn)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 0] = Math.Cos(valIn);
            retVal[0, 2] = Math.Sin(valIn);
            retVal[2, 0] = -Math.Sin(valIn);
            retVal[2, 2] = Math.Cos(valIn);
            return retVal*this;
        }

        public static Matrix rotation_z(double valIn)
        {
            Matrix retVal=Matrix.identity();
            retVal[0,0] = Math.Cos(valIn);
            retVal[0,1] = -Math.Sin(valIn);
            retVal[1,0] = Math.Sin(valIn);
            retVal[1,1] = Math.Cos(valIn);
            return retVal;
            // non-static: rotation_z_ns
            //non-static is for chaining as it is not possible with static.
        }
        public Matrix rotation_z_ns(double valIn)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 0] = Math.Cos(valIn);
            retVal[0, 1] = -Math.Sin(valIn);
            retVal[1, 0] = Math.Sin(valIn);
            retVal[1, 1] = Math.Cos(valIn);
            return retVal*this;
        }
        public static Matrix shearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix retVal = Matrix.identity();
            retVal[0, 1] = xy;
            retVal[0,2] = xz;
            retVal[1,0]= yx;
            retVal[1,2] = yz;
            retVal[2,0]= zx;
            retVal[2,1] = zy;
            return retVal;
            //non-static: shearing_ns
            //non-static is for chaining as it is not possible with static.
        }
        public Matrix shearing_ns(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix retVal= Matrix.identity();
            retVal[0, 1] = xy;
            retVal[0, 2] = xz;
            retVal[1, 0] = yx;
            retVal[1, 2] = yz;
            retVal[2, 0] = zx;
            retVal[2, 1] = zy;
            return retVal*this;
        }
        /// <summary>
        /// Note: this was on page 37
        /// I missed this, and was not needed again until page 82.
        /// </summary>
        /// <returns></returns>
        public Matrix transpose()
        {
            Matrix ret = new Matrix(x_size, y_size);
            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    ret[i, j] = this[j, i];
                }
            }

            return ret;
        }

        public static Matrix view_transform(csharp_rt.Tuple from_in, csharp_rt.Tuple to_in, csharp_rt.Tuple up_in)
        {
            Matrix ret= Matrix.identity();
            //test print
            //Console.WriteLine("to:{0}\nfrom:{1}", to_in, from_in);

            csharp_rt.Tuple forward_vector = (to_in - from_in).normalize();
            //test print
            // can delete after next (push/when noticed)
            //Console.WriteLine(forward_vector);

            csharp_rt.Tuple left_vector = forward_vector.cross(up_in.normalize());

            //test print
            // can delete after next (push/when noticed)
            //Console.WriteLine("left vec: {0}", left_vector);

            csharp_rt.Tuple true_up = left_vector.cross(forward_vector);


            Matrix orientation = new Matrix(new double[,] { { left_vector.x, left_vector.y, left_vector.z, 0 }, 
                                                            { true_up.x, true_up.y, true_up.z, 0 }, 
                                                            { -forward_vector.x, -forward_vector.y, -forward_vector.z, 0 }, 
                                                            { 0, 0, 0, 1 } });
            return orientation*Matrix.translation(-from_in.x,-from_in.y,-from_in.z);
        }

       


    }
}
