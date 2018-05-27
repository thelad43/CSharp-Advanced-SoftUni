namespace _08._Full_Directory_Traversal
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);
            var files = filePaths.Select(path => new FileInfo(path)).ToList();

            var ordered = files
                .OrderBy(file => file.Length)
                .GroupBy(file => file.Extension)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fullPath = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullPath))
            {
                foreach (var fileInfos in ordered)
                {
                    writer.WriteLine(fileInfos.Key);

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