using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuel, double liters, double tankCapacity)
            : base(fuel, liters + 0.9, tankCapacity)
        {
        }
    }
}
