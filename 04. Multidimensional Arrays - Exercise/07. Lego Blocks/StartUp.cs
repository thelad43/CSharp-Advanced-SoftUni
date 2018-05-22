namespace _07._Lego_Blocks
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var leftBlock = new int[rows][];
            var rightBlock = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                leftBlock[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                rightBlock[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
            }

            var rowLenght = leftBlock[0].Length + rightBlock[0].Length;
            var allElements = 0;
            var isMatch = true;

            for (int row = 0; row < rows; row++)
            {
                var currentLenght = leftBlock[row].Length + rightBlock[row].Length;

                if (currentLenght != rowLenght)
                {
                    isMatch = false;
                }

                allElements += currentLenght;
            }

            if (isMatch)
            {
                var resultRow = new int[rowLenght];

                for (int r = 0; r < rows; r++)
                {
                    resultRow = leftBlock[r].Concat(rightBlock[r]).ToArray();
                    Console.WriteLine($"[{string.Join(", ", resultRow)}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {allElements}");
            }
        }
    }
}