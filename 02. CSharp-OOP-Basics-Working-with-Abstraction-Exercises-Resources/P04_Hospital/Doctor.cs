using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private List<string> patients;

        public Doctor(string name)
        {
            this.Name = name;
            this.patients = new List<string>();
        }
        public Doctor(string name, List<string> patients)
        {
            this.Name = name;
            this.patients = patients;
        }
        public string Name { get; set; }

        public void AddPatient(string patient)
        {
            patients.Add(patient);
        }
        public List<string> ReturnPatients() => this.patients.OrderBy(x => x).ToList();
    }
}
