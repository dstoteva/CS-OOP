using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private double fuel;
        public double Fuel
        { get => this.fuel;
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
                    
            }
        }
        public double LitersPerKilometer { get; set; }
        public double TankCapacity { get; set; }
        public Vehicle(double fuel, double liters, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.LitersPerKilometer = liters;  
        }
        public string Drive(double distance)
        {
            if (distance*this.LitersPerKilometer <= this.Fuel)
            {
                this.Fuel -= this.LitersPerKilometer * distance; 
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
        public virtual void Refuel(double liters)
        {
            if (liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.Fuel += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }
    }
}
