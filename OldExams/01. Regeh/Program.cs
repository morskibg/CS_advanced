using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string pattern =
                @"(?<left>(\[[A-Za-z]+){1})(<(?<lNum>\d+)REGEH(?<rNum>\d+)>){1}(?<right>(([A-Za-z]+)]){1})";
            string input = Console.ReadLine();
            
            List<int> indices = new List<int>();
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
            {
                indices.Add(int.Parse(m.Groups["lNum"].Value));
                indices.Add(int.Parse(m.Groups["rNum"].Value));
            }
            for (int i = 0; i < indices.Count; i++)
            {
                int currIdx = 0;
                for (int j = 0; j <= i; j++)
                {
                    currIdx += indices[j];
                }
                currIdx %= input.Length;
               
                Console.Write(input[currIdx]);
                
            }
            int t = 0; 
        }
    }
}
