namespace _09._Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var result = CalculateFibonacci(n);
            Console.WriteLine(result);
        }

        private static long CalculateFibonacci(int n)
        {
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var first = stack.Pop();
                var second = stack.Pop();

                stack.Push(first);
                stack.Push(first + second);
            }

            return stack.Peek();
        }
    }
}