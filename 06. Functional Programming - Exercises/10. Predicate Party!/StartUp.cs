namespace _10._Predicate_Party_
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Party!")
                {
                    break;
                }

                var cmdParams = line
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var removed = string.Empty;

                switch (cmdParams[0])
                {
                    case "Remove":
                        int length;

                        if (int.TryParse(cmdParams[2], out length))
                        {
                            var peopleForDeleting = people
                                .Where(p => p.Length == length)
                                .ToArray();

                            for (int i = 0; i < peopleForDeleting.Length; i++)
                            {
                                people.Remove(peopleForDeleting[i]);
                            }
                        }
                        else if (cmdParams[1] == "StartsWith")
                        {
                            removed = people
                                   .Where(p => p
                                   .StartsWith(cmdParams[2]))
                                   .FirstOrDefault();

                            people.Remove(removed);
                        }
                        else
                        {
                            removed = people
                                  .Where(p => p
                                  .EndsWith(cmdParams[2]))
                                  .FirstOrDefault();

                            people.Remove(removed);
                        }
                        break;

                    case "Double":
                        if (int.TryParse(cmdParams[2], out length))
                        {
                            var peopleForDouble = people
                                .Where(p => p.Length == length)
                                .ToArray();

                            for (int i = 0; i < peopleForDouble.Length; i++)
                            {
                                people.Add(peopleForDouble[i]);
                            }
                        }
                        else if (cmdParams[1] == "StartsWith")
                        {
                            var doubled = people
                                    .Where(p => p
                                    .StartsWith(cmdParams[2]))
                                    .FirstOrDefault();

                            var n = people.Where(p => p == doubled).Count();

                            for (int i = 0; i < n; i++)
                            {
                                people.Add(doubled);
                            }
                        }
                        else
                        {
                            var doubled = people
                                  .Where(p => p
                                  .EndsWith(cmdParams[2]))
                                  .FirstOrDefault();

                            var n = people.Where(p => p == doubled).Count();

                            for (int i = 0; i < n; i++)
                            {
                                people.Add(doubled);
                            }
                        }
                        break;

                    default:
                        throw new ArgumentException();
                }
            }

            if (people.Any())
            {
                Console.Write(string.Join(", ", people.OrderBy(p => p)));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}