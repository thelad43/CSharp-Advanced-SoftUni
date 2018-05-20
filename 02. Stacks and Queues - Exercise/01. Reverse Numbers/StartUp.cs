namespace _01._Reverse_Numbers
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(numbers);
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}