using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_StudentSystem.Commands
{
    public class CommandParser
    {
        public Command Parse(string command)
        {
            var parts = command.Split();
            return new Command
            {
                Name = parts[0],
                Arguments = parts.Skip(1).ToArray()
            };
        }
    }
}
