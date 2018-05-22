namespace _11._Parking_System
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var rows = int.Parse(input[0]);
            var columns = int.Parse(input[1]);
            var matrix = new int[rows][];

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }

                var data = command.Split();
                var entrance = int.Parse(data[0]);
                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);
                var steps = Math.Abs(entrance - row) + 1;

                if (matrix[row] == null)
                {
                    matrix[row] = new int[columns];
                }

                if (matrix[row][col] == 0)
                {
                    matrix[row][col] = 1;
                    steps += col;
                    Console.WriteLine(steps);
                }
                else
                {
                    var count = 1;

                    while (true)
                    {
                        var lowerCell = col - count;
                        var upperCell = col + count;

                        if (lowerCell < 1 && upperCell > columns - 1)
                        {
                            Console.WriteLine($"Row {row} full");
                            break;
                        }

                        if (lowerCell > 0 && matrix[row][lowerCell] == 0)
                        {
                            matrix[row][lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }

                        if (upperCell < columns && matrix[row][upperCell] == 0)
                        {
                            matrix[row][upperCell] = 1;
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }

                        count++;
                    }
                }
            }
        }
    }
}