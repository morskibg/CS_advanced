using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int[]> GetMin = x => x.OrderBy(y => y).ToArray();
            Console.WriteLine(GetMin(nums)[0]);
        }
    }
}
