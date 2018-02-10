using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Monopoly
{
    class Program
    {
        static bool IsInRange(int row, int col, int currRow, int currCol)
        {
            return currRow >= 0 && currRow < row && currCol >= 0 && currCol < col;
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];
            char[,] matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int money = 50;
            int turns = 0;
            int incomePerTurn = 0;
            int hotels = 0;
            int jailTime = 0;
            //Queue<int> path = new Queue<int>(row * col);
            for (int i = 0; i < row; i++)
            {
                bool goesToTheRight = i % 2 == 0;
                for (int j = 0, k = col - 1; j < col || jailTime > 0; j++, --k)
                {


                    if (jailTime > 0)
                    {
                        --j;
                        ++k;
                        --jailTime;
                        ++turns;
                        money += 10 * hotels;
                        continue;
                    }

                    int idx = goesToTheRight ? j : k;
                    char currCell = matrix[i, idx];
                    if (currCell == 'H')
                    {
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++hotels}.");
                        money = 0;
                    }
                    else if (currCell == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        jailTime = 2;
                    }
                    else if (currCell == 'S')
                    {
                        int moneyToSpent = (idx + 1) * (i + 1);
                        if (money < moneyToSpent)
                        {
                            moneyToSpent = money;
                        }
                        Console.WriteLine($"Spent {moneyToSpent} money at the shop.");
                        money -= moneyToSpent;
                    }
                    ++turns;
                    money += 10 * hotels;
                }
            }
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
            int t = 0;
        }
    }
}
