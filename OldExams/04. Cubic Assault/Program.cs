using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "Count em all")
                {
                    break;
                }
                string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                
                //string[] tokens = { "Cubica", "Black", "1" };
                string region = tokens[0];
                string meteorType = tokens[1];
                long meteorsQty =  long.Parse(tokens[2]);
                if (!regions.ContainsKey(region))
                {
                    regions[region] = new Dictionary<string, long>
                    {
                        { "Red", 0},
                        { "Black", 0},
                        { "Green", 0}
                    };                        
                }
                regions[region][meteorType] += meteorsQty;
                if(regions[region][meteorType] >= 1000000)
                {
                    if(meteorType == "Green")
                    {
                        while(regions[region]["Green"] >= 1000000)
                        {
                            regions[region]["Green"] -= 1000000;
                            regions[region]["Red"]++;
                        }                       
                    }
                    if (meteorType != "Black")
                    {
                        while (regions[region]["Red"] >= 1000000)
                        {
                            regions[region]["Red"] -= 1000000;
                            regions[region]["Black"]++;
                        }
                    }
                }
            }
            foreach (var kvp in regions.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var innerKVP in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {innerKVP.Key} : {innerKVP.Value}");
                }
            }
        }
    }
}
