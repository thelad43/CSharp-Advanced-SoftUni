namespace _07._Predicate_For_Names
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            names
                .Where(n => n.Length <= length)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}