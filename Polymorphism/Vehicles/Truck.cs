using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        public Truck(double fuel, double liters, double tankCapacity)
            : base(fuel, liters + 1.6, tankCapacity)
        {
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.Fuel -= liters * 0.05;
        }
    }
}
