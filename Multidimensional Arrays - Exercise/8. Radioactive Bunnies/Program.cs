using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Radioactive_Bunnies
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
        static void ReadInput(char[,] matrix, int rows, int cols, ref int pRow, ref int pCol)
        {
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                char[] symbols = line.ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = symbols[j];
                    if (symbols[j] == 'P')
                    {
                        pCol = j;
                        pRow = i;
                    }
                }

            }
        }

        static bool IsInBounds(int rows, int cols, int currRow, int currCol)
        {
            return currRow >= 0 && currRow < rows && currCol >= 0 && currCol < cols;
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int pRow = -1;
            int pCol = -1;
            char[,] matrix = new char[rows, cols];
            ReadInput(matrix, rows, cols, ref pRow, ref pCol);
            string commandsLine = Console.ReadLine();
            char[] commands = commandsLine.ToCharArray();
            bool isWinning = false;
            bool isReachBunny = false;
            foreach (var currCommand in commands)
            {
                int newRow = pRow;
                int newCal = pCol;
                if (currCommand == 'U')
                {
                    if (!IsInBounds(rows, cols, pRow - 1, pCol))
                    {
                        isWinning = true;
                    }
                    else
                    {
                        newRow = pRow - 1;
                        newCal = pCol;
                    }

                }
                else if (currCommand == 'R')
                {
                    if (!IsInBounds(rows, cols, pRow, pCol + 1))
                    {
                        isWinning = true;

                    }
                    else
                    {
                        newRow = pRow;
                        newCal = pCol + 1;
                    }
                }
                else if (currCommand == 'D')
                {
                    if (!IsInBounds(rows, cols, pRow + 1, pCol))
                    {
                        isWinning = true;
                    }
                    else
                    {
                        newRow = pRow + 1;
                        newCal = pCol;
                    }
                    
                }
                else if (currCommand == 'L')
                {
                    if (!IsInBounds(rows, cols, pRow, pCol - 1))
                    {
                        isWinning = true;
                    }
                    else
                    {
                        newRow = pRow;
                        newCal = pCol - 1;
                    }
                }
                matrix[pRow, pCol] = '.';
                if (!isWinning)
                {
                    pRow = newRow;
                    pCol = newCal;
                    isReachBunny = matrix[newRow, newCal] == 'B';
                    if (!isReachBunny)
                    {
                        matrix[newRow, newCal] = 'P';
                    }
                }
                bool isReacedPlayer = PopulateVampireBunies(matrix, rows, cols);
                if (isWinning || isReachBunny || isReacedPlayer)
                {
                    break;
                }

            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            if (isWinning)
            {
                Console.WriteLine($"won: {pRow} {pCol}");
            }
            else
            {
                Console.WriteLine($"dead: {pRow} {pCol}");
            }


        }

        static bool PopulateVampireBunies(char[,] matrix, int rows, int cols)
        {
            Queue<Point> bunies = new Queue<Point>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunies.Enqueue(new Point(i, j));
                    }
                }
            }
            bool isReachPlayer = false;
            foreach (var bunny in bunies)
            {
                if (IsInBounds(rows, cols, bunny.Row, bunny.Col + 1))
                {
                    if (matrix[bunny.Row, bunny.Col + 1] == 'P')
                    {
                        matrix[bunny.Row, bunny.Col + 1] = 'B';
                        isReachPlayer = true;
                    }
                    matrix[bunny.Row, bunny.Col + 1] = 'B';
                }
                if (IsInBounds(rows, cols, bunny.Row, bunny.Col - 1))
                {
                    if (matrix[bunny.Row, bunny.Col - 1] == 'P')
                    {
                        matrix[bunny.Row, bunny.Col - 1] = 'B';
                        isReachPlayer = true;
                    }
                    matrix[bunny.Row, bunny.Col - 1] = 'B';
                }
                if (IsInBounds(rows, cols, bunny.Row + 1, bunny.Col))
                {
                    if (matrix[bunny.Row + 1, bunny.Col] == 'P')
                    {
                        matrix[bunny.Row + 1, bunny.Col] = 'B';
                        isReachPlayer = true;
                    }
                    matrix[bunny.Row + 1, bunny.Col] = 'B';
                }
                if (IsInBounds(rows, cols, bunny.Row - 1, bunny.Col))
                {
                    if (matrix[bunny.Row - 1, bunny.Col] == 'P')
                    {
                        matrix[bunny.Row - 1, bunny.Col] = 'B';
                        isReachPlayer = true;
                    }
                    matrix[bunny.Row - 1, bunny.Col] = 'B';
                }
            }
            return isReachPlayer;
        }
    }
}
