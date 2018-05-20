namespace _05._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var kids = Console.ReadLine().Split(' ');
            var queue = new Queue<string>(kids);
            var n = int.Parse(Console.ReadLine());

            while (true)
            {
                if (queue.Count == 1)
                {
                    break;
                }

                for (int i = 0; i < n - 1; i++)
                {
                    var kid = queue.Dequeue();
                    queue.Enqueue(kid);
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}