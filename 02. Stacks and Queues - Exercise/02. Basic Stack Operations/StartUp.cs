namespace _02._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    partial class StartUp
    {
        public static void Main()
        {
            var inputParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var countOfElementsToPush = inputParams[0];
            var countOfElementsToPop = inputParams[1];
            var elementForChecking = inputParams[2];

            var elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < countOfElementsToPush; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < countOfElementsToPop; i++)
            {
                if (!stack.Any())
                {
                    break;
                }

                stack.Pop();
            }

            if (!stack.Any())
            {
                Console.WriteLine(0);
                return;
            }

            var result = stack.Contains(elementForChecking) ? "true" : stack.Min().ToString();
            Console.WriteLine(result);
        }
    }
}