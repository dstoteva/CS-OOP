using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts.Privates.SpecialisedSoldiers;

namespace MilitaryElite.Models.Privates.SpecialisedSoldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public IReadOnlyCollection<Repair> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Repairs:");
            foreach (var r in Repairs)
            {
                sb.AppendLine("  " + r.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
