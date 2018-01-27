using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Maximal_Sum
{
    class Program
    {
        static void CalcSum(int[,] matrix, int row, int col, ref int maxSum, ref int maxSumMatrixRow, ref int maxSumMatrixCol)
        {
            int currSum = 0;
            for (int i = row; i < row + 3; ++i)
            {
                for (int j = col; j < col + 3; j++)
                {
                    currSum += matrix[i, j];
                }
            }
            if (currSum > maxSum)
            {
                maxSum = currSum;
                maxSumMatrixRow = row;
                maxSumMatrixCol = col;
            }
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }

            }
            int maxSum = Int32.MinValue;
            int maxSumMatrixRow = -1;
            int maxSumMatrixCol = -1;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    CalcSum(matrix, i, j, ref maxSum, ref maxSumMatrixRow, ref maxSumMatrixCol);
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxSumMatrixRow; i < maxSumMatrixRow + 3; i++)
            {
                for (int j = maxSumMatrixCol; j < maxSumMatrixCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
