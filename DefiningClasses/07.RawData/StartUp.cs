using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(
                    carProperties[0],
                    int.Parse(carProperties[1]),
                    int.Parse(carProperties[2]),
                    int.Parse(carProperties[3]),
                    carProperties[4],
                    double.Parse(carProperties[5]),
                    int.Parse(carProperties[6]),
                    double.Parse(carProperties[7]),
                    int.Parse(carProperties[8]),
                    double.Parse(carProperties[9]),
                    int.Parse(carProperties[10]),
                    double.Parse(carProperties[11]),
                    int.Parse(carProperties[12])
                    );

                cars.Add(car);
            }

            string command = Console.ReadLine();

            string[] filteredCarModels;

            if (command == "fragile")
            {
                filteredCarModels = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToArray();
            }
            else
            {
                filteredCarModels = cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToArray();
            }

            Console.WriteLine(string.Join(Environment.NewLine, filteredCarModels));
        }
    }
}
