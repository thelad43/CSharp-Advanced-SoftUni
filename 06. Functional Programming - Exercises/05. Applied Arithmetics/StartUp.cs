namespace _05._Applied_Arithmetics
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

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                switch (line)
                {
                    case "add":
                        numbers = numbers
                            .Select(n => n + 1)
                            .ToArray();
                        break;

                    case "multiply":
                        numbers = numbers
                            .Select(n => n * 2)
                            .ToArray();
                        break;

                    case "subtract":
                        numbers = numbers
                            .Select(n => n - 1)
                            .ToArray();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}