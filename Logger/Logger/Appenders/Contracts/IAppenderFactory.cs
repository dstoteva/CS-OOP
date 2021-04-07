using LoggerDemo.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
