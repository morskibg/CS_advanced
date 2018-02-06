using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"![^#]*?\b(?<street>[A-Za-z]{4})\b[^#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d#][^#]*)?#|#[^!]*?\b(?<street>[A-Za-z]{4})\b[^!]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!][^!]*)?!";
            //string pattern = @"\![^#]*?\b(?<street>[A-Za-z]{4})\b[^#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d#][^#]*)?\#|\#[^!]*?\b(?<street>[A-Za-z]{4})\b[^!]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!][^!]*)?\!";
            ////string pattern = @"![^#]*?\b(?<street>[A-Za-z]{4})\b[^#]*(?<number>\d{3})-(?<password>\d{6}|\d{4})#|#[^!]*?\b(?<street>[A-Za-z]{4})\b[^!]*(?<number>\d{3})-(?<password>\d{6}|\d{4})!";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                Match toProceed = null;
                if (matches.Count != 0)
                {
                    toProceed = matches[matches.Count / 2];
                    
                    Console.WriteLine($"Go to str. {toProceed.Groups["street"].Value} {toProceed.Groups["number"].Value}. Secret pass: {toProceed.Groups["password"].Value}.");
                }
            }
        }
    }
}
