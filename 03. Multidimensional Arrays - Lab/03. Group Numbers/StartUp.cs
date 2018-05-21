namespace _03._Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            var numbersWithReminder0 = new List<int>(numbers.Where(n => Math.Abs(n) % 3 == 0));
            var numbersWithReminder1 = new List<int>(numbers.Where(n => Math.Abs(n) % 3 == 1));
            var numbersWithReminder2 = new List<int>(numbers.Where(n => Math.Abs(n) % 3 == 2));

            Console.WriteLine(string.Join(" ", numbersWithReminder0));
            Console.WriteLine(string.Join(" ", numbersWithReminder1));
            Console.WriteLine(string.Join(" ", numbersWithReminder2));
        }
    }
}