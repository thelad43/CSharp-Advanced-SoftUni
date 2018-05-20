namespace _05._Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            queue.Enqueue(n);

            for (int i = 0; i < 50; i++)
            {
                var head = queue.Peek();

                queue.Enqueue(head + 1);
                queue.Enqueue(2 * head + 1);
                queue.Enqueue(head + 2);

                Console.Write($"{queue.Dequeue()} ");
            }
        }
    }
}