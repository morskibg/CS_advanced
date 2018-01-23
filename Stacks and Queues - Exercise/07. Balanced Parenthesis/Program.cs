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
            if(input.Length == 1)
            {
                Console.WriteLine("NO");
                return;
            }
            Stack<char> stack = new Stack<char>();
            foreach(char ch in input)
            {
                if(ch == '{' || ch == '[' || ch == '(')
                {
                    stack.Push(ch);
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    char lastPar = stack.Pop();
                    char matchingLatPar;
                    if (lastPar == '{')
                    {
                        matchingLatPar = '}';
                    }
                    else if(lastPar == '[')
                    {
                        matchingLatPar = ']';
                    }
                    else
                    {
                        matchingLatPar = ')';
                    }

                    if(matchingLatPar == ch)
                    {
                        continue;                        
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
            
        }
    }
}
