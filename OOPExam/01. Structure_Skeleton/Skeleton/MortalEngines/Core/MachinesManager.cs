namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Factories;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;
        private PilotFactory pilotFactory;
        private FighterFactory fighterFactory;
        private TankFactory tankFactory;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.pilotFactory = new PilotFactory();
            this.fighterFactory = new FighterFactory();
            this.tankFactory = new TankFactory();
        }
        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                Pilot pilot = this.pilotFactory.CreatePilot(name);
                this.pilots.Add(pilot);
                return $"Pilot {name} hired";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(t => t.Name == name && t.GetType().Name == "Tank"))
            {
                return $"Machine {name} is manufactured already";
            }
            Tank tank = this.tankFactory.CreateTank(name, attackPoints, defensePoints);
            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(f => f.Name == name && f.GetType().Name == "Fighter"))
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                Fighter fighter = this.fighterFactory.CreateFighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);
                
                return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            else if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            else if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            else if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            else if (attackingMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (defendingMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                attackingMachine.Attack(defendingMachine);
                return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
            }
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter fighter = (Fighter)this.machines.FirstOrDefault(f => f.Name == fighterName && f.GetType().Name == "Fighter");
            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)this.machines.FirstOrDefault(x => x.Name == tankName && x.GetType().Name == "Tank");
            if (tank == null)
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}