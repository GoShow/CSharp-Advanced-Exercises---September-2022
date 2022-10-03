namespace _07.RawData
{
    public class Car
    {

        public Car(
            string model,
            int speed,
            int power,
            int weight,
            string type,
            double tyre1pressure,
            int tyre1age,
            double tyre2pressure,
            int tyre2age,
            double tyre3pressure,
            int tyre3age,
            double tyre4pressure,
            int tyre4age)
        {

            Model = model;
            Engine = new Engine { Speed = speed, Power = power };
            Cargo = new Cargo { Weight = weight, Type = type };
            Tyres = new Tyre[4];
            Tyres[0] = new Tyre { Pressure = tyre1pressure, Age = tyre1age };
            Tyres[1] = new Tyre { Pressure = tyre2pressure, Age = tyre2age };
            Tyres[2] = new Tyre { Pressure = tyre3pressure, Age = tyre3age };
            Tyres[3] = new Tyre { Pressure = tyre4pressure, Age = tyre4age };
        }



        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }
    }
}
