namespace _03._Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var result = ConvertToBinary(number);
            Console.WriteLine(result);
        }

        private static string ConvertToBinary(int number)
        {
            if (number == 0)
            {
                return "0";
            }

            var stack = new Stack<int>();

            while (true)
            {
                if (number == 0)
                {
                    break;
                }

                var reminder = number % 2;
                stack.Push(reminder);
                number /= 2;
            }

            var result = new StringBuilder(stack.Count);

            while (true)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                result.Append(stack.Pop());
            }

            return result.ToString();
        }
    }
}