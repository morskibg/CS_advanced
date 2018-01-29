using System;
using System.Collections.Generic;

namespace Problem02
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            int r = int.Parse(dimensions[0]);
            int c = int.Parse(dimensions[1]);

            var parking = new List<HashSet<int>>();
            for (int i = 0; i < r; i++)
            {
                parking.Add(new HashSet<int>());
                parking[i].Add(0);
            }

            string line = Console.ReadLine();
            while (line != "stop")
            {
                string[] elements = line.Split(' ');
                int entryRow = int.Parse(elements[0]);
                int destRow = int.Parse(elements[1]);
                int destCol = int.Parse(elements[2]);
                int actualCol = FindPlace(parking, r, c, destRow, destCol);
                if (actualCol == -1)
                {
                    Console.WriteLine("Row {0} full", destRow);
                }
                else
                {
                    parking[destRow].Add(actualCol);
                    int path = Math.Abs(destRow - entryRow) + actualCol + 1;
                    Console.WriteLine(path);
                }

                line = Console.ReadLine();
            }
        }

        public static int FindPlace(List<HashSet<int>> parking, int r, int c, int destRow, int destCol)
        {
            if (!parking[destRow].Contains(destCol))
                return destCol;

            int delta = 1;
            while (true)
            {
                bool rowFullLeft = false;
                if (IsInsideParking(r, c, destRow, destCol - delta))
                {
                    if (!parking[destRow].Contains(destCol - delta))
                    {
                        return destCol - delta;
                    }
                }
                else
                {
                    rowFullLeft = true;
                }

                if (IsInsideParking(r, c, destRow, destCol + delta))
                {
                    if (!parking[destRow].Contains(destCol + delta))
                    {
                        return destCol + delta;
                    }
                }
                else
                {
                    if (rowFullLeft) break;
                }

                delta++;
            }
            return -1;
        }

        public static bool IsInsideParking(int r, int c, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < r && col < c)
                return true;
            return false;
        }
    }
}