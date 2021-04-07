using InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MaxDamage { get; }
        int MinDamage { get; }
        WeaponRarity Rarity { get; }
        IGem[] GemSockets { get; }
        void AddGem(IGem gem, int socketIndex);
        void RemoveGem(int socketIndex);
    }
}
