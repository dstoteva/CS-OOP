using MortalEngines.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core.Contracts
{
    public class Engine : IEngine
    {
        private MachinesManager machineManager;
        private Reader reader;
        private Writer writer;

        public Engine()
        {
            this.machineManager = new MachinesManager();
            this.reader = new Reader();
            this.writer = new Writer();
        }
        public void Run()
        {
            var commands = this.reader.ReadCommands();

            foreach (var command in commands)
            {
                try
                {
                    string commandName = command.Name;
                    string name = command.Parameters[0];
                    switch (commandName)
                    {
                        case "HirePilot":
                           this. writer.Write(this.machineManager.HirePilot(name));
                            break;
                        case "PilotReport":
                            this.writer.Write(this.machineManager.PilotReport(name));
                            break;
                        case "MachineReport":
                            this.writer.Write(this.machineManager.MachineReport(name));
                            break;
                        case "AggressiveMode":
                            this.writer.Write(this.machineManager.ToggleFighterAggressiveMode(name));
                            break;
                        case "DefenseMode":
                            this.writer.Write(this.machineManager.ToggleTankDefenseMode(name));
                            break;
                        case "Engage":
                            string machineName = command.Parameters[1];
                            this.writer.Write(this.machineManager.EngageMachine(name, machineName));
                            break;
                        case "Attack":
                            string defendingMachine = command.Parameters[1];
                            this.writer.Write(this.machineManager.AttackMachines(name, defendingMachine));
                            break;
                        case "ManufactureTank":
                            double attack = double.Parse(command.Parameters[1]);
                            double defense = double.Parse(command.Parameters[2]);
                            this.writer.Write(this.machineManager.ManufactureTank(name, attack, defense));
                            break;
                        case "ManufactureFighter":
                            double attackFighter = double.Parse(command.Parameters[1]);
                            double defenseFighter = double.Parse(command.Parameters[2]);
                            this.writer.Write(this.machineManager.ManufactureFighter(name, attackFighter, defenseFighter));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Error: " + ex.InnerException.Message);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    
                }
                
            }
        }
    }
}
