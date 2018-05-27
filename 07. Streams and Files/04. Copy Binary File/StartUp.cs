namespace _04._Copy_Binary_File
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var sourcePath = @"..\..\..\..\Source\copyMe.png";
            var destinationPath = @"..\..\..\..\Source\copiedResult.png";

            using (var source = new FileStream(sourcePath, FileMode.Open))
            {
                using (var destination = new FileStream(destinationPath, FileMode.Create))
                {
                    var buffer = new byte[source.Length];

                    while (true)
                    {
                        var bytes = source.Read(buffer, 0, buffer.Length);

                        if (bytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, bytes);
                    }
                }
            }
        }
    }
}