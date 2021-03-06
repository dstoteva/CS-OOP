using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO.Contracts
{
    public interface ICommand
    {
        string Name { get; }
        string[] Parameters { get; }
    }
}
