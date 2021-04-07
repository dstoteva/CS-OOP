using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                ExceptionThrower(value, 4, nameof(firstName));
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                ExceptionThrower(value, 3, nameof(lastName));
                this.lastName = value;
            }
        }
        
        private void ExceptionThrower(string value, int length, string name)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {name}");
            }
            if (value.Length < length)
            {
                throw new ArgumentException($"Expected length at least {length} symbols! Argument: {name}");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.firstName}");
            sb.AppendLine($"Last Name: {this.lastName}");
            return sb.ToString();
        }
    }
}
