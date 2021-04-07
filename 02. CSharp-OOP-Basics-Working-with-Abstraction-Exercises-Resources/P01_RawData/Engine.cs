using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        private int engineSpeed;

        public Engine(int speed, int power)
        {
            this.engineSpeed = speed;
            this.Power = power;
        }
        public int Power { get; private set; }
    }
}
