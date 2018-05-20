namespace _04._Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var expression = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                var currentChar = expression[i];

                if (currentChar == '(')
                {
                    stack.Push(i);
                }

                if (currentChar == ')')
                {
                    var topMostElement = stack.Pop();
                    var subExpression = expression.Substring(topMostElement, i - topMostElement + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}