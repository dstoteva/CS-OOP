using P03_StudentSystem.Commands;
using P03_StudentSystem.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;
        private Func<string> readInput;

        public Engine(CommandParser commandParser, StudentSystem studentSystem, Func<string> readInput)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.readInput = readInput;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = commandParser.Parse(this.readInput());

                    if (command.Name == "Exit")
                    {
                        break;
                    }

                    if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];

                        var student = studentSystem.Get(name);

                        Console.WriteLine(student);
                    }
                }
                catch
                {

                    continue;
                }

            }
        }
    }
}
