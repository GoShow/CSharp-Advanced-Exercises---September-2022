using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> userNames = new HashSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string userName = Console.ReadLine();

                userNames.Add(userName);
            }

            foreach (var userName in userNames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
