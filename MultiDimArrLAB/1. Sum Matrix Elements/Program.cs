using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> dimensions = Console.ReadLine().Split(',').Select(x => x.Trim()).Select(int.Parse).ToList();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows,cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] currCol = Console.ReadLine().Split(',').Select(x => x.Trim()).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currCol[j];
                    sum += matrix[i, j];
                }
            }
            dimensions.Add(sum);
            foreach (var i in dimensions)
            {
                Console.WriteLine(i);
            }
        }
    }
}
