using LoggerDemo.Appenders;
using LoggerDemo.Appenders.Contracts;
using LoggerDemo.Layouts;
using LoggerDemo.Layouts.Contracts;
using LoggerDemo.Loggers.Contracts;
using System;
using LoggerDemo.Loggers;
using LoggerDemo.Loggers.Enums;
using LoggerDemo.Core;
using LoggerDemo.Core.Contracts;

namespace LoggerDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();

        }
    }
}
