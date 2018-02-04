using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void ProcessFilter(Dictionary<string, int> names, Func<string, bool> filter, string filterCommand)
        {

            foreach (var name in names.Keys.Where(filter).ToList())
            {
                if (filterCommand == "Add filter")
                {
                    names[name] = 0;
                }
                else
                {
                    names[name] = 1;
                }
            }
        }
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ').ToArray();
            Dictionary<string, int> dictNames = new Dictionary<string, int>();
            foreach (var name in names)
            {
                if (!dictNames.ContainsKey(name))
                {
                    dictNames[name] = 0;
                }
                dictNames[name]++;
            }
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Print")
                {
                    break;
                }
                string[] tokens = line.Split(';').ToArray();
                string filterCommand = tokens[0];
                string filterType = tokens[1];
                string pattern = tokens[2];
                if (filterType == "StartsWith")
                {
                    ProcessFilter(dictNames, x => x.StartsWith(pattern), filterCommand);
                }
                else if (filterType == "EndsWith")
                {
                    ProcessFilter(dictNames, x => x.EndsWith(pattern), filterCommand);
                }
                else if (filterType == "Length")
                {
                    int len = int.Parse(pattern);
                    ProcessFilter(dictNames, x => x.Length == len, filterCommand);
                }
                else
                {
                    ProcessFilter(dictNames, x => x.Contains(pattern), filterCommand);
                }
            }
            Console.WriteLine(string.Join(" ", names.Where(x => dictNames[x] >0)));
        }
    }
}
