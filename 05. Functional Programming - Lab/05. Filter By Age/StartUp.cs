namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var peopleAndAge = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);

                peopleAndAge[name] = age;
            }

            var condition = Console.ReadLine();
            var compareAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateFilter(condition, compareAge);
            var print = CreateWriter(format);

            foreach (var kvp in peopleAndAge)
            {
                if (filter(kvp.Value))
                {
                    print(kvp);
                }
            }
        }

        private static Func<int, bool> CreateFilter(string condition, int compareAge)
        {
            if (condition == "older")
            {
                return x => x >= compareAge;
            }

            return x => x < compareAge;
        }

        private static Action<KeyValuePair<string, int>> CreateWriter(string outputFormat)
        {
            switch (outputFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);

                case "age":
                    return x => Console.WriteLine(x.Value);

                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");

                default:
                    throw new ArgumentException();
            }
        }
    }
}