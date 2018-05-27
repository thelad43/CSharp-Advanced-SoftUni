namespace _05._Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        private const int bufferSize = 4096;

        public static void Main()
        {
            var sourcePath = @"..\..\..\..\Source\sliceMe.mp4";
            var destination = @"..\..\..\..\Source\";
            var parts = 7;

            Slice(sourcePath, destination, parts);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                var pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    var currentPieceSize = 0L;
                    destinationDirectory = destinationDirectory == string.Empty ? @".\" : destinationDirectory;
                    var currentPart = destinationDirectory + $"Part-{i}.{extension}";

                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                        var buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf('.') + 1);
            destinationDirectory = destinationDirectory == string.Empty ? @".\" : destinationDirectory;
            var assembledFile = $"{destinationDirectory}Assembled.{extension}";

            if (!destinationDirectory.EndsWith("\\"))
            {
                destinationDirectory += "\\";
            }

            using (var writer = new FileStream(assembledFile, FileMode.Create))
            {
                var buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}