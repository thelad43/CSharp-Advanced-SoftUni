namespace _09._List_Of_Predicates
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var endOfRange = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            var isDivisible = true;

            for (int i = 1; i <= endOfRange; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i % numbers[j] != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{i} ");
                }

                isDivisible = true;
            }
        }
    }
}