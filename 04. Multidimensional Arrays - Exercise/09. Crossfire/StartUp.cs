namespace _09._Crossfire
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];

            var matrix = FillMatrix(rowSize, colSize);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Nuke it from orbit")
                {
                    break;
                }

                var bombTokens = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var bombRow = bombTokens[0];
                var bombCol = bombTokens[1];
                var bombRadius = bombTokens[2];

                Explosion(ref matrix, bombRow, bombCol, bombRadius);
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row.Where(n => n > 0)));
            }
        }

        private static void Explosion(ref int[][] matrix, int bombRow, int bombCol, int bombRadius)
        {
            for (int rowIndex = bombRow - bombRadius; rowIndex <= bombRow + bombRadius; rowIndex++)
            {
                if (AreIndexesValid(rowIndex, bombCol, matrix))
                {
                    matrix[rowIndex][bombCol] = -1;
                }
            }

            for (int colIndex = bombCol - bombRadius; colIndex <= bombCol + bombRadius; colIndex++)
            {
                if (AreIndexesValid(bombRow, colIndex, matrix))
                {
                    matrix[bombRow][colIndex] = -1;
                }
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex].Any(c => c == -1))
                {
                    matrix[rowIndex] = matrix[rowIndex].Where(n => n > 0).ToArray();
                }

                if (matrix[rowIndex].Length < 1)
                {
                    matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                    rowIndex--;
                }
            }
        }

        private static bool AreIndexesValid(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] FillMatrix(int rowSize, int colSize)
        {
            var matrix = new int[rowSize][];
            var fillNumber = 1;

            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                matrix[rowIndex] = new int[colSize];

                for (int colIndex = 0; colIndex < colSize; colIndex++)
                {
                    matrix[rowIndex][colIndex] = fillNumber;
                    fillNumber++;
                }
            }

            return matrix;
        }
    }
}