using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, long> gold = new Dictionary<string, long>();
            
            Dictionary<string, long> cash = new Dictionary<string, long>();
            
            Dictionary<string, long> gem = new Dictionary<string, long>();
            
            long bagCapacity = long.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string pattern = @"(?<name>[A-Za-z]+)\s(?<qty>[0-9]+)";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match currItem in matches)
            {
                string name = currItem.Groups["name"].Value;
                long amount = long.Parse(currItem.Groups["qty"].Value);
                long currGoldAmount = gold.Values.Sum();
                long currGemAmount = gem.Values.Sum();
                long currCashAmount = cash.Values.Sum();
                if (currGoldAmount + currGemAmount + currCashAmount + amount > bagCapacity)
                {
                    continue;
                }
                if (name.ToLower() == "gold")
                {
                    if (!gold.ContainsKey(name))
                    {
                        gold[name] = 0;
                    }
                    gold[name] += amount;
                    currGoldAmount += amount;
                }
                else if (name.Length > 3 && name.Substring(name.Length - 3).ToLower() == "gem")
                {

                    if (currGemAmount + amount <= currGoldAmount)
                    {
                        if (!gem.ContainsKey(name))
                        {
                            gem[name] = 0;
                        }
                        gem[name] += amount;
                    }
                    currGemAmount += amount;
                }
                else if (name.Length == 3 && char.IsLetter(name[0]) && char.IsLetter(name[1]) && char.IsLetter(name[2]))
                {
                    if (currCashAmount + amount <= currGemAmount)
                    {
                        if (!cash.ContainsKey(name))
                        {
                            cash[name] = 0;
                        }
                        cash[name] += amount;
                        currCashAmount += amount;
                    }
                }

            }
            List<Dictionary<string, long>> bag = new List<Dictionary<string, long>>();
            if (gold.Count > 0)
                bag.Add(gold);
            if (gem.Count > 0)
                bag.Add(gem);
            if (cash.Count > 0)
                bag.Add(cash);
            foreach (var item in bag.OrderByDescending(x => x.Values.Sum()))
            {
                string groupName = "";
                if (item.Count > 0)
                {


                    if (item.Keys.First().ToLower() == "gold")
                    {
                        groupName = "Gold";
                    }
                    else if (item.Keys.First().Length == 3)
                    {
                        groupName = "Cash";
                    }
                    else
                    {
                        groupName = "Gem";
                    }
                }
                Console.WriteLine($"<{groupName}> ${item.Values.Sum()}");
                foreach (var comodity in item.OrderByDescending(kvp => kvp.Key).ThenBy(kvp => kvp.Value))
                {
                    Console.WriteLine($"##{comodity.Key} - {comodity.Value}");
                }
            }
        }
    }
}
