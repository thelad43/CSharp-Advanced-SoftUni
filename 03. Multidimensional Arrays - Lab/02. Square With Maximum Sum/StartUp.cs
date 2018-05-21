namespace _02._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrix = ReadMatrix();
            PrintMaxSumOfSquare(matrix);
        }

        private static void PrintMaxSumOfSquare(int[,] matrix)
        {
            var maxSum = int.MinValue;
            var currentMaxSquareMatrix = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSquareSum = matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col + 1];

                    if (currentSquareSum > maxSum)
                    {
                        maxSum = currentSquareSum;

                        currentMaxSquareMatrix[0, 0] = matrix[row, col];
                        currentMaxSquareMatrix[1, 0] = matrix[row + 1, col];
                        currentMaxSquareMatrix[0, 1] = matrix[row, col + 1];
                        currentMaxSquareMatrix[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }

            for (int row = 0; row < currentMaxSquareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < currentMaxSquareMatrix.GetLength(1); col++)
                {
                    Console.Write(currentMaxSquareMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }

        private static int[,] ReadMatrix()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < numbers.Length; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            return matrix;
        }
    }
}