using InfernoInfinity.Contracts;
using InfernoInfinity.Enums;
using InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Factories
{
    public class WeaponFactory
    {
        internal IWeapon CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
        {
            WeaponRarity rarity;
            var isRarityValid = Enum.TryParse(weaponRarity, out rarity);
            if (!isRarityValid)
            {
                return null;
            }
            switch (weaponKind)
            {
                case "Axe":
                    return new Axe(weaponName, rarity);
                case "Sword":
                    return new Sword(weaponName, rarity);
                case "Knife":
                    return new Knife(weaponName, rarity);
                default:
                    return null;
            }
        }
    }
}
