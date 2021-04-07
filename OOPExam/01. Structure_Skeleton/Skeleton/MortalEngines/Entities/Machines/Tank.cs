using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoint = 100;
        private const double attackPointsToBeChanged = 40;
        private const double defencePointsToBeChanged = 30;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, initialHealthPoint)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints += attackPointsToBeChanged;
                this.DefensePoints -= defencePointsToBeChanged;
                this.DefenseMode = false;
            }
            else if (this.DefenseMode == false)
            {
                this.AttackPoints -= attackPointsToBeChanged;
                this.DefensePoints += defencePointsToBeChanged;
                this.DefenseMode = true;
            }
        }
        public override string ToString()
        {
            string defenceMode = this.DefenseMode == false ? "OFF" : "ON";
            return base.ToString() + Environment.NewLine + $" *Defense: {defenceMode}";
        }
    }
}
