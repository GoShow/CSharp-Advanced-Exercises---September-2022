using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] personProps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person
                {
                    Name = personProps[0],
                    Age = int.Parse(personProps[1])
                };

                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
