namespace _11._The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split();
            var filters = GetFilters();
            people = FilterNames(filters, people);
            Console.WriteLine(string.Join(" ", people));
        }

        private static string[] FilterNames(HashSet<Filter> filters, string[] people)
        {
            foreach (var filter in filters)
            {
                if (filter.Command.Contains("starts"))
                {
                    people = Filter.FilterCollection(people, n => n.StartsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("ends"))
                {
                    people = Filter.FilterCollection(people, n => n.EndsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("length"))
                {
                    people = Filter.FilterCollection(people, n => n.Length == int.Parse(filter.Arg));
                }
                else if (filter.Command.Contains("contains"))
                {
                    people = Filter.FilterCollection(people, n => n.ToLower()
                    .Contains(filter.Arg.ToLower()));
                }
            }

            return people;
        }

        private static HashSet<Filter> GetFilters()
        {
            var filters = new HashSet<Filter>();

            var input = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            while (true)
            {
                if (input[0] == "Print")
                {
                    break;
                }

                var currentFilter = new Filter() { Command = input[1].ToLower(), Arg = input[2] };

                if (input[0].StartsWith("Add"))
                {
                    filters.Add(currentFilter);
                }
                else if (input[0].StartsWith("Remove"))
                {
                    filters.RemoveWhere(f =>
                        f.Arg == currentFilter.Arg &&
                        f.Command == currentFilter.Command);
                }

                input = Console.ReadLine()
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return filters;
        }
    }
}