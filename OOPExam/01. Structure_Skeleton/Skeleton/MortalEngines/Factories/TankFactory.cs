using MortalEngines.Entities.Machines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories
{
    public class TankFactory
    {
        public Tank CreateTank(string name, double attackPoints, double defensePoints)
        {
            return new Tank(name, attackPoints, defensePoints);
        }
    }
}
