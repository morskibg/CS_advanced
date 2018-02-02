using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {      
        
        static void Main(string[] args)
        {
            int []nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string option = Console.ReadLine();
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            for (int i = nums[0]; i <= nums[1]; i++)
            {
                if(option == "odd" && isOdd(i))
                {
                    Console.Write($"{i} ");
                }
                else if (option == "even" && isEven(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
