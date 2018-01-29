using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Parking_System
{
    class Program
    {
        static int FindFreeSpot(bool[,] matrix, int destRow, int destCol, int cols)
        {
            int leftCol = destCol;
            int rightCol = destCol;

            while (true)
            {
                if (leftCol - 1 > 0)
                {
                    if (matrix[destRow, leftCol - 1] == false)
                    {
                        matrix[destRow, leftCol - 1] = true;
                        return leftCol - 1;
                    }
                    --leftCol;
                }
                else if (rightCol + 1 < cols)
                {
                    if (matrix[destRow, rightCol + 1] == false)
                    {
                        matrix[destRow, rightCol + 1] = true;
                        return rightCol + 1;
                    }
                    ++rightCol;
                }
                else
                {
                    return -1;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool[,] matrix = new bool[dimensions[0], dimensions[1]];
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "stop")
                {
                    break;
                }
                int[] query = line.Split(' ').Select(int.Parse).ToArray();
                int entranceRow = query[0];
                int destCol = query[1];
                int destRow = query[2];
                if (matrix[destRow, destCol] == false)
                {
                    matrix[destRow, destCol] = true;
                    Console.WriteLine(Math.Abs(entranceRow - destRow) + destCol + 1);
                }
                else
                {
                    int freeCol = FindFreeSpot(matrix, destRow, destCol, dimensions[1]);
                    if (freeCol < 0)
                    {
                        Console.WriteLine($"Row {destRow} full");
                    }
                    else
                    {
                        Console.WriteLine(Math.Abs(entranceRow - destRow) + freeCol + 1);
                    }
                }
            }
        }
    }
}
