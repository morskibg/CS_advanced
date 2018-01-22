using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> openBraces = new Stack<char>();
            Queue<char> closedBraces = new Queue<char>();
            foreach (var bracket in input)
            {
                if (bracket == '[' || bracket == '{' || bracket == '(')
                {
                    openBraces.Push(bracket);
                }
                else if(openBraces.Count > closedBraces.Count)
                {
                    closedBraces.Enqueue(bracket);
                }
            }

            if (openBraces.Count != closedBraces.Count)
            {
                Console.WriteLine("NO");
                return;
            }
            while (openBraces.Count > 0)
            {
                char currOpen = openBraces.Pop();
                char currClose = closedBraces.Dequeue();
                if (currOpen == '{' && currClose != '}')
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (currOpen == '(' && currClose != ')')
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (currOpen == '[' && currClose != ']')
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
