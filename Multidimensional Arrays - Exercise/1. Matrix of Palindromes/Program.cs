using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int firstLast = i + 97;
                    int middle = i + j + 97;
                    char a = (char) firstLast;
                    char b = (char) middle;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(a);
                    sb.Append(b);
                    sb.Append(a);
                    matrix[i, j] = sb.ToString();
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            int t = 0;
        }
    }
}
