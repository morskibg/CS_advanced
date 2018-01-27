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
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            bool isEvenRows = (rows % 2 == 0);
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            char[] snakeCh = snake.ToCharArray();
            int snakeSize = snakeCh.Length;
            int[] shotParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int snakeIdx = 0;
            for (int i = rows - 1; i >= 0; --i)
            {
                int j = 0;
                bool isReversed = false;
                if (isEvenRows)
                {
                    if (i % 2 == 0)
                    {
                        j = cols - 1;
                        isReversed = true;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        j = cols - 1;
                        isReversed = true;
                    }
                }
                for (; j == 0 ? j < cols : j >= 0; )
                {
                    matrix[i, j] = snakeCh[snakeIdx++];
                    if (snakeIdx == snakeSize - 1)
                    {
                        snakeIdx = 0;
                    }
                    if (isReversed)
                    {
                        --j;
                    }
                    else
                    {
                        ++j;
                    }
                }
            }
            int t = 0;
        }
    }
}
