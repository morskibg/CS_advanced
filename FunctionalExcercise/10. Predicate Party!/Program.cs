using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Predicate_Party_
{
   
    class Program
    {
        static void ModFunc(ref List<string> data, Func<string ,bool> foo, string command)
        {
            List<string> temp = new List<string>();
            foreach (var name in data)
            {
                temp.Add(name);
                if (foo(name))
                {
                    if (command == "Double")
                    {
                        temp.Add(name);
                    }
                    else
                    {
                        temp.RemoveAll(x => x == name);
                    }
                }
            }
            data = temp;
        }
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Party!")
                {
                    break;
                }
                string[] tokens = line.Split(' ').ToArray();
                string command = tokens[0];
                string condition = tokens[1];
                string pattern = tokens[2];
                if (condition == "StartsWith")
                {
                    ModFunc(ref names, x => x.StartsWith(pattern), command);
                }
                else if (condition == "EndsWith")
                {
                    ModFunc(ref names, x => x.EndsWith(pattern), command);
                }
                else
                {
                    int len = int.Parse(pattern);
                    ModFunc(ref names, x => x.Length == len, command);
                }
            }
            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
           
        }
    }
}
