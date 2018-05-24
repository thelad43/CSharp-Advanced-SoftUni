namespace _13._TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var names = Console.ReadLine().
              Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = names
                .FirstOrDefault(name => CalculateSumOfCharacters(name) >= n);

            Console.WriteLine(result);
        }

        private static long CalculateSumOfCharacters(string word)
        {
            var chars = word.ToCharArray();
            var sum = 0L;

            for (int i = 0; i < chars.Length; i++)
            {
                sum += chars[i];
            }

            return sum;
        }
    }
}