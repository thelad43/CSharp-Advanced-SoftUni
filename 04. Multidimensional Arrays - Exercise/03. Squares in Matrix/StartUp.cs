namespace _03._Squares_in_Matrix
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = ReadMatrix(matrixSize);

            var count = GetCountOfEqualChars(matrixSize, matrix);

            Console.WriteLine(count);
        }

        private static int GetCountOfEqualChars(int[] matrixSize, string[,] matrix)
        {
            var count = 0;

            for (int row = 0; row < matrixSize[0] - 1; row++)
            {
                for (int col = 0; col < matrixSize[1] - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static string[,] ReadMatrix(int[] matrixSize)
        {
            var matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var cells = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            return matrix;
        }
    }
}