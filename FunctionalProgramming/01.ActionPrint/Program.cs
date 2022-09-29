using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (strings) => Console.WriteLine(string.Join(Environment.NewLine, strings));

            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(strings);
        }
    }
}
