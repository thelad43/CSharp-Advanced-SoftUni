namespace _01._Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var rowsAndCols = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = "" + (char)('a' + row) + (char)('a' + row + col) + (char)('a' + row);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}