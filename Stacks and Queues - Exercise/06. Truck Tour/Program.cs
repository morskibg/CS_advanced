using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int pumps = int.Parse(Console.ReadLine());
            long[] petrolArr = new long[pumps];
            long[] distanceArr = new long[pumps];
            for (int i = 0; i < pumps; i++)
            {
                long[] args = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                petrolArr[i] = args[0];
                distanceArr[i] = args[1];
            }
            int counter = 0;
            Queue<long> petrol = new Queue<long>(petrolArr);
            Queue<long> distance = new Queue<long>(distanceArr);
            while (counter < pumps)
            {
                
                for (int i = 0; i < counter; i++)
                {
                    long a = petrol.Dequeue();
                    petrol.Enqueue(a);
                    a = distance.Dequeue();
                    distance.Enqueue(a);
                }
                long totalPetrol = 0;
                int click = 0;
                while (true)
                {
                    long currPetrol = petrol.Dequeue();
                    long currDistance = distance.Dequeue();
                    totalPetrol += currPetrol - currDistance;
                    petrol.Enqueue(currPetrol);
                    distance.Enqueue(currDistance);
                    if (totalPetrol < 0)
                    {
                        ++counter;
                        petrol.Clear();
                        distance.Clear();
                        for (int i = 0; i < pumps; i++)
                        {
                            petrol.Enqueue(petrolArr[i]);
                            distance.Enqueue(distanceArr[i]);
                        }
                        break;
                    }
                    ++click;
                    if (click == pumps)
                    {
                        Console.WriteLine(counter);
                        return;
                    }
                }
            }

        }
    }
}
