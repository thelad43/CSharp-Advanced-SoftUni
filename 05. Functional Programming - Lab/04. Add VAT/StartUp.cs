namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var result = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n += n * 0.2)
                .Select(n => $"{n:F2}")
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}