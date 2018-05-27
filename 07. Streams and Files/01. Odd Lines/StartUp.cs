namespace _01._Odd_Lines
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = @"..\..\..\..\Source\text.txt";

            using (var reader = new StreamReader(path))
            {
                var index = 0;

                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (index % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    index++;
                }
            }
        }
    }
}