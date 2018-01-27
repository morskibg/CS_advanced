using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Crossfire
{
    class Program
    {
        static void FillMatrix(int[][] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] tempArr = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    tempArr[j] = j + 1 + i * cols;
                }
                matrix[i] = tempArr;
            }
        }

        
        static void DestroyCells(int[][] matrix, ref int rows, int cols, int[] query)
        {
            int impactRow = query[0];
            int impactCol = query[1];
            int imapctRadius = query[2];
            
            for (int k = 0; k < rows; ++k)
            {
                List<int> tempList = new List<int>();
                for (int i = 0; i < matrix[k].Length; i++)
                {
                    if (k == impactRow)
                    {
                        if (i < impactCol - imapctRadius || i > impactCol + imapctRadius)
                        {
                            tempList.Add(matrix[k][i]);
                        }
                    }
                    else
                    {
                        if (i != impactCol)
                        {
                            tempList.Add(matrix[k][i]);
                        }
                        else
                        {
                            if (k > impactRow + imapctRadius || k < impactRow - imapctRadius)
                            {
                                tempList.Add(matrix[k][i]);
                            }
                        }
                    }
                }
                if (tempList.Count > 0)
                {
                    matrix[k] = tempList.ToArray();
                }
                else
                {
                    matrix[k] = null;
                    --rows;
                }
            }
            
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                if (row != null)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            }
        }

        static int[][] CompresMatrix(int[][] oldMatrix, int rows)
        {
            int[][] matrix = new int[rows][];
            int idx = 0;
            foreach (int[] row in oldMatrix)
            {
                if (row != null)
                {
                    matrix[idx++] = row;
                }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            FillMatrix(matrix, rows, cols);
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Nuke it from orbit")
                {
                    break;
                }
                int[] query = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int oldRows = rows;
                DestroyCells(matrix, ref rows, cols, query);
                if (oldRows != rows)
                {
                    matrix = CompresMatrix(matrix, rows);
                }
            }
            PrintMatrix(matrix);
        }
    }
}
