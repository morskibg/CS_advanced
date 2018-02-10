using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Champions_League
{
    class Program
    {
        static void ProceedOponentRecods(string teamOne, string teamTwo, Dictionary<string, HashSet<string>> oponentsRec)
        {

            if (!oponentsRec.ContainsKey(teamOne))
            {
                oponentsRec[teamOne] = new HashSet<string>();
            }
            oponentsRec[teamOne].Add(teamTwo);
        }
        static void ProceedWinsRecods(string teamOne, string teamTwo, Dictionary<string, int> winsRec, int[] firstMatchGoals, int[] secondMatchGoals)
        {
            string winner = teamOne;
            int homeGoalsIdx = 0;
            int awayGoalsIdx = 1;
            if (firstMatchGoals[homeGoalsIdx] + secondMatchGoals[awayGoalsIdx] ==
                secondMatchGoals[homeGoalsIdx] + firstMatchGoals[awayGoalsIdx])
            {
                if (firstMatchGoals[awayGoalsIdx] > secondMatchGoals[awayGoalsIdx])
                {
                    winner = teamTwo;
                }
            }
            else if (firstMatchGoals[homeGoalsIdx] + secondMatchGoals[awayGoalsIdx] <
                     secondMatchGoals[homeGoalsIdx] + firstMatchGoals[awayGoalsIdx])
            {
                winner = teamTwo;
            }

                string looser = winner == teamOne ? teamTwo : teamOne;
            if (!winsRec.ContainsKey(winner))
            {
                winsRec[winner] = 0;
            }
            winsRec[winner]++;
            if (!winsRec.ContainsKey(looser))
            {
                winsRec[looser] = 0;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> winsRecords = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> oponentsRecords = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                string[] tokens = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToArray();
                string teamOne = tokens[0];
                string teamTwo = tokens[1];
                int[] firstMatchGoals = tokens[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int[] secondMatchGoals = tokens[3].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                ProceedOponentRecods(teamOne, teamTwo, oponentsRecords);
                ProceedOponentRecods(teamTwo, teamOne, oponentsRecords);
                ProceedWinsRecods(teamOne, teamTwo, winsRecords, firstMatchGoals, secondMatchGoals);

            }
            foreach (var team in winsRecords.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ", oponentsRecords[team.Key].OrderBy(x => x))}");
            }
        }
    }
}
