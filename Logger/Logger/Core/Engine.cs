using LoggerDemo.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(appenderArgs);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("|");

                if (input[0] == "END")
                {
                    break;
                }
                this.commandInterpreter.AddReport(input);
            }
            this.commandInterpreter.PrintInfo();
        }
    }
}
