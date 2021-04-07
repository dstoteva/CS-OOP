using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] jetoni = command.Split();
                var departament = jetoni[0];
                var purvoIme = jetoni[1];
                var vtoroIme = jetoni[2];
                var pacient = jetoni[3];
                var cqloIme = purvoIme + vtoroIme;

                
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool imaMqsto = departments[departament].SelectMany(x => x).Count() < 60;
                if (imaMqsto)
                {
                    int staq = 0;
                    if (!doctors.Any(x => x.Name == cqloIme))
                    {
                        Doctor doctor = new Doctor(cqloIme);
                        doctors.Add(doctor);
                    }
                    doctors.FirstOrDefault(x => x.Name == cqloIme).AddPatient(pacient);
                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            staq = st;
                            break;
                        }
                    }
                    departments[departament][staq].Add(pacient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Doctor doctor = doctors.FirstOrDefault(x => x.Name == args[0] + args[1]);
                    Console.WriteLine(string.Join("\n", doctor.ReturnPatients()));
                    
                }
                command = Console.ReadLine();
            }
        }
    }
}
