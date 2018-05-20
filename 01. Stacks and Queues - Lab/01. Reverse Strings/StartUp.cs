namespace _01._Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var inputAsCharArray = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();

            foreach (var letter in inputAsCharArray)
            {
                stack.Push(letter);
            }

            foreach (var letter in stack)
            {
                Console.Write(letter);
            }
        }
    }
}