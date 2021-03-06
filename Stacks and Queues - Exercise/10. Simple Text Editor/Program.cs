﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder SB = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < n; ++i)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                int firstCommand = int.Parse(commands[0]);
                switch (firstCommand)
                {
                    case 1:
                        {
                            stack.Push("!" + commands[1]);
                            SB.Append(commands[1]);
                            break;
                        }
                    case 2:
                        {

                            int eraseCount = int.Parse(commands[1]);
                            char[] toRemoveArr = new char[eraseCount];
                            SB.CopyTo(SB.Length - eraseCount, toRemoveArr, 0, eraseCount);
                            stack.Push(new string(toRemoveArr));
                            SB.Remove(SB.Length - eraseCount, eraseCount);
                            break;
                        }
                    case 3:
                        {
                            int idx = int.Parse(commands[1]) - 1;
                            if (idx >= 0 && idx < SB.Length)
                            {
                                Console.WriteLine(SB[idx]);

                            }
                            break;
                        }
                    case 4:
                        {
                            if (stack.Count > 0)
                            {
                                string fromStack = stack.Pop();
                                if (fromStack.Contains("!"))
                                {
                                    string toRemove = fromStack.Substring(1, fromStack.Length - 1);
                                    SB.Remove(SB.Length - toRemove.Length, toRemove.Length);
                                }
                                else
                                {

                                    SB.Append(fromStack);
                                }

                            }

                            break;
                        }
                }
            }
        }
    }
}
