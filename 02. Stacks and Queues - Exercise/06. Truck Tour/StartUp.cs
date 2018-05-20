namespace _06._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pump);
            }

            for (int start = 0; start < n - 1; start++)
            {
                var fuel = 0;
                var isSolution = true;

                for (int passedPumps = 0; passedPumps < n; passedPumps++)
                {
                    var currentPump = queue.Dequeue();
                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        start += passedPumps;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(start);
                    Environment.Exit(0);
                }
            }
        }
    }
}