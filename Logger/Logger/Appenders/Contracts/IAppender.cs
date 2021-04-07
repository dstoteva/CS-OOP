using LoggerDemo.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);
        ReportLevel ReportLevel { get; set; }
    }
}
