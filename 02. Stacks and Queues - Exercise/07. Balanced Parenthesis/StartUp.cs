namespace _07._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            var opening = new[] { '(', '[', '{' };
            var closing = new[] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();

                    if (Array.IndexOf(opening, lastElement) != Array.IndexOf(closing, element))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}