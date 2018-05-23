namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
              .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .OrderBy(n => n)
              .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}