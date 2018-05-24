﻿namespace _12._Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            ExecuteCommands(gems);
            Console.WriteLine(string.Join(" ", gems));
        }

        private static void ExecuteCommands(List<int> gems)
        {
            var input = Console.ReadLine().Split(';');
            var exclusionFilters = new Queue<KeyValuePair<string, int>>();

            while (true)
            {
                if (input[0] == "Forge")
                {
                    break;
                }

                if (input.Length < 3)
                {
                    input = Console.ReadLine().Split(';');
                    continue;
                }

                var command = input[0];
                var filterType = input[1];
                var filterParamenter = int.Parse(input[2]);

                switch (command)
                {
                    case "Exclude":
                        exclusionFilters.Enqueue(new KeyValuePair<string, int>(filterType, filterParamenter));
                        break;

                    case "Reverse":
                        if (exclusionFilters.Count > 0)
                        {
                            exclusionFilters.Dequeue();
                        }

                        break;

                    default:
                        throw new ArgumentException();
                }

                input = Console.ReadLine().Split(';');
            }

            ExecuteExclusions(gems, exclusionFilters);
        }

        private static void ExecuteExclusions(List<int> gems, Queue<KeyValuePair<string, int>> exclusionFilters)
        {
            foreach (var filter in exclusionFilters.Reverse())
            {
                switch (filter.Key)
                {
                    case "Sum Left":
                        FilterLeft(filter.Value, gems);
                        break;

                    case "Sum Right":
                        FilterRight(filter.Value, gems);
                        break;

                    case "Sum Left Right":
                        FilterLeftRight(filter.Value, gems);
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }

        private static void FilterLeftRight(int value, List<int> gems)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var leftGemPower = (i == 0) ? 0 : gems[i - 1];
                var rightGemPower = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGemPower + gems[i] + rightGemPower == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void FilterRight(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.Last() == value)
            {
                gems.RemoveAt(gems.Count - 1);
            }

            for (int i = 0; i < gems.Count; i++)
            {
                var rightNum = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (gems[i] + rightNum == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void FilterLeft(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.First() == value)
            {
                gems.RemoveAt(0);
            }

            for (int i = gems.Count - 1; i >= 0; i--)
            {
                var leftNum = (i > 0) ? gems[i - 1] : 0;

                if (gems[i] + leftNum == value)
                {
                    gems.RemoveAt(i);
                }
            }
        }
    }
}