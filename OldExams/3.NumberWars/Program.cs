using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Number_Wars
{
    class Program
    {
        static int IntFromChar(string s)
        {

            int sum = 0;
            if (char.IsLower(s[s.Length - 1]))
            {
                sum += (int)s[s.Length - 1] - 96;
            }
            else
            {
                sum += (int)s[s.Length - 1] - 40;
            }
            return sum;
        }
        static int IntFromString(string s)
        {
            int sum = int.Parse(s.Substring(0, s.Length - 1));
            //sum += IntFromChar(s);

            return sum;
        }
        static void Main(string[] args)
        {
            Queue<string> p1Cards = new Queue<string>(Console.ReadLine().Split().ToArray());
            Queue<string> p2Cards = new Queue<string>(Console.ReadLine().Split().ToArray());
            int turnsCount = 0;
            while (true)
            {

                if (p1Cards.Count == 0 || p2Cards.Count == 0 || turnsCount >= 1000000)
                {
                    break;
                }
                ++turnsCount;
                string s1 = p1Cards.Dequeue();
                string s2 = p2Cards.Dequeue();
                int p1Num = int.Parse(s1.Substring(0, s1.Length - 1));
                int p2Num = int.Parse(s2.Substring(0, s2.Length - 1));
                if (p1Num == p2Num)
                {
                    List<string> winnedCards = new List<string>() {s1, s2};

                    if (!Fight(p1Cards, p2Cards, winnedCards))
                    {
                        break;
                    }
                }

                else
                {
                    if (p1Num > p2Num)
                    {
                        p1Cards.Enqueue(s1);
                        p1Cards.Enqueue(s2);

                        
                    }
                    else
                    {
                        p2Cards.Enqueue(s2);
                        p2Cards.Enqueue(s1);
                        

                    }
                }
                

            }

            if (p1Cards.Count == p2Cards.Count)
            {
                Console.WriteLine($"Draw after {turnsCount} turns");
            }
            else
            {
                if (p1Cards.Count > p2Cards.Count)
                {
                    Console.WriteLine($"First player wins after {turnsCount} turns");
                }
                else
                {
                    Console.WriteLine($"Second player wins after {turnsCount} turns");
                }
            }

        }

        static bool AbilityToFight(Queue<string> p1Cards, Queue<string> p2Cards)
        {
            if (p1Cards.Count >= 3 && p2Cards.Count >= 3)
            {
                return true;
            }
            return false;
        }
        private static bool Fight(Queue<string> p1Cards, Queue<string> p2Cards, List<string> winnedCards)
        {
            if (AbilityToFight(p1Cards, p2Cards))
            {
                int counter = 3;
                int p1Power = 0;
                int p2Power = 0;
                while (counter > 0 && p1Cards.Count > 0 && p2Cards.Count > 0)
                {
                    --counter;
                    string s1 = p1Cards.Dequeue();
                    string s2 = p2Cards.Dequeue();
                    winnedCards.Add(s1);
                    winnedCards.Add(s2);
                    p1Power += IntFromChar(s1);
                    p2Power += IntFromChar(s2);
                }
                if (p1Power == p2Power)
                {
                    Fight(p1Cards, p2Cards, winnedCards);
                }
                else if (p1Power > p2Power)
                {

                    foreach (var card in winnedCards.OrderByDescending(IntFromString).ThenByDescending(IntFromString))
                    {
                        p1Cards.Enqueue(card);
                    }
                }
                else
                {
                    foreach (var card in winnedCards.OrderByDescending(IntFromString).ThenByDescending(IntFromString))
                    {
                        p2Cards.Enqueue(card);
                    }
                }
                return true;
            }
            return false;
        }

    }
}
