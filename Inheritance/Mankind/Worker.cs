using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        public decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value < 10)
                {
                    ExceptionThrower(nameof(weekSalary));
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    ExceptionThrower(nameof(workHoursPerDay));
                }
                this.workHoursPerDay = value;
            }
        }

        private void ExceptionThrower(string name)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: {name}");
        }

        private decimal SalaryPerHourCalculator()
        {
            return weekSalary / ((decimal)workHoursPerDay * 5);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Week Salary: {this.weekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {SalaryPerHourCalculator():f2}");
            return sb.ToString();
        }
    }
}
