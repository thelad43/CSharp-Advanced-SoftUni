namespace _04._Maximal_Sum
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

            var maxSum = int.MinValue;
            var rowStartIndex = -1;
            var colStartIndex = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                           matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                           matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowStartIndex = row;
                        colStartIndex = col;
                    }
                }
            }

            PrintMatrix(matrix, maxSum, rowStartIndex, colStartIndex);
        }

        private static void PrintMatrix(int[,] matrix, int maxSum, int rowIndex, int colIndex)
        {
            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
        }

        private static int[,] ReadMatrix(int[] matrixSize)
        {
            var matrix = new int[matrixSize[0], matrixSize[1]];

            for (int rows = 0; rows < matrixSize[0]; rows++)
            {
                var numbers = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrixSize[1]; cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }

            return matrix;
        }
    }
}