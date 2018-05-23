namespace _03._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var result = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}