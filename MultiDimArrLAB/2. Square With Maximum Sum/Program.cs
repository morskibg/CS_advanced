using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Square_With_Maximum_Sum
{
    class Program
    {

        
        static int CalcSum(int[,] matrix, int currRow, int currCol)
        {
            return matrix[currRow, currCol] + matrix[currRow, currCol + 1] + matrix[currRow + 1, currCol] +
                   matrix[currRow + 1, currCol + 1];
        }

        static void CalcSubMatrix(int[,] matrix, int[,] subMatrix,  int currRow, int currCol, ref int currMaxSum)
        {

            int currSum = CalcSum(matrix, currRow, currCol);
            if (currSum > currMaxSum)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        subMatrix[i, j] = matrix[currRow + i, currCol + j];
                    }
                }
                currMaxSum = currSum;
            }
        }

        static void FindBiggestSubMatrix(int[,] matrix, int[,] subMatrix, int currRow, int currCol, ref int currMaxSum,
            int rows, int cols, bool [,] visited)
        {
            
            CalcSubMatrix(matrix, subMatrix, currRow, currCol, ref currMaxSum);
            if (currCol + 1 < cols - 1 && visited[currRow, currCol + 1] == false)
            {
                visited[currRow, currCol + 1] = true;
                FindBiggestSubMatrix(matrix, subMatrix, currRow, currCol + 1, ref currMaxSum, rows, cols, visited);
            }
            if (currRow + 1 < rows - 1 && visited[currRow + 1, currCol] == false)
            {
                visited[currRow + 1, currCol] = true;
                FindBiggestSubMatrix(matrix, subMatrix, currRow + 1, currCol, ref currMaxSum, rows, cols, visited);
            }
            if (currRow - 1 >= 0 && visited[currRow - 1, currCol] == false)
            {
                visited[currRow - 1, currCol] = true;
                FindBiggestSubMatrix(matrix, subMatrix, currRow - 1, currCol, ref currMaxSum, rows, cols, visited);
            }
            if (currCol - 1 >= 0 && visited[currRow, currCol - 1] == false)
            {
                visited[currRow, currCol - 1] = true;
                FindBiggestSubMatrix(matrix, subMatrix, currRow, currCol - 1, ref currMaxSum, rows, cols, visited);
            }
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(',').Select(x => x.Trim()).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            bool [,] visitedMatrix = new bool[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                int[] currCol = Console.ReadLine().Split(',').Select(x => x.Trim()).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currCol[j];
                }
            }
            int[,] biggestMatrix = new int[2,2];
            int currMaxSum = Int32.MinValue;
            
            FindBiggestSubMatrix(matrix, biggestMatrix, 0, 0, ref currMaxSum, rows, cols, visitedMatrix);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(biggestMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(currMaxSum);
        }
    }
}
