using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Action_Point
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);
            string[] input = Console.ReadLine().Split(' ').ToArray();
            foreach (var name  in input)
            {
                print(name);
            }
        }
    }
}
