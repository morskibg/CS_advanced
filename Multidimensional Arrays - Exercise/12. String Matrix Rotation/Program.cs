using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Rotate90(char[,] oldMatrix, char[,] newMatrix, int oldRows, int oldCols)
        {
            int newRows = oldCols;
            int newCols = oldRows;


        }
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> input = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                input.Add(line);
            }
            int rows = input.Count;
            int cols = input.OrderByDescending(x => x.Length).First().Length;
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] row = input[i].ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    if (j < row.Length)
                    {
                        matrix[i, j] = row[j];
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
            if (command == "Rotate(90)")
            {
                
            }
            int t = 0;
        }
    }
}
