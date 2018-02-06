using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OldExams
{
    class Program
    {
        static char[,] matrix = new char[8,8];
        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                char[] chars = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] tokens = input.Split('-').ToArray();
                char figure = tokens[0][0];
                
                int fRow = int.Parse(tokens[0].Substring(1, 1));
                int fCol = int.Parse(tokens[0].Substring(2, 1));
                int destRow = int.Parse(tokens[1].Substring(0, 1));
                int destCol = int.Parse(tokens[1].Substring(1, 1));
                if (!HasFigureAtThisPlace(fRow, fCol, figure))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                else if (!IsInMatrix(destRow, destCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                switch (figure)
                {
                    case 'p':
                    case 'P':
                        if (!PawnMove(fRow, fCol, destRow, destCol))
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        break;
                    case 'B':
                        if (!BishopMove(fRow, fCol, destRow, destCol))
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        break;
                    case 'R':
                        if (!RookMove(fRow, fCol, destRow, destCol))
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        break;
                    case 'K':
                        if (!KingMove(fRow, fCol, destRow, destCol))
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }
                        break;
                    case 'Q':
                        if (!QueenMove(fRow, fCol, destRow, destCol))
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }
                        break;
                        default:
                            break;
                }

                
            }
            
        }

        static bool HasFigureAtThisPlace(int row, int col, char figure)
        {
            
            char currFigure = char.ToUpper(matrix[row, col]);
            return currFigure == figure;
        }

        

        static bool PawnMove(int row, int col, int destRow, int destCol)
        {
            char figure = matrix[row, col];
            if (figure == 'P' && Math.Abs(row - destRow) == 1 && col - destCol == 0)
            {
                matrix[row, col] = 'x';
                if (row > destRow)
                {
                    
                    matrix[destRow, destCol] = 'p';
                }
                else
                {
                    matrix[destRow, destCol] = 'P';
                }
                return true;
            }
            else if (figure == 'p' && row - destRow == 1 && col - destCol == 0)
            {
                matrix[destRow, destCol] = 'p';
                return true;
            }
            return false;
        }

        static bool BishopMove(int row, int col, int destRow, int destCol)
        {
            
            int deltaRow = Math.Abs(row - destRow);
            int deltaCol = Math.Abs(col - destCol);
            if (deltaCol != deltaRow)
            {
                return false;
            }
            matrix[row,col] = 'x';
            matrix[destRow, destCol] = 'B';

            return true;
        }

        static bool RookMove(int row, int col, int destRow, int destCol)
        {
            if (row == destRow || col == destCol)
            {
                matrix[row, col] = 'x';
                matrix[destRow, destCol] = 'R';
                return true;
            }
            return false;
        }

        static bool KingMove(int row, int col, int destRow, int destCol)
        {
            if (Math.Abs(row - destRow) <= 1 && Math.Abs(col - destCol) <= 1)
            {
                matrix[row, col] = 'x';
                matrix[destRow, destCol] = 'K';
                return true;
            }
            return false;
        }

        static bool QueenMove(int row, int col, int destRow, int destCol)
        {
            int deltaRow = Math.Abs(row - destRow);
            int deltaCol = Math.Abs(col - destCol);
            if (deltaRow == deltaCol || (row == destRow || col == destCol))
            {
                matrix[row, col] = 'x';
                matrix[destRow, destCol] = 'Q';
                return true;
            }
            return false;
        }
        static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
    }
}
