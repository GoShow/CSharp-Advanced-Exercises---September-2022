using System;

namespace _01.DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person();
            peter.Name = "Peter";
            peter.Age = 20;

            Person george = new Person
            {
                Name = "George",
                Age = 18
            };

            Console.WriteLine($"{peter.Name} is {peter.Age} years old");
            Console.WriteLine($"{george.Name} is {george.Age} years old");
        }
    }
}
