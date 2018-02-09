using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Arrange_Numbers
{
    
    class Program
    {
        
        static readonly Dictionary<int, string> numsAndWords = new Dictionary<int, string>()
        {
            {0, "zero" },
            {1, "one" },
            {2, "two" },
            {3, "three" },
            {4, "four" },
            {5, "five" },
            {6, "six" },
            {7, "seven" },
            {8, "eight" },
            {9, "nine" },

        };

        static int WordToNum(string s)
        {
            if (s.Contains("-"))
            {
                string[] tokens = s.Split('-').ToArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < tokens.Length; i++)
                {
                    int currNum = numsAndWords.FirstOrDefault(x => x.Value == tokens[i]).Key;
                    sb.Append(currNum.ToString());
                }
                return int.Parse(sb.ToString());
            }
            return numsAndWords.FirstOrDefault(x => x.Value == s).Key;
        }
        static string NumToWord(int num)
        {
            
            int temp = num;
            int digits = 0;
            while (temp != 0)
            {
                ++digits;
                temp /= 10;
            }
            if (digits < 2)
            {
                return numsAndWords[num];
            }
            temp = num;
            
            Stack<string> reversedNums = new Stack<string>();
            int idx = 0;
            for (int i = 0; i < digits; i++)
            {
                idx = temp % 10;
                temp /= 10;
                reversedNums.Push(numsAndWords[idx]);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digits; i++)
            {
                sb.Append(reversedNums.Pop());
                if (i < digits - 1)
                {
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            string [] intWords = nums.Select(NumToWord).OrderBy(x => x).ToArray();
            int[] orderedIntsFromWords = intWords.Select(WordToNum).ToArray();
            Console.WriteLine(string.Join(", ", orderedIntsFromWords));
        }
    }
}
