using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void ApplayFilters(HashSet<Func<string, bool>> filters, List<string> names)
        {
            foreach (var filter in filters)
            {
                int t = 0;
                foreach (var name in names)
                {
                    if (filter(name))
                    {
                        
                    }
                }
            }
        }
       // static void ForEachName()
        static void Main(string[] args)
        {
            HashSet<Func<string,  bool>> filters = new HashSet<Func<string,  bool>>();
            List<string> names = Console.ReadLine().Split(' ').ToList();
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

                switch (filterType)
                {
                    case "Starts with":
                        if (filterCommand == "Add filter")
                        {
                            filters.Add(x => x.StartsWith(pattern));
                        }
                        else
                        {
                            filters.Remove(x => x.StartsWith(pattern));
                        }
                        break;
                    case "Ends with":
                        if (filterCommand == "Add filter")
                        {
                            filters.Add(x => x.EndsWith(pattern));
                        }
                        else
                        {
                            filters.Remove(x => x.EndsWith(pattern));
                        }
                        break;
                    case "Length":
                        if (filterCommand == "Add filter")
                        {
                            filters.Add(x => x.Length == int.Parse(pattern));
                        }
                        else
                        {
                            filters.Remove(x => x.Length == int.Parse(pattern));
                        }
                        break;
                    case "Contains":
                        if (filterCommand == "Add filter")
                        {
                            filters.Add(x => x.Contains(pattern));
                        }
                        else
                        {
                            filters.Remove(x => x.Contains(pattern));
                        }
                        break;
                }
                
                ApplayFilters(filters, names);
            }
            int t = 0;
        }
    }
}
