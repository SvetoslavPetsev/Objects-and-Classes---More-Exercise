using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Raw_Data
{
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }

    }

    public class Cargo
    {
        public int CargoWight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int wight, string type)
        {
            this.CargoWight = wight;
            this.CargoType = type;
        }
    }

    public class Car
    {
        public string Model { get; set; }

        public Engine EnginInfo { get; set; }

        public Cargo CargoInfo { get; set; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.EnginInfo = engine;
            this.CargoInfo = cargo;
        }

    }
    class Program
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string model = inputInfo[0];
                int engineSpeed = int.Parse(inputInfo[1]);
                int enginePower = int.Parse(inputInfo[2]);
                int cargoWight = int.Parse(inputInfo[3]);
                string cargotype = inputInfo[4];

                Engine currEngine = new Engine(engineSpeed, enginePower);
                Cargo currCargo = new Cargo(cargoWight, cargotype);

                Car newCar = new Car(model, currEngine, currCargo);
                listOfCars.Add(newCar);
            }

            string command = Console.ReadLine();

            switch (command)

            {
               case "fragile":

                    foreach (Car car in listOfCars)
                    {
                        if (car.CargoInfo.CargoType == "fragile" && car.CargoInfo.CargoWight < 1000)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;

                case "flamable":

                    foreach (Car car in listOfCars)
                    {
                        if (car.CargoInfo.CargoType == "flamable" && car.EnginInfo.EnginePower > 250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;
            }
        }
    }
}
