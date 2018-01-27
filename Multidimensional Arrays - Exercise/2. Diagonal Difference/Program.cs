using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            long diagLr = 0;
            long diagRl = 0;
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0, k = n - 1; j < n; j++, --k)
                {
                    if (i == j)
                    {
                        diagLr += row[j];
                    }
                    if (i == k)
                    {
                        diagRl += row[j];
                    }
                    
                }
            }
            Console.WriteLine(Math.Abs(diagLr - diagRl));

        }
    }
}
