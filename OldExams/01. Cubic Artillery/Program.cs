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
            return 0;
        }
        static void RearangeLastBunker(Queue<int> bunker, int weapon,  int remainingCapacity)
        {
            Queue<int> tempStorage = new Queue<int>();
            while (true)
            {
                int removedWeapon = bunker.Dequeue();
                tempStorage.Enqueue(removedWeapon);
                remainingCapacity += removedWeapon;
                if(remainingCapacity >= weapon)
                {
                    bunker.Enqueue(weapon);
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            Queue<string> inputBunkers = new Queue<string>();
            Queue<int> inputWeapons = new Queue<int>();
            Dictionary<string, Queue<int>> bunkers = new Dictionary<string, Queue<int>>();
            int tryParse = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "Bunker Revision")
                {
                    break;
                }
                string[] tokens = input.Split().ToArray();
                foreach (var i in tokens)
                {
                    if(int.TryParse(i, out tryParse))
                    {
                        if(bunkerCapacity >= tryParse)
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
                string currBunker = inputBunkers.Dequeue();
                Queue<int> currBunkerStash = new Queue<int>();
                currCapacity = AddWeapon(currBunkerStash, inputWeapons, currCapacity);
                if (currCapacity == 0)
                {
                    Console.WriteLine($"{currBunker} -> {string.Join(", ",currBunkerStash)}");
                }
                else
                {
                    if(bunkers.Count == 1)
                    {
                        RearangeLastBunker(currBunkerStash, inputWeapons.Dequeue(), currCapacity);
                    }
                    int p = 0;
                }
                int t = 0;
            }
        }
    }
}
