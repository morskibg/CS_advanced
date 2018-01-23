using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);
            int num = int.Parse(Console.ReadLine());
            while(num - 2 > 0)
            {
                long prev = stack.Pop();
                long beforePrev = stack.Peek();
                stack.Push(prev);
                stack.Push(prev + beforePrev);
                --num;
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
