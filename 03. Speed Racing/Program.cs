using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    public class Car
    { 
        public string CarModel { get; set; }
        public double FuelAmounth { get; set; }

        public double FuelConsumpForOneKilo { get; set; }

        public int traveledDistance = 0;

        public Car(string name, double fuel, double consump)
        {
            this.CarModel = name;
            this.FuelAmounth = fuel;
            this.FuelConsumpForOneKilo = consump;
        }
    }

    class Program
    {
        static double CheckIsHaveFuel(Car model, double distance)
        {

            double currModelFuel = model.FuelAmounth;
            double currModelConsump = model.FuelConsumpForOneKilo;
            double consumedFuelForDistance = distance * currModelConsump;
            currModelFuel -= consumedFuelForDistance;
            return currModelFuel;
        }

        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string carModel = inputInfo[0];
                double fuelAmounth = double.Parse(inputInfo[1]);
                double fuelConsump = double.Parse(inputInfo[2]);

                Car newCar = new Car(carModel, fuelAmounth, fuelConsump);
                listOfCars.Add(newCar);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] driveInfo = input.Split();

                string model = driveInfo[1];
                int travelDistance = int.Parse(driveInfo[2]);

                for (int i = 0; i < listOfCars.Count; i++)
                {
                    string currModel = listOfCars[i].CarModel;

                    if (currModel == model)
                    {
                        double carFuelcheck = CheckIsHaveFuel(listOfCars[i], travelDistance);
                        if (carFuelcheck < 0)
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                            break;
                        }
                        else
                        {
                            double currFuelAmounth = listOfCars[i].FuelAmounth;
                            double currFuelConsump = listOfCars[i].FuelConsumpForOneKilo;
                            listOfCars[i].FuelAmounth = currFuelAmounth - travelDistance * currFuelConsump;
                            listOfCars[i].traveledDistance += travelDistance;
                            break;
                        }
                    }
                }
            }

            foreach (Car car in listOfCars)
            {
                Console.WriteLine($"{car.CarModel} {car.FuelAmounth:F2} {car.traveledDistance}");
            }
        }
    }
}
