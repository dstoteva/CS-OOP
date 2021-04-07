using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Students
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        private Dictionary<string, Student> students;

        public void Add(string name, int age, double grade)
        {
            if (!students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                students[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (students.ContainsKey(name))
            {
                var student = this.students[name];

                return student;
            }
                throw new InvalidOperationException($"Student with name '{name}' could not be found.");
        }
        public void ParseCommand()
        {
            var commandParts = Console.ReadLine().Split();
            var commandName = commandParts[0];

            if (commandName == "Create")
            {
                var name = commandParts[1];
                var age = int.Parse(commandParts[2]);
                var grade = double.Parse(commandParts[3]);
                
            }
            else if (commandName == "Show")
            {
                var name = commandParts[1];
                

            }
            else if (commandName == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
