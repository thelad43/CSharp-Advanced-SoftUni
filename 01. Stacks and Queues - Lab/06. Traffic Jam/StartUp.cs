namespace _06._Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var numberOfCarsCanPassDuringGreenLight = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            var passedCars = 0;

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                if (line != "green")
                {
                    var car = line;
                    cars.Enqueue(car);
                }
                else
                {
                    for (int i = 0; i < numberOfCarsCanPassDuringGreenLight; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        var car = cars.Dequeue();
                        passedCars++;
                        Console.WriteLine($"{car} passed!");
                    }
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}