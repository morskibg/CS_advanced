using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _10.The_Heigan_Dance
{
    class Program
    {
        static char[,] matrix = new char[15, 15];

        static int pRow = 7;
        static int pCol = 7;
        static bool isPlayerHitByCloud = false;
        static bool isPlayerHitByEruption = false;
        static bool isPlayerDeadByPleague = false;
        static bool isPlayerDeadByEruption = false;
        static bool hasPlagueYesterday = false;
        private const double plagueDamage = 3500.0;
        private const double eruptionDamage = 6000.0;
        static double playerHealth = 18500.0;
        static double heiganHealth = 3000000.0;
        static Queue<Point> Plague = new Queue<Point>();
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
        static void InitializeMatrix(int pRow, int pCol)
        {
           
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrix[i, j] = '.';
                }
            }
            matrix[pRow, pCol] = 'p';
            isPlayerHitByCloud = Plague.Count > 0;
            if (Plague.Count > 0)
            {
                Plague.Dequeue();
            }
            
            isPlayerHitByEruption = false;
            hasPlagueYesterday = false;
            //while (Plague.Count > 0)
            //{
            //    bool[,] visited = new bool[15, 15];
            //    Point currPlague = Plague.Dequeue();
            //    PlaceSpell(currPlague.Row, currPlague.Col, currPlague.Row, currPlague.Col, visited, ref isPlayerHitByCloud, 'c');
            //}
        }
        static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < 15 && col >= 0 && col < 15;
        }
        static void PlaceSpell(int row, int col, int impactRow, int impactCol, bool[,] visited, ref bool isPlayerHere, char spell)
        {
            if (!IsInBounds(impactRow, impactCol))
            {
                return;
            }
            if (matrix[row, col] == 'p')
            {
                isPlayerHere = true;
            }
            else
            {
                matrix[row, col] = spell;
            }

            visited[row, col] = true;

            if (IsInBounds(row, col + 1) && col + 1 <= impactCol + 1 && visited[row, col + 1] == false)
            {
                PlaceSpell(row, col + 1, impactRow, impactCol, visited, ref isPlayerHere, spell);
            }
            if (IsInBounds(row, col - 1) && col - 1 >= impactCol - 1 && visited[row, col - 1] == false)
            {
                PlaceSpell(row, col - 1, impactRow, impactCol, visited, ref isPlayerHere, spell);
            }
            if (IsInBounds(row + 1, col) && row + 1 <= impactRow + 1 && visited[row + 1, col] == false)
            {
                PlaceSpell(row + 1, col, impactRow, impactCol, visited, ref isPlayerHere, spell);
            }
            if (IsInBounds(row - 1, col) && row - 1 >= impactRow - 1 && visited[row - 1, col] == false)
            {
                PlaceSpell(row - 1, col, impactRow, impactCol, visited, ref isPlayerHere, spell);
            }
        }

        static void Print()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

       

        static void PlayerResponse()
        {
            if (isPlayerHitByCloud || isPlayerHitByEruption || hasPlagueYesterday)
            {




                if (IsInBounds(pRow - 1, pCol) && matrix[pRow - 1, pCol] == '.')
                {
                    matrix[pRow, pCol] = '.';
                    --pRow;
                    matrix[pRow, pCol] = 'p';
                }
                else if (IsInBounds(pRow, pCol + 1) && matrix[pRow, pCol + 1] == '.')
                {
                    matrix[pRow, pCol] = '.';
                    ++pCol;
                    matrix[pRow, pCol] = 'p';
                }
                else if (IsInBounds(pRow + 1, pCol) && matrix[pRow + 1, pCol] == '.')
                {
                    matrix[pRow, pCol] = '.';
                    ++pRow;
                    matrix[pRow, pCol] = 'p';
                }
                else if (IsInBounds(pRow, pCol - 1) && matrix[pRow, pCol - 1] == '.')
                {
                    matrix[pRow, pCol] = '.';
                    --pCol;
                    matrix[pRow, pCol] = 'p';
                }
                else
                {
                    if (isPlayerHitByCloud)
                    {
                        if (hasPlagueYesterday)
                        {
                            playerHealth -= plagueDamage;
                        }
                        playerHealth -= plagueDamage;

                    }
                    if (playerHealth <= 0)
                    {
                        isPlayerDeadByPleague = true;

                    }
                    else
                    {
                        if (isPlayerHitByEruption)
                        {
                            playerHealth -= eruptionDamage;
                            if (playerHealth <= 0)
                            {
                                isPlayerDeadByEruption = true;
                            }
                        }
                    }


                }
            }
           
        }

        static void Main(string[] args)
        {
            InitializeMatrix(pRow, pCol);
            double damageToHeigan = double.Parse(Console.ReadLine());
            bool isHeiganDeath = false;
            while (true)
            {
                heiganHealth -= damageToHeigan;
                if (heiganHealth <= 0)
                {
                    isHeiganDeath = true;
                    //PlayerResponse();
                    break;
                }
                string[] query = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int currRow = int.Parse(query[1]);
                int currCol = int.Parse(query[2]);
                bool[,] visited = new bool[15, 15];
                if (query[0] == "Cloud")
                {
                    if (isPlayerHitByCloud)
                    {
                        hasPlagueYesterday = true;
                    }
                    
                    PlaceSpell(currRow, currCol, currRow, currCol, visited, ref isPlayerHitByCloud, 'c');
                    Plague.Enqueue(new Point(currRow, currCol));
                   

                }
                else
                {
                    
                    PlaceSpell(currRow, currCol, currRow, currCol, visited, ref isPlayerHitByEruption, 'e');
                    
                }
                PlayerResponse();
                InitializeMatrix(pRow, pCol);
                if (isPlayerDeadByEruption || isPlayerDeadByPleague)
                {
                    break;
                }
            }
           
            if (isHeiganDeath)
            {
                Console.WriteLine($"Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {pRow}, {pCol}");
            }
            if (isPlayerDeadByPleague || isPlayerDeadByEruption)
            {
                Console.WriteLine($"Heigan: {heiganHealth.ToString("0.00")}");
                Console.WriteLine($"Player: Killed by {(isPlayerDeadByEruption ? "Eruption" : "Plague Cloud")}");
                Console.WriteLine($"Final position: {pRow}, {pCol}");
            }
        }
    }
}
