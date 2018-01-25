using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(',').Select(x => x.Trim()).Select(int.Parse).ToArray();
            Array.Reverse(nums);
            int[][] orderedByModuloOf3 = new int[3][];
            int[] countReminders = new int[3];
            foreach (var num in nums)
            {
                int reminder = Math.Abs(num % 3);
                countReminders[reminder]++;
            }
            orderedByModuloOf3[0] = new int[countReminders[0]];
            orderedByModuloOf3[1] = new int[countReminders[1]];
            orderedByModuloOf3[2] = new int[countReminders[2]];
            foreach (var num in nums)
            {
                int reminder = Math.Abs(num % 3);
                if (reminder == 0)
                {
                    orderedByModuloOf3[0][--countReminders[0]] = num;
                }
                else if (reminder == 1)
                {
                    orderedByModuloOf3[1][--countReminders[1]] = num;
                }
                else
                {
                    orderedByModuloOf3[2][--countReminders[2]] = num;
                }
            }
            foreach (int[] row in orderedByModuloOf3)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            
        }
    }
}
