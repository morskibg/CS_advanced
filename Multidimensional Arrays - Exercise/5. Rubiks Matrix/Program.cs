using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rubiks_Matrix
{
    class Program
    {
        static void Rotate(int[] arr, string direction, int rotations)
        {
            int arrSize = arr.Length;
            if (direction == "down" || direction == "right")
            {
                for (int i = 0; i < rotations; i++)
                {
                    int acc = arr[arrSize - 1];
                    for (int k = arrSize - 2; k >= 0; k--)
                    {
                        arr[k + 1] = arr[k];
                    }
                    arr[0] = acc;
                }
            }
            else if (direction == "up" || direction == "left")
            {
                for (int i = 0; i < rotations; i++)
                {
                    int acc = arr[0];
                    for (int k = 0; k < arrSize - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                    arr[arrSize - 1] = acc;
                }
            }
            int t = 0;
        }
        static void MoveColums(int[,] matrix, int rows, int targetCol, int moveCounter, string direction)
        {
            int[] auxArr = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                auxArr[i] = matrix[i, targetCol];
            }
            Rotate(auxArr, direction, moveCounter);
            for (int i = 0; i < rows; i++)
            {
                matrix[i, targetCol] = auxArr[i];
            }
        }

        static void MoveRows(int[,] matrix, int cols, int targetRow, int moveCounter, string direction)
        {
            int[] auxArr = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                auxArr[i] = matrix[targetRow, i];
            }
            Rotate(auxArr, direction, moveCounter);
            for (int i = 0; i < cols; i++)
            {
                matrix[targetRow, i] = auxArr[i];
            }
        }

        static void FindItem(int[,] matrix, int rows, int cols, int item, ref int row, ref int col)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == item)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }
        }

        static void CheckAndPrint(int[,] baseMatrix, int[,] matrix, int currRow, int currCol, int rows, int cols)
        {
            if (baseMatrix[currRow, currCol] == matrix[currRow, currCol])
            {
                Console.WriteLine("No swap required");
            }
            else
            {
                int itemToSearch = baseMatrix[currRow, currCol];
                int itemRow = -1;
                int itemCol = -1;
                FindItem(matrix, rows, cols, itemToSearch, ref itemRow, ref itemCol);
                int temp = matrix[currRow, currCol];
                matrix[currRow, currCol] = itemToSearch;
                matrix[itemRow, itemCol] = temp;
                Console.WriteLine($"Swap ({currRow}, {currCol}) with ({itemRow}, {itemCol})");
            }
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            int[,] baseMatrix = new int[rows, cols];
            int n = int.Parse(Console.ReadLine());
            int filler = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = filler;
                    baseMatrix[i, j] = filler++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                int target = int.Parse(commands[0]);
                string direction = commands[1];
                int movementCounter = int.Parse(commands[2]);
                if (direction == "up" || direction == "down")
                {
                    MoveColums(matrix, rows, target, movementCounter, direction);
                }
                else
                {
                    MoveRows(matrix, cols, target, movementCounter, direction);
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    CheckAndPrint(baseMatrix, matrix, i, j, rows, cols);
                }
            }

            int t = 0;
        }
    }
}
