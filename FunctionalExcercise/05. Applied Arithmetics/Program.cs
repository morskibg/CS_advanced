using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static int Add(int num)
        {
            return num + 1;
        }
        static int Multiply(int num)
        {
            return num * 2;
        }
        static int Subtract(int num)
        {
            return num  - 1;
        }

        
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                bool isPrinting = false;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (isPrinting)
                    {
                        break;
                    }
                    Func<int, int> calcFunc = null;
                    switch (input)
                    {
                        case "add":
                            calcFunc = Add;
                            break;
                        case "multiply":
                            calcFunc = Multiply;
                            break;
                        case "subtract":
                            calcFunc = Subtract;
                            break;
                        case "print":
                            isPrinting = true;
                            break;
                            
                        default:
                                break;
                    }
                    if (isPrinting)
                    {
                        Console.WriteLine(string.Join(" ", nums));
                        isPrinting = false;
                        break;
                    }
                    nums[i] = calcFunc(nums[i]);
                    
                }

            }
            int t = 0;
        }
    }
}
