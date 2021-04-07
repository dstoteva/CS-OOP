using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        private List<ICommand> commands;

        public Reader()
        {
            this.commands = new List<ICommand>();
        }
        public IList<ICommand> ReadCommands()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string commandName = input[0];
                string[] parameters = input.Skip(1).ToArray();
                if (commandName == "Quit")
                {
                    break;
                }
                Command command = new Command(commandName, parameters);
                this.commands.Add(command);
            }

            return this.commands;
        }
    }
}
