using LoggerDemo.Appenders.Contracts;
using LoggerDemo.Layouts.Contracts;
using LoggerDemo.Loggers.Contracts;
using LoggerDemo.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace LoggerDemo.Appenders
{
    public class FileAppender : Appender
    {
        private const string path = @"..\..\..\log.txt";
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                File.AppendAllText(path, content);
                this.Count++;
            }
        }
        public long ReturnSum()
        {
            long size = 0;
            foreach (var word in File.ReadAllLines(path))
            {
                size += word.Where(x => char.IsLetter(x)).Select(x => (int)x).Sum();
            }
            return size;
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.ReturnSum()}";
        }
    }
}
