using _Data.Refactor.Models.SOs.Players;
using VyesBase.Core.Architecture.Model;

namespace _Data.Refactor.Models.Runtimes.Players
{
    public class BasePlayerSoRuntime : BaseSoRuntime
    {
        protected BasePlayerSo basePlayerSo;
        public string Name { get; private set; }
        public float Health { get; private set; }
        public float HealthRegen { get; private set; }
        public float AttackDamage { get; private set; }
        public float AbilityPower { get; private set; }
        public float Armor { get; private set; }
        public float MagicResistance { get; private set; }
        public float MoveSpeed { get; private set; }
        public float CriticalChance { get; private set; }
        public float CriticalDamage { get; private set; }
        public float ArmorPenetration { get; private set; }
        public float MagicPenetration { get; private set; }
        public float LifeSteal { get; private set; }
        public float Omnivamp { get; private set; }
        public float Haste { get; private set; }
        public float HealingPower { get; private set; }
        public float PickUpRange { get; private set; }
        public float ExpMultiplier { get; private set; }

        public BasePlayerSoRuntime(BasePlayerSo baseSo) : base(baseSo)
        {
            basePlayerSo = baseSo;
            Name = baseSo.name;
            Health = baseSo.health;
            HealthRegen = baseSo.healthRegen;
            AttackDamage = baseSo.attackDamage;
            AbilityPower = baseSo.abilityPower;
            MagicResistance = baseSo.magicResistance;
            Armor = baseSo.armor;
            MoveSpeed = baseSo.moveSpeed;
            CriticalChance = baseSo.criticalChance;
            CriticalDamage = baseSo.criticalDamage;
            ArmorPenetration = baseSo.armorPenetration;
            MagicPenetration = baseSo.magicPenetration;
            LifeSteal = baseSo.lifeSteal;
            Omnivamp = baseSo.omnivamp;
            Haste = baseSo.haste;
            HealingPower = baseSo.healingPower;
            PickUpRange = baseSo.pickUpRange;
            ExpMultiplier = baseSo.expMultiplier;
        }
    }
}