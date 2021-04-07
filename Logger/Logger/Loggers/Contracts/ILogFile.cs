﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Loggers.Contracts
{
    public interface ILogFile
    {
        void Write(string message);
        int Size { get; }
    }
}
