using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        struct Point
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public Point(int i, int j)
            {
                this.Row = i;
                this.Col = j;
            }

        }
        static bool IsInMatrix(int n, int newRow, int newCol)
        {
            return newRow >= 0 && newRow < n && newCol >= 0 && newCol < n;
        }

        static int HowManyCanAttack(int currRow, int currCol, char[,] matrix, int n)
        {
            int victims = 0;
            if (IsInMatrix(n, currRow - 2, currCol + 1) && matrix[currRow - 2, currCol + 1] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow - 1, currCol + 2) && matrix[currRow - 1, currCol + 2] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow + 1, currCol + 2) && matrix[currRow + 1, currCol + 2] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow + 2, currCol + 1) && matrix[currRow + 2, currCol + 1] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow + 2, currCol - 1) && matrix[currRow + 2, currCol - 1] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow + 1, currCol - 2) && matrix[currRow + 1, currCol - 2] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow - 1, currCol - 2) && matrix[currRow - 1, currCol - 2] == 'K')
            {
                ++victims;
            }
            if (IsInMatrix(n, currRow - 2, currCol - 1) && matrix[currRow - 2, currCol - 1] == 'K')
            {
                ++victims;
            }

            return victims;
        }

        static void Print(char[,] matrix, int n)
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            List<Point> knights = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (input[j] == 'K')
                    {
                        knights.Add(new Point(i, j));
                    }
                    matrix[i, j] = input[j];
                }
            }
            // Print(matrix, n);
            List<int> victims = new List<int>(knights.Count);
            for (int i = 0; i < knights.Count; i++)
            {
                Point currKnight = knights[i];
                victims.Add(HowManyCanAttack(currKnight.Row, currKnight.Col, matrix, n));
            }
            int initialKnights = knights.Count;
            while (victims.Sum() != 0)
            {

                int maxViolentKnight = victims.IndexOf(victims.Max());
                //Point maxVN = knights[maxViolentKnight];
                //Console.WriteLine($"max violent knite is at {maxVN.Row} row and {maxVN.Col}");
                matrix[knights[maxViolentKnight].Row, knights[maxViolentKnight].Col] = '*';
                knights.RemoveAt(maxViolentKnight);
                //Print(matrix, n);
                victims.Clear();
                for (int i = 0; i < knights.Count; i++)
                {
                    Point currKnight = knights[i];
                    victims.Add(HowManyCanAttack(currKnight.Row, currKnight.Col, matrix, n));
                }

            }
            //Print(matrix, n);

            Console.WriteLine(initialKnights - knights.Count);

            int t = 0;
        }
    }
}
