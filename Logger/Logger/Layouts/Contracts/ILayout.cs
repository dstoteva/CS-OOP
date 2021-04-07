using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
