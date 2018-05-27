namespace _07._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var path = Console.ReadLine();
            var filesDictionary = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }

                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fullFileName = desktop + "\\report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var kvp in filesDictionary)
                {
                    var extension = kvp.Key;
                    var fileInfos = kvp.Value.OrderByDescending(f => f.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfos)
                    {
                        var size = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {size:F3}kb");
                    }
                }
            }
        }
    }
}