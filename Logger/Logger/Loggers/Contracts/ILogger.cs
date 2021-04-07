using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string message);
        void Info(string dateTime, string info);
        void Warning(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Critical(string dateTime, string message);


    }
}
