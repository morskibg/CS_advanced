using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = Int32.MinValue;
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (query.Length > 1)
                {
                    if (max < query[1])
                    {
                        max = query[1];
                    }
                    stack.Push(query[1]);
                }
                else if (query[0] == 2)
                {
                    if (stack.Peek() == max)
                    {
                        max = Int32.MinValue;
                    }
                    stack.Pop();
                }
                else if (stack.Count > 0)
                {
                    if (max == Int32.MinValue)
                    {
                        max = stack.Max();
                    }
                    Console.WriteLine(max);
                }
            }
        }
    }
}
