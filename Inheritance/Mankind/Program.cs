using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentArgs = Console.ReadLine().Split();
                string studentsFirstName = studentArgs[0];
                string studentsSecondName = studentArgs[1];
                string facultyNum = studentArgs[2];

                string[] workerArgs = Console.ReadLine().Split();
                string workersFirstName = workerArgs[0];
                string workersSecondName = workerArgs[1];
                decimal salary = decimal.Parse(workerArgs[2]);
                double workingHours = double.Parse(workerArgs[3]);

                Student student = new Student(studentsFirstName, studentsSecondName, facultyNum);
                Worker worker = new Worker(workersFirstName, workersSecondName, salary, workingHours);
                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
