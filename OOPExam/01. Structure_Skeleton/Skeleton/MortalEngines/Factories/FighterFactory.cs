using MortalEngines.Entities.Machines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories
{
    public class FighterFactory
    {
        public Fighter CreateFighter(string name, double attackPoints, double defensePoints)
        {
            return new Fighter(name, attackPoints, defensePoints);
        }
    }
}
