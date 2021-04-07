using LoggerDemo.Appenders.Contracts;
using LoggerDemo.Layouts.Contracts;
using LoggerDemo.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo.Appenders
{
    public abstract class Appender : IAppender
    {
        public int Count { get; set; }
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.Count = 0;
        }
        protected ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.Count}"; 
        }
    }
}
