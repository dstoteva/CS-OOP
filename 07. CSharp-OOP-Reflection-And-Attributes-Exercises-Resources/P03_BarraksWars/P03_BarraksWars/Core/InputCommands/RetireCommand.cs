using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IUnitFactory unitFactory, IRepository unitRepository) 
            : base(data, unitFactory, unitRepository)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
