using MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }

        void CompleteMission(string codeName);
    }
}
