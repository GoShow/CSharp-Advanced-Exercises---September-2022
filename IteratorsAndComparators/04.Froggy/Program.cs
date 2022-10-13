using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
