using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Predicate_For_Names
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ').ToArray();
            Func<string, bool> isSmallOrEqual = x => x.Length <= len;
            Console.WriteLine(string.Join("\n", names.Where(isSmallOrEqual)));

        }
    }
}
