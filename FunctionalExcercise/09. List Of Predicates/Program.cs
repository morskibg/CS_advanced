using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisder = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int, int, bool> checker = (x, y) => x % y == 0;
            for (int i = 1; i <= n; i++)
            {
                bool isGood = true;
                foreach (var div in divisder)
                {
                    if (!checker(i, div))
                    {
                        isGood = false;
                        break;
                    }
                }
                if (isGood)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
