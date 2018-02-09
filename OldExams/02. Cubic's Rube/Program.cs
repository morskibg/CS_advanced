using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        

        static bool IsInRube(int dimension, int x, int y, int z)
        {
            return x >= 0 && x < dimension && y >= 0 && y < dimension && z >= 0 && z < dimension;
        }
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            int[,,] rube = new int[dimension, dimension, dimension];
            long allCellsSum = 0;
            int cellChanheCounter = 0;
           
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Analyze")
                {
                    break;
                }
                int[] coordinates = input.Split().Select(int.Parse).ToArray();
                if (IsInRube(dimension, coordinates[0], coordinates[1], coordinates[2]))
                {                    
                    if (coordinates[3] != 0)
                    {
                        allCellsSum += coordinates[3];
                        ++cellChanheCounter;
                    }                                 
                }
            }
            Console.WriteLine(allCellsSum);
            Console.WriteLine(dimension * dimension * dimension - cellChanheCounter);

        }
    }
}
