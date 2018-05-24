namespace _01._Action_Print
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printNameOnNewLine = (string name) => Console.WriteLine(name);

            foreach (var name in names)
            {
                printNameOnNewLine(name);
            }
        }
    }
}