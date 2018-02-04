using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> jems = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            bool[] jemsAndCount = new bool[jems.Count];
           
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Forge")
                {
                    break;
                }
                string[] tokens = input.Split(';').ToArray();
                string command = tokens[0];
                string filterType = tokens[1];
                int filterParam = int.Parse(tokens[2]);
                if (command == "Reverse")
                {
                    for (int i = 0; i < jemsAndCount.Length; i++)
                    {
                        jemsAndCount[i] = false;
                    }
                    continue;
                }
                GlobalFilter(jems, jemsAndCount, filterParam, filterType);
            }
            for (int i = 0; i < jemsAndCount.Length; i++)
            {
                if (jemsAndCount[i] == false)
                {
                    Console.Write($"{jems[i]} ");
                }
            }
        }

        private static void GlobalFilter(List<int> jems, bool[] jemsAndCount, int pattern, string filterType)
        {
            for (int i = 0; i < jems.Count; i++)
            {
                int leftJem = i == 0 ? 0 : jems[i - 1];
                int rightJem = i == jems.Count - 1 ? 0 : jems[i + 1];
                int sum = leftJem + jems[i];
                if (filterType == "Sum Right")
                {
                    sum = rightJem + jems[i];
                }
                else if (filterType == "Sum Left Right")
                {
                    sum += rightJem;
                }
                if (sum == pattern)
                {
                    jemsAndCount[i] = true;
                }
            }
        }
    }
}
