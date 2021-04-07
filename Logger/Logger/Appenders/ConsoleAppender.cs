using LoggerDemo.Appenders.Contracts;
using LoggerDemo.Layouts.Contracts;
using LoggerDemo.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base (layout)
        {
        }
       
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.Count++;
            }
            
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
