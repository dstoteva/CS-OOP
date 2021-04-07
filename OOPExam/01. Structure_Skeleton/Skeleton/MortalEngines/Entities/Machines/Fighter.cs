using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double initialHealthPoint = 200;
        private const double attackPointsToBeChanged = 50;
        private const double defencePointsToBeChanged = 25;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoint)
        {
            this.AggressiveMode = false;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints -= attackPointsToBeChanged;
                this.DefensePoints += defencePointsToBeChanged;
                this.AggressiveMode = false;
            }
            else if (this.AggressiveMode == false)
            {
                this.AttackPoints += attackPointsToBeChanged;
                this.DefensePoints -= defencePointsToBeChanged;
                this.AggressiveMode = true;
            }
        }
        public override string ToString()
        {
            string aggressiveMode = this.AggressiveMode == false ? "OFF" : "ON";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveMode}";
        }
    }
}

