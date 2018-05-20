namespace _10._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var result = new StringBuilder();
            var history = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var commandTokens = Console.ReadLine().Split(' ');
                var command = int.Parse(commandTokens[0]);

                switch (command)
                {
                    case 1:
                        if (commandTokens.Length > 1)
                        {
                            history.Push(result.ToString());
                            result.Append(commandTokens[1]);
                        }
                        break;

                    case 2:
                        if (commandTokens.Length > 1)
                        {
                            var count = int.Parse(commandTokens[1]);
                            history.Push(result.ToString());

                            if (count > result.Length)
                            {
                                result.Clear();
                                break;
                            }

                            result.Remove(result.Length - count, count);
                        }
                        break;

                    case 3:
                        if (commandTokens.Length > 1)
                        {
                            var index = int.Parse(commandTokens[1]);

                            if (index <= result.Length && index > 0)
                            {
                                Console.WriteLine(result[index - 1]);
                            }
                        }
                        break;

                    case 4:
                        result.Clear();
                        result.Append(history.Pop());
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}