using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Lego_Blocks
{
    class Program
    {
        static void ReadArr(int[][] arr, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] tempArr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                arr[i] = tempArr;
            }
        }

        static bool IsComplementRows(int[][]arr1, int[][] arr2, int rows)
        {
            int summedRowLength = arr1[0].Length + arr2[0].Length;
            int rank = arr1.Rank;
            
            for (int i = 1; i < rows; i++)
            {
                if (summedRowLength != arr1[i].Length + arr2[i].Length)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintCombinedArr(int[][] arr1, int[][] arr2, int rows)
        {
            int[][] reversedArr = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                reversedArr[i] = arr2[i].Reverse().ToArray();
                Console.Write("[");
                Console.Write(string.Join(", ", arr1[i]));
                Console.Write(", ");
                Console.Write(string.Join(", ", reversedArr[i]));
                Console.Write("]");
                Console.WriteLine();
            }
            
        }

        static int CountArrElements(int[][] arr, int rows)
        {
            int cout = 0;
            foreach (int[] row in arr)
            {
                foreach (int element in row)
                {
                    cout++;
                }
            }
            return cout;
        }
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] arr1 = new int[rows][];
            int[][] arr2 = new int[rows][];
            ReadArr(arr1, rows);
            ReadArr(arr2, rows);
            if (IsComplementRows(arr1, arr2, rows))
            {
                PrintCombinedArr(arr1, arr2, rows);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {CountArrElements(arr1, rows) + CountArrElements(arr2, rows)}");
            }
            

        }
    }
}
