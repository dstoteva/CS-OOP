using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IUnitFactory unitFactory, IRepository unitRepository) 
            : base(data, unitFactory, unitRepository)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
