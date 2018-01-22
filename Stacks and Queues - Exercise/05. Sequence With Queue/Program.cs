using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static bool Add(long[] arr, int idx, long num)
        {
            if (idx < 50)
            {
                arr[idx] = num;
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(num);
            long[] arr = new long[50];
            int counter = 0;
            arr[counter++] = num;
            while(true)
            {
                long currNum = queue.Dequeue();
                long a = currNum + 1;
                if (!Add(arr, counter++, a))
                {
                    break;
                }
                queue.Enqueue(a);
                long b = 2 * currNum + 1;
                if (!Add(arr, counter++, b))
                {
                    break;
                }
                queue.Enqueue(b);
                long c = currNum + 2;
                if (!Add(arr, counter++, c))
                {
                    break;
                }
                queue.Enqueue(c);
                

            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
