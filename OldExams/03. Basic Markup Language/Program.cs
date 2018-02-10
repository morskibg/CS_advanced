using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Basic_Markup_Language
{
    class Programa
    {
        static void Main(string[] args)
        {
            //"\s*<\s*([a-z]+)\s+(?:value\s*=\s*\"\s*(\d+)\s*\"\s+)?[a-z]+\s*=\s*\"([^""]*)\"\s*\/>\s*"
            string pattern =
                @"(?:<)(?<command1>\s*[a-zA-Z]+\s+[a-zA-Z]+\s*)\s*=\s*\""(?<quot1>[^""]*)\""\s*(?<command2>[a-zA-Z]+)?\s*=?\s*\""?(?<quot2>[^""]*)?\""?\s*(?:\/>$)";
            Regex rx = new Regex(pattern);
            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "<stop/>")
                {
                    break;
                }

                //MatchCollection matches = Regex.Matches(input, pattern);
                //var list = matches.Cast<Match>().Select(x => x.Value).ToList();
                //Console.WriteLine("******************************8");
                //Console.WriteLine(string.Join(", ",list));
                Match match = rx.Match(input);
                string firstComamnd = match.Groups["command1"].Value;

                if (firstComamnd.Contains("repeat"))
                {
                    int repeatValue = 0;
                    bool isDigit = int.TryParse(match.Groups["quot1"].Value, out repeatValue);
                    if (!isDigit)
                    {
                        continue;
                    }
                    string toRepeat = match.Groups["quot2"].Value;
                    counter = repeatValue == 0 ? counter : ++counter;
                    for (int i = 0; i < repeatValue; i++)
                    {
                        Console.WriteLine($"{counter}. {toRepeat}");
                        counter = i == repeatValue - 1 ? counter : ++counter;
                    }
                    //Console.WriteLine($"Value to repeat {repeatValue}");
                }
                else if (firstComamnd.Contains("reverse"))
                {
                    
                    
                    string toReverse = match.Groups["quot1"].Value;
                    if (toReverse.Length == 0)
                    {
                        continue;
                    }
                    ++counter;
                    Console.WriteLine($"{counter}. {string.Join("", toReverse.Reverse())}");
                    //Console.WriteLine($"Cotent to reverse {toReverse}");
                }
                else if (firstComamnd.Contains("inverse"))
                {
                    
                    string toInverse = match.Groups["quot1"].Value;
                    if (toInverse.Length == 0)
                    {
                        continue;
                    }
                    ++counter;
                    Console.WriteLine($"{counter}. {string.Join("", toInverse.Select(x => char.IsLower(x) ? char.ToUpper(x) : char.ToLower(x)))}");
                    //Console.WriteLine($"Cotent to inverse {toInverse}");
                }

            }
        }
    }
}
