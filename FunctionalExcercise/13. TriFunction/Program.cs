using System;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int pattern = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ').ToArray();
            Func<string, int, bool> IsCorrectWord = (str, num) => str.ToCharArray().Select(ch => (int)ch).Sum() >= num;
            Func<string[], int, Func<string, int, bool>, string> TraverseNames =
                (strArr, num, func) => strArr.FirstOrDefault(str => func(str, num));
            Console.WriteLine(TraverseNames(names, pattern,IsCorrectWord));

        }

        
    }
}
