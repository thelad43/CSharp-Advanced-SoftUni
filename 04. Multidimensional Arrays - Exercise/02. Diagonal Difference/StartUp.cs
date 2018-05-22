namespace _02._Diagonal_Difference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(matrixSize);
            var leftSumDiagonal = GetLeftSumDiagonal(matrix);
            var rightSumDiagonal = GetRightSumDiagonal(matrix);
            Console.WriteLine(Math.Abs(leftSumDiagonal - rightSumDiagonal));
        }

        private static int GetRightSumDiagonal(int[,] matrix)
        {
            var rightSumDiagonal = 0;

            for (int row = 0, col = matrix.GetLength(0) - 1; row < matrix.GetLength(0); row++, col--)
            {
                rightSumDiagonal += matrix[row, col];
            }

            return rightSumDiagonal;
        }

        private static int GetLeftSumDiagonal(int[,] matrix)
        {
            var leftSumDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                leftSumDiagonal += matrix[row, row];
            }

            return leftSumDiagonal;
        }

        private static int[,] ReadMatrix(int matrixSize)
        {
            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            return matrix;
        }
    }
}