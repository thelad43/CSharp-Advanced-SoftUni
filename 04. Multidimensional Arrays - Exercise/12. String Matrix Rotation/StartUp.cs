namespace _12._String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var degreesString = Console.ReadLine().Trim().ToLower();
            var rg = new Regex(@"rotate\((\d+)\)");
            var degrees = int.Parse(rg.Match(degreesString).Groups[1].ToString());
            var rotationsCount = (degrees / 90) % 4;
            var lines = new List<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                lines.Add(input);
                input = Console.ReadLine();
            }

            var matrix = new char[lines.Count][];
            var wordsLen = lines.Max(r => r.Length);

            for (int row = 0; row < lines.Count; row++)
            {
                matrix[row] = lines[row].PadRight(wordsLen).ToCharArray();
            }

            for (int i = 0; i < rotationsCount; i++)
            {
                matrix = Rotate(matrix);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static char[][] Rotate(char[][] words)
        {
            var result = new char[words.Max(w => w.Length)][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[words.Length];

                for (int col = 0; col < result[row].Length; col++)
                {
                    result[row][col] = words[words.Length - 1 - col][row];
                }
            }

            return result;
        }
    }
}