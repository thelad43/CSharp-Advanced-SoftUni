namespace _04._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
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

            var queue = new Queue<int>();

            for (int i = 0; i < countOfElementsToPush; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < countOfElementsToPop; i++)
            {
                if (!queue.Any())
                {
                    break;
                }

                queue.Dequeue();
            }

            if (!queue.Any())
            {
                Console.WriteLine(0);
                return;
            }

            var result = queue.Contains(elementForChecking) ? "true" : queue.Min().ToString();
            Console.WriteLine(result);
        }
    }
}