using LoggerDemo.Appenders.Contracts;
using LoggerDemo.Layouts.Contracts;
using LoggerDemo.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
