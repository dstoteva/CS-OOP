using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO
{
    public class Command : ICommand
    {
        public Command(string name, string[] parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }
        public string Name { get; }

        public string[] Parameters { get; }
    }
}
