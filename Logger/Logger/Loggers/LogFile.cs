using LoggerDemo.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoggerDemo.Loggers
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}
