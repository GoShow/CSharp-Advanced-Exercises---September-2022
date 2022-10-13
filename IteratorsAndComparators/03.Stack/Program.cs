using System;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Push":
                        string[] itemsToPush = tokens.Skip(1).ToArray();
                        foreach (var item in itemsToPush)
                        {
                            stack.Push(item);
                        }

                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
