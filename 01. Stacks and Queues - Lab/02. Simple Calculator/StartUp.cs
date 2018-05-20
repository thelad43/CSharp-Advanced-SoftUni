namespace _02._Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var stack = new Stack<string>(inputLine.Split(' ').Reverse());

            while (true)
            {
                if (stack.Count == 1)
                {
                    break;
                }

                var firstNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                var currentResult = 0;

                currentResult = op == "+" ? firstNumber + secondNumber : firstNumber - secondNumber;

                stack.Push(currentResult.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}