using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = (numbers) =>
            {
                int min = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(min(numbers));
        }
    }
}
