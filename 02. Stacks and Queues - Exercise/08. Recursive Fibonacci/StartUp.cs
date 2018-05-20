namespace _08._Recursive_Fibonacci
{
    using System;

    public class StartUp
    {
        private static long[] memoization;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            memoization = new long[n + 1];
            var result = Fibonacci(n - 1);
            Console.WriteLine(result);
        }

        private static long Fibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memoization[n] != 0)
            {
                return memoization[n];
            }

            memoization[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memoization[n];
        }
    }
}