namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var smallestNumber = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Min();

            Console.WriteLine(smallestNumber);
        }
    }
}