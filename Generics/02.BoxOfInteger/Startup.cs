using System;

namespace _02.BoxOfInteger
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());

                box.Items.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
