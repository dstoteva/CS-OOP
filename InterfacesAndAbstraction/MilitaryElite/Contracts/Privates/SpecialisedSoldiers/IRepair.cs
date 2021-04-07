using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
