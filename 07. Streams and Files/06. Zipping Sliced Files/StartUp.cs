namespace _06._Zipping_Sliced_Files
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class StartUp
    {
        private const int bufferSize = 4096;

        public static void Main()
        {
            var sourcePath = @"..\..\..\..\Source\sliceMe.mp4";
            var destination = @"..\..\..\..\Source\";
            var parts = 2;

            Zip(sourcePath, destination, parts);
        }

        private static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                var pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    var currentPieceSize = 0L;
                    destinationDirectory = destinationDirectory == string.Empty ? @".\" : destinationDirectory;
                    var currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    using (var writer =
                        new GZipStream(
                            new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
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
    }
}