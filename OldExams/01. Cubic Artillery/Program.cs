using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Cubic_Artillery
{
    class Program
    {
        static int AddWeapon(Queue<int> bunker, Queue<int> weapons, int remainingBunkerCapacity)
        {
            while (remainingBunkerCapacity > 0 && weapons.Count > 0)
            {
                if (weapons.Peek() <= remainingBunkerCapacity)
                {
                    int weaponToAdd = weapons.Dequeue();
                    bunker.Enqueue(weaponToAdd);
                    remainingBunkerCapacity -= weaponToAdd;
                }
                else
                {
                    return remainingBunkerCapacity;
                }
            }
            return remainingBunkerCapacity;
        }
        static int RearangeLastBunker(Queue<int> bunker, int weapon, int remainingCapacity)
        {
            

            while (true)
            {
                int removedWeapon = bunker.Dequeue();               
                remainingCapacity += removedWeapon;
                if (remainingCapacity >= weapon)
                {
                    bunker.Enqueue(weapon);
                    break;
                }
            }
            return remainingCapacity;
        }
        static void Main(string[] args)
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            Queue<string> inputBunkers = new Queue<string>();
            Queue<int> inputWeapons = new Queue<int>();
            Dictionary<string, Queue<int>> filledBunkers = new Dictionary<string, Queue<int>>();

            int tryParse = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bunker Revision")
                {
                    break;
                }
                string[] tokens = input.Split().ToArray();
                foreach (var i in tokens)
                {
                    if (int.TryParse(i, out tryParse))
                    {
                        if (bunkerCapacity >= tryParse)
                        {
                            inputWeapons.Enqueue(tryParse);
                        }
                    }
                    else
                    {
                        inputBunkers.Enqueue(i);
                    }
                }

                int currCapacity = bunkerCapacity;
                if (inputBunkers.Count == 0)
                {
                    break;
                }
                while (true)
                {
                    if (inputBunkers.Count > 0 && filledBunkers.Count > 0)
                    {
                        foreach (var kvp in filledBunkers)
                        {
                            if (kvp.Value.Count > 0)
                            {
                                Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
                            }
                            else
                            {
                                Console.WriteLine($"{kvp.Key} -> Empty");
                            }
                        }
                        filledBunkers.Clear();
                    }


                    string currBunker = inputBunkers.Dequeue();
                    Queue<int> currBunkerStash = new Queue<int>();
                    currCapacity = AddWeapon(currBunkerStash, inputWeapons, currCapacity);
                    if (currCapacity == 0 && inputBunkers.Count > 0)
                    {

                        Console.WriteLine($"{currBunker} -> {string.Join(", ", currBunkerStash)}");
                        currCapacity = bunkerCapacity;
                    }
                    else if(currCapacity == bunkerCapacity && inputBunkers.Count > 0)
                    {
                        Console.WriteLine($"{currBunker} -> Empty");
                    }
                    else
                    {
                        if (inputBunkers.Count == 0)
                        {
                            
                            while (inputWeapons.Count > 0)
                            {
                                currCapacity = RearangeLastBunker(currBunkerStash, inputWeapons.Dequeue(), currCapacity);
                            }
                            filledBunkers[currBunker] = new Queue<int>(currBunkerStash);

                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{currBunker} -> {string.Join(", ", currBunkerStash)}");
                            break;
                        }

                    }
                }
                int t = 0;
            }
        }
    }
}
