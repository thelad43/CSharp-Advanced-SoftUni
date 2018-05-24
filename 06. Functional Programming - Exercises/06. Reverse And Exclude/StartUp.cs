namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var divider = int.Parse(Console.ReadLine());

            numbers
                .Where(n => n % divider != 0)
                .Reverse()
                .ToList()
                .ForEach(n => Console.Write($"{n} "));
        }
    }
}