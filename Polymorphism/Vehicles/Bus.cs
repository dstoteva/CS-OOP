using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuel, double liters, double tankCapacity) 
            : base(fuel, liters + 1.4, tankCapacity)
        {
        }
        public string DriveEmpty(double distance)
        {
            this.LitersPerKilometer = LitersPerKilometer - 1.4;
            return base.Drive(distance);
        }
    }
}
