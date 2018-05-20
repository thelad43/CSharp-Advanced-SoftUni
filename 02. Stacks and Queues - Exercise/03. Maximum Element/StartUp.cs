namespace _03._Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                var commandTokens = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (commandTokens[0] == 1)
                {
                    var elementToPush = commandTokens[1];
                    stack.Push(elementToPush);

                    if (elementToPush > maxStack.Peek())
                    {
                        maxStack.Push(elementToPush);
                    }
                }
                else if (commandTokens[0] == 2)
                {
                    var elementToPop = stack.Pop();

                    if (maxStack.Peek() == elementToPop)
                    {
                        maxStack.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}