using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<beforeDigits>\d+)(?<text>[A-Za-z]+)(?<afterDigits>[^A-Za-z]*)$";
            Regex rx = new Regex(pattern);
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "Over!")
                {
                    break;
                }
                int testSum = int.Parse(Console.ReadLine());
                Match match = rx.Match(message);
              
                if (!match.Success || match.Groups["text"].Value.Length != testSum)
                {
                    
                    continue;
                }
                string extractedMsg = match.Groups["text"].Value;
                int beforNumCount = match.Groups["beforeDigits"].Value.Length;
                int afterNumCount = match.Groups["afterDigits"].Value.Length;
               
                List<int> indices = new List<int>(beforNumCount + afterNumCount);
                MatchCollection matchedBeforeDigits = Regex.Matches(match.Groups["beforeDigits"].Value, "\\d");
                MatchCollection matchedAfterDigits = Regex.Matches(match.Groups["afterDigits"].Value, "\\d");

                foreach (Match digit in matchedBeforeDigits)
                {
                    indices.Add(int.Parse(digit.ToString()));
                }
                foreach (Match digit in matchedAfterDigits)
                {
                    bool isDigit = int.TryParse(digit.ToString(), out int digitP);
                    if (isDigit)
                    {
                        indices.Add(digitP);
                    }

                }
                char[] verificationCode = new char[indices.Count];
                for (int i = 0; i < indices.Count; i++)
                {
                    verificationCode[i] = ' ';
                    if (indices[i] >= 0 && indices[i] < extractedMsg.Length)
                    {
                        verificationCode[i] = extractedMsg[indices[i]];
                    }
                }
                Console.WriteLine($"{extractedMsg} == {string.Join("", verificationCode)}");

            }
            }
    }
}
