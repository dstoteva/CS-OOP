using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);
        void AddReport(string[] args);
        void PrintInfo();

    }
}
