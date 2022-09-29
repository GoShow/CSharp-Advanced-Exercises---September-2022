using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FIndEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isEven = Console.ReadLine() == "even";

            List<int> numbers = new List<int>();

            List<int> result = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = number => number % 2 == 0;
            Predicate<int> odd = number => number % 2 != 0;

            if (isEven)
            {
                result = numbers.FindAll(even);
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
