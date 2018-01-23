using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static long[] lookup = new long[51];
        static long GetFib(long num)
        {
            if(num == 1 || num == 2)
            {
                lookup[1] = 1;
                lookup[2] = 1;
                return 1;
            }
            if(lookup[num - 1] == 0)
            {
                long calcFib = GetFib(num - 1) + GetFib(num - 2);
                lookup[num] = calcFib;
            }
            return lookup[num - 1] + lookup[num - 2]; 
            
           
        }
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());  
            long fib = GetFib(n);
            Console.WriteLine(fib);
           
        }
    }
}
