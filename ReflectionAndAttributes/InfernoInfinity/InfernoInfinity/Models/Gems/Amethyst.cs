using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int AgilityBonus = 8;
        private const int StrengthBonus = 2;
        private const int VitalityBonus = 4;
        public Amethyst(GemClarity clarity) 
            : base(clarity, AgilityBonus, StrengthBonus, VitalityBonus)
        {
        }
    }
}
