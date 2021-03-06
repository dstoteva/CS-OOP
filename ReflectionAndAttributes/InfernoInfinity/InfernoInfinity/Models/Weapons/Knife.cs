using InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int MaxDamage = 4;
        private const int MinDamage = 3;
        private const int GemSockets = 2;

        public Knife(string name, WeaponRarity rarity)
            : base(name, rarity, MaxDamage, MinDamage, GemSockets)
        {
        }
    }
}
