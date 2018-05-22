namespace _08._Radioactive_Bunnies
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(matrixSize[0]);
            var cols = int.Parse(matrixSize[1]);

            var cave = new char[rows, cols];
            var result = string.Empty;
            string inputLine;

            for (var i = 0; i < rows; i++)
            {
                inputLine = Console.ReadLine().Trim();

                for (var j = 0; j < cols; j++)
                {
                    cave[i, j] = inputLine[j];
                }
            }

            var resultingCave = new char[rows, cols];
            Array.Copy(cave, resultingCave, cave.Length);

            inputLine = Console.ReadLine().Trim();
            var died = false;
            var escaped = false;

            for (var i = 0; i < inputLine.Length; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    for (var k = 0; k < cols; k++)
                    {
                        if (!cave[j, k].Equals('P'))
                        {
                            continue;
                        }

                        switch (inputLine[i])
                        {
                            case 'U':
                                try
                                {
                                    if (resultingCave[j - 1, k].Equals('B'))
                                    {
                                        result = $"dead: {j - 1} {k}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j - 1, k] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    result = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'L':
                                try
                                {
                                    if (resultingCave[j, k - 1].Equals('B'))
                                    {
                                        result = $"dead: {j} {k - 1}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j, k - 1] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    result = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'R':
                                try
                                {
                                    if (resultingCave[j, k + 1].Equals('B'))
                                    {
                                        result = $"dead: {j} {k + 1}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j, k + 1] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    result = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'D':
                                try
                                {
                                    if (resultingCave[j + 1, k].Equals('B'))
                                    {
                                        result = $"dead: {j + 1} {k}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j + 1, k] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    result = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;
                        }
                    }
                }

                for (var j = 0; j < rows; j++)
                {
                    for (var k = 0; k < cols; k++)
                    {
                        if (!cave[j, k].Equals('B'))
                        {
                            continue;
                        }
                        try
                        {
                            var element = resultingCave[j - 1, k];

                            if (element.Equals('P'))
                            {
                                died = true;
                                result = $"dead: {j - 1} {k}";
                            }

                            resultingCave[j - 1, k] = 'B';
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            var element = resultingCave[j + 1, k];

                            if (element.Equals('P'))
                            {
                                died = true;
                                result = $"dead: {j + 1} {k}";
                            }

                            resultingCave[j + 1, k] = 'B';
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            var element = resultingCave[j, k - 1];

                            if (element.Equals('P'))
                            {
                                died = true;
                                result = $"dead: {j } {k - 1}";
                            }
                            resultingCave[j, k - 1] = 'B';
                        }
                        catch (Exception)
                        {
                        }

                        try
                        {
                            var element = resultingCave[j, k + 1];

                            if (element.Equals('P'))
                            {
                                died = true;
                                result = $"dead: {j } {k + 1}";
                            }

                            resultingCave[j, k + 1] = 'B';
                        }
                        catch (Exception)
                        {
                        }

                        resultingCave[j, k] = 'B';
                    }
                }

                Array.Copy(resultingCave, cave, resultingCave.Length);

                if (!died && !escaped)
                {
                    continue;
                }

                for (var l = 0; l < rows; l++)
                {
                    for (var m = 0; m < cols; m++)
                    {
                        Console.Write(resultingCave[l, m]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine(result);
                return;
            }
        }
    }
}