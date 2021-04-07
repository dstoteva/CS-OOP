using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models.Privates
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var p in Privates)
            {
                sb.AppendLine("  " + p.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
