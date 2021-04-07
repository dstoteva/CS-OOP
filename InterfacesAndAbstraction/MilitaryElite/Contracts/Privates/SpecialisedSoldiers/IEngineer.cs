using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Privates.SpecialisedSoldiers;

namespace MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
