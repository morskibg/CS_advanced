using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int divizor = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisible = x => x % divizor != 0;
            int[] filtered = nums.Where(isDivisible).ToArray();
            Action<int[]> print = x => Console.WriteLine(string.Join(" ",x.Reverse()));
            print(filtered);
        }
    }
}
