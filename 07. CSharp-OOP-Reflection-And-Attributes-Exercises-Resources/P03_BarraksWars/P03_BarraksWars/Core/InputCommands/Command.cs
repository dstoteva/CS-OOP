using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.InputCommands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IUnitFactory unitFactory;
        private IRepository unitRepository;

        protected Command(string[] data, IUnitFactory unitFactory, IRepository unitRepository)
        {
            this.data = data;
            this.unitFactory = unitFactory;
            this.unitRepository = unitRepository;
        }
        protected string[] Data => this.data;
        protected IUnitFactory UnitFactory => this.unitFactory;
        protected IRepository Repository => this.unitRepository;
        public abstract string Execute();
    }
}
