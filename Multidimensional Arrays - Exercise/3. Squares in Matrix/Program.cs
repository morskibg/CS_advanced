using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Squares_in_Matrix
{
    class Program
    {
        static bool IsEqual(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] &&
                matrix[row, col] == matrix[row + 1, col + 1])
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x[0])
                    .ToArray();
                
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
                
            }
            int counter = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (IsEqual(matrix, i, j))
                    {
                        ++counter;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
