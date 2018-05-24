namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evenOrOdd = Console.ReadLine();
            var result = new List<int>();
            Predicate<int> isEven = n => n % 2 == 0;

            Enumerable.Range(range[0], range[1] - range[0] + 1)
                .Where(n => evenOrOdd == "even" ? isEven(n) : !isEven(n))
                .ToList()
                .ForEach(result.Add);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}