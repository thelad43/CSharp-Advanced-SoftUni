namespace _02._Line_Numbers
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var sourcePath = @"..\..\..\..\Source\text.txt";
            var resultPath = @"..\..\..\..\Source\result.txt";

            using (var reader = new StreamReader(sourcePath))
            {
                using (var writer = new StreamWriter(resultPath))
                {
                    var index = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {index}: {line}");
                        index++;
                    }
                }
            }

            var result = File.ReadAllLines(resultPath);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}