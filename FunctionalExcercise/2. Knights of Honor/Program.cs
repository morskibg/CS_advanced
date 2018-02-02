using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");
            string[] input = Console.ReadLine().Split(' ').ToArray();
            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
