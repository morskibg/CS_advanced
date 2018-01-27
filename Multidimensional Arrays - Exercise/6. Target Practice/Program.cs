using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6.Target_Practice
{
    class Program
    {
        static bool IsInBounds(int rows, int cols, int currRow, int currCol)
        {
            bool res = currRow >= 0 && currRow < rows && currCol >= 0 && currCol < cols;
            return res;
        }

        struct Point
        {
            public int I { get; set; }
            public int J { get; set; }

            public Point(int i, int j)
            {
                this.I = i;
                this.J = j;
            }
        }
        static void FillStairsWithSnakes(char[,] matrix, int rows, int cols, string snake)
        {
            char[] snakeChars = snake.ToCharArray();
            int snakeSize = snakeChars.Length;
            bool isEvenRows = (rows % 2 == 0);
            int snakeIdx = 0;
            for (int i = rows - 1; i >= 0; --i)
            {
                bool isAtEvenRow = ((i + 1) % 2 == 0);
                bool writeBackward = (isEvenRows && isAtEvenRow) ||
                                     (!isEvenRows && !isAtEvenRow);

                for (int j = writeBackward ? cols - 1 : 0;
                    writeBackward ? j >= 0 : j < cols;
                    j += writeBackward ? -1 : 1)
                {
                    matrix[i, j] = snakeChars[snakeIdx++];
                    if (snakeIdx == snakeSize)
                    {
                        snakeIdx = 0;
                    }
                }
            }
        }

        static void FindDamageCoordinates(char[,] matrix, int rows, int cols, int currRow,
            int currCol, int impactRadius, int impactRow, int impactCol)
        {
           
            matrix[currRow, currCol] = ' ';
            if (IsInBounds(rows, cols, currRow, currCol + 1) && matrix[currRow, currCol + 1] != ' '
                && CalcRadiusVector(currRow, currCol + 1, impactRow, impactCol, impactRadius))
            {
                FindDamageCoordinates(matrix, rows, cols, currRow, currCol + 1, impactRadius, impactRow, impactCol);
            }
            if (IsInBounds(rows, cols, currRow, currCol - 1) && matrix[currRow, currCol - 1] != ' '
                && CalcRadiusVector(currRow, currCol - 1, impactRow, impactCol, impactRadius))
            {
                FindDamageCoordinates(matrix, rows, cols, currRow, currCol - 1, impactRadius, impactRow, impactCol);
            }
            if (IsInBounds(rows, cols, currRow + 1, currCol) && matrix[currRow + 1, currCol] != ' '
                && CalcRadiusVector(currRow + 1, currCol, impactRow, impactCol, impactRadius))
            {
                FindDamageCoordinates(matrix, rows, cols, currRow + 1, currCol, impactRadius, impactRow, impactCol);
            }
            if (IsInBounds(rows, cols, currRow - 1, currCol) && matrix[currRow - 1, currCol] != ' '
                && CalcRadiusVector(currRow - 1, currCol, impactRow, impactCol, impactRadius))
            {
                FindDamageCoordinates(matrix, rows, cols, currRow - 1, currCol, impactRadius, impactRow, impactCol);
            }
        }

        static bool CalcRadiusVector(int row, int col, int impactRow, int impactCol, int impactRadius)
        {
            int num = (row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol);
            double vector = Math.Sqrt((double)num);
            if (vector <= (double) impactRadius)
            {
                return true;
            }
            return false;
        }

        static void CompressMatrix(char[,] matrix, int rows, int cols)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int i = rows - 1; i > 0; i--)
                {
                    if (matrix[i, j] == ' ')
                    {
                        int k = i - 1;
                        while (k >= 0)
                        {
                            if (matrix[k, j] != ' ')
                            {
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = ' ';
                                break;
                            }
                            --k;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
           
            string snake = Console.ReadLine();

            int[] shotParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            FillStairsWithSnakes(matrix, rows, cols, snake);
            
            FindDamageCoordinates(matrix, rows, cols, shotParams[0], shotParams[1], shotParams[2], shotParams[0], shotParams[1]);
            CompressMatrix(matrix, rows, cols);
           
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            
        }
    }
}
