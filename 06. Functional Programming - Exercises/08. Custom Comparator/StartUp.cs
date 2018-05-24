namespace _08._Custom_Comparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var result = numbers
                .Where(n => Math.Abs(n) % 2 == 0)
                .OrderBy(n => n)
                .Concat(numbers
                .Where(n => Math.Abs(n) % 2 == 1)
                .OrderBy(n => n));

            Console.WriteLine(string.Join(" ", result));
        }
    }
}