using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine().Split();
            double carFuel = double.Parse(carArgs[1]);
            double carLitersPerKilometer = double.Parse(carArgs[2]);
            double carCapacity = double.Parse(carArgs[3]);
            Car car = new Car(carFuel, carLitersPerKilometer, carCapacity);

            string[] truckArgs = Console.ReadLine().Split();
            double truckFuel = double.Parse(truckArgs[1]);
            double truckLitersPerKilometer = double.Parse(truckArgs[2]);
            double truckCapacity = double.Parse(truckArgs[3]);
            Truck truck = new Truck(truckFuel, truckLitersPerKilometer, truckCapacity);

            string[] busArgs = Console.ReadLine().Split();
            double busFuel = double.Parse(busArgs[1]);
            double busLiters = double.Parse(busArgs[2]);
            double busCapacity = double.Parse(busArgs[3]);
            Bus bus = new Bus(busFuel, busLiters, busCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string command = inputArgs[0];
                string vehicleType = inputArgs[1];
                double measures = double.Parse(inputArgs[2]);                
                try
                {
                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(measures));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(measures));
                        }
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(measures));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(measures);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(measures);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(measures);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.DriveEmpty(measures));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }  
                
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
