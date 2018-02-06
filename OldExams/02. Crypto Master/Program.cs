using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int maxCount = nums.Length * nums.Length;
            int step = 0;
            int idx = 0;
            int maxSequenceCounter = Int32.MinValue;
            
            for (int i = 0; i < maxCount; i++)
            {
                int currCount = Calc(nums, idx, step);
               
                if (maxSequenceCounter < currCount)
                {
                    maxSequenceCounter = currCount;
                }
                
                if (step < nums.Length)
                {
                    ++step;
                }
                else
                {
                    step = 1;
                    ++idx;
                }
            }
            Console.WriteLine(maxSequenceCounter);

        }

        static int Calc(int[] nums, int startIdx, int step)
        {
            int idx = startIdx % nums.Length;
            int prevNum = nums[idx];
            int counter = 1;
            while (true)
            {
                idx += step;
                idx %= nums.Length;
                if(nums[idx] > prevNum)
                {
                    prevNum = nums[idx];
                    
                    ++counter;
                }
                else
                {
                    break;
                }
            }
            return counter;
        }
    }
}
