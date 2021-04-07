using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNum;

        public Student(string firstName, string secondName, string facultyNum) 
            : base(firstName, secondName)
        {
            this.FacultyNum = facultyNum;
        }
        public string FacultyNum
        {
            get => this.facultyNum;
            set
            {
                if (value.Length < 5 || value.Length > 10 || !Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNum = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Faculty number: {this.facultyNum}");
            return sb.ToString();
        }
    }
}
