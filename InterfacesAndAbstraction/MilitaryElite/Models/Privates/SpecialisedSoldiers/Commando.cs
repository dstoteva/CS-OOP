using MilitaryElite.Contracts.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models.Privates.SpecialisedSoldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions { get;}


        public void CompleteMission(string codeName)
        {
            Mission mission = Missions.FirstOrDefault(x => x.CodeName == codeName);
            if (mission != null)
            {
                mission.State = "Finished";
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions: ");
            foreach (var m in this.Missions)
            {
                sb.AppendLine("  " + m.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
