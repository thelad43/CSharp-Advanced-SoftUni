namespace _02._Knights_of_Honor
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(n => $"Sir {n}")
               .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}