namespace P03_StudentSystem.Students
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            var strudentInfo = $"{this.Name} is {this.Age} years old.";

            if (this.Grade >= 5.00)
            {
                strudentInfo += " Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                strudentInfo += " Average student.";
            }
            else
            {
                strudentInfo += " Very nice person.";
            }
            return strudentInfo;
        }
    }
}