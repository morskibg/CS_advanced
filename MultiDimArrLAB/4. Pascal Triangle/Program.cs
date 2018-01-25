using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Pascal_Triangle
{
    class PascalTraingle
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            
            for (int r = 0; r < rows; r++)
            {
                for (int space = 1; space <= rows - r; space++)
                {
                    Console.Write(" ");
                }
                long number = 1;
                for (int c = 0; c <= r; c++)
                {
                    Console.Write(" " + number);
                    number = number * (r - c) / (c + 1);
                }
                Console.WriteLine("");
            }

        }
    }
}
