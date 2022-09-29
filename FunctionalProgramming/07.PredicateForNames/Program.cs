using System;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], Predicate<string>> printNames = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(names, n => n.Length <= length);
        }
    }
}
