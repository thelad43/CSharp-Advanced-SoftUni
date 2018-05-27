namespace _03._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var sourceWordsPath = @"..\..\..\..\Source\words.txt";
            var sourceContainedWords = @"..\..\..\..\Source\text.txt";
            var resultPath = @"..\..\..\..\Source\resultWordCount.txt";

            var words = new List<string>();

            using (var reader = new StreamReader(sourceWordsPath))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    words.Add(line);
                }
            }

            var wordByCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(sourceContainedWords))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var lineTokens = line
                        .Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => w.ToLower())
                        .ToArray();

                    for (int i = 0; i < words.Count; i++)
                    {
                        var currentWord = words[i];
                        var isContainedInCurrentLine = lineTokens.Contains(currentWord) ? true : false;
                        var countOfContainedWord = lineTokens.Where(w => w == currentWord).ToArray().Length;

                        if (isContainedInCurrentLine)
                        {
                            if (!wordByCount.ContainsKey(currentWord))
                            {
                                wordByCount[currentWord] = 0;
                            }

                            wordByCount[currentWord] += countOfContainedWord;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(resultPath))
            {
                foreach (var kvp in wordByCount)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}