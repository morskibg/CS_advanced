using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Collect_Resources
{
    class Program
    {
        private static readonly string[] validResources = {"stone", "gold", "wood", "food"};
        static void Main(string[] args)
        {
            
            string[] resources = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToArray();
            
            int maxSum = int.MinValue;
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                bool[] isVisited = new bool[resources.Length];
                int [] tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).Select(int.Parse).ToArray();
                int start = tokens[0];
                int step = tokens[1];
                int idx = start;
                while (true)
                {
                    
                    if (isVisited[idx] == true)
                    {
                        break;
                    }
                    string currResource = resources[idx];
                    string[] tokens2 = currResource.Split(new [] {"_"}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim()).Select(x => x.ToLower()).ToArray();
                    if (validResources.Contains(tokens2[0]))
                    {
                        int qty = tokens2.Length > 1 ? int.Parse(tokens2[1]) : 1;
                        sum += qty;
                        isVisited[idx] = true;
                    }
                    
                    idx += step;
                    idx %= resources.Length;
                }
                if (maxSum < sum)
                {
                    maxSum = sum;
                }
               
            }
            Console.WriteLine(maxSum);
        }
    }
}
