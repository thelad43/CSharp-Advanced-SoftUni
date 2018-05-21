namespace _04._Pascal_Triangle
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var triangle = new int[rows][];
            var currentWidth = 1;

            for (int height = 0; height < rows; height++)
            {
                triangle[height] = new int[currentWidth];

                var currentRow = triangle[height];

                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length - 1; i++)
                    {
                        var previousRow = triangle[height - 1];
                        var prevoiousRowSum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = prevoiousRowSum;
                    }
                }
            }

            for (int i = 0; i < triangle.Length; i++)
            {
                var innerArray = triangle[i];

                for (int j = 0; j < innerArray.Length; j++)
                {
                    Console.Write(innerArray[j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}