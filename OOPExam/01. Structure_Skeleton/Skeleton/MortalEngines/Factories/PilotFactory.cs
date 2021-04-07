using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories
{
    public class PilotFactory
    {
        public Pilot CreatePilot(string name)
        {
            Pilot pilot = new Pilot(name);

            return pilot;
        }
    }
}
