using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Model => "488-Spider";
        public string Driver { get; private set; }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Gas!";
        }
        public override string ToString()
        {
            return $"{this.Model}/{this.PushBrakes()}/{this.PushGasPedal()}/{this.Driver}";
        }
    }
}
