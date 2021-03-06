using InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int AgilityBonus = 2;
        private const int StrengthBonus = 7;
        private const int VitalityBonus = 5;
        public Ruby(GemClarity clarity)
            : base(clarity, AgilityBonus, StrengthBonus, VitalityBonus)
        {
        }
    }
}
